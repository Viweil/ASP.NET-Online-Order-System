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
using System.EnterpriseServices;
using System.IO;
using System.Security.Policy;
using System.Web.DynamicData;

public partial class Pages_Admin_ProductAdd : System.Web.UI.Page
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

    protected void ddlPath_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.ImageMapPhoto.ImageUrl = ddlPath.SelectedItem.Value;// 此处也需要修改
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        ImageMapPhoto.ImageUrl = GetUpLoadImage(ful);
        if (lblMessage.Visible)
        {
            lblMessage.Style.Add("color", "red");
        }
    }
    
    private string GetUpLoadImage(FileUpload ful)
    {
        #region check image
        if (ful.PostedFile.ContentType.ToUpper().IndexOf("IMAGE") < -1)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select upload images";
            return "";
        }
        #endregion

        #region check image size
        System.Drawing.Image img = System.Drawing.Image.FromStream(ful.PostedFile.InputStream);
        int Width = img.Width;
        int Height = img.Height;
        if (Width > 700 || Height > 700 || ful.PostedFile.ContentLength > 1024 * 1024 * 2)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "The file is too large";
            return "";
        }
        #endregion
        
        #region check image type
        var flag = false;
        HttpPostedFile postedFile = ful.PostedFile;
        string fileName = Path.GetFileName(postedFile.FileName);
        string fileExtension = Path.GetExtension(fileName);
        String[] allowedExtensions = { ".bmp", ".jpg", ".gif", ".png" };
        for (int j = 0; j < allowedExtensions.Length; j++)
        {
            if (fileExtension == allowedExtensions[j])
            {
                flag = true;
                break;
            }
        }

        if (!flag)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Only images(.jpg, .png, .bmp and .gif) can be uploaded";
            return "";
        }
        #endregion
        
        this.ful.PostedFile.SaveAs(Server.MapPath("~/Images/Products/") + fileName);
        return Path.Combine("~/Images/Products/" + fileName);
    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ProductInfo info = new ProductInfo();
        info.CategoryID = Convert.ToInt32(this.ddlCategory.SelectedValue.ToString());
        info.HatName = this.txtName.Text.Trim();
        info.Quantity = Convert.ToInt32(this.txtQuantity.Text.Trim());
        info.ColourID = Convert.ToInt32(this.ddlColour.SelectedValue.ToString());
        info.SupplierID = Convert.ToInt32(this.ddlSupplier.SelectedValue.ToString());
        info.Price = decimal.Parse(this.txtPrice.Text.Trim());
        info.Path = ImageMapPhoto.ImageUrl;
        info.Description = this.txtDesc.Text.Trim();
        info.LoadDate = DateTime.Now;
        info.IsHot = false;
        AddProductInfo(info);
        ImageMapPhoto.ImageUrl = info.Path;

    }

    void AddProductInfo(ProductInfo info)
    {
        string strSql
             = @"insert into [products] 
                (CategoryID,HatName,Quantity,ColourID,SupplierID,Price,Path,Description,LoadDate)  
                values(@CategoryID,@HatName,@Quantity,@ColourID, @SupplierID,@Price,@Path,@Description,@LoadDate)";


        SqlParameter[] parmeters = new SqlParameter[]
        {
            new SqlParameter("@CategoryID",info.CategoryID),
            new SqlParameter("@HatName",info.HatName),
            new SqlParameter("@Quantity",info.Quantity),
            new SqlParameter("@ColourID",info.ColourID),
            new SqlParameter("@SupplierID",info.SupplierID),
            new SqlParameter("@Price",info.Price),
            new SqlParameter("@Path",info.Path),
            new SqlParameter("@Description",info.Description),
            new SqlParameter("@LoadDate",info.LoadDate),
        };
        SqlCommand myCmd = dbObj.GetCommandStr(strSql, parmeters);
        dbObj.ExecNonQuery(myCmd);
        Response.Write(ccObj.MessageBox("Successful！", "ProductList.aspx"));
    }
}



[Serializable]
class ProductInfo
{
    public int ProductID { get; set; }
    public string HatName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Path { get; set; }
    public int Quantity { get; set; }
    public int ColourID { get; set; }
    public int SupplierID { get; set; }
    public int CategoryID { get; set; }
    public bool IsHot { get; set; }
    public DateTime LoadDate { get; set; }
}