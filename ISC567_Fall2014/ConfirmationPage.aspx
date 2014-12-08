<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConfirmationPage.aspx.vb" Inherits="ISC567_Fall2014.ConfirmationPage" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div class="ListIFrame" style="width: 600px; height: 350px;">
            <table style="width: 100%;">
                <tr style="text-align: left">
                    <td colspan="2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="Confirmation Page" CssClass="IFrameHeader" Width="100%">
                        </ccJSIM:DragIFrame>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"> </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%; text-align: center">

                        <br />
                        <br />
                        
                       

                    </td>
                </tr>
                <tr>
                    <td style="width: 50%">You :
                        <asp:Label ID="txtName" runat="server" BorderStyle="None" Style="width: auto; height: 98%; text-align: center" Font-Bold="True"></asp:Label>
                    </td>
                    
                    <td style="width: 50%">
                        <asp:Label ID="txtAddress" runat="server" BorderStyle="None" Style="width: auto; height: 98%" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="lblCity" runat="server" BorderStyle="None" Style="width: auto; height: 98%" Font-Bold="True"></asp:Label>
                        &nbsp,<asp:Label ID="lblSt" runat="server" BorderStyle="None" Style="width: auto; height: 98%" Font-Bold="True"></asp:Label><br />
                        &nbsp-<asp:Label  ID="lblZip" runat="server" BorderStyle="None" Style="width: auto; height: 98%" Font-Bold="True"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td style="width: 50%">
                        <asp:Label ID="Label1" runat="server" BorderStyle="None" Style="width: 98%; height: 98%;" Text="Are About to take"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%">Exam Name :
                        <asp:Label ID="lblexamName" runat="server" Style="width: auto; height: 98%; text-align: center" Font-Bold="True"></asp:Label><br />
                        <br />
                        <br />
                    </td>
                    <td style="width: 50%">Date :
                        <asp:Label ID="lblDate" runat="server" BorderStyle="None" Style="width: auto; height: 98%; text-align: center" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp; at 
                    <asp:Label ID="lblTime" runat="server" BorderStyle="None" Style="width: auto; height: 98%; text-align: center" Font-Bold="True"></asp:Label>
                        <br />
                        Location :
                        <asp:Label ID="lblLocation" runat="server" BorderStyle="None" Style="width: auto; height: 98%" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Style="width: 98%; height: 98%;" Text="Proctor Code:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtProctorCode" runat="server" Style="width: 98%; height: 98%;"></asp:TextBox>
                    </td>
                    <td>
                        <%--<ccJSIM:OpenIFrameButton ID="OpenIFrameButton1"  runat="server"  FrameSrc="WaitForExamTime.aspx"
                            IFrameName="ifWaitForExam" Text="Submit" 
                            CssClass="Button" ZIndex="180" LeftPosition="200" TopPosition="200" />--%>
                    </td>

                    <td>

                        



                    </td>
                </tr>
                <tr align="left">
                    <td colspan="2">
                        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton" runat="server" CssClass="ButtonDisplay" 
                     FrameSrc="WaitForExamTime.aspx" HeightPosition="340" 
                     IFrameName="ifAddEditExams" LeftPosition="350" Text="Submit" TopPosition="120" 
                     WidthPosition="600" ZIndex="160" >

                        </ccJSIM:OpenIFrameButton>
                        <br />

                        <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" Text="Cancel" CssClass="Button"  IFrameName="ifConfirmationPage" Interval="10" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


