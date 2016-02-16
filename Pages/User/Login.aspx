<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_User_Login" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content" class="float_r">
            <div id="slider-wrapper">
                <h2>
                    Login
                </h2>
                <p style="color:Red;">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label></p>
                <div class="content_half float_l ">
                    <span>User Name<label>*<asp:TextBox ID="TxtUserName" runat="server" Width="300px"></asp:TextBox></label></span>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtUserName" ErrorMessage="* Please type user name" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span>Password<label>*<asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" Width="300px"></asp:TextBox></label></span>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TxtPassword" ErrorMessage="* Please type password" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
                <div class="content_half float_r ">
                </div>
                <div class="cleaner h50"></div>
                <div>
                <table>
                <tr>
                <td style="width:150px;"><asp:Button ID="btnLogin" class="submit_btn" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                </tr>
                </table>
                    
                    
                </div>
            </div>
            <div class="cleaner">
            </div>
        </div>
        <!-- END of crazyhats_main -->
        <div class="cleaner">
        </div>
</asp:Content>

