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

public partial class Pages_User_ProductDetails : System.Web.UI.Page
{
    DBClass dbObj = new DBClass();
    CommonClass ccObj = new CommonClass();
    HatClass gcObj = new HatClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetHatsInfo();
        }
    }
    public void GetHatsInfo()
    {
        string strSql = "select * from Products where ProductID=" + Convert.ToInt32(Request["id"].Trim());
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");
        this.lblName.Text = dsTable.Rows[0]["HatName"].ToString();
        this.lblPrice.Text = "$ " + dsTable.Rows[0]["Price"].ToString();
        this.lblDescription.Text = dsTable.Rows[0]["Description"].ToString();
        this.imgProduct.ImageUrl = dsTable.Rows[0]["Path"].ToString();
        this.lblCategory.Text = gcObj.GetCategory(Convert.ToInt32(dsTable.Rows[0]["CategoryID"].ToString()));
        this.lblColour.Text = gcObj.GetColour(Convert.ToInt32(dsTable.Rows[0]["ColourID"].ToString()));
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        string strUrl = Session["address"].ToString();
        Response.Redirect(strUrl);
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
            Response.Write("<script>alert('Sorry, you are not member, please register first.');location='Default.aspx'</script>");
            Response.End();
        }
    }

  
}