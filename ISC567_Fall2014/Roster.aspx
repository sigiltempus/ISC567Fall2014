<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Roster.aspx.vb" Inherits="ISC567_Fall2014.Roster" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="Styles/IFrameStyles.css" />

    <style type="text/css">
        .style1 {
            font-size: 14pt;
            font-weight: bold;
            height: 25px;
            color: White;
            background-color: #ba1c1c;
            font-family: Verdana;
            padding: 5px 5px 5px 5px;
            width: 550px;
        }

        .style2 {
            width: 604px;
        }

        .auto-style1 {
            width: 274px;
        }
        .auto-style2 {
            height: 6px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        <div class="ListIFrame" style="width: 804px; height: 400px;">
            <table style="width: 100%; height: 342px;">
                <tr style="text-align: left">
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="Exam in which you are involved" CanDragIFrame="True" CssClass="IFrameHeader" Visible="True" Width="98%">
                        </ccJSIM:DragIFrame>
                        </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical"
                                    BorderStyle="Solid" BorderColor="Black" BorderWidth="2px" Width="100%" Height="332px">
                                    <ccJSIM:OpenIFrameGridView ID="gvroster" runat="server" Width="100%"
                                        AutoGenerateColumns="False" CellPadding="4" ChangeRowColor="True"
                                        DataKeyNames="examid" ForeColor="#333333" FrameSrc="roster.aspx" GridLines="None"
                                        GridSortColumn="status" GridSortDirection="ASC" HeightPosition="200"
                                        HighlighedRowColor="Blue" IFrameName="ifAddEditUser" IncludeSorting="True"
                                        LeftPosition="60" ShowDeleteButton="False" ShowEditButton="False"
                                        ShowSelectorButton="True" TopPosition="60" WidthPosition="300"
                                        ZIndex="150" AllowSorting="True" Interval="" GridDeleteButtonText=""
                                        GridEditButtonText="">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="se.examid" Visible="False" HeaderText="ExamID" SortExpression="se.examid" />

                                            <asp:BoundField DataField="examname" HeaderText="Exam" SortExpression="Exam" />
                                            <asp:BoundField DataField="status" HeaderText="ExStatus" SortExpression="status" />
                                            <asp:BoundField DataField="examdate" HeaderText="Date" SortExpression="examdate" />
                                            <asp:BoundField DataField="examstarttime" HeaderText="Time" SortExpression="Time" />
                                            <asp:BoundField DataField="examlocation" HeaderText="Location" SortExpression="Location" />
                                            <asp:BoundField DataField="score" HeaderText="Score" SortExpression="Score" />

                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </ccJSIM:OpenIFrameGridView>


                                    <br />
                                    <br />
                                    <br />


                                    <br />
                                    <table style="text-align: center; width: 100%; height: 83px;">
                                        <tr>
                                            <td>
                                                <ccJSIM:OpenIFrameButton ID="btnIfExamSchedule" runat="server" CssClass="Button" FrameSrc="ScheduleExam.aspx" HeightPosition="500" IFrameName="ifScheduleExam" LeftPosition="350" Text="Schedule Another Exam" TopPosition="80" WidthPosition="600" ZIndex="160" />
                                            </td>
                                            <td class="auto-style1">
                                                <ccJSIM:OpenIFrameButton ID="btnifTakeExam" runat="server" CssClass="Button" Enabled="False" FrameSrc="ConfirmationPage.aspx" HeightPosition="360" IFrameName="ifConfirmationPage" LeftPosition="250" Text="Take The EXAM" TopPosition="120" Width="98%" WidthPosition="610" ZIndex="160" />
                                         
                                                 </td>
                                            <td class="auto-style1">
                                                <asp:Button ID="btnCancelExam" runat="server" CssClass="Button" Text="  cancel the scheduled exam" Width="197px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;<td>
                                                    &nbsp;</td>
                                                <td class="auto-style1">
                                                    <br />
                                                    <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" CssClass="Button" IFrameName="ifRoster" Interval="10" Text="Close" />
                                                </td>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
