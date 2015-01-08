using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["currentUser"] != null)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        string userName = txtUserName.Text;
        string password = txtPassword.Text;

        bool proceed = UserService.CheckUserLogin(userName, password);

        if (proceed)
        {
            BOUser user = UserService.GetBOUser(userName, password);
            Session["currentUser"] = user;

            Response.Redirect("MainMenu.aspx");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}
