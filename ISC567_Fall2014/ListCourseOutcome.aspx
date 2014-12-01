<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListCourseOutcome.aspx.vb"
    Inherits="ISC567_Fall2014.ListCourseOutcome" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Program List</title>
    <link href="Styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Simplemenu.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #form1 {
            width: 735px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="ListIFrame">
        <table align="left" cellpadding="0" cellspacing="0" style="width: 720px;">
            <tr>
                <td colspan="2" class="auto-style2"">
                    <ccJSIM:DragIFrame ID="lblHeader" runat="server" CssClass="IFrameHeader" Width="99%" CanDragIFrame="True">
                        <asp:Label ID="lblTitle" runat="server" Text="List Course OutCome" Width="89%" style="text-align: left; padding: 0;"></asp:Label>
                    <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifListCourseOutcome" Width="9%" Text="[X] Close" style="text-align: right;" />
                    </ccJSIM:DragIFrame>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="710px" Height="380px">
                        <ccJSIM:RadioButtonGridView ID="gvCourseOutcome" runat="server" AutoGenerateColumns="False"
                            IncludeSorting="True" EmptyDataText="No Data Found" GridSortColumn="" DataKeyNames="crsoutcomesid"
                            ForeColor="#333333" HighlighedRowColor="#FFFFAD" HeaderStyle-CssClass="gridViewHeader"
                            Width="700px" HeaderStyle-ForeColor="White">
                            <AlternatingRowStyle BackColor="#FFFFFF" />
                            <RowStyle BackColor="#EEEEEE" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Outcome#" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCourseOutcomeId" runat="server" Text='<%# Eval("crsoutcomesid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course Outcome">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramName" runat="server" Text='<%# Eval("crsoutcometext") %>'
                                            Width="500px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prg Seq" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrgsequence" runat="server" Text='<%# Eval("crsoutcomenum") %>'
                                            Width="10px"></asp:Label>
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
                                <ccJSIM:OpenIFrameButton ID="btnAddCourseOutcome" runat="server" Text="Add Course Outcomes"
                                    FrameSrc="AddEditCourseOutcome.aspx?mode=add" IFrameName="ifAddCourseOutcomes"
                                    HeightPosition="400" LeftPosition="350" ZIndex="200" TopPosition="250" WidthPosition="600"
                                    CssClass="Button" />
                            </td>
                            <td align="center">
                                <ccJSIM:OpenIFrameButton ID="btnEditCourseoutcome" runat="server" Text="Edit Course Outcomes"
                                    FrameSrc="AddEditCourseOutcome.aspx?mode=edit" IFrameName="ifAddCourseOutcomes"
                                    HeightPosition="400" LeftPosition="350" ZIndex="200" TopPosition="250" WidthPosition="600"
                                    CssClass="Button" />
                            </td>
                            <td align="center">
                                <ccJSIM:OpenIFrameButton ID="btncrseprgoutcome" runat="server" Text="Course Outcomes to  Program Outcomes"
                                    FrameSrc="CrseOutcomePrrOutcome.aspx" IFrameName="ifCrseprgOutcome" HeightPosition="800"
                                    LeftPosition="360" ZIndex="180" TopPosition="120" WidthPosition="600" CssClass="Button" />
                            </td>
                              <td align="center">
                                <ccJSIM:OpenIFrameButton ID="OpenIFrameButton1" runat="server" Text="Course Outcomes SubSkill"
                                    FrameSrc="CourseOutcomeSubSkill.aspx" IFrameName="ifcrsOutSubskill" HeightPosition="500"
                                    LeftPosition="330" ZIndex="225" TopPosition="260" WidthPosition="653" CssClass="Button" />
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
