﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WorkonExamItem.aspx.vb" Inherits="ISC567_Fall2014.WorkonExamItem" %>
<%@ Register assembly="JSIM" namespace="JSIM.Custom_Controls" tagprefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Exam Item</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        
        .auto-style2 {
            width: 940px;
            height:inherit;
        }

        #form1 {
            width: 934px;
        }
        .auto-style3 {
            height: 308px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame1">
            <table style="height: 385px">
                <tr>
                    <td class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" CssClass="IFrameHeader" Width="107%" CanDragIFrame="True" Height="24px">
                            <asp:Label ID="lblTitle" runat="server" Text="Exam Items" Width="90%" style="text-align: center;"></asp:Label>
                        </ccJSIM:DragIFrame>
                    </td>
                    <td> 
                        <ccJSIM:CloseIFrameButton ID="Close" runat="server" Text="Close" IFrameName="ifExamList" PostBackUrl="WorkonExam.aspx"  Width="70px" style=" height: 21px;" />
                            
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                       
                            <asp:Label ID="lblExam" runat="server" Text="Exam" Position="absolute" style="z-index: 1; left: 164px; top: 44px; position: absolute"></asp:Label>
                            <asp:TextBox ID="txtExam" runat="server" ReadOnly="true" Position="absolute" style="z-index: 1; left: 209px; top: 44px; position: absolute; width: 270px;"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="Exam Status" Position="absolute" style="z-index: 1; left: 516px; top: 44px; position: absolute"></asp:Label>
                            <asp:TextBox ID="txtStatus" ReadOnly="true" runat="server" Position="absolute" style="z-index: 1; left: 612px; top: 44px; position: absolute; width: 293px"></asp:TextBox>
                            <asp:Label ID="lblType" runat="server" Text="Exam Type" Position="absolute" style="z-index: 1; left: 128px; top: 72px; position: absolute"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtType" runat="server" ReadOnly="true" Position="absolute" style="z-index: 1; left: 207px; top: 72px; position: absolute; width: 540px"></asp:TextBox>                                              
                            <br />
                            <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style3">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="99%" Height="224px" CssClass="PanelStyle">
                            <asp:Button ID="btnDeleteItem" Cssstyle="Button"  OnClick="btnDeleteItem_Click" runat="server" style="z-index:1; left:579px; top: 400px; position: absolute; background-color: #FFFAC2; font-weight: bold; font-size: 9pt; border: 1px solid #ba931c;" Text="Delete Item" Width="159px" />
                            <ccJSIM:OpenIFrameButton ID="Button3" Cssstyle="Button" runat="server" FrameSrc="AddEditExamItem.aspx?mode=edit" IFrameName="iframeAddItem" style="z-index:1; left:419px; top: 400px; position: absolute; width: 150px; background-color: #FFFAC2; font-weight: bold; font-size: 9pt; border: 1px solid #ba931c;" Text="Show Item" WidthPosition="900" HeightPosition="450" LeftPosition="530" TopPosition="160" zindex="220"/>
                            <ccJSIM:OpenIFrameButton ID="Button2" Cssstyle="Button" runat="server" FrameSrc="AddEditExamItem.aspx?mode=add" IFrameName="iframeAddItem" style="z-index: 1; left: 245px; top: 400px; position: absolute; background-color: #FFFAC2; font-weight: bold; font-size: 9pt; border: 1px solid #ba931c;" Text="Add New Item" Width="166px" WidthPosition="900" HeightPosition="450" LeftPosition="530" TopPosition="160" zindex="220" />
                            <ccJSIM:RadioButtonGridView ID="gvExamList" runat="server" AutoGenerateColumns="False" 
                                ChangeRowColor="True" GridSortDirection="DESC" 
                                HighlighedRowColor="" IncludeSorting="True" ShowSelectorButton="True" AllowSorting="True" 
                                UseAjax="False" Height="151px" style="margin-right: 0px" Width="100%" DataKeyNames="Item">
                                    <Columns>
                                    <asp:BoundField DataField="Item" SortExpression="Item" HeaderText="Item" Visible="False" >
                                        <HeaderStyle Width="6.5%" />
                                        <ItemStyle Width="6.5%" />
                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="#" SortExpression="#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                         <asp:BoundField DataField="questionobjective" HeaderText="Question Objective" >
                                        <HeaderStyle Width="80%" />
                                        </asp:BoundField>
                                </Columns>
                                    <HeaderStyle Width="2px" />
                            </ccJSIM:RadioButtonGridView>
                           
                                   
                        </asp:Panel>
                    </ContentTemplate>
                    
                </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                        &nbsp;
                        </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
