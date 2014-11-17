<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SubSkillInBK.aspx.vb" Inherits="ISC567_Spring2013.SubSkillInBK" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SubSkillInBK List</title>
    <link href="styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            font-size: 14pt;
            font-weight: bold;
            color: White;
            background-color: #ba1c1c;
            font-family: Verdana;
            padding: 5px 5px 5px 5px;
            width: 264px;
        }
        .auto-style2 {
            width: 264px;
        }
        .auto-style3 {
            font-size: 14pt;
            font-weight: bold;
            color: White;
            background-color: #ba1c1c;
            font-family: Verdana;
            padding: 5px 5px 5px 5px;
            width: 415px;
        }
        .auto-style4 {
            width: 415px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager ID="Scriptmanager1" runat="server" EnablePageMethods="True"></asp:scriptmanager>
      <div class="ListIFrame">
         <table align="left" width="700px" border="0px" cellpadding="0px" cellspacing="0px">
             <tr>
                 <td align="left" class="auto-style1">
                     <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="List Sub Skill In Bk" CssClass="IFrameHeader"> </ccJSIM:DragIFrame>

                 </td>
                 <td align="right" class="auto-style3">
                     <ccJSIM:CloseIFrameLinkButton ID="CloseIFrameLinkButton1" runat="server" IFrameName="SubSkillInBK" Text="[x] Close"
                          ForeColor="White" BorderColor="White"> </ccJSIM:CloseIFrameLinkButton>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label1" runat="server" Text="SubSkill" style="text-align: left" Height="25px"></asp:Label>
                 </td>
                 <td class="auto-style4">
                     <asp:Label ID="Label2" runat="server" Text="BK1" style="text-align: middle"></asp:Label>
                 </td>  
                </tr>
             <tr>
                 <td class="auto-style2">
                     <asp:DropDownList ID="ddlSubskill" runat="server" Width="200px" Height="25px"></asp:DropDownList>

                 </td>
                 <td class="auto-style4">
                     <asp:DropDownList ID="ddlBk1" runat="server" Width="200px" Height="25px"></asp:DropDownList>
                 </td>
             </tr>
             <tr>
                 <td align="left" class="auto-style2">
                     <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" runat="server" CssClass="Button" Text="Save" align="left" IFrameName="SubSkillInBK" ParentFrame="IfSubSkill" 
                         ParentPage="SubSkill.aspx" Width="53px" StatusPanelId="lblStatus" RefreshParentPage="True"/>

                 </td>
             </tr>
         </table>
     </div>
    </form>
</body>
</html>
