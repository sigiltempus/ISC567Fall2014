<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListProgramBK.aspx.vb" Inherits="ISC567_Spring2013.ListProgramBK" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Body Of Knowledge</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        #form1 {
            width: 800px;
            height: 300px;
            margin-top: 0px;
        }
        .auto-style3 {
            font-size: 14pt;
            font-weight: bold;
            color: White;
            background-color: #ba1c1c;
            font-family: Verdana;
            padding: 5px 5px 5px 5px;
            width: 213px;
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
                        <ccJSIM:DragIFrame ID="lblCHeader" runat="server" Text="" CssClass="IFrameHeader" Width="100%">
                        <asp:Label ID="lblCTitle" runat="server" Text="List BkLevel1" Width="90%" style="text-align: left;"></asp:Label>
                        <ccJSIM:CloseIFrameButton ID="btnCSave" runat="server" IFrameName="ifListProgramBK" Text="[X] Close" style="text-align: right" />
                        </ccJSIM:DragIFrame>
                    </td>

            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="220px" Width="755px"
                        BorderStyle="Solid" BorderColor="Black" BorderWidth="2px">
                        <ccJSIM:RadioButtonGridView ID="ProjectsGridView" runat="server" AutoGenerateColumns="False"
                            IncludeSorting="True" EmptyDataText="No Data Found" DataKeyNames="BKLevel1ID"
                            ForeColor="#333333" HighlighedRowColor="255, 255, 173" HeaderStyle-CssClass="gridViewHeader"
                            Width="689px" HeaderStyle-ForeColor="White" ChangeRowColor="True" GridSortDirection="ASC" ShowSelectorButton="True" Height="163px" GridSortColumn="">
                            <AlternatingRowStyle BackColor="#FFFFFF" />
                            <RowStyle BackColor="#EEEEEE" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Body Of Knowledge Level1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumberL1" runat="server" Text='<%# Eval("NumberL1")%>'
                                            Width="2px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title")%>' Width="630 px"></asp:Label>
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
                            <td >
                                <ccJSIM:OpenIFrameButton ID="btnAddBKLevel1" runat="server" Text="Add Bklevel1"
                                    FrameSrc="AddEditBKLevel1.aspx?mode=add" IFrameName="IfAddEditBKLevel1" HeightPosition="327"
                                    LeftPosition="300" ZIndex="230" TopPosition="215" WidthPosition="704" CssClass="Button" Width="100px" />
                                &nbsp;
                                <ccJSIM:OpenIFrameButton ID="btnEditBKLevel1" runat="server" Text="Edit Bklevel1"
                                    FrameSrc="AddEditBKLevel1.aspx?mode=edit" IFrameName="IfAddEditBKLevel1"
                                    HeightPosition="327" LeftPosition="300" ZIndex="230" TopPosition="215" WidthPosition="704"
                                    CssClass="Button" Width="100px" />
                                <asp:Label ID="lblCSpacer" runat="server" Text="  " Width="250px"></asp:Label>
                        &nbsp;

                                <ccJSIM:OpenIFrameButton ID="btnSkills" runat="server" Text="Go To BKLevel2" FrameSrc="ListProgramBK2.aspx?mode=edit"
                                    IFrameName="IfListProgramBK2" HeightPosition="342" LeftPosition="360" Style="left: 4px"
                                    ZIndex="230" TopPosition="230" WidthPosition="755" CssClass="Button" Width="100px" />
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
