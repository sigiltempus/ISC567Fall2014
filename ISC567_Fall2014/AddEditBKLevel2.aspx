<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditBKLevel2.aspx.vb" Inherits="ISC567_Fall2014.AddEditBKLevel2" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADD/EDIT BK LEVEL 2</title>
    <script type="text/javascript">
        function ShowAlert() {

            alert('Do you want to save these changes');

        };
    </script>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />
    <script src="Scripts/jQuery/jquery-1.9.1.js"></script>
    <script src="Scripts/jQuery/jquery-ui.js"></script>

</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="AddEditIFrame" style="height: 320px;width:700px">
            <table style="height: 300px; width: 702px">
                <tr>
                    <td colspan="1" class="IFrameHeader">
                        <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="Add BK Level2" style="text-align: left">
                        </ccJSIM:DragIFrame>
                    </td>
                    <td colspan="1" class="IFrameHeader">
                        <ccJSIM:CloseIFrameLinkButton ID="CloseIFrameLinkButton1" runat="server" Text="[x] Close"
                            BorderColor="White" ForeColor="White" IFrameName="IfAddEditBKLevel2" style="text-align: right">
                        </ccJSIM:CloseIFrameLinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Program ID" style="text-align: right"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtISModelID" runat="server" Width="25px" style="text-align: left"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="BKLevel1ID" style="text-align: right"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBKLevel1ID" runat="server" Width="25px" style="text-align: left"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="NumberL1 - BKLevel1" style="text-align: right"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumberL1" runat="server" Width="25px" style="text-align: left"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="NumberL2 - BKLevel2" style="text-align: right"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumberL2" runat="server" Width="25px" style="text-align: left"></asp:TextBox>
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="BK Level2 Title" style="text-align: right"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" Width="400px" Height="50px" TextMode="MultiLine" style="text-align: left"></asp:TextBox>
                    </td>
                </tr>               
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" runat="server" CssClass="Button"
                        align="left" IFrameName="IfAddEditBKLevel2" MethodName="wsAddEditBKLevel2"
                        ParentFrame="ifListProgramBK2" ParentPage="ListProgramBK2.aspx" Width="53px" StatusPanelId="lblStatus"
                        RefreshParentPage="True" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
