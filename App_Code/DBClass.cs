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

/// <summary>
/// Summary description for DBClass
/// </summary>
public class DBClass
{
	public DBClass()
	{
		
	}

    public SqlConnection GetConnection()
    {
        string myStr = ConfigurationManager.AppSettings["DBCS"].ToString();
        SqlConnection myConn = new SqlConnection(myStr);
        return myConn;
    }

    public string ExecScalar(SqlCommand myCmd)
    {
        string strSql;
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open(); 
            }
            
            strSql = Convert.ToString(myCmd.ExecuteScalar());
            return strSql;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();
            }
        }
    }

    public void ExecNonQuery(SqlCommand myCmd)
    {
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close(); 
            }
        }
    }

    public DataTable GetDataSet(SqlCommand myCmd, string TableName)
    {
        SqlDataAdapter adapt;
        DataSet ds = new DataSet();
        try
        {
            if (myCmd.Connection.State != ConnectionState.Open)
            {
                myCmd.Connection.Open();
            }
            adapt = new SqlDataAdapter(myCmd);
            adapt.Fill(ds, TableName);
            return ds.Tables[TableName];

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);

        }
        finally
        {
            if (myCmd.Connection.State == ConnectionState.Open)
            {
                myCmd.Connection.Close();

            }
        }

    }

    public SqlCommand GetCommandProc(string strProcName)
    {
        SqlConnection myConn = GetConnection();
        SqlCommand myCmd = new SqlCommand();
        myCmd.Connection = myConn;
        myCmd.CommandText = strProcName;
        myCmd.CommandType = CommandType.StoredProcedure;
        return myCmd;
    }

    //public SqlCommand GetCommandStr(string strSql)
    //{
    //    SqlConnection myConn = GetConnection();
    //    SqlCommand myCmd = new SqlCommand();
    //    myCmd.Connection = myConn;
    //    myCmd.CommandText = strSql;
    //    myCmd.CommandType = CommandType.Text;
    //    return myCmd;
    //}

    public SqlCommand GetCommandStr(string strSql)
    {
        return GetCommandStr(strSql, null);
    }
    public SqlCommand GetCommandStr(string strSql, params SqlParameter[] sqlParameters)
    {
        SqlConnection myConn = GetConnection();
        SqlCommand myCmd = new SqlCommand();
        if (sqlParameters != null && sqlParameters.Length > 0)
        {
            myCmd.Parameters.AddRange(sqlParameters);
        }
        myCmd.Connection = myConn;
        myCmd.CommandText = strSql;
        myCmd.CommandType = CommandType.Text;
        return myCmd;
    }

    public DataTable GetDataSetStr(string sqlStr, string TableName)
    {
        SqlConnection myConn = GetConnection();
        myConn.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapt = new SqlDataAdapter(sqlStr, myConn);
        adapt.Fill(ds, TableName);
        myConn.Close();
        return ds.Tables[TableName];
    }

    
}