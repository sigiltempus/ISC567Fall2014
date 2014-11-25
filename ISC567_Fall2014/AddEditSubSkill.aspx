<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditSubSkill.aspx.vb"
    Inherits="ISC567_Fall2014.AddEditSubSkill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <div class="AddEditIFrame">
            <table align="center" width="100%" border="0px" cellpadding="0px" cellspacing="0px">
                <tr>
                    <td align="left" class="IFrameHeader">
                        <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="Add Sub Skill">
                        </ccJSIM:DragIFrame>
                    </td>
                    <td align="right" class="IFrameHeader">
                        <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="[x] Close"
                            IFrameName="IfAddEditSubSkill">
                        </ccJSIM:CloseIFrameButton>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server" Text="Skill Class Number"></asp:Label>
                    </td>
                    <td align="left" class="style2">
                        <asp:TextBox ID="txtskillsclassnum" runat="server" Width="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Skill Number"></asp:Label>
                    </td>
                    <td align="left" class="style2">
                        <asp:TextBox ID="txtskillsnum" runat="server" Width="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Sub Skill Number"></asp:Label>
                    </td>
                    <td align="left" class="style2">
                        <asp:TextBox ID="txtsubskillnum" runat="server" Width="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Sub Skill ID"></asp:Label>
                    </td>
                    <td align="left" class="style2">
                        <asp:TextBox ID="txtsubskillcombo" runat="server" Width="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="Label3" runat="server" Text="Sub Skill Title"></asp:Label>
                    </td>
                    <td align="left" class="style2">
                        <asp:TextBox ID="txtsubskilltitle" runat="server" Width="400px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="Label5" runat="server" Text="Job Ad Words"></asp:Label>
                    </td>
                    <td align="left" class="style2">
                        <asp:TextBox ID="txtjobadwords" runat="server" Height="102px" Width="394px"></asp:TextBox>
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
                            align="left" IFrameName="IfAddEditSubSkill" ParentFrame="IfSubSkill"
                            ParentPage="SubSkill.aspx" Width="53px" StatusPanelId="lblStatus" RefreshParentPage="True" MethodName="wsAddEditSubSkill" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>