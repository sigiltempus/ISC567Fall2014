﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreateEditExam.aspx.vb" Inherits="ISC567_Fall2014.CreateEditExam" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Add/Edit Exam</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 160px;
            width: 480px;
        }

        .auto-style2 {
            height: 2.5px;
            width: 480px;
        }
        .auto-style4 {
            width: 70px;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame" style="height: 270px;">
            <table>
                <tr>
                    <td class="auto-style2" style="width:auto">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" CanDragIFrame="True" CssClass="IFrameHeader" Width="155%" ><asp:Label ID="lblTitle" runat="server" Text="Add Exam" Width="85%" style="text-align: left;"> </asp:Label><%--<ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddEditExam" Text="[X] Close" 
                             style="text-align: right;" />--%></ccJSIM:DragIFrame>
                         </td>
                    <td class="auto-style4"><ccJSIM:CloseIFrameButton ID="Close" runat="server" Text="[X] Close" IFrameName="ifAddExam" PostBackUrl="WorkonExam.aspx"  Width="70px" style="z-index: 1; height: 21px; text-align:left; margin-left: 0px;" />
                   </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" BorderStyle="Solid" BorderColor="Black"
                            BorderWidth="2px" class="auto-style1">
                            <table style="width: 98%;" id="tblName">
                                <tr style="text-decoration-style: solid;">
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblExamType" runat="server" Text="Exam Type" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%;">
                                        <asp:DropDownList ID="ddlExamType" runat="server" AutoPostBack="true" CssClass="DropDownList" Style="width: 75%;">
										<asp:ListItem Value="-1">- Select an Exam Type -</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblName" runat="server" Text="Exam Name " Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%;">
                                        <asp:TextBox ID="txtName" runat="server" Style="width: 75%; "></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblPurpose" runat="server" Text="Exam Purpose " Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%;">
                                     <asp:TextBox ID="txtPurpose" runat="server" Width="75%" TextMode="MultiLine" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:Label ID="lblDuration" runat="server" Text="Duration " Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 73%;">
                                       
                                        <asp:DropDownList ID="ddlHours" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="0">Hours</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        &nbsp;
                                        &nbsp;
                                        <asp:DropDownList ID="ddlminutes" runat="server" AutoPostBack="True" >
                                            <asp:ListItem Value="0">Minutes</asp:ListItem>
                                            <asp:ListItem>00</asp:ListItem>
                                            <asp:ListItem Value=".25">15</asp:ListItem>
                                            <asp:ListItem Value=".50">30</asp:ListItem>
                                            <asp:ListItem Value=".75">45</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%;">
                                        &nbsp;</td>
                                    
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                   
                </tr>
                <tr>
                    <td colspan="2"class="auto-style2">
                        <ccJSIM:SaveandCloseIFrameButton ID="btnSave" runat="server" Text="Save"  style="z-index: 1;  height: 21px; width: 93px;" />
							  
                    </td>
                    
                </tr>
                  </table>
               
                             
                       
              
          
        </div>
    </form>
</body>
</html>





