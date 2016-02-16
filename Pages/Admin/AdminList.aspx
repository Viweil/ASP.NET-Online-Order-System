<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="Pages_Admin_AdminList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">
    <div id="slider-wrapper">
        <h2>Admin List</h2>
        <br />
        <asp:GridView ID="gvAdminList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="5" DataKeyNames ="AdminID"  Width="100%" HorizontalAlign="Center" CellPadding =3
							HeaderStyle-CssClass="summary-title" OnPageIndexChanging="gvAdminList_PageIndexChanging"  
                            OnRowDeleting="gvAdminList_RowDeleting" BackColor="LightGoldenrodYellow" BorderColor="Tan"  
                            BorderWidth="1px" CellSpacing="2" GridLines="None"  ForeColor="Black">
							<HeaderStyle Font-Bold="True" BackColor="Tan" CssClass="summary-title"></HeaderStyle>
                            <Columns>
                                <asp:BoundField DataField="AdminID" HeaderText="AdminID" ReadOnly="True" >
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AdminName" HeaderText="Admin Name" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Password" HeaderText="Password" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RealName" HeaderText="Real Name" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                
                                <asp:CommandField ShowDeleteButton="True" >
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        </asp:GridView>

    </div>
</div>

</asp:Content>

