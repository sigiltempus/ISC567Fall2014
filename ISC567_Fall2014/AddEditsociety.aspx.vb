Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class AddEditsociety
    ' Inherits System.Web.UI.Page
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
            Editsociety()
        End If
        btnCSave.Parameters = CreateParameters()
    End Sub
    Private Sub AddNew()
        lblHeader.Text = "Add Society"
        txtShortName.Text = ""
        txtLongName.Text = ""

    End Sub


    Private Sub Editsociety()
        lblHeader.Text = "Edit Society "
        Dim societyID As Integer = CInt(Session("selectedsocietyId"))
        'Dim skillclassid As Integer = 1
        'Dim ProjectID As Integer = Convert.ToInt32(Request.QueryString("ProjectID"))
        Dim osociety As New DataAccessTier.dasociety
        Dim con As String = GetConnectionString("connectionString")
        Dim dtsocietyInfo As DataTable = osociety.GetsocietyInfo(societyID, con)

        If Not IsNothing(dtsocietyInfo) AndAlso dtsocietyInfo.Rows.Count > 0 Then
            With dtsocietyInfo
                txtShortName.Text = .Rows(0)("shortname").ToString()
                txtLongName.Text = .Rows(0)("longname").ToString()

            End With

        End If
    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("shortname", txtShortName)
        paramContainer.AddParameter("longname", txtLongName)


        Dim societyID As Integer
        'Dim societyID As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("societyID"))

        societyID = CInt(Session("selectedsocietyId"))
        'Dim skillclassid As Integer = 1
        paramContainer.AddParameter("societyID", CStr(societyID), False)
        Return MyBase.CreateParameters()
    End Function

#Region "Local Functions"
    Private Shared Function insertsocietyInfo(ByVal shortname As String, ByVal longname As String) As String
        Dim strStatus As String = ""
        Dim cn As String = GetConnectionString("connectionString")
        Dim osociety As New DataAccessTier.dasociety
        osociety.insertsocietyinfo(shortname, longname, cn)
        If osociety.TransactionSuccessful Then
            strStatus = "society added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Function GetsocietyInfo(ByVal societyID As Integer) As DataTable
        Dim dtsocietyInfo As DataTable
        Dim osociety As New DataAccessTier.dasociety
        Dim con As String = GetConnectionString("connectionString")
        dtsocietyInfo = osociety.GetsocietyInfo(societyID, con)
        If Not osociety.TransactionSuccessful Then
            dtsocietyInfo = Nothing
        End If
        Return dtsocietyInfo
    End Function

    Private Shared Function editsocietyInfo(ByVal societyID As Integer, ByVal shortname As String, ByVal longname As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim osociety As New DataAccessTier.dasociety
        osociety.EditsocietyInformation(societyID, shortname, longname, con)
        If osociety.TransactionSuccessful Then
            strStatus = "Society added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
#End Region

#Region "Local WebService Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditsociety(ByVal mode As String, ByVal shortname As String, ByVal longname As String,
                                            ByVal societyID As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertsocietyInfo(shortname, longname)
        ElseIf mode = "edit" Then
            strmsg = editsocietyInfo(societyID, shortname, longname)
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


End Class