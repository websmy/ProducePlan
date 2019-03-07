using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class workhours_manage_gongxuQuery : System.Web.UI.Page
{
    private DataSet _dsBind = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //_dsBind = SQLHelper1.Query("select  * from workhours_manage ");
            BindData3();
            //_dsBind = new DataSet();
            //string sql = "";
            //if (String.IsNullOrEmpty(cInvcode))
            //{
            //    sql = "select  * from workhours_manage";
            //}
            //else
            //{
            //    sql = "select  * from workhours_manage where 产品编码='" + cInvcode + "'";
            //}

            
        }
    }

    public void BindData3()
    {
        _dsBind = new DataSet();
        if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
        {
            _dsBind = SQLHelper1.Query("SELECT * FROM  [workhours_manage] a WHERE a.autoid NOT IN( SELECT DISTINCT 工序autoid FROM 工时录入) and a.flag='"+DropDownList1.SelectedValue+"' ");
        }
        else
        {
            _dsBind = SQLHelper1.Query("SELECT * FROM  [workhours_manage] a WHERE a.autoid NOT IN( SELECT DISTINCT 工序autoid FROM 工时录入) and a.产品编码='" + TextBox1.Text.Trim().Trim() + "' and a.flag='"+DropDownList1.SelectedValue+"' " );
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



    protected void GridView3_PreRender(object sender, EventArgs e)
    {
        if (GridView3.Rows.Count == 0)
        {
            renderEmptyGridView(GridView3, " autoid,产品编码,工序,工时");
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
                newPageIndex = int.Parse(txtNewPageIndex.Text.Trim()) - 1; // get the NewPageIndex
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
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}