Public Class JDrive
    Private _SNFilename As String
    Private _UserDocumentsPath As String
    Private _JDrive As String
    Private _PJDatabasePath As String

    Public Const PJDatabasePassword As String = "PJ32015"

    Public JournalsPath As String
    Public BooksPath As String
    Public MyBooksPath As String
    Public AudioPath As String
    Public PhotosPath As String

    Public JournalTemplete As String
    Public JournalFolderThumb As String
    Public JournalThumb As String
    Public DefaultMusic As String
    Public DefaultPhoto As String

    Public MusicPath As String
    Public JournalLibraryPath As String

    Private Connection As OleDb.OleDbConnection
    Private PJDataSet As DataSet
    Private PJDataAdapter As OleDb.OleDbDataAdapter

    Public ReadOnly Property SNFilename As String
        Get
            Return _SNFilename
        End Get
    End Property

    Public ReadOnly Property UserDocumentsPath As String
        Get
            Return _UserDocumentsPath
        End Get
    End Property

    Public ReadOnly Property JDrive As String
        Get
            Return _JDrive
        End Get
    End Property

    Public ReadOnly Property PJDatabasePath As String
        Get
            Return _PJDatabasePath
        End Get
    End Property

    Public Sub ExtenalFiles()
        Dim strPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Dim i As Integer = strPath.Count
        strPath = strPath.Substring(6, i - 6)

        JournalTemplete = strPath & "\T4.dotm"
        JournalFolderThumb = strPath & "\J2.png"
        JournalThumb = strPath & "\J1.png"
        DefaultMusic = strPath & "\Default.mp3"
        DefaultPhoto = strPath & "\DefaultPhoto.png"

    End Sub

    Private Sub RelocateDB()
        Dim strPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Dim i As Integer = strPath.Count
        strPath = strPath.Substring(6, i - 6)

        Dim DB As String = strPath & "\PJ.accdb"

        Dim destLocation As String = _PJDatabasePath

        If System.IO.File.Exists(destLocation) = False Then
            System.IO.File.Copy(DB, destLocation)
        End If
    End Sub

    Public Sub SetAllVariables()
        Dim Username As String = My.User.Name
        Dim User() As String = Username.Split("\")
        Dim RealUserName = User(1)

        _UserDocumentsPath = "C:\Users\" & RealUserName & "\Documents\" 'MyDocuments
        CreateDirectory(_UserDocumentsPath & "JDrive")

        _SNFilename = "C:\Users\" & RealUserName & "\Desktop\" 'FileName

        _JDrive = _UserDocumentsPath & "JDrive" 'JDrive
        _PJDatabasePath = _JDrive & "\PJ.accdb"

        RelocateDB()
    End Sub

    Private Sub DataBase(MyUsername As String, MyPassword As String, MyEmail As String)
        Connection = New OleDb.OleDbConnection

        Dim dbProvider As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        Dim dbSource As String = "Data Source = " & PJDatabasePath & ";"
        Dim Password As String = "Jet OLEDB:Database Password=" & PJDatabasePassword

        Connection.ConnectionString = dbProvider & dbSource & Password
        Connection.Open()
        Connection.Close()

        Dim sql As String = "SELECT * FROM PJ"
        PJDataAdapter = New OleDb.OleDbDataAdapter(sql, Connection)

        PJDataSet = New DataSet
        PJDataAdapter.Fill(PJDataSet, "PJ3")

        Dim cb As New OleDb.OleDbCommandBuilder(PJDataAdapter)
        Dim dsNewRow As DataRow

        dsNewRow = PJDataSet.Tables("PJ3").NewRow

        dsNewRow.Item("UserNames") = MyUsername
        dsNewRow.Item("Passwords") = MyPassword
        dsNewRow.Item("Emails") = MyEmail

        PJDataSet.Tables("PJ3").Rows.Add(dsNewRow)

        PJDataAdapter.Update(PJDataSet, "PJ3")
    End Sub

    Private Sub CreateDirectory(Path As String)
        System.IO.Directory.CreateDirectory(Path)
    End Sub

    Public Sub InitializeDirectories(Username As String)
        Dim UserPath As String = JDrive & "\" & Username

        'User
        CreateDirectory(UserPath)

        'Journal Library
        CreateDirectory(UserPath & "\Journal Library")
        CreateDirectory(UserPath & "\Journal Library\Journals")
        CreateDirectory(UserPath & "\Journal Library\Journals\Personal")
        CreateDirectory(UserPath & "\Journal Library\Books")
        CreateDirectory(UserPath & "\Journal Library\Books\My Books")
        CreateDirectory(UserPath & "\Journal Library\Audio")
        CreateDirectory(UserPath & "\Journal Library\Photos")

        'Preferences
        CreateDirectory(UserPath & "\Preferences")

        'Music
        CreateDirectory(UserPath & "\Music")
    End Sub

    Public Sub InitializeAccount(Username As String, Password As String, Email As String)
        SetAllVariables()

        If System.IO.Directory.Exists(JDrive) = False Then
            CreateDirectory(JDrive)
            InitializeDirectories(Username)
        Else
            InitializeDirectories(Username)
            DataBase(Username, Password, Email)
        End If
    End Sub

    Public Sub OpenDB()
        Connection = New OleDb.OleDbConnection

        Dim dbProvider As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        Dim dbSource As String = "Data Source = " & PJDatabasePath & ";"
        Dim MyPassword As String = "Jet OLEDB:Database Password=" & PJDatabasePassword

        Connection.ConnectionString = dbProvider & dbSource & MyPassword
        Connection.Open()
        Connection.Close()

        Dim sql As String = "SELECT * FROM PJ"
        PJDataAdapter = New OleDb.OleDbDataAdapter(sql, Connection)

        PJDataSet = New DataSet
        PJDataAdapter.Fill(PJDataSet, "PJ3")
    End Sub

#Region "Journal Library"

    Public Sub InitializeJL(Username As String)
        ExtenalFiles()
        Dim UserPath As String = JDrive & "\" & Username

        JournalsPath = UserPath & "\Journal Library\Journals"
        BooksPath = UserPath & "\Journal Library\Books"
        MyBooksPath = UserPath & "\Journal Library\Books\My Books"
        AudioPath = UserPath & "\Journal Library\Audio"
        PhotosPath = UserPath & "\Journal Library\Photos"
        JournalLibraryPath = UserPath & "\Journal Library\"
        MusicPath = JDrive & "\" & Username & "\Music\"
    End Sub

    Public Function JournalLibraryItemCounter(Username As String, Location As String, FileExtention As String) As Integer

        Dim Folder As New IO.DirectoryInfo(Location)
        Dim Counter = 0

        Folder.Refresh()

        For Each File As IO.FileInfo In Folder.GetFiles("*" & FileExtention & "*", IO.SearchOption.AllDirectories)
            If File.Name.Substring(0, 2) <> "~$" Then
                Counter += 1
            End If
        Next File

        Return Counter
    End Function

    Public Sub JournalLibraryItem(Listview As System.Windows.Forms.ListView, FileExtention As String, Location As String)
        Dim Folder As New IO.DirectoryInfo(Location)
        Dim Counter As Integer = -1

        Folder.Refresh()
        Listview.Items.Clear()

        For Each File As IO.FileInfo In Folder.GetFiles("*" & FileExtention & "*", IO.SearchOption.AllDirectories)

            If File.Name.Substring(0, 2) <> "~$" Then
                Counter += 1

                Listview.Items.Add(System.IO.Path.GetFileNameWithoutExtension(File.Name))
                Listview.Items.Item(Counter).ImageIndex = 0
            End If

        Next File

        Listview.Height = Form1.LeftSideAppBar.Height - Form1.pbStatusBar.Height - Form1.Panel2.Height
    End Sub

    Public Sub ViewJournalFolders(Listview As System.Windows.Forms.ListView, CurrentPath As String, Extention As String)
        Listview.Items.Clear()

        Dim Counter As Integer = 0
        Dim ItemC As Integer

        For Each Folder As String In IO.Directory.GetDirectories(CurrentPath)
            ItemC = JournalLibraryItemCounter(LogIn.txtUsername.Text, CurrentPath & "\" & System.IO.Path.GetFileName(Folder), "*" & Extention & "*")

          
            If ItemC = 1 Then
                Listview.Items.Add(System.IO.Path.GetFileName(Folder) & vbCrLf & ItemC & " item")
            Else
                Listview.Items.Add(System.IO.Path.GetFileName(Folder) & vbCrLf & ItemC & " items")
            End If

            Listview.Items.Item(Counter).ImageIndex = 0
            'Listview.Items.Item(Counter).SubItems.Item(0).Text = ItemC

            Counter += 1
        Next Folder
        '   Listview.Height = Form1.LeftSideAppBar.Height - Form1.pbStatusBar.Height - Form1.Panel2.Height
    End Sub

    Public Sub AddFolder(Listview As System.Windows.Forms.ListView, CurrentPath As String, Extention As String)
        InitializeJL(LogIn.txtUsername.Text)
        Dim RenameFolder As String = InputBox("Rename Folder: ")

        System.IO.Directory.CreateDirectory(CurrentPath & "\" & RenameFolder)
        ViewJournalFolders(Listview, CurrentPath, Extention)
    End Sub

    Public Sub ChangeView(Listview As System.Windows.Forms.ListView)
        Listview.View = View.Details
    End Sub

    Public Sub RenameFile(CurrentName As String, ListView As System.Windows.Forms.ListView, Extention As String, Path As String)
        Dim Rename As String

        Try
            Rename = InputBox("Rename to:", "Personal Journal", CurrentName)
        Catch ex As Exception
            Rename = CurrentName
        End Try

        Try
            If Extention = ".pdf" Then
                My.Computer.FileSystem.RenameFile(Path & "\" & CurrentName & Extention, Rename & Extention)
                My.Computer.FileSystem.RenameFile(Path & "\" & CurrentName & ".png", Rename & ".png")
            Else
                My.Computer.FileSystem.RenameFile(Path & "\" & CurrentName & Extention, Rename & Extention)
            End If

            JournalLibraryItem(ListView, Extention, Path)
        Catch ex As Exception : End Try
    End Sub

    Public Sub MoveFile(CurrentName As String, ListView As System.Windows.Forms.ListView, Extention As String, Path As String, DestPath As String)
        If MsgBox("Are you sure you want to move " & CurrentName & " to " & System.IO.Path.GetFileName(DestPath) & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                If Extention = ".pdf" Then
                    My.Computer.FileSystem.MoveFile(Path & "\" & CurrentName & Extention, DestPath & "\" & CurrentName & Extention)
                    My.Computer.FileSystem.MoveFile(Path & "\" & CurrentName & ".png", DestPath & "\" & CurrentName & ".png")
                Else
                    My.Computer.FileSystem.MoveFile(Path & "\" & CurrentName & Extention, DestPath & "\" & CurrentName & Extention)
                End If
            Catch ex As Exception : End Try
        End If

    End Sub

    Public Sub RenameFolder(CurrentName As String, ListView As System.Windows.Forms.ListView, Path As String, Extention As String)
        InitializeJL(LogIn.txtUsername.Text)
        Dim Rename As String

        Try
            Rename = InputBox("Rename to:", "Personal Journal", CurrentName)
        Catch ex As Exception
            Rename = "Untitled"
        End Try

        If Rename = "" Then
            Rename = "Untitled"
        End If

        Try
            My.Computer.FileSystem.RenameDirectory(Path & "\" & CurrentName, Rename)
            ViewJournalFolders(ListView, Path, Extention)
        Catch ex As Exception : End Try

    End Sub

    Public Sub DeleteFile(CurrentName As String, ListView As System.Windows.Forms.ListView, Extention As String, Path As String)
        Try
            If (MsgBox("Are you sure you want to delete " & CurrentName & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                If Extention = ".pdf" Then
                    Kill(Path & "\" & CurrentName & Extention)
                    Kill(Path & "\" & CurrentName & ".png")
                Else
                    Kill(Path & "\" & CurrentName & Extention)
                End If

                JournalLibraryItem(ListView, Extention, Path)
            End If
        Catch ex As Exception : End Try
    End Sub

    Public Sub DeleteFolder(CurrentName As String, ListView As System.Windows.Forms.ListView, Extention As String, Path As String)
        Try
            If (MsgBox("Are you sure you want to delete " & CurrentName & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                ' MsgBox(Path & "\" & CurrentName)
                My.Computer.FileSystem.DeleteDirectory(Path & "\" & CurrentName, FileIO.DeleteDirectoryOption.DeleteAllContents)
                ViewJournalFolders(ListView, Path, Extention)
            End If
        Catch ex As Exception : End Try
    End Sub

    Public Sub SaveJournal(JournalWriter As AxEDOfficeLib.AxEDOffice, Username As String, SaveAs As String, Path As String)
        InitializeJL(Username)
        JournalWriter.SaveAs(JournalsPath & "\" & Path & "\" & SaveAs & ".docx")


        MsgBox("Successfully Saved", MsgBoxStyle.Information)
    End Sub

    Public Sub SaveChanges(JournalWriter As AxEDOfficeLib.AxEDOffice, ByRef MoveOn As Integer)
        If JournalWriter.IsDirty = True Then

            If ((MsgBox("Do you want to save changes to Untitled Journal?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes)) Then

                If JournalWriter.IsDirty = True And JournalWriter.GetDocumentName = "T4.dotm" Then
                    SaveAs.Show()
                ElseIf JournalWriter.IsDirty = True And JournalWriter.GetDocumentName <> "T4.dotm" Then
                    JournalWriter.Save()
                End If

                MoveOn = 0

            Else
                MoveOn = 1
            End If

        End If
    End Sub



    

#End Region


    Public Sub New()
        SetAllVariables()
        ExtenalFiles()
    End Sub
End Class
