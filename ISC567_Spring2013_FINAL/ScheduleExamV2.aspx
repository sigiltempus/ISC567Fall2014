<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ScheduleExamV2.aspx.vb" Inherits="ISC567_Spring2013.ScheduleExamV2" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="Styles/IFrameStyles.css" />
    <style type="text/css">
        .style1 {
            width: 310px;
        }

        .style2 {
            width: 125px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div class="AddEditIFrame" style="width: 804px; height: 496px;">
            <ccJSIM:DragIFrame ID="DragIFrame1" runat="server" Text="Schedule Exam" CanDragIFrame="True"
                Width="98%" CssClass="IFrameHeader"> 
            </ccJSIM:DragIFrame>
            <table style="width:98%; height:98%">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label1" runat="server" Text="Exam" Font-Bold="true">
                        </asp:Label>
                    </td>
                    <td class="style1">
                        <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="true">
                            <asp:ListItem Value="-1">--Select a Exam--
                            </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style1">

                        <%-- <asp:Calendar ID="Calender1" runat="server" Width="165px"></asp:Calendar>--%>

                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style1">

                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <ccJSIM:CheckboxGridView ID="CGVScheduledExams" runat="server" AutoGenerateColumns="False" CheckedIdentifier="" CheckedMethodName="" GridSortColumn="" GridSortDirection="ASC" IncludeSorting="True" ShowHeaderCheckbox="True" StatusPanelId="" UnCheckedMethodName="" UseAjax="False" Width="403px">
                            <Columns>
                                <asp:BoundField />
                                <asp:BoundField HeaderText="Date" />
                                <asp:BoundField HeaderText="Time" />
                                <asp:BoundField HeaderText="Location" />
                                <asp:BoundField />
                            </Columns>
                        </ccJSIM:CheckboxGridView>
                    </td>
                </tr>
                <tr>
                    <td class="style2"></td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>


                <tr>
                    <td class="style2"></td>
                </tr>
                <tr>
                    <td>
                        <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="Cancel" CssClass="Button" IFrameName="ifScheduleExam" Interval="10" Height="30px" Width="90px" />&nbsp; 
                    <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" runat="server" Text="Save" IFrameName="IfScheduleExam" Height="30px"
                        Width="90px" StatusPanelId="lblStatus" CssClass="Button" RefreshParentPage="True" ParentFrame="ifRoster" ParentPage="Roster.aspx" />&nbsp;                            
                    <asp:Label ID="lblErr" runat="server" Text="" ForeColor="Red" Font="Large" Style="z-index: 1; left: 183px; top: 412px; position: absolute"></asp:Label>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
