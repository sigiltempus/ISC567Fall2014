<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExamProvider_1A.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_1A" %>

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
                        <asp:Label ID="lblTitle" runat="server" Text="Choose An Exam Provider" Width="90%" style="text-align: left;"></asp:Label>
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ScrollBars="Vertical" CssClass="PanelStyle" >
                        <ContentTemplate>
                            <asp:Panel ID="SAView" runat="server" ScrollBars="Vertical" width="99.5%"
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="180px">

                                <ccJSIM:RadioButtonGridView ID="gvExamProvider" runat="server" CellPadding="4" 
                                    ChangeRowColor="True" ForeColor="#333333" GridLines="None" GridSortDirection="ASC" 
                                    HighlighedRowColor="" IncludeSorting="True" ShowSelectorButton="True" 
                                    AutoGenerateColumns="False" Height="97%" DataKeyNames="providerid" Width="99%">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="providerid" HeaderText="providerid" Visible="False" />
                                        <asp:BoundField HeaderText="Exam Provider" DataField="name" SortExpression="name" />
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
                        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton2" runat="server" FrameSrc="AddProvider.aspx?mode=add" HeightPosition="360" WidthPosition="704"
                            IFrameName="ifExamProvider_1A" Text="Add Provider" LeftPosition="110" TopPosition="160" ZIndex="180" CssClass="Button" style="z-index: 1; left: 26px; top: 230px; position: absolute; width: 113px;" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton3" runat="server" FrameSrc="AddProvider.aspx?mode=edit" HeightPosition="360" WidthPosition="704"
                            IFrameName="ifExamProvider_1A" Text="Edit Provider" LeftPosition="110" TopPosition="160"  ZIndex="180" CssClass="Button" style="z-index: 1; left: 152px; top: 230px; position: absolute; width: 103px;" />
                        &nbsp;
                        <ccJSIM:OpenIFrameButton ID="workOnProvider" runat="server" FrameSrc="WorkOnStaff.aspx" IFrameName="WorkOnStaff" Text="Work On Provider Staff"
    						HeightPosition="260" LeftPosition="110" TopPosition="160" WidthPosition="580" ZIndex="180" CssClass="Button" style="z-index: 1; top: 230px; position: absolute; width: 201px;"/>
						&nbsp;
						<ccJSIM:CloseIFrameButton ID="btnClose" runat="server" Text ="Close" IFrameName="ifExamProviderFunctions" Interval="10" 
						PostBackUrl="~/MainMenu.aspx" CssClass="Button" style="z-index: 1; left: 479px; top: 230px; position: absolute; width: 63px;"/>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
