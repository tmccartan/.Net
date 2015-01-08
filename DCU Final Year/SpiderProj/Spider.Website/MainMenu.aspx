<%@ Page Title="" Language="C#" MasterPageFile="~/Spider.master" AutoEventWireup="true" CodeFile="MainMenu.aspx.cs" Inherits="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
<table border="0" cellpadding="5" cellspacing="0" style="text-align: center">
        <tr>
            <td id ="newForm" runat="server" width="33%" class="linkCell">
                <a href="SyntaxWizard.aspx">
                    <img alt="Enter a New Form" src="icons/syntax.png" /><br />Create Syntax File
                </a>
            </td>
            <td  id ="viewForm" runat="server" width="33%" class="linkCell">
                <a href="Logs.aspx">
                    <img alt="View Forms" src="icons/logs.png" /><br />View Logs
                </a>
            </td>
            <td  id ="admin" runat="server" width="33%" class="linkCell">
                <a href="Admin.aspx">
                    <img alt="View Forms" src="icons/Admin.png" /><br />Admin Section
                </a>
            </td>
        </tr>
    </table>
</asp:Content>

