<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddProvider.aspx.vb" Inherits="ISC567_Spring2013.AddProvider" %>
<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>


<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add/Edit Provider</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 220px;
            width: 690px;
        }

        .auto-style2 {
            height: 2.5px;
            width: 690px;
        }
        </style>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame" style="height: 300px;">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" CanDragIFrame="True" Text="" CssClass="IFrameHeader" Width="100%">
                            <asp:Label ID="lblTitle" runat="server" Text="Add/Edit Provider" Width="85%" style="text-align: left;"></asp:Label>
                            
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderColor="Black"
                            BorderWidth="2px" class="auto-style1">
                            <table style="width: 100%;" id="tblName">
                                <%--<tr style="text-decoration-style: solid;">
                                    <td style="width: 50%;">&nbsp;</td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 48%;">Name<br />
                                        <asp:TextBox ID="txtName" runat="server" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td colspan="2" style="width: 48%;">&nbsp;</td>
                                </tr>
                                <tr>
                                   <%-- <td style="width: 48%;">&nbsp;</td>
                                    <td>&nbsp;</td>--%>
                                    <%--<td colspan="2" style="width: 48%;"><br />
                                        </td>--%>
                                </tr>
                                <tr>
                                    <td style="width: 48%;">Address Line 1<br />
                                        <asp:TextBox ID="txtAddress1" runat="server" Style="width: 100%;"></asp:TextBox></td>
                                    <td style="width: 4%;">&nbsp;</td>
                                    <td colspan="2" style="width: 48%;">Address Line 2<br />
                                        <asp:TextBox ID="txtAddress2" runat="server" Width="307px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 48%;">City<br />
                                        <asp:TextBox ID="txtCity" runat="server" Style="width: 100%;"></asp:TextBox></td>
                                    <td style="width: 4%;">&nbsp;</td>
                                    <td style="width: 20%;">State<br />
                                        <asp:TextBox ID="txtState" runat="server" Style="width: 100%;"></asp:TextBox></td>
                                    <td style="width: 25%; padding-left: 4px;">Zip Code<br />
                                        <asp:TextBox ID="txtZip" runat="server" Style="width: 60%;"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <%--<td style="width: 48%;">&nbsp;</td>
                                    <td style="width: 4%;">&nbsp;</td>--%>
                                    
                                </tr>
                                <tr>
                                    <td style="width: 48%;">Web Url<br />
                                        <asp:TextBox ID="txtWeburl" runat="server" Style="width: 100%;"></asp:TextBox></td>
                                    <td style="width: 4%;">&nbsp;</td>
                                    <td colspan="2" style="width: 48%;">
                                        Country<br />
                                        <asp:TextBox ID="txtCountry" runat="server" ></asp:TextBox>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table>
                                                    
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td style="width: 1%;">&nbsp;</td>
                                                        <td>
                                                            <asp:CheckBox ID="chkBxIsEPSA" runat="server" Text="Is EPSA" style="z-index: 1; left: 95px; top: 240px; position: absolute" /></td>
                                                        <td style="width: 1%;">&nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td style="width: 1%;">&nbsp;</td>
                                                        <td>
                                                            <asp:CheckBox ID="chkBxIsDeveloper" runat="server" Text="Is Developer" style="z-index: 1; left: 257px; top: 240px; position: absolute" /></td>
                                                        <td style="width: 1%;">&nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                         <%--   <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="chkBxIsProvider" EventName="CheckedChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="chkBxIsInstitution" EventName="CheckedChanged" />
                                            </Triggers>--%>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                               
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
         
                        <ccJSIM:SaveAndCloseIFrameButton ID="Save" runat="server" IFrameName="ifExamProvider_1A" Interval="10" Text=" [✓] Save " Width="100px" CssClass="Button" style="z-index: 1; left: 180px; top: 275px; height:23px; position: absolute;" />
                        <ccJSIM:CloseIFrameButton ID="btnCloseAddEdit" runat="server" CssClass="Button" style="z-index: 1; left: 380px; top: 275px; height:23px; position: absolute; width: 109px" Interval="10" PostBackUrl="ExamProvider_1A.aspx" Text="Close" IFrameName="ifExamProvider_1A"/>

                </tr>
            </table>
      </div>
    </form>
</body>
</html>
