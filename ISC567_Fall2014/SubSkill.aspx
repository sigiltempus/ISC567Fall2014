<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SubSkill.aspx.vb" Inherits="ISC567_Spring2013.SubSkill" %>

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
    <div class="ListIFrame">
        <table align="left" width="700px" border="0px" cellpadding="0px" cellspacing="0px">
            <tr>
                <td align="left" class="IFrameHeader">
                    <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="List Sub Skill">
                    </ccJSIM:DragIFrame>
                </td>
                <td align="right" class="IFrameHeader">
                    <ccJSIM:CloseIFrameLinkButton ID="CloseIFrameLinkButton1" runat="server" Text="[x] Close"
                        ForeColor="White" BorderColor="White" IFrameName="IfSubSkill">
                    </ccJSIM:CloseIFrameLinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="260px">
                        <ccJSIM:RadioButtonGridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
                            IncludeSorting="True" EmptyDataText="No Data Found" GridSortColumn="" DataKeyNames="subskillid"
                            ForeColor="#333333" HighlighedRowColor="#FFFFAD" HeaderStyle-CssClass="gridViewHeader"
                            Width="650px" HeaderStyle-ForeColor="White">
                            <AlternatingRowStyle BackColor="#FFFFFF" />
                            <RowStyle BackColor="#EEEEEE" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Skill Class Num">
                                    <ItemTemplate>
                                        <asp:Label ID="lblskillsclassnum" runat="server" Text='<%# Eval("skillsclassnum") %>'
                                            Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Skill Num">
                                    <ItemTemplate>
                                        <asp:Label ID="lblskillsnum" runat="server" Text='<%# Eval("skillsnum") %>' Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub Skill Num">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubskillnum" runat="server" Text='<%# Eval("subskillnum") %>' Width="2px"></asp:Label>
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
                                    FrameSrc="AddEditSubSkill.aspx?mode=add" IFrameName="IfAddEditSubSkill" HeightPosition="405"
                                    LeftPosition="400" ZIndex="300" TopPosition="210" WidthPosition="550" CssClass="Button" />
                            </td>
                            <td align="center">
                                <ccJSIM:OpenIFrameButton ID="btnEditSubSkill" runat="server" Text="Edit Sub Skill"
                                    FrameSrc="AddEditSubSkill.aspx?mode=edit" IFrameName="IfAddEditSubSkill" HeightPosition="405"
                                    LeftPosition="400" ZIndex="300" TopPosition="210" WidthPosition="550" CssClass="Button" />
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
