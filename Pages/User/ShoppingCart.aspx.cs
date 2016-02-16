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

public partial class Pages_User_ShoppingCart : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    string strSql;
    DataTable dtTable;
    Hashtable hashCar;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["flag"] != null && Request["flag"] == "clear")
            {
                Session["ShopCart"] = null;
            }

            ST_check_Login();
            if (Session["ShopCart"] == null)
            {
                this.labMessage.Text = "You haven't purchased yet!";
                this.labMessage.Visible = true;
                this.lnkbtnCheck.Visible = false;
                this.lnkbtnClear.Visible = false;
                this.lnkbtnContinue.Visible = false;
                this.lnkbtnUpdate.Visible = false;
                this.lblUpdate.Visible = false;
                this.lblTotalPrice.Visible = false;
                this.lblPrice.Visible = false;
                this.lblGST.Visible = false;
            }
            else
            {
                hashCar = (Hashtable)Session["ShopCart"];
                if (hashCar.Count == 0)
                {

                    this.labMessage.Text = "There's no item in your shopping cart.";
                    this.labMessage.Visible = true;
                    this.lnkbtnCheck.Visible = false;
                    this.lnkbtnClear.Visible = false;
                    this.lnkbtnContinue.Visible = false;
                    this.lnkbtnUpdate.Visible = false;
                    this.lblUpdate.Visible = false;
                    this.lblTotalPrice.Visible = false;
                    this.lblPrice.Visible = false;
                    this.lblGST.Visible = false;
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
                        i++;
                    }
                    this.labhatPrice.Text = "$ " + hatPrice.ToString();
                    this.labgstPrice.Text = "$ " + gstPrice.ToString();
                    this.labTotalPrice.Text = "$ " + sumPrice.ToString();
                    this.gvShoppingCart.DataSource = dtTable.DefaultView;
                    this.gvShoppingCart.DataKeyNames = new string[] { "ProductID" };
                    this.gvShoppingCart.DataBind();
                }
            }

        }

    }

    public void ST_check_Login()
    {
        if ((Session["Username"] == null))
        {
            Response.Write("<script>alert('Please login first.');location='Login.aspx'</script>");
            Response.End();
        }
    }

    protected void txtNum_TextChanged(object sender, EventArgs e)
    {
        hashCar = (Hashtable)Session["ShopCart"];
        foreach (GridViewRow gvr in this.gvShoppingCart.Rows)
        {
            TextBox otb = (TextBox)gvr.FindControl("txtNum");
            int count = Int32.Parse(otb.Text);
            string ProductID = gvr.Cells[1].Text;
            hashCar[ProductID] = count;
            Session["ShopCart"] = hashCar;
            bind();
        }
    }

    public void bind()
    {
        if (Session["ShopCart"] == null)
        {

            this.labMessage.Text = "You haven't purchase yet!";
            this.labMessage.Visible = true;
            this.lnkbtnCheck.Visible = false;
            this.lnkbtnClear.Visible = false;
            this.lnkbtnContinue.Visible = false;
            this.lnkbtnUpdate.Visible = false;
        }
        else
        {
            hashCar = (Hashtable)Session["ShopCart"];
            if (hashCar.Count == 0)
            {
                this.labMessage.Text = "There's no item in your shopping cart.";
                this.labMessage.Visible = true;
                this.lnkbtnCheck.Visible = false;
                this.lnkbtnClear.Visible = false;
                this.lnkbtnContinue.Visible = false;
                this.lnkbtnUpdate.Visible = false;
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
                float totalPrice = 0;
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
                    totalPrice += price * count;
                    i++;
                }
                this.labTotalPrice.Text = "Total Price：$" + totalPrice.ToString();
                this.gvShoppingCart.DataSource = dtTable.DefaultView;
                this.gvShoppingCart.DataKeyNames = new string[] { "ProductID" };
                this.gvShoppingCart.DataBind();
            }
        }
    }

    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        Session["ShopCart"] = null;
        Response.Redirect("~/Pages/User/ShoppingCart.aspx");
    }
    protected void lnkbtnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    protected void lnkbtnCheck_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/User/CheckOut.aspx");
    }

    protected void lnkbtnUpdate_Click(object sender, EventArgs e)
    {
        hashCar = (Hashtable)Session["ShopCart"];
        foreach (GridViewRow gvr in this.gvShoppingCart.Rows)
        {
            TextBox otb = (TextBox)gvr.FindControl("txtNum");
            int count = Int32.Parse(otb.Text);
            string ProductID = gvr.Cells[1].Text;
            hashCar[ProductID] = count;
        }
        Session["ShopCart"] = hashCar;
        Response.Redirect("~/Pages/User/ShoppingCart.aspx");
    }

    protected void lnkbtnDelete_Command(object sender, CommandEventArgs e)
    {
        hashCar = (Hashtable)Session["ShopCart"];

        hashCar.Remove(e.CommandArgument);
        Session["ShopCart"] = hashCar;
        Response.Redirect("~/Pages/User/ShoppingCart.aspx");
    }

    protected void gvShoppingCart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShoppingCart.PageIndex = e.NewPageIndex;
        bind();

    }

}