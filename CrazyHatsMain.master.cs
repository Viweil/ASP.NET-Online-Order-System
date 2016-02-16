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

public partial class CrazyHatsMain : System.Web.UI.MasterPage
{
    HatClass gcObj = new HatClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gcObj.DLCategoryBind(this.dlCategory);
            if (Session["UserID"] != null)
            {
                this.lnkLogin.Visible = false;
                this.lnkRegister.Visible = false;
                this.lnkLogout.Visible = true;
                this.lnkMyDetails.Visible = true;
                this.Label_Welcome.Text = "HELLO : " + Session["UserName"] + " !";
            }
            else
            {
                this.lnkLogin.Visible = true;
                this.lnkRegister.Visible = true;
                this.lnkLogout.Visible = false;
                this.lnkMyDetails.Visible = false;
                this.Label_Welcome.Text = "HELLO : GUEST !";
            }
        }
        
    }
    protected void dlCategory_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
           
            Response.Redirect("~/Pages/User/CategoryList.aspx?id=" + Convert.ToInt32(e.CommandArgument.ToString()));
          
        }
    }

    public string GetCategoryName(int IntCategoryID)
    {
        return gcObj.GetCategory(IntCategoryID);
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session["UserID"] = null;
        Session["UserName"] = null;
        this.lnkLogin.Visible = true;
        this.lnkRegister.Visible = true;
        this.lnkLogout.Visible = false;
        this.Label_Welcome.Text = "HELLO : GUEST !";
        Response.Redirect("~/Default.aspx");
    }
}
