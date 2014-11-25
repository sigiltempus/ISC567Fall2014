Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class AddEditCurriculum
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub
    Private Sub SetForm()
        Dim mode As String = Request.QueryString("mode") ' Get the actual mode from the Query string
        If mode = "add" Then
            AddNew()
        ElseIf mode = "edit" Then
            EditCurriculum()
        End If
        btnCSave.Parameters = CreateParameters()
    End Sub
    Private Sub AddNew()
        lblHeader.Text = "Add Curriculum"
        txtShortName.Text = ""
        txtLongName.Text = ""

    End Sub


    Private Sub EditCurriculum()
        lblHeader.Text = "Edit Curriculum "
        Dim CurriculumID As Integer = CInt(Session("selectedCurriculumId"))
        'Dim skillclassid As Integer = 1
        'Dim ProjectID As Integer = Convert.ToInt32(Request.QueryString("ProjectID"))
        Dim oCurriculum As New DataAccessTier.daProgram
        Dim con As String = GetConnectionString("connectionString")
        Dim dtCurriculumInfo As DataTable = oCurriculum.GetCurriculumById(CurriculumID, con)

        If Not IsNothing(dtCurriculumInfo) AndAlso dtCurriculumInfo.Rows.Count > 0 Then
            With dtCurriculumInfo
                txtShortName.Text = .Rows(0)("curriculum_shortname").ToString()
                txtLongName.Text = .Rows(0)("curriculum_longname").ToString()

            End With

        End If
    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("shortname", txtShortName)
        paramContainer.AddParameter("longname", txtLongName)


        Dim CurriculumID As Integer
        'Dim CurriculumID As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("CurriculumID"))

        CurriculumID = CInt(Session("selectedCurriculumId"))
        'Dim skillclassid As Integer = 1
        paramContainer.AddParameter("CurriculumID", CStr(CurriculumID), False)
        Return MyBase.CreateParameters()
    End Function

#Region "Local Functions"
    Private Shared Function insertCurriculumInfo(ByVal shortname As String, ByVal longname As String) As String
        Dim strStatus As String = ""
        Dim cn As String = GetConnectionString("connectionString")
        Dim oCurriculum As New DataAccessTier.daProgram
        oCurriculum.InsertCurriculumInformation(shortname, longname, cn)
        If oCurriculum.TransactionSuccessful Then
            strStatus = "Curriculum added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Function GetCurriculumInfo(ByVal CurriculumID As Integer) As DataTable
        Dim dtCurriculumInfo As DataTable
        Dim oCurriculum As New DataAccessTier.daProgram
        Dim con As String = GetConnectionString("connectionString")
        dtCurriculumInfo = oCurriculum.GetCurriculumById(CurriculumID, con)
        If Not oCurriculum.TransactionSuccessful Then
            dtCurriculumInfo = Nothing
        End If
        Return dtCurriculumInfo
    End Function

    Private Shared Function editCurriculumInfo(ByVal CurriculumID As Integer, ByVal shortname As String, ByVal longname As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oCurriculum As New DataAccessTier.daProgram
        oCurriculum.EditCurriculumInformation(CurriculumID, shortname, longname, con)
        If oCurriculum.TransactionSuccessful Then
            strStatus = "Curriculum added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
#End Region

#Region "Local WebService Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditCurriculum(ByVal mode As String, ByVal shortname As String, ByVal longname As String,
                                            ByVal CurriculumID As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertCurriculumInfo(shortname, longname)
        ElseIf mode = "edit" Then
            strmsg = editCurriculumInfo(CurriculumID, shortname, longname)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    #End Function

#End Region

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine & _
               "window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub


    Protected Sub lbtnC1lose_Click(sender As Object, e As EventArgs) Handles lbtnC1lose.Click





    End Sub
End Class