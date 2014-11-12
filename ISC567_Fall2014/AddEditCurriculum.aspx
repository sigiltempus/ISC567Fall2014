<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditCurriculum.aspx.vb" Inherits="ISC567_Fall2014.AddEditCurriculum" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add/Edit Curriculum</title>
    <script src="Scripts/jQuery/jquery-1.9.1.js"></script>
    <script src="Scripts/jQuery/jquery-ui.js"></script>

    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 320px;
            width: 690px;
        }

        .auto-style2 {
            height: 20px;
            width: 690px;
        }

        .chkBxList input {
            margin-left: 20px;
        }

        .chkBxList td {
            padding-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame" style="height: 420px;">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" CanDragIFrame="True" Text="" CssClass="IFrameHeader" Width="100%">
                            <asp:Label ID="lblTitle" runat="server" Text="" Width="85%" style="text-align: left;"></asp:Label>
                            <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddEditCurriculum" Text="[X] Close" style="text-align: right" />
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" BorderStyle="Solid" BorderColor="Black"
                            BorderWidth="2px" class="auto-style1">
                            <table style="width: 98%;" id="tblName">
                                <tr>
                                    <td style="width: 96%;">Curriculum Short Name<br />
                                        <asp:TextBox ID="txtShortName" runat="server" Style="width: 100%;" MaxLength="10" Enabled="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValShortName" runat="server" ErrorMessage="Curriculum Short Name is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtShortName">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 96%;">Curriculum Full Name<br />
                                        <asp:TextBox ID="txtLongName" runat="server" Style="width: 100%;" MaxLength="100" Height="40px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValLongName" runat="server" ErrorMessage="Curriculum Full Name is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtLongName">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                               
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please correct the errors specified below before proceeding"
                                          runat="server" />
                                    </td>  
                                   <!-- <caption>
                                        DisplayMode=&quot;BulletList&quot; EnableClientScript=&quot;true&quot; ForeColor=&quot;Red&quot;
                                    </caption>-->
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 20px;">
                        <ccJSIM:SaveAndCloseIFrameButton ID="btnCSave" runat="server" OnClick="btnCSave_Click" IFrameName="ifAddEditCurriculum" Interval="100"
                            Text=" [✓] SAVE " Width="100px" ParentFrame="ifCurriculumList" ParentPage="ListCurriculum.aspx" CssClass="Button" RefreshParentPage="True"/>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

