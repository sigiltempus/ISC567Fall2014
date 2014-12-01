<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Exam.aspx.vb" Inherits="ISC567_Fall2014.Exam" %>
<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style2
        {
            width: 660px;
        }

      
        .auto-style3 {
            height: 245px;
        }

      
    </style>
    
   
</head>
<body>
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ListIFrame" >


        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                   </Triggers>
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   
                   <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="100%" Height="400px" CssClass="PanelStyle">
                                     <table style="height: 400px">
                                        <tr>
                                            <td style="vertical-align:top">
                                                <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="Exam" CssClass="IFrameHeader" Width="100%" >
                                                    <%--<ccJSIM:CloseIFrameButton ID="CloseIFrameButton1"  runat="server" IFrameName="ifExam" Text="[X] Close" />--%>
                                                </ccJSIM:DragIFrame>               
                                            </td>
                                            </tr>
                                           <%-- <td style="text-align:right">                   
                                               <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifExam" Text="[X] Close" />
                                            </--%>            
                                        
                                        <tr>
                                            <td class="auto-style3">
                                                <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false" style="z-index: 1; left: 8px; top: 158px; position: absolute"> </asp:Label>
                                                
                                                
                                                <asp:RadioButtonList ID="rbAnswerOptions" runat="server" RepeatDirection="Vertical" >
                                                </asp:RadioButtonList>
                                                
                                                
                                            </td>
                                        </tr>
                                        <tr style="top:380px; left:120px">
                                            <td >
                                                &nbsp;
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 180px; top: 83px; position: absolute" Text="Minutes"></asp:Label>
                                                    <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 113px; top: 84px; position: absolute" Text=""></asp:Label>
                                                    <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 33px; top: 82px; position:absolute; width:94px" Text="Time to go "></asp:Label>                             

                                                    <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 31px; top: 110px; position: absolute; right: 642px" Text="Question:"></asp:Label>
                                                    <asp:Label ID="lblQuestion" runat="server" style="z-index: 1; left: 107px; top:110px; position: absolute; width:449px; height: auto" Text="Ques"></asp:Label>

                                                    <asp:LinkButton ID="linkprev" runat="server" style="z-index: 1; left: 28px; top:355px; position: absolute; bottom: 178px;" Text="Previous">Previous</asp:LinkButton>    
                                                    <asp:LinkButton ID="linknext" runat="server" style="z-index: 1; left: 408px; top:356px; position: absolute" Text="Next" OnClick="linknext_Click" >Next</asp:LinkButton>
                                                    
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                            </asp:Panel>
                    </ContentTemplate>
            </asp:UpdatePanel>
             <table>
           <tr>
               <td></td>
               <td>
                  <asp:Button  ID="btnFinished" runat="server" CssClass="Button" style="z-index: 1; left: 547px; top: 355px; position: absolute"  Text="Finished" />

                                                    
               </td>
           </tr>
       </table>
       
       </div>
  
    </form>
</body>
</html>
