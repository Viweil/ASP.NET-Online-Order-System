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
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for OrderClass
/// </summary>
public class OrderClass
{
    DBClass dbObj = new DBClass();
    CommonClass ccObj = new CommonClass();
	public OrderClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //public int AddOrder(float fltHatsFee, float fltGstFee, int IntTotalNum, string strName, string strPhone, string strPostCode, string strAddress, string strEmail)
    //{
    //    SqlCommand myCmd = dbObj.GetCommandProc("proc_AddOrder");
        
    //    SqlParameter HatsFee = new SqlParameter("@HatsFee", SqlDbType.Float, 8);
    //    HatsFee.Value = fltHatsFee;
    //    myCmd.Parameters.Add(HatsFee);

    //    SqlParameter gstFee = new SqlParameter("@GstFee", SqlDbType.Float, 8);
    //    gstFee.Value = fltGstFee;
    //    myCmd.Parameters.Add(gstFee);

    //    SqlParameter amount = new SqlParameter("@TotalNum", SqlDbType.Int, 4);
    //    amount.Value = IntTotalNum;
    //    myCmd.Parameters.Add(amount);
       
    //    SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
    //    name.Value = strName;
    //    myCmd.Parameters.Add(name);
       
    //    SqlParameter phone = new SqlParameter("@Phone", SqlDbType.VarChar, 20);
    //    phone.Value = strPhone;
    //    myCmd.Parameters.Add(phone);
        
    //    SqlParameter postCode = new SqlParameter("@PostCode", SqlDbType.Char, 10);
    //    postCode.Value = strPostCode;
    //    myCmd.Parameters.Add(postCode);
        
    //    SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
    //    address.Value = strAddress;
    //    myCmd.Parameters.Add(address);
        
    //    SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar, 50);
    //    email.Value = strEmail;
    //    myCmd.Parameters.Add(email);
        
    //    SqlParameter orderID = myCmd.Parameters.Add("@OrderID", SqlDbType.Int, 4);
    //    orderID.Direction = ParameterDirection.Output;
    //    dbObj.ExecNonQuery(myCmd);
    //    return Convert.ToInt32(orderID.Value.ToString());
    //}

    public int AddOrder(float fltHatsFee, float fltGstFee, int IntTotalNum, string strName, string strPhone, string strPostCode, string strAddress, string strEmail, int IntUserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AddOrder");

        SqlParameter HatsFee = new SqlParameter("@HatsFee", SqlDbType.Float, 8);
        HatsFee.Value = fltHatsFee;
        myCmd.Parameters.Add(HatsFee);

        SqlParameter gstFee = new SqlParameter("@GstFee", SqlDbType.Float, 8);
        gstFee.Value = fltGstFee;
        myCmd.Parameters.Add(gstFee);

        SqlParameter amount = new SqlParameter("@TotalNum", SqlDbType.Int, 4);
        amount.Value = IntTotalNum;
        myCmd.Parameters.Add(amount);

        SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        name.Value = strName;
        myCmd.Parameters.Add(name);

        SqlParameter phone = new SqlParameter("@Phone", SqlDbType.VarChar, 20);
        phone.Value = strPhone;
        myCmd.Parameters.Add(phone);

        SqlParameter postCode = new SqlParameter("@PostCode", SqlDbType.Char, 10);
        postCode.Value = strPostCode;
        myCmd.Parameters.Add(postCode);

        SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        address.Value = strAddress;
        myCmd.Parameters.Add(address);

        SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar, 50);
        email.Value = strEmail;
        myCmd.Parameters.Add(email);

        SqlParameter userID = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
        userID.Value = IntUserID;
        myCmd.Parameters.Add(userID);

        SqlParameter orderID = myCmd.Parameters.Add("@OrderID", SqlDbType.Int, 4);
        orderID.Direction = ParameterDirection.Output;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(orderID.Value.ToString());
    }
    public void AddDetail(int IntProductID, int IntNum, int IntOrderID, float fltTotalPrice)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AddOrderDetail");
        
        SqlParameter productID = new SqlParameter("@ProductID", SqlDbType.Int, 4);
        productID.Value = IntProductID;
        myCmd.Parameters.Add(productID);
        
        SqlParameter num = new SqlParameter("@Num", SqlDbType.Int, 4);
        num.Value = IntNum;
        myCmd.Parameters.Add(num);
        
        SqlParameter orderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        orderID.Value = IntOrderID;
        myCmd.Parameters.Add(orderID);

        SqlParameter TotalPrice = new SqlParameter("@HatsFee", SqlDbType.Float, 8);
        TotalPrice.Value = fltTotalPrice;
        myCmd.Parameters.Add(TotalPrice);
        dbObj.ExecNonQuery(myCmd);
    }

    public string GetOrder(int IntOrderID)//done
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetOrder");

        SqlParameter orderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        orderID.Value = IntOrderID;
        myCmd.Parameters.Add(orderID);
        return dbObj.ExecScalar(myCmd).ToString();
    }

   
}