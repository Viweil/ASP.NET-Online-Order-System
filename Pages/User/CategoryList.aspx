<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true" CodeFile="CategoryList.aspx.cs" Inherits="Pages_User_CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div id="content" class="float_r">
        	<h1><asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h1>
            <div class="product_box">
            <asp:DataList ID="dlCategory" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
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
        
        <p style="clear: both"></p>
        <p align =center
                <asp:Label ID="labCP" runat="server" Text="current page"></asp:Label>
                                [
                                <asp:Label ID="labPage" runat="server" Text="1"></asp:Label>
                                &nbsp;]
                                <asp:Label ID="labTP" runat="server" Text="total："></asp:Label>
                                [
                                <asp:Label ID="labBackPage" runat="server"></asp:Label>
                                &nbsp;]
                                <asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnOne_Click">&nbsp;1&nbsp;</asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnUp_Click">&nbsp;&nbsp<<&nbsp&nbsp</asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnNext_Click">&nbsp;&nbsp;>>&nbsp;&nbsp;</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnBack_Click">&nbsp;end&nbsp;</asp:LinkButton> &nbsp; &nbsp; </p>
    </div>

</asp:Content>

