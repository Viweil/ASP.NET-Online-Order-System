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

public partial class Pages_Admin_UserEdit : System.Web.UI.Page
{
    DBClass dbObj = new DBClass();
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            GetUserInfo();
        }
    }


    public void GetUserInfo()
    {
        string strSql = "select * from UserInfo where UserID= '" + Convert.ToInt32(Request["UserID"].Trim()) + "'";
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");       
        this.txtFirstName.Text = dsTable.Rows[0]["FirstName"].ToString();
        this.txtLastName.Text = dsTable.Rows[0]["LastName"].ToString();
        this.txtUserName.Text = dsTable.Rows[0]["UserName"].ToString();
        this.txtEmail.Text = dsTable.Rows[0]["Email"].ToString();
        this.txtAddress.Text = dsTable.Rows[0]["Address"].ToString();
        this.txtMobile.Text = dsTable.Rows[0]["Mobile"].ToString();
        this.txtHomePhone.Text = dsTable.Rows[0]["HomePhone"].ToString();
        this.txtWorkPhone.Text = dsTable.Rows[0]["WorkPhone"].ToString();
        this.lblUserID.Text = Request["UserID"].Trim();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int IntUserID = Convert.ToInt32(lblUserID.Text.Trim());
        ucObj.ModifyUser(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtUserName.Text.Trim(), txtEmail.Text.Trim(),
             txtMobile.Text.Trim(), txtWorkPhone.Text.Trim(), txtHomePhone.Text.Trim(), txtAddress.Text.Trim(), IntUserID);
        Response.Write(ccObj.MessageBox("Successful！", "UserList.aspx"));
    }
   
}