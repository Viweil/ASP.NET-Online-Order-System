<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Pages_Admin_UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content" class="float_r">
        <h2>User Management</h2>
          <asp:GridView ID="gvUserList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="5" DataKeyNames ="UserID"  Width="100%" HorizontalAlign="Center"
							HeaderStyle-CssClass="summary-title" OnPageIndexChanging="gvUserList_PageIndexChanging" 
                            OnRowDeleting="gvUserList_RowDeleting" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                            BorderWidth="1px" CellPadding="2" GridLines="None" ForeColor="Black">
							<HeaderStyle Font-Bold="True" CssClass="summary-title" BackColor="Tan"></HeaderStyle>
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" >
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LastName" HeaderText="LastName" >
                                    <ItemStyle HorizontalAlign="Center"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UserName" HeaderText="UserName" >
                                    <ItemStyle HorizontalAlign="Center"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" >
                                    <ItemStyle HorizontalAlign="Center"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="Address" >
                                    <ItemStyle HorizontalAlign="Center"  Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                                    <ItemStyle HorizontalAlign="Center"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                               <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="UserEdit.aspx?UserID={0}" >
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

