using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_Tou_Manage : System.Web.UI.Page
{

    private DataSet _dsBind = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData3();
        }
    }
    public void BindData3()
    {
        _dsBind = new DataSet();
        //if (String.IsNullOrEmpty(TextBox1.Text))
        //{
            _dsBind = SQLHelper1.Query(" select  * from Param");
        //}
        //else
        //{
        //    _dsBind = SQLHelper1.Query("select  * from xialiao where 产品编码='" + TextBox1.Text.Trim() + "'");
        //}


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

        string 年度 = "";
        string 季度 = "";
        string 废铁处理基价 = "";
        string 铝型材处理基价 = "";
        string 不锈钢处理基价 = "";
        //string 截止时间 = "";
        string 是否在投标中 = "";

        GridViewRow _row = GridView3.Rows[e.RowIndex];

        年度 = (_row.FindControl("DropDownList1") as DropDownList).SelectedValue;
        季度 = (_row.FindControl("DropDownList2") as DropDownList).SelectedValue;
        废铁处理基价 = (_row.FindControl("txt废铁处理基价") as TextBox).Text;
        铝型材处理基价 = (_row.FindControl("txt铝型材处理基价") as TextBox).Text;
        不锈钢处理基价 = (_row.FindControl("txt不锈钢处理基价") as TextBox).Text;
        //截止时间 = (_row.FindControl("txt截止时间") as TextBox).Text;

        是否在投标中 = (_row.FindControl("DropDownList3") as DropDownList).SelectedValue;

        HiddenField autoid = (HiddenField)_row.FindControl("autoid");

        string sql = "";
        if ("1".Equals(是否在投标中))
        {
            sql = "update param set 是否在投标中='" + 0 + "'  ";
        }
      
        sql =sql+
            "update  [param] set 年度='" + 年度 + "', 季度='" + 季度 + "' " +
            ",废铁处理基价='" + 废铁处理基价 + "'" +
            ",铝型材处理基价='" + 铝型材处理基价 + "'" +
            ",不锈钢处理基价='" + 不锈钢处理基价 + "'" +
            //",截止时间='" + 截止时间 + "'" +
            ",是否在投标中='" + 是否在投标中 + "'" +

            " where autoid=" + autoid.Value;

        SQLHelper1.Query(sql);
        GridView3.EditIndex = -1;
        BindData3();
        //BindData();

    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow _row = GridView3.Rows[e.RowIndex];
        HiddenField autoid = (HiddenField)_row.FindControl("autoid");

        string sql = " delete from [Param] where autoid=" + autoid.Value ;
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
                string 年度 = "";
                string 季度 = "";
                string 废铁处理基价 = "";
                string 铝型材处理基价 = "";
                string 不锈钢处理基价 = "";
                //string 截止时间 = "";

                年度 = (GridView3.FooterRow.FindControl("DropDownList1") as DropDownList).SelectedValue;
                季度 = (GridView3.FooterRow.FindControl("DropDownList2") as DropDownList).SelectedValue;
                废铁处理基价 = (GridView3.FooterRow.FindControl("txt废铁处理基价F") as TextBox).Text;
                铝型材处理基价 = (GridView3.FooterRow.FindControl("txt铝型材处理基价F") as TextBox).Text;
                不锈钢处理基价 = (GridView3.FooterRow.FindControl("txt不锈钢处理基价F") as TextBox).Text;
                //截止时间 = (GridView3.FooterRow.FindControl("txt截止时间F") as TextBox).Text;

                strsql = " INSERT INTO [Param]" +
                         " ([年度]          " +
                         " ,[季度]          " +
                         " ,[废铁处理基价]          " +
                         " ,[铝型材处理基价]          " +
                         " ,[不锈钢处理基价]          " +
                         //" ,[截止时间]                 " +
                         " ,[是否在投标中]  )         " +
                         "     VALUES          " +
                         "      ('" + 年度 + "'     " +
                         " ,'" + 季度 + "'          " +
                         " ,'" + 废铁处理基价 + "'          " +
                         " ,'" + 铝型材处理基价 + "'                 " +
                         " ,'" + 不锈钢处理基价 + "'                 " +
                         //" ,'" + 截止时间 + "'                 " +
                         " ,'" + 0 + "' )";
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
            renderEmptyGridView(GridView3, " autoid,年度,季度,废铁处理基价,铝型材处理基价,不锈钢处理基价,截止时间,是否在投标中");
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
        if (e.Row.RowIndex > -1)
        {

            HiddenField modid = e.Row.FindControl("autoid") as HiddenField;

            //HyperLink la = e.Row.FindControl("HyperLink1") as HyperLink;

            //la.Attributes.Add("onclick",
            //                  "openwin('Tou_Detail.aspx','Tou_Detail','" + modid.Value + "','650','600','" +
            //                  modid.Value + "','" + e.Row.Cells[1].Text + "','" +
            //                  e.Row.Cells[1].Text + "','" +
            //                  e.Row.Cells[1].Text + "','" + modid.Value + "','" + modid.Value + "' )");
            //la.NavigateUrl = "javascript:void(0)";
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList dropTemp = (DropDownList)e.Row.FindControl("DropDownList1");
         
            if (dropTemp != null)
            {

                string sql = "SELECT year from [Year] ";
                DataSet ds = SQLHelper1.Query(sql);

                DataTable dataTable = ds.Tables[0]; ;
                //DataRow dr3 = dataTable.NewRow();
                //dr3["process"] = "请选择";
                //dr3["val"] = "-1";
                //dataTable.Rows.InsertAt(dr3, 0);

                dropTemp.DataSource = dataTable;
                dropTemp.DataTextField = "year";
                dropTemp.DataValueField = "year";
                dropTemp.DataBind();

            }

            DropDownList dropTemp1 = (DropDownList)e.Row.FindControl("DropDownList2");

            if (dropTemp1 != null)
            {

                string sql = "SELECT 季度  from [Year_Season] ";
                DataSet ds = SQLHelper1.Query(sql);

                DataTable dataTable = ds.Tables[0]; ;
                //DataRow dr3 = dataTable.NewRow();
                //dr3["process"] = "请选择";
                //dr3["val"] = "-1";
                //dataTable.Rows.InsertAt(dr3, 0);

                dropTemp1.DataSource = dataTable;
                dropTemp1.DataTextField = "季度";
                dropTemp1.DataValueField = "季度";
                dropTemp1.DataBind();

            }
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                LinkButton modid = e.Row.FindControl("LinkButton2") as LinkButton;

        
                modid.Attributes.Add("onclick", "javascript:return confirm('你确认要删除吗!')");
            }
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
    protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dropTemp = (DropDownList)e.Row.FindControl("DropDownList1");
                if (dropTemp != null)
                {

                    string sql = "SELECT year  from [Year] ";
                    DataSet ds = SQLHelper1.Query(sql);

                    DataTable dataTable = ds.Tables[0];

                    DataRow dr3 = dataTable.NewRow();
                    //dr3["process"] = "请选择";
                    //dr3["cWhCode"] = "-1";
                    //dataTable.Rows.InsertAt(dr3, 0);

                    dropTemp.DataSource = dataTable;
                    dropTemp.DataTextField = "year";
                    dropTemp.DataValueField = "year";
                }

                DropDownList dropTemp1 = (DropDownList)e.Row.FindControl("DropDownList2");
                if (dropTemp1 != null)
                {

                    string sql = "SELECT 季度  from [Year_Season] ";
                    DataSet ds = SQLHelper1.Query(sql);

                    DataTable dataTable = ds.Tables[0];

                    DataRow dr3 = dataTable.NewRow();
                    //dr3["process"] = "请选择";
                    //dr3["cWhCode"] = "-1";
                    //dataTable.Rows.InsertAt(dr3, 0);

                    dropTemp1.DataSource = dataTable;
                    dropTemp1.DataTextField = "季度";
                    dropTemp1.DataValueField = "季度";
                }

                DropDownList dropTemp3 = (DropDownList)e.Row.FindControl("DropDownList3");
                if (dropTemp3 != null)
                {

                    //string sql = "SELECT 季度  from [Year_Season] ";
                    //DataSet ds = SQLHelper1.Query(sql);

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("参数");
                    dataTable.Columns.Add("值");

                    DataRow dr3 = dataTable.NewRow();
                    dr3["参数"] = "是";
                    dr3["值"] = "1";

                    dataTable.Rows.Add(dr3);

                    dr3 = dataTable.NewRow();
                    dr3["参数"] = "否";
                    dr3["值"] = "0";
                    dataTable.Rows.Add(dr3);

                    //dataTable.Rows.InsertAt(dr3, 0);

                    dropTemp3.DataSource = dataTable;
                    dropTemp3.DataTextField = "参数";
                    dropTemp3.DataValueField = "值";
                }

            }
        }
    }
}