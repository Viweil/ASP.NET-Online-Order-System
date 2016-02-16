<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Pages_Admin_AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="../../Styles/Style2.css" />
</head>
<body>
 <form id="form1" runat="server">
        <div>
            <div id="crazyhats_body_wrapper">
                <div id="crazyhats_wrapper">
                    <div id="crazyhats_header">
                     <div class="cleaner"></div>
                    </div>
                     <div id="crazyhats_main">
                     <div id="content" class="float_r">
            <div id="slider-wrapper">
                <h2>
                   Admin Login
                </h2>
                <p>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label></p>
                <div class="content_half float_l ">
                    <span>Admin Name<label>*<asp:TextBox ID="txtAdminName" runat="server" Width="300px"></asp:TextBox></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtAdminName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </span>
                    <br />
                    <br />
                    <span>Password<label>*<asp:TextBox ID="txtAdminPwd" runat="server" TextMode="Password" Width="300px"></asp:TextBox></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtAdminPwd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </span><br />
                    <br />
                   
                </div>
                <div class="content_half float_r ">
                </div>
                <div class="cleaner h50"></div>
                <div>
                <table>
                <tr>
                <td style="width:150px;"><asp:Button ID="btnLogin" class="submit_btn" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                <td style="width:150px;"><asp:HyperLink ID="HomePage" runat="server" NavigateUrl="~/Default.aspx">Back to Crazy Hats</asp:HyperLink></td>
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
                    </div>
                </div>
            </div>
        </div>
</form>
</body>
</html>
