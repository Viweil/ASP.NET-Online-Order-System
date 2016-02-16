using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Category : System.Web.UI.UserControl
{
    HatClass gcObj = new HatClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gcObj.DLCategoryBind(this.dlCategory);

        }
    }
    protected void dlCategory_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            Response.Redirect("goodsList.aspx?id=" + e.CommandArgument);
        }
    }

    public string GetCategoryName(int IntCategoryID)
    {
        return gcObj.GetCategory(IntCategoryID);
    }

    protected void dlNewGoods_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "Default.aspx";
            Response.Redirect("~/showInfo.aspx?id=" + Convert.ToInt32(e.CommandArgument.ToString()));
        }

    }
}