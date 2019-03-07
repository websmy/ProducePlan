using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkForms_catalog_body : System.Web.UI.Page
{
    Classes classes = new Classes();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //form1.Visible = false;
                Bind();
            }
            catch
            {

            }
        }
    }

    private void Bind()
    {
        if (Request.QueryString["type"] != null)//说明是增加操作
        {
            if (Request.QueryString["type"] == "add")
                lblTitle.Text = "增加同级项";
            else
                lblTitle.Text = "增加子级项";
        }
        else
        {
            if (Request.QueryString["classId"] != null)
            {
                DataTable dt = classes.GetByClassId(Convert.ToInt32(Request.QueryString["classId"].ToString()));
                lblTitle.Text = "编辑";
                txtName.Text = dt.Rows[0]["className"].ToString().Trim();
                txtdescr.Text = dt.Rows[0]["classDescrip"].ToString().Trim();
                txtNeedHours.Text = dt.Rows[0]["workhours"].ToString().Trim();
                btAdd.Text = "修改";

                //if ("0".Equals(dt.Rows[0]["childNum"].ToString()))
                //{
                //    form1.Visible = true;
                //}
                //else
                //{
                //    form1.Visible = false;
                //}
            }
        }
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Add();
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('" + ex.ToString() + "');", true);
        }
    }
    private void Add()
    {
        if (Request.QueryString["type"] != null && Request.QueryString["classId"] != null)
        {
            if (Request.QueryString["type"] == "add")//增加同级
            {
                DataTable dt = classes.GetParent(Convert.ToInt32(Request.QueryString["classId"].ToString()));
                if (dt.Rows.Count > 0)//如果不是顶级
                {
                    classes.AddClass(txtName.Text.Trim(), txtdescr.Text
                        , Convert.ToInt32(dt.Rows[0]["classId"].ToString())//父级
                        , Convert.ToInt32(dt.Rows[0]["childNum"].ToString())//最大排序号
                        , Convert.ToInt32(dt.Rows[0]["depth"].ToString()) + 1,
                        Convert.ToDecimal(txtNeedHours.Text.Trim()));
                }
                else//增加顶级
                {
                    string maxId = classes.GetMaxSortId(0);
                    if (maxId == "-1")
                        maxId = "0";
                    classes.AddClass(txtName.Text.Trim(), txtdescr.Text, 0, Convert.ToInt32(maxId) + 1, 0, Convert.ToDecimal(txtNeedHours.Text.Trim()));
                }
            }
            else//增加子级
            {
                if (Request.QueryString["classId"].ToString() != "-1")
                {
                    DataTable dt = classes.GetByClassId(Convert.ToInt32(Request.QueryString["classId"].ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        classes.AddClass(txtName.Text.Trim(), txtdescr.Text
                            , Convert.ToInt32(dt.Rows[0]["classId"].ToString())//父级
                            , Convert.ToInt32(dt.Rows[0]["childNum"].ToString())//最大排序号,是父级孩子数量
                            , Convert.ToInt32(dt.Rows[0]["depth"].ToString()) + 1,
                            Convert.ToDecimal(txtNeedHours.Text.Trim()));
                        classes.UpdateChildNum(Convert.ToInt32(Request.QueryString["classId"].ToString()), true);
                    }
                }
                else//增加第一个结点，或者增加最顶级结点。
                {
                    //找到顶级最大排序号，加一。
                    classes.AddClass(txtName.Text.Trim(), txtdescr.Text, 0, Convert.ToInt32(classes.GetMaxSortId(0)) + 1, 0, Convert.ToDecimal(txtNeedHours.Text.Trim()));
                }
            }
        }
        else
        {
            if (Request.QueryString["classId"] != null)//修改
            {
                classes.UpdateClass(txtName.Text.Trim(), txtdescr.Text, Convert.ToInt32(Request.QueryString["classId"].ToString()),Convert.ToDecimal(txtNeedHours.Text.Trim()));
            }
        }
        //刷新类别树
        ltlJs.Text = "window.parent.location.reload();";//.leftFrame
    }
}