<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Roster.aspx.vb" Inherits="ISC567_Spring2013.Roster" %>

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
            width: 604px;
        }

        .style2 {
            width: 604px;
        }

        .auto-style1 {
            width: 274px;
        }
        .auto-style2 {
            width: 317px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        <div class="ListIFrame" style="width: 804px; height: 496px;">
            <table style="width: 100%;">
                <tr style="text-align: left">
                    <td colspan="2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="Exam in which you are involved" CanDragIFrame="True" CssClass="IFrameHeader" Visible="True" Width="98%">
                        </ccJSIM:DragIFrame>
                </tr>
                <tr>
                    <td colspan="2" valign="top">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical"
                                    BorderStyle="Solid" BorderColor="Black" BorderWidth="2px" Width="100%" Height="350px">
                                    <ccJSIM:OpenIFrameGridView ID="gvroster" runat="server" Width="100%"
                                        AutoGenerateColumns="False" CellPadding="4" ChangeRowColor="True"
                                        DataKeyNames="examid" ForeColor="#333333" FrameSrc="roster.aspx" GridLines="None"
                                        GridSortColumn="status" GridSortDirection="ASC" HeightPosition="300"
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
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="2px" Width="100%" Height="150px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="text-align: center; width: 98%">

                            <tr>

                                <td class="auto-style2">
                                    <ccJSIM:OpenIFrameButton ID="btnIfExamSchedule" Text="Schedule Another Exam" runat="server" CssClass="Button" IFrameName="ifScheduleExam" FrameSrc="ScheduleExamV2.aspx"
                                        HeightPosition="500" LeftPosition="20" TopPosition="120"
                                        WidthPosition="808" ZIndex="160" />
                                </td>

                                <td>
                                    <ccJSIM:OpenIFrameButton ID="btnifTakeExam" Text="Take The EXAM" runat="server" CssClass="Button" Width="98%" IFrameName="ifConfirmationPage" FrameSrc="ConfirmationPage.aspx"
                                        HeightPosition="504" LeftPosition="20" TopPosition="120" 
                                        WidthPosition="804" ZIndex="160" Enabled="False" />
                                </td>
                                <td class="auto-style1">
                                    <asp:Button ID="btnCancelExam" runat="server" Text="  cancel the scheduled exam"
                                        Width="190px" CssClass="Button" /></td>


                            </tr>
                            <tr>

                                <td class="auto-style2">
                                    <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" Text="Cancel" CssClass="Button" IFrameName="ifRoster" Interval="10" />

                                <td>
                                    &nbsp;</td>
                                <td class="auto-style1">
                                    <asp:Button ID="Button5" runat="server" CssClass="Button" Text="Logout" Width="139px" />
                                    </td>


                            </tr>

                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
