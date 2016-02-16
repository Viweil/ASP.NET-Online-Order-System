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


public partial class Pages_Admin_CategoryAdd : System.Web.UI.Page
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
        if (this.txtName.Text == "")
        {
            Response.Write(ccObj.MessageBoxPage("Please type category name"));
        }
        else
        {
            string sqlStr = "select * from Category where CategoryName='" + this.txtName.Text.Trim() + "'";
            DataTable dsTable = dbObj.GetDataSetStr(sqlStr, "tbClass");
            if (dsTable.Rows.Count > 0)
            {
                Response.Write(ccObj.MessageBoxPage("This category has been already exist."));
            }
            else
            {
                string strAddSql = "Insert into Category(CategoryName) values ('" + this.txtName.Text.Trim() + "')";
                SqlCommand myCmd = dbObj.GetCommandStr(strAddSql);
                dbObj.ExecNonQuery(myCmd);
                Response.Write(ccObj.MessageBox("Successful!"));
                Response.Redirect("CategoryList.aspx");
            }
        }

    }
}