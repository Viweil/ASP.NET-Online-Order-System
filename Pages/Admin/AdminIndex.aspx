<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master"
    AutoEventWireup="true" CodeFile="AdminIndex.aspx.cs" Inherits="Pages_Admin_AdminIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="float_r">
        <div id="slider-wrapper">
            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" bgcolor="#ffffff">
                            <tr>
                                <h2>Order Informatioin</h2>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvOrderList" runat="server" SkinID="gvSkin" OnPageIndexChanging="gvOrderList_PageIndexChanging"
                                        AllowPaging="True" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="OrderID">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a href='OrderModify.aspx?OrderID=<%# DataBinder.Eval(Container.DataItem, "OrderID") %>'>
                                                        <%# DataBinder.Eval(Container.DataItem, "OrderID") %>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "OrderDate").ToString()).ToLongDateString()%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                       
            </table>
        </div>
    </div>
</asp:Content>
