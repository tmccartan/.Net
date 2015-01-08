<%@ Page Title="" Language="C#" MasterPageFile="~/Spider.master" AutoEventWireup="true" CodeFile="SyntaxWizard.aspx.cs" Inherits="SyntaxWizard" %>
<%@ Register namespace="MyControls" tagprefix="custom" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">
 
  <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"/>
  
 <p class="GroupBoxHeader"><asp:Label runat="server" ID="lblSyntaxWizard" Text="Syntax Wizard" /></p>  
 
 
<asp:UpdatePanel ID="upPnlMain" runat="server">
<ContentTemplate>
<table>
<tr>
<div id="error" runat="server" visible ="false">
 </div>
<td>
<%--<custom:CustomEditor ID="HL7Editor" Width="600px" Height="200px" runat="server" /><br />

--%>

Message Title<br />
<asp:TextBox ID="MessageTitleTxt" runat="server"/><br /><br />

<asp:TextBox ID="HL7Editor" Width="600px" Height="200px" runat="server" TextMode="MultiLine" /><br />
<asp:Button ID="AddSegment" runat="server" Text="New Segmenent" />
<asp:Button ID="AddField" runat="server" Text="New Field"  />
<asp:Button ID="EndField" runat="server" Text="End Field" Visible="false" OnClick="Add_FieldBtn" />
<asp:Button ID="AddSubField" runat="server" Text="New Sub Field" /> 
<asp:Button ID="AddSubSubField" runat="server" Text="New Sub Sub Field" /> <%--OnClick="Add_SubFieldSubBtn" />--%><BR />
<asp:Button ID="SaveButton" runat="server" Text="Save Syntax" OnClick="SaveBtn_Click" />

</td>
</tr>
</table>

<asp:Panel ID ="newSegment" runat="server" CssClass="modalPopup" Style="display: none" Width="400px" GroupingText="New Group Panel" >
  <table border="0" width ="100%">
    <tr>
        <td >
        <p class="GroupBoxHeader">Add a new Segment</p>
        <br />
        </td>
        </tr>
        <tr>
        
            <td width ="100%">
                Segment Name:<asp:TextBox ID= "segNameTxt" runat="server"></asp:TextBox><br />
                <br />
                <br />
            </td>
        </tr>
         
        <tr>
            <td align = "center">
           
            <asp:Button ID="addNewSeg" runat="server" Text="Add Segment" OnClick="Add_SegmentBtn" CausesValidation="false" />
            <asp:Button ID="cancelNewSeg" runat="server" Text="Cancel"  CausesValidation="false" />
            
            </td>
        </tr>
        
        </table>
 </asp:Panel>
<asp:Panel ID ="newField" runat="server" CssClass="modalPopup" Style="display: none" Width="400px" GroupingText="New Group Panel" >
  <table border="0" width ="100%">
    <tr>
        <td >
        <p class="GroupBoxHeader">Add a new Field</p>
        <br />
        </td>
        </tr>
        <tr>
        
            <td width ="100%">
                Field Name:<asp:TextBox ID= "fieldNameTxt" runat="server"></asp:TextBox><br />
                <br />
                <br />
            </td>
        </tr>
         
        <tr>
            <td align = "center">
           
            <asp:Button ID="OKFieldButton" runat="server" Text="Add Field" OnClick="Add_FieldBtn" CausesValidation="false" />
            <asp:Button ID="CanFieldBtn" runat="server" Text="Cancel"  CausesValidation="false" />
            
            </td>
        </tr>
        
        </table>
 </asp:Panel>
<asp:Panel ID ="newSubField" runat="server" CssClass="modalPopup" Style="display: none" Width="400px" GroupingText="New Group Panel" >
  <table border="0" width ="100%">
    <tr>
        <td >
        <p class="GroupBoxHeader">Add a new SubField</p>
        <br />
        </td>
        </tr>
        <tr>
        
            <td width ="100%">
                SubField Name:<asp:TextBox ID= "subFieldTxt" runat="server"></asp:TextBox><br />
                <br />
                <br />
            </td>
        </tr>
         
        <tr>
            <td align = "center">
           
            <asp:Button ID="addSubFieldBtn" runat="server" Text="Add SubField" OnClick="Add_SubFieldBtn" CausesValidation="false" />
            <asp:Button ID="CancelSubFieldBtn" runat="server" Text="Cancel"  CausesValidation="false" />
            
            </td>
        </tr>
        
        </table>
 </asp:Panel>
<asp:Panel ID ="newSubSubField" runat="server" CssClass="modalPopup" Style="display: none" Width="400px" GroupingText="New Group Panel" >
  <table border="0" width ="100%">
    <tr>
        <td >
        <p class="GroupBoxHeader">Add a new Sub Sub Field</p>
        <br />
        </td>
        </tr>
        <tr>
        
            <td width ="100%">
                Sub Field Name:<asp:TextBox ID= "SubSubFieldTxt" runat="server"></asp:TextBox><br />
                <br />
                <br />
            </td>
        </tr>
         
        <tr>
            <td align = "center">
           
            <asp:Button ID="ModalAddSubSubFieldBtn" runat="server" Text="Add Field" OnClick="Add_SubFieldSubBtn" CausesValidation="false" />
            <asp:Button ID="ModalCancelSubSubFieldBtn" runat="server" Text="Cancel"  CausesValidation="false" />
            
            </td>
        </tr>
        
        </table>
 </asp:Panel>
 
 <ajaxToolkit:ModalPopupExtender ID="AddSegmentModal" runat="server"
    TargetControlID="AddSegment"
    PopupControlID="newSegment"
    BackgroundCssClass="modalBackground" 
    DropShadow="true"
    CancelControlID="cancelNewSeg" 
      
/>
<ajaxToolkit:ModalPopupExtender ID="AddFieldModal" runat="server"
    TargetControlID="AddField"
    PopupControlID="newField"
    BackgroundCssClass="modalBackground" 
    DropShadow="true"  
/>
<ajaxToolkit:ModalPopupExtender ID="AddSubFieldModal" runat="server"
        TargetControlID="AddSubField"
        PopupControlID="newSubField"
        BackgroundCssClass="modalBackground" 
        DropShadow="true" 
        CancelControlID="CancelSubFieldBtn" 
/>

<ajaxToolkit:ModalPopupExtender ID="AddSubSubFieldModal" runat="server"
    TargetControlID="AddSubSubField"
    PopupControlID="newSubSubField"
    BackgroundCssClass="modalBackground" 
    DropShadow="true" 
    CancelControlID="ModalCancelSubSubFieldBtn" 
/>
</ContentTemplate>
</asp:UpdatePanel>
<%--VIEW PREVIOUS SYNTAX--%>
</asp:Content>

