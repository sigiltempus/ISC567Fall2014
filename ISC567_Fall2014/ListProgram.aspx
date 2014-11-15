<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListProgram.aspx.vb" Inherits="ISC567_Fall2014.ListProgram" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>List Program</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 325px;
            width: 940px;
        }

        .auto-style2 {
            width: 940px;
        }

        #form1 {
            width: 950px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="" CssClass="IFrameHeader" Width="100%">
                        <asp:Label ID="lblTitle" runat="server" Text="List Program" Width="90%" style="text-align: left;"></asp:Label>
                        <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifProgramList" Text="[X] Close" style="text-align: right" />
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical"
                                    BorderStyle="Solid" BorderColor="Black" BorderWidth="2px"
                                    class="auto-style1">
                                    <ccJSIM:OpenIFrameGridView ID="gvProgramList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ChangeRowColor="True" DataKeyNames="programid,shortname" ForeColor="#333333" FrameSrc="AddEditProgram.aspx" IncludeSorting="True"
                                        GridLines="None" GridSortColumn="ProgramName" GridSortDirection="ASC" HighlighedRowColor="Yellow" ShowEditButton="False"
                                        ShowDeleteButton="False" ShowSelectorButton="True" AllowSorting="True" GridDeleteButtonText="" GridEditButtonText="" Interval="" >
                                        <Columns>
                                            <asp:BoundField DataField="ProgramId" HeaderText="ProgramId" SortExpression="ProgramId" Visible="False" />
                                            <asp:BoundField DataField="shortname" HeaderText="Program Name" SortExpression="ProgramName" />
                                             <asp:BoundField DataField="longname" HeaderText="Program Full Name" SortExpression="ProgramName" />
                                            <asp:BoundField DataField="value" HeaderText="Program Status" SortExpression="ProgramStatus" />
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <AlternatingRowStyle BackColor="White" />
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
                <tr>
                    <td colspan="2">
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenAddProgram" runat="server" FrameSrc="AddEditProgram.aspx?mode=add&caller=lstProgram" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditProgram" Text="Add Program" LeftPosition="250" TopPosition="160" ZIndex="185" CssClass="Button" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenEditProgram" runat="server" FrameSrc="AddEditProgram.aspx?mode=edit&caller=lstProgram" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditProgram" Text="Edit Program" LeftPosition="250" TopPosition="160"  ZIndex="185" CssClass="Button" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnWorkOnExam" runat="server" FrameSrc="ExamProvider_7.aspx" HeightPosition="400" WidthPosition="575"
                            IFrameName="ifWorkOnExam" Text="Work On Exam" LeftPosition="250" TopPosition="170"  ZIndex="185" CssClass="Button" style="z-index: 1; top: 230px;  " Width="189px"/>
                         &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenBK" runat="server" FrameSrc="ListProgramBK.aspx" HeightPosition="320" WidthPosition="800"
                            IFrameName="ifListProgramBK" Text="Body Of Knowledge" LeftPosition="170" TopPosition="160" ZIndex="185" CssClass="Button" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenCourse" runat="server" FrameSrc="ListCourse.aspx" HeightPosition="500" WidthPosition="755"
                            IFrameName="ifCourseList" Text="Course" LeftPosition="250" TopPosition="160"  ZIndex="185" CssClass="Button"  />
                        &nbsp;
                         <ccJSIM:OpenIFrameButton ID="lbtnOpenProgramOutcome" runat="server" FrameSrc="ListProgramOutcome.aspx" HeightPosition="524" WidthPosition="724"
                            IFrameName="ifListProgramOutcome" Text="Program Outcome" LeftPosition="250" TopPosition="170" ZIndex="185" CssClass="Button" />
                         &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenProgramSkillClass" runat="server" FrameSrc="SkillClass.aspx" HeightPosition="280" WidthPosition="714"
                            IFrameName="ifProgramSkillClass" Text="Skill Class" LeftPosition="200" TopPosition="160"  ZIndex="185" CssClass="Button" />
                        <asp:Label ID="lblSpacer" runat="server" Text="  " Width="250px"></asp:Label>
                       
                        
                       
                       
                        &nbsp;
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
