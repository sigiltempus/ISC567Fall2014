<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Listsponsor.aspx.vb" Inherits="ISC567_Spring2013.Listsponsor" %>
<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>List Sponsor</title>
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
                        <asp:Label ID="lblCTitle" runat="server" Text="List Sponsor" Width="90%" style="text-align: left;"></asp:Label>
                        <ccJSIM:CloseIFrameButton ID="btnCSave" runat="server" IFrameName="ifsponsorlist" Text="[X] Close" style="text-align: right" />
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
                                    <ccJSIM:OpenIFrameGridView ID="gvsponsorList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ChangeRowColor="True" DataKeyNames="sponsorid,shortname" ForeColor="#333333" FrameSrc="AddEditSponsor.aspx" IncludeSorting="True"
                                        GridLines="None" GridSortColumn="Curriculum Name" GridSortDirection="ASC" HighlighedRowColor="Yellow" ShowEditButton="False"
                                        ShowDeleteButton="False" ShowSelectorButton="True" AllowSorting="True" GridDeleteButtonText="" GridEditButtonText="" Interval="" >
                                        <Columns>
                                            <asp:BoundField DataField="sponsorid" HeaderText="SponsorId" SortExpression="SponsorId" Visible="False" />
                                            <asp:BoundField DataField="curriculum_longname" HeaderText="Curriculum Name" SortExpression="CurriculumName" />
                                            <asp:BoundField DataField="longname" HeaderText="Society Name" SortExpression="SocietyName" />
                                             <asp:BoundField DataField="sponsored_on" HeaderText="Sponsored date" SortExpression="Sponsoreddate" />
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
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenAddSponsor" runat="server" FrameSrc="AddEditSponsor.aspx?mode=add&caller=lstSponsor" HeightPosition="330" WidthPosition="704"
                            IFrameName="ifAddEditSponsor" Text="Add Sponsor" LeftPosition="250" TopPosition="160" ZIndex="190" CssClass="Button" />
                        &nbsp;
                       <ccJSIM:OpenIFrameButton ID="lbtnOpenEditSponsor" runat="server" FrameSrc="AddEditSponsor.aspx?mode=edit&caller=lstSponsor" HeightPosition="330" WidthPosition="704"
                            IFrameName="ifAddEditSponsor" Text="Edit Sponsor" LeftPosition="250" TopPosition="160"  ZIndex="190" CssClass="Button" />
                        &nbsp;
                       
                        
                         </td>
                </tr>
            </table>
        </div>
</form>
</body>
</html>
