<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditExamSchedule.aspx.vb" Inherits="ISC567_Fall2014.AddEditExam" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="Scripts/jQuery/jquery-1.9.1.js"></script>
    <script src="Scripts/jQuery/jquery-ui.js"></script>
    <link rel="stylesheet" href="Styles/jQuery/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <title>Add/Edit Exam</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 135px;
            width: 586px;
        }

        .auto-style2 {
            height: 20px;
            width: 586px;
        }
    </style>
    <script>
        $(function () {
            $("#txtDate").datepicker();
        });
    </script>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame" style="height: 236px;">
            <table style="height: 178px">
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" CanDragIFrame="True" CssClass="IFrameHeader" Width="100%">
                            <asp:Label ID="lblTitle" runat="server" Text="" Width="85%" style="text-align: left;">
                            </asp:Label>
                            <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddEditExamSchedule" Text="[X] Close" 
                             style="text-align: right;" />
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
                            BorderWidth="2px" class="auto-style1" Height="140px">
                            <table style="width: 98%; margin-bottom: 0px;" id="tblName">
                                <tr style="text-decoration-style: solid;">
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblExamName" runat="server" Text="Exam Name: " Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%; white-space: nowrap;">
                                        <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="true" CssClass="DropDownList" Style="width: 55%;">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqExam" runat="server" ErrorMessage="Exam Name Required" ControlToValidate="ddlExam"
                                            Display="Dynamic" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblDate" runat="server" Text="Date: " Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%; white-space: nowrap;">
                                        <input runat="server" type="text" id="txtDate" style="width: 55%;" />
                                        <asp:RequiredFieldValidator ID="ReqDate" runat="server" ErrorMessage="Exam Date Required" ControlToValidate="txtDate"
                                            Display="Dynamic" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="ValDate" ControlToValidate="txtDate"
                                            ValidationExpression="^[0-3]?[0-9]/[0-3]?[0-9]/(?:[0-9]{2})?[0-9]{2}$"
                                            ErrorMessage="Invalid Date" Display="Dynamic" Text="*" ForeColor="Red">   
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblStartTime" runat="server" Text="Start Time: " Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%; white-space: nowrap;">
                                        <asp:TextBox ID="txtStartTime" runat="server" Style="width: 55%;"></asp:TextBox>(Format:00:00)
                                        <asp:RequiredFieldValidator ID="ReqStartTime" runat="server" ErrorMessage="Start Time Required" ControlToValidate="txtStartTime"
                                            Display="Dynamic" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="ValStartTime" ControlToValidate="txtStartTime"
                                            ValidationExpression="(([01][0-9])|(2[0-3])):?[0-5][0-9]"
                                            ErrorMessage="Invalid Start Time" Display="Dynamic" Text="*" ForeColor="Red">   
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblEndTime" runat="server" Text="End Time: " Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%; white-space: nowrap;">
                                        <asp:TextBox ID="txtEndTime" runat="server" Style="width: 55%;"></asp:TextBox>(Format:00:00)
                                        <asp:RequiredFieldValidator ID="ReqEndTime" runat="server" ErrorMessage="End Time Required" ControlToValidate="txtEndTime"
                                            Display="Dynamic" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="ValEndTime" ControlToValidate="txtEndTime"
                                            ValidationExpression="(([01][0-9])|(2[0-3])):?[0-5][0-9]"
                                            ErrorMessage="Invalid End Time" Display="Dynamic" Text="*" ForeColor="Red">   
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblLocation" runat="server" Text="Location: " Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%; white-space: nowrap;">
                                        <asp:TextBox ID="txtLocation" runat="server" Style="width: 55%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqLocation" runat="server" ErrorMessage="Location Required" ControlToValidate="txtLocation"
                                            Display="Dynamic" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr >
                                    <td colspan="2">
                                        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please correct the errors specified below before proceeding"
                                            DisplayMode="BulletList" EnableClientScript="true" ForeColor="Red" runat="server" Width="445px" />
                                        <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="Close" Cssclass="Button" IFrameName="ifExamList" PostBackUrl="WorkonExam.aspx"  Width="70px" style="z-index: 1; left: 490px; top: 210px; position: absolute; height: 21px;" />
                                    </td>
 
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 20px;">
                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
