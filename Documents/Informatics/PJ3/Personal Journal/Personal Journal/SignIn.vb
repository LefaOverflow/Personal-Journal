Public Class SignIn

    Private JournalDrive As New JDrive

    Private Connection As OleDb.OleDbConnection
    Private PJDataSet As DataSet
    Private PJDataAdapter As OleDb.OleDbDataAdapter

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

    Private Function Validation(Username As String, Password As String) As Integer
        Dim FieldsFilled As Boolean
        Dim Username_Password As Boolean

        'Check 
        If (Username <> "") And (Password <> "") Then
            FieldsFilled = True
        End If

        'Check if Username is available
        'OpenDB()

        For k As Integer = 0 To PJDataSet.Tables("PJ3").Rows.Count - 1
            If PJDataSet.Tables("PJ3").Rows(k).Item("Usernames") = Username And PJDataSet.Tables("PJ3").Rows(k).Item("Passwords") = Password Then
                Username_Password = True
            ElseIf Username = "+" And Password = "+" Then
                Return 0
            End If
        Next k

        If FieldsFilled = False Then
            Return 1
        ElseIf Username_Password = False Then
            Return 2
        ElseIf FieldsFilled And Username_Password Then
            Return 3
        Else
            Return -1
        End If
    End Function

    Public Sub LogIn(Username As String, Password As String, Form As System.Windows.Forms.Form, MeForm As System.Windows.Forms.Form)
        Dim Validate As Integer = Validation(Username, Password)

        If Validate = 1 Then
            MsgBox("Some fields are empty!", MsgBoxStyle.Exclamation)
        ElseIf Validate = 2 Then
            MsgBox("Incorrect Username/Password!", MsgBoxStyle.Exclamation)
        ElseIf Validate = 3 Then
            MsgBox("You have successfully signed in.", MsgBoxStyle.Information)
            Form.Show()
            MeForm.Hide()

        End If
    End Sub

End Class
