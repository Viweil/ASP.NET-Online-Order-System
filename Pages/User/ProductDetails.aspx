<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="Pages_User_ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div id="content" class="float_r">
            <h1>
                Product Detail
            </h1>
                <div class="content_half float_l">
                    <asp:Image ID="imgProduct" runat="server"/>
                </div>
                <div class="content_half float_r">
                    <table>
                        <tr>
                            <td colspan="2">
                                <h2>
                                    <asp:Label ID="lblName" runat="server"></asp:Label></h2>
                                <hr />
                            </td>

                        </tr>
                        <tr>
                            <td>Price:</td>
                            <td>
                                <asp:Label ID="lblPrice" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Color:</td>
                            <td>
                                <asp:Label ID="lblColour" runat="server"></asp:Label></td>
                        </tr>
                         <tr>
                            <td>Category:</td>
                            <td>
                                <asp:Label ID="lblCategory" runat="server"></asp:Label></td>
                        </tr>
                       
                    </table>
                    <div class="cleaner h20"></div>
                  <asp:ImageButton ID="Back" runat="server" class="addtocart" 
                        ImageUrl="~/Images/back.jpg" PostBackUrl="~/Pages/User/Product.aspx" />
                    <br />
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </div>
                
                <div class="cleaner h30"></div>
                    <h5>Product Description</h5>
                    <p><asp:Label ID="lblDescription" runat="server"></asp:Label></p>
          
       
       
        <div class="cleaner h50"></div>
        <h3>Related Products</h3>
        <div class="product_box">
        </div>
    </div>
   
    <div class="cleaner"></div>
</asp:Content>

