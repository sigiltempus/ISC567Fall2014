Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class ListProgram
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods   "
    Private Sub SetForm()
        PopulateGVPrograms()
    End Sub

    ' populates our gridview
    Private Sub PopulateGVPrograms()
        Dim dtProgramList As DataTable = GetProgramList()
        Dim dvProgramList As DataView

        Try
            If Not IsNothing(dtProgramList) AndAlso dtProgramList.Rows.Count > 0 Then
                dvProgramList = dtProgramList.DefaultView
                dvProgramList.Sort = String.Format("{0} {1}", gvProgramList.GridSortColumn, gvProgramList.GridSortDirection.ToString())
                gvProgramList.DataSource = dvProgramList
                gvProgramList.DataBind()
            Else
                gvProgramList.DataSource = Nothing
                gvProgramList.DataBind()
            End If
        Catch ex As Exception
            lblErrorMessage.Text = ex.Message
            lblErrorMessage.Visible = True
        End Try
    End Sub
#End Region

#Region "Local Functions "

    ' Function returns the list of Programs and its status
    Private Function GetProgramList() As DataTable
        Dim dtProgramList As DataTable
        Dim oProgram As New DataAccessTier.daProgram
        Dim cn As String = GetConnectionString("connectionString")
        dtProgramList = oProgram.GetProgramList(cn)
        If Not oProgram.TransactionSuccessful Then
            dtProgramList = Nothing
        End If
        Return dtProgramList
    End Function

#End Region

#Region " Event "

    Private Sub gvProgramList_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvProgramList.Sorting
        PopulateGVPrograms()
    End Sub

    Protected Sub gvProgramList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvProgramList.SelectedIndexChanged
        'Place selected data from Grid into the session variable
        Dim selectedProgramId As String = gvProgramList.SelectedValue.ToString()
        Dim s As Boolean = InsertSVTableValue(Of Integer)("programId", CInt(selectedProgramId)) 'Using SV Table
        Session.Add("selectedProgramId", selectedProgramId) ' Instead of using SV Table some code may just be requesting from Session Variable
    End Sub

#End Region

End Class