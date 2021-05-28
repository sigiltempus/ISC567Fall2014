<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Listsociety.aspx.vb" Inherits="ISC567_Fall2014.Listsociety" %>



<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>List Curriculum</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 325px;
            width: 940px;
        }

        .auto-style2 {
            width: 941px;
        }

        #form1 {
            width: 950px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="CScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblCHeader" runat="server" Text="" CssClass="IFrameHeader" Width="100%">
                        <asp:Label ID="lblCTitle" runat="server" Text="List society" Width="90%" style="text-align: left;"></asp:Label>
                        <ccJSIM:CloseIFrameButton ID="btnCSave" runat="server" IFrameName="ifsocietylist" Text="[X] Close" style="text-align: right" />
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblCErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="CPanel1" runat="server" ScrollBars="Vertical"
                                    BorderStyle="Solid" BorderColor="Black" BorderWidth="2px"
                                    class="auto-style1">
                                    <ccJSIM:OpenIFrameGridView ID="gvsocietyList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ChangeRowColor="True" DataKeyNames="societyid,shortname" ForeColor="#333333" FrameSrc="AddEditsociety.aspx" IncludeSorting="True"
                                        GridLines="None" GridSortColumn="societyName" GridSortDirection="ASC" HighlighedRowColor="Yellow" ShowEditButton="False"
                                        ShowDeleteButton="False" ShowSelectorButton="True" AllowSorting="True" GridDeleteButtonText="" GridEditButtonText="" Interval="" >
                                        <Columns>
                                            <asp:BoundField DataField="societyid" HeaderText="societyId" SortExpression="societyId" Visible="False" />
                                            <asp:BoundField DataField="shortname" HeaderText="society Name" SortExpression="societyName" />
                                            <asp:BoundField DataField="longname" HeaderText="society Full Name" SortExpression="societyFullName" />
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
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenAddsociety" runat="server" FrameSrc="AddEditsociety.aspx?mode=add&caller=lstsociety" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditsociety" Text="Add society" LeftPosition="250" TopPosition="180" ZIndex="190" CssClass="Button" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenEditsociety" runat="server" FrameSrc="AddEditsociety.aspx?mode=edit&caller=lstsociety" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditsociety" Text="Edit society" LeftPosition="250" TopPosition="160"  ZIndex="190" CssClass="Button" />
                        &nbsp;
                        <asp:Label ID="lblCSpacer" runat="server" Text="  " Width="250px"></asp:Label>
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnOpensociety" runat="server" FrameSrc="Listsponsor.aspx" HeightPosition="430" WidthPosition="955" Visible="true"
                            IFrameName="ifsponsorlist" Text="sponsor" LeftPosition="170" TopPosition="160" ZIndex="190" CssClass="Button" />
                        &nbsp;
                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

