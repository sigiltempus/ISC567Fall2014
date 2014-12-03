<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SubSkillInBK.aspx.vb" Inherits="ISC567_Fall2014.SubSkillInBK" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SubSkillInBK List</title>
    <link href="styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            font-size: 14pt;
            font-weight: bold;
            color: White;
            background-color: #ba1c1c;
            font-family: Verdana;
            padding: 5px 5px 5px 5px;
            width: 264px;
        }
        .auto-style3 {
            font-size: 14pt;
            font-weight: bold;
            color: White;
            background-color: #ba1c1c;
            font-family: Verdana;
            padding: 5px 5px 5px 5px;
            width: 415px;
        }
        .auto-style5 {
            height: 41px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager ID="Scriptmanager1" runat="server" EnablePageMethods="True"></asp:scriptmanager>
      <div class="ListIFrame">
         <table align="left" width="700px" border="0px" cellpadding="0px" cellspacing="0px" style="height: 518px">
             <tr>
                 <td align="left" class="auto-style1">
                     <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="List SubSkill In BK2" CssClass="IFrameHeader" Width="400" />

                 </td>
                 <td align="right" class="IFrameHeader">
                     <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="[x] Close"
                        IFrameName="ifSubskillBK">
                    </ccJSIM:CloseIFrameButton>
                 </td>
             </tr>
             <tr valign="middle">
                <td colspan="2" class="auto-style5">
                    <asp:Label ID="lblsubskillinbk" runat="server" Height="25px" Text="For BK2:" Font-Bold="True" />
                    &nbsp;
                    <asp:DropDownList ID="ddlBK2" runat="server" Width="400" DataTextField="ProgTitleCombo" 
                        DataValueField="BKLEVEl2ID" AutoPostBack="true" />
                </td>
            </tr>
             <tr valign="top">
                <td colspan="2">
                    <asp:Label ID="lblStatus" runat="server" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
             <tr valign="top">
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="100%" BorderColor="Black"
                                BorderStyle="Solid" BorderWidth="2px" Height="400px">
                                <ccJSIM:CheckboxGridView ID="gvSubSkill" runat="server" CellPadding="4"
                                    ForeColor="#333333" GridLines="None" IncludeSorting="True" CheckedIdentifier="Checked"
                                    StatusPanelId="lblStatus" Width="99%" AutoGenerateColumns="False" DataKeyNames="subskillid" 
                                    AllowSorting="true" GridSortColumn="Checked" 
                                    CheckedMethodName="wsToggleSubskillBK" UnCheckedMethodName="wsToggleSubskillBK" UseAjax="False" 
                                    EnableSortingAndPagingCallbacks="True"  GridSortDirection="ASC" ShowHeaderCheckbox="True">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Checked" HeaderText="Checked" Visible="False" SortExpression="Checked" /> 
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
