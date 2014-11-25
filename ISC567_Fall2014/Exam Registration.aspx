<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Exam Registration.aspx.vb" Inherits="ISC567_Fall2014.Exam_Registration" %>

<%@ Register assembly="JSIM" namespace="JSIM.Custom_Controls" tagprefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .IFrameHeader
{
    font-size: 14pt;
    font-weight: bold;
    color: White;
    background-color: #ba1c1c;
    font-family: Verdana;
    padding: 5px 5px 5px 5px;
}

.AddEditIFrame
{
    vertical-align: top;
    top: 0px;
    left: 0px;
    width: inherit;
    height: inherit;
    border: 2px #ba931c solid;
    position: absolute;
    margin: 0 auto;
    overflow: hidden;
    padding: 0;
    background-color: #EFEFEF;
    color: #8D6D00;
}

        .auto-style3 {
            height: 49px;
        }
    .Button
{
    background-color: #FFFAC2;
    color: black;
    z-index: 1;
    left: 266px;
    top: 170px;
    margin-left: 0px;
    font-size: 9pt;
    font-weight: bold;
    border: 1px solid #ba931c;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 149px; width: 382px">
    
        <br />
    
    </div>
        <div class="AddEditIFrame" style="width: 400px; height: 400px;">
            <table style="width: 100%;">
                <tr style="text-align: left">
                    <td colspan="2">
                    <ccJSIM:DragIFrame ID="lblHeader0" runat="server" CssClass="IFrameHeader" Width="134%" CanDragIFrame="True" Height="28px">
                        
                    
                        <%--<ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" IFrameName="ifAddCourse" Text="[X] Close" />--%>

                    RegisterForExam</ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lbladdress1" runat="server" Text="Address1:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress2" runat="server" Text="Address2:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblCity" runat="server" Text="City:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSt" runat="server" Text="State:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtState" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblzip" runat="server" Text="ZIP:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtzip" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblphNum1" runat="server" Text="Phone Number:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhoneNum" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>

                <tr align="right">
                    <td colspan="2" class="auto-style3">
                        <br />

                        <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Submit" CssClass="Button" runat="server" IFrameName="ifAddEditUser" MethodName="wsAddEditUser" ParentFrame="ifTakerFunctions" ParentPage="TakerFunctions.aspx" />&nbsp;
                <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" Text="Close" CssClass="Button" IFrameName="ifAddEditUser" Interval="10" PostBackUrl="~/MainMenu.aspx" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
