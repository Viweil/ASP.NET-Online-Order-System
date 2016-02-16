<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="SupplierAdd.aspx.cs" Inherits="Pages_Admin_SupplierAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">
   
        <h2>Add Supplier</h2>
        <div class="content_half float_l ">
            <p style="color:red">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TxtEmail" ErrorMessage="*  Plase type correct email address" 
                    ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </p>
            <span>Supplier Name<label>*</label></span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox></label>
            </span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                   
            <br />
            <br />
            <span>Mobile<label>*</label></span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtMobile" runat="server" Width="300px"></asp:TextBox></label>
            </span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtMobile" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <span>Work Phone<label><asp:TextBox ID="txtWorkPhone" runat="server" Width="300px"></asp:TextBox></label>
            </span>
            <br />
            <br />      
            <span>Home Phone<label><asp:TextBox ID="txtHomePhone" runat="server" Width="300px"></asp:TextBox></label>
            </span>
            <br />
            <br />  
            <span>Email<label>*</label></span>&nbsp;&nbsp;
            <span><asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox></label>
            </span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br /> 
        </div>
        <div class="content_half float_r ">
        </div>
        <div class="cleaner h50"></div>
        <div>
        <table>
        <tr>
        <td style="width:150px;"><asp:Button ID="btnAdd" class="submit_btn" runat="server" Text="Save" OnClick="btnAdd_Click" /></td>
        </tr>
        </table>
        </div>

</div>
</asp:Content>

