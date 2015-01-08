using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class controls_ErrorMessage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ValidStatus)
        {
            imgErrorControl.Src = String.Empty;
            lblErrorMessageHeader.Text = String.Empty;
            lblErrorMessage.Text = String.Empty;
        }
        else
        {
            imgErrorControl.Src = ImageSource;
            lblErrorMessageHeader.Text = HttpUtility.HtmlDecode("<strong>" +  HttpUtility.HtmlDecode(ErrorMessageHeader) + "</strong>");            

            if (ErrorMessage == String.Empty)
            {
                this.errormsgrow.Visible = false;
            }
            else
            {
                this.errormsgrow.Visible = true;
                lblErrorMessage.Text = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(ErrorMessage) + "</br>");                
            }
            if (ErrorMessageHeader == String.Empty)
            {
                this.pnlMain.Visible = false;
            }
        }


    }

    #region Properties

    public String ErrorMessageHeader
    {
        get { return this.hdnErrorMessageHeader.Value; }
        set { this.hdnErrorMessageHeader.Value = HttpUtility.HtmlEncode(value); }
        //set { this.hdnErrorMessageHeader.Value = value; }
    }

    public String ErrorMessage
    {
        get { return this.hdnErrorMessage.Value; }
        set { this.hdnErrorMessage.Value = HttpUtility.HtmlEncode(value); }
    }

    public Boolean ValidStatus
    {
        get { return Boolean.Parse(this.hdnStatus.Value); }
        set { this.hdnStatus.Value = value.ToString(); }
    }

    public String ImageSource
    {
        get { return this.hdnImgSrc.Value; }
        set { this.hdnImgSrc.Value = value; }
    }


    #endregion

}
