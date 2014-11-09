<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListPerson.aspx.vb" Inherits="ISC567_Spring2013.ListPerson" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>List Person</title>
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
                        <asp:Label ID="lblTitle" runat="server" Text="List Person" Width="90%" style="text-align: left;"></asp:Label>
                        <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifPersonList" Text="[X] Close" style="text-align: right" />
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
                                    <ccJSIM:OpenIFrameGridView ID="gvPersonList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ChangeRowColor="True" DataKeyNames="personID" ForeColor="#333333" FrameSrc="AddEditUser.aspx" IncludeSorting="True"
                                        GridLines="None" GridSortColumn="LastName" GridSortDirection="ASC" HighlighedRowColor="Yellow" ShowEditButton="False"
                                        ShowDeleteButton="False" ShowSelectorButton="True" AllowSorting="True" GridDeleteButtonText="" GridEditButtonText="" Interval="" >
                                        <Columns>
                                            <asp:BoundField DataField="personID" HeaderText="personID" SortExpression="personID" Visible="False" />
                                            <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname" />
                                            <asp:BoundField DataField="firstname" HeaderText="First Name" SortExpression="firstname" />
                                            <asp:BoundField DataField="institutionName" HeaderText="Institution Name" SortExpression="institutionName" />
                                            <asp:CheckBoxField DataField="isSA" HeaderText="SA" SortExpression="isSA"/>
                                            <asp:CheckBoxField DataField="isProvider" HeaderText="Provider" SortExpression="isProvider" />
                                            <asp:CheckBoxField DataField="isEPSA" HeaderText="EPSA" SortExpression="isEPSA" />
                                            <asp:CheckBoxField DataField="isDeveloper" HeaderText="Dev" SortExpression="isDeveloper" />
                                            <asp:CheckBoxField DataField="isInstitution" HeaderText="Inst" SortExpression="isInstitution" />
                                            <asp:CheckBoxField DataField="isISA" HeaderText="ISA" SortExpression="isISA" />
                                            <asp:CheckBoxField DataField="isProctor" HeaderText="Proctor" SortExpression="isProctor" />
                                            <asp:CheckBoxField DataField="isReports" HeaderText="Rpt" SortExpression="isReports" />
                                            <asp:CheckBoxField DataField="isTaker" HeaderText="Taker" SortExpression="isTaker" />
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
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenAddPerson" runat="server" FrameSrc="AddEditPerson.aspx?mode=add&caller=lstPerson" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditPerson" Text="Add Person" LeftPosition="250" TopPosition="160" ZIndex="110" CssClass="Button" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="lbtnOpenEditPerson" runat="server" FrameSrc="AddEditPerson.aspx?mode=edit&caller=lstPerson" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditPerson" Text="Edit Person" LeftPosition="250" TopPosition="160"  ZIndex="110" CssClass="Button" />
                        &nbsp;
                        <asp:Button ID="btnDeletePerson" runat="server" Text="Delete Person" OnClick="btnDeletePerson_Click" CssClass="Button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
