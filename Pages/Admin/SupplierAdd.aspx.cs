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

public partial class Pages_Admin_SupplierAdd : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       
            string sqlStr = "select * from Supplier where SupplierName='" + this.txtName.Text.Trim() + "'";
            DataTable dsTable = dbObj.GetDataSetStr(sqlStr, "tbSupplier");
            if (dsTable.Rows.Count > 0)
            {
                Response.Write(ccObj.MessageBoxPage("This supplier has been already exist."));
            }
            else
            {
                string strAddSql = "Insert into Supplier(SupplierName,HomePhone,WorkPhone,Mobile,Email) values ('" + this.txtName.Text.Trim() + "','" + this.txtHomePhone.Text.Trim() + "','" + this.txtWorkPhone.Text.Trim() + "','" + this.txtMobile.Text.Trim() + "','" + this.txtEmail.Text.Trim() + "')";
                SqlCommand myCmd = dbObj.GetCommandStr(strAddSql);
                dbObj.ExecNonQuery(myCmd);
                Response.Write(ccObj.MessageBox("Successful!"));
                Response.Redirect("SupplierList.aspx");
            }

    }
}