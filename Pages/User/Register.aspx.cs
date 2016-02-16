using System;
using System.Net.Mail;
using System.Net;
using Model;
using BLL;

public partial class Pages_User_Register : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReg_Click(object sender, EventArgs e)
    {
        int IntReturnValue = ucObj.AddUser(TxtFirstName.Text.Trim(), TxtLastName.Text.Trim(), TxtUserName.Text.Trim(), TxtPassword.Text.Trim(), TxtEmail.Text.Trim(), 
            TxtMobile.Text.Trim(), TxtWorkPhone.Text.Trim(), TxtHomePhone.Text.Trim(), TxtAddress.Text.Trim());
        if (IntReturnValue == 100)
        {
           
            //MailMessage mailMsg = new MailMessage();
            //mailMsg.From = new MailAddress("nikkilwei@gmail.com");// Source
            //mailMsg.To.Add(new MailAddress(TxtEmail.Text.Trim()));//Destination
            //mailMsg.Subject = "Congratulations! Welcome to Crazy Hat!";// Subject 
            //mailMsg.Body = "<a href='http://localhost:16527'>Click here</a>";// Content 
            //mailMsg.IsBodyHtml = true;
            //System.Net.Mail.SmtpClient client = new SmtpClient("smtp.gmail.com");//smtp server。
            //client.Credentials = new NetworkCredential("nikkilwei@gmail.com", "nikki123456");// sender's account.
            //client.Send(mailMsg);
            Response.Write(ccObj.MessageBox("Congratulations! Register succeeded!"));
            autoLogin();
        }
        else
        {
            Response.Write(ccObj.MessageBox("Sorry, this user name has been already exsit."));

        }

        }
    protected void autoLogin()
    {
        Session["UserID"] = null;
        Session["UserName"] = null;

        #region varify login
        UserInfo userInfo = new UserInfo();
        userInfo.UserName = this.TxtUserName.Text.Trim();
        userInfo.Password = this.TxtPassword.Text.Trim();

        UserInfo_BLL userInfoBll = new UserInfo_BLL();
        UserInfo result = userInfoBll.CheckUserInfoByUserNameAndPassword(userInfo);
        #endregion

            Session["UserID"] = result.UserID;
            Session["UserName"] = result.UserName;
            Response.Redirect("~/Default.aspx");
        
    }

    //protected void SendEmail(String Mail)
    //{
    //    MailAddress toAddress = new MailAddress(Mail);
    //    MailAddress fromAddress = new MailAddress("nikkilwei@gmail.com");
    //    MailMessage message = new MailMessage(fromAddress, toAddress);
    //    message.Subject = "Registration is successful!";
    //    message.Body = "Congratulation. You have registed successfully.";
    //    SmtpClient mailClient = new SmtpClient();

    //    try
    //    {
    //        mailClient.Host = "localhost";
    //        mailClient.Send(message);
    //    }
    //    catch (SmtpException smtpEx)
    //    {
    //        Response.Write("Email is not sent due to system error: " + smtpEx.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("Error: " + ex.ToString());
    //    }
    //}

}
 
