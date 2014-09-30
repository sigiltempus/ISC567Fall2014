<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExamProvider_9.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_9" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Edit Exam</title>
    <link rel="stylesheet" type="text/css" href="Styles/IFrameStyles.css" />
</head>
<body>
    <form id="form2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div class="AddEditIFrame" style="width: 550px; height: 350px;">
            <table cellpadding="1" cellspacing="1" style="height: 350px; width: 550px">
               
                
                <tr class="IFrameHeader">
                    <td colspan="5">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="Edit Exam" CssClass="IFrameHeader" CanDragIFrame="True" Width="550px"></ccJSIM:DragIFrame>
                    </td>
                </tr>
                 <tr>
                    <td colspan="1">
                        <asp:Label ID="lblExamName" runat="server" Text="ExamName: " Font-Bold="true"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtExamName" runat="server" style="margin-left: 0px" Width="249px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="middle">
                        <asp:Label ID="lblExamTypeInfo" runat="server" Text="" CssClass="Label"></asp:Label>
                    </td>
               </tr>
                <tr valign="top">
            <td colspan="5">
            <asp:Label ID="lblExamType" runat="server" Text="Exam Type:" Font-Bold="true" CssClass="Label"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="ddlExamType" runat="server" Width="350px" Height="20px" AutoPostBack="true" CssClass="DropDownList">
                    <asp:ListItem Value="-1">- Select an Exam Type -</asp:ListItem>
               </asp:DropDownList>
            </td>
        </tr>
                <tr>
                    <td colspan="1">
                        <asp:Label ID="lblShortName" runat="server" Text="Short Name: " Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtShortName" runat="server" Width="250px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td colspan="1">
                        <asp:Label ID="lblDescription" runat="server" Text="Description: " Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtDescription" runat="server" Width="250px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDuration" runat="server" Text="Duration: " Font-Bold="true"></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="txtDuration" runat="server" Width="90px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:Label ID="lblMinutes" runat="server" Text="Minutes" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuestions" runat="server" Width="80px"></asp:TextBox>
                    </td>
                    <td>
                       <asp:Label ID="lblQuestions" runat="server" Text="#Questions" Width="100px"></asp:Label>
                    </td>
                    
                </tr>
                <tr align="left">
                    <td colspan="5">
                       
                        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton1" runat="server" Text="Save" style="z-index: 1; left: 291px; top: 320px; position: absolute; height: 27px; width: 93px; background-color: #FFFAC2;" />
                        <ccJSIM:CloseIFrameButton ID="Close" runat="server" Text="Close" IFrameName="ifEditExam" PostBackUrl="ExamProvider_7.aspx"  Width="70px" style="z-index: 1; left: 146px; top: 320px; position: absolute; right: 334px; height: 27px; background-color: #FFFAC2;" />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>