<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Pages_User_Product" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div id="content" class="float_r">
        	<h1> Products</h1>
            <div class="product_box">
            <asp:DataList ID="dlHot" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                OnItemCommand="Product_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkbtnHName" runat="server" CommandName="chkDetail" Font-Underline="false"
                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ProductID")%>'>
                        <span><asp:Image ID="imageHot" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"Path")%>' /></span>
                        <p><%#DataBinder.Eval(Container.DataItem, "HatName")%></p>
                        <p class="product_price" style="border-bottom:0px;">$&nbsp;<%# DataBinder.Eval(Container.DataItem,"Price") %></p>
                    </asp:LinkButton>
                    <asp:ImageButton ID="imgBuy" class="addtocart" runat="server" CommandName="buy" 
                        ImageUrl="~/Images/addtocart.png" 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>' />
                    <asp:ImageButton ID="imgdetail" class="detail" runat="server" 
                        ImageUrl="~/Images/detail.png" CommandName="chkDetail" 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>' />
                        <p class="product_price" style="padding-top:15px;"></p>
                </ItemTemplate>
            </asp:DataList>
        </div>
         </div>
        <p style="clear: both"></p>
   
                                   
</asp:Content>

