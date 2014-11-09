<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditCourse.aspx.vb"
    Inherits="ISC567_Fall2014.AddEditCourse" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/IFrameStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 421px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="ListIFrame" >
        <table style="width: 546px;">
            <tr> 
                <td colspan="2" class="auto-style2"">
                    <ccJSIM:DragIFrame ID="lblHeader" runat="server" CssClass="IFrameHeader" Width="100%" CanDragIFrame="True" Height="30px">
                        <asp:Label ID="lblTitle" runat="server" Text="Add Course" Width="87%"  style="text-align: left; padding: 0; z-index:200"></asp:Label>
                    <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddCourse" Text="[X] Close" />
                        <%--<ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" IFrameName="ifAddCourse" Text="[X] Close" />--%>

                    </ccJSIM:DragIFrame>
                </td>


                <%--<td colspan="2" class="auto-style2"">
                    <ccJSIM:DragIFrame ID="lblHeader" runat="server" CssClass="IFrameHeader" Width="99%" CanDragIFrame="True">
                        <asp:Label ID="lblTitle" runat="server" Text="Add Course" Width="87%" style="text-align: left; padding: 0; z-index:200"></asp:Label>
                    <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddCourse" Width="12%" Text="[X] Close" />
           
                    </ccJSIM:DragIFrame>
                </td> --%>
                
            </tr>
            
            <tr>
                <td align="right">
                    <asp:Label ID="Label7" runat="server" Text="Sequence Number" Width ="100px"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    &nbsp;
                    <asp:TextBox ID="txtSeq" runat="server" Width="40px"  ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Short Name"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    &nbsp;
                    <asp:TextBox ID="txtShortName" runat="server" Width="101px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Long Name"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    &nbsp;
                    <asp:TextBox ID="txtFullName" runat="server" Height="44px" TextMode="MultiLine" 
                        Width="360px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    &nbsp;
                    <asp:TextBox ID="txtDescription" runat="server" Height="60px" TextMode="MultiLine"
                        Width="360px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" Text="Topics"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    &nbsp;
                    <asp:TextBox ID="txttopics" runat="server" Height="46px" TextMode="MultiLine" 
                        Width="360px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label5" runat="server" Text="Discussion"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    &nbsp;
                    <asp:TextBox ID="txtDiscussion" runat="server" Height="52px" 
                        TextMode="MultiLine" Width="360px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label6" runat="server" Text="Year In Prog"></asp:Label>
                </td>
                <td align="left" class="auto-style1">
                    &nbsp;
                    <asp:TextBox ID="txtYear" runat="server" Width="80px"  ></asp:TextBox>
                </td>
            </tr>
       
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left" class="auto-style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" runat="server" IFrameName="ifAddCourse" 
                        MethodName="wsAddEditCourse" ParentFrame="ifCourseList" ParentPage="ListCourse.aspx"
                        Width="53px" CssClass="Button" StatusPanelId="lblStatus" RefreshParentPage="True" />
                    <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" IFrameName="ifAddCourse" Width="12%" Text="[X] Close" PostBackUrl="ListCourse" style="z-index: 1; left: 475px; top: 5px; position: absolute; height: 25px;"/>

                    </td>
                    <%--<ccJSIM:SaveAndCloseIFrameButton ID="btnSave" Text="Save" Width="53px" CssClass="Button" runat="server" MethodName="wsAddEditCourse" IFrameName=""/>--%>

            </tr>
        </table>
    </div>
    </form>
</body>
</html>
