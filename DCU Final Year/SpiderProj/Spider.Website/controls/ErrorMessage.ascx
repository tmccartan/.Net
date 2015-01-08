<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ErrorMessage.ascx.cs"
    Inherits="controls_ErrorMessage" %>
<asp:Panel ID="pnlMain" runat="server" Width="100%" BorderWidth="0">
    <table style="width: 100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <fieldset style="padding: 0px; width: 99%">
                    <table width="100%" cellpadding="0" cellspacing="0" class="ErrorControlRepeatImage">
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left" valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0" class="ErrorControlRepeatImage">
                                    <tr>
                                        <td style="width: 29px; height: 29px; padding-left: 7px; padding-right: 7px; padding-top: 4px; padding-bottom:4px"
                                            align="left" valign="top">
                                            <img src="" alt="" id="imgErrorControl" runat="server" /></td>
                                        <td align="left" valign="middle" style="padding-top: 5px">
                                            <asp:Label ID="lblErrorMessageHeader" runat="server" Text="" Font-Bold="True" Font-Size="8pt"></asp:Label></td>
                                    </tr>
                                    <tr id="errormsgrow" runat="server">
                                        <td align="left">
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblErrorMessage" runat="server" Font-Size="8.5pt"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnErrorMessageHeader" Value="" runat="server" />
    <asp:HiddenField ID="hdnErrorMessage" Value="" runat="server" />
    <asp:HiddenField ID="hdnStatus" Value="false" runat="server" />
    <asp:HiddenField ID="hdnImgSrc" Value="" runat="server" />
</asp:Panel>
