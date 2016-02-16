using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Pages_Admin_SupplierList : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    public void gvBind()
    {
        string strSql = "select * from Supplier";
        DataTable dbTable = dbObj.GetDataSetStr(strSql, "tbSupplier");
        this.gvSupplierList.DataSource = dbTable.DefaultView;
        this.gvSupplierList.DataKeyNames = new string[] { "SupplierID" };
        this.gvSupplierList.DataBind();
    }

    protected void gvSupplierList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSupplierList.PageIndex = e.NewPageIndex;
        gvBind();

    }
    protected void gvSupplierList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int IntSupplierID = Convert.ToInt32(gvSupplierList.DataKeys[e.RowIndex].Value);
        string strSql = "select count(*) from Products where SupplierID=" + IntSupplierID;
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        if (Convert.ToInt32(dbObj.ExecScalar(myCmd)) != 0)
        {
            Response.Write(ccObj.MessageBox("You can't delete since is using now."));
            Response.Redirect("SupplierList.aspx");
        }
        else
        {
            string strDelSql = "delete from Supplier where SupplierID=" + IntSupplierID;
            SqlCommand myDelCmd = dbObj.GetCommandStr(strDelSql);
            dbObj.ExecNonQuery(myDelCmd);
            gvBind();

        }


    }
}