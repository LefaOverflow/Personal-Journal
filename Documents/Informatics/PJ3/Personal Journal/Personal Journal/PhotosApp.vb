Public Class PhotosApp

    Private JournalDrive As New JDrive
    Private DefaultArt As String = JournalDrive.DefaultPhoto

    Public Sub InitializeAlbums(Listview As System.Windows.Forms.ListView, Extention As String, ImageList As System.Windows.Forms.ImageList)
        ImageList.Images.Clear()

        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        Dim Counter As Integer = 0
        Dim MiniCounter As Integer = 0
        Dim ArrPhotos() As String
        Dim FirstPic As String = ""

        Listview.Items.Clear()
        For Each Drive As String In IO.Directory.GetDirectories(JournalDrive.PhotosPath)
            Counter += 1
            ReDim Preserve ArrPhotos(Counter)

            ArrPhotos(Counter) = System.IO.Path.GetFileName(Drive)
        Next Drive

        If Counter > 0 Then
            For k As Integer = 1 To UBound(ArrPhotos)

                Dim Folder As New IO.DirectoryInfo(JournalDrive.PhotosPath & "\" & ArrPhotos(k))
                For Each File As IO.FileInfo In Folder.GetFiles("*.jpg*", IO.SearchOption.AllDirectories)
                    FirstPic = File.FullName
                Next File


                Dim ItemC As Integer = JournalDrive.JournalLibraryItemCounter(LogIn.txtUsername.Text, JournalDrive.PhotosPath & "\" & System.IO.Path.GetFileName(ArrPhotos(k)), "*" & Extention & "*")

                If ItemC = 1 Then
                    Listview.Items.Add(System.IO.Path.GetFileName(ArrPhotos(k)) & vbCrLf & ItemC & " photo")
                Else
                    Listview.Items.Add(System.IO.Path.GetFileName(ArrPhotos(k)) & vbCrLf & ItemC & " photos")
                End If

                If FirstPic <> "" Then
                    Dim AlbumCover As New System.Drawing.Bitmap(FirstPic)
                    ImageList.Images.Add(AlbumCover)
                    Listview.Items.Item(k - 1).ImageIndex = k - 1
                Else
                    Dim DefaultCoverr As New System.Drawing.Bitmap(DefaultArt)
                    ImageList.Images.Add(DefaultCoverr)
                    Listview.Items.Item(k - 1).ImageIndex = k - 1
                End If

                FirstPic = ""

            Next k

            Dim DefaultCover As New System.Drawing.Bitmap(DefaultArt)
            Listview.Items.Add("Add New Album")
            ImageList.Images.Add(DefaultCover)
            Listview.Items.Item(ArrPhotos.Length - 1).ImageIndex = ArrPhotos.Length - 1

        Else

            Dim DefaultCover As New System.Drawing.Bitmap(DefaultArt)
            Listview.Items.Add("Add New Album")
            ImageList.Images.Add(DefaultCover)
            Listview.Items.Item(0).ImageIndex = 0
        End If

        Listview.Height = Form1.LeftSideAppBar.Height - Form1.pbStatusBar.Height - Form1.Panel2.Height
    End Sub

    Private ArrPhotos(0) As String
    Private Rename As String
    Public Sub AddPhotos()
        Rename = InputBox("Rename new Album: ", "Personal Journal", "Untitled")

        My.Computer.FileSystem.CreateDirectory(JournalDrive.PhotosPath & "\" & Rename)

        Dim AddPhotos As New OpenFileDialog
       

        AddPhotos.Multiselect = True
        AddPhotos.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png*"

        Dim Counter As Integer = 0
        If AddPhotos.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each Photo As String In AddPhotos.FileNames
                ReDim Preserve ArrPhotos(Counter)
                ArrPhotos(Counter) = Photo
                Counter += 1

            Next Photo
        End If
    End Sub

    Public Sub AddPhotosBW(lblTitle As DevComponents.DotNetBar.LabelX)
        Dim Length As Long
        Dim PhotoSize As IO.FileInfo
        Dim Counter As Integer = 0

        For k As Integer = 0 To UBound(ArrPhotos)
            Counter += 1

            lblTitle.Text = Counter & "/" & ArrPhotos.Length & " photos"
            lblTitle.Refresh()
            System.Threading.Thread.Sleep(100)

            PhotoSize = New IO.FileInfo(ArrPhotos(k))
            Length = PhotoSize.Length / 1000

            If Length < 200 Then
                My.Computer.FileSystem.CopyFile(ArrPhotos(k), JournalDrive.PhotosPath & "\" & Rename & "\" & System.IO.Path.GetFileName(ArrPhotos(k)))

            ElseIf Length > 200 And Length < 1000 Then
                CompressPhoto(ArrPhotos(k), JournalDrive.PhotosPath & "\" & Rename & "\" & System.IO.Path.GetFileName(ArrPhotos(k)), 0.4)

            ElseIf Length > 1000 Then
                CompressPhoto(ArrPhotos(k), JournalDrive.PhotosPath & "\" & Rename & "\" & System.IO.Path.GetFileName(ArrPhotos(k)), 0.1)
            End If
        Next
    End Sub

    Private Sub CompressPhoto(PhotoPath As String, DestinationPath As String, Ratio As Double)
        Dim CompressImage = New Bitmap(PhotoPath)

        Dim CompressHelper As New Bitmap(CompressImage.Width * Ratio, CompressImage.Height * Ratio, Imaging.PixelFormat.Format24bppRgb)
        Dim EGD As Graphics = Graphics.FromImage(CompressHelper)

        EGD.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        EGD.DrawImage(CompressImage, 0, 0, CompressHelper.Width, CompressHelper.Height)

        CompressHelper.Save(DestinationPath)

        CompressImage.Dispose()
        CompressHelper.Dispose()
        EGD.Dispose()
    End Sub

    Private ArrUploadPhotos(0) As String
    Public Sub UploadPhotos(PhotoAlbum As String)
        Dim AddPhotos As New OpenFileDialog
        

        AddPhotos.Multiselect = True
        AddPhotos.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png*"

        Dim Counter As Integer = 0
        If AddPhotos.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each Photo As String In AddPhotos.FileNames
                ReDim Preserve ArrUploadPhotos(Counter)
                ArrUploadPhotos(Counter) = Photo
                Counter += 1
            Next Photo
        End If
    End Sub

    Public Sub BWUploadPhotos(PhotoAlbum As String, lblTitle As DevComponents.DotNetBar.LabelX)
        Dim Length As Long
        Dim PhotoSize As IO.FileInfo
        Dim Counter As Integer

        Try
            For k As Integer = 0 To UBound(ArrUploadPhotos)
                Counter += 1

                lblTitle.Text = Counter & "/" & ArrUploadPhotos.Length & " photos"
                lblTitle.Refresh()
                System.Threading.Thread.Sleep(100)

                PhotoSize = New IO.FileInfo(ArrUploadPhotos(k))
                Length = PhotoSize.Length / 1000 'kB

                If Length < 200 Then
                    My.Computer.FileSystem.CopyFile(ArrUploadPhotos(k), JournalDrive.PhotosPath & "\" & PhotoAlbum & "\" & System.IO.Path.GetFileName(ArrUploadPhotos(k)), False)

                ElseIf Length > 200 And Length < 1000 Then
                    CompressPhoto(ArrUploadPhotos(k), JournalDrive.PhotosPath & "\" & PhotoAlbum & "\" & System.IO.Path.GetFileName(ArrUploadPhotos(k)), 0.4)

                ElseIf Length > 1000 Then
                    CompressPhoto(ArrUploadPhotos(k), JournalDrive.PhotosPath & "\" & PhotoAlbum & "\" & System.IO.Path.GetFileName(ArrUploadPhotos(k)), 0.1)
                End If
            Next k
        Catch ex As Exception
            lblTitle.Text = PhotoAlbum
        End Try
    End Sub

    Public Sub PopulatePhotos(Listview As System.Windows.Forms.ListView, ImageList As System.Windows.Forms.ImageList, AlbumName As String)
        ImageList.Images.Clear()
        Listview.Items.Clear()
        Listview.Refresh()

        Dim Folder As New IO.DirectoryInfo(JournalDrive.PhotosPath & "\" & AlbumName)
        Dim Counter As Integer = 0

        Dim AlbumCover As Bitmap
        Dim picc As New PictureBox

        For Each File As IO.FileInfo In Folder.GetFiles("*.jpg*", IO.SearchOption.AllDirectories)
            AlbumCover = New Bitmap(File.FullName, False)


            ImageList.Images.Add(AlbumCover)
            ' AlbumCover.Dispose()
            Listview.Items.Add("")
            Listview.Items.Item(Counter).Name = File.FullName
            Counter += 1

            Listview.Items.Item(Counter - 1).ImageIndex = Counter - 1
            System.Threading.Thread.Sleep(1)
            File.Refresh()
            Listview.Refresh()


        Next File





    End Sub

    Public Sub PhotoReview(PhotoViewerFrame As System.Windows.Forms.Panel, PhotoViewer As System.Windows.Forms.PictureBox, PhotoPath As String)
        PhotoViewerFrame.BringToFront()
        PhotoViewerFrame.Show()

        PhotoViewerFrame.Top = (Form1.ClientSize.Height / 2) - (PhotoViewerFrame.Height / 2)
        PhotoViewerFrame.Left = (Form1.ClientSize.Width / 2) - (PhotoViewerFrame.Width / 2)

        PhotoViewer.Load(PhotoPath)
        PhotoViewer.SizeMode = PictureBoxSizeMode.Zoom

    End Sub

    Public Sub KillPhoto(Url As String, Imagelist As System.Windows.Forms.ImageList)
        Try
            Imagelist.Images.Clear()
            Kill(Url)
        Catch ex As Exception : End Try


    End Sub

End Class
