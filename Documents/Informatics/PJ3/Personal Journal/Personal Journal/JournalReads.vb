Public Class JournalReads

    Private JournalDrive As New JDrive

    Public Sub UploadBook(Listview As System.Windows.Forms.ListView, FileExtention As String, Location As String, ImageList As System.Windows.Forms.ImageList, BookFolder As String)
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)

        Dim AddBooks As New OpenFileDialog
        AddBooks.Multiselect = False
        AddBooks.Filter = "pdf files (*.pdf)|*.pdf*"

        If AddBooks.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each Book As String In AddBooks.FileNames
                System.IO.File.Copy(Book, JournalDrive.BooksPath & "\" & BookFolder & "\" & System.IO.Path.GetFileName(AddBooks.FileName), True)
                GetBookCover(JournalDrive.BooksPath & "\" & BookFolder & "\" & System.IO.Path.GetFileName(AddBooks.FileName), System.IO.Path.GetFileNameWithoutExtension(AddBooks.FileName), BookFolder)

                MsgBox("Uploaded Successfully", MsgBoxStyle.Information)
            Next
        End If

        JournalDrive.JournalLibraryItem(Listview, FileExtention, Location)
        PreviewBookCover(Listview, ImageList, BookFolder)
    End Sub

    Public Sub GetBookCover(BookUrl As String, BookName As String, Foldername As String)
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)

        Dim Doc As Acrobat.CAcroPDDoc
        Dim Page As Acrobat.CAcroPDPage
        Dim Rect As Acrobat.CAcroRect
        Dim RectTemp As Object

        Try
            Doc = CreateObject("AcroExch.PDDoc")
            Dim pdfOpener As Integer = Doc.Open(BookUrl)

            ' Get the first page
            Page = Doc.AcquirePage(0)

            ' Get the size of the page
            RectTemp = Page.GetSize

            ' Create PDFRect to hold dimensions of the page
            Rect = CreateObject("AcroExch.Rect")

            Rect.Left = 0
            Rect.right = RectTemp.x
            Rect.Top = 0
            Rect.bottom = RectTemp.y

            Page.CopyToClipboard(Rect, 0, 0, 100)

            Dim MyClipBoard As IDataObject = Clipboard.GetDataObject()

            If MyClipBoard.GetDataPresent(DataFormats.Bitmap) Then

                Dim BookCover As Bitmap = MyClipBoard.GetData(DataFormats.Bitmap)
                BookCover.Save(JournalDrive.BooksPath & "\" & Foldername & "\" & BookName & ".png")

                BookCover.Dispose()
                Doc.Close()
            End If
        Catch ex As Exception : End Try
    End Sub

    Public Sub PreviewBookCover(Listview As System.Windows.Forms.ListView, ImageList As System.Windows.Forms.ImageList, BooksFolder As String)
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        ImageList.Images.Clear()

        Dim Folder As New IO.DirectoryInfo(JournalDrive.BooksPath & "\" & BooksFolder)

        Dim CoverNames(0) As String
        Dim Counter As Integer = 0

        For Each Cover As IO.FileInfo In Folder.GetFiles("*.png*", IO.SearchOption.AllDirectories)
            ReDim Preserve CoverNames(Counter)

            CoverNames(Counter) = Cover.FullName

            Counter += 1
        Next Cover

        If Counter > 0 Then
            For k As Integer = 0 To UBound(CoverNames)
                If Listview.Items.Item(k).Text = System.IO.Path.GetFileNameWithoutExtension(CoverNames(k)) Then
                    Dim Image As New Bitmap(CoverNames(k))
                    ImageList.Images.Add(Image)


                    Listview.Items.Item(k).ImageIndex = k
                    Image.Dispose()
                End If
            Next k
        End If
    End Sub

    Public Sub LoadBookFolders(Listbox As System.Windows.Forms.ListView)
        Listbox.Show()
        Listbox.Items.Clear()

        JournalDrive.InitializeJL(LogIn.txtUsername.Text)

        For Each Drive As String In IO.Directory.GetDirectories(JournalDrive.BooksPath)
            Listbox.Items.Add(System.IO.Path.GetFileName(Drive))
        Next Drive

        Listbox.Items.Add("Create New Folder")
    End Sub

    Public Sub SelectFolder(FolderName As String, Listbox As System.Windows.Forms.ListView, BookFolderTitle As DevComponents.DotNetBar.LabelX, ListView As System.Windows.Forms.ListView, Imagelist As System.Windows.Forms.ImageList) 'e
        If FolderName = "Create New Folder" Then
            Dim Rename As String = InputBox("Rename New Folder: ", "Personal Journal", "Untitled")
            My.Computer.FileSystem.CreateDirectory(JournalDrive.BooksPath & "\" & Rename)

            LoadBookFolders(Listbox)

        Else
            Listbox.Hide()
            Form1.ButtonX1.Hide()
            BookFolderTitle.Text = FolderName
            JournalDrive.JournalLibraryItem(ListView, ".pdf", JournalDrive.BooksPath & "\" & FolderName)
            PreviewBookCover(ListView, Imagelist, FolderName)
        End If
    End Sub





End Class
