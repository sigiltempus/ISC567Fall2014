<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListProgramBK3.aspx.vb" Inherits="ISC567_Fall2014.ListProgramBK3" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LIST BK LEVEL 3</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />
    <style type="text/css">
        .auto-style1 {
            height: 325px;
            width: 740px;
        }

        .auto-style2 {
            width: 740px;
        }

        #form1 {
            width: 750px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="ListIFrame">
        <table class ="auto-style2">
            <tr>
                <td colspan="1" class="IFrameHeader">
                    <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="List BK LEVEL 3" style="text-align: left">
                    </ccJSIM:DragIFrame>
                </td>
                <td colspan ="1" class="IFrameHeader">
                <ccJSIM:CloseIFrameLinkButton ID="CloseIFrameLinkButton1" runat="server" Text="[x] Close" style="text-align: right"
                    ForeColor="White" BorderColor="White" IFrameName="IfListProgramBK3">
                </ccJSIM:CloseIFrameLinkButton>
            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="260px">
                        <ccJSIM:RadioButtonGridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
                            IncludeSorting="True" EmptyDataText="No Data Found" DataKeyNames="BKLevel3ID"
                            ForeColor="#333333" HighlighedRowColor="255, 255, 173" HeaderStyle-CssClass="gridViewHeader"
                            Width="650px" HeaderStyle-ForeColor="White" ChangeRowColor="True" GridSortDirection="ASC" ShowSelectorButton="True">
                            <AlternatingRowStyle BackColor="#FFFFFF" />
                            <RowStyle BackColor="#EEEEEE" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="BK Level1 Num">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumberL1" runat="server" Text='<%# Eval("NumberL1")%>'
                                            Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BK Level2 Num">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumberL2" runat="server" Text='<%# Eval("NumberL2")%>' Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BK Level3 Num">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumberL3" runat="server" Text='<%# Eval("NumberL3")%>' Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Title") %>' Width="550px"></asp:Label>
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
                        <td >
                            <ccJSIM:OpenIFrameButton ID="btnAddBKLevel3" runat="server" Text="Add BK Level3"
                                FrameSrc="AddEditBKLevel3.aspx?mode=add" IFrameName="IfAddEditBKLevel3"
                               HeightPosition="327" LeftPosition="400" ZIndex="260" TopPosition="210" WidthPosition="720"
                                CssClass="Button" />
                        </td>
                        <td >
                            <ccJSIM:OpenIFrameButton ID="btnEditBKLevel3" runat="server" Text="Edit BK Level3"
                                FrameSrc="AddEditBKLevel3.aspx?mode=edit" IFrameName="IfAddEditBKLevel3"
                                HeightPosition="327" LeftPosition="400" ZIndex="260" TopPosition="210" WidthPosition="720"
                                CssClass="Button" />
                        </td>
                        <td >
                            <ccJSIM:OpenIFrameButton ID="btnBKLevel4" runat="server" Text="Go To BKLevel4" FrameSrc="ListProgramBK4.aspx?mode=edit"
                                IFrameName="IfListProgramBK4" HeightPosition="330" LeftPosition="700" ZIndex="250" TopPosition="280"
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
