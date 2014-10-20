<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="ISC567_Spring2013.Login" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />
</head>
<body>
    <div class="entireSiteWrapper">
        <form id="form1" runat="server">
            <div class="PageCustomHeader" style="height: 110px">

                <h1 style="text-align: center; width: 102px; margin-bottom: 0px; width: 100%">EDTS</h1>
                <br />

                <p style="font-size: 10pt; text-align: center; width: 100%; margin-right: 0px; margin-bottom: 0px; margin-top: 0px;">(Exam Development & Testing Services)</p>

            </div>
            <div class="contentWrapper">
                <div style="text-align: center">
                    <div style="width: 325px; margin-left: auto; margin-right: auto;">
                        <asp:Login ID="UserLogin" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99"
                            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt"
                            Height="257px" UserNameLabelText="Login:" Width="328px">
                            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                        </asp:Login>
                    </div>

                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="lblRegister" runat="server" Text="If you are not yet registered with the system, please "></asp:Label>
                    <ccJSIM:OpenIFrameLinkButton ID="lbtnAddEditPerson" runat="server" FrameSrc="AddEditPerson.aspx" HeightPosition="422"
                        IFrameName="ifAddEditPerson" LeftPosition="250" TopPosition="100" WidthPosition="708"
                        ZIndex="150" Visible="true">create a new user account</ccJSIM:OpenIFrameLinkButton>
                </div>

            </div>
            <div class="footerwrapper">

                <div class="copyright">
                    Copyright © 2011 ISC567 Group Project All Rights Reserved.
                </div>
            </div>
            <!-- End of footer !-->
        </form>
    </div>
</body>
</html>
