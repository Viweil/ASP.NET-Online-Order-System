<%@ Page Title="" Language="C#" MasterPageFile="~/CrazyHatsMain.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_User_Register" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="content" class="float_r">
            
                <h2>
                    Registration</h2>
                <h5>
                    <strong>FILLING THE INFORMATION</strong></h5>
                
                <div class="content_half float_l ">
                    <span>First Name<label>*</label></span>&nbsp;&nbsp;
                    <span><asp:TextBox ID="TxtFirstName" runat="server" Width="300px"></asp:TextBox></span>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtFirstName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                   
                    <br />
                    <br />
                    <span>Last Name<label>*</label></span>&nbsp;&nbsp;
                    <asp:TextBox ID="TxtLastName" runat="server" Width="300px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TxtLastName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                    <br />
                    <br />
                    <span>Prefer User Name<label>*</label></span>&nbsp;&nbsp;
                    <asp:TextBox ID="TxtUserName" runat="server" Width="300"></asp:TextBox>                    
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TxtUserName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                    <br />
                    <br />
                    <span>Password<label>*</label></span>&nbsp;&nbsp;
                    <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                    

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TxtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    

                    <br />
                    <br />
                    <span>Confirm Password<label>*</label></span>&nbsp;&nbsp;
                    <asp:TextBox ID="TxtConfirmPass" runat="server" TextMode="Password" Width="300px"></asp:TextBox>                    

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TxtConfirmPass" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <p style="color:red">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TxtPassword" ControlToValidate="TxtConfirmPass" 
                        ErrorMessage="*  Both password must be same" ForeColor="Red"></asp:CompareValidator></p>
                     <p style="color:red">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TxtEmail" ErrorMessage="*  Plase type correct email address" 
                        ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </p>
                </div>

                    <div class="content_half float_r ">
                
                    <span>Email Address<label>*</label></span>&nbsp;&nbsp;
                    <asp:TextBox ID="TxtEmail" runat="server" Width="300px"></asp:TextBox>
                   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TxtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                   
                    <br />
                    <br />
                    <span>Mobile Phone<label>*</label></span>&nbsp;&nbsp;<asp:TextBox 
                    ID="TxtMobile" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="TxtMobile" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span>Work Phone</span>&nbsp;&nbsp;<asp:TextBox 
                        ID="TxtWorkPhone" runat="server" Width="300px"></asp:TextBox>
                    <br />
                    <br />
                    <span>Home Phone</span>&nbsp;&nbsp;<asp:TextBox 
                        ID="TxtHomePhone" runat="server" Width="300px"></asp:TextBox>
                    <br />
                    <br />
                    <span>Address<label>*</label></span>&nbsp;&nbsp;<asp:TextBox 
                    ID="TxtAddress" runat="server" Width="300px" Height="77px" 
                    TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="TxtAddress" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>

                <div class="cleaner h50"></div>

               <div><asp:Button ID="btnRegister" class="submit_btn" runat="server" 
                       Text="Submit" onclick="btnReg_Click" />
              </div>

            <div class="cleaner">
            </div>
        </div>
        <!-- END of crazyhats_main -->



</asp:Content>

