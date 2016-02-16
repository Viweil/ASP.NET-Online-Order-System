<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Pages_Admin_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">
    
        <h2>Product List</h2>
        <br />
        <p>Please type product：&nbsp;
			<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>&nbsp;
			<asp:Button id="btnSearch" class="search_btn" runat="server" Text="Search"></asp:Button></p>
        <asp:GridView ID="gvGoodsInfo" runat="server" CellPadding="2" Width="95%" HorizontalAlign="Center" 
							HeaderStyle-CssClass="summary-title" AutoGenerateColumns="False" OnPageIndexChanging="gvGoodsInfo_PageIndexChanging" OnRowDeleting="gvGoodsInfo_RowDeleting" AllowPaging="True" PageSize="5" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" GridLines="None" ForeColor="Black" >
                       <HeaderStyle Font-Bold="True"  Font-Size =Small BackColor="Tan" CssClass="summary-title"></HeaderStyle>
                        <Columns>
                            <asp:BoundField DataField="ProductID" HeaderText="ProductID"  >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HatName" HeaderText="Product Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText ="Category">
                            <HeaderStyle HorizontalAlign = "Center" />
                            <ItemStyle HorizontalAlign = "Center" />
                            <ItemTemplate >
                            <%# GetCategoryName(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "CategoryID").ToString())) %>
                            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText ="Price">
                            <HeaderStyle HorizontalAlign = "Center" />
                            <ItemStyle HorizontalAlign = "Center" />
                            <ItemTemplate >
                            $ <%# GetPrice(DataBinder.Eval(Container.DataItem, "Price").ToString())%>
                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="ProductEdit.aspx?ProductID={0}" >
                                <ControlStyle Font-Underline="False" ForeColor="Black" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" >
                                <ControlStyle Font-Underline="False" ForeColor="Black" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="Tan" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>


 </div>
</asp:Content>

