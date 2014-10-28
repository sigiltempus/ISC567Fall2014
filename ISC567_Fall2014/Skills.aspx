<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Skills.aspx.vb" Inherits="ISC567_Fall2014.Skills" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Skills List</title>
    <link href="styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css">
        .auto-style1
        {
            font-size: 14pt;
            font-weight: bold;
            color: White;
            background-color: #ba1c1c;
            font-family: Verdana;
            padding: 5px 5px 5px 5px;
            width: 136px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        z<div class= "ListIFrame">
    <table align="left" width="700px" border="0px" cellpadding="0px" cellspacing="0px">
        <tr>
            <td align="left" class="auto-style1">
                <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="List Skill">
                </ccJSIM:DragIFrame>
            </td>
            <td align="right" class="IFrameHeader">
                <ccJSIM:CloseIFrameLinkButton ID="CloseIFrameLinkButton1" runat="server" Text="[x] Close"
                    ForeColor="White" BorderColor="White" IFrameName="IfSkills">
                </ccJSIM:CloseIFrameLinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="260px">
                    <ccJSIM:RadioButtonGridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
                        IncludeSorting="True" EmptyDataText="No Data Found" DataKeyNames="skillsid"
                        ForeColor="#333333" HighlighedRowColor="255, 255, 173" HeaderStyle-CssClass="gridViewHeader"
                        Width="650px" HeaderStyle-ForeColor="White" 
                        EnableModelValidation="True">
                        <AlternatingRowStyle BackColor="#FFFFFF" />
                        <RowStyle BackColor="#EEEEEE" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Skill Class Num">
                                <ItemTemplate>
                                    <asp:Label ID="lblskillsclassnum" runat="server" Text='<%# Eval("skillsclassnum") %>' Width="2px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Skill Num">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("skillsnum")%>' Width="2px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Skill Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusProgram" runat="server" Text='<%# Eval("skillsname")%>' Width="590px"></asp:Label>
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
                            <ccJSIM:OpenIFrameButton ID="btnAddSkills" runat="server" Text="Add Skill"
                                FrameSrc="AddEditSkills.aspx?mode=add" IFrameName="IfAddEditSkills"
                                HeightPosition="300" LeftPosition="400" ZIndex="300" TopPosition="320" WidthPosition="520"
                                CssClass="Button" />
                        </td>
                        <td align="center">
                            <ccJSIM:OpenIFrameButton ID="btnEditSkills" runat="server" Text="Edit Skill"
                                FrameSrc="AddEditSkills.aspx?mode=edit" IFrameName="IfAddEditSkills"
                                HeightPosition="300"  LeftPosition="400" ZIndex="300" TopPosition="320" WidthPosition="520"
                                CssClass="Button" />
                        </td>
                        <td align="right">
                            <ccJSIM:OpenIFrameButton ID="btnSkills" runat="server" Text="Go To Sub Skill" FrameSrc="SubSkill.aspx?mode=edit"
                                IFrameName="IfSubSkill" HeightPosition="450" LeftPosition="450" ZIndex="200" TopPosition="250"
                                WidthPosition="715" CssClass="Button" />
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

