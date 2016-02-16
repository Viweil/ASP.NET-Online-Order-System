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

public partial class Pages_Admin_CategoryList : System.Web.UI.Page
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
        string strSql = "select * from Category";
        DataTable dbTable = dbObj.GetDataSetStr(strSql, "tbClass");
        this.gvCategoryList.DataSource = dbTable.DefaultView;
        this.gvCategoryList.DataKeyNames = new string[] { "CategoryID" };
        this.gvCategoryList.DataBind();
    }

    protected void gvCategoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategoryList.PageIndex = e.NewPageIndex;
        gvBind();

    }

    protected void gvCategoryList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int IntCategoryID = Convert.ToInt32(gvCategoryList.DataKeys[e.RowIndex].Value);
        string strSql = "select count(*) from Products where CategoryID=" + IntCategoryID;
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        if (Convert.ToInt32(dbObj.ExecScalar(myCmd)) != 0)
        {
            Response.Write(ccObj.MessageBox("You can't delete since is using now."));
            Response.Redirect("CategoryList.aspx");
        }
        else
        {
            string strDelSql = "delete from Category where CategoryID=" + IntCategoryID;
            SqlCommand myDelCmd = dbObj.GetCommandStr(strDelSql);
            dbObj.ExecNonQuery(myDelCmd);
            gvBind();

        }


    }
}