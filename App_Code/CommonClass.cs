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
/// Summary description for CommonClass
/// </summary>
public class CommonClass
{
	public CommonClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string MessageBox(string TxtMessage, string Url)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "');location='" + Url + "';</script>";
        return str;
    }
    public string MessageBox(string TxtMessage)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "')</script>";
        return str;
    }
    public string MessageBoxPage(string TxtMessage)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "');location='javascript:history.go(-1)';</script>";
        return str;
    }
   
    public string VarStr(string sString, int nLeng)
    {
        int index = sString.IndexOf(".");
        if (index == -1 || index + nLeng >= sString.Length)
            return sString;
        else
            return sString.Substring(0, (index + nLeng + 1));
    }


}