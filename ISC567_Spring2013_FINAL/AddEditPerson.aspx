<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddEditPerson.aspx.vb" Inherits="ISC567_Spring2013.AddEditPerson" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add/Edit person</title>
    <script src="Scripts/jQuery/jquery-1.9.1.js"></script>
    <script src="Scripts/jQuery/jquery-ui.js"></script>
    <link rel="stylesheet" href="Styles/jQuery/jquery-ui.css" />

    <link rel="stylesheet" href="/resources/demos/style.css" />

    <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 320px;
            width: 690px;
        }

        .auto-style2 {
            height: 20px;
            width: 690px;
        }

        .chkBxList input {
            margin-left: 20px;
        }

        .chkBxList td {
            padding-left: 10px;
        }
    </style>
    <script>
        $(function () {
            $("#txtDateOfBirth").datepicker();
        });
    </script>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame" style="height: 420px;">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" CanDragIFrame="True" Text="" CssClass="IFrameHeader" Width="100%">
                            <asp:Label ID="lblTitle" runat="server" Text="" Width="85%" style="text-align: left;"></asp:Label>
                            <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifAddEditPerson" Text="[X] Close" style="text-align: right" />
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" BorderStyle="Solid" BorderColor="Black"
                            BorderWidth="2px" class="auto-style1">
                            <table style="width: 98%;" id="tblName">
                                <tr style="text-decoration-style: solid;">
                                    <td style="width: 48%;">Institution<br />
                                        <asp:DropDownList ID="ddlInstitution" runat="server" Style="width: 100%;">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td colspan="2" style="width: 48%;">Provider<br />
                                        <asp:DropDownList ID="ddlProvider" runat="server" Style="width: 100%;">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 48%; white-space: nowrap;">First Name<br />
                                        <asp:TextBox ID="txtFirstName" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValFirstName" runat="server" ErrorMessage="First Name is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtFirstName">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td colspan="2" style="width: 48%; white-space: nowrap;">Last Name<br />
                                        <asp:TextBox ID="txtLastName" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValLastName" runat="server" ErrorMessage="Last Name is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtLastName">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 48%; white-space: nowrap;">Email Address<br />
                                        <asp:TextBox ID="txtEmail" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RegularExpressionValidator runat="server" ID="txtEmailValidator" ControlToValidate="txtEmail"
                                            Display="Dynamic" ErrorMessage="Invalid Email Address" Text="*" ForeColor="Red"
                                            ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td colspan="2" style="width: 48%; white-space: nowrap;">Date of Birth<br />
                                        <input runat="server" type="text" id="txtDateOfBirth" />
                                        <asp:RegularExpressionValidator runat="server" ID="ValDOB" ControlToValidate="txtDateOfBirth"
                                            ValidationExpression="^[0-3]?[0-9]/[0-3]?[0-9]/(?:[0-9]{2})?[0-9]{2}$"
                                            ErrorMessage="Invalid Date of Birth" Display="Dynamic" Text="*" ForeColor="Red">   
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 48%; white-space: nowrap;">Address Line 1<br />
                                        <asp:TextBox ID="txtAddress1" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValtxtAddress1" runat="server" ErrorMessage="Address Line 1 is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtAddress1" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 4%;">&nbsp;</td>
                                    <td colspan="2" style="width: 48%;">Address Line 2<br />
                                        <asp:TextBox ID="txtAddress2" runat="server" Style="width: 100%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 48%; white-space: nowrap;">City<br />
                                        <asp:TextBox ID="txtCity" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValtxtCity" runat="server" ErrorMessage="City is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtCity" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 4%;">&nbsp;</td>
                                    <td style="width: 20%; white-space: nowrap;">State<br />
                                        <asp:TextBox ID="txtState" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValtxtState" runat="server" ErrorMessage="State is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtState" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 25%; padding-left: 4px; white-space: nowrap;">Zip Code<br />
                                        <asp:TextBox ID="txtZip" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RegularExpressionValidator runat="server" ID="txtZipValidator" ControlToValidate="txtZip"
                                            ValidationExpression="^\d{5}(-\d{4})?$" ErrorMessage="Invalid Zip Code" Display="Dynamic" Text="*" ForeColor="Red">                                            
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 48%; white-space: nowrap;">Primary Phone #<br />
                                        <asp:TextBox ID="txtPrimaryPhone" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RegularExpressionValidator runat="server" ID="ValPrimaryPhone" ControlToValidate="txtPrimaryPhone"
                                            ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"
                                            ErrorMessage="Invalid Primary Phone #" Display="Dynamic" Text="*" ForeColor="Red">                                           
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td style="width: 4%;">&nbsp;</td>
                                    <td colspan="2" style="width: 48%;">Phone Type<br />
                                        <asp:DropDownList ID="ddlPhoneType1" runat="server" Style="width: 100%;">
                                            <asp:ListItem>Cell</asp:ListItem>
                                            <asp:ListItem>Home</asp:ListItem>
                                            <asp:ListItem>Work</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 48%; white-space: nowrap;">Alternate Phone #<br />
                                        <asp:TextBox ID="txtAlternatePhone" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtAlternatePhone"
                                            ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$" ErrorMessage="Invalid Alternate Phone #"
                                            Display="Dynamic" Text="*" ForeColor="Red">                                           
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td style="width: 4%;">&nbsp;</td>
                                    <td colspan="2" style="width: 48%;">Phone Type<br />
                                        <asp:DropDownList ID="ddlPhoneType2" runat="server" Style="width: 100%;">
                                            <asp:ListItem>Cell</asp:ListItem>
                                            <asp:ListItem>Home</asp:ListItem>
                                            <asp:ListItem>Work</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="width: 100%;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel2" runat="server" Width="100%" CssClass="PanelStyle">
                                                    <asp:CheckBoxList ID="chkBxRoleLists" runat="server" AutoPostBack="True" TabIndex="2"
                                                        RepeatDirection="Vertical" RepeatColumns="3" Visible="true" CssClass="chkBxList">
                                                    </asp:CheckBoxList>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%; white-space: nowrap;">Choose a User Name<br />
                                        <asp:TextBox ID="txtUserName" runat="server" Style="width: 100%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValtxtUserName" runat="server" ErrorMessage="Username is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtUserName" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 48%; white-space: nowrap;">Password<br />
                                        <asp:TextBox ID="txtPassword" runat="server" Style="width: 100%;" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValtxtPassword" runat="server" ErrorMessage="Password is required"
                                            Text="*" ForeColor="Red" ControlToValidate="txtPassword" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 4%;">&nbsp;</td>
                                    <td colspan="2" style="width: 48%; white-space: nowrap;">Confirm Password<br />
                                        <asp:TextBox ID="txtPasswordConfirm" runat="server" Style="width: 100%;" TextMode="Password"></asp:TextBox>
                                        <asp:CompareValidator ID="CValtxtPasswordConfirm" runat="server" ControlToValidate="txtPassword"
                                            ControlToCompare="txtPasswordConfirm" EnableClientScript="true" Text="*" ForeColor="Red"
                                            ErrorMessage="The passwords you have entered do not match." Display="Dynamic">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please correct the errors specified below before proceeding"
                                            DisplayMode="BulletList" EnableClientScript="true" ForeColor="Red" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 20px;">
                        <ccJSIM:SaveAndCloseIFrameButton ID="btnSave" runat="server" OnClick="btnSave_Click" IFrameName="ifAddEditPerson" Interval="100"
                            Text=" [✓] SAVE " Width="100px" ParentFrame="ifPersonList" ParentPage="ListPerson.aspx" CssClass="Button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
