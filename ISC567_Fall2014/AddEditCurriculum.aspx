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
            width: 671px;
        }

        .auto-style2 {
            height: 20px;
            width: 671px;
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
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <div class="ListIFrame" style="height: 420px;">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:CloseIFrameButton ID="lbtnC1lose" runat="server" IFrameName="ifAddEditCurriculum" Text="[X] Close" BorderColor="White" ForeColor="Black" style="text-align: right; z-index: 1; left: 71px; top: 6px; position: absolute; margin-left: 515px; margin-top: 0px;" Height="24px" Width="70px"  />
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" CanDragIFrame="True" CssClass="IFrameHeader" Width="98%">
                             <asp:Label ID="lblCTitle" runat="server" Text="" Width="85%" style="text-align: left;"></asp:Label>
                        
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2"> 
                        &nbsp;</td>
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
                            <ccJSIM:SaveAndCloseIFrameButton ID="btnCSave" runat="server" CssClass="Button" IFrameName="ifAddEditCurriculum" Interval="100" MethodName="wsAddEditCurriculum" ParentFrame="ifCurriculumList" ParentPage="ListCurriculum.aspx" RefreshParentPage="True" Text=" [✓] SAVE " />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

