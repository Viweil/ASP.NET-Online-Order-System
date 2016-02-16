<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="SupplierList.aspx.cs" Inherits="Pages_Admin_SupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">
    <div id="slider-wrapper">
    <h2>Supplier List</h2>
    <br />
    <%--<table width="450" align="center">--%>
    <asp:GridView ID="gvSupplierList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="5"  Width="100%" 
							HeaderStyle-CssClass="summary-title" OnPageIndexChanging="gvSupplierList_PageIndexChanging" 
                            OnRowDeleting="gvSupplierList_RowDeleting" HorizontalAlign="Center" 
							BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                            BorderWidth="1px" GridLines="None" ForeColor="Black" >
	    <HeaderStyle Font-Bold="True"  Font-Size =Small BackColor="Tan" CssClass="summary-title" ></HeaderStyle>
        <Columns>
            <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" >
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" >
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField> 
            <asp:BoundField DataField="Mobile" HeaderText="Contact Number" >
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" >
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField> 
            <asp:CommandField ShowDeleteButton="True" >
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
   <%-- </table>--%>
     </div>
</div>
</asp:Content>

