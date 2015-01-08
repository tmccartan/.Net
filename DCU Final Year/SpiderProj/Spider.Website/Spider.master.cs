using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Spider : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SetDate();
        if (Session["currentUser"] != null)
        {
            BOUser user = (BOUser)Session["currentUser"];
            lblUsername.Text = user.UserName;

        }
        else
        {
            pnlUserGreeting.Visible = false;
        }
        //if (MySession.Current.currentUser.UserLevel == 3)
        //{
        //    // shows the tabs according to user levels
        //    AdminTab.Visible = true;
        //    WizardTab.Visible = true;
        //    NewTab.Visible = true;
        //    AlertsTab.Visible = true;
        //    ConsultTab.Visible = true;

        //}
        //else if (MySession.Current.currentUser.UserLevel == 2)
        //{
        //    // shows the tabs according to user levels
        //    NewTab.Visible = true;
        //    AlertsTab.Visible = true;
        //    ConsultTab.Visible = true;
        //}
        //else
        //{
        //}
    }

    protected void lnkLogOff_Click(object sender, EventArgs e)
    {
        pnlUserGreeting.Visible = false;
        Session.Clear();
        Response.Redirect(HttpContext.Current.Request.ApplicationPath + @"/login.aspx");
    }

    #region Methods
    private void SetDate()
    {
        DateTime dateToday = DateTime.Today;
        StringBuilder date = new StringBuilder();

        date.Append(DateTime.Today.DayOfWeek.ToString());
        date.Append(", ");
        date.Append(dateToday.Day.ToString());
        date.Append(" ");
        date.Append(dateToday.ToString("MMMM"));
        date.Append(" ");
        date.Append(dateToday.Year.ToString());

        lblDate.Text = date.ToString();


    }
    /*
    private void SetUserGreeting(bool hasLoggedIn)
    {
        if (!hasLoggedIn)
            pnlUserGreeting.Visible = false;
        else
        {
            pnlUserGreeting.Visible = true;
        }
    }*/
    #endregion
}
