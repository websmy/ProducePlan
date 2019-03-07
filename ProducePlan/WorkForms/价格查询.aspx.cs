using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_价格查询 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ClearAll();
            ClearAll1();
            ClearAll2();

            BindValue();
        }
    }

    private void BindValue()
    {
        string sql = "SELECT 风机型号  from  [风机报价基本表] ";
        DataSet ds = SQLHelper1.Query(sql);

        DataTable dataTable = ds.Tables[0];

        DataRow dr3 = dataTable.NewRow();
        dr3["风机型号"] = "请选择";
        //dr3["cWhCode"] = "-1";
        dataTable.Rows.InsertAt(dr3, 0);

        DropDownList11.DataSource = dataTable;
        DropDownList11.DataTextField = "风机型号";
        DropDownList11.DataValueField = "风机型号";
        DropDownList11.DataBind();


        sql = "SELECT 风机型号  from  [风机报价基本表CLQ] ";
        ds = SQLHelper1.Query(sql);
        dataTable = ds.Tables[0];
        dr3 = dataTable.NewRow();
        dr3["风机型号"] = "请选择";
        //dr3["cWhCode"] = "-1";
        dataTable.Rows.InsertAt(dr3, 0);
        DropDownList26.DataSource = dataTable;
        DropDownList26.DataTextField = "风机型号";
        DropDownList26.DataValueField = "风机型号";
        DropDownList26.DataBind();


        sql = "SELECT distinct 风机型号  from  [风机报价基本表CZ]  ";
        ds = SQLHelper1.Query(sql);
        dataTable = ds.Tables[0];
        dr3 = dataTable.NewRow();
        dr3["风机型号"] = "请选择";
        //dr3["cWhCode"] = "-1";
        dataTable.Rows.InsertAt(dr3, 0);
        DropDownList46.DataSource = dataTable;
        DropDownList46.DataTextField = "风机型号";
        DropDownList46.DataValueField = "风机型号";
        DropDownList46.DataBind();

        sql = "SELECT distinct 风筒板厚  from  [风机报价基本表CZ]  ";
        ds = SQLHelper1.Query(sql);
        dataTable = ds.Tables[0];
        dr3 = dataTable.NewRow();
        dr3["风筒板厚"] = "请选择";
        //dr3["cWhCode"] = "-1";
        dataTable.Rows.InsertAt(dr3, 0);
        DropDownList307.DataSource = dataTable;
        DropDownList307.DataTextField = "风筒板厚";
        DropDownList307.DataValueField = "风筒板厚";
        DropDownList307.DataBind();





        sql = "SELECT *  from [Param]  where [是否在投标中]=1";
        ds = SQLHelper1.Query(sql);

        dataTable = ds.Tables[0];
        string a1 = dataTable.Rows[0]["废铁处理基价"].ToString().Trim();
        string a2 = dataTable.Rows[0]["铝型材处理基价"].ToString().Trim();
        string a3 = dataTable.Rows[0]["不锈钢处理基价"].ToString().Trim();
        SetValue(DropDownList12, a1, a2, a3);
        SetValue(DropDownList13, a1, a2, a3);
        SetValue(DropDownList14, a1, a2, a3);
        SetValue(DropDownList15, a1, a2, a3);
        SetValue(DropDownList16, a1, a2, a3);
        SetValue(DropDownList17, a1, a2, a3);

        SetValue(DropDownList37, a1, a2, a3);
        SetValue(DropDownList38, a1, a2, a3);
        SetValue(DropDownList39, a1, a2, a3);
        SetValue(DropDownList41, a1, a2, a3);
        SetValue(DropDownList43, a1, a2, a3);
        SetValue(DropDownList45, a1, a2, a3);


        //SetValue(DropDownList57, a1, a2, a3);
        //SetValue(DropDownList58, a1, a2, a3);
        //SetValue(DropDownList59, a1, a2, a3);
        //SetValue(DropDownList61, a1, a2, a3);
        //SetValue(DropDownList63, a1, a2, a3);
        //SetValue(DropDownList65, a1, a2, a3);




    }

    private void SetValue(DropDownList ddl, string a1, string a2, string a3)
    {
        ddl.Items.Add(new ListItem("请选择", "请选择"));
        ddl.Items.Add(new ListItem("铝板", a1));
        ddl.Items.Add(new ListItem("碳钢", a2));
        ddl.Items.Add(new ListItem("不锈钢", a3));
        ddl.DataBind();
    }

    private void ClearAll()
    {
        foreach (Control ctrl in TabPanel1_1.Controls)
        {
            foreach (Control childc in ctrl.Controls)
            {
                switch (childc.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        TextBox txt = (TextBox)childc;
                        break;
                    case "System.Web.UI.WebControls.Label":
                        Label lbl = (Label)childc;
                        lbl.Text = "";
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        DropDownList ddl = (DropDownList)childc;
                        break;
                }
            }
        }
    }
    private void ClearAll1()
    {
        foreach (Control ctrl in TabPanel1_2.Controls)
        {
            foreach (Control childc in ctrl.Controls)
            {
                switch (childc.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        TextBox txt = (TextBox)childc;
                        break;
                    case "System.Web.UI.WebControls.Label":
                        Label lbl = (Label)childc;
                        lbl.Text = "";
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        DropDownList ddl = (DropDownList)childc;
                        break;
                }
            }
        }
    }

    private void ClearAll2()
    {
        foreach (Control ctrl in TabPanel4.Controls)
        {
            foreach (Control childc in ctrl.Controls)
            {
                switch (childc.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        TextBox txt = (TextBox)childc;
                        break;
                    case "System.Web.UI.WebControls.Label":
                        Label lbl = (Label)childc;
                        lbl.Text = "";
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        DropDownList ddl = (DropDownList)childc;
                        break;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        double dResult = 0;
        string calLog = "";
        电机价格.Text = "";
        电机价格1.Text = "";
        string 电机型号 = DropDownList1.SelectedItem.Text.Trim();
        string 级数 = DropDownList2.SelectedItem.Text.Trim();
        string 功率 = DropDownList3.SelectedItem.Text.Trim();
        string 防爆等级 = DropDownList4.SelectedItem.Text.Trim();
        string 绝缘等级 = DropDownList5.SelectedItem.Text.Trim();
        string 安装方式 = DropDownList6.SelectedItem.Text.Trim();
        string 轴头攻丝 = DropDownList7.SelectedItem.Text.Trim();
        string 加热带 = DropDownList8.SelectedItem.Text.Trim();
        string 轴承 = DropDownList9.SelectedItem.Text.Trim();
        string 风扇罩 = DropDownList10.SelectedItem.Text.Trim();

        string sql = String.Format("select 中准价,机座号 from 电机 where 电机型号='{0}' and  级数='{1}' and 功率='{2}'", 电机型号, 级数, 功率);

        DataTable dt = SQLHelper1.Query(sql).Tables[0];
        if (dt.Rows.Count > 1)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('数据不唯一!')", true);

            //MessageBox.Show(this, "数据不唯一");
        }
        if (dt.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有电机数据!')", true);

            //MessageBox.Show(UpdatePanel1, "没有电机数据");
        }
        else if (dt.Rows.Count == 1)
        {
            double d中准价 = Convert.ToDouble(dt.Rows[0][0]);
            int 机座号 = Convert.ToInt32(dt.Rows[0][1]);
            if ("无".Equals(防爆等级))
            {
                dResult = d中准价 * 1.69;
                calLog = calLog + d中准价 + " * 1.69 ";
            }
            else if ("BT4".Equals(防爆等级))
            {
                dResult = d中准价 * 1.5 * 2.57;
                calLog = calLog + d中准价 + " * 1.5 * 2.57 ";
            }
            else if ("CT4".Equals(防爆等级))
            {
                dResult = d中准价 * 1.5 * 2.57 * 1.7;
                calLog = calLog + d中准价 + " * 1.5 * 2.57 * 1.7 ";
            }

            if ("F".Equals(绝缘等级))
            {

            }
            else if ("H".Equals(绝缘等级))
            {
                dResult = dResult * 1.4;
                calLog = calLog + " * 1.4 ";
            }

            if ("轴流安装".Equals(安装方式))
            {

            }
            else if ("V1安装".Equals(安装方式))
            {
                dResult = dResult * 1.05;
                calLog = calLog + " * 1.05 ";
            }

            if ("外螺丝".Equals(轴头攻丝))
            {

            }
            else if ("B3/B35轴头丝".Equals(轴头攻丝))
            {
                dResult = dResult * 1.02;
                calLog = calLog + " * 1.02 ";
            }


            if ("国产".Equals(轴承))
            {

            }
            else if ("国外".Equals(轴承))
            {
                dResult = dResult * 1.05;
                calLog = calLog + " * 1.05 ";
            }
            else if ("SKF".Equals(轴承))
            {
                //YHZ系列电机价格+差价
                dResult = dResult * 1.1;
                calLog = calLog + " * 1.1 ";
            }


            if ("有".Equals(风扇罩))
            {

            }
            else if ("无".Equals(风扇罩))
            {
                dResult = dResult * 1.06;
                calLog = calLog + " * 1.06 ";
            }


            if ("无".Equals(加热带))
            {

            }
            else if ("有".Equals(加热带))
            {
                if (机座号 <= 132)
                {
                    dResult = dResult + 100;
                    calLog = calLog + " + 100";

                }
                else if (机座号 >= 160)
                {
                    dResult = dResult + 200;
                    calLog = calLog + " + 200";

                }
            }


            电机价格.Text = dResult.ToString();
            电机价格1.Text = "=" + calLog;

            double d总报价 = dResult;
            if (!"".Equals(叶轮价格.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(叶轮价格.Text);
            }
            if (!"".Equals(机壳价格.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(机壳价格.Text);
            }
            if (!"".Equals(进风口价格.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(进风口价格.Text);
            }
            if (!"".Equals(减震支架价格.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(减震支架价格.Text);
            }
            if (!"".Equals(出口法兰价格.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(出口法兰价格.Text);
            }
            if (!"".Equals(进口法兰价格.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(进口法兰价格.Text);
            }
            if (!"".Equals(其它总价格.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(其它总价格.Text);
            }
            总报价.Text = d总报价.ToString();

        }


    }
    protected void DropDownList11_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strText = DropDownList11.SelectedValue.Trim();
        if (!"请选择".Equals(strText))
        {
            总报价.Text = "";
            string sql = "select * from [风机报价基本表] where 风机型号='" + strText + "'  ";
            DataTable dt = SQLHelper1.Query(sql).Tables[0];
            for (int i = 3; i < dt.Columns.Count; i++)
            {
                foreach (Control ctrl in TabPanel1_1.Controls)
                {
                    foreach (Control childc in ctrl.Controls)
                    {

                        if ("System.Web.UI.WebControls.Label".Equals(childc.GetType().ToString()))
                        {
                            if (childc.ID.Equals(dt.Columns[i].ColumnName))
                            {
                                Label lbl = (Label)childc;
                                lbl.Text = dt.Rows[0][i].ToString();
                            }
                        }
                    }
                }
            }

            计算叶轮价格();
            计算机壳价格();
            计算进风口价格();
            计算减震支架价格();
            计算出口法兰价格();
            计算进口法兰价格();
            计算其它总价格();
        }
        else
        {
            ClearAll();     
        }
    }
    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算叶轮价格();
    }

    private void 计算叶轮价格()
    {
        double dResult = 0;
        string calcLog = "";
        叶轮价格.Text = "";
        叶轮价格1.Text = "";
        //string strText = DropDownList12.SelectedValue.Trim();
        string strVal = DropDownList12.SelectedValue.Trim();
        if (!"请选择".Equals(strVal) && !"".Equals(叶轮重量.Text))
        {
            //dResult = Convert.ToDouble(strVal) + Convert.ToDouble(叶轮重量.Text) + Convert.ToDouble(轴盘.Text) + Convert.ToDouble(叶轮工时.Text);
            dResult = Convert.ToDouble(叶轮重量.Text) * Convert.ToDouble(strVal) + Convert.ToDouble(轴盘.Text) +
                      53 * Convert.ToDouble(叶轮工时.Text);
            calcLog = calcLog + 叶轮重量.Text + "*" + strVal + "+" + 轴盘.Text + "+53*" + 叶轮工时.Text;
            叶轮价格.Text = dResult.ToString();
            叶轮价格1.Text = "=" + calcLog;

        }

    }
    protected void DropDownList13_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算机壳价格();
    }

    private void 计算机壳价格()
    {
        double dResult = 0;
        string calcLog = "";
        机壳价格.Text = "";
        机壳价格1.Text = "";
        //string strText = DropDownList13.SelectedValue.Trim();
        string strVal = DropDownList13.SelectedValue.Trim();
        if (!"请选择".Equals(strVal) && !"".Equals(机壳重量.Text))
        {
            dResult = Convert.ToDouble(机壳重量.Text) * Convert.ToDouble(strVal) + 53 * Convert.ToDouble(机壳工时.Text);
            calcLog = calcLog + 机壳重量.Text + "*" + strVal + "+53*" + 机壳工时.Text;

            机壳价格.Text = dResult.ToString();
            机壳价格1.Text = "=" + calcLog;

        }
    }

    protected void DropDownList14_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算进风口价格();
    }
    private void 计算进风口价格()
    {
        double dResult = 0;
        string calcLog = "";
        进风口价格.Text = "";
        进风口价格1.Text = "";
        string strVal = DropDownList14.SelectedValue.Trim();
        if (!"请选择".Equals(strVal) && !"".Equals(进风口重量.Text))
        {
            //dResult = Convert.ToDouble(进风口重量.Text) * Convert.ToDouble(strVal) + 53 * Convert.ToDouble(叶轮工时.Text);
            //calcLog = calcLog + 进风口重量.Text + "*" + strVal + "+53*" + 叶轮工时.Text;

            dResult = Convert.ToDouble(进风口重量.Text) * Convert.ToDouble(strVal) + Convert.ToDouble(铜板.Text) +
                  53 * Convert.ToDouble(进风口工时.Text);
            calcLog = calcLog + 进风口重量.Text + "*" + strVal + "+" + 铜板.Text + "+53*" + 进风口工时.Text;

            进风口价格.Text = dResult.ToString();
            进风口价格1.Text = "=" + calcLog;
        }
    }
    protected void DropDownList18_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算减震支架价格();
    }
    protected void DropDownList15_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算减震支架价格();
    }
    private void 计算减震支架价格()
    {
        double dResult = 0;
        string calcLog = "";
        减震支架价格.Text = "";
        减震支架价格1.Text = "";

        string strText18 = DropDownList18.SelectedValue.Trim();
        //string strVal18 = DropDownList18.SelectedValue.Trim();

        string strText15 = DropDownList15.SelectedValue.Trim();
        //string strVal15 = DropDownList15.SelectedValue.Trim();
        if (!"0".Equals(strText18) && !"请选择".Equals(strText15) && !"".Equals(减震支架工时.Text))
        //if (!"有".Equals(strText18) && !"请选择".Equals(strText15))
        {
            //dResult = Convert.ToDouble(strText15) + Convert.ToDouble(减震支架.Text) + Convert.ToDouble(减震支架工时.Text);
            //calcLog = calcLog + strText15 + "+" + 减震支架.Text + "+" + 减震支架工时.Text;

            dResult = Convert.ToDouble(减震支架.Text) * Convert.ToDouble(strText15) + 53 * Convert.ToDouble(减震支架工时.Text);
            calcLog = calcLog + 减震支架.Text + "*" + strText15 + "+53*" + 减震支架工时.Text;

            减震支架价格.Text = dResult.ToString();
            减震支架价格1.Text = "=" + calcLog;
        }
    }


    protected void DropDownList19_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算出口法兰价格();
    }
    protected void DropDownList16_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算出口法兰价格();
    }
    private void 计算出口法兰价格()
    {
        double dResult = 0;
        string calcLog = "";
        出口法兰价格.Text = "";
        出口法兰价格1.Text = "";

        string strText18 = DropDownList19.SelectedValue.Trim();
        //string strVal18 = DropDownList18.SelectedValue.Trim();

        string strText15 = DropDownList16.SelectedValue.Trim();
        //string strVal15 = DropDownList15.SelectedValue.Trim();
        if (!"0".Equals(strText18) && !"请选择".Equals(strText15) && !"".Equals(出口法兰工时.Text))
        //if (!"有".Equals(strText18) && !"请选择".Equals(strText15))
        {
            //dResult = Convert.ToDouble(strText15) + Convert.ToDouble(出口法兰重量.Text) + Convert.ToDouble(出口法兰工时.Text);
            //calcLog = calcLog + strText15 + "+" + 出口法兰重量.Text + "+" + 出口法兰工时.Text;

            dResult = Convert.ToDouble(出口法兰重量.Text) * Convert.ToDouble(strText15) + 53 * Convert.ToDouble(出口法兰工时.Text);
            calcLog = calcLog + 出口法兰重量.Text + "*" + strText15 + "+53*" + 出口法兰工时.Text;

            出口法兰价格.Text = dResult.ToString();
            出口法兰价格1.Text = "=" + calcLog;
        }
    }

    protected void DropDownList20_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算进口法兰价格();
    }
    protected void DropDownList17_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算进口法兰价格();
    }
    private void 计算进口法兰价格()
    {
        double dResult = 0;
        string calcLog = "";
        进口法兰价格.Text = "";
        进口法兰价格1.Text = "";

        string strText18 = DropDownList20.SelectedValue.Trim();
        //string strVal18 = DropDownList18.SelectedValue.Trim();

        string strText15 = DropDownList17.SelectedValue.Trim();
        //string strVal15 = DropDownList15.SelectedValue.Trim();
        if (!"0".Equals(strText18) && !"请选择".Equals(strText15) && !"".Equals(进口法兰工时.Text))
        //if (!"有".Equals(strText18) && !"请选择".Equals(strText15))
        {
            //dResult = Convert.ToDouble(strText15) + Convert.ToDouble(进口法兰重量.Text) + Convert.ToDouble(进口法兰工时.Text);

            //calcLog = calcLog + strText15 + "+" + 进口法兰重量.Text + "+" + 进口法兰工时.Text;

            dResult = Convert.ToDouble(进口法兰重量.Text) * Convert.ToDouble(strText15) + 53 * Convert.ToDouble(进口法兰工时.Text);
            calcLog = calcLog + 进口法兰重量.Text + "*" + strText15 + "+53*" + 进口法兰工时.Text;

            进口法兰价格.Text = dResult.ToString();
            进口法兰价格1.Text = "=" + calcLog;
        }
    }


    protected void DropDownList21_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格();
    }

    private void 计算其它总价格()
    {
        double dResult = 0;
        string calcLog = "";
        其它总价格.Text = "";
        其它总价格1.Text = "";
        if (!"".Equals(标准件核定.Text))
        {
            dResult = dResult + Convert.ToDouble(标准件核定.Text);
            calcLog = calcLog + 标准件核定.Text;

            string strText21 = DropDownList21.SelectedValue.Trim();
            string strText22 = DropDownList22.SelectedValue.Trim();
            string strText23 = DropDownList23.SelectedValue.Trim();
            string strText24 = DropDownList24.SelectedValue.Trim();
            string strText25 = DropDownList25.SelectedValue.Trim();
            if (!"0".Equals(strText21))
            {
                dResult = dResult + Convert.ToDouble(减震器.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 减震器.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 减震器.Text;
                }
            }

            if (!"0".Equals(strText22))
            {
                dResult = dResult + Convert.ToDouble(填料函.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 填料函.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 填料函.Text;
                }
            }
            if (!"0".Equals(strText23))
            {
                dResult = dResult + Convert.ToDouble(包装.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 包装.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 包装.Text;
                }
            }
            if (!"0".Equals(strText24))
            {
                dResult = dResult + Convert.ToDouble(防护网.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 防护网.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 防护网.Text;
                }
            }
            if (!"0".Equals(strText25))
            {
                dResult = dResult + Convert.ToDouble(软连接.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 软连接.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 软连接.Text;
                }
            }

            其它总价格.Text = dResult.ToString();
            其它总价格1.Text = "=" + calcLog;
        }


    }

    protected void DropDownList22_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格();
    }
    protected void DropDownList23_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格();
    }
    protected void DropDownList24_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格();
    }
    protected void DropDownList25_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }

    private void 清空电机价格()
    {
        电机价格.Text = "";
        电机价格1.Text = "";
    }

    private void 清空电机价格1()
    {
        Label1.Text = "";
        Label2.Text = "";
    }
    private void 清空电机价格2()
    {
        Label5.Text = "";
        Label6.Text = "";
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }
    protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }
    protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格();
    }

    //============================
    protected void Button2_Click(object sender, EventArgs e)
    {
        double dResult = 0;
        string calLog = "";
        Label1.Text = "";
        Label2.Text = "";
        string 电机型号 = DropDownList27.SelectedItem.Text.Trim();
        string 级数 = DropDownList28.SelectedItem.Text.Trim();
        string 功率 = DropDownList29.SelectedItem.Text.Trim();
        string 防爆等级 = DropDownList30.SelectedItem.Text.Trim();
        string 绝缘等级 = DropDownList31.SelectedItem.Text.Trim();
        string 安装方式 = DropDownList32.SelectedItem.Text.Trim();
        string 轴头攻丝 = DropDownList33.SelectedItem.Text.Trim();
        string 加热带 = DropDownList34.SelectedItem.Text.Trim();
        string 轴承 = DropDownList35.SelectedItem.Text.Trim();
        string 风扇罩 = DropDownList36.SelectedItem.Text.Trim();

        string sql = String.Format("select 中准价,机座号 from 电机 where 电机型号='{0}' and  级数='{1}' and 功率='{2}'", 电机型号, 级数, 功率);

        DataTable dt = SQLHelper1.Query(sql).Tables[0];
        if (dt.Rows.Count > 1)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('数据不唯一!')", true);

            //MessageBox.Show(this, "数据不唯一");
        }
        if (dt.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有电机数据!')", true);

            //MessageBox.Show(UpdatePanel1, "没有电机数据");
        }
        else if (dt.Rows.Count == 1)
        {
            double d中准价 = Convert.ToDouble(dt.Rows[0][0]);
            int 机座号 = Convert.ToInt32(dt.Rows[0][1]);
            if ("无".Equals(防爆等级))
            {
                dResult = d中准价 * 1.69;
                calLog = calLog + d中准价 + " * 1.69 ";
            }
            else if ("BT4".Equals(防爆等级))
            {
                dResult = d中准价 * 1.5 * 2.57;
                calLog = calLog + d中准价 + " * 1.5 * 2.57 ";
            }
            else if ("CT4".Equals(防爆等级))
            {
                dResult = d中准价 * 1.5 * 2.57 * 1.7;
                calLog = calLog + d中准价 + " * 1.5 * 2.57 * 1.7 ";
            }

            if ("F".Equals(绝缘等级))
            {

            }
            else if ("H".Equals(绝缘等级))
            {
                dResult = dResult * 1.4;
                calLog = calLog + " * 1.4 ";
            }

            if ("轴流安装".Equals(安装方式))
            {

            }
            else if ("V1安装".Equals(安装方式))
            {
                dResult = dResult * 1.05;
                calLog = calLog + " * 1.05 ";
            }

            if ("外螺丝".Equals(轴头攻丝))
            {

            }
            else if ("B3/B35轴头丝".Equals(轴头攻丝))
            {
                dResult = dResult * 1.02;
                calLog = calLog + " * 1.02 ";
            }


            if ("国产".Equals(轴承))
            {

            }
            else if ("国外".Equals(轴承))
            {
                dResult = dResult * 1.05;
                calLog = calLog + " * 1.05 ";
            }
            else if ("SKF".Equals(轴承))
            {
                //YHZ系列电机价格+差价
                dResult = dResult * 1.1;
                calLog = calLog + " * 1.1 ";
            }


            if ("有".Equals(风扇罩))
            {

            }
            else if ("无".Equals(风扇罩))
            {
                dResult = dResult * 1.06;
                calLog = calLog + " * 1.06 ";
            }


            if ("无".Equals(加热带))
            {

            }
            else if ("有".Equals(加热带))
            {
                if (机座号 <= 132)
                {
                    dResult = dResult + 100;
                    calLog = calLog + " + 100";

                }
                else if (机座号 >= 160)
                {
                    dResult = dResult + 200;
                    calLog = calLog + " + 200";

                }
            }


            Label1.Text = dResult.ToString();
            Label2.Text = "=" + calLog;

            double d总报价 = dResult;
            if (!"".Equals(Label3.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label3.Text);
            }
            if (!"".Equals(Label8.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label8.Text);
            }
            if (!"".Equals(Label12.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label12.Text);
            }
            if (!"".Equals(Label17.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label17.Text);
            }
            if (!"".Equals(Label21.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label21.Text);
            }
            if (!"".Equals(Label25.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label25.Text);
            }
            if (!"".Equals(Label30.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label30.Text);
            }
            总报价1.Text = d总报价.ToString();

        }

    }
    protected void DropDownList26_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strText = DropDownList26.SelectedValue.Trim();
        if (!"请选择".Equals(strText))
        {
            总报价.Text = "";
            string sql = "select * from [风机报价基本表CLQ] where 风机型号='" + strText + "'  ";
            DataTable dt = SQLHelper1.Query(sql).Tables[0];
            for (int i = 3; i < dt.Columns.Count; i++)
            {
                foreach (Control ctrl in TabPanel1_2.Controls)
                {
                    foreach (Control childc in ctrl.Controls)
                    {

                        if ("System.Web.UI.WebControls.Label".Equals(childc.GetType().ToString()))
                        {
                            if (childc.ID.Equals(dt.Columns[i].ColumnName))
                            {
                                Label lbl = (Label)childc;
                                lbl.Text = dt.Rows[0][i].ToString();
                            }
                        }
                    }
                }
            }

            计算叶轮价格1();
            计算机壳价格1();
            计算进风口价格1();
            计算减震支架价格1();
            计算出口法兰价格1();
            计算进口法兰价格1();
            计算其它总价格1();
        }
        else
        {
            ClearAll1();
        }
    }

    protected void DropDownList37_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算叶轮价格1();
    }

    private void 计算叶轮价格1()
    {
        double dResult = 0;
        string calcLog = "";
        Label3.Text = "";
        Label4.Text = "";
        //string strText = DropDownList12.SelectedValue.Trim();
        string strVal = DropDownList37.SelectedValue.Trim();
        if (!"请选择".Equals(strVal) && !"".Equals(叶轮重量1.Text))
        {
            //dResult = Convert.ToDouble(strVal) + Convert.ToDouble(叶轮重量.Text) + Convert.ToDouble(轴盘.Text) + Convert.ToDouble(叶轮工时.Text);
            dResult = Convert.ToDouble(叶轮重量1.Text) * Convert.ToDouble(strVal) + Convert.ToDouble(轴盘1.Text) +
                      53 * Convert.ToDouble(叶轮工时1.Text);
            calcLog = calcLog + 叶轮重量1.Text + "*" + strVal + "+" + 轴盘1.Text + "+53*" + 叶轮工时1.Text;
            Label3.Text = dResult.ToString();
            Label4.Text = "=" + calcLog;

        }
    }
    protected void DropDownList38_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算机壳价格1();
    }
    private void 计算机壳价格1()
    {
        double dResult = 0;
        string calcLog = "";
        Label8.Text = "";
        Label9.Text = "";
        //string strText = DropDownList13.SelectedValue.Trim();
        string strVal = DropDownList38.SelectedValue.Trim();
        if (!"请选择".Equals(strVal) && !"".Equals(机壳重量1.Text))
        {
            dResult = Convert.ToDouble(机壳重量1.Text) * Convert.ToDouble(strVal) + 53 * Convert.ToDouble(机壳工时1.Text);
            calcLog = calcLog + 机壳重量1.Text + "*" + strVal + "+53*" + 机壳工时1.Text;

            Label8.Text = dResult.ToString();
            Label9.Text = "=" + calcLog;

        }
    }
    protected void DropDownList39_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算进风口价格1();
    }

    private void 计算进风口价格1()
    {
        double dResult = 0;
        string calcLog = "";
        Label12.Text = "";
        Label13.Text = "";
        string strVal = DropDownList39.SelectedValue.Trim();
        if (!"请选择".Equals(strVal) && !"".Equals(进风口重量1.Text))
        {
            //dResult = Convert.ToDouble(进风口重量.Text) * Convert.ToDouble(strVal) + 53 * Convert.ToDouble(叶轮工时.Text);
            //calcLog = calcLog + 进风口重量.Text + "*" + strVal + "+53*" + 叶轮工时.Text;

            dResult = Convert.ToDouble(进风口重量1.Text) * Convert.ToDouble(strVal) +
                  53 * Convert.ToDouble(进风口工时1.Text);
            calcLog = calcLog + 进风口重量1.Text + "*" + strVal  + "+53*" + 进风口工时1.Text;

            Label12.Text = dResult.ToString();
            Label13.Text = "=" + calcLog;
        }
    }

    protected void DropDownList40_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算减震支架价格1();
    }
    protected void DropDownList41_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算减震支架价格1();
    }


    private void 计算减震支架价格1()
    {
        double dResult = 0;
        string calcLog = "";
        Label17.Text = "";
        Label18.Text = "";

        string strText18 = DropDownList40.SelectedValue.Trim();
        //string strVal18 = DropDownList18.SelectedValue.Trim();

        string strText15 = DropDownList41.SelectedValue.Trim();
        //string strVal15 = DropDownList15.SelectedValue.Trim();
        if (!"0".Equals(strText18) && !"请选择".Equals(strText15) && !"".Equals(减震支架工时1.Text))
        //if (!"有".Equals(strText18) && !"请选择".Equals(strText15))
        {
            //dResult = Convert.ToDouble(strText15) + Convert.ToDouble(减震支架.Text) + Convert.ToDouble(减震支架工时.Text);
            //calcLog = calcLog + strText15 + "+" + 减震支架.Text + "+" + 减震支架工时.Text;

            dResult = Convert.ToDouble(减震支架1.Text) * Convert.ToDouble(strText15) + 53 * Convert.ToDouble(减震支架工时1.Text);
            calcLog = calcLog + 减震支架1.Text + "*" + strText15 + "+53*" + 减震支架工时1.Text;

            Label17.Text = dResult.ToString();
            Label18.Text = "=" + calcLog;
        }
    }



    protected void DropDownList42_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算出口法兰价格1();
    }
    protected void DropDownList43_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算出口法兰价格1();
    }


    private void 计算出口法兰价格1()
    {
        double dResult = 0;
        string calcLog = "";
        Label21.Text = "";
        Label22.Text = "";

        string strText18 = DropDownList42.SelectedValue.Trim();
        //string strVal18 = DropDownList18.SelectedValue.Trim();

        string strText15 = DropDownList43.SelectedValue.Trim();
        //string strVal15 = DropDownList15.SelectedValue.Trim();
        if (!"0".Equals(strText18) && !"请选择".Equals(strText15) && !"".Equals(出口法兰工时1.Text))
        //if (!"有".Equals(strText18) && !"请选择".Equals(strText15))
        {
            //dResult = Convert.ToDouble(strText15) + Convert.ToDouble(出口法兰重量.Text) + Convert.ToDouble(出口法兰工时.Text);
            //calcLog = calcLog + strText15 + "+" + 出口法兰重量.Text + "+" + 出口法兰工时.Text;

            dResult = Convert.ToDouble(出口法兰重量1.Text) * Convert.ToDouble(strText15) + 53 * Convert.ToDouble(出口法兰工时1.Text);
            calcLog = calcLog + 出口法兰重量1.Text + "*" + strText15 + "+53*" + 出口法兰工时1.Text;

            Label21.Text = dResult.ToString();
            Label22.Text = "=" + calcLog;
        }
    }




    protected void DropDownList44_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算进口法兰价格1();
    }
    protected void DropDownList45_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算进口法兰价格1();
    }

    private void 计算进口法兰价格1()
    {
        double dResult = 0;
        string calcLog = "";
        Label25.Text = "";
        Label26.Text = "";

        string strText18 = DropDownList20.SelectedValue.Trim();
        //string strVal18 = DropDownList18.SelectedValue.Trim();

        string strText15 = DropDownList17.SelectedValue.Trim();
        //string strVal15 = DropDownList15.SelectedValue.Trim();
        if (!"0".Equals(strText18) && !"请选择".Equals(strText15) && !"".Equals(进口法兰工时1.Text))
        //if (!"有".Equals(strText18) && !"请选择".Equals(strText15))
        {
            //dResult = Convert.ToDouble(strText15) + Convert.ToDouble(进口法兰重量.Text) + Convert.ToDouble(进口法兰工时.Text);

            //calcLog = calcLog + strText15 + "+" + 进口法兰重量.Text + "+" + 进口法兰工时.Text;

            dResult = Convert.ToDouble(进口法兰重量1.Text) * Convert.ToDouble(strText15) + 53 * Convert.ToDouble(进口法兰工时1.Text);
            calcLog = calcLog + 进口法兰重量1.Text + "*" + strText15 + "+53*" + 进口法兰工时1.Text;

            Label25.Text = dResult.ToString();
            Label26.Text = "=" + calcLog;
        }
    }



    protected void DropDownList200_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格1();
    }
    protected void DropDownList201_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格1();
    }
    protected void DropDownList203_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格1();
    }
    protected void DropDownList204_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格1();
    }
    protected void DropDownList205_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格1();
    }

    private void 计算其它总价格1()
    {
        double dResult = 0;
        string calcLog = "";
        Label30.Text = "";
        Label31.Text = "";
        if (!"".Equals(标准件核定1.Text))
        {
            dResult = dResult + Convert.ToDouble(标准件核定1.Text);
            calcLog = calcLog + 标准件核定1.Text;

            string strText21 = DropDownList200.SelectedValue.Trim();
            string strText22 = DropDownList201.SelectedValue.Trim();
            string strText23 = DropDownList203.SelectedValue.Trim();
            string strText24 = DropDownList204.SelectedValue.Trim();
            string strText25 = DropDownList205.SelectedValue.Trim();
            if (!"0".Equals(strText21))
            {
                dResult = dResult + Convert.ToDouble(减震器1.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 减震器1.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 减震器1.Text;
                }
            }

            if (!"0".Equals(strText22))
            {
                dResult = dResult + Convert.ToDouble(填料函1.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 填料函1.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 填料函1.Text;
                }
            }
            if (!"0".Equals(strText23))
            {
                dResult = dResult + Convert.ToDouble(包装1.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 包装1.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 包装1.Text;
                }
            }
            if (!"0".Equals(strText24))
            {
                dResult = dResult + Convert.ToDouble(防护网1.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 防护网1.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 防护网1.Text;
                }
            }
            if (!"0".Equals(strText25))
            {
                dResult = dResult + Convert.ToDouble(软连接1.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 软连接1.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 软连接1.Text;
                }
            }

            Label30.Text = dResult.ToString();
            Label31.Text = "=" + calcLog;
        }


    }


    protected void DropDownList46_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList47_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList48_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList49_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList50_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList51_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList52_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList53_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList54_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList55_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }
    protected void DropDownList56_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格2();
    }


    protected void DropDownList27_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList28_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList29_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList30_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();

    }
    protected void DropDownList31_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList32_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList33_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList34_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList35_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList36_SelectedIndexChanged(object sender, EventArgs e)
    {
        清空电机价格1();
    }
    protected void DropDownList300_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格3();
    }
    protected void DropDownList301_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格3();
    }
    protected void DropDownList303_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格3();
    }
    protected void DropDownList304_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格3();
    }
    protected void DropDownList305_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格3();
    }
    protected void DropDownList57_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList307_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strText = DropDownList46.SelectedValue.Trim();
        string strText1 = DropDownList307.SelectedValue.Trim();
        if (!"请选择".Equals(strText) && !"请选择".Equals(strText1))
        {
            总报价.Text = "";
            string sql = "select * from [风机报价基本表CZ] where 风机型号='" + strText + "'  and 风筒板厚='" + strText1 + "'   ";
            DataTable dt = SQLHelper1.Query(sql).Tables[0];

            if (dt.Rows.Count==1)
            {
                for (int i = 3; i < dt.Columns.Count; i++)
                {
                    foreach (Control ctrl in TabPanel4.Controls)
                    {
                        foreach (Control childc in ctrl.Controls)
                        {

                            if ("System.Web.UI.WebControls.Label".Equals(childc.GetType().ToString()))
                            {
                                if (childc.ID.Equals(dt.Columns[i].ColumnName))
                                {
                                    Label lbl = (Label)childc;
                                    lbl.Text = dt.Rows[0][i].ToString();
                                }
                            }
                        }
                    }
                }

                计算叶轮价格3();
             
                计算风筒价格3();
                计算配对法兰价格3();
                计算其它总价格3();
            

            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('数据不唯一!')", true);
                ClearAll2();
            }


         
        }
        else
        {
            ClearAll2();
        }
    }

    private void 计算叶轮价格3()
    {
        double dResult = 0;
        string calcLog = "";
        Label7.Text = "";
        Label10.Text = "";
        //string strText = DropDownList12.SelectedValue.Trim();
        //string strVal = DropDownList12.SelectedValue.Trim();
        //if (!"请选择".Equals(strVal) && !"".Equals(叶轮重量.Text))
        //{
            //dResult = Convert.ToDouble(strVal) + Convert.ToDouble(叶轮重量.Text) + Convert.ToDouble(轴盘.Text) + Convert.ToDouble(叶轮工时.Text);
        dResult =  Convert.ToDouble(叶轮材料费3.Text) +  53 * Convert.ToDouble(叶轮工时3.Text);
        calcLog = calcLog + 叶轮材料费3.Text + "+53*" + 叶轮工时3.Text;
            Label7.Text = dResult.ToString();
            Label10.Text = "=" + calcLog;

        //}

    }

    private void 计算风筒价格3()
    {
        string sql = "";
         
        sql = "SELECT *  from [Param]  where [是否在投标中]=1";
        DataSet ds = SQLHelper1.Query(sql);

        DataTable dataTable = ds.Tables[0];
        string a1 = dataTable.Rows[0]["废铁处理基价"].ToString().Trim();
        string a2 = dataTable.Rows[0]["铝型材处理基价"].ToString().Trim();
        string a3 = dataTable.Rows[0]["不锈钢处理基价"].ToString().Trim();

        double dResult = 0;
        string calcLog = "";
        Label16.Text = "";
        Label19.Text = "";
        //string strVal = DropDownList14.SelectedValue.Trim();
        //if (!"请选择".Equals(strVal) && !"".Equals(风筒重量.Text))
        //{       
            dResult = Convert.ToDouble(风筒重量3.Text) * Convert.ToDouble(a2) +  53 * Convert.ToDouble(风筒工时3.Text);
            calcLog = calcLog + 风筒重量3.Text + "*" + a2 + "+53*" + 风筒工时3.Text;

            Label16.Text = dResult.ToString();
            Label19.Text = "=" + calcLog;
        ////}
    }

    private void 计算配对法兰价格3()
    {
        string sql = "";

        sql = "SELECT *  from [Param]  where [是否在投标中]=1";
        DataSet ds = SQLHelper1.Query(sql);

        DataTable dataTable = ds.Tables[0];
        string a1 = dataTable.Rows[0]["废铁处理基价"].ToString().Trim();
        string a2 = dataTable.Rows[0]["铝型材处理基价"].ToString().Trim();
        string a3 = dataTable.Rows[0]["不锈钢处理基价"].ToString().Trim();

        double dResult = 0;
        string calcLog = "";
        Label24.Text = "";
        Label27.Text = "";
        //string strVal = DropDownList14.SelectedValue.Trim();
        //if (!"请选择".Equals(strVal) && !"".Equals(配对法兰重量.Text))
        //{       
        dResult = Convert.ToDouble(配对法兰重量3.Text) * Convert.ToDouble(a2) + 53 * Convert.ToDouble(配对法兰工时3.Text);
        calcLog = calcLog + 配对法兰重量3.Text + "*" + a2 + "+53*" + 配对法兰工时3.Text;

        Label24.Text = dResult.ToString();
        Label27.Text = "=" + calcLog;
        ////}
    }

    private void 计算其它总价格3()
    {
        double dResult = 0;
        string calcLog = "";
        Label45.Text = "";
        Label46.Text = "";
        //if (!"".Equals(标准件核定3.Text))
        //{
            dResult = dResult + Convert.ToDouble(标准件核定3.Text);
            calcLog = calcLog + 标准件核定3.Text;

            string strText300 = DropDownList300.SelectedValue.Trim();
            string strText301 = DropDownList301.SelectedValue.Trim();
            string strText303 = DropDownList303.SelectedValue.Trim();
            string strText304 = DropDownList304.SelectedValue.Trim();
            string strText305 = DropDownList305.SelectedValue.Trim();
            string strText306 = DropDownList306.SelectedValue.Trim();
            if (!"0".Equals(strText300))
            {
                dResult = dResult + Convert.ToDouble(减震器3.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 减震器3.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 减震器3.Text;
                }
            }

            if (!"0".Equals(strText301))
            {
                dResult = dResult + Convert.ToDouble(填料函3.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 填料函3.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 填料函3.Text;
                }
            }
            if (!"0".Equals(strText303))
            {
                dResult = dResult + Convert.ToDouble(包装核定3.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 包装核定3.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 包装核定3.Text;
                }
            }
            if (!"0".Equals(strText304))
            {
                dResult = dResult + Convert.ToDouble(防护网3.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 防护网3.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 防护网3.Text;
                }
            }
            if (!"0".Equals(strText305))
            {
                dResult = dResult + Convert.ToDouble(接线盒3.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 接线盒3.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 接线盒3.Text;
                }
            }

            if (!"0".Equals(strText306))
            {
                dResult = dResult + Convert.ToDouble(支撑板3.Text);
                if ("".Equals(calcLog))
                {
                    calcLog = calcLog + 支撑板3.Text;
                }
                else
                {
                    calcLog = calcLog + "+" + 支撑板3.Text;
                }
            }


            Label45.Text = dResult.ToString();
            Label46.Text = "=" + calcLog;
        //}


    }


    protected void DropDownList306_SelectedIndexChanged(object sender, EventArgs e)
    {
        计算其它总价格3();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        double dResult = 0;
        string calLog = "";
        Label5.Text = "";
        Label6.Text = "";
        string 电机型号 = DropDownList47.SelectedItem.Text.Trim();
        string 级数 = DropDownList48.SelectedItem.Text.Trim();
        string 功率 = DropDownList49.SelectedItem.Text.Trim();
        string 防爆等级 = DropDownList50.SelectedItem.Text.Trim();
        string 绝缘等级 = DropDownList51.SelectedItem.Text.Trim();
        string 安装方式 = DropDownList52.SelectedItem.Text.Trim();
        string 轴头攻丝 = DropDownList53.SelectedItem.Text.Trim();
        string 加热带 = DropDownList54.SelectedItem.Text.Trim();
        string 轴承 = DropDownList55.SelectedItem.Text.Trim();
        string 风扇罩 = DropDownList56.SelectedItem.Text.Trim();

        string sql = String.Format("select 中准价,机座号 from 电机 where 电机型号='{0}' and  级数='{1}' and 功率='{2}'", 电机型号, 级数, 功率);

        DataTable dt = SQLHelper1.Query(sql).Tables[0];
        if (dt.Rows.Count > 1)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('数据不唯一!')", true);

            //MessageBox.Show(this, "数据不唯一");
        }
        if (dt.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alert", "alert('没有电机数据!')", true);

            //MessageBox.Show(UpdatePanel1, "没有电机数据");
        }
        else if (dt.Rows.Count == 1)
        {
            double d中准价 = Convert.ToDouble(dt.Rows[0][0]);
            int 机座号 = Convert.ToInt32(dt.Rows[0][1]);
            if ("无".Equals(防爆等级))
            {
                dResult = d中准价 * 1.69;
                calLog = calLog + d中准价 + " * 1.69 ";
            }
            else if ("BT4".Equals(防爆等级))
            {
                dResult = d中准价 * 1.5 * 2.57;
                calLog = calLog + d中准价 + " * 1.5 * 2.57 ";
            }
            else if ("CT4".Equals(防爆等级))
            {
                dResult = d中准价 * 1.5 * 2.57 * 1.7;
                calLog = calLog + d中准价 + " * 1.5 * 2.57 * 1.7 ";
            }

            if ("F".Equals(绝缘等级))
            {

            }
            else if ("H".Equals(绝缘等级))
            {
                dResult = dResult * 1.4;
                calLog = calLog + " * 1.4 ";
            }

            if ("轴流安装".Equals(安装方式))
            {

            }
            else if ("V1安装".Equals(安装方式))
            {
                dResult = dResult * 1.05;
                calLog = calLog + " * 1.05 ";
            }

            if ("外螺丝".Equals(轴头攻丝))
            {

            }
            else if ("B3/B35轴头丝".Equals(轴头攻丝))
            {
                dResult = dResult * 1.02;
                calLog = calLog + " * 1.02 ";
            }


            if ("国产".Equals(轴承))
            {

            }
            else if ("国外".Equals(轴承))
            {
                dResult = dResult * 1.05;
                calLog = calLog + " * 1.05 ";
            }
            else if ("SKF".Equals(轴承))
            {
                //YHZ系列电机价格+差价
                dResult = dResult * 1.1;
                calLog = calLog + " * 1.1 ";
            }


            if ("有".Equals(风扇罩))
            {

            }
            else if ("无".Equals(风扇罩))
            {
                dResult = dResult * 1.06;
                calLog = calLog + " * 1.06 ";
            }


            if ("无".Equals(加热带))
            {

            }
            else if ("有".Equals(加热带))
            {
                if (机座号 <= 132)
                {
                    dResult = dResult + 100;
                    calLog = calLog + " + 100";

                }
                else if (机座号 >= 160)
                {
                    dResult = dResult + 200;
                    calLog = calLog + " + 200";

                }
            }


            Label5.Text = dResult.ToString();
            Label6.Text = "=" + calLog;

            double d总报价 = dResult;
            if (!"".Equals(Label5.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label5.Text);
            }
            if (!"".Equals(Label7.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label7.Text);
            }
            if (!"".Equals(Label16.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label16.Text);
            }
            if (!"".Equals(Label24.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label24.Text);
            }
            if (!"".Equals(Label45.Text))
            {
                d总报价 = d总报价 + Convert.ToDouble(Label45.Text);
            }
            //if (!"".Equals(Label25.Text))
            //{
            //    d总报价 = d总报价 + Convert.ToDouble(Label25.Text);
            //}
            //if (!"".Equals(Label30.Text))
            //{
            //    d总报价 = d总报价 + Convert.ToDouble(Label30.Text);
            //}
            总报价3.Text = d总报价.ToString();

        }
    }
}

