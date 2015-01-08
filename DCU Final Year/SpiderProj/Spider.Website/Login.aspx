<%@ Page Title="" Language="C#" MasterPageFile="~/Spider.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
 <script type="text/javascript">
    function keydown(ev){
      ev = ev || window.event;
      if (ev.keyCode == 13){
        document.getElementById("<%=btnLogin.ClientID %>").click();
        return false;
      }
    }
    </script>
<asp:Panel ID ="loginBox" runat="server" GroupingText ="Login" Width ="50%">
Please Login to use the system
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
    <td colspan="2">
    </td>
    </tr>
 <tr>
    <td style="width: 42%" align="right">
        User Name:&nbsp;</td>
    <td align="left">
        <asp:TextBox ID="txtUserName" runat="server" CssClass="LoginTextBox" Width ="40%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valUserName" runat="server" ControlToValidate="txtUserName"
            ErrorMessage="User Name cannot be empty">*</asp:RequiredFieldValidator></td>
</tr>
 <tr>
    <td style="width: 42%" align="right">
        Password:&nbsp;</td>
    <td align="left">
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="LoginTextBox" onkeydown="keydown.apply(null, arguments)" Width ="40%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
            ErrorMessage="User Name cannot be empty">*</asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td></td>
<td align="right" style="padding-right: 125px">
<asp:LinkButton ID="btnLogin" runat="server" Text="Login" CssClass="LoginButton" OnClick="LoginBtn_Click" />
</td>
</tr>
</table>
</asp:Panel>
</asp:Content>

