<%@ Page Title="" Language="C#" MasterPageFile="~/Spider.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<table border="0" cellpadding="5" cellspacing="0" style="text-align: center">
        <tr>
            <td id ="newUser" runat="server" width="33%" class="linkCell">
                <a href="UserMaintenance.aspx?newUser=true">
                    <img alt="Enter a New User" src="icons/new.jpg" /><br />New User
                </a>
            </td>
            <td  id ="UserMaintainance" runat="server" width="33%" class="linkCell">
                <a href="UserMaintenance.aspx?newUser=false">
                    <img alt="User Maintainance" src="icons/maintain.png" /><br />User Maintainance
                </a>
            </td>
          
        </tr>
    </table>
</asp:Content>

