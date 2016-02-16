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

public partial class Pages_Admin_OrderList : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    OrderClass ocObj = new OrderClass();

    ProductOrder_BLL productOrderBll = new ProductOrder_BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string flag = Request["ship"];
            if (flag != null && flag == "yes") // Modify order status
            {
                UpdateByOrderID(Request["OrderID"]);
            }

            ST_check_Login();
            pageBind();
        }
    }

    private void UpdateByOrderID(string orderId)
    {
        ProductOrderInfo info = new ProductOrderInfo();
        info.OrderID = Convert.ToInt32(orderId);
        productOrderBll.UpdateInfoByOrderId(info);
        pageBind();
    }

    public void ST_check_Login()
    {

        if ((Session["AdminName"] == null))
        {
            Response.Write("<script>alert('Sorry, you are not administrator.');location='../../Default.aspx'</script>");
            Response.End();
        }
    }

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

    string strSql;
    public void pageBind()
    {
        strSql = "select * from ProductOrder where ";

        string strOL = Request["OrderList"] == null ? "01" : Request["OrderList"];
        switch (strOL)
        {
            case "01":
                strSql += "IsSend=0";
                gvOrderList.Columns[8].Visible = false;
                break;
            case "02":
                strSql += "IsSend=1";
                gvOrderList.Columns[7].Visible = false;
                break;
            default:
                break;
        }
        strSql += "  order by OrderDate Desc";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbOI");
        this.gvOrderList.DataSource = dsTable.DefaultView;
        this.gvOrderList.DataKeyNames = new string[] { "OrderID" };
        this.gvOrderList.DataBind();
    }

    protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrderList.PageIndex = e.NewPageIndex;
        gvBind();

    }

    public void gvBind()
    {
        string strSql = "select * from ProductOrder";
        DataTable dbTable = dbObj.GetDataSetStr(strSql, "tbClass");
        this.gvOrderList.DataSource = dbTable.DefaultView;
        this.gvOrderList.DataKeyNames = new string[] { "OrderID" };
        this.gvOrderList.DataBind();
    }

    protected void gvOrderList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


        string strDetailSql = "delete from OrderDetail where OrderID=" + Convert.ToInt32(gvOrderList.DataKeys[e.RowIndex].Value);
        SqlCommand myDetCmd = dbObj.GetCommandStr(strDetailSql);
        dbObj.ExecNonQuery(myDetCmd);

        string strUserSql = "delete from UserInfo where OrderID=" + Convert.ToInt32(gvOrderList.DataKeys[e.RowIndex].Value);
        SqlCommand myUserCmd = dbObj.GetCommandStr(strUserSql);
        dbObj.ExecNonQuery(myUserCmd);

        string strDelSql = "delete from ProductOrder where OrderID=" + Convert.ToInt32(gvOrderList.DataKeys[e.RowIndex].Value);
        SqlCommand myDelCmd = dbObj.GetCommandStr(strDelSql);
        dbObj.ExecNonQuery(myDelCmd);

        
        Response.Redirect("OrderList.aspx");


    }
}