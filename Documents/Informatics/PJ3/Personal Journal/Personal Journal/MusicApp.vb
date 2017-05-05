Public Class MusicApp
    Private JournalDrive As New JDrive

    Private DefaultArt As String = JournalDrive.DefaultMusic
    Private ArrSongs() As String
    Private ArrSongzTitles() As String
    Private ArrArtists() As String

    Public Sub LoadAlbums(AlbumList As System.Windows.Forms.ListView, TempMediaPlayer As AxWMPLib.AxWindowsMediaPlayer, ImageList As System.Windows.Forms.ImageList, Location As String)
        AlbumList.Items.Clear()
        ImageList.Images.Clear()

        Dim Folder As New IO.DirectoryInfo(Location)
        Dim ArrAlbums() As String
        Dim Counter = 0

        Folder.Refresh()

        For Each File As IO.FileInfo In Folder.GetFiles("*.m3u*", IO.SearchOption.AllDirectories)
            Counter += 1
            ReDim Preserve ArrAlbums(Counter)

            ArrAlbums(Counter) = System.IO.Path.GetFileNameWithoutExtension(File.Name)
        Next File

        If Counter > 0 Then
            For h As Integer = 1 To UBound(ArrAlbums)

                TempMediaPlayer.URL = Location & ArrAlbums(h) & ".m3u"
                TempMediaPlayer.Ctlcontrols.stop()

                'Loading Mini Album-Arts into ImageList
                Dim DefaultAlbumArt As New ID3TagLibrary.MP3File(DefaultArt) ' TO BE Edited

                Dim currentsong As String = TempMediaPlayer.currentPlaylist.Item(0).sourceURL
                Try
                    Dim MiniArts As New ID3TagLibrary.MP3File(currentsong)
                    ImageList.Images.Add(MiniArts.Tag2.Artwork(38))
                Catch ex As Exception
                    ImageList.Images.Add(DefaultAlbumArt.Tag2.Artwork(38))
                End Try


                Dim AlbumInfo As New ID3TagLibrary.MP3File(currentsong)

                Dim AlbumName As String = ArrAlbums(h)
                Dim Artist As String
                Artist = AlbumInfo.Artist
                If Artist Is Nothing Then
                    Artist = "Unknown Artist"
                End If

                Dim NumSongs As Integer = TempMediaPlayer.currentPlaylist.count

                AlbumList.Items.Add(AlbumName & vbCrLf & Artist & vbCrLf & NumSongs & " songs")
                AlbumList.Items.Item(h - 1).ImageIndex = h - 1

            Next


            Dim DefaultAlbum As New ID3TagLibrary.MP3File(DefaultArt)
            ImageList.Images.Add(DefaultAlbum.Tag2.Artwork(38))

            AlbumList.Items.Add("Add New Album")
            AlbumList.Items.Item(ArrAlbums.Length - 1).ImageIndex = ArrAlbums.Length - 1
        Else
            Dim DefaultAlbum As New ID3TagLibrary.MP3File(DefaultArt)
            ImageList.Images.Add(DefaultAlbum.Tag2.Artwork(38))

            AlbumList.Items.Add("Add New Album")
            AlbumList.Items.Item(0).ImageIndex = 0

        End If

        Form1.lblMusicAlbum.Text = "Albums(" + CStr(Counter) + ")"


    End Sub

    Public Sub AddAlbum(AlbumList As System.Windows.Forms.ListView, TempMediaPlayer As AxWMPLib.AxWindowsMediaPlayer, ImageList As System.Windows.Forms.ImageList, Location As String)

        Dim AlbumName As String = InputBox("Rename Your New Album")

        If AlbumName.Length > 0 Then
            Using NewAlbum As New System.IO.StreamWriter(Location & AlbumName & ".m3u")
                'New Album Created
            End Using

            Try
                Dim Addsongs As New OpenFileDialog
                Addsongs.Multiselect = True
                Addsongs.Filter = "mp3 files (*.mp3)|*.mp3*"

                If Addsongs.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Using SongWriter As New System.IO.StreamWriter(Location & AlbumName & ".m3u", True)

                        For Each song As String In Addsongs.FileNames
                            SongWriter.WriteLine(song)
                        Next song

                    End Using
                End If
            Catch ex As Exception : End Try

            LoadAlbums(AlbumList, TempMediaPlayer, ImageList, Location)
        End If
    End Sub

    Public Sub LoadPlaylist(MusicPlayer As AxWMPLib.AxWindowsMediaPlayer, PlayList As System.Windows.Forms.ListView, ImageList As System.Windows.Forms.ImageList, AlbumArt As System.Windows.Forms.PictureBox, Playlist_Name As String)
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)

        MusicPlayer.URL = JournalDrive.MusicPath & Playlist_Name & ".m3u" ' To Be Edited!!!
        ReDim ArrSongs(MusicPlayer.currentPlaylist.count)
        ReDim ArrArtists(MusicPlayer.currentPlaylist.count)
        ReDim ArrSongzTitles(MusicPlayer.currentPlaylist.count)

        'Initializing Playlist Mini Album-Arts
        ImageList.Images.Clear()

        'Loading Mini Album-Arts into ImageList
        Dim DefaultAlbumArt As New ID3TagLibrary.MP3File(DefaultArt)

        For k As Integer = 1 To MusicPlayer.currentPlaylist.count
            Dim currentsong As String = MusicPlayer.currentPlaylist.Item(k - 1).sourceURL
            Try
                Dim MiniArts As New ID3TagLibrary.MP3File(currentsong)
                ImageList.Images.Add(MiniArts.Tag2.Artwork(38))
            Catch ex As Exception
                ImageList.Images.Add(DefaultAlbumArt.Tag2.Artwork(38))
            End Try
        Next k

        PlayList.Refresh()
        System.Threading.Thread.Sleep(100)

        'Initializing Playlist Content
        PlayList.Items.Clear()

        Dim currentsongz As String = MusicPlayer.currentPlaylist.Item(0).sourceURL
        Dim mp3First As New ID3TagLibrary.MP3File(currentsongz)

        'Song Name
        If mp3First.Title <> "" Then
            ArrSongs(1) = mp3First.Title
        Else
            ArrSongs(1) = MusicPlayer.currentPlaylist.Item(0).name
        End If

        'Artist Name
        If mp3First.Tag2.Artist <> "" Then
            ArrArtists(1) = mp3First.Tag2.Artist
        Else
            ArrArtists(1) = "Unknown Artist"
        End If


        'If Song Name and Artist Name are in range
        If ArrArtists(1).Length < 31 And ArrSongs(1).Length < 31 Then
            PlayList.Items.Add(ArrSongs(1) & vbCrLf & "-" & ArrArtists(1) & "-")

            'If Song Name is too long
        ElseIf ArrSongs(1).Length > 31 And ArrArtists(1).Length < 31 Then
            PlayList.Items.Add(ArrSongs(1).Substring(0, 27) & "..." & vbCrLf & "-" & ArrArtists(1) & "-")

            'If Artist Name is too long
        ElseIf ArrSongs(1).Length < 31 And ArrArtists(1).Length > 31 Then
            PlayList.Items.Add(ArrSongs(1) & vbCrLf & "-" & ArrArtists(1).Substring(0, 27) & "...")

            'If Song Name and Artist Name are too long
        ElseIf ArrArtists(1).Length > 31 And ArrSongs(1).Length > 31 Then
            PlayList.Items.Add(ArrSongs(1).Substring(0, 27) & "..." & vbCrLf & "-" & ArrArtists(1).Substring(0, 27) & "...")

        ElseIf ArrSongs(1).Length > 31 Then
            PlayList.Items.Add(ArrSongs(1).Substring(0, 27) & "..." & vbCrLf & "-" & ArrArtists(1) & "-")
        Else
            PlayList.Items.Add(ArrSongs(1) & vbCrLf & "-" & ArrArtists(1) & "-")
        End If

        'Creating Playlist
        For k As Integer = 2 To MusicPlayer.currentPlaylist.count

            Dim currentsong As String = MusicPlayer.currentPlaylist.Item(k - 1).sourceURL

            Try
                Dim mp3 As New ID3TagLibrary.MP3File(currentsong)

                ArrSongs(k) = MusicPlayer.currentPlaylist.Item(k - 1).name

                'Artist Name
                If mp3.Tag2.Artist <> "" Then
                    ArrArtists(k) = mp3.Tag2.Artist
                Else
                    ArrArtists(k) = "Unknown Artist"
                End If

                '------Playlist Creation- Song Name and Artist Name-----

                'If Song Name and Artist Name are in range
                If ArrArtists(k).Length < 31 And ArrSongs(k).Length < 31 Then
                    PlayList.Items.Add(ArrSongs(k) & vbCrLf & "-" & ArrArtists(k) & "-")

                    'If Song Name is too long
                ElseIf ArrSongs(k).Length > 31 And ArrArtists(k).Length < 31 Then
                    PlayList.Items.Add(ArrSongs(k).Substring(0, 27) & "..." & vbCrLf & "-" & ArrArtists(k) & "-")

                    'If Artist Name is too long
                ElseIf ArrSongs(k).Length < 31 And ArrArtists(k).Length > 31 Then
                    PlayList.Items.Add(ArrSongs(k) & vbCrLf & "-" & ArrArtists(k).Substring(0, 27) & "...")

                    'If Song Name and Artist Name are too long
                ElseIf ArrArtists(k).Length > 31 And ArrSongs(k).Length > 31 Then
                    PlayList.Items.Add(ArrSongs(k).Substring(0, 27) & "..." & vbCrLf & "-" & ArrArtists(k).Substring(0, 27) & "...")

                ElseIf ArrSongs(k).Length > 31 Then
                    PlayList.Items.Add(ArrSongs(k).Substring(0, 27) & "..." & vbCrLf & "-" & ArrArtists(k) & "-")
                Else
                    PlayList.Items.Add(ArrSongs(k) & vbCrLf & "-" & ArrArtists(k) & "-")
                End If

            Catch ex As Exception
                PlayList.Items.Add("Unknown")
            End Try
        Next k
      


        For k As Integer = 1 To PlayList.Items.Count
            PlayList.Items.Item(k - 1).ImageIndex = k - 1
        Next

      
        'Resizing PlayList
        PlayList.Columns.Item(0).Width = PlayList.Width - 20

        'Resizing AlbumArt
        AlbumArt.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Public Sub UpdateAlbumArt(MediaPlayer As AxWMPLib.AxWindowsMediaPlayer, AlbumArt As System.Windows.Forms.PictureBox, Playlist As System.Windows.Forms.ListView, AlbumDetails As System.Windows.Forms.Label, AlbumName As String)
        If MediaPlayer.playState = WMPLib.WMPPlayState.wmppsReady And MediaPlayer.currentPlaylist.count = 1 Then
            Dim mp3Default As New ID3TagLibrary.MP3File(DefaultArt)
            AlbumArt.Image = mp3Default.Tag2.Artwork(100)
        Else


            Dim mp3 As ID3TagLibrary.MP3File

            Try
                mp3 = New ID3TagLibrary.MP3File(MediaPlayer.currentMedia.sourceURL)

                AlbumArt.Image = mp3.Tag2.Artwork(100)

            Catch ex As Exception

                Dim mp3Default As New ID3TagLibrary.MP3File(DefaultArt)
                AlbumArt.Image = mp3Default.Tag2.Artwork(100)

            End Try

            If AlbumArt.Image Is Nothing Then

                Dim mp3D As New ID3TagLibrary.MP3File(DefaultArt)
                AlbumArt.Image = mp3D.Tag2.Artwork(100)

            End If

            If MediaPlayer.currentMedia.name.Length > 25 And mp3.Artist.Length > 15 Then
                UpdateSongName(AlbumDetails, MediaPlayer.currentMedia.name.Substring(0, 25) & "...", AlbumName, mp3.Artist.Substring(0, 15) & "...")
            ElseIf MediaPlayer.currentMedia.name.Length > 25 And mp3.Artist.Length < 15 Then
                UpdateSongName(AlbumDetails, MediaPlayer.currentMedia.name.Substring(0, 25) & "...", AlbumName, mp3.Artist)
            ElseIf MediaPlayer.currentMedia.name.Length < 25 And mp3.Artist.Length > 15 Then
                UpdateSongName(AlbumDetails, MediaPlayer.currentMedia.name, AlbumName, mp3.Artist.Substring(0, 15) & "...")
            Else
                UpdateSongName(AlbumDetails, MediaPlayer.currentMedia.name, AlbumName, mp3.Artist)
            End If
        End If
    End Sub

    Dim Counter As Integer = 0
    Public Sub SelectSong(SongName As Integer, MediaPlayer As AxWMPLib.AxWindowsMediaPlayer)
        Dim Song As String = ArrSongs(SongName)
        Try

            While MediaPlayer.currentMedia.name <> Song

                MediaPlayer.Ctlcontrols.next()

                If MediaPlayer.playState = WMPLib.WMPPlayState.wmppsReady Then
                    Counter += 1
                    MediaPlayer.Ctlcontrols.play()
                    SelectSong(SongName, MediaPlayer) 'Recursion :)
                End If

            End While

        Catch ex As Exception
            MediaPlayer.Ctlcontrols.play()
        End Try
    End Sub

    Public Sub MusicPlayerHider(TimerHider As System.Windows.Forms.Timer, MusicPlayer As AxWMPLib.AxWindowsMediaPlayer, Menubtn As DevComponents.DotNetBar.ButtonX, Addsongsbtn As DevComponents.DotNetBar.ButtonX, pnlAlbumName As System.Windows.Forms.Panel, ByRef Counter As Integer)
        Counter += 1

        If Counter = 10 Then
            MusicPlayer.Visible = False
            Menubtn.Visible = False
            Addsongsbtn.Visible = False
            pnlAlbumName.Visible = False
            Counter = 0
            TimerHider.Stop()
        End If
    End Sub


    Public Sub OpenMusic(ListView As System.Windows.Forms.ListView, SideBar As DevComponents.DotNetBar.SuperTabControl, AlbumArt As System.Windows.Forms.PictureBox, StatusBar As System.Windows.Forms.PictureBox, SideApp As DevComponents.DotNetBar.SuperTabControl)
        SideApp.Visible = True
        ListView.Height = SideBar.Height - AlbumArt.Height - StatusBar.Height
    End Sub

    Public Sub Addsongz(MusicPlayer As AxWMPLib.AxWindowsMediaPlayer, PlayList As System.Windows.Forms.ListView, ImageList As System.Windows.Forms.ImageList, AlbumArt As System.Windows.Forms.PictureBox, Playlist_Name As String)
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)

        Dim Addsongs As New OpenFileDialog
        Addsongs.Multiselect = True
        Addsongs.Filter = "mp3 files (*.mp3)|*.mp3*"

        If Addsongs.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using SongWriter As New System.IO.StreamWriter(JournalDrive.MusicPath & Playlist_Name & ".m3u", True)

                For Each song As String In Addsongs.FileNames
                    SongWriter.WriteLine(song)
                Next song

            End Using
        End If

        LoadPlaylist(MusicPlayer, PlayList, ImageList, AlbumArt, Playlist_Name)
    End Sub

    Public Sub UpdateSongName(AlbumDetails As System.Windows.Forms.Label, SongName As String, AlbumName As String, ArtistName As String)
        AlbumDetails.Text = SongName & vbCrLf & AlbumName & " - " & ArtistName
    End Sub

   

End Class
