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

public partial class Pages_Admin_ProductList : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    HatClass gcObj = new HatClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["search"] = null;
            gvBind();
        }
    }
    
    public string GetCategoryName(int IntCategoryID)
    {
        string strCategoryName = gcObj.GetCategory(IntCategoryID);
        return strCategoryName;
    }

    public String GetPrice(string strPrice)
    {
        return ccObj.VarStr(strPrice,2);
    }

    public String GetImage(string strImage)
    {
        return ccObj.VarStr(strImage, 2);
    }
   
    public void gvBind()
    {
        string strSql = "select * from Products";
        
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");
        this.gvGoodsInfo.DataSource = dsTable.DefaultView;
        this.gvGoodsInfo.DataKeyNames = new string[] { "ProductID" };
        this.gvGoodsInfo.DataBind();
    }
    
    public void gvSearchBind()
    {
        DataTable dsTable = gcObj.search(this.txtKey.Text.Trim());
        this.gvGoodsInfo.DataSource = dsTable.DefaultView;
        this.gvGoodsInfo.DataKeyNames = new string[] { "ProductID" };
        this.gvGoodsInfo.DataBind();
    }

    protected void gvGoodsInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGoodsInfo.PageIndex = e.NewPageIndex;
        if (ViewState["search"] != null)
        {
            gvSearchBind();
        }
        else
        {
            gvBind();
        }
    }

    protected void gvGoodsInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int IntProductID = Convert.ToInt32(gvGoodsInfo.DataKeys[e.RowIndex].Value); 
        string strSql = "select count(*) from OrderDetail where ProductID=" + IntProductID;
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        
        if (Convert.ToInt32(dbObj.ExecScalar(myCmd)) > 0)
        {
            Response.Write(ccObj.MessageBox("You can't delete this product since is using now."));
        }
        else
        {
            string strDelSql = "delete from Products where ProductID=" + IntProductID;
            SqlCommand myDelCmd = dbObj.GetCommandStr(strDelSql);
            dbObj.ExecNonQuery(myDelCmd);
            
            if (ViewState["search"] != null)
            {
                gvSearchBind();
            }
            else
            {
                gvBind();
            }

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["search"] = 1;
        gvSearchBind();
    }
}