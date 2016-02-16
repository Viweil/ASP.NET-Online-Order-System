using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
/// <summary>
/// Summary description for UserClass
/// </summary>
public class UserClass
{
    DBClass dbObj = new DBClass();
	public UserClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable UserLogin(string strName, string strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_UserLogin");
         
        SqlParameter Name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        
        SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }

    public DataTable GetUserInfo(int IntUserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetUser");

        SqlParameter userId = new SqlParameter("@UserID", SqlDbType.Int, 4);
        userId.Value = IntUserID;
        myCmd.Parameters.Add(userId);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }

    public int AddUser(string strFirstName, string strLastName, string strUserName, string strPassword,
        string strEmail, string strMobile, string strWorkPhone,string strHomePhone, string strAddress)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AddUser");

        SqlParameter firstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
        firstName.Value = strFirstName;
        myCmd.Parameters.Add(firstName);

        SqlParameter lastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
        lastName.Value = strLastName;
        myCmd.Parameters.Add(lastName); 
        
        SqlParameter username = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        username.Value = strUserName;
        myCmd.Parameters.Add(username);
        
        SqlParameter password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        password.Value = strPassword;
        myCmd.Parameters.Add(password);

        SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar, 50);
        email.Value = strEmail;
        myCmd.Parameters.Add(email);
       
        SqlParameter mobile = new SqlParameter("@Mobile", SqlDbType.VarChar, 20);
        mobile.Value = strMobile;
        myCmd.Parameters.Add(mobile);

        SqlParameter workPhone = new SqlParameter("@WorkPhone", SqlDbType.Char, 10);
        workPhone.Value = strWorkPhone;
        myCmd.Parameters.Add(workPhone);

        SqlParameter homePhone = new SqlParameter("@HomePhone", SqlDbType.Char, 10);
        homePhone.Value = strHomePhone;
        myCmd.Parameters.Add(homePhone);
        
        SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        address.Value = strAddress;
        myCmd.Parameters.Add(address);
                
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }

    public void ModifyUser(string strFirstName, string strLastName, string strUserName,
        string strEmail, string strMobile, string strWorkPhone, string strHomePhone, string strAddress, int IntUserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_ModifyUser");

        SqlParameter firstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
        firstName.Value = strFirstName;
        myCmd.Parameters.Add(firstName);

        SqlParameter lastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
        lastName.Value = strLastName;
        myCmd.Parameters.Add(lastName);

        SqlParameter username = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        username.Value = strUserName;
        myCmd.Parameters.Add(username);

        SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar, 50);
        email.Value = strEmail;
        myCmd.Parameters.Add(email);

        SqlParameter mobile = new SqlParameter("@Mobile", SqlDbType.VarChar, 20);
        mobile.Value = strMobile;
        myCmd.Parameters.Add(mobile);

        SqlParameter workPhone = new SqlParameter("@WorkPhone", SqlDbType.Char, 10);
        workPhone.Value = strWorkPhone;
        myCmd.Parameters.Add(workPhone);

        SqlParameter homePhone = new SqlParameter("@HomePhone", SqlDbType.Char, 10);
        homePhone.Value = strHomePhone;
        myCmd.Parameters.Add(homePhone);

        SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        address.Value = strAddress;
        myCmd.Parameters.Add(address);
         
        SqlParameter userId = new SqlParameter("@UserId", SqlDbType.Int, 4);
        userId.Value = IntUserID;
        myCmd.Parameters.Add(userId);
        dbObj.ExecNonQuery(myCmd);

    }

    public void ModifyUserOrder(int IntOrderID, int IntUserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_ModifyUserOrder");

        SqlParameter orderId = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        orderId.Value = IntOrderID;
        myCmd.Parameters.Add(orderId);

        SqlParameter userId = new SqlParameter("@UserId", SqlDbType.Int, 4);
        userId.Value = IntUserID;
        myCmd.Parameters.Add(userId);
        dbObj.ExecNonQuery(myCmd);
    }

}