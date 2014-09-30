Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ProctorExam
    Inherits JSIM.Bases.BaseClass

    Dim time1 As TimeSpan = DateTime.Now.AddSeconds(100) - DateTime.Now
    Dim span2 As TimeSpan = TimeSpan.FromSeconds(1)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
            If Session("timerCount") Is Nothing Then
                Session("timerCount") = time1.TotalSeconds
            End If

            Timer1.Enabled = False
        End If
    End Sub
#Region "Local Methods"

    Private Sub SetForm()
        'Retrieves the users's ID from the SvTable
        ' Dim personid As Integer = GetSVTableValue(Of Integer)("personid")
        Dim personid As Integer = 1
        'Dim institutionid As Integer = CInt(Session("institutionIdInContext"))
        ' Dim scheduledexamid As Integer = CInt(Session("selectedExamId"))
        Dim scheduledexamid As Integer = 1
        '' Instance of Data Access Tier
        'Dim oUser As New DataAccessTier.daUser
        ''Retrieves the user's Profile
        'Dim dtUserProfile As DataTable = oUser.GetUserProfileByID(personid, con)
        ''Retrieves user's first and last names from the data table
        'Dim firstname As String = dtUserProfile.Rows(0)("firstname").ToString()
        'Dim lastname As String = dtUserProfile.Rows(0)("lastname").ToString()

        If Not IsNothing(Session("timeDiff")) Then
            Session("timeDiff") = Nothing
        End If
        If Not IsNothing(Session("examStartTime")) Then
            Session("examStartTime") = Nothing
        End If
        If Not IsNothing(Session("remainingTime")) Then
            Session("remainingTime") = Nothing
        End If
        If Not IsNothing(Session("examDate")) Then
            Session("examDate") = Nothing
        End If

        DisplayScheduleExam()
        PopulateGVExamTakers()

    End Sub

    Private Sub DisplayScheduleExam()
        'Dim institutionid As Integer = CInt(Session("institutionIdInContext"))
        'Dim scheduledexamid As Integer = CInt(Session("selectedExamId"))

        Dim institutionid As Integer = 973
        Dim scheduledexamid As Integer = 1

        Dim dtExamInfo As DataTable = GetScheduledExamInfoById(institutionid, scheduledexamid)

        Dim scheduleExamID As String

        If Not IsNothing(dtExamInfo) AndAlso dtExamInfo.Rows.Count > 0 Then
            With dtExamInfo
                scheduleExamID = .Rows(0)("scheduledexamid").ToString()
                lblExam.Text = .Rows(0)("examname").ToString()
                lblLoc.Text = .Rows(0)("examlocation").ToString()
                Session("examDate") = CDate(.Rows(0)("examdate")).ToShortDateString()
                lblStatus.Text = .Rows(0)("status").ToString()
                Dim duration As Integer = Convert.ToInt32(.Rows(0)("duration"))
                Dim examStartTime As DateTime = CDate((.Rows(0)("examStartTime")))
                lblDatetime.Text = Session("examDate").ToString()
                Session("examStartTime") = examStartTime
                If IsNothing(Session("remainingTime")) Then
                    Dim examDateTime As DateTime = CDate(Session("examStartTime"))
                    Dim currentTime As TimeSpan = Now.TimeOfDay
                    Dim examTime As TimeSpan = examDateTime.TimeOfDay
                    Dim timeDiff As Integer = CInt(currentTime.TotalMinutes - examTime.TotalMinutes)
                    If (timeDiff >= 0 And timeDiff < duration) Then
                        Session("timeDiff") = timeDiff
                    Else
                        Session("timeDiff") = Nothing
                    End If
                    Dim remainingTime As TimeSpan
                    If (timeDiff < duration And timeDiff > 0) Then
                        Dim timeGap As Integer = duration - timeDiff
                        remainingTime = TimeSpan.FromMinutes(timeGap)
                    Else
                        remainingTime = TimeSpan.FromMinutes(duration)
                    End If
                    Session("remainingTime") = remainingTime
                End If

            End With
        Else
            'TODO
        End If
    End Sub

    'Populates GridView
    Private Sub PopulateGVExamTakers()
        'Dim ScheduledExamID As Integer = CInt(Session("selectedExamId"))
        Dim ScheduledExamID As Integer = 1

        If Not IsNothing(ScheduledExamID) AndAlso ScheduledExamID > 0 Then
            'rbPerson.Visible = True
            Dim dtTakers As DataTable = GetExamTakersList(ScheduledExamID)
            Dim dv As DataView = dtTakers.DefaultView
            Try
                gvAssignedUsers.DataSource = dv
                gvAssignedUsers.DataBind()
            Catch ex As Exception
                lblStatus.Text = "Data Binding Error: " & ex.Message
                lblStatus.ForeColor = Drawing.Color.Red
            End Try
        Else
            'No role was selected, so don't show anything in grid
            gvAssignedUsers.DataSource = Nothing
            gvAssignedUsers.DataBind()
        End If
    End Sub


    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim counter As Integer = CType(Session("timerCount"), Integer)
        If (counter = 0) Then
            'Response.Redirect("Roster.aspx")
        Else
            counter -= 1
            timerCount.Text = TimeSpan.FromSeconds(counter).ToString()
        End If
        Session("timerCount") = counter
        System.Threading.Thread.Sleep(1000)
    End Sub
	
    'Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    'PopulateGVExamTakers()
    '    'lblTime.Text = "----"
    '    Session("remainingTime") = 60
    '    Dim span1 As TimeSpan = CType(Session("remainingTime"), TimeSpan)
    '    Dim remainingTime2 As TimeSpan
    '    remainingTime2 = span1.Subtract(span2)
    '    lblTime.Text = String.Format("{0}:{1:d2}:{2:d2}", _
    '                               remainingTime2.Hours, _
    '                               remainingTime2.Minutes, _
    '                               remainingTime2.Seconds)
    '    Session("remainingTime") = remainingTime2

    '    If Session("remainingTime").Equals(TimeSpan.Zero) Then
    '        Timer1.Enabled = False
    '        lblTime.Text = "Time is Up"
    '        Session.Remove("examStartTime")
    '        Session.Remove("remainingTime")
    '        Session.Remove("examDate")
    '        Session.Remove("timeDiff")
    '    End If
    '    'Dim examDateTime As DateTime = CDate(Session("examStartTime"))
	
	'    'Dim currentTime As TimeSpan = Now.TimeOfDay
    '    'Dim examTime As TimeSpan = examDateTime.TimeOfDay
    '    'Dim examDate As Date = CDate(Session("examDate"))
    '    'Dim today As Date = Now.Date
    '    'Dim timeDiff As Integer = Convert.ToInt32(Session("timeDiff"))
    '    'Dim TimeCompValue As Integer = (currentTime.CompareTo(examTime))
    '    'Dim DateCompValue As Integer = (today.CompareTo(examDate))
    '    'Dim zero = 0

    '    'If DateCompValue.Equals(zero) Then
    '    '    If TimeCompValue.Equals(zero) Or (TimeCompValue > 0 And (Not IsNothing(Session("timeDiff")))) Then
    '    '        Dim span1 As TimeSpan = CType(Session("remainingTime"), TimeSpan)
    '    '        Dim remainingTime2 As TimeSpan
    '    '        remainingTime2 = span1.Subtract(span2)
    '    '        lblTime.Text = String.Format("{0}:{1:d2}:{2:d2}", _
    '    '                                   remainingTime2.Hours, _
    '    '                                   remainingTime2.Minutes, _
    '    '                                   remainingTime2.Seconds)
    '    '        Session("remainingTime") = remainingTime2

    '    '        If Session("remainingTime").Equals(TimeSpan.Zero) Then
    '    '            Timer1.Enabled = False
    '    '            lblTime.Text = "Time is Up"
    '    '            Session.Remove("examStartTime")
    '    '            Session.Remove("remainingTime")
    '    '            Session.Remove("examDate")
    '    '            Session.Remove("timeDiff")
    '    '        End If
	
    '    '    Else
    '    '        lblTime.Text = "----"
    '    '    End If
    '    'End If
    'End Sub

#End Region

#Region " Local functions "

    Private Function GetScheduledExamInfoById(ByVal InstitutionID As Integer, ByVal scheduledexamid As Integer) As DataTable
        Dim dtExamInfo As DataTable
        Dim cn As String = GetConnectionString("connectionString")
        Dim oExam As New DataAccessTier.daInstitution
        dtExamInfo = oExam.GetScheduledExamInfoById(InstitutionID, scheduledexamid, cn)
        If Not oExam.TransactionSuccessful Then
            dtExamInfo = Nothing
        End If
        Return dtExamInfo
    End Function

    'Get a list of users and whether a role exists a not
    Private Function GetExamTakersList(ByVal ScheduledExamID As Integer) As DataTable
        Dim dtTakers As DataTable
        Dim cn As String = GetConnectionString("connectionString")
        Dim oTaker As New DataAccessTier.daInstitution

        dtTakers = oTaker.GetRosterByScheduledExamId(ScheduledExamID, cn)

        If Not oTaker.TransactionSuccessful Then
            dtTakers = Nothing
        End If
        Return dtTakers
    End Function

#End Region

#Region " Events "

    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 3
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next
        txtPassword.Text = sb.ToString()
    End Sub
	
    Protected Sub gdAssignedUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvAssignedUsers.SelectedIndexChanged
    End Sub

    Protected Sub checkIn_Click(sender As Object, e As EventArgs) Handles checkIn.Click
        Timer1.Enabled = True
    End Sub

    Private Function linkprev() As Object
        Throw New NotImplementedException
    End Function

    Private Function linknext() As Object
        Throw New NotImplementedException
    End Function

    Private Sub saveAnswers()
        Throw New NotImplementedException
    End Sub

#End Region

End Class
