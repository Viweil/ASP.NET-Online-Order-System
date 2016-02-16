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

public partial class Pages_User_CategoryList : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    HatClass gcObj = new HatClass();
    DBClass dbObj = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dlBind();
            displayTitle();
        }
    }

    public void dlBind()
    {

        dlBindPage(Convert.ToInt32(Request["id"].ToString()));
        
    }

    public void displayTitle()
    {

        string strCategoryName = gcObj.GetCategory(Convert.ToInt32(Request["id"].ToString()));
        this.lblTitle.Text = strCategoryName;


    }

    public void dlBindPage(int IntCategory)
    {

        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetCategoryList");
       
        SqlParameter Category = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
        Category.Value = IntCategory;
        myCmd.Parameters.Add(Category);
        dbObj.ExecNonQuery(myCmd);

        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGI");
        int curpage = Convert.ToInt32(this.labPage.Text);
        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = dsTable.DefaultView;
        ps.AllowPaging = true; 
        ps.PageSize = 15; 
        ps.CurrentPageIndex = curpage - 1; 
        this.lnkbtnUp.Enabled = true;
        this.lnkbtnNext.Enabled = true;
        this.lnkbtnBack.Enabled = true;
        this.lnkbtnOne.Enabled = true;
        if (curpage == 1)
        {
            this.lnkbtnOne.Enabled = false;
            this.lnkbtnUp.Enabled = false;
        }
        if (curpage == ps.PageCount)
        {
            this.lnkbtnNext.Enabled = false;
            this.lnkbtnBack.Enabled = false;
        }
        this.labBackPage.Text = Convert.ToString(ps.PageCount);
        this.dlCategory.DataSource = ps;
        this.dlCategory.DataKeyField = "ProductID";
        this.dlCategory.DataBind();

    }

    protected void lnkbtnOne_Click(object sender, EventArgs e)
    {
        this.labPage.Text = "1";
        this.dlBind();
    }
    protected void lnkbtnUp_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
        this.dlBind();
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
        this.dlBind();
    }
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        this.labPage.Text = this.labBackPage.Text;
        this.dlBind();
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
        //if (Session["UserName"] == null)
        //{
        //    Response.Redirect("Default.aspx");
        //}
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
        }
    }

}