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

public partial class Pages_Admin_AdminLogin : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (this.txtAdminName.Text.Trim() == "" || this.txtAdminPwd.Text.Trim() == "")
        {
            Response.Write(ccObj.MessageBox("Please type admin name and password！"));
        }
        else
        {
            string strSql = "select * from Admin where AdminName='" + this.txtAdminName.Text.Trim() + "' and Password='" + this.txtAdminPwd.Text.Trim() + "'";
            DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbAdmin");
            if (dsTable.Rows.Count > 0)
            {
                Session["AdminID"] = Convert.ToInt32(dsTable.Rows[0][0].ToString());
                Session["AdminName"] = dsTable.Rows[0][1].ToString();
                Response.Redirect("AdminIndex.aspx");
            }
            else
            {
                Response.Write(ccObj.MessageBox("Incorrect name or password."));
            }
        }
    }
}