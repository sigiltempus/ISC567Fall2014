<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExamProvider_13.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_13" %>

<!<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--    <link rel ="stylesheet" type ="text/css" href ="styles/IFrameStyles.css" />--%>
    <link href= "Styles/IFrameStyles.css" rel ="StyleSheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods ="True">

        </asp:ScriptManager>
        

        
        
    <div class="AddEditIFrame" style="width:1000px; height: 800px;">
        <table style="width:100%;">
            <tr align="right" valign="top" >
                <%--<asp:Label ID="lblUser" runat="server" Text="User Name"></asp:Label>--%>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                </td>
            </tr>
           
            
        
           
            <tr>

            </tr>
            <tr>


                    <td align="left" colspan="1">
                        <asp:Label ID="lblEdit" runat="server" Text="Edit Item"></asp:Label> 
                        <br />
                        <br />
                    <asp:Label ID="LabelForExam" runat="server" Text="For Exam" CssClass="IFrameHeader" Font-Bold="false" BackColor="Black"> </asp:Label>   <asp:TextBox ID="txtForExam" runat="server"></asp:TextBox> 
                        <br /> 
                       
                        <br />
                        <asp:Label ID="lblExamType" runat="server" Text="Exam Type" CssClass="IFrameHeader" Font-Bold="false" BackColor="Black"></asp:Label> <asp:TextBox ID="txtSaveChanges" runat="server"></asp:TextBox>
                </td>
                  </tr>
              <tr>
                  <td>
                      
                      <br />

                      <asp:Label ID="lblK1" runat="server" Text="K1"></asp:Label>   <asp:DropDownList ID="ddlKey1" runat="server"></asp:DropDownList>
                      <br />
                      <br />
                      <asp:Label ID="lblK2" runat="server" Text="K2"></asp:Label><asp:DropDownList ID="ddlKey2" runat="server"></asp:DropDownList>
                      <br />
                      <br />
                      <asp:Label ID="lblK3" runat="server" Text="K3"></asp:Label><asp:DropDownList ID="ddlKey3" runat="server"></asp:DropDownList>
                      <br />
                      <br />
                      <asp:Label ID="lblObjective" runat="server" Text="Objective"></asp:Label>
                      <br />
                      <asp:TextBox ID="txtObjective" runat="server"></asp:TextBox>
                      <br />
                      <br />
                      <asp:Label ID="lblItem" runat="server" Text="Item"></asp:Label>
                      <br />
                      <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
                      <br /> 
                      <br />
                      <asp:Label ID="lblA" runat="server" Text="A"></asp:Label>  <asp:TextBox ID="txtA" runat="server"></asp:TextBox>

                     <br />
                      <br />
                      <asp:Label ID="lblB" runat="server" Text="B"></asp:Label> <asp:TextBox ID="txtB" runat="server"></asp:TextBox>
                      <br />
                      <br />
                     <asp:Label ID="lblC" runat="server" Text="C"></asp:Label> <asp:TextBox ID="txtC" runat="server"></asp:TextBox>
                      <br />
                      <br />
                     <asp:Label ID="lblD" runat="server" Text="D"></asp:Label> <asp:TextBox ID="txtD" runat="server"></asp:TextBox>
                      <br />
                      <br />
                     <asp:Label ID="lblCorrect" runat="server" Text="Correct"></asp:Label> <asp:TextBox ID="txtCorrect" runat="server"></asp:TextBox>
                      <br />
                      <br />
                      <asp:Label ID="lblNumOfExams" runat="server" Text="#ofExams"></asp:Label> <asp:TextBox ID="txtNumOfExams" runat="server"></asp:TextBox>
                      <br />
                      <br />
                     <asp:Label ID="lblPercentCorrect" runat="server" Text="%Correct"></asp:Label> <asp:TextBox ID="txtPercentCorrect" runat="server"></asp:TextBox>
                      <br />
                      <br />
                     <asp:Label ID="lblMenu" runat="server" Text="Menu"></asp:Label> <asp:TextBox ID="txtMenu" runat="server"></asp:TextBox>
                      <br />
                      <br />
                     <asp:Label ID="lblPBS" runat="server" Text="PBS"></asp:Label> <asp:TextBox ID="txtPBS" runat="server"></asp:TextBox>
                       <br />
                      <br />
                       <asp:Button ID="btnClose" runat="server" Text="Close"/>           <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes to Items"/>
                  </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
              </table>
    </div>
    </form>
</body>
</html>