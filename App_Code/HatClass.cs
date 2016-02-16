using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for HatClass
/// </summary>
public class HatClass
{
    DBClass dbObj = new DBClass();
	public HatClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void dlBind(DataList dlName, DataTable dsTable)
    {
        if (dsTable != null)
        {
            dlName.DataSource = dsTable.DefaultView;
            dlName.DataKeyField = dsTable.Columns[0].ToString();
            dlName.DataBind();
        }
    }

    public void DLCategoryBind(DataList dlName)
    {
        string sqlStr = "select Top 20 * from Category";
        DataTable dsTable = dbObj.GetDataSetStr(sqlStr, "tbClass");
        dlBind(dlName, dsTable);
    }

    public void DLDisplayHat(int IntDisplay, DataList dlName, string TableName) //done
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_DisplayHat");
        
        SqlParameter Display = new SqlParameter("@Display", SqlDbType.Int, 4);
        Display.Value = IntDisplay;
        myCmd.Parameters.Add(Display);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, TableName);
        dlBind(dlName, dsTable);
    }

    public void DLNewHats(DataList dlName)//done
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_NewHats");
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGoods");
        dlBind(dlName, dsTable);
    }

    public string GetCategory(int IntCategoryID)//done
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetCategory");

        SqlParameter categoryID = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
        categoryID.Value = IntCategoryID;
        myCmd.Parameters.Add(categoryID);
        return dbObj.ExecScalar(myCmd).ToString();
    }

    public string GetPrice(int IntProductID)//done
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetPrice");

        SqlParameter productID = new SqlParameter("@ProductID", SqlDbType.Int, 4);
        productID.Value = IntProductID;
        myCmd.Parameters.Add(productID);
        return dbObj.ExecScalar(myCmd).ToString();
    }

    public string GetColour(int IntColourID)//done
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetColour");

        SqlParameter colourID = new SqlParameter("@ColourID", SqlDbType.Int, 4);
        colourID.Value = IntColourID;
        myCmd.Parameters.Add(colourID);
        return dbObj.ExecScalar(myCmd).ToString();
    }

    public DataTable search(string strKeyWord)//done
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_SearchBar");
        SqlParameter key = new SqlParameter("@keywords", SqlDbType.VarChar, 50);
        key.Value = strKeyWord;
        myCmd.Parameters.Add(key);
        
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbBI");
        return dsTable;
    }
}