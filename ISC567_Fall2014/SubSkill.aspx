﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SubSkill.aspx.vb" Inherits="ISC567_Fall2014.SubSkill" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SubSkill List</title>
    <link href="styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        `<div class="ListIFrame">
        <table align="left" width="700px" border="0px" cellpadding="0px" cellspacing="0px">
            <tr>
                <td align="left" class="IFrameHeader">
                    <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="List Sub Skill">
                    </ccJSIM:DragIFrame>
                </td>
                <td align="right" class="IFrameHeader">
                    <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="[x] Close"
                        IFrameName="IfSubSkill">
                    </ccJSIM:CloseIFrameButton>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="220px">
                        <%--DataKeyNames="skillsnum"--%>
                        <ccJSIM:RadioButtonGridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
                            IncludeSorting="True" EmptyDataText="No Data Found" GridSortColumn="" DataKeyNames="subskillid"
                            ForeColor="#333333" HighlighedRowColor="#FFFFAD" HeaderStyle-CssClass="gridViewHeader"
                            Width="650px" HeaderStyle-ForeColor="White">
                            <AlternatingRowStyle BackColor="#FFFFFF" />
                            <RowStyle BackColor="#EEEEEE" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Skill Num">
                                    <ItemTemplate>
                                        <asp:Label ID="lblskillsnum" runat="server" Text='<%# Eval("skillsid")%>' Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub Skill Num">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubskillnum" runat="server" Text='<%# Eval("subskillid")%>' Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub Skill Title ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("subskilltitle") %>' Width="550px"></asp:Label>
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
                <td colspan="2" class="style1">
                    <table>
                        <tr>
                            <td align="left">
                                <ccJSIM:OpenIFrameButton ID="btnAddSUbSkill" runat="server" Text="Add Sub Skill"
                                    FrameSrc="AddEditSubSkill.aspx?mode=add" IFrameName="IfAddEditSubSkill" HeightPosition="340"
                                    LeftPosition="425" ZIndex="300" TopPosition="210" WidthPosition="550" CssClass="Button" />
                            </td>
                            <td align="center">
                                <ccJSIM:OpenIFrameButton ID="btnEditSubSkill" runat="server" Text="Edit Sub Skill"
                                    FrameSrc="AddEditSubSkill.aspx?mode=edit" IFrameName="IfAddEditSubSkill" HeightPosition="340"
                                    LeftPosition="425" ZIndex="300" TopPosition="210" WidthPosition="550" CssClass="Button" />
                            </td>
                            <td align="right">
                            <ccJSIM:OpenIFrameButton ID="btnSubSkills" runat="server" Text="SubSkill in BK2" FrameSrc="SubSkillInBK.aspx"
                                IFrameName="ifSubskillBK" HeightPosition="325" LeftPosition="400" ZIndex="200" TopPosition="250"
                                WidthPosition="715" CssClass="Button" />

                                <ccJSIM:OpenIFrameButton ID="btnSKCourseOutcome" runat="server" Text="Course Outcomes SubSkill"
                                    FrameSrc="CourseOutcomeSubSkill.aspx" IFrameName="ifcrsOutSubskill" HeightPosition="380"
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
