<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/CrazyHatsMain.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" EnableEventValidation="false"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="content" class="float_r">
        <div id="slider-wrapper">
            <div id="slider" class="nivoSlider">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/slider/01.jpg" />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/slider/02.jpg" />
                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/slider/03.jpg" />
                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/slider/04.jpg" />
            </div>
        </div>
        <script type="text/javascript" src="Scripts/jquery-1.4.3.min.js"></script>
        <script type="text/javascript" src="Scripts/jquery.nivo.slider.pack.js"></script>
        <script type="text/javascript">
            $(window).load(function () {
                $('#slider').nivoSlider();
            });
        </script>
        <h1>New Products</h1>
        <div class="product_box">
            <asp:DataList ID="dlHot" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                OnItemCommand="Produc_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkbtnHName" runat="server" CommandName="chkDetail" Font-Underline="false"
                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ProductID")%>'>
                        <span><asp:Image ID="imageHot" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"Path")%>' /></span>
                        <p><%#DataBinder.Eval(Container.DataItem, "HatName")%></p>
                        <p class="product_price" style="border-bottom:0px;">$ <%#DataBinder.Eval(Container.DataItem,"Price").ToString()%></p>
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
    </div>
</asp:Content>
