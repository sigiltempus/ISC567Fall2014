<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditProgramOutcome.aspx.vb"
    Inherits="ISC567_Fall2014.AddEditProgramOutcome" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="ListIFrame">
        <table align="left" border="0px" cellpadding="0" cellspacing="0" style="width: 591px; height: 415px">
            <tr>
                <td align="left" class="IFrameHeader">
                    <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="Edit Program Outcome" CanDragIFrame="True"
                        Width="180"></ccJSIM:DragIFrame>
                </td>
                <td align="right" class="IFrameHeader">
                        <ccJSIM:CloseIFrameLinkButton runat="server" IFrameName="IfAddEditProgramOutcomes" ID="CloseIFrameLinkButton1"
                        Text="[x]Close" postbackurl="ListProgramOutCome.aspx" BorderColor="White" ForeColor="white"></ccJSIM:CloseIFrameLinkButton>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" Text="Program:" style="z-index: 1; left: 118px; top: 141px; position: absolute"></asp:Label>
                    <asp:DropDownList ID="ddlProgram" runat="server" style="z-index: 1; left: 215px; top: 140px; position: absolute">
                        <asp:ListItem> IS 2010</asp:ListItem>
                        <asp:ListItem> MCIS 2006</asp:ListItem>
                        <asp:ListItem> CIS</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="left">
                    &nbsp;
                    </td>
            </tr>
                 <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Program Outcome sequence" Width="150" style="z-index: 1; left: 40px; top: 176px; position: absolute; height: 31px"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="txtProgramseq" runat="server" style="z-index: 1; left: 222px; top: 187px; position: absolute; width: 32px;" MaxLength="1" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Program Outcome" style="z-index: 1; left: 68px; top: 243px; position: absolute"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="txtPrgoutcom" runat="server" TextMode="MultiLine" TabIndex="3" style="z-index: 1; left: 218px; top: 294px; position: absolute; width: 360px; height: 74px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Program Outcome Info" style="z-index: 1; left: 18px; top: 301px; position: absolute; right: 394px;"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;
                    <asp:TextBox ID="txtShortoutcome" runat="server" style="z-index: 1; left: 217px; top: 237px; position: absolute; width: 89px; height: 31px; bottom: 147px;" TabIndex="2"></asp:TextBox>
                </td>
            </tr>
        <%--    <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td align="left" colspan="2">
                    &nbsp;
                    <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" runat="server" IFrameName="IfAddProgramOutcomes"
                        MethodName="" ParentFrame="IfProgramOutcome" ParentPage="ListProgramOutCome.aspx"
                        Width="53px" StatusPanelId="lblStatus" CssClass="Button" RefreshParentPage="True" OnClick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:Label ID="Savemsg"  runat="server" style="z-index: 1; left: 156px; top: 387px; position: absolute"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
