using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class WorkForms_MomPop : System.Web.UI.Page
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
        string parValue = Request.QueryString["id"];
        if (String.IsNullOrEmpty(parValue))
        {
            Response.Write("<script>window.close();</script>");
            Response.Redirect("./Mom.aspx");
            Response.End();
        }
        string aSql = "select mom_moallocate.[AllocateId],mom_moallocate.[MoDId],mom_moallocate.[SortSeq],mom_orderdetail.MDeptCode,Warehouse.[cWhName],mom_moallocate.invcode,inventory.cinvname,mom_moallocate.qty,mom_moallocate.issqty, 0.00 as  xiancun,mom_moallocate.qty-mom_moallocate.issqty yaoling " +
                                     "from mom_moallocate " +
                                     "left join mom_orderdetail on mom_moallocate.modid = mom_orderdetail.modid " +
                                     "left join inventory on mom_moallocate.invcode = inventory.cinvcode " +
                                     //"left join CurrentStock on CurrentStock.cWhCode = mom_moallocate.whcode and CurrentStock.cInvCode = mom_moallocate.InvCode " +
                                     "left join Warehouse on Warehouse.cWhCode = mom_moallocate.whcode  " +
                                     "where mom_moallocate.modid=" + parValue + " " +
                                     "order by mom_moallocate.whcode";
        DataSet ds = SQLHelper.Query(aSql);
        //this.HiddenField1.Value = row.Cells[0].Text;
        //this.HiddenField2.Value = row.Cells[4].Text;
        //this.HiddenField3.Value = row.Cells[3].Text;
        //this.HiddenField4.Value = row.Cells[6].Text;
        DataTable dt = ds.Tables[0];
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
        //DataTable dt = ds.Tables[0];




        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

}