<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TakerFunctions.aspx.vb" Inherits="ISC567_Fall2014.TakerFunctions" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="Stylesheet" type="text/css" href="styles/IFrameStyles.css" />
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 42px;
        }
        .auto-style3 {
            height: 18px;
        }
        .auto-style4 {
            height: 43px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
    <div class="AddEditIFrame" style="width:800px; height:250px;">
    <table style="width:100%;">
        <tr>
            <td style="text-align:left" >
                <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="Exam Taker" CanDragIFrame="True" CssClass="IFrameHeader" Width="114%"></ccJSIM:DragIFrame>
            </td>
            <td>                 
                <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" Text="[x}Close" IFrameName="ifTakerFunctions" Interval="10" Height="22px"/>
            </td>
            </tr>
            <tr align="center">
                <td>
                  <br />
                  <asp:Label ID="lblTakerHeader" runat="server" Text="Welcome to the Exam System" Font-Underline="true" Font-Bold="True" Width ="90%" Height="20px"></asp:Label>
                </td>
            </tr>
         <tr>
                <td class="auto-style2">
                     <br />
                    <asp:Label ID="lblMessage" runat="server" Text="You may select any of the following functions: (click a link)" Font-Bold="true" Width ="90%"></asp:Label>

                </td>
            </tr>
        <tr>
                <td>
                    <asp:Label ID="lblSVLineName2" runat="server" Visible="true"></asp:Label>
                </td>
            </tr>
        <tr>
                <td class="auto-style1">
                     <br />
                </td>
            </tr>
        <tr>
                <td class="auto-style3">
                    
                    <ccJSIM:OpenIFrameLinkButton ID="btnAddEditPerson" runat="server" CssClass="Button" 
                     FrameSrc="AddEditTaker.aspx?mode=edit" HeightPosition="404" 
                     IFrameName="ifAddEditUser" LeftPosition="20" Text="Edit User" TopPosition="120" 
                     WidthPosition="404" ZIndex="160" > Edit Personal Information </ccJSIM:OpenIFrameLinkButton>&nbsp;&nbsp;&nbsp;
                    <ccJSIM:OpenIFrameLinkButton ID="btnRoster0" runat="server" CssClass="Button" 
                     FrameSrc="Exam Registration.aspx" HeightPosition="500" 
                     IFrameName="ifRoster" LeftPosition="20" Text=" Registration For Exam " TopPosition="120" 
                     WidthPosition="808" ZIndex="160" ></ccJSIM:OpenIFrameLinkButton>&nbsp;&nbsp;
&nbsp;                    <ccJSIM:OpenIFrameLinkButton ID="btnRoster" runat="server" CssClass="Button" 
                     FrameSrc="Roster.aspx" HeightPosition="400" 
                     IFrameName="ifRoster" LeftPosition="20" Text="" TopPosition="120" 
                     WidthPosition="808" ZIndex="160" > Exam Roster </ccJSIM:OpenIFrameLinkButton>
                </td>
            </tr>
        <tr>
                <%--<td>
                    <ccJSIM:OpenIFrameLinkButton ID="ifLogout" runat="server"> Logout of the System </ccJSIM:OpenIFrameLinkButton>
                </td>--%>
              
            </tr>
        <tr align="left">
            <td></td>
            <td class="auto-style4">
                <br />
               
            </td>
        </tr>
    </table>        
        </div>
    </form>
    </body>
</html>

