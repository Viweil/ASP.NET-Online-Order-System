<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true"
    CodeFile="ShoppingCart.aspx.cs" Inherits="Pages_User_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="float_r">
        <h1>Shopping Cart</h1>
        <asp:Panel ID="pnlShoppingCart" runat="server"></asp:Panel>
        <p style="text-align:center"><asp:Label ID="labMessage" runat="server" Visible="False"></asp:Label></p>
        <table id="tbShoppingCart" width="680px" cellspacing="0" cellpadding="5">
            <tr><td align="center"></td></tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvShoppingCart" DataKeyNames ="ProductID"   runat="server"  
                        AutoGenerateColumns="False"  AllowPaging="True" 
                        OnPageIndexChanging="gvShoppingCart_PageIndexChanging" BorderWidth="1px" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" CellPadding="4" 
                        ForeColor="Black" GridLines="Horizontal" style="margin-right: 0px" 
                        Width="658px" >
                            <Columns>
                                <asp:BoundField DataField="No" HeaderText="NO." ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>  
                                    
                                <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                     </asp:BoundField>     
                                      
                                <asp:BoundField DataField="HatName" HeaderText="HatName" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField> 

                                <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate >
                                <asp:TextBox ID="txtNum" runat="server" Text ='<%#Eval("Num") %>' 
                                    Width ="30px"  OnTextChanged="txtNum_TextChanged" Height="19px" ></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNum"
                                    ErrorMessage="×" ValidationExpression="^\+?[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate >
                                    $<%#Eval("Price")%>
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText ="TotalPrice">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate >
                                    $<%#Eval("TotalPrice")%>
                                    </ItemTemplate>    
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate >
                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandArgument ='<%#Eval("ProductID") %>' OnCommand ="lnkbtnDelete_Command">Delete</asp:LinkButton>
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                     
                            </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr><td align="left" style="height: 30px"></td>
		    </tr>
            <tr align ="left" valign ="top"  >
				<td align="center">&nbsp;</td>
                <td align="right" font-weight:bold"><asp:Label ID="lblPrice" runat="server" Text="" Font-Size="Small" Font-Bold="True">Price</asp:Label></td>
                <td align="right" font-weight:bold"><asp:Label ID="labhatPrice" runat="server" Text="" ></asp:Label></td>
                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			</tr>
            <tr>
                <td align="right"  height="30px">&nbsp;&nbsp;</td>
                <td align="right" font-weight:bold"><asp:Label ID="lblGST" runat="server" Text="" Font-Size="Small" Font-Bold="True">GST</asp:Label></td>
                <td align="right" font-weight:bold"><asp:Label ID="labgstPrice" runat="server" Text="" ></asp:Label></td>
                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
		    </tr>
            <tr>
                <td align="right"  height="30px">
                <asp:Label ID="lblUpdate" runat="server" Text="" >Have you modified your basket? Please click here to</asp:Label> 
                <asp:LinkButton ID="lnkbtnUpdate" runat="server" OnClick="lnkbtnUpdate_Click">Update</asp:LinkButton>&nbsp;&nbsp;</td>
                <td align="right" font-weight:bold"> <asp:Label ID="lblTotalPrice" runat="server" Text="" Font-Bold="True" Font-Size="Small">Total Price</asp:Label></td>
                <td align="right" font-weight:bold"><asp:Label ID="labTotalPrice" runat="server" Text="" ></asp:Label></td>
                <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
			</tr>
        </table>
        <div id="dvShoppingCart" style="float: right; width: 215px; margin-top: 20px;">
            <p><asp:LinkButton ID="lnkbtnCheck" PostBackUrl="CheckOut.aspx" runat="server" OnClick="lnkbtnCheck_Click" >Proceed to checkout</asp:LinkButton></p>
            <p><asp:LinkButton ID="lnkbtnContinue" PostBackUrl="~/Default.aspx" runat="server" OnClick="lnkbtnContinue_Click" >Continue shopping</asp:LinkButton></p>
            <p align="left"><asp:LinkButton ID="lnkbtnClear" PostBackUrl="ShoppingCart.aspx?flag=clear" runat="server" OnClick="lnkbtnClear_Click" >Clear All</asp:LinkButton></p>
        </div>
    </div>
    
    <div class="cleaner"></div>
</asp:Content>
