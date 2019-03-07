using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_MomPop_QueN : System.Web.UI.Page
{

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Bind();

            Button1.Attributes.Add("onclick", "window.opener=null;window.close()");
        }
    }

    private void Bind()
    {
        //GridView2.Columns[5].HeaderText = "现存量";
        string parValue = Request.QueryString["id"];
        if (String.IsNullOrEmpty(parValue))
        {
            Response.Write("<script>window.close();</script>");
            Response.Redirect("./Mom.aspx");
            Response.End();
        }
        DataSet ds = SQLHelper.Query("select inventory.cDefWareHouse AS whcode,mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,Warehouse.[cWhName],mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, 0.00 xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling " +
                                     "from mom_moallocate " +
                                     "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
                                     "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +
                                     //"left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
                                     "left join Warehouse on Warehouse.cWhCode = mom_moallocate.whcode  " +
                                     "where mom_moallocate.modid=" + parValue + " " +
                                     "order by mom_moallocate.whcode");
        //this.HiddenField1.Value = row.Cells[0].Text;
        //this.HiddenField2.Value = row.Cells[4].Text;
        //this.HiddenField3.Value = row.Cells[3].Text;
        //this.HiddenField4.Value = row.Cells[6].Text;
        DataTable dt = ds.Tables[0];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["xiancun"] =
                SQLHelper.Query(
                    "select Isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity),0) from CurrentStock where CurrentStock.cInvCode ='" +
                    dt.Rows[i]["invcode"].ToString() + "'  and CurrentStock.cWhCode='" + dt.Rows[i]["whcode"].ToString() + "'  ").Tables[0].Rows[0][0].ToString();
        }
        DataRow[] drArr = dt.Select("(qty - issqty)>xiancun");
        DataTable dtNew = dt.Clone();
        for (int i = 0; i < drArr.Length; i++)
        {
            dtNew.ImportRow(drArr[i]);

        }

        dt.Clear();
        dt = dtNew;

        this.HiddenField1.Value = Request.QueryString["p1"];

        this.HiddenField2.Value = Request.QueryString["p2"];
        this.HiddenField3.Value = Request.QueryString["p3"];
        this.HiddenField4.Value = Request.QueryString["p4"];
        this.HiddenField6.Value = Request.QueryString["p6"];

        if (HiddenField1.Value.Equals("1301") && this.HiddenField6.Value.StartsWith("03"))
        {
            //GridView2.Columns[5].HeaderText = "现存量(不区分仓库)";
           ds = SQLHelper.Query("select mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,Warehouse.[cWhName],mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, 0.00 xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling " +
                                     "from mom_moallocate " +
                                     "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
                                     "left join inventory on mom_moallocate.invcode = inventory.cinvcode   " +
                                     //"left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
                                     "left join Warehouse on Warehouse.cWhCode = mom_moallocate.whcode  " +
                                     "where mom_moallocate.modid=" + parValue + "  " +
                                     "  and (inventory.[cInvCCode] like '0103%'  or inventory.[cInvCCode] like '02%')" +
                                     "order by mom_moallocate.whcode");
           dt = ds.Tables[0];
            //dt.Select()
            //DataView dv = dt.DefaultView;
            //dv.
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["xiancun"] =
                    SQLHelper.Query(
                        "select Isnull(sum(CurrentStock.iQuantity) - sum(CurrentStock.fOutQuantity),0) from CurrentStock where CurrentStock.cInvCode ='" +
                        dt.Rows[i]["invcode"].ToString() + "'").Tables[0].Rows[0][0].ToString();
            }
             drArr = dt.Select("(qty - issqty)>xiancun");
             dtNew = dt.Clone();
            for (int i = 0; i < drArr.Length; i++)
            {
                dtNew.ImportRow(drArr[i]);

            }

            dt.Clear();
            dt = dtNew;

        }

        


        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

}