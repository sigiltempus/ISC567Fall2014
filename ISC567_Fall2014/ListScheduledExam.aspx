<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListScheduledExam.aspx.vb" Inherits="ISC567_Fall2014.ListScheduledExam" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>List Exams</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 430px;
            width: 890px;
        }

        .auto-style2 {
            width: 890px;
        }

        #form1 {
            width: 900px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div class="ListIFrame">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="" CssClass="IFrameHeader" CanDragIFrame="True" Width="100%">
                            <asp:Label ID="lblTitle" runat="server" Text="Scheduled Exam" Width="90%" style="text-align: left;">
                            </asp:Label>
                            <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" Interval="10" IFrameName="ifListScheduledExam" Text="[X] Close" style="text-align: right;" />
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="Panel2" runat="server" Width="100%" Height="25px" CssClass="PanelStyle">
                            <asp:RadioButtonList ID="rblSelect" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Visible="true"
                                 OnSelectedIndexChanged="rblSelect_SelectedIndexChanged" >
                            </asp:RadioButtonList>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="100%" Height="320px" CssClass="PanelStyle">
                                    <ccJSIM:RadioButtonGridView ID="gvExamList" runat="server" AutoGenerateColumns="False" ChangeRowColor="True" 
                                        GridSortColumn="status" GridSortDirection="DESC" HighlighedRowColor="" IncludeSorting="True" ShowSelectorButton="True" 
                                        DataKeyNames="scheduledexamid" AllowSorting="True" CheckedIdentifier="isSA" UseAjax="False" OnSelectedIndexChanged="gvExamList_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="scheduledexamid" HeaderText="scheduledexamid" SortExpression="scheduledexamid" Visible="False" />
                                            <asp:BoundField DataField="examname" HeaderText="Exam" SortExpression="examname" />
                                            <asp:BoundField DataField="examlocation" HeaderText="Location" SortExpression="examlocation" />
                                            <asp:BoundField DataField="examdate" HeaderText="Exam Date" SortExpression="examdate" />
                                            <asp:BoundField DataField="examtime" HeaderText="Exam Time" SortExpression="examtime" />
                                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                                        </Columns>
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <SelectedRowStyle BackColor="#FFFF66" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </ccJSIM:RadioButtonGridView>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;">
                        <ccJSIM:OpenIFrameButton ID="btnScheduleExam" runat="server" CssClass="Button" FrameSrc="AddEditExamSchedule.aspx?mode=add" 
                            IFrameName="ifAddEditExamSchedule" Text="Schedule An Exam" 
                            HeightPosition="240" WidthPosition="600" LeftPosition="310" TopPosition="180" ZIndex="160" />
                        <ccJSIM:OpenIFrameButton ID="btnEditSchedule" runat="server" CssClass="Button" FrameSrc="AddEditExamSchedule.aspx?mode=edit" 
                            IFrameName="ifAddEditExamSchedule" Text="Edit Exam Schedule" 
                            HeightPosition="240" WidthPosition="600" LeftPosition="310" TopPosition="180" ZIndex="160" />
                    </td>
                    <td style="text-align:right;">                        
                        <ccJSIM:OpenIFrameButton ID="btnProctor" runat="server" CssClass="Button" FrameSrc="ProctorExam.aspx" 
                            IFrameName="ifProctorExam" Text="Proctor" HeightPosition="429" WidthPosition="779" LeftPosition="460" TopPosition="160" ZIndex="200" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
