﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SkillClass.aspx.vb" Inherits="ISC567_Fall2014.SkillClass" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SkillClass List</title>
    <link href="styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="ListIFrame">
        <table align="left" width="700px" border="0px" cellpadding="0px" cellspacing="0px">
            <tr>
                <td align="left" class="IFrameHeader">
                    <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="List Skill Class" CssClass="IFrameHeader">
                    </ccJSIM:DragIFrame>
                </td>
                <td align="right" class="IFrameHeader">
                    <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="[x] Close"
                        IFrameName="ifProgramSkillClass">
                    </ccJSIM:CloseIFrameButton>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="Left">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="220px">
                        <ccJSIM:RadioButtonGridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
                            IncludeSorting="True" EmptyDataText="No Data Found" GridSortColumn="" DataKeyNames="skillclassid"
                            ForeColor="#333333" HighlighedRowColor="#FFFFAD" HeaderStyle-CssClass="gridViewHeader"
                            Width="650px" HeaderStyle-ForeColor="White">
                            <AlternatingRowStyle BackColor="#FFFFFF" />
                            <RowStyle BackColor="#EEEEEE" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Skill Class Num">
                                    <ItemTemplate>
                                            <asp:Label ID="lblSkillsclassnum" runat="server" Text='<%# Eval("skillclassid") %>'
                                            Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Skill Class Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("scname") %>' Width="630 px"></asp:Label>
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
                    <table width="700px">
                        <tr>
                            <td align="left">
                                <ccJSIM:OpenIFrameButton ID="btnAddSkillClass" runat="server" Text="Add Skill Class"
                                    FrameSrc="AddEditSkillClass.aspx?mode=add" IFrameName="IfAddEditSkillClass" HeightPosition="186"
                                    LeftPosition="250" ZIndex="300" TopPosition="215" WidthPosition="555" CssClass="Button" />

                                <ccJSIM:OpenIFrameButton ID="btnEditSkillClass" runat="server" Text="Edit Skill Class"
                                    FrameSrc="AddEditSkillClass.aspx?mode=edit" IFrameName="IfAddEditSkillClass"
                                    HeightPosition="186" LeftPosition="250" ZIndex="300" TopPosition="215" WidthPosition="555"
                                    CssClass="Button" />

                                <ccJSIM:OpenIFrameButton ID="btnSkills" runat="server" Text="Go To Skill" FrameSrc="Skills.aspx?mode=edit"
                                    IFrameName="IfSkills" HeightPosition="318" LeftPosition="250" Style="left: 0px"
                                    ZIndex="200" TopPosition="200" WidthPosition="711" CssClass="Button" />
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
