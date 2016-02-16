<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true" CodeFile="MyDetails.aspx.cs" Inherits="Pages_User_MyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="float_r">
        <h2>My Details</h2>
        <table style="width: 200px; border: 1px">
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">First Name:</font></td>
                <td nowrap="nowrap" style="text-align: left;">
                    <asp:Label ID="lblFirstName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Last Name:</font></td>
                <td nowrap="nowrap" style="text-align: left;">
                    <asp:Label ID="lblLastName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">User Name:</font></td>
                <td nowrap="nowrap" style="text-align: left;">
                    <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Password:</font></td>
                <td nowrap="nowrap" style="text-align: left;">
                    <asp:Label ID="lblPassword" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Home Phone:</font></td>
                <td nowrap="nowrap" style="text-align: left;">
                    <asp:Label ID="lblHome" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Work Phone:</font></td>
                <td nowrap="nowrap" style="text-align: left;">
                    <asp:Label ID="lblWork" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Mobile Phone:</font></td>
                <td nowrap="nowrap" style="text-align: left;">
                    <asp:Label ID="lblMobile" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">My Email:</font></td>
                <td nowrap="nowrap" style="text-align: left;">
                    <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
            </tr>
        </table>

        <h2>My Orders</h2>
        <table style="width: 200px; border: 1px">
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Order Number:</font>
                    <asp:DropDownList ID="ddlOrder" runat="server" Width="150px"></asp:DropDownList></td>
               
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Order Number:</font>&nbsp;&nbsp;<asp:Label ID="lblOrderNum" runat="server"></asp:Label></td>
               
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Order Status:</font>&nbsp;&nbsp;<asp:Label ID="lblOrderStatus" runat="server"></asp:Label></td>
               
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Total Price:</font>&nbsp;&nbsp;<asp:Label ID="lblOrderPrice" runat="server"></asp:Label></td>
               
            </tr>
            <tr>
                <td nowrap="nowrap" style="text-align: left;"><font style="font-weight: bold;">Order Date:</font>&nbsp;&nbsp;<asp:Label ID="lblOrderDate" runat="server"></asp:Label></td>
             
            </tr>
        </table>


    </div>
</asp:Content>

