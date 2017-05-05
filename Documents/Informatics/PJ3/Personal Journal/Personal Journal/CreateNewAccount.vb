Public Class CreateNewAccount

    Private Connection As OleDb.OleDbConnection
    Private PJDataSet As DataSet
    Private PJDataAdapter As OleDb.OleDbDataAdapter

    Private JournalDrive As New JDrive

    Public Sub OpenDB()
        Connection = New OleDb.OleDbConnection

        Dim dbProvider As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        Dim dbSource As String = "Data Source = " & JournalDrive.PJDatabasePath & ";"
        Dim MyPassword As String = "Jet OLEDB:Database Password=" & JDrive.PJDatabasePassword

        Connection.ConnectionString = dbProvider & dbSource & MyPassword
        Connection.Open()
        Connection.Close()

        Dim sql As String = "SELECT * FROM PJ"
        PJDataAdapter = New OleDb.OleDbDataAdapter(sql, Connection)

        PJDataSet = New DataSet
        PJDataAdapter.Fill(PJDataSet, "PJ3")
    End Sub


    Public Function Validation(Username As String, Password As String, RetypePassword As String, Email As String, ShowCode As String, SecurityCode As String) As Integer
        Dim FieldsFilled As Boolean
        Dim UserName_Valid As Boolean = True
        Dim PasswordMatch As Boolean
        Dim SecurityMatch As Boolean

        'Check all Fields
        If (Username <> "") And (Password <> "") And (RetypePassword <> "") And (Email <> "") And (SecurityCode <> "") Then
            FieldsFilled = True
        End If

        'Check if Username is available
        OpenDB()

        For k As Integer = 0 To PJDataSet.Tables("PJ3").Rows.Count - 1
            If PJDataSet.Tables("PJ3").Rows(k).Item("Usernames") = Username Then
                UserName_Valid = False
            End If
        Next k

        'Password Match
        If Password = RetypePassword Then
            PasswordMatch = True
        End If

        'Security Match
        If SecurityCode = ShowCode Then
            SecurityMatch = True
        End If

        If FieldsFilled = False Then
            Return 1
        ElseIf UserName_Valid = False Then
            Return 2
        ElseIf PasswordMatch = False Then
            Return 3
        ElseIf SecurityMatch = False Then
            Return 4
        ElseIf FieldsFilled And UserName_Valid And PasswordMatch And SecurityMatch Then
            Return 5
        Else
            Return -1
        End If
    End Function

    Public Sub CreateAccount(Username As String, Password As String, Email As String)
        JournalDrive.InitializeAccount(Username, Password, Email)
    End Sub
End Class
