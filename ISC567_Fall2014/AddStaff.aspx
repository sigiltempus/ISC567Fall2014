<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddStaff.aspx.vb" Inherits="ISC567_Spring2013.WorkOnStaff" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
    <title></title>
    <link href="styles/IFramestyles.css" rel ="stylesheet" type="text/css" />

    </head>
<body>
<form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">

        </asp:ScriptManager>


    <table cellpadding="0" cellspacing="0" style="width:457px; height:200px;">

            
            <tr class="IFrameHeader" >

                <td align="center" colspan="2">
                    <ccJSIM:DragIFrame ID="DragIFrame1" runat="server" Text="Staff For University of South Alabama " Width="100%" Height="100%"> </ccJSIM:DragIFrame>
                </td>
            </tr>
           

        
     <%--    <tr valign="top">
            <td colspan="2">
                <asp:Label ID="LblStatus" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>--%>
            <tr valign="middle">
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" width="100%"
                               
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="350px">
                                                 <ccJSIM:CheckboxGridView ID="CGVRosterNotProvider" runat="server"></ccJSIM:CheckboxGridView>
                                                <asp:Label ID="lblName" runat="server" Text="Name :" style="z-index: 1; left: 53px; top: 108px; position: absolute; width: 67px"></asp:Label>
                                                <asp:CheckBox ID="isDeveloper" runat="server" style="z-index: 1; left: 359px; top: 164px; position: absolute" Text="Developer" />
                                                <asp:DropDownList ID="ddlName" runat="server" style="z-index: 1; height:11px; left: 79px; top: 304px; position: absolute; height: 25px; width: 221px">
                                                </asp:DropDownList>
                                                <div>
                                                <%--<asp:Label ID="Label3" runat="server" Font-Bold="True" style="z-index: 1; left: 13px; top: 29px; position: absolute; width: 683px" Text="Add Staff" Font-Size="30" BackColor="Red"></asp:Label>--%>

                                                    <asp:CheckBox ID="isEPSA" runat="server" style="z-index: 1; left: 368px; top: 213px; position: absolute" Text="EPSA" />
                                                    <ccJSIM:SaveAndCloseIFrameButton ID="saveProvider" runat="server" FrameSrc="AddStaff.aspx?mode=Add" HeightPosition="550" IFrameName="ifAddEdit" Interval="10" LeftPosition="250" style="z-index: 1; left: 84px; top: 367px; position: absolute; background-color: #FFFAC2" Text="Save Staff" TopPosition="100" WidthPosition="525" />
                                                    <asp:Label ID="nameValue" runat="server" style="z-index: 1; height:14px; left: 122px; top: 98px; position: absolute; height: 53px; width: 105px" Text="Name" Visible="false"></asp:Label>

                            </asp:Panel>
                        </ContentTemplate>
                        <%--<Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlRole" EventName="SelectedIndexChanged" />
                        </Triggers>--%>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr align="left" valign="bottom">
                <td colspan="2">


                   <%-- &nbsp;
                    <ccJSIM:SaveAndCloseIFrameButton ID="saveProvider" runat="server" Text="Save Staff" CssClass="Button1" 
                            IFrameName="ifExamProvider_2ver1" FrameSrc="AddStaff.aspx?mode=Add" Interval="10" 
                            ZIndex="160" HeightPosition="550" LeftPosition="250" TopPosition="100" WidthPosition="1000"/>
                    &nbsp;
                      <ccJSIM:CloseIFrameButton ID="SaveAndCloseIFrameButton1" runat="server" Text="Close" CssClass="Button1" 
                          Interval="10" ZIndex="160" HeightPosition="550" LeftPosition="450" TopPosition="100" WidthPosition="1000"/>--%>
                    <ccJSIM:CloseIFrameButton ID="btnClose" runat="server" style="z-index: 1; left: 275px; top: 365px; position: absolute; width: 73px; background-color: #FFFAC2" Text="Close"  Interval="10" IFrameName="ifAddEdit" PostBackUrl="WorkOnStaff.aspx"/>
                </td>
                
                </tr>

        
    </table>

    </form>
</body>
</html>
