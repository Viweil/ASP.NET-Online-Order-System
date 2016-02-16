<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ProductEdit.aspx.cs" Inherits="Pages_Admin_ProductEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">
    
        <h2>Edit Product</h2>
        <br />
        <div class="content_half float_l ">
            <span>Product Name:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>Category:</span>&nbsp;&nbsp;
            <span><asp:DropDownList id="ddlCategory" runat="server" AutoPostBack="True"></asp:DropDownList></span>
            <br />
            <br />
            <span>Product Price:</span>&nbsp;&nbsp;
            <asp:TextBox ID="txtPrice" runat="server" Width="70px"></asp:TextBox>
            <br />
            <br />
            <span>Product Colour:</span>&nbsp;&nbsp;
            <asp:DropDownList id="ddlColour" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />
            <br />
            <span>Quantity:</span>&nbsp;&nbsp;
            <asp:TextBox ID="txtQuantity" runat="server" Width="50px"></asp:TextBox>
            <br />
            <br />
            <span>Supplier:</span>&nbsp;&nbsp;
            <asp:DropDownList id="ddlSupplier" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />
            <br />
            <span>Image:</span>&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPath" runat="server" OnSelectedIndexChanged="ddlPath_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList> 
            <br />
            <br />
            <p style="text-align:center"><asp:ImageMap ID="ImageMapPhoto" runat="server" Width="100" Height="70"></asp:ImageMap></p>
            <br />
            <br />
            <span>Description:</span>&nbsp;&nbsp;
            <asp:textbox id="txtDesc" runat="server" Width="307px" Height="89px" TextMode="MultiLine"></asp:textbox>
            <br />
            <br />
            <asp:button id="btnUpdate" runat="server" class="submit_btn" Text="Update" OnClick="btnUpdate_Click"></asp:button>
            <br />
        </div>

    
</div>

</asp:Content>

