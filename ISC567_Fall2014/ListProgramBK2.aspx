<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListProgramBK2.aspx.vb" Inherits="ISC567_Spring2013.ListProgramBK2" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BK LEVEL2 LIST</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        
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
    <div class= "ListIFrame">
    <table class ="auto-style2">
        <tr>
             <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblCHeader" runat="server" Text="" CssClass="IFrameHeader" Width="100%">
                        <asp:Label ID="lblCTitle" runat="server" Text="List BkLevel2" Width="85%" style="text-align: left;"></asp:Label>
                        <ccJSIM:CloseIFrameButton ID="btnCSave" runat="server" IFrameName="IfListProgramBK2" Text="[X] Close" style="text-align: right" />
                        </ccJSIM:DragIFrame>
                    </td>
        </tr>
        <tr>
            <td colspan="2" >
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="260px" Width="750px"
                    BorderStyle="Solid" BorderColor="Black" BorderWidth="2px">
                    <ccJSIM:RadioButtonGridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
                        IncludeSorting="True" EmptyDataText="No Data Found" DataKeyNames="BKLevel2ID"
                        ForeColor="#333333" HighlighedRowColor="255, 255, 173" HeaderStyle-CssClass="gridViewHeader"
                        Width="700px" HeaderStyle-ForeColor="White" ChangeRowColor="True" GridSortColumn="" GridSortDirection="ASC" ShowSelectorButton="True">
                        <AlternatingRowStyle BackColor="#FFFFFF" />
                        <RowStyle BackColor="#EEEEEE" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="BKLevel1 Num">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumberL1" runat="server" Text='<%# Eval("NumberL1")%>' Width="2px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BKLevel2 Num">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumberL2" runat="server" Text='<%# Eval("NumberL2")%>' Width="2px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title")%>' Width="590px"></asp:Label>
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
            <td colspan="2" class="auto-style2">
                <table>
                    <tr>
                        <td >
                            <ccJSIM:OpenIFrameButton ID="btnAddBKLevel2" runat="server" Text="Add BK Level2"
                                FrameSrc="AddEditBKLevel2.aspx?mode=add" IFrameName="IfAddEditBKLevel2"
                                HeightPosition="327" LeftPosition="400" ZIndex="240" TopPosition="210" WidthPosition="720"
                                CssClass="Button" Width="100px" />
                          &nbsp;
                            <ccJSIM:OpenIFrameButton ID="btnEditBKLevel2" runat="server" Text="Edit BK Level2"
                                FrameSrc="AddEditBKLevel2.aspx?mode=edit" IFrameName="IfAddEditBKLevel2"
                                HeightPosition="327"  LeftPosition="400" ZIndex="240" TopPosition="210" WidthPosition="720"
                                CssClass="Button" Width="100px" />
                        
                        <asp:Label ID="lblCSpacer" runat="server" Text="  " Width="250px"></asp:Label>
                        &nbsp;
                        
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
