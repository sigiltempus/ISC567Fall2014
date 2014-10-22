<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExamProvider_5.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_5" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><title></title><link href="styles/IFramestyles.css" rel ="stylesheet" type="text/css" /></head><body><form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">

        </asp:ScriptManager>
    <div class="CheckboxIFrame">
    --<table cellpadding="0" cellspacing="0" style="width:500px; height:300px;">
        <tr align="right" valign="top" >
                <%--<asp:Label ID="lblUser" runat="server" Text="User Name"></asp:Label>--%>
                <td colspan="2">
                    <ccJSIM:DragIFrame ID="DragIFrame1" runat="server" Text="User Name" CanDragIFrame="True" CssClass="label"> </ccJSIM:DragIFrame>
                </td>
            </tr>
           
            
            <tr class="IFrameHeader" >
               <td align="right">
                    &nbsp;<asp:Label ID="lblInstitution" runat="server" Text="Logout" CssClass="IFrameHeader" Font-Bold="True" Font-Size="Small"></asp:Label>
               </td>
                
            </tr>
           
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblHeading" runat="server" Text="Staff Lookup" CssClass="IFrameHeader" Font-Size="Small"></asp:Label>
                    <br/>
                    <br />


                </td>
            </tr>
           
            <tr>
                <td colspan="3">
                    &nbsp; &nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Add Staff Name For"></asp:Label>
                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px" Width="206px"></asp:TextBox>
                    
             </td>
            </tr>--%>
       
        
         <tr valign="top">
            <td colspan="2">
                &nbsp;</td>
        </tr>
            <tr align="center" valign="middle">
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Enter Email To Verify Staff Status"></asp:Label>
                    <br />

                    <asp:TextBox ID="TextBox1" runat="server" Width="191px"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Submit" />
                    <br />
                    <br />

                </td>
            </tr>
            <tr align="right" valign="bottom">
                <td colspan="2">

        &nbsp; 
                    <asp:Button ID="BtnClose" runat="server" Text="Close" Width="80px" />
       
                </td>
                </tr>

        
    </table>
    </div>
    </form>
</body>
</html>
