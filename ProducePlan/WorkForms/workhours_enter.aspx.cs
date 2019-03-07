using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_workhours_enter : System.Web.UI.Page
{

    DataSet _dsBind = null;
    Classes classes = new Classes();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            getParam();
            BindData();
        }
    }

    private void getParam()
    {
        string moDid = Request.QueryString["id"];

        if (String.IsNullOrEmpty(moDid))
        {
            Response.Write("<script>alert('缺少参数');window.opener=null;window.close();</script>");
            Response.End();
        }
        else
        {
            MoDId.Value = moDid;
        }

        string sql =
         "SELECT   SO_SOMain.cCusName,a.soseq,a.define25,a.SoDId,a.moid,a.SortSeq,Department.[cDepName],a.modid,a.MDeptCode,inventory.cinvdefine4,inventory.[cInvCode],a.SoCode, mom_order.mocode,a.InvCode,inventory.cinvname,a.Qty, a.QualifiedInQty, mom_morder.startdate,mom_morder.Duedate " +
         "FROM mom_orderdetail a " +
         "LEFT JOIN mom_order ON a.moid = mom_order.moid " +
         "LEFT JOIN mom_morder ON a.modid = mom_morder.modid" +
         " LEFT JOIN inventory ON a.InvCode = inventory.cInvCode " +
         "LEFT JOIN [Department] ON a.MDeptCode = [Department].[cDepCode] " +
         "LEFT join SO_SODetails on a.sodid=SO_SODetails.iSOsID  " +
         "LEFT join SO_SOMain on SO_SODetails.cSOCode=SO_SOMain.cSOCode  " +
         "WHERE a.status <> 4  and a.Qty <> a.QualifiedInQty and a.Status = 3  and 1=1 ";
        sql += " and  a.modid=" + MoDId.Value;
        DataSet ds = SQLHelper.Query(sql);

        totalQuantity.Value = ds.Tables[0].Rows[0]["Qty"].ToString();
        InvCode.Value = ds.Tables[0].Rows[0]["InvCode"].ToString();
        cInvName.Value = ds.Tables[0].Rows[0]["cInvName"].ToString();
        Label1.Text = cInvName.Value;
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {

    }

    public void BindData()
    {
        _dsBind = new DataSet();
        string sql =
            " SELECT  a.shenFlag,a.[autoid],a.name,'' as className,a.[iquantity],b.workhours, a.[modid], CONVERT(varchar(100), a.date, 23) as date,b.classId, " +
            " b.workhours, a.tworkhours  from  " +
            "[workerhoursEnter] a  " +
            " left join classes b on  b.classId=a.classId  " +
            //" left join workhours c on a.InvCode=c.InvCode and a.val=c.val " +
            //" left join worker  w on a.ncode=w.ncode" +
            "  where a.[modid]='" + MoDId.Value + "' ";
        //sql += " and  modid=" + MoDId.Value;
        _dsBind = SQLHelper1.Query(sql);
        DataTable dt = _dsBind.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["className"] = classes.GetRoute(dt.Rows[i]["classId"].ToString());
            //dt.Rows[i]["tworkhours"] = Convert.ToDecimal(dt.Rows[i]["workhours"].ToString()) *
                                       //Convert.ToDecimal(dt.Rows[i]["iquantity"].ToString());
        }
        //_dsBind = _ObjBusiness.GetBindDetails();
        GridView1.DataSource = _dsBind;
        GridView1.DataBind();


    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count == 0)
        {
            renderEmptyGridView(GridView1, "autoid,shenFlag,name,className, iquantity, modid,workhours,tworkhours,date");
        }
    }

    public static void renderEmptyGridView(GridView EmptyGridView, string FieldNames)
    {
        //将GridView变成只有Header和Footer列，以及被隐藏的空白资料列     
        DataTable dTable = new DataTable();
        char[] delimiterChars = { ',' };
        string[] colName = FieldNames.Split(delimiterChars);
        foreach (string myCol in colName)
        {
            DataColumn dColumn = new DataColumn(myCol.Trim());
            dTable.Columns.Add(dColumn);
        }
        DataRow dRow = dTable.NewRow();
        foreach (string myCol in colName)
        {
            dRow[myCol.Trim()] = DBNull.Value;
        }
        dTable.Rows.Add(dRow);
        EmptyGridView.DataSourceID = null;
        EmptyGridView.DataSource = dTable;
        EmptyGridView.DataBind();
        EmptyGridView.Rows[0].Visible = false;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList dropTemp = (DropDownList)e.Row.FindControl("DropDownList1");

            TextBox txtDateF = (TextBox)e.Row.FindControl("txtDateF");
            txtDateF.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
            if (dropTemp != null)
            {
                string strRole = "";
                //if (User.Identity.Name.Equals("离心风机车间"))
                //{
                //    strRole = "lixinchejian";
                //}
                string[] a = Roles.GetUsersInRole(User.Identity.Name);

                List<string> datas1 = new List<string>();
                List<string> datas2 = new List<string>();
                for (int i = 0; i < a.Count(); i++)
                {
                    datas1.Add(a[i]);
                    datas2.Add(a[i]);
                }

                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("-1", "请选择");
                for (int i = 0; i < datas1.Count && i < datas2.Count; ++i)
                {
                    dic.Add(datas1[i], datas2[i]);
                }

                dropTemp.DataSource = dic;
                dropTemp.DataTextField = "Value";
                dropTemp.DataValueField = "Key";
                dropTemp.DataBind();
            }

            //==========================
            dropTemp = (DropDownList)e.Row.FindControl("DropDownList19");
            if (dropTemp != null)
            {

                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("-1", "请选择");
                //for (int i = 0; i < datas1.Count && i < datas2.Count; ++i)
                //{
                //    dic.Add(datas1[i], datas2[i]);
                //}

                DataTable dt = classes.GetClass(" [className]='" + User.Identity.Name + "' ");

                string topClassId = dt.Rows[0]["classId"].ToString().Trim();
                List<string> lst = classes.GetAllEndChild(topClassId);
                foreach (string s in lst)
                {
                    dic.Add(s, classes.GetRoute(s));
                }

                dropTemp.DataSource = dic;
                dropTemp.DataTextField = "Value";
                dropTemp.DataValueField = "Key";
                dropTemp.DataBind();
            }
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                Label name = (Label)e.Row.FindControl("lblName");
                ((LinkButton)e.Row.Cells[7].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + name.Text + "\"吗?')");

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
                HiddenField hidShenFlag = (HiddenField)e.Row.FindControl("hidShenFlag");

                if (!"".Equals(hidShenFlag.Value))
                {
                    if (!Convert.ToBoolean(hidShenFlag.Value))
                    {
                        LinkButton1.Visible = true;
                        LinkButton2.Visible = true;
                    }
                    else if (Convert.ToBoolean(hidShenFlag.Value))
                    {
                        LinkButton1.Visible = false;
                        LinkButton2.Visible = false;
                    }
                }

         
                //if Roles.IsUserInRole("shenhe");
                //Label name = (Label)e.Row.FindControl("lblName");
                //((LinkButton)e.Row.Cells[7].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + name.Text + "\"吗?')");


                //Label name = (Label)e.Row.FindControl("lblName");
                //((LinkButton)e.Row.Cells[7].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + name.Text + "\"吗?')");


            }
        }



    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        string strsql = "";
        if (e.CommandName == "Add")
        {
            string name = "";
            string className = "";

            string date = "";
            string iquantity = "";
            //string workhours = "";
            //string prepworkhours = "";
            string modid = "";

            if (GridView1.Rows.Count > 0)
            {
                //name = (GridView1.FooterRow.FindControl("name") as TextBox).Text;
                //className = (GridView1.FooterRow.FindControl("className") as TextBox).Text;

                name = (GridView1.FooterRow.FindControl("DropDownList1") as DropDownList).SelectedValue;
                className = (GridView1.FooterRow.FindControl("DropDownList19") as DropDownList).SelectedValue;
                iquantity = (GridView1.FooterRow.FindControl("txtiquantity") as TextBox).Text;
                date = (GridView1.FooterRow.FindControl("txtDateF") as TextBox).Text.Trim();
                //prepworkhours = (GridView1.FooterRow.FindControl("txtprepworkhours") as TextBox).Text;
                //string temp=(GridView1.FooterRow.FindControl("lblworkhours") as Label).Text;
                //workhours = string.IsNullOrEmpty(temp)?"":temp;

                //if (!string.IsNullOrEmpty(workhours))
                //{
                //    tworkhours = Math.Round((Convert.ToDecimal(iquantity) * Convert.ToDecimal(workhours)), 2).ToString(); 
                //}

                decimal tworkhours = 0;
                DataSet ds = SQLHelper1.Query("select * from classes where classId="+className);
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    tworkhours = Convert.ToDecimal(dt.Rows[i]["workhours"].ToString()) *
                                               Convert.ToDecimal(iquantity);
                }
                //tworkhours = (GridView1.FooterRow.FindControl("lbltworkhours") as TextBox).Text;
                modid = MoDId.Value;

                strsql =
                   "INSERT INTO [workerhoursEnter]([name],[classId],[iquantity],[modid],[InvCode],date,tworkhours) " +
                   " values ('" + name + "','" + className + "','" + iquantity + "','" + modid + "' ,'" + InvCode.Value + "','"+date+"',"+tworkhours+")";
            }
        }
        if (!string.IsNullOrEmpty(strsql))
        {
            SQLHelper1.ExecuteSql(strsql);
            BindData();
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string name = "";
        string className = "";
        string date = "";
        string iquantity = "";
        string modid = "";

        GridViewRow _row = GridView1.Rows[e.RowIndex];
        name = (_row.FindControl("DropDownList1") as DropDownList).SelectedValue;
        className = (_row.FindControl("DropDownList19") as DropDownList).SelectedValue;
        iquantity = (_row.FindControl("txtiquantity") as TextBox).Text;
        date = (_row.FindControl("txtDate") as TextBox).Text;

        decimal tworkhours = 0;
       DataSet ds = SQLHelper1.Query("select * from classes where classId=" + className);
        DataTable dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            tworkhours = Convert.ToDecimal(dt.Rows[i]["workhours"].ToString()) *
                                       Convert.ToDecimal(iquantity);
        }
        //string ncode = "";
        //string val = "";
        //string iquantity = "";
        ////string workhours = "";
        //string prepworkhours = "";
        //string modid = "";
     
        //name = (_row.FindControl("txtncode") as TextBox).Text;
        //val = (_row.FindControl("DropDownList1") as DropDownList).SelectedValue;
        //iquantity = (_row.FindControl("txtiquantity") as TextBox).Text;
        //prepworkhours = (_row.FindControl("txtprepworkhours") as TextBox).Text;

        Label autoid = (Label)_row.FindControl("lblautoid");

        modid = MoDId.Value;

        string sql =
            "update  [workerhoursEnter] set name='" + name + "', classId='" + className + "', iquantity='" + iquantity +
            "' ,modid='" + modid + "' , date='" + date + "' ,tworkhours=" + tworkhours + " where autoid=" + autoid.Text;

        SQLHelper1.ExecuteSql(sql);
        GridView1.EditIndex = -1;
        BindData();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow _row = GridView1.Rows[e.RowIndex];
        Label autoid = (Label)_row.FindControl("lblautoid");

        string sql = " delete from [workerhoursEnter] where autoid=" + autoid.Text;
        SQLHelper1.ExecuteSql(sql);
        GridView1.EditIndex = -1;
        BindData();

    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DropDownList dropTemp = (DropDownList)e.Row.FindControl("DropDownList1");
                //if (dropTemp != null)
                //{

                //    string sql = "SELECT [process],val from [process] ";
                //    DataSet ds = SQLHelper1.Query(sql);

                //    DataTable dataTable = ds.Tables[0];

                //    DataRow dr3 = dataTable.NewRow();
                //    //dr3["process"] = "请选择";
                //    //dr3["cWhCode"] = "-1";
                //    //dataTable.Rows.InsertAt(dr3, 0);

                //    dropTemp.DataSource = dataTable;
                //    dropTemp.DataTextField = "process";
                //    dropTemp.DataValueField = "val";
                //}

                DropDownList dropTemp = (DropDownList)e.Row.FindControl("DropDownList1");
                if (dropTemp != null)
                {
                    string strRole = "";
                    //if (User.Identity.Name.Equals("离心风机车间"))
                    //{
                    //    strRole = "lixinchejian";
                    //}
                    string[] a = Roles.GetUsersInRole(User.Identity.Name);

                    List<string> datas1 = new List<string>();
                    List<string> datas2 = new List<string>();
                    for (int i = 0; i < a.Count(); i++)
                    {
                        datas1.Add(a[i]);
                        datas2.Add(a[i]);
                    }

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    //dic.Add("-1", "请选择");
                    for (int i = 0; i < datas1.Count && i < datas2.Count; ++i)
                    {
                        dic.Add(datas1[i], datas2[i]);
                    }

                    dropTemp.DataSource = dic;
                    dropTemp.DataTextField = "Value";
                    dropTemp.DataValueField = "Key";
                    //dropTemp.DataBind();
                }

                //==========================
                dropTemp = (DropDownList)e.Row.FindControl("DropDownList19");
                if (dropTemp != null)
                {

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    //dic.Add("-1", "请选择");
                    //for (int i = 0; i < datas1.Count && i < datas2.Count; ++i)
                    //{
                    //    dic.Add(datas1[i], datas2[i]);
                    //}

                    DataTable dt = classes.GetClass(" [className]='" + User.Identity.Name + "' ");

                    string topClassId = dt.Rows[0]["classId"].ToString().Trim();
                    List<string> lst = classes.GetAllEndChild(topClassId);
                    foreach (string s in lst)
                    {
                        dic.Add(s, classes.GetRoute(s));
                    }

                    dropTemp.DataSource = dic;
                    dropTemp.DataTextField = "Value";
                    dropTemp.DataValueField = "Key";
                    //dropTemp.DataBind();
                }
            }
        }
    }
}