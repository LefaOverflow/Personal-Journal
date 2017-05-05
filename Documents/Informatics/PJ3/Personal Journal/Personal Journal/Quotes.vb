Public Class Quotes

    Private JournalDrive As New JDrive

    Private Connection As OleDb.OleDbConnection
    Private PJDataSet As DataSet
    Private PJDataAdapter As OleDb.OleDbDataAdapter

    Private Sub OpenDB()
        Connection = New OleDb.OleDbConnection

        Dim dbProvider As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        Dim dbSource As String = "Data Source = " & JournalDrive.PJDatabasePath & ";"
        Dim MyPassword As String = "Jet OLEDB:Database Password=" & JDrive.PJDatabasePassword

        Connection.ConnectionString = dbProvider & dbSource & MyPassword
        Connection.Open()
        Connection.Close()

        Dim sql As String = "SELECT * FROM Quotes"
        PJDataAdapter = New OleDb.OleDbDataAdapter(sql, Connection)

        PJDataSet = New DataSet
        PJDataAdapter.Fill(PJDataSet, "Quotes")
    End Sub

    Public Sub Thoughtoftheday(lblQuotes As DevComponents.DotNetBar.LabelX)
        OpenDB()

        lblQuotes.Text = PJDataSet.Tables("Quotes").Rows(DateTime.Today.DayOfYear).Item("Quotes")
    End Sub

End Class
