using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_DiaoBoDan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
  public DataSet ExcelToSet(String Path_Im ,bool Delete)
            {
                try
                {
                    DataSet SheetSet = new DataSet();
                    //通过OleDb连接到Excel

                    //string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path_Im + ";" +
                    //                 "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";

                    String conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path_Im + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                    System.Data.OleDb.OleDbConnection DbConn = new System.Data.OleDb.OleDbConnection(conString);
                    //MessageBox.Show(this, "333");
                    DbConn.Open();

                    if (DbConn.State == ConnectionState.Open)
                    {
                    //获取Sheet列表
                        System.Data.DataTable Schema_dt = DbConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                        if (Schema_dt != null)
                        {
                            foreach (DataRow dr in Schema_dt.Rows)//遍历所有Sheet
                            {
                                String SheetName = dr["TABLE_NAME"].ToString();//获取Sheet名称
                                DataTable Dt_Sheet = new DataTable();
                                 OleDbDataAdapter adapter   =new System.Data.OleDb.OleDbDataAdapter(
                                        String.Format("select * from [{0}]", SheetName), DbConn);
                                adapter.Fill(Dt_Sheet);
                                //填充Sheet数据到DataTable
                                //获取的Sheet名称是带后缀的，需要处理一下
                                SheetName = SheetName.TrimStart("'".ToCharArray());
                                SheetName = SheetName.TrimEnd("'".ToCharArray());
                                SheetName = SheetName.TrimEnd("$".ToCharArray());
                                Dt_Sheet.TableName = SheetName;
                                //添加该Sheet（作为一个DataTable）的数据到DataSet
                                try { SheetSet.Tables.Add(Dt_Sheet); }
                                catch { }
                            }
                        }
                        else
                            SheetSet = null;
                        DbConn.Close();
                    }
                    else
                        SheetSet = null;
                    //删除临时文档
                    if (Delete && File.Exists(Path_Im))
                        File.Delete(Path_Im);
                    return SheetSet;
                }
                catch (Exception err)
                {
                    MessageBox.Show(this,err.Message);
                }
                return null;
            }

    protected void Button1_Click(object sender, EventArgs e)
    {

       


        HiddenField Label_Msg = new HiddenField();
        Label_Msg.Value = "";

        String path_temp = "";
        if (FileUpload_Excel.HasFile)
        {
            if ((System.IO.Path.GetExtension(FileUpload_Excel.FileName)).ToLower().StartsWith(".xls"))//检测扩展名
            {
                try
                {
                    DateTime dt = System.DateTime.Now;
                    string str = dt.ToString("yyyyMMddhhmmss");
                    str = str + ".xls";

                    path_temp = Server.MapPath("../images/files/");

                    // path_temp = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); //要保存的临时路径
                    path_temp = path_temp + "\\" + str;
                    FileUpload_Excel.SaveAs(path_temp); //FileUpload的SaveAs方法实现上传
                    Label_Msg.Value = "";
                    //......读取文档
                }
                catch (Exception ex) { Label_Msg.Value = ex.Message; }
            }
            else Label_Msg.Value = "Only ECXEL-format doc. accepted!";
        }
        else Label_Msg.Value = "No file selected!.";

        if (!"".Equals(Label_Msg.Value))
        {
            MessageBox.Show(this, Label_Msg.Value);
            return;
        }
        else
        {
            

            //=================================

            //string[] a = new string[] { "010103", "010104", "010105", "010208" };
            try
            {
                List<String> SQLStringList = new List<string>();

                //string[] connString = DB.getConnString();
                //string conStr = "Data Source=" + connString[0] + ";Initial Catalog=" + connString[3] + ";uid =" +
                //                connString[1] + ";pwd=" + connString[2] + ";MultipleActiveResultSets=True";


                //读取Excel开始 dr["DLID"].ToString().Trim()
                //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + File1.Text.Trim() + ";" +
                //                 "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";

                DataSet ds = ExcelToSet(path_temp, false);

                //DataSet ds = new DataSet();
                //OleDbDataAdapter oada = new OleDbDataAdapter("select * from [主表$]", strConn);
                //oada.Fill(ds, "主表");
                //读取Excel结束

                string sql1 =
                    " select right('0000000000' + cast((max(cTVCode)) as varchar(10)),10) FROM [dbo].[TransVouch]";
                DataSet ds2= SQLHelperTool.Query(sql1);
                string cTVCode = ds2.Tables[0].Rows[0][0].ToString();

                    string sql3 =
                    " select max(ID)  FROM [dbo].[TransVouch]";
                DataSet ds3= SQLHelperTool.Query(sql3);
                int ID = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);

                string sql4 =
                  " select max(autoID)  FROM [dbo].[TransVouchs]";
                DataSet ds4 = SQLHelperTool.Query(sql4);
                int autoID = Convert.ToInt32(ds4.Tables[0].Rows[0][0]);
               
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    //读取Code值
                    if (!"".Equals(dr["转出仓库（01-37）"] )
                        && !"".Equals(dr["转入仓库（01-37）"].ToString())
                        && !"".Equals(dr["出库类别（201-215）"].ToString())
                        && !"".Equals(dr["入库类别（101-106）"].ToString())
                        
                        )
                    {
                        ++ID;
                        cTVCode = (System.Convert.ToInt32(cTVCode) + 1).ToString().PadLeft(10, '0');
                        StringBuilder sb = new StringBuilder();
                        string strsql主表 = "  " +
                                          "INSERT  [TransVouch]                        " +
                                          "        ( [cTVCode] ,                             " +
                                          "          [dTVDate] ,                             " +
                                          "          [cOWhCode] ,                            " +
                                          "          [cIWhCode] ,                            " +
                                          "          [cODepCode] ,                           " +
                                          "          [cIDepCode] ,                           " +
                                          "          [cPersonCode] ,                         " +
                                          "          [cIRdCode] ,                            " +
                                          "          [cORdCode] ,                            " +
                                          "          [cTVMemo] ,                             " +
                                          "          [cDefine1] ,                            " +
                                          "          [cDefine2] ,                            " +
                                          "          [cDefine3] ,                            " +
                                          "          [cDefine4] ,                            " +
                                          "          [cDefine5] ,                            " +
                                          "          [cDefine6] ,                            " +
                                          "          [cDefine7] ,                            " +
                                          "          [cDefine8] ,                            " +
                                          "          [cDefine9] ,                            " +
                                          "          [cDefine10] ,                           " +
                                          "          [cAccounter] ,                          " +
                                          "          [cMaker] ,                              " +
                                          "          [iNetLock] ,                            " +
                                          "          [ID] ,                                  " +
                                          "          [VT_ID] ,                               " +
                                          "          [cVerifyPerson] ,                       " +
                                          "          [dVerifyDate] ,                         " +
                                          "          [cPSPCode] ,                            " +
                                          "          [cMPoCode] ,                            " +
                                          "          [iQuantity] ,                           " +
                                          "          [bTransFlag] ,                          " +
                                          "          [cDefine11] ,                           " +
                                          "          [cDefine12] ,                           " +
                                          "          [cDefine13] ,                           " +
                                          "          [cDefine14] ,                           " +
                                          "          [cDefine15] ,                           " +
                                          "          [cDefine16] ,                           " +
                                          "          [iproorderid] ,                         " +
                                          "          [cOrderType] ,                          " +
                                          "          [cTranRequestCode] ,                    " +
                                          "          [cVersion] ,                            " +
                                          "          [BomId] ,                               " +
                                          "          [cFree1] ,                              " +
                                          "          [cFree2] ,                              " +
                                          "          [cFree3] ,                              " +
                                          "          [cFree4] ,                              " +
                                          "          [cFree5] ,                              " +
                                          "          [cFree6] ,                              " +
                                          "          [cFree7] ,                              " +
                                          "          [cFree8] ,                              " +
                                          "          [cFree9] ,                              " +
                                          "          [cFree10] ,                             " +
                                          "          [cAppTVCode] ,                          " +
                                          "          [csource] ,                             " +
                                          "          [itransflag]                            " +
                                          "        )                                         " +
                                          "VALUES  ( N'" + cTVCode + "' ,                         " +
                                          "          '"+DateTime.Now.Date.ToString()+"' ,  " +
                                          "          N'"+dr["转出仓库（01-37）"]+"' ,                                 " +
                                          "          N'"+dr["转入仓库（01-37）"]+"' ,                                 " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          N'"+dr["入库类别（101-106）"]+"' ,                                " +
                                          "          N'"+dr["出库类别（201-215）"]+"' ,                                " +
                                          "          N'"+dr["备注(主表)"]+"' ,                             " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          N'"+User.Identity.Name+"' ,                             " +
                                          "          0 ,                                     " +
                                          "          "+ID+" ,                                 " +
                                          "          89 ,                                    " +
                                          "          NULL,                             " +
                                          "          NULL ,  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          0 ,                                     " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          NULL ,                                  " +
                                          "          N'1' ,                                  " +
                                          "          N'正向'                                 " +
                                          "        )                                         ";

                        sb.Append(strsql主表);
                        SQLStringList.Add((sb.ToString()));
                        //continue;                  
                    }


                    ++autoID;
                    string strsql子表 = "  " +
                                      "INSERT  [dbo].[TransVouchs]            " +
                                      "        ( [cTVCode] ,                  " +
                                      "          [cInvCode] ,                 " +
                                      "          [RdsID] ,                    " +
                                      "          [iTVNum] ,                   " +
                                      "          [iTVQuantity] ,              " +
                                      "          [iTVACost] ,                 " +
                                      "          [iTVAPrice] ,                " +
                                      "          [iTVPCost] ,                 " +
                                      "          [iTVPPrice] ,                " +
                                      "          [cTVBatch] ,                 " +
                                      "          [dDisDate] ,                 " +
                                      "          [cFree1] ,                   " +
                                      "          [cFree2] ,                   " +
                                      "          [cDefine22] ,                " +
                                      "          [cDefine23] ,                " +
                                      "          [cDefine24] ,                " +
                                      "          [cDefine25] ,                " +
                                      "          [cDefine26] ,                " +
                                      "          [cDefine27] ,                " +
                                      "          [cItemCode] ,                " +
                                      "          [cItem_class] ,              " +
                                      "          [fSaleCost] ,                " +
                                      "          [fSalePrice] ,               " +
                                      "          [cName] ,                    " +
                                      "          [cItemCName] ,               " +
                                      "          [autoID] ,                   " +
                                      "          [ID] ,                       " +
                                      "          [iMassDate] ,                " +
                                      "          [cBarCode] ,                 " +
                                      "          [cAssUnit] ,                 " +
                                      "          [cFree3] ,                   " +
                                      "          [cFree4] ,                   " +
                                      "          [cFree5] ,                   " +
                                      "          [cFree6] ,                   " +
                                      "          [cFree7] ,                   " +
                                      "          [cFree8] ,                   " +
                                      "          [cFree9] ,                   " +
                                      "          [cFree10] ,                  " +
                                      "          [cDefine28] ,                " +
                                      "          [cDefine29] ,                " +
                                      "          [cDefine30] ,                " +
                                      "          [cDefine31] ,                " +
                                      "          [cDefine32] ,                " +
                                      "          [cDefine33] ,                " +
                                      "          [cDefine34] ,                " +
                                      "          [cDefine35] ,                " +
                                      "          [cDefine36] ,                " +
                                      "          [cDefine37] ,                " +
                                      "          [iMPoIds] ,                  " +
                                      "          [cBVencode] ,                " +
                                      "          [cInVouchCode] ,             " +
                                      "          [dMadeDate] ,                " +
                                      "          [cMassUnit] ,                " +
                                      "          [iTRIds] ,                   " +
                                      "          [AppTransIDS] ,              " +
                                      "          [iSSoType] ,                 " +
                                      "          [iSSodid] ,                  " +
                                      "          [iDSoType] ,                 " +
                                      "          [iDSodid] ,                  " +
                                      "          [bCosting] ,                 " +
                                      "          [cvmivencode] ,              " +
                                      "          [cinposcode] ,               " +
                                      "          [coutposcode] ,              " +
                                      "          [iinvsncount]                " +
                                      "        )                              " +
                                      "VALUES  ( N'"+cTVCode+"' ,              " +
                                      "          N'" + dr["存货编码"] + "' ,             " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          '" + dr["数量"] + "' ,                          " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          '" + dr["供货商名称"] + "' ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          0 ,                          " +
                                      "          0 ,                          " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          '"+autoID+"' ,                     " +
                                      "          '"+ID+"' ,                      " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          '" + dr["备注"] + "' ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          1 ,                          " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL ,                       " +
                                      "          NULL                         " +
                                      "        )                              ";

                    SQLStringList.Add((strsql子表.ToString()));
                }

              
                if (SQLStringList.Count == 0)
                {
                    MessageBox.Show(this, "没有任何数据");
                    return;
                }

                if (SQLHelperTool.ExecuteSqlTran(SQLStringList) == 0)
                {
                    //Response.Write("<script>alert('生成报表失败');</script>");
                    MessageBox.Show(this, "执行SQL出错");
                    //MessageBox.Show(this, "生成报表失败");
                    return;
                }



                MessageBox.Show(this, "操作完成。");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {

                //successSw.Close();
                //failtureSw.Close();
            }

        }


    }
    
}