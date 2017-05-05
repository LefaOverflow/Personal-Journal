Public Class CalendarApp

    Private ArrMonth(12) As String
    Private ArrWeekDays(7) As String

    Private Function InitializeDays(Day As Integer) As String
        ArrWeekDays(1) = "Monday"
        ArrWeekDays(2) = "Tuesday"
        ArrWeekDays(3) = "Wednesday"
        ArrWeekDays(4) = "Thursday"
        ArrWeekDays(5) = "Friday"
        ArrWeekDays(6) = "Saturday"
        ArrWeekDays(7) = "Sunday"

        Return ArrWeekDays(Day)
    End Function

    Private Function InitializeMonths(Month As Integer) As String
        ArrMonth(1) = "Jan"
        ArrMonth(2) = "Feb"
        ArrMonth(3) = "Mar"
        ArrMonth(4) = "Apr"
        ArrMonth(5) = "May"
        ArrMonth(6) = "Jun"
        ArrMonth(7) = "Jul"
        ArrMonth(8) = "Aug"
        ArrMonth(9) = "Sep"
        ArrMonth(10) = "Oct"
        ArrMonth(11) = "Nov"
        ArrMonth(12) = "Dec"

        Return ArrMonth(Month)
    End Function

    Private Sub SetDayOfWeek(Day As DevComponents.DotNetBar.LabelX)
        ''  Dim DayofWeek As Integer = 



        Day.Text = InitializeDays(DateAndTime.Weekday(Date.Today, FirstDayOfWeek.Monday))

    End Sub

    Private Sub SetDate(MyDate As DevComponents.DotNetBar.LabelX)
        MyDate.Text = DateAndTime.Day(Date.Today)
    End Sub

    Private Sub SetMonthYear(MonthYear As DevComponents.DotNetBar.LabelX)

        Dim IntMonth As Integer = Date.Today.Month
        Dim Month As String = DateAndTime.MonthName(IntMonth, True)


        Dim Year As String = DateAndTime.Year(Date.Today)

        MonthYear.Text = Month & " " & Year
    End Sub

    Public Sub SetCalendar(Day As DevComponents.DotNetBar.LabelX, MyDate As DevComponents.DotNetBar.LabelX, MonthYear As DevComponents.DotNetBar.LabelX, SideApp As DevComponents.DotNetBar.SuperTabControl)
        SetDayOfWeek(Day)
        SetDate(MyDate)
        SetMonthYear(MonthYear)
    End Sub

   
End Class
