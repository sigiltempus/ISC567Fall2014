<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExamProvider_6.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_6" %>

<%@ Register assembly="JSIM" namespace="JSIM.Custom_Controls" tagprefix="ccJSIM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">

        .style2
        {
            font-size: large;
        }
        .style3
        {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div style="height: 37px; width: 704px">
    
        <asp:Label ID="Label1" runat="server" BackColor="Red" Font-Bold="True" 
            Font-Size="Large" ForeColor="White" Text="Edit Staff for :"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox6" runat="server" Width="204px"></asp:TextBox>
    
    </div>
    <p>
        Name:</p>
    <p>
        Last:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Width="156px"></asp:TextBox>
    </p>
    <p>
        First:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Width="162px"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <asp:Panel ID="Panel1" runat="server" style="font-size: large">
        Provider<span class="style2"><span 
    class="style3">:</span>&nbsp;&nbsp;&nbsp; </span>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Selected="True">Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:DropDownList>
        <br />
        Ad<span class="style2"><span class="style3">min:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
        <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem Selected="True">Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:DropDownList>
        <br />
        Proctor<span class="style2"><span class="style3">:&nbsp;&nbsp;&nbsp; </span>&nbsp; </span>
        <asp:DropDownList ID="DropDownList4" runat="server">
            <asp:ListItem Selected="True">Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:DropDownList>
        <br />
        Staff<span class="style2"><span class="style3">:&nbsp;&nbsp; </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
        <asp:DropDownList ID="DropDownList5" runat="server">
            <asp:ListItem Selected="True">Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <ccJSIM:SaveAndCloseIFrameButton ID="SaveAndCloseIFrameButton1" runat="server" 
            Text="Save" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" Text="Close" />
    </asp:Panel>
    </form>
    <form id="form1" runat="server">
    </form>
</body>
</html>


