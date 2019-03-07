using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_cnfx_manage : System.Web.UI.Page
{
    private DataSet _dsBind = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindFilter();
            //_dsBind = SQLHelper1.Query("select  * from xialiao ");
            BindData3();
            //_dsBind = new DataSet();
            //string sql = "";
            //if (String.IsNullOrEmpty(cInvcode))
            //{
            //    sql = "select  * from xialiao";
            //}
            //else
            //{
            //    sql = "select  * from xialiao where 产品编码='" + cInvcode + "'";
            //}

            
        }
    }

    private void BindFilter()
    {
        string str = "";
        bool found = false;
        Dictionary<string, string> dic = XMLHelper.ReadConfig("~/config/quanxian.config", "web/user");
        if (dic == null)
            return;
        foreach (KeyValuePair<string, string> kv in dic)
        {
            if (kv.Key.Equals(User.Identity.Name))
            {
                found = true;
                str = kv.Value;
                break;
            }
        }

        if (!found)
        {
            return;
        }

        //部门和班组取的方式不对
        string sql =
          "select Department.[cDepName] ,mom_orderdetail.modid,mom_orderdetail.MDeptCode,inventory.cinvdefine4,mom_orderdetail.SoCode,mom_order.mocode,mom_orderdetail.InvCode,inventory.cinvname,mom_orderdetail.Qty,mom_orderdetail.QualifiedInQty,mom_morder.startdate,mom_morder.Duedate " +
          "from mom_orderdetail " +
          "left join mom_order on mom_orderdetail.moid=mom_order.moid " +
          "left join mom_morder on mom_orderdetail.modid=mom_morder.modid " +
          "left join inventory on mom_orderdetail.InvCode=inventory.cInvCode " +
          "left join [Department] on mom_orderdetail.MDeptCode=[Department].[cDepCode] " +
          "where mom_orderdetail.status<> 4 and mom_orderdetail.Qty <> mom_orderdetail.QualifiedInQty and mom_orderdetail.Status = 3 and Department.[cDepName] in (" + str + ")";

        //string sql = "select * from aViewName where 1=1 ";
        DataSet ds = SQLHelper.Query(sql);


        DataTable dataTable = ds.Tables[0]; ;
        DataView dataView = dataTable.DefaultView;

        DataTable dataTableDistinct3 = dataView.ToTable(true, "cDepName");//注

        ViewState["dataTableDistinct3"] = dataTableDistinct3.Copy();

        DataRow dr3 = dataTableDistinct3.NewRow();
        dr3["cDepName"] = "全部";
        dataTableDistinct3.Rows.InsertAt(dr3, 0);
        DropDownList3.DataSource = dataTableDistinct3;
        DropDownList3.DataValueField = "cDepName";
        DropDownList3.DataBind();

        DataTable dataTableDistinct4 = dataView.ToTable(true, "cinvdefine4");//注      
        DataTable dtTemp = dataTableDistinct4.Copy();
        DataTable dtTemp1 = dtTemp.Copy();
        dtTemp1.Rows.Clear();
        
        for (int i = 0; i < dtTemp.Rows.Count; i++)
        {
            int cnt = 0;
            if (String.IsNullOrEmpty(dtTemp.Rows[i]["cinvdefine4"].ToString()))
            {
                cnt++;
            }

            if (cnt >= 2)
            {
                //dtTemp.Rows[i].Delete();
            }
            else
            {
                dtTemp1.ImportRow(dtTemp.Rows[i]);
            }
        }

        ViewState["dataTableDistinct4"] = dtTemp1;

        DataTable dtTemp2 = dtTemp1.Copy();
        DataRow dr4 = dtTemp2.NewRow();
        dr4["cinvdefine4"] = "全部";
        dtTemp2.Rows.InsertAt(dr4, 0);
        DropDownList4.DataSource = dtTemp2;
        DropDownList4.DataValueField = "cinvdefine4";
        DropDownList4.DataBind();
    }

    public void BindData3()
    {
        _dsBind = new DataSet();
        if (!"全部".Equals(DropDownList3.SelectedValue) && !"全部".Equals(DropDownList4.SelectedValue))
        {
            _dsBind = SQLHelper1.Query("select  * from 工时 where 部门='" + DropDownList3.SelectedValue + "' and 班组='" + DropDownList4.SelectedValue + "' ");
        }
        else if (!"全部".Equals(DropDownList3.SelectedValue) && "全部".Equals(DropDownList4.SelectedValue))
        {
            _dsBind = SQLHelper1.Query("select  * from 工时 where 部门='" + DropDownList3.SelectedValue + "'  ");
        }
        else if ("全部".Equals(DropDownList3.SelectedValue) && !"全部".Equals(DropDownList4.SelectedValue))
        {
            _dsBind = SQLHelper1.Query("select  * from 工时 where  班组='" + DropDownList4.SelectedValue + "' ");
        }
        else
        {
            _dsBind = SQLHelper1.Query("select  * from 工时");        
        }

        GridView3.DataSource = _dsBind;
        GridView3.DataBind();
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

    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string 部门 = "";
        string 班组 = "";
        string 人数 = "";
        string 工时 = "";
        string 日期 = "";
        GridViewRow _row = GridView3.Rows[e.RowIndex];

        部门 = (_row.FindControl("DDL部门") as DropDownList).SelectedValue;
        班组 = (_row.FindControl("DDL班组") as DropDownList).SelectedValue;
        人数 = (_row.FindControl("txt人数") as TextBox).Text;
        工时 = (_row.FindControl("txt工时") as TextBox).Text;
        日期 = (_row.FindControl("txt日期") as TextBox).Text;

        Label autoid = (Label)_row.FindControl("autoid");

        string sql =
            "update  [工时] set 部门='" + 部门 + "', 班组='" + 班组 + "' " +
            ",人数='" + 人数 + "'" +
            ",工时='" + 工时 + "'" +
            ",日期='" + 日期 + "'" +
            

            " where autoid=" + autoid.Text;

        SQLHelper1.ExecuteSql(sql);
        GridView3.EditIndex = -1;
        BindData3();
        //BindData();

    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow _row = GridView3.Rows[e.RowIndex];
        Label autoid = (Label)_row.FindControl("autoid");

        string sql = " delete from [工时] where autoid=" + autoid.Text;
        SQLHelper1.ExecuteSql(sql);
        GridView3.EditIndex = -1;
        BindData3();
        //BindData();

    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strsql = "";
        if (e.CommandName == "Add")
        {
            string xialiao = "";
            if (GridView3.Rows.Count > 0)
            {
                string 部门 = "";
                string 班组 = "";
                string 人数 = "";
                string 工时 = "";
                string 日期 = "";

                //int maxid = SQLHelper1.GetMaxID("val", "xialiao");
                部门 = (GridView3.FooterRow.FindControl("DDL部门F") as DropDownList).SelectedValue;
                班组 = (GridView3.FooterRow.FindControl("DDL班组F") as DropDownList).SelectedValue;
                人数 = (GridView3.FooterRow.FindControl("txt人数F") as TextBox).Text;
                工时 = (GridView3.FooterRow.FindControl("txt工时F") as TextBox).Text;
                日期 = (GridView3.FooterRow.FindControl("txt日期F") as TextBox).Text;

                strsql = " INSERT INTO [工时]" +
                         " ([部门]          " +
                         " ,[班组]          " +
                         " ,[人数]          " +
                         " ,[工时]          " +
                         " ,[日期] )         " +
                        
                         "     VALUES          " +
                         "      ('" + 部门 + "'     " +
                         " ,'" + 班组 + "'          " +
                         " ,'" + 人数 + "'          " +
                         " ,'" + 工时 + "'          " +
                         " ,'" + 日期 + "' )";
            }
            else
            {
            }

        }

        if (!string.IsNullOrEmpty(strsql))
        {
            SQLHelper1.ExecuteSql(strsql);
            BindData3();
            //BindData();

        }
    }


    protected void GridView3_PreRender(object sender, EventArgs e)
    {
        if (GridView3.Rows.Count == 0)
        {
            renderEmptyGridView(GridView3, " autoid,部门,班组,人数,工时,日期");
        }
    }
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.EditIndex = -1;
        BindData3();
        //BindData();
    }
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        BindData3();
        //BindData();
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList DDL部门F = e.Row.FindControl("DDL部门F") as DropDownList;
            DDL部门F.DataSource = ViewState["dataTableDistinct3"];
            DDL部门F.DataValueField = "cDepName";
            DDL部门F.DataBind();

            DropDownList DDL班组F = e.Row.FindControl("DDL班组F") as DropDownList;
            DDL班组F.DataSource = ViewState["dataTableDistinct4"];
            DDL班组F.DataValueField = "cinvdefine4";
            DDL班组F.DataBind();

        }
       
        if (e.Row.RowType == DataControlRowType.DataRow )           
        {
            if (e.Row.RowState == DataControlRowState.Edit || ((int)(e.Row.RowState & DataControlRowState.Edit)) != 0)
            {
                DropDownList DDL部门 = e.Row.FindControl("DDL部门") as DropDownList;
                DDL部门.DataSource = ViewState["dataTableDistinct3"];
                DDL部门.DataValueField = "cDepName";
                DDL部门.DataBind();

                DDL部门.SelectedValue = (e.Row.FindControl("部门h") as HiddenField).Value;

                DropDownList DDL班组 = e.Row.FindControl("DDL班组") as DropDownList;
                DDL班组.DataSource = ViewState["dataTableDistinct4"];
                DDL班组.DataValueField = "cinvdefine4";
                DDL班组.DataBind();

                DDL班组.SelectedValue = (e.Row.FindControl("班组h") as HiddenField).Value;

            }

        
            //if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            //{
            //    Label label产品编码 = (Label)e.Row.FindControl("label产品编码");
            //    ((LinkButton)e.Row.Cells[10].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + label产品编码.Text + "\"吗?')");
            //}
        }
 
    }


    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;
        int newPageIndex = 0;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;
            if (null != pagerRow)
            {
                txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
            }
            if (null != txtNewPageIndex)
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        { newPageIndex = e.NewPageIndex; }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        BindData3();
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        
       
        BindData3();
    }
}