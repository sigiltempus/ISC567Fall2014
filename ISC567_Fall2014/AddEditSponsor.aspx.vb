Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class AddEditSponsor
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub
    Private Sub SetForm()
        Dim mode As String = Request.QueryString("mode")
        ' Get the actual mode from the Query string
        If mode = "add" Then
            AddNew()
        ElseIf mode = "edit" Then
            EditSponsor()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub
    Private Sub AddNew()
        dgFrame.Text = "Add Sponsor"
        Dim shortname As String = CStr(Session("selectedsocietyName"))
        txtSponsor.Text = shortname
        txtdate.Text = ""
        ddlcurriculum.SelectedIndex = -1
    End Sub


    Private Sub EditSponsor()
        dgFrame.Text = "Edit Sponsor"
        Dim Sponsorid As Integer = CInt(Session("selectedsponsorId"))
        Dim shortname As String = CStr(Session("selectedsponsorName"))
        'Dim skillclassid As Integer = 1
        'Dim ProjectID As Integer = Convert.ToInt32(Request.QueryString("ProjectID"))
        Dim oSponsor As New DataAccessTier.dasponsor

        Dim con As String = GetConnectionString("connectionString")
        Dim dtSponsorInfo As DataTable = oSponsor.GetSponsorInfo(con, Sponsorid)

        If Not IsNothing(dtSponsorInfo) AndAlso dtSponsorInfo.Rows.Count > 0 Then
            txtSponsor.Text = shortname
            With dtSponsorInfo
                txtdate.Text = .Rows(0)("sponsored_on").ToString()
                ddlcurriculum.SelectedValue = .Rows(0)("curriculumid").ToString()
            End With

        End If
    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()

        Dim societyId As Integer = 1 'Get the SocietyId appropriately

        'Dim shortname As String = CStr(Session("selectedsocietyName"))
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("societyid", CStr(societyId), False)
        paramContainer.AddParameter("curriculumid", ddlcurriculum)
        'paramContainer.AddParameter("shortname", shortname)
        paramContainer.AddParameter("Sponsored_date", txtdate)

        Dim sponsorid As Integer = Convert.ToInt32(Session("selectedsponsorId"))
        'Dim Sponsor As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("Sponsor"))

        'Dim skillclassid As Integer = 1
        paramContainer.AddParameter("Sponsorid", CStr(sponsorid), False)
        Return MyBase.CreateParameters()
    End Function

#Region "Local Functions"
    Private Shared Function insertSponsorInfo(ByVal societyid As Integer, ByVal curriculumid As Integer, ByVal sponsored_date As String) As String
        Dim strStatus As String = ""
        Dim cn As String = GetConnectionString("connectionString")
        Dim oSponsor As New DataAccessTier.dasponsor
        oSponsor.insertSponsor(societyid, curriculumid, sponsored_date, cn)
        If oSponsor.TransactionSuccessful Then
            strStatus = "Sponsor added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Function GetSponsorInfo(ByVal Sponsorid As Integer) As DataTable
        Dim dtSponsorInfo As DataTable
        Dim oSponsor As New DataAccessTier.dasponsor
        Dim con As String = GetConnectionString("connectionString")
        dtSponsorInfo = oSponsor.GetSponsorInfo(con, Sponsorid)
        If Not oSponsor.TransactionSuccessful Then
            dtSponsorInfo = Nothing
        End If
        Return dtSponsorInfo
    End Function

    Private Shared Function editSponsorInfo(ByVal Sponsorid As Integer, ByVal societyid As Integer, ByVal curriculumid As Integer, ByVal sponsored_date As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oSponsor As New DataAccessTier.dasponsor
        oSponsor.editSponsorInfo(Sponsorid, societyid, curriculumid, sponsored_date, con)
        If oSponsor.TransactionSuccessful Then
            strStatus = "SkillClass added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
#End Region

#Region "Local WebService Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditSponsor(ByVal mode As String, ByVal societyid As Integer, ByVal curriculumid As Integer,
                                            ByVal sponsored_date As String, ByVal Sponsorid As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertSponsorInfo(societyid, curriculumid, sponsored_date)
        ElseIf mode = "edit" Then
            strmsg = editSponsorInfo(Sponsorid, societyid, curriculumid, sponsored_date)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    End Function

#End Region

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine & _
               "window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub ddlcurriculum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcurriculum.SelectedIndexChanged

    End Sub
End Class