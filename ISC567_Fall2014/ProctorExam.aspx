<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProctorExam.aspx.vb" Inherits="ISC567_Spring2013.ProctorExam" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Proctor</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 288px;
            width: 765px;
        }

        .auto-style2 {
            width: 765px;
        }

        .gridHeader {
            text-align: left;
        }

        #form1 {
            width: 775px;
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
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="" CssClass="IFrameHeader" Width="100%" CanDragIFrame="True">
                            <asp:Label ID="lblTitle" runat="server" Text="Proctor" Width="88%" style="text-align: left;"></asp:Label>
                            <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifProctorExam" Text="[X] Close" style="text-align: right" />
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblExam" runat="server" Text="" Width="30%"></asp:Label>
                        <asp:Label ID="lblLoc" runat="server" Text="" Width="30%"></asp:Label>
                        <asp:Label ID="lblDatetime" runat="server" Text="" Width="25%"></asp:Label>
                        <asp:Label ID="lblStatus" runat="server" Text="" Width="15%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblPassword" runat="server" Text="Password" Width="15%"></asp:Label>
                        <asp:Button ID="btnShow" runat="server" Text="SHOW" Width="15%" />
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="3" Width="15%"></asp:TextBox>
                        <asp:Label ID="lblMinsToGo" runat="server" Text="MINS TO GO" Width="15%"></asp:Label>
                        <asp:Label ID="timerCount" runat="server" Text=" " Width="100px"></asp:Label>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Label ID="lblTime" runat="server" Text="Timer not refreshed yet." Width="25%"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblListStatus" runat="server" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>--%>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical"
                                    BorderStyle="Solid" BorderColor="Black" BorderWidth="2px" class="auto-style1" >
                                    <asp:GridView ID="gvAssignedUsers" runat="server" AutoGenerateColumns="False" AllowSorting="True">
                                        <Columns>
                                            <asp:BoundField DataField="takerid" HeaderText="takerid" SortExpression="takerid" Visible="False" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                            <asp:TemplateField HeaderText="Is Present">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="validated" runat="server" Checked='<%# Bind("validated") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="validated" runat="server" Checked='<%# Bind("validated") %>' Enabled="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                                            <asp:BoundField DataField="score" HeaderText="Score" SortExpression="score" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Button ID="checkIn" runat="server" Text="Check In" OnClick="checkIn_Click" />
                                </asp:Panel>
                            </ContentTemplate>
                            <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                            </Triggers>--%>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>