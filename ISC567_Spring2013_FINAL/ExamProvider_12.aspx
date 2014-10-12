<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExamProvider_12.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_12" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add/Edit person</title>
    <script src="Scripts/jQuery/jquery-1.9.1.js"></script>
    <script src="Scripts/jQuery/jquery-ui.js"></script>
    <link rel="stylesheet" href="Styles/jQuery/jquery-ui.css" />

    <link rel="stylesheet" href="/resources/demos/style.css" />

    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 320px;
            width: 690px;
        }

        .auto-style2 {
            height: 20px;
            width: 690px;
        }

        .auto-style9 {
            height: 30px;
            width: 690px;
        }

        .chkBxList input {
            margin-left: 20px;
        }

        .chkBxList td {
            padding-left: 10px;
        }
        .auto-style3 {
            width: 98%;
            height: 20px;
        }
                
        .auto-style6 {
            height: 40px;
        }

        </style>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame2"">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" CanDragIFrame="True" Text="" CssClass="IFrameHeader" Width="100%">
                            <asp:Label ID="lblTitle" runat="server" Text="Add/Edit Item" Width="85%" style="text-align: center;"></asp:Label>
                            <%--<ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddEditPerson" Text="[X] Close" style="text-align: right" />--%>
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" class="auto-style9">
                       
                            <asp:Label ID="lblExam" runat="server" Text="Exam" Position="absolute" style="z-index: 1; left: 164px; top: 44px; position: absolute"></asp:Label>
                            <asp:TextBox ID="txtExam" runat="server" ReadOnly="true" Position="absolute" style="z-index: 1; left: 209px; top: 44px; position: absolute; width: 467px;"></asp:TextBox>
                            <asp:Label ID="lblType" runat="server" Text="Exam Type" Position="absolute" style="z-index: 1; left: 128px; top: 68px; position: absolute"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtType" runat="server" ReadOnly="true" Position="absolute" style="z-index: 1; left: 207px; top: 67px; position: absolute; width: 540px"></asp:TextBox>                                              
                            <br />
                            <br />
                    </td>
                </tr>
                
<%--                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="" Visible="false"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" BorderStyle="Solid" BorderColor="Black"
                            BorderWidth="2px" class="auto-style1" style="width: 885px;">
                            <table style="width: 100%; height: 24px;" id="tblName">
                               <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblK1" runat="server" Text="K1" style="z-index: 1;"></asp:Label>&nbsp;  
                                   <asp:Label ID="Label1" runat="server" ForeColor="Black" style="z-index: 1;" Text="Course Objective"></asp:Label> &nbsp;
                                   <asp:TextBox ID="TextBox3" runat="server" style="z-index: 1;"></asp:TextBox>
                                   <br />
                                    </td>
                                </tr>
                                <tr class="auto-style3" style="text-decoration-style: solid;">
                                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                    <asp:DropDownList ID="ddlKey1" runat="server" OnSelectedIndexChanged="ddlKey1_SelectedIndexChanged" AutoPostBack="true" Style="width: 811px;">
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblK2" runat="server" Text="K2" style="z-index: 1;"></asp:Label>&nbsp;  
                                   <asp:Label ID="Label2" runat="server" ForeColor="Black" style="z-index: 1;" Text="DOD Objective"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1;"></asp:TextBox>
                                   <br />
                                    </td>
                                </tr>
                                <tr class="auto-style3" style="text-decoration-style: solid;">
                                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlKey2" runat="server" OnSelectedIndexChanged="ddlKey2_SelectedIndexChanged" AutoPostBack="true" Style="width: 811px;">
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                               <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblK3" runat="server" Text="K3" style="z-index: 1;"></asp:Label>&nbsp;  
                                   <asp:Label ID="Label3" runat="server" ForeColor="Black" style="z-index: 1;" Text="IS Skill"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1;"></asp:TextBox>
                                   <br />
                                    </td>
                                </tr>
                                <tr class="auto-style3" style="text-decoration-style: solid;">
                                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlKey3" runat="server" OnSelectedIndexChanged="ddlKey3_SelectedIndexChanged" AutoPostBack="true" Style="width: 811px;">
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblObjective" runat="server" Text="Objective" style="z-index: 1;"></asp:Label>&nbsp;  
                                   </td>
                                </tr>
                                <tr class="auto-style6" style="text-decoration-style: solid;">
                                    <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                    <asp:TextBox ID="txtObjective" runat="server" TextMode="MultiLine" style="z-index: 1;font-family:Verdana; font-size:12px" Width="811px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblItem" runat="server" Text="Item" style="z-index: 1;"></asp:Label>&nbsp;  
                                   </td>
                                </tr>
                                <tr class="auto-style6" style="text-decoration-style: solid;">
                                    <td class="auto-style6">&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                    <asp:TextBox ID="txtItem" TextMode="MultiLine" runat="server" style="z-index: 1; font-family:Verdana;font-size:12px" Width="811px"></asp:TextBox>
                                    </td>
                                </tr>	
                               <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblA" runat="server" Text="A" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;  
                                   <asp:TextBox ID="txtA" runat="server" style="z-index: 1; width: 811px; height: 14px"></asp:TextBox>
                                   </td>
                                </tr>
                                <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblB" runat="server" Text="B" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;  
                                   <asp:TextBox ID="txtB" runat="server" style="z-index: 1; width: 811px; height: 14px"></asp:TextBox>
                                   </td>
                                </tr>
                                <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblC" runat="server" Text="C" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;  
                                   <asp:TextBox ID="txtC" runat="server" style="z-index: 1; width: 811px; height: 14px"></asp:TextBox>
                                   </td>
                                </tr>								
                                <tr style="text-decoration-style: solid;">
                                   <td class="auto-style3">&nbsp;
                                   <asp:Label ID="lblD" runat="server" Text="D" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;  
                                   <asp:TextBox ID="txtD" runat="server" style="z-index: 1; width: 811px; height: 14px"></asp:TextBox>
                                   </td>
                                </tr>
                                <tr style="text-decoration-style: solid;">
                                <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblCorrect" runat="server" Text="Correct" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 
                                    <asp:TextBox ID="txtCorrect" runat="server" style="z-index: 1; width: 50px;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblNumOfExams" runat="server" Text="#ofExams" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 
                                    <asp:TextBox ID="txtNumOfExams" runat="server" style="z-index: 1;width: 50px;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblPercentCorrect" runat="server" Text="%Correct" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtPercentCorrect" runat="server" style="z-index: 1;width: 60px;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblMean" runat="server" Text="Mean" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtMenu" runat="server" style="z-index: 1;width: 60px;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblPBS" runat="server" Text="PBS" style="z-index: 1;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtPBS" runat="server" style="z-index: 1;width: 60px;"></asp:TextBox>&nbsp;&nbsp;
                                  </td>
                                  </tr>
                               </table>
                         </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 20px;">
                      <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" Text="Close" IFrameName="iframeAddItem" PostBackUrl="ExamProvider_11.aspx" style="z-index: 1; background-color: #FFFAC2; font-weight: bold; font-size: 9pt; border: 1px solid #ba931c;" Csssytle="Button"/>&nbsp;         
                      <ccJSIM:SaveAndCloseIFrameButton ID="btnSaveChanges" runat="server" Text="Save Changes" style="z-index: 1; width:300px; background-color: #FFFAC2; font-weight: bold; font-size: 9pt; border: 1px solid #ba931c;" Csssytle="Button"/>&nbsp;

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
