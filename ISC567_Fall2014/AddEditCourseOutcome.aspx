<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditCourseOutcome.aspx.vb"
    Inherits="ISC567_Fall2014.AddEditCourseOutcome" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 301px;
        }
        .auto-style2 {
            height: 27px;
        }
        .auto-style3 {
            width: 301px;
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="ListIFrame" >
        <table align="left" border="0" cellpadding="0" cellspacing="0" width="596" style="height:396px">
            <tr>
                <td colspan="2" class="auto-style2"">
                    <ccJSIM:DragIFrame ID="dgFrame" runat="server" CssClass="IFrameHeader" Width="100%" CanDragIFrame="True">
                        <asp:Label ID="lblTitle" runat="server" Text="Edit Course Outcome" Width="90%"  style="text-align: left; padding: 0; z-index:200"></asp:Label>
                    <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddCourseOutcomes" Text="[X] Close" />
                        
                    </ccJSIM:DragIFrame>
                </td> 
               
            </tr>
            <%--<tr>
                <td align="right" style="padding-right:10px;">
                    <asp:Label ID="Label4" runat="server" Text="Program:"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    
                    <asp:DropDownList ID="ddlProgram" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <%--<tr>
                <td align="right" style="padding-right:10px;" class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Course:"></asp:Label>
                </td>
                <td align="left" class="auto-style3">
                    
                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>--%>
               <tr>
                <td align="right" style="padding-right:10px;" >
                    <asp:Label ID="Label1" runat="server" Text="Course Outcome ID:" Width="275px"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    
                    <asp:TextBox ID="txtProgramseq" runat="server" Width="50px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:10px;">
                    <asp:Label ID="Label2" runat="server" Text="Course Outcome:"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    
                    <asp:TextBox ID="txtPrgoutcom" runat="server" Height="103px" TextMode="MultiLine"
                        Width="287px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td align="right" style="padding-right:10px;">
                    <asp:Label ID="Label3" runat="server" Text="Short Outcome:"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    
                    <asp:TextBox ID="txtShortoutcome" runat="server" Height="70px" Width="286px"></asp:TextBox>
                </td>
            </tr>
         <tr>
                <td align="right" style="padding-right:10px;">
                    <asp:Label ID="Label5" runat="server" Text="Course Outcome Number"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    
                    <asp:TextBox ID="txtCrsOutcomeNumber" runat="server" Height="25px" Width="286px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:10px;">
                    
                </td>
                <td align="left" class="auto-style1">
                    
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" runat="server" IFrameName="ifAddCourseOutcomes"
                        MethodName="wsAddEditCourseOutcome" ParentFrame="ifListCourseOutcome" ParentPage="ListCourseOutcome.aspx"
                        Width="53px" StatusPanelId="lblStatus" CssClass="Button" RefreshParentPage="True" />
                    <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" IFrameName="ifAddCourseOutcomes" Width="12%" 
                        Text="[X] Close" PostBackUrl="ListCourseOutcome" style="z-index: 1; left: 515px; top: 5px; position: absolute; height: 25px;"/>

                </td>
                
               <%-- <td align="left" colspan="2">
                    <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" runat="server" IFrameName="ifAddCourseOutcomes" 
                        MethodName="wsAddEditCourseOutcome" ParentFrame="ifListCourseOutcome" ParentPage="ListCourseOutcome.aspx"
                        Width="53px" CssClass="Button" StatusPanelId="lblStatus" RefreshParentPage="True"/>
                    </td>--%>
                    <%--<ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" Width="53px" CssClass="Button" runat="server" MethodName="wsAddEditCourse" IFrameName=""/>--%>

           
            </tr>

        </table>
    </div>
    </form>
</body>
</html>
