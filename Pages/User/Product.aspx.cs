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
using System.Collections;

public partial class Pages_User_Product : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    HatClass gcObj = new HatClass();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HotBind();
        }
    }

    protected void HotBind()
    {
        gcObj.DLDisplayHat(1, this.dlHot, "Hot");
    }

    protected void Product_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "chkDetail")
        {
            AddressBack(e);
        }
        else if (e.CommandName == "buy")
        {
            AddShopCart(e);
        }
    }

    public void AddressBack(DataListCommandEventArgs e)
    {
        Session["address"] = "";
        Session["address"] = "Default.aspx";
        Response.Redirect("~/Pages/User/ProductDetails.aspx?id=" + Convert.ToInt32(e.CommandArgument.ToString()));
    }

    public void AddShopCart(DataListCommandEventArgs e)
    {
        /*If login*/
        ST_check_Login();
        Hashtable hashCar;
        if (Session["ShopCart"] == null)
        {
            //if no shopping cart
            hashCar = new Hashtable();
            hashCar.Add(e.CommandArgument, 1);
            Session["ShopCart"] = hashCar;
        }
        else
        {
            //if has shopping cart
            hashCar = (Hashtable)Session["ShopCart"];//get hash table of cart
            if (hashCar.Contains(e.CommandArgument))//if this item in the cart, add 1
            {
                int count = Convert.ToInt32(hashCar[e.CommandArgument].ToString());//get the number of items
                hashCar[e.CommandArgument] = (count + 1);//add 1 item
            }
            else
                hashCar.Add(e.CommandArgument, 1);
        }
        Response.Redirect("~/Pages/User/ShoppingCart.aspx");
    }

    public void ST_check_Login()
    {

        if ((Session["UserName"] == null))
        {
            Response.Write("<script>alert('Sorry, please login first.');location='Login.aspx'</script>");
            Response.End();
            //Response.Redirect("~/Pages/User/Login.aspx");
        }
    }

  
}