//TODO
/* Encrypt Password
 * Check Password = ConfirmPassword
 * Change success panel
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserMaintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["currentUser"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            bool newUser = Boolean.Parse(Request.QueryString["newUser"]);
            if (newUser)
            {
                setupNewUser();
            }
            else
            {
                int userNum = 0;
                bool userNumInQueryString = int.TryParse(Request.QueryString["userID"], out userNum);

                if (userNumInQueryString)
                {
                    loadUserForEdit();
                }
                else
                {
                    loadUserTable();
                }
            }
        }
    }
    private void loadUserForEdit()
    {
        int userID = Convert.ToInt32(Request.QueryString["userID"]);
        BOUser user = UserService.GetBOUserByUserID(userID);
        
        txtEditUserID.Text = user.UserID.ToString();
        txtEditUsername.Text = user.UserName;
        pnlEditUser.Visible = true;
    }
    private void setupNewUser()
    {
        pnlNewUserDetails.Visible = true;
    }
    private void loadUserTable()
    {
        DataSet ds = UserService.GetAllUsers();
        gvUserTable.DataSource = ds;
        gvUserTable.DataBind();
        pnlUserTable.Visible = true;

    }
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        if (!txtUserName.Text.Equals(string.Empty) && !txtUserName.Text.Equals(string.Empty) && !txtConfirmPassword.Text.Equals(string.Empty))
        {
            bool success = UserService.CreateNewUser(txtUserName.Text, txtPassword.Text, ckAdvanced.Checked);
            if (success)
            {
                pnlUserTable.Visible = false;
                pnlSuccess.Visible = true;
            }
        }
        else
        {
            ///TODO: Handle Error
        }
    }
    protected void btnEditUser_Click(object sender, EventArgs e)
    {
        if (!txtEditUsername.Text.Equals(string.Empty) && !txtEditPassword.Text.Equals(string.Empty) &&  !txtEditConfirmPassword.Text.Equals(string.Empty))
        {
            bool success = UserService.UpdateUserDetails(txtEditUsername.Text, txtEditPassword.Text, Convert.ToInt32(txtEditUserID.Text), ckAdvanced.Checked);
            if (success)
            {
                pnlEditUser.Visible = false;
                pnlSuccess.Visible = true;
            }
            
        }
        else
        {
            ///TODO: Handle Error
        }
    }
    protected void gvUserTable_Edit(object sender, GridViewSelectEventArgs e)
    {
        GridView selected = (GridView)sender;
        int userID = Convert.ToInt32(selected.Rows[e.NewSelectedIndex].Cells[0].Text);
        Response.Redirect("~/UserMaintenance.aspx?newUser=false&userID="+userID);

    }
}
