<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExamProvider_5A.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_5A" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel ="stylesheet" type ="text/css" href ="styles/IFrameStyles.css" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods ="True">

        </asp:ScriptManager>
    <div class="AddEditIFrame" style="width:200px; height:150px;">
        
        <tr align="right" valign="bottom">
                <td colspan="2">
                    <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="PersonExists" CanDragIFrame ="True" CssClass="IFrameHeader" Font-Size="Small"></ccJSIM:DragIFrame>
                </td>
            </tr>
        
            </div>
        
    <div>
      
    
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Add To Member Institution" />
    
    </div>
    </form>

