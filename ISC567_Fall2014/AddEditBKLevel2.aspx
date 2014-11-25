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
                <td colspan="2" class="auto-style2">
                   <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="Add/Edit Bklevel1" CssClass="IFrameHeader" Width="100%"  style="text-align: left" CanDragIFrame="True">
                   <asp:Label ID="lblCTitle" runat="server" Text="" Width="80%" style="text-align: left;"></asp:Label>
                       
                        </ccJSIM:DragIFrame>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style2">
                     <ccJSIM:CloseIFrameButton ID="btnCSave" runat="server" IFrameName="IfAddEditBKLevel2" Text="[X] Close" style="text-align: right; position: relative; top: -34px; left: 600px;" />
                 </td>
            </tr>
                     
                 <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Curriculum Name" style="text-align: right" Enabled="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtCName" runat="server" Width="100px" style="text-align: left" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Program Name" style="text-align: right" Enabled="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPname" runat="server" Width="100px" style="text-align: left" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="NumberL1 - BKLevel1" style="text-align: right"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumberL1" runat="server" Width="25px" style="text-align: left" Enabled="false"></asp:TextBox>
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
                        ParentFrame="IfListProgramBK2" ParentPage="ListProgramBK2.aspx" Width="53px" StatusPanelId="lblStatus"
                        RefreshParentPage="True" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
