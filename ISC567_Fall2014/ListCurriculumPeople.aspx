<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListCurriculumpeople.aspx.vb" Inherits="ISC567_Fall2014.ListCurriculumpeople" %>
<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>List Curriculum People</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 325px;
            width: 940px;
        }

        .auto-style2 {
            width: 940px;
        }

        #form1 {
            width: 950px;
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
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="" CssClass="IFrameHeader" Width="100%">
                        <asp:Label ID="lblTitle" runat="server" Text="List Curriculum People" Width="90%" style="text-align: left;"></asp:Label>
                        <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifListCurriculumPeople" Text="[X] Close" style="text-align: right" />
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical"
                                    BorderStyle="Solid" BorderColor="Black" BorderWidth="2px"
                                    class="auto-style1">
                                    <ccJSIM:OpenIFrameGridView ID="gvListCurriculumPeople" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ChangeRowColor="True" DataKeyNames="personid" ForeColor="#333333" FrameSrc="ListCurriculum.aspx" IncludeSorting="True"
                                        GridLines="None" GridSortColumn="LastName" GridSortDirection="ASC" HighlighedRowColor="Yellow" ShowEditButton="False"
                                        ShowDeleteButton="False" ShowSelectorButton="True" AllowSorting="True" GridDeleteButtonText="" GridEditButtonText="" Interval="" Width="821px" >
                                        <Columns>
                                            <asp:BoundField DataField="personid" HeaderText="personID" SortExpression="personid" Visible="False" />
                                            <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname" />
                                            <asp:BoundField DataField="firstname" HeaderText="First Name" SortExpression="firstname" />
                                            
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
                    <td colspan="2">
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenAddCurriculumPerson" runat="server" FrameSrc="AddEditPerson.aspx?mode=add&caller=lstPerson" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditPerson" Text="Add Curriculum Person" LeftPosition="375" TopPosition="160" ZIndex="185" CssClass="Button" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenEditCurriculumPerson" runat="server" FrameSrc="AddEditPerson.aspx?mode=edit&caller=lstPerson" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditPerson" Text="Edit Curriculum Person" LeftPosition="375" TopPosition="160"  ZIndex="185" CssClass="Button" />
                        &nbsp;
                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

