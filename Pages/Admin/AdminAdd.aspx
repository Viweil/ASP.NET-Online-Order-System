<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="Pages_Admin_AdminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content" class="float_r">
            <div id="slider-wrapper">
                <h2>Add Administrator</h2>
                <p><asp:Label ID="lblError" runat="server" Text=""></asp:Label></p>
                <p style="color:red">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="*  Plase type correct email address" 
                        ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </p>
                <div class="content_half float_l ">
                    <span>Admin Name<label>*<asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </span>
                    <br />
                    <br />
                    <span>Real Name<label>*<asp:TextBox ID="txtTrueName" runat="server" Width="300px"></asp:TextBox></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtTrueName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </span>
                    <br />
                    <br />
                    <span>Password<label>*<asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" Width="300px"></asp:TextBox></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassWord" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </span>
                    <br />
                    <br />
                    <span>Email<label>*<asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </span>
                    <br />
                    <br />
                   
                </div>
                <div class="content_half float_r ">
                </div>
                <div class="cleaner h50"></div>
                <div>
                <table>
                <tr>
                <td style="width:150px;"><asp:Button ID="btnSave" class="submit_btn" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                <td><asp:Button ID="btnCancel" class="submit_btn" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                </tr>
                </table>
                    
                    
                </div>
            </div>
            <div class="cleaner">
            </div>
        </div>
        <div class="cleaner">
        </div>
</asp:Content>

