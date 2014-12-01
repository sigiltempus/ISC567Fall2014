<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CourseOutcomeSubSkill.aspx.vb" Inherits="ISC567_Fall2014.ProgramOutcomeSubSkill" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="Styles/IFrameStyles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="CheckBoxIFrame">
        <table cellpadding="0" cellspacing="0" width="650">
            <tr valign="top">
                <td align="left" class="IFrameHeader">
                    <ccJSIM:DragIFrame ID="lblHeader" runat="server" Width="100%" Text="Course OutCome SubSkill"> </ccJSIM:DragIFrame>
                </td>
                <td align="right" class="IFrameHeader">
                    <ccJSIM:CloseIFrameLinkButton runat="server" IFrameName="ifcrsOutSubskill" ID="lbtnclose"
                        Text="[x]Close"  BorderColor="White" ForeColor="white"></ccJSIM:CloseIFrameLinkButton>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="2" height="40">
                    <asp:Label ID="lblProgOutcome" runat="server" Height="25px" Text="For Course OutCome :" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="2">
                    <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="100%" BorderColor="Black"
                                BorderStyle="Solid" BorderWidth="2px" Height="475px">
                                <ccJSIM:CheckboxGridView ID="gvSubSkill" runat="server" CellPadding="4"
                                    ForeColor="#333333" GridLines="None" IncludeSorting="True" CheckedIdentifier="Checked"
                                    StatusPanelId="lblStatus" Width="99%" AutoGenerateColumns="False" DataKeyNames="subskillid" 
                                    AllowSorting="true" GridSortColumn="Checked" 
                                    CheckedMethodName="wsToggleSubskill" UnCheckedMethodName="wsToggleSubskill" UseAjax="False" EnableSortingAndPagingCallbacks="True"  >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Checked" HeaderText="Checked" Visible="False" /> 
                                        <asp:BoundField DataField="subskillcomb" HeaderText="Sub skill comb" SortExpression="fullname" />
                                        <asp:BoundField DataField="subskilltitle" HeaderText="Sub Skill" SortExpression="fullname" />
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
                                </ccJSIM:CheckboxGridView>
                            </asp:Panel>
                        </ContentTemplate>                 
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
