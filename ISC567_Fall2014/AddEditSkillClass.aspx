<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditSkillClass.aspx.vb" Inherits="ISC567_Spring2013.AddEditSkillClass" %>

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
        <table align="center" border="0px" cellpadding="0px" cellspacing="0px">
            <tr>
                <td align="left" class="IFrameHeader">
                    <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="Add Skill Class">
                    </ccJSIM:DragIFrame>
                </td>
                <td align="right" class="IFrameHeader">
                    <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="[x] Close"
                        IFrameName="IfAddEditSkillClass">
                    </ccJSIM:CloseIFrameButton>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Program Name"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlProgram" runat="server" DataSourceID="sdsProgram" DataTextField="shortname"
                        DataValueField="programid">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sdsProgram" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT [programid], [shortname] FROM [program]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Skill Class Number"></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:TextBox ID="txtskillsclassnum" runat="server" Width="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:Label ID="Label3" runat="server" Text="Skill Class Name"></asp:Label>
                </td>
                <td align="left" class="style2">
                    <asp:TextBox ID="txtscname" runat="server" Width="400px" Height="50px" TextMode="MultiLine"></asp:TextBox>
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
                        align="left" IFrameName="IfAddEditSkillClass" MethodName="wsAddEditSkillClass"
                        ParentFrame="ifProgramSkillClass" ParentPage="SkillClass.aspx" Width="53px" StatusPanelId="lblStatus"
                        RefreshParentPage="True" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
