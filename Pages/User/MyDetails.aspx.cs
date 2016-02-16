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

public partial class Pages_User_MyDetails : System.Web.UI.Page
{
    DBClass dbObj = new DBClass();
    CommonClass ccObj = new CommonClass();
    HatClass gcObj = new HatClass();
    UserClass ucObj = new UserClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserInfo();
            ddlOrderBind();
        }
    }


    public void GetUserInfo()
    {
        string strSql = "select * from UserInfo where UserID=" + Convert.ToInt32(Session["UserID"]);
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");
        this.lblFirstName.Text = dsTable.Rows[0]["FirstName"].ToString();
        this.lblLastName.Text = dsTable.Rows[0]["LastName"].ToString();
        this.lblUserName.Text = dsTable.Rows[0]["UserName"].ToString();
        this.lblPassword.Text = dsTable.Rows[0]["Password"].ToString();
        this.lblHome.Text = dsTable.Rows[0]["HomePhone"].ToString();
        this.lblWork.Text = dsTable.Rows[0]["WorkPhone"].ToString();
        this.lblMobile.Text = dsTable.Rows[0]["Mobile"].ToString();
        this.lblEmail.Text = dsTable.Rows[0]["Email"].ToString();
        ddlOrderBind();


    }

    public void ddlOrderBind()
    {
        string strSql = "select OrderID from UserInfo where UserID=" + Convert.ToInt32(Session["UserID"]);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbClass");
        if (dsTable != null && dsTable.Rows.Count > 0)
        {
            this.ddlOrder.DataSource = dsTable;
            this.ddlOrder.DataTextField = "OrderID";
            this.ddlOrder.DataValueField = "OrderID";
            this.ddlOrder.DataBind();
            if (ddlOrder.Items.Count > 0)
            {
                GetOrderInfo(ddlOrder.SelectedItem.Value);
            }
        }

    }

    public void GetOrderInfo(string orderID)
    {
        int orderid;
        if (!int.TryParse(orderID, out orderid))
        {
            return;
        }
        string strSql = "select * from [ProductOrder] where OrderID=" + orderID;
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");
        this.lblOrderNum.Text = dsTable.Rows[0]["OrderID"].ToString();
        this.lblOrderStatus.Text = dsTable.Rows[0]["IsSend"].ToString();
        this.lblOrderPrice.Text = Convert.ToDecimal(dsTable.Rows[0]["TotalPrice"]).ToString("C2");
        this.lblOrderDate.Text = dsTable.Rows[0]["OrderDate"].ToString();

    }

    //public void GetUserOrder()
    //{
    //    string strSql = "select * from ProductOrder where UserID=" + Convert.ToInt32(Session["UserID"]);
    //    SqlCommand myCmd = dbObj.GetCommandStr(strSql);
    //    DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");
    //    this.lblFirstName.Text = dsTable.Rows[0]["FirstName"].ToString();
    //    this.lblLastName.Text = dsTable.Rows[0]["LastName"].ToString();
    //    this.lblUserName.Text = dsTable.Rows[0]["UserName"].ToString();
    //    this.lblPassword.Text = dsTable.Rows[0]["Password"].ToString();
    //    this.lblHome.Text = dsTable.Rows[0]["HomePhone"].ToString();
    //    this.lblWork.Text = dsTable.Rows[0]["WorkPhone"].ToString();
    //    this.lblMobile.Text = dsTable.Rows[0]["Mobile"].ToString();
    //    this.lblEmail.Text = dsTable.Rows[0]["Email"].ToString();
    //}

    public string GetVarGF(string strGoodsFee)
    {
        return ccObj.VarStr(strGoodsFee, 2);
    }
    public string GetVarTP(string strTotalPrice)
    {
        return ccObj.VarStr(strTotalPrice, 2);
    }
    public string GetStatus(int IntOrderID)
    {
        string strSql = "select (case IsSend when '0' then 'waiting' when '1' then 'shipped' end ) as IsSend";
        strSql += "  from ProductOrder where OrderID=" + IntOrderID;
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbOI");
        return (dsTable.Rows[0][0].ToString());
    }

   

    protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetOrderInfo(ddlOrder.SelectedItem.Value);
    }

}