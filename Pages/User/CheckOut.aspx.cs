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

public partial class Pages_User_CheckOut : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    OrderClass ocObj = new OrderClass();
    UserClass ucObj = new UserClass();
    DataTable dtTable;
    Hashtable hashCar;
    string strSql;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] == null)
            {
                //Response.Redirect("Default.aspx");
                Response.Write("<script lanuage=javascript>alert('Please login first');location='Login.aspx'</script>");
            }
            //if (Session["Username"] != null)
            else
            {
                DataTable dsTable = ucObj.GetUserInfo(Convert.ToInt32(Session["UserID"].ToString()));
                this.txtReciverName.Text = dsTable.Rows[0][1].ToString() + " " + dsTable.Rows[0][2].ToString();
                this.txtReceiverPhone.Text = dsTable.Rows[0][7].ToString();
                this.txtReceiverEmails.Text = dsTable.Rows[0][4].ToString();
                this.txtReceiverPostCode.Text = "";
                this.txtReceiverAddress.Text = dsTable.Rows[0][6].ToString();
            }
            if (Session["ShopCart"] == null)
            {
                this.labMessage.Text = "No items in your shopping cart！";
                this.btnConfirm.Visible = false;
            }
            else
            {
                hashCar = (Hashtable)Session["ShopCart"];
                if (hashCar.Count == 0)
                {

                    this.labMessage.Text = "No items in your shopping cart";
                    this.btnConfirm.Visible = false;
                }
                else
                {
                    dtTable = new DataTable();
                    DataColumn column1 = new DataColumn("No");
                    DataColumn column2 = new DataColumn("ProductID");
                    DataColumn column3 = new DataColumn("HatName");
                    DataColumn column4 = new DataColumn("Num");
                    DataColumn column5 = new DataColumn("Price");
                    DataColumn column6 = new DataColumn("TotalPrice");
                    dtTable.Columns.Add(column1);
                    dtTable.Columns.Add(column2);
                    dtTable.Columns.Add(column3);
                    dtTable.Columns.Add(column4);
                    dtTable.Columns.Add(column5);
                    dtTable.Columns.Add(column6);
                    DataRow row;

                    foreach (object key in hashCar.Keys)
                    {
                        row = dtTable.NewRow();
                        row["ProductID"] = key.ToString();
                        row["Num"] = hashCar[key].ToString();
                        dtTable.Rows.Add(row);
                    }

                    DataTable dstable;
                    int i = 1;
                    float price;
                    int count;
                    float hatPrice = 0;
                    float gstPrice = 0;
                    float gst = 0.15f;
                    float sumPrice = 0;
                    int totalNum = 0;
                    foreach (DataRow drRow in dtTable.Rows)
                    {
                        strSql = "select HatName,Price from [Products] where ProductID=" + Convert.ToInt32(drRow["ProductID"].ToString());
                        dstable = dbObj.GetDataSetStr(strSql, "tbGI");
                        drRow["No"] = i;
                        drRow["HatName"] = dstable.Rows[0][0].ToString();
                        drRow["Price"] = (dstable.Rows[0][1].ToString());
                        price = float.Parse(dstable.Rows[0][1].ToString());
                        count = Int32.Parse(drRow["Num"].ToString());
                        drRow["TotalPrice"] = price * count;
                        hatPrice += price * count;
                        gstPrice += hatPrice * gst;
                        sumPrice += hatPrice + gstPrice;
                        totalNum += count;
                        i++;
                    }
                    this.labhatPrice.Text = hatPrice.ToString();
                    this.labgstPrice.Text = gstPrice.ToString();
                    this.labTotalPrice.Text = sumPrice.ToString();
                    this.labTotalNum.Text = totalNum.ToString();
                    this.gvShoppingCart.DataSource = dtTable.DefaultView;
                    this.gvShoppingCart.DataKeyNames = new string[] { "ProductID" };
                    this.gvShoppingCart.DataBind();
                }
            }
        }

    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string strName = this.txtReciverName.Text.Trim();
            string strPhone = this.txtReceiverPhone.Text.Trim();
            string strEmail = this.txtReceiverEmails.Text.Trim();
            string strPostCode = this.txtReceiverPostCode.Text.Trim();
            string strAddress = this.txtReceiverAddress.Text.Trim();
            int IntTotalNum = int.Parse(this.labTotalNum.Text);
            // float fltTotalPrice = int.Parse(this.labTotalPrice.Text);
            float fltGstFee = float.Parse(this.labgstPrice.Text);
            float flthatPrice = float.Parse(this.labhatPrice.Text);
            int IntUserID = Convert.ToInt32(Session["UserID"]);

            int IntOrderID = ocObj.AddOrder(float.Parse(this.labhatPrice.Text), float.Parse(this.labgstPrice.Text), IntTotalNum, strName, strPhone, strPostCode, strAddress, strEmail, IntUserID);
            int IntProductID;
            int IntNum;
            float fltTotalPrice; 

            foreach (GridViewRow gvr in this.gvShoppingCart.Rows)
            {
                IntProductID = int.Parse(gvr.Cells[1].Text);
                IntNum = int.Parse(gvr.Cells[3].Text);
                fltTotalPrice = float.Parse(gvr.Cells[5].Text);
                ocObj.AddDetail(IntProductID, IntNum, IntOrderID, fltTotalPrice);
            }
            foreach (GridViewRow gvr in this.gvShoppingCart.Rows)
            {
                ucObj.ModifyUserOrder(IntOrderID, IntUserID);
            }
            Session["ShopCart"] = null;
            Response.Redirect("~/Pages/User/MyDetails.aspx");


        }
    }
  
}