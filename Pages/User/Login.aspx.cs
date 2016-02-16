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
using BLL;
using Model;

public partial class Pages_User_Login : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Session["UserID"] = null;
        Session["UserName"] = null;

        #region varify login
        UserInfo userInfo = new UserInfo();                
        userInfo.UserName = this.TxtUserName.Text.Trim(); 
        userInfo.Password = this.TxtPassword.Text.Trim();

        UserInfo_BLL userInfoBll = new UserInfo_BLL();   
        UserInfo result = userInfoBll.CheckUserInfoByUserNameAndPassword(userInfo);
        #endregion

        if (result != null && result.UserID > 0)// after login redirect MyDetails
        {
            Session["UserID"] = result.UserID;
            Session["UserName"] = result.UserName;
            Response.Redirect("~/Pages/User/MyDetails.aspx");
        }
        else
        {
            lblError.Text = "User Name or Password Incorrect.";
        }
    }
 
}