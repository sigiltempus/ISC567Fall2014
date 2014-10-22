<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExamProvider_7.aspx.vb" Inherits="ISC567_Spring2013.ExamProvider_7" %>

<%@ Register Assembly="JSIM" Namespace="JSIM.Custom_Controls" TagPrefix="ccJSIM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="styles/IFrameStyles.css" />

    <style type="text/css">
        .auto-style1 {
            height: 325px;
            width: 940px;
        }

        .auto-style2 {
            width: 570px;
        }

        #form1 {
            width: 570px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="ListIFrame">
            <table>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <ccJSIM:DragIFrame ID="lblHeader" runat="server" Text="" CssClass="IFrameHeader" Width="99.5%">
                        <asp:Label ID="lblTitle" runat="server" Text="Choose An Exam" Width="90%" style="text-align: left;"></asp:Label>
                        <ccJSIM:CloseIFrameButton ID="lbtnClose" runat="server" IFrameName="ifExamProviderFunctions" Text="[X] Close" style="text-align: right"> </ccJSIM:CloseIFrameButton>
                        </ccJSIM:DragIFrame>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="450px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                               <asp:ListItem>Name of Universities</asp:ListItem>
                               <asp:ListItem></asp:ListItem>
                           </asp:DropDownList>

                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" width="99%"
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="281px">
    <ccJSIM:RadioButtonGridView ID="RadioButtonGridView2" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" ChangeRowColor="True" 
        ForeColor="#333333" GridLines="None" GridSortDirection="ASC" 
        HighlighedRowColor="" IncludeSorting="True" ShowSelectorButton="True" 
        Width="99%" DataKeyNames="examid">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="examid" HeaderText="examid" Visible="false" />
            <asp:BoundField DataField="institutionid" HeaderText="institutionid" Visible="false" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="examname" HeaderText="Exam Name">
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="exampurpose" HeaderText="Purpose of the exam">
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="duration" HeaderText="Duration">
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </ccJSIM:RadioButtonGridView>
                                <ccJSIM:CloseIFrameButton ID="CloseIFrameButton1" runat="server" IFrameName="ifWorkOnExam" Interval="10" PostBackUrl="WorkOnStaff.aspx" style="z-index: 1; left: 468px; top: 350px; position: absolute; width: 86px;" Text="Close" CssClass="Button" />
                    </asp:Panel>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton2" runat="server" FrameSrc="ExamProvider_8.aspx?mode=edit" 
						IFrameName="ifAddExam" Text="Edit Exam" HeightPosition="245" LeftPosition="450" TopPosition="200" WidthPosition="500" ZIndex="210" CssClass="Button" style="z-index: 1; left: 100px; top: 351px; position: absolute; width: 94px;" />
                        &nbsp;
                       <%-- <ccJSIM:OpenIFrameButton ID="OpenIFrameButton3" runat="server" FrameSrc= "ExamProvider_11.aspx"
                            IFrameName="ifAuthor" Text="Authors" Interval="10" HeightPosition="550" LeftPosition="250" TopPosition="100" WidthPosition="990" ZIndex="210" CssClass="Button" style="z-index: 1; left: 198px; top: 350px; position: absolute; width: 81px;" />
                        &nbsp;--%>
                        <ccJSIM:OpenIFrameButton ID="OpenIFrameButton4" runat="server" FrameSrc="ExamProvider_11.aspx" IFrameName="ifExamList" Text="Work On Exam Item"
    						Interval="10" HeightPosition="432" LeftPosition="240" TopPosition="120" WidthPosition="955" ZIndex="210" CssClass="Button" style="z-index: 1; top: 350px; left:218px; position: absolute; width: 220px;"/>
						&nbsp;
						<ccJSIM:OpenIFrameButton ID="OpenIFrameButton1" runat="server" Text ="Add Exam" IFrameName="ifAddExam" Framesrc="ExamProvider_8.aspx?mode=add" Interval="10" HeightPosition="245" LeftPosition="450" TopPosition="200" WidthPosition="500" ZIndex="210" CssClass="Button" style="z-index: 1; left: 19px; top: 350px; position: absolute; width: 72px;"/>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>








	
