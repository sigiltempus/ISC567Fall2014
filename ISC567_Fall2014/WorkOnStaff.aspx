<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WorkOnStaff.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_4" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 325px;
            width: 940px;
        }

        .auto-style2 {
            width: 570px;
        }

        #form1 {
            width: 570px;
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
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="" CssClass="IFrameHeader" Width="99.5%">
                        <asp:Label ID="lblTitle" runat="server" Text="Choose An Exam Provider Staff" Width="90%" style="text-align: left;"></asp:Label>
<%--                        <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifExamProviderFunctions" Text="[X] Close" style="text-align: right" />--%>
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
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" width="99.5%"
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="180px">
                                <%--<ccJSIM:CheckboxGridView ID="gvExamProviderStaff" runat="server" AutoGenerateColumns="False" CheckedIdentifier="" GridSortDirection="ASC" IncludeSorting="True" ShowHeaderCheckbox="True" UseAjax="False">
                                    <Columns>
                                        <asp:BoundField AccessibleHeaderText="Staff Name" HeaderText="Name" />
                                        <asp:BoundField AccessibleHeaderText="EPSA" HeaderText="EPSA" />
                                        <asp:BoundField HeaderText="Developer" />
                                      <%--<asp:BoundField HeaderText="PrStaff" />
                                    </Columns>
                                </ccJSIM:CheckboxGridView>--%>


                                <ccJSIM:RadioButtonGridView ID="staffGridView" runat="server" CellPadding="4" 
                                    ChangeRowColor="True" ForeColor="#333333" GridLines="None" GridSortDirection="ASC" 
                                    HighlighedRowColor="" IncludeSorting="True" ShowSelectorButton="True" 
                                    AutoGenerateColumns="False" Height="97%" width="99%" DataKeyNames="examproviderstaffid" GridSortColumn="">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="examproviderstaffid" HeaderText="examProviderStaffID" Visible="false" />
                                        <asp:BoundField DataField="personName" HeaderText="Staff Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:CheckBoxField DataField="isEPSA" HeaderText="isEPSA" ReadOnly="true">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:CheckBoxField>
                                        <asp:CheckBoxField DataField="isdeveloper" HeaderText="isDeveloper" ReadOnly="true">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:CheckBoxField>
                                    </Columns>                                  
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </ccJSIM:RadioButtonGridView>

                            </asp:Panel>
                        </ContentTemplate>
						</asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton1" runat="server" FrameSrc="AddStaff.aspx?mode=add" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditPerson" Text="Add Staff" LeftPosition="250" TopPosition="160" ZIndex="190" CssClass="Button" style="z-index: 1; left: 26px; top: 230px; position: absolute; width: 113px;" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="EditProvider" runat="server" FrameSrc="AddStaff.aspx?mode=edit" HeightPosition="424" WidthPosition="704"
                            IFrameName="ifAddEditPerson" Text="Edit Staff" LeftPosition="250" TopPosition="160"  ZIndex="190" CssClass="Button" style="z-index: 1; left: 152px; top: 230px; position: absolute; width: 103px;" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton3" runat="server" FrameSrc="ExamProvider_7.aspx" IFrameName="ifWorkOnExam" Text="Work On Exam"
    						HeightPosition="378" LeftPosition="240" TopPosition="160" WidthPosition="575" ZIndex="180" CssClass="Button" style="z-index: 1; top: 230px; position: absolute; width: 201px;"/>
						&nbsp;
						<ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text ="Close" IFrameName="WorkOnStaff" Interval="10" 
						PostBackUrl="ExamProvider_1A.aspx" CssClass="Button" style="z-index: 1; left: 479px; top: 230px; position: absolute; width: 63px;"/>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
