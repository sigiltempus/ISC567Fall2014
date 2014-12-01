<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListCourse.aspx.vb" Inherits="ISC567_Fall2014.ListCourse" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Course List</title>
    <link href="Styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 356px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="ListIFrame" >
        <table style="height: 400px; width: 751px;">
            <tr>

                <td colspan="2" class="auto-style2"">
                    <ccJSIM:DragIFrame ID="lblHeader" runat="server" CssClass="IFrameHeader" Width="99%" CanDragIFrame="True">
                        <asp:Label ID="lblTitle" runat="server" Text="List Course" Width="89%" style="text-align: left; padding: 0;"></asp:Label>
                    <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifCourseList" Width="9%" Text="[X] Close" style="text-align: right;" />
                    </ccJSIM:DragIFrame>
                </td>
          
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Label ID="lblMesage" runat="server" Text="Courses for Program :" ForeColor="Green"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left" class="auto-style1">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="720px" Height="396">
                        <ccJSIM:RadioButtonGridView ID="gvCourse" runat="server" AutoGenerateColumns="False"
                            IncludeSorting="True" EmptyDataText="No Data Found" GridSortColumn="" DataKeyNames="courseid"
                            ForeColor="#333333" HighlighedRowColor="#FFFFAD" HeaderStyle-CssClass="gridViewHeader"
                            Width="700px" HeaderStyle-ForeColor="White">
                            <AlternatingRowStyle BackColor="#FFFFFF" />
                            <RowStyle BackColor="#EEEEEE" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Crse#" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCourseID" runat="server" Text='<%# Eval("CourseId") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramName" runat="server" Text='<%# Eval("longtitle") %>' Width="280px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year In Prog">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYear" runat="server" Text='<%# Eval("yearinprog") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prg Seq" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrgsequence" runat="server" Text='<%# Eval("shorttitle") %>' Width="10px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="gridViewHeader" />
                            <RowStyle BackColor="White" />
                        </ccJSIM:RadioButtonGridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td align="left">
                                <ccJSIM:OpenIFrameButton ID="btnAddCourse" runat="server" Text="Add Course"
                                    FrameSrc="AddEditCourse.aspx?mode=add" IFrameName="ifAddCourse" HeightPosition="425"
                                    LeftPosition="250" ZIndex="200" TopPosition="180" WidthPosition="550" CssClass="Button" />
                            </td>
                            <td align="center">
                                <ccJSIM:OpenIFrameButton ID="btnEditCourse" runat="server" Text="Edit Course"
                                    FrameSrc="AddEditCourse.aspx?mode=edit" IFrameName="ifAddCourse" HeightPosition="425"
                                    LeftPosition="250" ZIndex="200" TopPosition="180" WidthPosition="550" CssClass="Button" />
                            </td>
                            
                            <td align="left">
                                <ccJSIM:OpenIFrameButton ID="btnGotoCourseOutCome" runat="server" Text="Go To Course Outcome"
                                    FrameSrc="ListCourseOutcome.aspx" IFrameName="ifListCourseOutcome" HeightPosition="450"
                                    LeftPosition="270" ZIndex="200" TopPosition="50" WidthPosition="725" CssClass="Button" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
