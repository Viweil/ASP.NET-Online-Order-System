﻿using System;
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

public partial class Pages_Admin_AdminList : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    DBClass dbObj = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvAdminBind();
        }
    }

    public void gvAdminBind()
    {
        string sqlStr = "select * from Admin";
        DataTable dsTable = dbObj.GetDataSetStr(sqlStr, "tbAdmin");
        this.gvAdminList.DataSource = dsTable.DefaultView;
        this.gvAdminList.DataKeyNames = new string[] { "AdminID" };
        this.gvAdminList.DataBind();
    }

    protected void gvAdminList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAdminList.PageIndex = e.NewPageIndex;
        gvAdminBind();
    }

    protected void gvAdminList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int IntID = Convert.ToInt32(gvAdminList.DataKeys[e.RowIndex].Value.ToString());

        if (Session["AdminID"] == IntID.ToString())
        {
            Response.Write(ccObj.MessageBox("You can't delete this admin since is using now ."));
            
        }
        else
        {
            string sqlDelStr = "delete from Admin where AdminID=" + IntID;
            SqlCommand myDelCmd = dbObj.GetCommandStr(sqlDelStr);
            dbObj.ExecNonQuery(myDelCmd);
            gvAdminBind();

        }

    }
}