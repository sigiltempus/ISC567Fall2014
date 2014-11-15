<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MainMenu.aspx.vb" Inherits="ISC567_Fall2014.MainMenu" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<script src="Scripts/jQuery/jquery.min.js" ></script>
<script src="Scripts/jQuery/jquery-ui.js"></script>
<script src="Scripts/jQuery/jquery.easy-confirm-dialog.js"></script>
<link rel="stylesheet" href="Styles/jQuery/jquery-ui.css" type="text/css" />

<script type="text/javascript">
    $(document).ready(function () {
        $("#yesno").easyconfirm({ locale: { title: 'Select Yes or No', button: ['Yes', 'No'] } });
        $("#yesno").click(function () {
            window.location = "Login.aspx";
        });
    });

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style>
        .auto-style3 {
            width: 84%;
        }
    </style>

</head>

<body>
    <div class="entireSiteWrapper">
        <form id="Form1" runat="server">
            <div class="PageCustomHeader" style="height: 80px; margin-bottom: 0px">
                <table style="height: 98%; width: 100%;">
                    <tr>
                        <td class="auto-style3">
                            <h1 style="text-align: left; width: 102px; margin-bottom: 0px; margin-top: 2px">EDTS</h1>
                            <p style="font-size: 10pt; text-align: left; width: 80%; margin-bottom: 2px; margin-top: 2px;">(Exam Development & Testing Services)</p>
                        </td>
                        <td colspan="2" style="text-align: right; font-size: 10pt">
                            <a href="#" id="yesno">
                                <asp:Label ID="lblLogOutTxt" runat="server" Text="Exit Application" BackColor="#ba1c1c" ForeColor="White" Width="130px" />
                            </a>
                            <br />
                            <br />
                            <asp:Label ID="lblSVLineName" runat="server" Visible="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="menuWrapper">
                <ul id="menuList" runat="server">
                    <li>
                        <a href="#">
                            <ccJSIM:OpenIFrameLinkButton ID="lbtnListPersons" runat="server" FrameSrc="ListPerson.aspx" Text="Administration"
                                IFrameName="ifPersonList" LeftPosition="15" TopPosition="120" WidthPosition="954" HeightPosition="404"
                                ZIndex="100" Visible="false" CssClass="LinkButton">List Person</ccJSIM:OpenIFrameLinkButton>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <ccJSIM:OpenIFrameLinkButton ID="lbtnInstitutionFunctions" runat="server" FrameSrc="ListInstitutionPeople.aspx"
                                IFrameName="ifInstitutionPeopleList" LeftPosition="15" TopPosition="120" WidthPosition="954" HeightPosition="404"
                                ZIndex="100" Visible="false" CssClass="LinkButton">Institution People</ccJSIM:OpenIFrameLinkButton>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <ccJSIM:OpenIFrameLinkButton ID="lbtnExamProviderFunctions" runat="server" FrameSrc="ExamProvider_1A.aspx"
                                HeightPosition="256"
                                IFrameName="ifExamProviderFunctions" LeftPosition="12" TopPosition="120" WidthPosition="575"
                                ZIndex="170" Visible="false" CssClass="LinkButton">Exam Provider Functions(SA)</ccJSIM:OpenIFrameLinkButton>
                        </a>
                    </li>
                    <li>
                       <ccJSIM:OpenIFrameLinkButton ID="lbtnCurriculumFunctions" runat="server" FrameSrc="ListCurriculum.aspx"
                            IFrameName="ifCurriculumList" LeftPosition="15" TopPosition="120" WidthPosition="954" HeightPosition="404"
                            ZIndex="180" Visible="false" CssClass="LinkButton">Curriculm</ccJSIM:OpenIFrameLinkButton>
                    </li>
                    <li>
                        <a href="#">
                        <ccJSIM:OpenIFrameLinkButton ID="lbtnsociety" runat="server" FrameSrc="Listsociety.aspx" HeightPosition="404"
                            IFrameName="ifsocietylist" LeftPosition="20" TopPosition="120" WidthPosition="955"
                            ZIndex="190" Visible="false" CssClass="LinkButton">Society</ccJSIM:OpenIFrameLinkButton>
                            </a>
                    </li>
                    <li>
                       <ccJSIM:OpenIFrameLinkButton ID="lbtnTakerFunctions" runat="server" FrameSrc="TakerFunctions.aspx" HeightPosition="254"
                            IFrameName="ifTakerFunctions" LeftPosition="25" TopPosition="120" WidthPosition="804"
                            ZIndex="160" Visible="false" CssClass="LinkButton">Exam Taker</ccJSIM:OpenIFrameLinkButton>
                    </li>
                </ul>
            </div>
            <div class="contentWrapper">
            </div>
            <div class="footerwrapper">
                <br />
                <div class="copyright">
                    Copyright © FALL 2014 ISC567 Group Project All Rights Reserved.
                </div>
            </div>
            <!-- End of footer !-->
        </form>
    </div>
</body>
</html>

