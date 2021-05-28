<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditSkills.aspx.vb"
    Inherits="ISC567_Fall2014.AddEditSkills" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <div class="AddEditIFrame">
            <table align="center" border="0px" cellpadding="0px" cellspacing="0px" style="height: 183px; width:296px;">
                <tr>
                    <td align="left" class="IFrameHeader">
                        <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="Add Skills">
                        </ccJSIM:DragIFrame>
                    </td>
                    <td align="right" class="IFrameHeader">
                        <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="[x] Close"
                           IFrameName="IfAddEditSkills">
                        </ccJSIM:CloseIFrameButton>
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Skill Name"></asp:Label>
                    </td>
                    <td align="left" class="style2">
                        <asp:TextBox ID="txtskillsname" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="left" class="style2">
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td align="left">
                        <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" runat="server" CssClass="Button"
                            align="left" IFrameName="IfAddEditSkills" ParentFrame="IfSkills"
                            ParentPage="Skills.aspx" Width="53px" StatusPanelId="lblStatus" RefreshParentPage="True" MethodName="wsAddEditSkills" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
