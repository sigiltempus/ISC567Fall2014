<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditTaker.aspx.vb" Inherits="ISC567_Fall2014.AddEditTaker" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        ul li {
            display: inline;
            list-style-type: none;
        }

        .auto-style3 {
            height: 49px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div class="AddEditIFrame" style="width: 400px; height: 400px;">
            <table style="width: 100%;">
                <tr style="text-align: left">
                    <td colspan="2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="" CanDragIFrame="True" CssClass="IFrameHeader" Visible="True" Width="98%">
                        </ccJSIM:DragIFrame>
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
                        <asp:Label ID="lblUsername" runat="server" Text="Username:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Bold="true" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Width="210px"></asp:TextBox>
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

                <tr align="right">
                    <td colspan="2" class="auto-style3">
                        <br />

                        <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" CssClass="Button" runat="server" IFrameName="ifAddEditUser" MethodName="wsAddEditUser" ParentFrame="ifTakerFunctions" ParentPage="TakerFunctions.aspx" />&nbsp;
                <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" Text="Cancel" CssClass="Button" IFrameName="ifAddEditUser" Interval="10" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
