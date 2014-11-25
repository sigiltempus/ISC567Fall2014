<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExitApplication.aspx.vb" Inherits="ISC567_Fall2014.ExitApplication" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel ="stylesheet" type ="text/css" href ="styles/IFrameStyles.css" />

    
    <style type="text/css">
        .Button
        {}
    </style>

    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods ="True">
        </asp:ScriptManager>
    <div class="Institution_1a" style="width:494px; height:150px;">
        <table>
            <tr align="right" valign="top" >
                <td colspan="2">
                    <ccJSIM:DragIFrame ID="DragIFrame1" runat="server" Text="" CanDragIFrame="True" 
                        CssClass="label"> </ccJSIM:DragIFrame>
                </td>
            </tr>           
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblConfirmation" runat="server" Text="Are you sure you want to exit this application?" 
                        CssClass="IFrameHeader" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
             <tr valign="top">
            <td colspan="2">
                &nbsp;</td>
        </tr>
            <tr valign="middle">
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="CloseConfirmation" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="121px">                                                              
                                <asp:Button ID="btnCloseApplication" runat="server" Text="Yes, close this application." />
                                <br>
                                </br>
                                <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="NO, DO NOT close this application" />                                                               
                            </asp:Panel>
                        </ContentTemplate>
                      
                    </asp:UpdatePanel>
                </td>
            </tr>
            
            
             
       </table>
        </div>
        </form>
       </body>
        </html>