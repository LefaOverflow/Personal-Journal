Public Class SaveAs

    Private JournalDrive As New JDrive


    Private Sub btnsaveas_Click(sender As Object, e As EventArgs) Handles btnsaveas.Click
        Try
            JournalDrive.SaveJournal(Form1.AxEDOffice1, LogIn.txtUsername.Text, txtsave.Text, ComboBox1.Text)
            Form1.InitializeCounters()
            JournalDrive.JournalLibraryItem(Form1.lvJournals, ".docx", JournalDrive.JournalsPath & "\" & Form1.MyJournalFolderName(0))
            JournalDrive.ViewJournalFolders(Form1.lvMyJournals, JournalDrive.JournalsPath, ".docx")

            If Form1.BeforeSave = 1 Then
                Form1.lvJournals_DoubleClick(sender, e)

            ElseIf Form1.BeforeSave = 2 Then
                Form1.NewJournal()

            ElseIf Form1.BeforeSave = 3 Then
                Form1.LogOutToolStripMenuItem_Click(sender, e)
            End If

            Me.Close()
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Private Sub SaveAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)

        For Each Drive As String In IO.Directory.GetDirectories(JournalDrive.JournalsPath)
            ComboBox1.Items.Add(System.IO.Path.GetFileName(Drive))
        Next Drive
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
End Class