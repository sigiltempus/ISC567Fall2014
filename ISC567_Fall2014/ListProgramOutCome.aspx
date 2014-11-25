<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListProgramOutCome.aspx.vb" Inherits="ISC567_Fall2014.ListProgramOutCome" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Program List</title>
    <link href="Styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="ListIFrame" >
        <table align="left"  border="0px" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" class="IFrameHeader">
                    <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="List Programs OutCome"></ccJSIM:DragIFrame>
                </td>
                <td align="right" class="IFrameHeader">
                    <ccJSIM:CloseIFrameLinkButton runat="server" IFrameName="ifListProgramOutcome" ID="CloseIFrameLinkButton1"
                        Text="[x]Close" postbackurl="ListProgram.aspx" BorderColor="White" ForeColor="white"></ccJSIM:CloseIFrameLinkButton>
                </td>
            </tr>
            <tr valign="top">
                <td colspan="2" height="40">
                    <asp:Label ID="lblRole" runat="server" Height="25px" Text="Program Outcomes for Program :"
                        Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="720px" Height="320px">
                        <ccJSIM:RadioButtonGridView ID="gvProgramOutcome" runat="server" AutoGenerateColumns="False"
                            IncludeSorting="True" EmptyDataText="No Data Found" GridSortColumn="" DataKeyNames="prgoutcomesid"
                            ForeColor="#333333" HighlighedRowColor="#FFFFAD" HeaderStyle-CssClass="gridViewHeader"
                            Width="700px" HeaderStyle-ForeColor="White">
                            <AlternatingRowStyle BackColor="#FFFFFF" />
                            <RowStyle BackColor="#EEEEEE" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Prg Seq">
                                    <ItemTemplate>
                                       <asp:Label ID="lblPrgsequence" runat="server" Text='<%# Eval("prgsequencenum")%>'
                                            Width="10px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Program Outcome">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramName" runat="server" Text='<%# Eval("prgshortoutcome")%>'>
                                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Program Outcome Info">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProgramtxt" runat="server" Text='<%# Eval("prgoutcometext")%>'
                                            Width="500px"></asp:Label>
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
                <td colspan="1">
                    <table>
                        <tr>
                            <td align="left">
                                <ccJSIM:OpenIFrameButton ID="btnAddProgramOutcome" runat="server" Text="Add Program Outcomes"
                                    FrameSrc="AddEditProgramOutcome.aspx?mode=add" IFrameName="IfAddEditProgramOutcomes"
                                    HeightPosition="420" WidthPosition="600"
                                    LeftPosition="450" TopPosition="110" ZIndex="185"  CssClass="Button"/>
                            </td>
                            <td>
                               <ccJSIM:OpenIFrameButton ID="btnEditProgramoutcome" runat="server" Text="Edit Program Outcomes"
                                    FrameSrc="AddEditProgramOutcome.aspx?mode=edit" IFrameName="IfAddEditProgramOutcomes"
                                     HeightPosition="420" WidthPosition="600"
                                    LeftPosition="450" TopPosition="110" ZIndex="185"  CssClass="Button"/>
                                    
                                  </td>
                            <td>
                                 
                                 <ccJSIM:OpenIFrameButton ID="btnProgramSubSkill" runat="server" Text="Program Outcomes SubSkill" onclick ="btnProgramSubSkill_Click" 
                                    FrameSrc="ProgramOutcomeSubSkill.aspx" IFrameName="ifProgrOutSubsill" HeightPosition="634" WidthPosition="654"
                                    LeftPosition="400" TopPosition="50" ZIndex="185"  CssClass="Button"/>
                               
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
