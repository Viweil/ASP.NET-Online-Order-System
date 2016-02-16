<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="CategoryAdd.aspx.cs" Inherits="Pages_Admin_CategoryAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">
    
    <div id="Div1">
                <h2>Add Category</h2>
                <div class="content_half float_l ">
                    <span>Category Name<label><asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox></label>
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
                <td style="width:150px;"><asp:Button ID="btnAdd" class="submit_btn" runat="server" Text="Save" OnClick="btnAdd_Click" /></td>
               </tr>
                </table>
                    
                    
                </div>
            </div>

</div>
</asp:Content>

