<%@ Page Title="" Language="C#" MasterPageFile="~/Spider.master" AutoEventWireup="true" CodeFile="UserMaintenance.aspx.cs" Inherits="UserMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">


 <asp:Panel ID ="pnlNewUserDetails" runat="server" GroupingText=" User Details" Visible ="false"> 
  <p class="GroupBoxHeader"><asp:Label runat="server" ID="lbNewUser" Text="New User" /></p>  
    <img alt="Enter a New User" src="icons/new.jpg" /><br /><br />

 <table>

 <tr>
 <td>
 <asp:Label runat="server" ID="lblUserName" Text="Username:" />
 </td>
 <td>
 <asp:TextBox ID = "txtUserName" runat="server"></asp:TextBox>
 </td>
 </tr>
 <tr> 
 <td>
 <asp:Label runat="server" ID="lblPassword" Text="Password:" />
 </td>
 <td>
  <asp:TextBox ID = "txtPassword" runat="server" TextMode="Password"></asp:TextBox>
 </td>
 </tr>
 <tr> 
 <td>
 <asp:Label runat="server" ID="lblConfirmPassword" Text="Confirm Password:" />
 </td>
 <td>
  <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
 </td>
 </tr>
 </table><br /><br />
 <asp:Button ID="btnNewUser" runat="server" OnClick="btnNewUser_Click" Text="Create User" />
 </asp:Panel>
 <asp:Panel ID ="pnlUserTable" runat="server" GroupingText=" User Table" Visible ="false"> 
  <p class="GroupBoxHeader"><asp:Label runat="server" ID="Label1" Text="User Maintenance" /></p>  
 <asp:GridView ID="gvUserTable" runat="server" AutoGenerateColumns="false" CssClass="GridView" Width="100%" OnSelectedIndexChanging="gvUserTable_Edit"   >
 <Columns>
  <asp:BoundField DataField="UserID" HeaderText=" ID">
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
    </asp:BoundField>
    <asp:BoundField DataField="UserName" HeaderText=" UserName">
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
    </asp:BoundField>
   <asp:CommandField ButtonType="Link" ShowSelectButton="true" SelectText="Edit User" />
  </Columns>
    <RowStyle CssClass="GridViewRowStyle" Wrap="False" />
    <PagerStyle CssClass="GridViewPageStyle" />
    <HeaderStyle CssClass="GridViewHeaderStyle" />
    <AlternatingRowStyle CssClass="GridViewAltStyle" Wrap="False" />
    </asp:GridView> 
  </asp:Panel>
 <asp:Panel ID ="pnlEditUser" runat="server" GroupingText=" Edit User Details" Visible ="false"> 
  <p class="GroupBoxHeader"><asp:Label runat="server" ID="lblEditUser" Text="Edit User" /></p>  
    <img alt="Edit User" src="icons/new.jpg" /><br /><br />

 <table>

<tr>
 <td>
 <asp:Label runat="server" ID="lblUserID" Text="UserID:" />
 </td>
 <td>
 <asp:TextBox ID = "txtEditUserID" runat="server" Enabled="false"></asp:TextBox>
 </td>
 </tr>
 <tr>
 <td>
 <asp:Label runat="server" ID="lblEditUsername" Text="Username:" />
 </td>
 <td>
 <asp:TextBox ID = "txtEditUsername" runat="server"></asp:TextBox>
 </td>
 </tr>
 <tr> 
 <td>
 <asp:Label runat="server" ID="lblEditPassword" Text="Password:" />
 </td>
 <td>
  <asp:TextBox ID = "txtEditPassword" runat="server" TextMode="Password"></asp:TextBox>
 </td>
 </tr>
 <tr> 
 <td>
 <asp:Label runat="server" ID="lblEditConfirmPassword" Text="Confirm Password:" />
 </td>
 <td>
  <asp:TextBox ID="txtEditConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
 </td>
 </tr>
 <tr> 
 <td>
 <asp:Label runat="server" ID="lblIsAdvanced" Text="Advanced User:" />
 </td>
 <td>
  <asp:CheckBox ID ="ckAdvanced" runat="server" Checked="false" />
 </td>
 </tr>
 </table><br /><br />
 <asp:Button ID="btnEditUser" runat="server" OnClick="btnEditUser_Click" Text="Update User" />
 </asp:Panel>
 <asp:Panel ID="pnlSuccess" runat ="server" Visible="false">
 <h2>Success</h2> 
 </asp:Panel>
</asp:Content>

