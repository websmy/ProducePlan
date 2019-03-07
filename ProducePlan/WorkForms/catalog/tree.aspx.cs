using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkForms_catalog_tree : System.Web.UI.Page
{
    private string bodyUrl = "";//页面转向,页面变量能在页面内保留，类似ViewState
    private DataTable tblClassInfo = new DataTable();//储存读入的数据 
    private Classes classes = new Classes();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Bind();
    }
    private void Bind()
    {
        string rootStr = "工序管理";
        TreeNode rootNode = new TreeNode(rootStr);
        rootNode.Value = "-1";
        rootNode.Target = "bodyFrame";
        rootNode.NavigateUrl = "body.aspx";
        PopulateTreeView(0, rootNode);
        this.tvType.Nodes.Add(rootNode);
    }
    /// <summary>
    /// 取得页面跳转地址
    /// </summary>
    /// <returns></returns>
    public string GetBodyUrl()
    {
        return bodyUrl;
    }
    /// <summary>
    /// 增加同级
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnAddNode_Click(object sender, ImageClickEventArgs e)
    {
        if (tvType.SelectedNode != null)
        {
            if (tvType.SelectedValue != "-1")//根结点不算
                bodyUrl = "body.aspx?type=add&classId=" + tvType.SelectedValue;
        }
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('请选择类别！');;", true);
    }
    /// <summary>
    /// 增加子级
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnAddChildNode_Click(object sender, ImageClickEventArgs e)
    {
        if (tvType.SelectedNode != null)
        {
            bodyUrl = "body.aspx?type=addChild&classId=" + tvType.SelectedValue;
        }
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('请选择类别！');;", true);
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnDeleteNode_Click(object sender, ImageClickEventArgs e)
    {
        if (tvType.SelectedNode != null)
        {
            if (tvType.SelectedNode == tvType.Nodes[0])
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('根结点不能删除');", true);
                return;
            }
            if (!classes.HasChild(Convert.ToInt32(tvType.SelectedValue)))
            {
                //先把同级重新排序
                DataTable dt = classes.GetByClassId(Convert.ToInt32(tvType.SelectedValue));
                classes.UpdateSort(Convert.ToInt32(dt.Rows[0]["sortId"].ToString()), Convert.ToInt32(dt.Rows[0]["parentId"].ToString()));
                classes.UpdateChildNum(Convert.ToInt32(dt.Rows[0]["parentId"].ToString()), false);
                //再删除
                classes.DeleteClass(Convert.ToInt32(tvType.SelectedValue));
                Response.Redirect("tree.aspx");
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('请先删除子级！');;", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('请选择类别！');;", true);
    }
    /// <summary>
    /// 上移
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnUp_Click(object sender, ImageClickEventArgs e)
    {
        if (tvType.SelectedNode != null)
        {
            if (tvType.SelectedNode == tvType.Nodes[0])
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('根结点不能移动');", true);
                return;
            }
            DataTable dt = classes.GetByClassId(Convert.ToInt32(tvType.SelectedValue));
            DataTable dtUp = classes.GetUpDown(Convert.ToInt32(tvType.SelectedValue), true);
            if (dt.Rows[0]["sortId"].ToString() != "0")
            {
                classes.ChangeSort(Convert.ToInt32(dt.Rows[0]["classId"].ToString()), true);
                classes.ChangeSort(Convert.ToInt32(dtUp.Rows[0]["classId"].ToString()), false);
                Response.Redirect("tree.aspx");
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('已经排在上面！');", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('请选择类别！');;", true);
    }
    /// <summary>
    /// 下移
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnDown_Click(object sender, ImageClickEventArgs e)
    {
        if (tvType.SelectedNode != null)
        {
            if (tvType.SelectedNode == tvType.Nodes[0])
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('根结点不能移动');", true);
                return;
            }
            DataTable dt = classes.GetByClassId(Convert.ToInt32(tvType.SelectedValue));
            DataTable dtDown = classes.GetUpDown(Convert.ToInt32(tvType.SelectedValue), false);
            if (dtDown.Rows.Count > 0)
            {
                classes.ChangeSort(Convert.ToInt32(dt.Rows[0]["classId"].ToString()), false);
                classes.ChangeSort(Convert.ToInt32(dtDown.Rows[0]["classId"].ToString()), true);
                Response.Redirect("tree.aspx");
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('已经排在下面！');", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "alert('请选择类别！');;", true);
    }
    /// <summary>
    /// 最简单的无限级绑定，这里的效率需要改进
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="parentNode"></param>
    private void PopulateTreeView(int parentId, TreeNode parentNode)
    {
        DataView dv = classes.GetClass("parentId=" + parentId.ToString()).DefaultView;
        foreach (DataRowView drv in dv)
        {
            TreeNode myNode = new TreeNode(drv["className"].ToString());
            //myNode.Expanded = false;
            myNode.Value = drv["classId"].ToString();
            myNode.Target = "bodyFrame";
            myNode.NavigateUrl = "body.aspx?classId=" + drv["classId"].ToString();
            parentNode.ChildNodes.Add(myNode);
            PopulateTreeView(Convert.ToInt32(drv["classId"].ToString()), myNode);
        }
    }
}