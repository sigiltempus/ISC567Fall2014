Imports JSIM.Bases.SVTable
Public Class AppVariable
    Inherits JSIM.Bases.BaseClass

#Region "Global Variables"
    Public Shared con As String = GetConnectionString("ConnectionString")
    Public Shared AppUser As New DataAccessTier.daUser
    Public Shared UpdateSVT As Boolean = False
    Public Shared personid As Integer = GetSVTableValue(Of Integer)("personid")
    Public Shared selectedPersonid As Integer = GetSVTableValue(Of Integer)("selectedPersonid")
    Public Shared isSA As Boolean = GetSVTableValue(Of Boolean)("isSA")
    Public Shared isTaker As Boolean = GetSVTableValue(Of Boolean)("isTaker")
    Public Shared isInstStaff As Boolean = GetSVTableValue(Of Boolean)("isInstStaff")
    Public Shared isExProvStaff As Boolean = GetSVTableValue(Of Boolean)("isExProvStaff")
    Public Shared isDeveloper As Boolean = GetSVTableValue(Of Boolean)("isDeveloper")
    Public Shared isRoster As Boolean = GetSVTableValue(Of Boolean)("isRoster")
    Public Shared isProvider As Boolean = GetSVTableValue(Of Boolean)("isProvider")
    Public Shared isInstitution As Boolean = GetSVTableValue(Of Boolean)("isInstitution")
    Public Shared isCurriculum As Boolean = GetSVTableValue(Of Boolean)("isCurriculum")
    Public Shared isEmployee As Boolean = GetSVTableValue(Of Boolean)("isEmployee")


#End Region

#Region "Global Methods and Functions"
    Public Shared Sub SVtable(ByVal dtUserProfile As DataTable)
        'Create the SV Table

        'Place data from table into variables that will be passed to the SV table
        Dim personid As String = dtUserProfile.Rows(0)("personid").ToString()
        InsertSVTableValue(Of String)("personid", personid)
        InsertSVTableValue(Of String)("selectedPersonid", selectedPersonid)
        Dim institutionid As String = dtUserProfile.Rows(0)("institutionid").ToString()
        InsertSVTableValue(Of String)("institutionid", institutionid)
        Dim isTaker As String = dtUserProfile.Rows(0)("isTaker").ToString()
        InsertSVTableValue(Of String)("isTaker", isTaker)
        Dim isProvider As String = dtUserProfile.Rows(0)("isProvider").ToString()
        InsertSVTableValue(Of String)("isProvider", isProvider)
        Dim isInstitution As String = dtUserProfile.Rows(0)("isInstitution").ToString()
        InsertSVTableValue(Of String)("isInstitution", isInstitution)
        Dim isInstStaff As String = dtUserProfile.Rows(0)("isInstStaff").ToString()
        InsertSVTableValue(Of String)("isInstStaff", isInstStaff)
        Dim isExProvStaff As String = dtUserProfile.Rows(0)("isExProvStaff").ToString()
        InsertSVTableValue(Of String)("isExProvStaff", isExProvStaff)
        Dim isDeveloper As String = dtUserProfile.Rows(0)("isDeveloper").ToString()
        InsertSVTableValue(Of String)("isDeveloper", isDeveloper)
        Dim isRoster As String = dtUserProfile.Rows(0)("isRoster").ToString()
        InsertSVTableValue(Of String)("isRoster", isRoster)
        Dim isSA As String = dtUserProfile.Rows(0)("isSA").ToString()
        InsertSVTableValue(Of String)("isSA", isSA)
        Dim isCurriculum As String = dtUserProfile.Rows(0)("isCurriculum").ToString()
        InsertSVTableValue(Of String)("isCurriculum", isCurriculum)
        Dim isEmployee As String = dtUserProfile.Rows(0)("isEmployee").ToString()
        InsertSVTableValue(Of String)("isEmployee", isEmployee)
    End Sub




#End Region

#Region "Tests"
    'Public Shared Sub AddSVTable(username, password)
    '    If AppUser.IsFound Then
    '        Dim dtUserProfile As DataTable = AppUser.GetUserProfile(username, password, con)
    '        If Not IsNothing(dtUserProfile) AndAlso dtUserProfile.Rows.Count > 0 Then
    '            ' Store the user profile in our base class 
    '            'UserProfile = dtUserProfile
    '            CreateSVTable(con)
    '            SVtable(dtUserProfile)
    '        End If
    '    End If
    'End Sub


    'Public Shared Sub GetVariables()
    '    Static personid As Integer = GetSVTableValue(Of Integer)("personid")
    '    Static firstname As String = GetSVTableValue(Of String)("firstname")
    '    Static lastname As String = GetSVTableValue(Of String)("lastname")
    '    Static isSA As Boolean = GetSVTableValue(Of Boolean)("isSA")
    '    Static isTaker As Boolean = GetSVTableValue(Of Boolean)("isTaker")
    '    Static isInstStaff As Boolean = GetSVTableValue(Of Boolean)("isInstStaff")
    '    Static isExProvStaff As Boolean = GetSVTableValue(Of Boolean)("isExProvStaff")
    '    Static isDeveloper As Boolean = GetSVTableValue(Of Boolean)("isDeveloper")
    '    Static isRoster As Boolean = GetSVTableValue(Of Boolean)("isRoster")
    '    Static isProvider As Boolean = GetSVTableValue(Of Boolean)("isProvider")
    '    Static isInstitution As Boolean = GetSVTableValue(Of Boolean)("isInstitution")

    'End Sub

    'Public Shared Function GetfirstName() As String
    '    GetSVTableValue(Of String)("firstname")
    '    Return firstname
    'End Function
    'Public Shared 
    'Public Shared Function GetlastName() As String
    '    GetSVTableValue(Of String)("lastname")
    '    Return lastname
    'End Function
#End Region

End Class
