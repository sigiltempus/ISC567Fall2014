<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditSponsor.aspx.vb" Inherits="ISC567_Fall2014.AddEditSponsor" %>
<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add/Edit Sponsor</title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />
    <script src="Scripts/jQuery/jquery-1.9.1.js"></script>
    <script src="Scripts/jQuery/jquery-ui.js"></script>
    <style type="text/css">
        .auto-style1 {
            height: 38px;
        }
        .auto-style2 {
            height: 37px;
        }
        .auto-style3 {
            font-size: 14pt;
            font-weight: bold;
            color: White;
            background-color: #ba1c1c;
            font-family: Verdana;
            padding: 5px 5px 5px 5px;
            height: 65px;
        }
    </style>
        
 
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="AddEditIFrame" style="height: 320px;width:700px">
        <table style="height: 300px; width: 702px">
            <tr>
                <td colspan="2" class="auto-style2">
                   <ccJSIM:DragIFrame ID="dgFrame" runat="server" Text="Add/Edit Sponsor" CssClass="IFrameHeader" Width="100%"  style="text-align: left" CanDragIFrame="True">
                   <asp:Label ID="lblCTitle" runat="server" Text="" Width="80%" style="text-align: left;"></asp:Label>
                       
                        </ccJSIM:DragIFrame>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style2">
                     <ccJSIM:CloseIFrameButton ID="btnCSave" runat="server" IFrameName="ifAddEditSponsor" Text="[X] Close" style="text-align: right; position: relative; top: -38px; left: 600px;" />
                 </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="Label2" runat="server" Text="Curriculum Name" style="text-align: left"></asp:Label>
                </td>
                <td >
                    <asp:DropDownList ID="ddlcurriculum" runat="server" DataSourceID="sdscurriculum" DataTextField="curriculum_shortname"
                        DataValueField="curriculumid">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sdscurriculum" runat="server" ConnectionString="<%$ ConnectionStrings:connectionString %>"
                        SelectCommand="SELECT [curriculumid], [curriculum_shortname] FROM [curriculum]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Society Name" style="text-align: right"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtSponsor" runat="server" Width="80px" style="text-align: right" enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Sponsored Date(YYYY/MM/DD)"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtdate" runat="server" Width="80px" style="text-align: right"></asp:TextBox>
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
                    <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" runat="server" 
                        Text="Save" CssClass="Button"
                        align="left" IFrameName="ifAddEditSponsor" Interval="10" MethodName="wsAddEditSponsor"
                        ParentFrame="ifsponsorlist" ParentPage="Listsponsor.aspx" RefreshParentPage="True" />
                    &nbsp;
                    <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" CssClass="Button" 
                                              Text="Cancel" IFrameName="ifAddEditSponsor" Interval="10"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

