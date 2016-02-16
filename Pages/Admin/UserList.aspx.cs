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

public partial class Pages_Admin_UserList : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvUserBind();
        }
    }
    public void gvUserBind()
    {
        string strSql = "select * from UserInfo";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbUser");
        this.gvUserList.DataSource = dsTable.DefaultView;
        this.gvUserList.DataKeyNames = new string[] { "UserID" };
        this.gvUserList.DataBind();
    }
    protected void gvUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUserList.PageIndex = e.NewPageIndex;
        gvUserBind();
    }
    protected void gvUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strSql = "delete from UserInfo where UserID=" + Convert.ToInt32(gvUserList.DataKeys[e.RowIndex].Value.ToString());
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        dbObj.ExecNonQuery(myCmd);
        gvUserBind();
    }
}