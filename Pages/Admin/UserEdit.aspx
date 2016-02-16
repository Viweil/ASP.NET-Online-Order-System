<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="Pages_Admin_UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">
        <h2>Edit User Information</h2>
        <br />
        <div class="content_half float_l ">
            <h3>UserID: <asp:Label ID="lblUserID" runat="server" Text=""></asp:Label></h3><br /><br />
            <span>First Name:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtFirstName" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>Last Name:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtLastName" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>User Name:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>Email:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>Address:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtAddress" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>Mobile:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>Home Phone:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtHomePhone" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <span>Work Phone:</span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtWorkPhone" runat="server" Width="200px"></asp:TextBox></span>
            <br />
            <br />
            <asp:button id="btnUpdate" runat="server" class="submit_btn" Text="Update" OnClick="btnUpdate_Click"></asp:button>
            <br />
        </div>

    
</div>
</asp:Content>

