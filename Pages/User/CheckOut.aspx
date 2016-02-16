<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="Pages_User_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="float_r">
        	<h2>Checkout</h2>
            <h5><strong>BILLING INFORMATION</strong></h5>
                <p style="color:red">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtReceiverEmails" ErrorMessage="*  Plase type correct email address" 
                        ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </p>
                <p style="color:red"><asp:Label ID="labMessage" runat="server" Visible="False"></asp:Label></p>
                <div class="content_half float_l ">
                    <span>Full Name:<label>*</label></span>&nbsp;&nbsp;
                    <span><asp:TextBox ID="txtReciverName" runat="server" Width="300px"></asp:TextBox></span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtReciverName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span>Contact Number:<label>*</label></span>&nbsp;&nbsp;
                    <asp:TextBox ID="txtReceiverPhone" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtReceiverPhone" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span>E-mail:<label>*</label></span>&nbsp;&nbsp;
                    <asp:TextBox ID="txtReceiverEmails" runat="server" Width="300"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtReceiverEmails" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>

                <div class="content_half float_r ">
                    <span>Address:<label>*</label></span>&nbsp;&nbsp;<asp:TextBox 
                    ID="txtReceiverAddress" runat="server" Width="300px" Height="69px" 
                    TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtReceiverAddress" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span>Post Code:<label>*</label></span>&nbsp;&nbsp;<asp:TextBox 
                    ID="txtReceiverPostCode" runat="server" Width="300px"></asp:TextBox>
                    <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtReceiverPostCode" ErrorMessage="Please type post code" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>
                 <div class="cleaner h50"></div>
            <h3>SHOPPING CART</h3>
            <asp:GridView ID="gvShoppingCart" runat="server"  
                        AutoGenerateColumns="False" BorderWidth="1px" 
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

                               <asp:BoundField DataField="Num" HeaderText="Number" ReadOnly="True">
                                      <ItemStyle HorizontalAlign="Center" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                     </asp:BoundField>  

                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True">
                                      <ItemStyle HorizontalAlign="Center" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                     </asp:BoundField>  

                                <asp:BoundField DataField="TotalPrice" HeaderText="TotalPrice" ReadOnly="True">
                                      <ItemStyle HorizontalAlign="Center" />
                                      <HeaderStyle HorizontalAlign="Center" />
                                     </asp:BoundField>  

                                
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
            <h4>TOTAL NUMBER: <strong><asp:Label ID="labTotalNum" runat="server" Text="0 "></asp:Label></strong></h4>
            <h4>PRICE: <strong><asp:Label ID="labhatPrice" runat="server" Text="0 ">$&nbsp;</asp:Label></strong></h4>
            <h4>GST: <strong><asp:Label ID="labgstPrice" runat="server" Text="0.00 " >$&nbsp;</asp:Label></strong></h4>
            <h4>TOTAL PRICE(INCLUDES GST): <strong><asp:Label ID="labTotalPrice" runat="server" Text="0.00" >$&nbsp;</asp:Label></strong></h4>
			<div><asp:Button ID="btnConfirm" class="submit_btn" runat="server" 
                       Text="Confirm Order" onclick="btnConfirm_Click" />
              </div>
            <div class="cleaner h50"></div>
               
            

        </div>
</asp:Content>

