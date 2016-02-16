<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="Pages_Error_ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">        	
        <h2>Sorry, an error has occurred. Please contact our system administrator.</h2>
        <p style="width:600px;line-height:20px; text-align:justify">
        The following is the error message:<%=Request.QueryString["ErrorMessage"] %>
        </p>
</div>
</asp:Content>

