using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class SyntaxWizard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["currentUser"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        BOUser user = (BOUser)Session["currentUser"];

        if (user.IsAdvanced)
        {
            HL7Editor.Enabled = true;
        }
        else
        {
            HL7Editor.Enabled = false;
        }
        
        if(!Page.IsPostBack)
        {
            //Set Up Message Header
            HL7Editor.Text += @"MSH|^~\&";

            //Disable Buttons For Syntax reasons
            AddSegment.Enabled = false;
            AddSubField.Enabled = false;
            AddSubSubField.Enabled = false;
        }

            
            

     
    }
    //Fires From the AddSeg button
    protected void Add_SegmentBtn(object sender, EventArgs e)
    {
        string newSegment = "\r" + segNameTxt.Text;
        HL7Editor.Text += newSegment;
        AddSegment.Enabled = false;
        AddSubField.Enabled = false;
        AddSubSubField.Enabled = false;
        
    }
    //Fires From the Add Field Button
    protected void Add_FieldBtn(object sender, EventArgs e)
    {
        #region oldcode
        //if (EndField.Visible == true)
        //{
        //    //End Button
        //    string endField = "|";

        //    //Change Button Text
        //    AddField.Visible = true;
        //    AddField.Enabled = true;
        //    EndField.Visible = false;
        //    //Disable Button for Grammer
        //    AddSubField.Enabled = false;
        //    //HL7Editor.Content += endField;
        //    //HL7Editor.Text += endField;

        //}
        //else
        //{
        //AddField.Visible = false;
        //EndField.Visible = true;
        //AddField.Text = "End Field";
        //
        //EndField Grammer
        //HL7Editor.Content += newField;
        #endregion
            //Field Grammer Sign Start
            string newField = "|";
            //Must be able to add sub Fields Here
            // Disable Buttons for grammer
            AddSubField.Enabled = true;
            //AddField.Enabled = false;
            //Set the New Event
            newField += fieldNameTxt.Text;
            AddSegment.Enabled = true;
           
            HL7Editor.Text += newField;
        //}
    }
    //Fires From the Sub Field Btn
    protected void Add_SubFieldBtn(object sender, EventArgs e)
    {
        if (AddSubSubField.Enabled == true)
        {
            //End Button
            string field = "^";

            //Change Button Text
            AddSubField.Visible = true;
           // EndSubField.Visible = false;
            field += subFieldTxt.Text;
            //Disable Button for Grammer
            //AddSubField.Enabled = false;
            HL7Editor.Text += field;

        }
        else//First Run
        {
            //Field Grammer Sign Start
            string newField = "^";
            //Must be able to add sub Fields Here
            //Disable Buttons for grammers
            AddSubSubField.Enabled = true;
            newField += subFieldTxt.Text;
            //Set the New Event
            HL7Editor.Text += newField;
            
            
            
        }
    }
    //Fires From the Sub Sub Field Button
    protected void Add_SubFieldSubBtn(object sender, EventArgs e)
    {
        
            //Field Grammer Sign Start
            string newField = "&";
            
           
        
    }
    protected void SaveBtn_Click(object sender, EventArgs e)
    { 
        
        //Process Syntax

        string HL7SyntaxFile = HL7Editor.Text;
        if (MessageTitleTxt.Text.Equals(string.Empty))
        {
            //load no title Error
            string errorString = "Please enter a Message Title";
            LoadErrorMessage(error, "No Title Entered", errorString);
        }
        else if (HL7Editor.Text.Equals(string.Empty))
        {
            //load no message error
            string errorString = "Please enter in you HL7 Syntax";
            LoadErrorMessage(error, "No Message Entered", errorString);
        }
        else
        {
            bool result = SyntaxWriter.ProcessSyntaxFile(HL7SyntaxFile, MessageTitleTxt.Text);

            if (result)
            {
                Response.Redirect("~/SyntaxSuccess.aspx");
            }
            else
            {
                Response.Redirect("~/ErrorPage.aspx");
            }
        }
    }
    protected void LoadErrorMessage(HtmlControl divControl, String errormsgheader, String errormsg)
    {
        String imagesource = Request.ApplicationPath + @"\images\error_icon.gif";

        UserControl errormsgcontrol = new UserControl();
        errormsgcontrol = (UserControl)LoadControl("controls/ErrorMessage.ascx");

        errormsgcontrol.GetType().GetProperty("ErrorMessageHeader").SetValue(errormsgcontrol, errormsgheader, null);
        errormsgcontrol.GetType().GetProperty("ErrorMessage").SetValue(errormsgcontrol, errormsg, null);
        errormsgcontrol.GetType().GetProperty("ImageSource").SetValue(errormsgcontrol, imagesource, null);

        divControl.Controls.Add(errormsgcontrol);
        divControl.Visible = true;
    }
}
