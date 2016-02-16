<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="Pages_Admin_ProductAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content" class="float_r">

        <h2>Edit Product</h2>
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

        <div class="content_half float_l ">
            <span>Product Name:</span>&nbsp;&nbsp;
            <span>
                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>Category:</span>&nbsp;&nbsp;
            <span>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True"></asp:DropDownList></span>
            <br />
            <br />
            <span>Product Price:</span>&nbsp;&nbsp;
            <asp:TextBox ID="txtPrice" runat="server" Width="70px"></asp:TextBox>
            <br />
            <br />
            <span>Product Colour:</span>&nbsp;&nbsp;
            <asp:DropDownList ID="ddlColour" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />
            <br />
            <span>Quantity:</span>&nbsp;&nbsp;
            <asp:TextBox ID="txtQuantity" runat="server" Width="50px"></asp:TextBox>
            <br />
            <br />
            <span>Supplier:</span>&nbsp;&nbsp;
            <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />
            <br />
            <span>Image:</span>&nbsp;&nbsp;
            <%--<asp:DropDownList ID="ddlPath" runat="server" OnSelectedIndexChanged="ddlPath_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList> --%>
            <asp:FileUpload ID="ful" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Upload"
                OnClick="btnUpload_Click" />
            <br />
            <br />
            <p style="text-align: center">
                <asp:ImageMap ID="ImageMapPhoto" runat="server" Width="100" Height="70"></asp:ImageMap>
            </p>
            <br />
            <br />
            <span>Description:</span>&nbsp;&nbsp;
            <asp:TextBox ID="txtDesc" runat="server" Width="307px" Height="89px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnUpdate" runat="server" class="submit_btn" Text="SAVE" OnClick="btnUpdate_Click" ></asp:Button>
            <br />
        </div>


    </div>
    <div class="cleaner"></div>
</asp:Content>

