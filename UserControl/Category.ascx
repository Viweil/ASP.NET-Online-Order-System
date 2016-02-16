<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Category.ascx.cs" Inherits="UserControl_Category" %>
<%@ Register Assembly="CustomControls" Namespace="CustomControls" TagPrefix="cc1" %>
<asp:DataList ID="dlCategory" runat="server" OnItemCommand="dlCategory_ItemCommand">
    <ItemTemplate>
        <asp:LinkButton ID="btnCategory" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryID") %>'>
                                  <%# DataBinder.Eval(Container.DataItem, "CategoryName") %>
        </asp:LinkButton>
    </ItemTemplate>
</asp:DataList>
