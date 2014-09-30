Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ExamProvider_1A
    Inherits JSIM.Bases.BaseClass
    Dim cn As String = GetConnectionString("connectionString")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub
#Region "Local Methods"
    Protected Sub SetForm()

        Session("personid") = 1
        Session("username") = "bart"
        PopulateGVExamProvider()
    End Sub

    Protected Sub PopulateGVExamProvider()


        Dim cn As String = GetConnectionString("connectionString")

        Dim oUser As New DataAccessTier.daUser
        Dim dtExamProviderNames As DataTable
        dtExamProviderNames = oUser.GetProviderNames(cn)

        gvExamProvider.DataSource = dtExamProviderNames
        gvExamProvider.DataBind()
    End Sub
#End Region

#Region "Local Functions"
    'Private Function GetProviderNames() As DataTable
    '    Dim dtExamProvInfo As DataTable
    '    Dim cn As String = GetConnectionString("connectionString")
    '    Dim oExamProvInfo As New DataAccessTier.daUser
    '    dtExamProvInfo = oExamProvInfo.GetProviderNames(cn)
    '    Return dtExamProvInfo

    'End Function

#End Region




    'Protected Sub EditProvider_Click(sender As Object, e As EventArgs) Handles EditProvider.Click

    'End Sub

    Protected Sub workOnProvider_Click(sender As Object, e As EventArgs) Handles workOnProvider.Click

    End Sub

    'Protected Sub OpenIFrameButton1_Click(sender As Object, e As EventArgs) Handles OpenIFrameButton1.Click

    'End Sub


    Protected Sub gvExamProvider_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvExamProvider.SelectedIndexChanged
        Dim prvrId As New Integer
        Session("providerid") = CInt(gvExamProvider.SelectedValue)
        'Session("providerid", prvrId)
        'InsertSVTableValue(Of Integer)("providerid", prvrId)
        'InsertSVTableValue("providerid", prvrId)
    End Sub
End Class
