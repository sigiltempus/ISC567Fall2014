<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WaitForExamTime.aspx.vb" Inherits="ISC567_Spring2013.WaitForExamTime" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style2
        {
            width: 660px;
            height: 56px;
        }
        .auto-style3 {
            width: 364px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ListIFrame">
        <table style="height: 317px">
            <tr>
                <td class="auto-style3">
                    <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="Wait Time for Exam" CssClass="IFrameHeader" Width="137%" CanDragIFrame="True"></ccJSIM:DragIFrame>
                </td>
                <td style="text-align:right">
                    <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddEditExams" Text="[X] Close" CssClass="IFrameHeaderClose" style="z-index: 1; left: -33px; top: 0px; position: relative; width: 171px;" />
                </td>
                
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label10" runat="server" style="z-index: 1; left: 19px; top: 134px; position: absolute" Text="Course:"></asp:Label>
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"> </asp:Label>
                    <asp:Label ID="Label9" runat="server" style="z-index: 1; left: 183px; top: 140px; position: absolute" Text="Date:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style2">
                    <%--<ccJSIM:OpenIFrameButton ID="btnContinue" runat="server" FrameSrc="Exam.aspx"
                        IFrameName="ifAddEditExams" Text="Continue" 
                        HeightPosition="400" LeftPosition="900" TopPosition="100" WidthPosition="400" ZIndex="160" />--%>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
             <%--<asp:Label ID="Label1" runat="server" BackColor="#990000" BorderColor="White" BorderStyle="Groove" style="z-index: 1; left: 10px; top: 34px; position: absolute; width: 448px" Text="Wait Time for Exam"></asp:Label>--%>
        <asp:Label ID="lblName" runat="server" style="z-index: 1; left: 112px; top: 79px; position: absolute; width: 285px; height: 19px;" Text="Name"></asp:Label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 15px; top: 109px; position: absolute; width: 364px" Text="You have been confirmed to take this exam"></asp:Label>
        <asp:Label ID="lblCourse" runat="server"  style="z-index: 1; left: 75px; top: 135px; position: absolute; width: 147px; height: 20px; right: 444px;" Text="Course "></asp:Label>
        <asp:Label ID="lblDate" runat="server"  style="z-index: 1; left: 228px; top: 139px; position: absolute; height: 20px; width: 140px" Text="Date"></asp:Label>
        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 192px; top: 198px; position: absolute" Text="At : "></asp:Label>
        <asp:Label ID="lblTime" runat="server"  style="z-index: 1; left: 226px; top: 199px; position: absolute; height: 20px; width: 170px" Text="Time"></asp:Label>
        <asp:Label ID="lblTimeRem" runat="server"  style="z-index: 1; left: 226px; top: 244px; position: absolute; width: 170px; height: 20px;" Text="TimeRem"></asp:Label>
        <asp:Label ID="Label8" runat="server" style="z-index: 1; left: 80px; top: 245px; position: absolute; width: 254px" Text="As soon as the time:"></asp:Label>
        <%--<asp:Button ID="Button1" runat="server" style="z-index: 1; left: 241px; top: 244px; position: absolute; width: 73px" Text="Continue" />--%>
        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton1" runat="server" FrameSrc="Exam.aspx"
                        IFrameName="ifAddEditExams" Text="Continue" 
                        HeightPosition="400" LeftPosition="60" TopPosition="30" WidthPosition="900"  CssClass="Button" ZIndex="160" style="position: relative; top: 9px; left: 548px; height: 26px" />  
                     </td>
            </tr>
        </table>
       </div>
    </form>
</body>
</html>
`

