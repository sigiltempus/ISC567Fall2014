<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditBKLevel1.aspx.vb" Inherits="ISC567_Spring2013.AddEditBKLevel1" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add/Edit BKLevel1</title>
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
                     <ccJSIM:CloseIFrameButton ID="btnCSave" runat="server" IFrameName="IfAddEditBKLevel1" Text="[X] Close" style="text-align: right; position: relative; top: -32px; left: 600px;" />
                 </td>
            </tr>
           
            <tr>
                                    <td style="width: 96%;">Curriculum Short Name
                                        <asp:TextBox ID="Txtcurriculumname" runat="server" Style="width: 100%; position: relative; top: -13px; left: 288px;" MaxLength="10" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valcurriculum" runat="server" ErrorMessage="curriculum Short Name is required"
                                            Text="*" ForeColor="Red" ControlToValidate="Txtcurriculumname" >
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                              <tr>
                                   <td>
                                    <asp:Label ID="Labelp" runat="server" Text="Program Short Name" style="text-align: right"></asp:Label>
                                        <asp:TextBox ID="txtShortName" runat="server" Style="width: 100%; position: relative; top: -16px; left: 288px;" MaxLength="10" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValShortName" runat="server" ErrorMessage="Program Short Name is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtShortName">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="NumberL1 - BK Level1" style="text-align: right"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNumberL1" runat="server" Width="25px" style="text-align: right"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="400px" Height="50px" TextMode="MultiLine"></asp:TextBox>
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
                        align="left" IFrameName="IfAddEditBKLevel1" MethodName="wsAddEditBKLevel1"
                        ParentFrame="ifListProgramBK" ParentPage="ListProgramBK.aspx" Width="53px" StatusPanelId="lblStatus"
                        RefreshParentPage="True" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
