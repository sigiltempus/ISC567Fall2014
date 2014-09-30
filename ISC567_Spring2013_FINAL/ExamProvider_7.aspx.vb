Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ExamProvider_7
    Inherits JSIM.Bases.BaseClass
    Dim cn As String = GetConnectionString("connectionString")
    Dim InstitutionID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setForm()
        End If
    End Sub
    Public Sub setForm()
        populateddl()
        populategv(InstitutionID)
    End Sub

    Public Sub populateddl()

        Dim cn As String = GetConnectionString("connectionString")

        Dim oUser As New DataAccessTier.daUser
        Dim dtInstitutionNames As DataTable
        dtInstitutionNames = oUser.GetInstitutionNames(cn)
        Dim dtInstitutionNamesView As DataView
        dtInstitutionNamesView = dtInstitutionNames.DefaultView
        DropDownList1.DataTextField = "name"
        DropDownList1.DataValueField = "institutionid"
        DropDownList1.DataSource = dtInstitutionNamesView
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem("Name of Universities", "0"))

    End Sub

    Public Sub populategv(InstitutionID As Integer)

        Dim oUser As New DataAccessTier.daUser
        Dim dtInstitutionExams As DataTable
        dtInstitutionExams = oUser.GetExamList(InstitutionID, cn)
        'Dim dtInstitutionExamsView As DataView
        'dtInstitutionExamsView = dtInstitutionExams.DefaultView

        RadioButtonGridView2.DataSource = dtInstitutionExams
        RadioButtonGridView2.DataBind()

    End Sub


    Public Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        RadioButtonGridView2.Visible = True
        InstitutionID = CInt(DropDownList1.SelectedValue)
        populategv(InstitutionID)

    End Sub




    Protected Sub RadioButtonGridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonGridView2.SelectedIndexChanged
        Session("examid") = RadioButtonGridView2.SelectedDataKey.Value
    End Sub
End Class