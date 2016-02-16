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

public partial class Pages_Admin_ProductEdit : System.Web.UI.Page
{
    DBClass dbObj = new DBClass();
    CommonClass ccObj = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCategoryBind();
            ddlColourBind();
            ddlSupplierBind();
            ImageBind();
            GetGoodsInfo();
        }
    }
    public void ddlCategoryBind()
    {
        string strSql = "select * from Category";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbClass");
        this.ddlCategory.DataSource = dsTable.DefaultView;
        this.ddlCategory.DataTextField = dsTable.Columns[1].ToString();
        this.ddlCategory.DataValueField = dsTable.Columns[0].ToString();
        this.ddlCategory.DataBind();
    }

    public void ddlColourBind()
    {
        string strSql = "select * from Colour";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbColour");
        this.ddlColour.DataSource = dsTable.DefaultView;
        this.ddlColour.DataTextField = dsTable.Columns[1].ToString();
        this.ddlColour.DataValueField = dsTable.Columns[0].ToString();
        this.ddlColour.DataBind();
    }

    public void ddlSupplierBind()
    {
        string strSql = "select * from Supplier";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbSupplier");
        this.ddlSupplier.DataSource = dsTable.DefaultView;
        this.ddlSupplier.DataTextField = dsTable.Columns[1].ToString();
        this.ddlSupplier.DataValueField = dsTable.Columns[0].ToString();
        this.ddlSupplier.DataBind();
    }

    public void ImageBind()
    {
        string strSql = "select * from Products where ProductID= '" + Convert.ToInt32(Request["ProductID"].Trim()) + "'";
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbImage");
        this.ddlPath.DataSource = dsTable.DefaultView;
        this.ddlPath.DataValueField = dsTable.Columns[4].ToString();
        this.ddlPath.DataBind();
        ddlPath.SelectedIndex = 0;
    }

    public void GetGoodsInfo()
    {
        string strSql = "select * from Products where ProductID= '" + Convert.ToInt32(Request["ProductID"].Trim()) + "'";
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");
        this.ddlCategory.SelectedValue = dsTable.Rows[0]["CategoryID"].ToString();
        this.txtName.Text = dsTable.Rows[0]["HatName"].ToString();
        this.txtQuantity.Text = dsTable.Rows[0]["Quantity"].ToString();
        this.ddlColour.SelectedValue = dsTable.Rows[0]["ColourID"].ToString();
        this.ddlSupplier.SelectedValue = dsTable.Rows[0]["SupplierID"].ToString();
        this.txtPrice.Text = dsTable.Rows[0]["Price"].ToString();
        this.ddlPath.SelectedValue = dsTable.Rows[0]["Path"].ToString();
        this.ImageMapPhoto.ImageUrl = ddlPath.SelectedItem.Value;
        this.txtDesc.Text = dsTable.Rows[0]["Description"].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int IntCategoryID = Convert.ToInt32(this.ddlCategory.SelectedValue.ToString());
        string strHatName = this.txtName.Text.Trim();
        int IntQuantity = Convert.ToInt32(this.txtQuantity.Text.Trim());
        int IntColourID = Convert.ToInt32(this.ddlColour.SelectedValue.ToString());
        int IntSupplierID = Convert.ToInt32(this.ddlSupplier.SelectedValue.ToString());
        float fltPrice = float.Parse(this.txtPrice.Text.Trim());
        string strPath = this.ddlPath.SelectedValue.ToString();
        string strDesc = this.txtDesc.Text.Trim();

        

        string strSql
            = @"update [products] set CategoryID=@CategoryID,HatName=@HatName,Quantity=@Quantity,ColourID=@ColourID,
                          SupplierID=@SupplierID,Price=@Price,Path=@Path,Description=@Description,LoadDate=@LoadDate where ProductID=@ProductID";
        SqlParameter[] parmeters = new SqlParameter[]
        {
            new SqlParameter("@CategoryID",IntCategoryID),
            new SqlParameter("@HatName",strHatName),
            new SqlParameter("@Quantity",IntQuantity),
            new SqlParameter("@ColourID",IntColourID),
            new SqlParameter("@SupplierID",IntSupplierID),
            new SqlParameter("@Price",fltPrice),
            new SqlParameter("@Path",strPath),
            new SqlParameter("@Description",strDesc),
            new SqlParameter("@LoadDate",DateTime.Now),
            new SqlParameter("@ProductID",Request["ProductID"].Trim()),
        };
        SqlCommand myCmd = dbObj.GetCommandStr(strSql, parmeters);

        dbObj.ExecNonQuery(myCmd);
        Response.Write(ccObj.MessageBox("Successful！", "ProductList.aspx"));
    }
    protected void ddlPath_SelectedIndexChanged(object sender, EventArgs e)
    {
        ImageMapPhoto.ImageUrl = ddlPath.SelectedItem.Value;
    }
}