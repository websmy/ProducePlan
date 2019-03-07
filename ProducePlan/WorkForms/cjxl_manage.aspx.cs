using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_cjxl_manage : System.Web.UI.Page
{
    private DataSet _dsBind = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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

    public void BindData3()
    {
        _dsBind = new DataSet();
        if (String.IsNullOrEmpty(TextBox1.Text))
        {
            _dsBind = SQLHelper1.Query("select  * from xialiao");
        }
        else
        {
            _dsBind = SQLHelper1.Query("select  * from xialiao where 产品编码='" + TextBox1.Text.Trim() + "'");
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
        //string xialiao = "";
        string 产品编码 = "";
        string 零件名称 = "";
        string 每台数量 = "";
        string 板材编码 = "";
        string 下料尺寸 = "";
        string 板厚 = "";
        string 材质 = "";
        string 设备 = "";
        string 加工说明 = "";
        GridViewRow _row = GridView3.Rows[e.RowIndex];

        产品编码 = (_row.FindControl("txt产品编码") as TextBox).Text;
        零件名称 = (_row.FindControl("txt零件名称") as TextBox).Text;
        每台数量 = (_row.FindControl("txt每台数量") as TextBox).Text;
        板材编码 = (_row.FindControl("txt板材编码") as TextBox).Text;
        下料尺寸 = (_row.FindControl("txt下料尺寸") as TextBox).Text;
        板厚 = (_row.FindControl("txt板厚") as TextBox).Text;
        材质 = (_row.FindControl("txt材质") as TextBox).Text;
        设备 = (_row.FindControl("txt设备") as TextBox).Text;
        加工说明 = (_row.FindControl("txt加工说明") as TextBox).Text;


        Label autoid = (Label)_row.FindControl("autoid");

        string sql =
            "update  [xialiao] set 产品编码='" + 产品编码 + "', 零件名称='" + 零件名称 + "' " +
            ",每台数量='" + 每台数量 + "'" +
            ",板材编码='" + 板材编码 + "'" +
            ",下料尺寸='" + 下料尺寸 + "'" +
            ",板厚='" + 板厚 + "'" +
            ",材质='" + 材质 + "'" +
            ",设备='" + 设备 + "'" +
            ",加工说明='" + 加工说明 + "'" +

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

        string sql = " delete from [xialiao] where autoid=" + autoid.Text;
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


                string 产品编码 = "";
                string 零件名称 = "";
                string 每台数量 = "";
                string 板材编码 = "";
                string 下料尺寸 = "";
                string 板厚 = "";
                string 材质 = "";
                string 设备 = "";
                string 加工说明 = "";


                //int maxid = SQLHelper1.GetMaxID("val", "xialiao");
                产品编码 = (GridView3.FooterRow.FindControl("txt产品编码F") as TextBox).Text;
                零件名称 = (GridView3.FooterRow.FindControl("txt零件名称F") as TextBox).Text;
                每台数量 = (GridView3.FooterRow.FindControl("txt每台数量F") as TextBox).Text;
                板材编码 = (GridView3.FooterRow.FindControl("txt板材编码F") as TextBox).Text;
                下料尺寸 = (GridView3.FooterRow.FindControl("txt下料尺寸F") as TextBox).Text;
                板厚 = (GridView3.FooterRow.FindControl("txt板厚F") as TextBox).Text;
                材质 = (GridView3.FooterRow.FindControl("txt材质F") as TextBox).Text;
                设备 = (GridView3.FooterRow.FindControl("txt设备F") as TextBox).Text;
                加工说明 = (GridView3.FooterRow.FindControl("txt加工说明F") as TextBox).Text;

                strsql = " INSERT INTO [xialiao]" +
                         " ([产品编码]          " +
                         " ,[零件名称]          " +
                         " ,[每台数量]          " +
                         " ,[板材编码]          " +
                         " ,[下料尺寸]          " +
                         " ,[板厚]                 " +
                         " ,[材质]                 " +
                         " ,[设备]                 " +
                         " ,[加工说明])         " +
                         "     VALUES          " +
                         "      ('" + 产品编码 + "'     " +
                         " ,'" + 零件名称 + "'          " +
                         " ,'" + 每台数量 + "'          " +
                         " ,'" + 板材编码 + "'          " +
                         " ,'" + 下料尺寸 + "'          " +
                         " ,'" + 板厚 + "'                 " +
                         " ,'" + 材质 + "'                 " +
                         " ,'" + 设备 + "'                 " +
                         " ,'" + 加工说明 + "' )";
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
            renderEmptyGridView(GridView3, " autoid,产品编码,零件名称,每台数量,板材编码,下料尺寸,板厚,材质,设备,加工说明");
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                Label label产品编码 = (Label)e.Row.FindControl("label产品编码");
                ((LinkButton)e.Row.Cells[10].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"" + label产品编码.Text + "\"吗?')");
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
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        
       
        BindData3();
    }
}