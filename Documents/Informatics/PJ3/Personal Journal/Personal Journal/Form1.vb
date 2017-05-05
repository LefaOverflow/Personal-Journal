Imports System.Net


Public Class Form1

    Private SideBars As New SideBarApps
    Private Initialize As New InitializePJ
    Private Music As New MusicApp
    Private Calendar As New CalendarApp
    Private Weather As New WeatherApp
    Private AudioJournal As New AudioJournalApp
    Private JournalDrive As New JDrive
    Private Reads As New JournalReads
    Private Thoughts As New Quotes
    Private Photos As New PhotosApp

    Private LeftBarCounter, RightBarCounter, TimerMusicCounter As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        JournalDrive.SetAllVariables()
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)


        Dim FolderIcon As New Bitmap(JournalDrive.JournalFolderThumb)
        ImageListJournalLibrary.Images.Clear()
        ImageListJournalLibrary.Images.Add(FolderIcon)

        Dim JournalIcon As New Bitmap(JournalDrive.JournalThumb)
        ImageListJournals.Images.Clear()
        ImageListJournals.Images.Add(JournalIcon)

        'lvJournals.Height =
        tmrIsDirty.Start()
        Control.CheckForIllegalCrossThreadCalls = False
        ' ProgressBarPhotos.Hide()

        MonthCalendarAdv1.DisplayMonth = Date.Today

        lbBookFolders.Hide()

        ButtonX1.Hide()
        pnlPhotoViewer.Hide()

        PictureBox2.Hide()
        PictureBox1.Height = Me.Height
        PictureBox1.Width = Me.Width

        PictureBox3.Visible = False
        lblNowPlaying.Hide()

        LeftBarCounter = 0
        RightBarCounter = 0
        TimerMusicCounter = 0



        Music.LoadAlbums(lvMusicMenu, AxWindowsMediaPlayer2, ImageList2, JournalDrive.MusicPath) 'NBBBBBBBBBBBBBBB

        lblCalendarDate.Parent = pbCalendar
        lblCalendarDay.Parent = pbCalendar
        lblCalendarMonth.Parent = pbCalendar

        btnMenu.Visible = False
        btnAddSongz.Visible = False
        pnlAlbumTitle.Visible = False

        lvMusicMenu.Columns.Item(0).Width = lvMusicMenu.Width
        lvAudioJournal.Height = RightSideAppBar.Height - pnlAudioJournal.Height - pbStatusBar.Height



        'Calculator1.Visible = False
        pnlGraph.Visible = False

        txtCalDisplay.Height = RightSideAppBar.Height - pnlCalculator.Height - Panel1.Height


        AxWindowsMediaPlayer1.Visible = False
        AxWindowsMediaPlayer2.Visible = False

        Me.lblQuotes.Location = Me.bbSmartDock.PointToClient(Me.PointToScreen(Me.lblQuotes.Location))
        Me.lblQuotes.Parent = Me.bbSmartDock

        tmrInitialize.Start()



        AxEDOffice1.OpenWord(JournalDrive.JournalTemplete)
        'AxEDOffice1.OpenWord("C:\Users\Lefa\Documents\JDrive\Demo\Journal Library\Journals\kk.docx")

        LeftSideAppBar.Visible = False
        RightSideAppBar.Visible = False

        AxEDOffice1.Toolbars = False

        AxEDOffice1.ViewZoomTo(120)


        pnlLeftSideBar.Visible = False
        pnlRightSideBar.Visible = False

        tmrLeftBarPop.Start()
        tmrRightBarPop.Start()

        bbSmartDock.SelectedTab = BubbleBarTab1
        Button1.Visible = False

        ' lvPlaylist.Height = RightSideAppBar.Height - pbAlbumArt.Height - pbStatusBar.Height

        ' wbSocialMedia.Navigate("m.facebok.com")

        Thoughts.Thoughtoftheday(lblQuotes)
        PictureBox1.Hide()
        ' lvJournals.Height = LeftSideAppBar.Height - pbStatusBar.Height

        lvJournalLibrary.Height = LeftSideAppBar.Height - pbStatusBar.Height - Panel2.Height
        lvMyJournals.Height = LeftSideAppBar.Height - pbStatusBar.Height - Panel2.Height

        Dim Tip As New ToolTip
        Tip.SetToolTip(btnAddSongz, "Add Songs")
        Tip.SetToolTip(btnMenu, "Go to Album menu")

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tmrInitialize.Tick
        Initialize.Initialize(wbSocialMedi, LeftSideAppBar, pbStatusBar, AxEDOffice1, MainTab, lblQuotes, Me)
    End Sub

    Private Sub tmrLeftBarPop_Tick(sender As Object, e As EventArgs) Handles tmrLeftBarPop.Tick
        SideBars.PanelShow(pnlLeftSideBar, pbStatusBar, MousePosition, Me, MSMain, bbSmartDock, MainTab, tmrLeftBarPop, 1)
    End Sub

    Private Sub tmrLeftBarHide_Tick(sender As Object, e As EventArgs) Handles tmrLeftBarHide.Tick
        SideBars.PanelHider(tmrLeftBarHide, tmrLeftBarPop, pnlLeftSideBar, LeftBarCounter)
    End Sub

    Private Sub tmrRightBarPop_Tick(sender As Object, e As EventArgs) Handles tmrRightBarPop.Tick
        SideBars.PanelShow(pnlRightSideBar, pbStatusBar, MousePosition, Me, MSMain, bbSmartDock, MainTab, tmrRightBarHide, 2)
    End Sub

    Private Sub tmrRightBarHide_Tick(sender As Object, e As EventArgs) Handles tmrRightBarHide.Tick
        SideBars.PanelHider(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightBarCounter)
    End Sub

    Private Sub pnlLeftSideBar_MouseLeave(sender As Object, e As EventArgs) Handles pnlLeftSideBar.MouseLeave, pnlSideBar1Extention.MouseLeave
        tmrLeftBarHide.Start()
    End Sub

    Private Sub pnlLeftSideBar_MouseHover(sender As Object, e As EventArgs) Handles pnlLeftSideBar.MouseHover, pnlFaceBook.MouseHover, pnlTwitter.MouseHover, pnlInstagram.MouseHover, pnlLinkedIn.MouseHover, pnlSideBar1Extention.MouseHover, pnlHideLeftBar.MouseHover
        tmrLeftBarHide.Stop()
        LeftBarCounter = 0
    End Sub

    Private Sub pnlRightSideBar_MouseLeave(sender As Object, e As EventArgs) Handles pnlRightSideBar.MouseLeave, pnlSideBar1Extention2.MouseLeave
        tmrRightBarHide.Start()
    End Sub

    Private Sub pnlRightSideBar_MouseHover(sender As Object, e As EventArgs) Handles pnlRightSideBar.MouseHover, pnlMusic.MouseHover, pnlWeather.MouseHover, pnlCalculator.MouseHover, pnlCalendar.MouseHover, pnlSideBar1Extention2.MouseHover, pnlHideRightBar.MouseHover
        tmrRightBarHide.Stop()
        RightBarCounter = 0
    End Sub

    Private Sub pnlHideLeftBar_Click(sender As Object, e As EventArgs) Handles pnlHideLeftBar.Click
        SideBars.AppHider(LeftSideAppBar, pnlLeftSideBar, tmrLeftBarPop)
    End Sub

    Private Sub pnlHideRightBar_Click(sender As Object, e As EventArgs) Handles pnlHideRightBar.Click
        SideBars.AppHider(RightSideAppBar, pnlRightSideBar, tmrRightBarPop)
    End Sub

    Private Sub pnlFaceBook_Click(sender As Object, e As EventArgs) Handles pnlFaceBook.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocial, "m.facebook.com", 0)
    End Sub

    Private Sub pnlTwitter_Click(sender As Object, e As EventArgs) Handles pnlTwitter.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocial, "mobile.twitter.com", 0)
    End Sub

    Private Sub pnlInstagram_Click(sender As Object, e As EventArgs) Handles pnlInstagram.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocial, "www.instagram.com/accounts/login/", 0)
    End Sub

    Private Sub pnlLinkedIn_Click(sender As Object, e As EventArgs) Handles pnlLinkedIn.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocial, "www.linkedin.com", 0)
    End Sub

    Private Sub pnlMusic_Click(sender As Object, e As EventArgs) Handles pnlMusic.Click
        If AxWindowsMediaPlayer1.currentPlaylist.count > 0 Then
            SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 0, RightBarCounter)
        Else
            SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 5, RightBarCounter)
        End If

    End Sub

    Private Sub pbAlbumArt_MouseEnter(sender As Object, e As EventArgs) Handles pbAlbumArt.MouseEnter
        Try
            AxWindowsMediaPlayer1.Visible = True
            btnMenu.Visible = True
            btnAddSongz.Visible = True
            pnlAlbumTitle.Visible = True
        Catch ex As Exception : End Try
    End Sub

    Private Sub pbAlbumArt_MouseLeave(sender As Object, e As EventArgs) Handles pbAlbumArt.MouseLeave
        tmrMusicHider.Start()
    End Sub

    Private Sub tmrMusicHider_Tick(sender As Object, e As EventArgs) Handles tmrMusicHider.Tick
        Music.MusicPlayerHider(tmrMusicHider, AxWindowsMediaPlayer1, btnMenu, btnAddSongz, pnlAlbumTitle, TimerMusicCounter)
    End Sub

    Private Sub AxWindowsMediaPlayer1_MediaChange_1(sender As Object, e As AxWMPLib._WMPOCXEvents_MediaChangeEvent) Handles AxWindowsMediaPlayer1.MediaChange

        If System.IO.Path.GetExtension(AxWindowsMediaPlayer1.currentMedia.sourceURL) <> ".wav" Then
            If AlbumName(0).Length > 15 Then
                Music.UpdateAlbumArt(AxWindowsMediaPlayer1, pbAlbumArt, lvPlaylist, lblSongName, AlbumName(0).Substring(0, 15) & "...")
            Else
                Music.UpdateAlbumArt(AxWindowsMediaPlayer1, pbAlbumArt, lvPlaylist, lblSongName, AlbumName(0))
            End If
        Else
            lblSongName.Text = AxWindowsMediaPlayer1.currentMedia.name
        End If
    End Sub

    Private Sub pnlCalendar_Click(sender As Object, e As EventArgs) Handles pnlCalendar.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 1, RightBarCounter)
        Calendar.SetCalendar(lblCalendarDay, lblCalendarDate, lblCalendarMonth, RightSideAppBar)
    End Sub

    Private Sub pnlCalculator_Click(sender As Object, e As EventArgs) Handles pnlCalculator.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 2, RightBarCounter)
    End Sub

    Private Sub lvPlaylist_DoubleClick(sender As Object, e As EventArgs) Handles lvPlaylist.DoubleClick
        'If SongIndex(0).Length > 28 Then
        '    Music.SelectSong(SongIndex(0).Substring(1, SongIndex(0).Length - 4), AxWindowsMediaPlayer1)
        'Else
        '    Music.SelectSong(SongIndex(0), AxWindowsMediaPlayer1)
        'End If

        Music.SelectSong(SongIndex, AxWindowsMediaPlayer1)

    End Sub

    Public SongIndex As Integer
    Private Sub lvPlaylist_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvPlaylist.ItemSelectionChanged
        SongIndex = e.Item.Index + 1
    End Sub

    Private Sub pnlWeather_Click(sender As Object, e As EventArgs) Handles pnlWeather.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 3, RightBarCounter)
        Weather.SetWeather(wbWeather)
    End Sub

#Region "CalculatorApp"

    Private Sub Cal0_Click(sender As Object, e As EventArgs) Handles Cal0.Click
        Calculator1.BtnDigit0.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal1_Click_1(sender As Object, e As EventArgs) Handles Cal1.Click
        Calculator1.BtnDigit1.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal2_Click(sender As Object, e As EventArgs) Handles Cal2.Click
        Calculator1.BtnDigit2.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal3_Click(sender As Object, e As EventArgs) Handles Cal3.Click
        Calculator1.BtnDigit3.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal4_Click(sender As Object, e As EventArgs) Handles Cal4.Click
        Calculator1.BtnDigit4.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal5_Click(sender As Object, e As EventArgs) Handles Cal5.Click
        Calculator1.BtnDigit5.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal6_Click(sender As Object, e As EventArgs) Handles Cal6.Click
        Calculator1.BtnDigit6.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal7_Click(sender As Object, e As EventArgs) Handles Cal7.Click
        Calculator1.BtnDigit7.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal8_Click(sender As Object, e As EventArgs) Handles Cal8.Click
        Calculator1.BtnDigit8.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub Cal9_Click(sender As Object, e As EventArgs) Handles Cal9.Click
        Calculator1.BtnDigit9.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalComma_Click(sender As Object, e As EventArgs) Handles CalComma.Click
        Calculator1.BtnDecimal.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalEquals_Click(sender As Object, e As EventArgs) Handles CalEquals.Click
        Calculator1.BtnEquals.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalPlus_Click(sender As Object, e As EventArgs) Handles CalPlus.Click
        Calculator1.BtnAdd.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalMinus_Click(sender As Object, e As EventArgs) Handles CalMinus.Click
        Calculator1.BtnSubtract.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalTimes_Click(sender As Object, e As EventArgs) Handles CalTimes.Click
        Calculator1.BtnMultiply.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalDivide_Click(sender As Object, e As EventArgs) Handles CalDivide.Click
        Calculator1.BtnDivide.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalPercentage_Click(sender As Object, e As EventArgs) Handles CalPercentage.Click
        Calculator1.BtnPercent.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalErase_Click(sender As Object, e As EventArgs) Handles CalErase.Click
        Calculator1.BtnBack.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub CalAC_Click(sender As Object, e As EventArgs) Handles CalAC.Click
        Calculator1.BtnClear.PerformClick()
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bbSmartDock.SelectedTab = BubbleBarTab2
    End Sub


    Private Sub BubbleButton13_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnReturn.Click
        bbSmartDock.SelectedTab = BubbleBarTab1
    End Sub

    Private Sub BubbleButton11_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnPhoto.Click
        Dim BrowsePic As New OpenFileDialog()
        BrowsePic.Multiselect = True
        BrowsePic.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|GIF (*.gif)|*.gif*"

        If BrowsePic.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            AxEDOffice1.WordInsertPicture(BrowsePic.FileName, True)
        End If
    End Sub


    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        'AxEDOffice1.ExitOfficeApp()
        AxEDOffice1.CloseDoc()

        Application.ExitThread()
        Application.ExitThread()
        Application.Exit()
    End Sub

    Private Sub Calculator1_ValueChanged(sender As Object, e As DevComponents.Editors.ValueChangedEventArgs) Handles Calculator1.ValueChanged
        txtCalDisplay.Text = Calculator1.DisplayValue
    End Sub

    Private Sub RightSideAppBar_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles RightSideAppBar.SelectedTabChanged

    End Sub

    Private Sub pnlRecord_Click(sender As Object, e As EventArgs) Handles pnlRecord.Click
        AudioJournal.RecordAudio(tmrRecorder, pnlRecord, pnlGraph, lblSec, lblMin, lblHrs)
    End Sub

    Private Sub pnlStop_Click(sender As Object, e As EventArgs) Handles pnlStop.Click
        AudioJournal.StopRecording(tmrRecorder, pnlRecord, pnlGraph)
        pnlGraph.Enabled = True
    End Sub

    Private Sub pnlGraph_Click(sender As Object, e As EventArgs) Handles pnlGraph.Click
        AudioJournal.PreviewAudio()
    End Sub

    Private Sub pnlGraph_DoubleClick(sender As Object, e As EventArgs) Handles pnlGraph.DoubleClick
        AudioJournal.SaveAudio(lvJournalLibrary, lvAudio, pnlGraph, lblSec, lblMin, lblHrs)
    End Sub

    Private Sub tmrRecorder_Tick(sender As Object, e As EventArgs) Handles tmrRecorder.Tick
        AudioJournal.RecordTime(lblSec, lblMin, lblHrs)
    End Sub

    Private Sub bbAudioJournal_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles bbAudioJournal.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 4, RightBarCounter)
    End Sub

    Private Sub lvMusicMenu_DoubleClick(sender As Object, e As EventArgs) Handles lvMusicMenu.DoubleClick, AddSongsToolStripMenuItem.Click
        If AlbumName(0) = "Add New Album" Then
            Music.AddAlbum(lvMusicMenu, AxWindowsMediaPlayer2, ImageList2, JournalDrive.MusicPath)
        Else
            lblMusicAlbum.Text = "Loading..."
            Music.LoadPlaylist(AxWindowsMediaPlayer1, lvPlaylist, ImageList1, pbAlbumArt, AlbumName(0))
            Music.OpenMusic(lvPlaylist, RightSideAppBar, pbAlbumArt, pbStatusBar, RightSideAppBar)
            SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 0, RightBarCounter)
            lblNowPlaying.Show()
            lblMusicAlbum.Text = "Albums"
        End If
    End Sub

    Public Sub InitializeCounters()
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        'MsgBox(JournalDrive.JournalsPath)
        Dim JCounter As Integer = JournalDrive.JournalLibraryItemCounter(LogIn.txtUsername.Text, JournalDrive.JournalsPath, ".docx")
        Dim BCounter As Integer = JournalDrive.JournalLibraryItemCounter(LogIn.txtUsername.Text, JournalDrive.BooksPath, ".pdf")
        Dim ACounter As Integer = JournalDrive.JournalLibraryItemCounter(LogIn.txtUsername.Text, JournalDrive.AudioPath, ".wav")
        Dim PCounter As Integer = JournalDrive.JournalLibraryItemCounter(LogIn.txtUsername.Text, JournalDrive.PhotosPath, ".jpg")

        lvJournalLibrary.Refresh()
        System.Threading.Thread.Sleep(1)

        If JCounter <> 1 Then
            lvJournalLibrary.Items.Item(0).Text = "Journals" & vbCrLf & JCounter & " items"
        Else
            lvJournalLibrary.Items.Item(0).Text = "Journals" & vbCrLf & JCounter & " item"
        End If

        If BCounter <> 1 Then
            lvJournalLibrary.Items.Item(1).Text = "Books" & vbCrLf & BCounter & " items"
        Else
            lvJournalLibrary.Items.Item(1).Text = "Books" & vbCrLf & BCounter & " item"
        End If

        If ACounter <> 1 Then
            lvJournalLibrary.Items.Item(2).Text = "Audio" & vbCrLf & ACounter & " items"
        Else
            lvJournalLibrary.Items.Item(2).Text = "Audio" & vbCrLf & ACounter & " item"
        End If

        If PCounter <> 1 Then
            lvJournalLibrary.Items.Item(3).Text = "Photos" & vbCrLf & PCounter & " items"
        Else
            lvJournalLibrary.Items.Item(3).Text = "Photos" & vbCrLf & PCounter & " item"
        End If

    End Sub


    Private Sub BubbleButton1_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnJournalLibrary.Click
        InitializeCounters()
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 1)
    End Sub

    Private AlbumName() As String
    Private Sub lvMusicMenu_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvMusicMenu.ItemSelectionChanged
        AlbumName = e.Item.Text.Split(vbCrLf)
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 5, RightBarCounter)
    End Sub

    Public Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        MoveOn = 0
        If AxEDOffice1.IsDirty = True And AxEDOffice1.GetDocumentName = "T4.dotm" Then
            JournalDrive.SaveChanges(AxEDOffice1, MoveOn)

            If MoveOn = 0 Then
                BeforeSave = 3
            Else
                PictureBox3.Show()
                PictureBox3.Height = MainTab.Height
                PictureBox3.Width = MainTab.Width

                Application.Restart()

                PictureBox3.Hide()
            End If

        Else
            AxEDOffice1.Save()

            PictureBox3.Show()
            PictureBox3.Height = MainTab.Height
            PictureBox3.Width = MainTab.Width

            Application.Restart()

            PictureBox3.Hide()
        End If
    End Sub

    Private Sub lvJournalLibrary_DoubleClick(sender As Object, e As EventArgs) Handles lvJournalLibrary.DoubleClick
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)

        If JournalLibraryItem.Contains("Journals") Then

            'JournalDrive.JournalLibraryItem(lvJournals, ".docx", JournalDrive.JournalsPath)
            'SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedia, "NULL", 2)
            JournalDrive.ViewJournalFolders(lvMyJournals, JournalDrive.JournalsPath, ".docx")
            SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 5)


        ElseIf JournalLibraryItem.Contains("Books") Then

            JournalDrive.JournalLibraryItem(lvBooks, ".pdf", JournalDrive.BooksPath & "\" & lblBooks.Text)
            Reads.PreviewBookCover(lvBooks, ImageListBooks, lblBooks.Text)
            SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 3)

        ElseIf JournalLibraryItem.Contains("Audio") Then

            JournalDrive.JournalLibraryItem(lvAudio, ".wav", JournalDrive.AudioPath)
            SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 4)

        ElseIf JournalLibraryItem.Contains("Photos") Then

            JournalDrive.JournalLibraryItem(lvPhotos, ".jpg", JournalDrive.PhotosPath)
            Photos.InitializeAlbums(lvPhotos, ".jpg", ImageListPhotos)
            SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 6)
        End If
    End Sub

    Dim JournalLibraryItem As String
    Private Sub lvJournalLibrary_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvJournalLibrary.ItemSelectionChanged
        JournalLibraryItem = e.Item.Text
    End Sub

    Dim JournalName As String
    Private Sub lvJournals_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvJournals.ItemSelectionChanged
        JournalName = e.Item.Text
    End Sub

    Public BeforeSave As Integer '1: Before Open; 2: Before New; 3: Before Close;
    Public MoveOn As Integer = 0

    Private Sub LabelX1_Click(sender As Object, e As EventArgs) Handles LabelX1.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 5)
    End Sub

    Dim BookName As String
    Private Sub lvBooks_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvBooks.ItemSelectionChanged
        BookName = e.Item.Text
    End Sub

    Private Sub lvBooks_DoubleClick(sender As Object, e As EventArgs) Handles lvBooks.DoubleClick
        AxAcroPDF1.LoadFile(JournalDrive.BooksPath & "\" & BookFolderName & "\" & BookName & ".pdf")
        PictureBox2.Show()
        PictureBox3.Height = MainTab.Height
        PictureBox3.Width = MainTab.Width

        MainTab.SelectedTabIndex = 1

        PictureBox2.Hide()
    End Sub

    Private Sub LabelX5_Click(sender As Object, e As EventArgs) Handles LabelX5.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 1)
    End Sub

    Private Sub LabelX6_Click(sender As Object, e As EventArgs) Handles LabelX6.Click
        Reads.UploadBook(lvBooks, ".pdf", JournalDrive.BooksPath & "\" & lblBooks.Text, ImageListBooks, lblBooks.Text)

        Dim BCounter As Integer = JournalDrive.JournalLibraryItemCounter(LogIn.txtUsername.Text, JournalDrive.BooksPath, ".pdf")
        lvJournalLibrary.Items.Item(1).Text = "Books" & vbCrLf & BCounter & " items"
    End Sub

    Dim AudioName As String
    Private Sub lvAudio_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvAudio.ItemSelectionChanged
        AudioName = e.Item.Text
    End Sub

    Private Sub lvAudio_DoubleClick(sender As Object, e As EventArgs) Handles lvAudio.DoubleClick
        AudioJournal.LoadAudio(AxWindowsMediaPlayer1, JournalDrive.AudioPath, lvPlaylist, ImageList1, pbAlbumArt, AudioName)
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 0, RightBarCounter)
    End Sub

    Private Sub LabelX8_Click(sender As Object, e As EventArgs) Handles LabelX8.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 1)
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.RenameFile(BookName, lvBooks, ".pdf", JournalDrive.BooksPath & "\" & BookFolderName)
        Reads.PreviewBookCover(lvBooks, ImageListBooks, lblBooks.Text)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.DeleteFile(BookName, lvBooks, ".pdf", JournalDrive.BooksPath & "\" & BookFolderName)
        Reads.PreviewBookCover(lvBooks, ImageListBooks, lblBooks.Text)
        InitializeCounters()

    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.RenameFile(JournalName, lvJournals, ".docx", JournalDrive.JournalsPath & "\" & MyJournalFolderName(0))
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.DeleteFile(JournalName, lvJournals, ".docx", JournalDrive.JournalsPath & "\" & MyJournalFolderName(0))
        InitializeCounters()
        JournalDrive.ViewJournalFolders(lvMyJournals, JournalDrive.JournalsPath, ".docx")
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.RenameFile(AudioName, lvAudio, ".wav", JournalDrive.AudioPath)
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.DeleteFile(AudioName, lvAudio, ".wav", JournalDrive.AudioPath)
        InitializeCounters()
    End Sub

    Private Sub lblNowPlaying_Click(sender As Object, e As EventArgs) Handles lblNowPlaying.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 0, RightBarCounter)
    End Sub

    Private Sub DeleteAlbumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAlbumToolStripMenuItem.Click
        JournalDrive.RenameFile(AlbumName(0), lvMusicMenu, ".m3u", JournalDrive.MusicPath)
        Music.LoadAlbums(lvMusicMenu, AxWindowsMediaPlayer2, ImageList2, JournalDrive.MusicPath)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        JournalDrive.DeleteFile(AlbumName(0), lvMusicMenu, ".m3u", JournalDrive.MusicPath)
        Music.LoadAlbums(lvMusicMenu, AxWindowsMediaPlayer2, ImageList2, JournalDrive.MusicPath)
    End Sub

    Private Sub AxEDOffice1_DocumentOpened(sender As Object, e As EventArgs) Handles AxEDOffice1.DocumentOpened
        Try
            AxEDOffice1.WordDisableSaveHotKey(True)
            AxEDOffice1.WordDisablePrintHotKey(True)
            AxEDOffice1.SwitchViewType(6)
        Catch ex As Exception : End Try

    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.Control And e.KeyCode = Keys.S) Then
            MsgBox(" ")
        End If
    End Sub

    Private Sub AxEDOffice1_BeforeDocumentOpened(sender As Object, e As EventArgs) Handles AxEDOffice1.BeforeDocumentOpened
        AxEDOffice1.SwitchViewType(6)
    End Sub

    Private Sub tmrIsDirty_Tick(sender As Object, e As EventArgs) Handles tmrIsDirty.Tick
        If AxEDOffice1.IsDirty = True Then
            bbSmartDock.SelectedTab = BubbleBarTab2

            tmrIsDirty.Stop()
        End If
    End Sub

    Private Sub btnJL_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnJL.Click
        InitializeCounters()
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 1)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnSave.Click
        If AxEDOffice1.IsDirty = True And AxEDOffice1.GetDocumentName = "T4.dotm" Then
            SaveAs.Show()
        ElseIf AxEDOffice1.IsDirty = True And AxEDOffice1.GetDocumentName <> "T4.dotm" Then
            AxEDOffice1.Save()
        End If
    End Sub

    Public Sub NewJournal()
        MoveOn = 0
        If AxEDOffice1.IsDirty = True And AxEDOffice1.GetDocumentName = "T4.dotm" Then

            JournalDrive.SaveChanges(AxEDOffice1, MoveOn)

            If MoveOn = 0 Then
                BeforeSave = 2
            Else
                SaveAs.Close()

                PictureBox3.Show()
                PictureBox3.Height = MainTab.Height
                PictureBox3.Width = MainTab.Width

                AxEDOffice1.OpenWord(JournalDrive.JournalTemplete)

                PictureBox3.Hide()
            End If

        ElseIf AxEDOffice1.IsDirty = True And AxEDOffice1.GetDocumentName <> "T4.dotm" Then
            AxEDOffice1.Save()

            PictureBox3.Show()
            PictureBox3.Height = MainTab.Height
            PictureBox3.Width = MainTab.Width

            AxEDOffice1.OpenWord(JournalDrive.JournalTemplete)

            PictureBox3.Hide()
        Else

            PictureBox3.Show()
            PictureBox3.Height = MainTab.Height
            PictureBox3.Width = MainTab.Width

            AxEDOffice1.OpenWord(JournalDrive.JournalTemplete)

            PictureBox3.Hide()
        End If
    End Sub

    Public Sub lvJournals_DoubleClick(sender As Object, e As EventArgs) Handles lvJournals.DoubleClick
        MoveOn = 0
        If AxEDOffice1.IsDirty = True And AxEDOffice1.GetDocumentName = "T4.dotm" Then
            JournalDrive.SaveChanges(AxEDOffice1, MoveOn)
            If MoveOn = 0 Then
                BeforeSave = 1
            Else
                JournalDrive.InitializeJL(LogIn.txtUsername.Text)

                PictureBox3.Show()
                PictureBox3.Height = MainTab.Height
                PictureBox3.Width = MainTab.Width

                AxEDOffice1.OpenWord(JournalDrive.JournalsPath & "\" & MyJournalFolderName(0) & "\" & JournalName & ".docx")
                MainTab.SelectedTabIndex = 0

                PictureBox3.Hide()
            End If

        Else
            AxEDOffice1.Save()
            JournalDrive.InitializeJL(LogIn.txtUsername.Text)

            PictureBox3.Show()
            PictureBox3.Height = MainTab.Height
            PictureBox3.Width = MainTab.Width

            AxEDOffice1.OpenWord(JournalDrive.JournalsPath & "\" & MyJournalFolderName(0) & "\" & JournalName & ".docx")
            MainTab.SelectedTabIndex = 0

            PictureBox3.Hide()
        End If
    End Sub

    Public Sub btnNewJournal_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnNewJournal.Click
        NewJournal()
    End Sub

    Private Sub btnAddSongz_Click(sender As Object, e As EventArgs) Handles btnAddSongz.Click
        Music.Addsongz(AxWindowsMediaPlayer1, lvPlaylist, ImageList1, pbAlbumArt, AlbumName(0))
    End Sub


    Private Sub BubbleButton2_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnSwitcher.Click
        If MainTab.SelectedTabIndex = 1 Then
            MainTab.SelectedTabIndex = 0
        Else
            MainTab.SelectedTabIndex = 1
        End If
    End Sub

    Private Sub btnTools_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnTools.Click
        bbSmartDock.SelectedTab = BubbleBarTab2
    End Sub

    Private Sub btnWeather_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnWeather.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 3, RightBarCounter)
        Weather.SetWeather(wbWeather)
    End Sub

    Private Sub btnMusic_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnMusic.Click
        If AxWindowsMediaPlayer1.currentPlaylist.count > 0 Then
            SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 0, RightBarCounter)
        Else
            SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 5, RightBarCounter)
        End If
    End Sub

    Private Sub btnCalendar_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnCalendar.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 1, RightBarCounter)
        Calendar.SetCalendar(lblCalendarDay, lblCalendarDate, lblCalendarMonth, RightSideAppBar)
    End Sub


    Private Sub lvMyJournals_DoubleClick(sender As Object, e As EventArgs) Handles lvMyJournals.DoubleClick
        lblFolderTitle.Text = MyJournalFolderName(0)
        JournalDrive.JournalLibraryItem(lvJournals, ".docx", JournalDrive.JournalsPath & "\" & MyJournalFolderName(0))
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 2)
    End Sub

    Public MyJournalFolderName() As String
    Private Sub lvMyJournals_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvMyJournals.ItemSelectionChanged
        MyJournalFolderName = e.Item.Text.Split(vbCrLf)
    End Sub

    Private Sub LabelX12_Click(sender As Object, e As EventArgs) Handles LabelX12.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.AddFolder(lvMyJournals, JournalDrive.JournalsPath, ".docx")
    End Sub

    Private Sub LabelX13_Click(sender As Object, e As EventArgs)
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.ChangeView(lvMyJournals)
    End Sub

    Private Sub LabelX11_Click(sender As Object, e As EventArgs) Handles LabelX11.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 1)
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        JournalDrive.RenameFolder(MyJournalFolderName(0), lvMyJournals, JournalDrive.JournalsPath & "\" & MyJournalFolderName(0), ".docx")
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        JournalDrive.DeleteFolder(MyJournalFolderName(0), lvMyJournals, JournalDrive.JournalsPath & "\" & MyJournalFolderName(0), ".docx")
    End Sub

    Private Sub MoveJournalToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles MoveJournalToolStripMenuItem.MouseHover
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        MoveJournalToolStripMenuItem.DropDownItems.Clear()

        For Each Drive As String In IO.Directory.GetDirectories(JournalDrive.JournalsPath)
            MoveJournalToolStripMenuItem.DropDownItems.Add(System.IO.Path.GetFileName(Drive))
        Next Drive
    End Sub

    Private Sub MoveJournalToolStripMenuItem_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MoveJournalToolStripMenuItem.DropDownItemClicked
        JournalDrive.MoveFile(JournalName, lvJournals, ".docx", JournalDrive.JournalsPath & "\" & MyJournalFolderName(0), JournalDrive.JournalsPath & "\" & e.ClickedItem.Text)
        JournalDrive.JournalLibraryItem(lvJournals, ".docx", JournalDrive.JournalsPath & "\" & MyJournalFolderName(0))
        JournalDrive.ViewJournalFolders(lvMyJournals, JournalDrive.JournalsPath, ".docx")
    End Sub

    Private Sub LabelX2_Click(sender As Object, e As EventArgs) Handles LabelX2.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 1)
    End Sub

    Dim PhotoAlbumName() As String
    Private Sub lvPhotos_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvPhotos.ItemSelectionChanged
        PhotoAlbumName = e.Item.Text.Split(vbCrLf)
    End Sub

    Private Sub BWPhotos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWPhotos.DoWork
        Photos.PopulatePhotos(lvmyphotos, ImageListArrayPhotos, PhotoAlbumName(0))
    End Sub

    Private Sub BWNewPhotoAlbum_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWNewPhotoAlbum.DoWork
        Photos.AddPhotosBW(lblPhotoAlbums)
    End Sub

    Private Sub BWNewPhotoAlbum_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWNewPhotoAlbum.RunWorkerCompleted
        lblPhotoAlbums.Text = "Photo Albums"
        Photos.InitializeAlbums(lvPhotos, ".jpg", ImageListPhotos)
        InitializeCounters()
    End Sub

    Private Sub BWUploadPhoto_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWUploadPhoto.DoWork
        Photos.BWUploadPhotos(PhotoAlbumName(0), lblPhotosTitle)
    End Sub

    Private Sub BWUploadPhoto_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWUploadPhoto.RunWorkerCompleted
        lblPhotosTitle.Text = PhotoAlbumName(0)
        Photos.InitializeAlbums(lvPhotos, ".jpg", ImageListPhotos)
        Photos.PopulatePhotos(lvmyphotos, ImageListArrayPhotos, PhotoAlbumName(0))
        InitializeCounters()
    End Sub

    Private Sub lvPhotos_DoubleClick(sender As Object, e As EventArgs) Handles lvPhotos.DoubleClick
        If PhotoAlbumName(0) = "Add New Album" Then
            Photos.AddPhotos()
            BWNewPhotoAlbum.RunWorkerAsync()
        Else

            lblPhotosTitle.Text = PhotoAlbumName(0)
            lvmyphotos.Height = LeftSideAppBar.Height - pbStatusBar.Height - Panel2.Height
            ImageListArrayPhotos.Images.Clear()
            SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 7)
            BWPhotos.RunWorkerAsync()


        End If
    End Sub

    Private Sub LabelX17_Click(sender As Object, e As EventArgs) Handles LabelX17.Click
        SideBars.LeftSideBarApps(pnlLeftSideBar, tmrLeftBarPop, LeftSideAppBar, wbSocialMedi, "NULL", 6)
    End Sub

    Private Sub lblUploadPhotos_Click(sender As Object, e As EventArgs) Handles lblUploadPhotos.Click
        Photos.InitializeAlbums(lvPhotos, ".jpg", ImageListPhotos)
        Photos.PopulatePhotos(lvmyphotos, ImageListArrayPhotos, PhotoAlbumName(0))
        InitializeCounters()
        Photos.UploadPhotos(PhotoAlbumName(0))
        BWUploadPhoto.RunWorkerAsync()
    End Sub

    Private Sub lvmyphotos_DoubleClick(sender As Object, e As EventArgs) Handles lvmyphotos.DoubleClick
        Photos.PhotoReview(pnlPhotoViewer, pbPhotoViewer, PhotoUrl)
    End Sub

    Dim PhotoUrl As String
    Private Sub lvmyphotos_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvmyphotos.ItemSelectionChanged
        PhotoUrl = e.Item.Name
    End Sub

    Private Sub pnlPhotoViewer_DoubleClick(sender As Object, e As EventArgs) Handles pnlPhotoViewer.DoubleClick
        pnlPhotoViewer.Hide()
        pnlPhotoViewer.SendToBack()
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        If PhotoAlbumName(0) <> "Add New Album" Then
            ImageListPhotos.Images.Clear()
            JournalDrive.RenameFolder(PhotoAlbumName(0), lvPhotos, JournalDrive.PhotosPath, ".jpg")
            Photos.InitializeAlbums(lvPhotos, ".jpg", ImageListPhotos)
        End If
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        If PhotoAlbumName(0) <> "Add New Album" Then
            ImageListPhotos.Images.Clear()
            JournalDrive.DeleteFolder(PhotoAlbumName(0), lvPhotos, ".jpg", JournalDrive.PhotosPath)
            Photos.InitializeAlbums(lvPhotos, ".jpg", ImageListPhotos)
        End If
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        lvPhotos_DoubleClick(sender, e)
    End Sub

    Private Sub RenameToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem1.Click
        Photos.KillPhoto(PhotoUrl, ImageListArrayPhotos)
        Photos.PopulatePhotos(lvmyphotos, ImageListArrayPhotos, PhotoAlbumName(0))
        Photos.InitializeAlbums(lvPhotos, ".jpg", ImageListPhotos)
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        lvMyJournals_DoubleClick(sender, e)
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.RenameFolder(MyJournalFolderName(0), lvMyJournals, JournalDrive.JournalsPath, ".docx")
        JournalDrive.ViewJournalFolders(lvJournals, JournalDrive.JournalsPath, ".docx")
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        JournalDrive.DeleteFolder(MyJournalFolderName(0), lvMyJournals, ".docx", JournalDrive.JournalsPath)
        JournalDrive.ViewJournalFolders(lvMyJournals, JournalDrive.JournalsPath, ".docx")
        InitializeCounters()
    End Sub

    Private Sub btnChat_Click(sender As Object, e As DevComponents.DotNetBar.ClickEventArgs) Handles btnChat.Click
        SideBars.RightSideBarApps(tmrRightBarHide, tmrRightBarPop, pnlRightSideBar, RightSideAppBar, 3, RightBarCounter)
        wbWeather.Source = New Uri("https://web.whatsapp.com/")
    End Sub

    Dim BookFolderName As String = "My Books"
    Private Sub ListView1_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lbBookFolders.ItemSelectionChanged
        BookFolderName = e.Item.Text
    End Sub

    Private Sub lblBooks_DoubleClick(sender As Object, e As EventArgs) Handles lblBooks.DoubleClick
        Reads.LoadBookFolders(lbBookFolders)
        ButtonX1.Visible = True
        ButtonX1.BringToFront()
    End Sub

    Private Sub lbBookFolders_DoubleClick(sender As Object, e As EventArgs) Handles lbBookFolders.DoubleClick
        Reads.SelectFolder(BookFolderName, lbBookFolders, lblBooks, lvBooks, ImageListBooks)
    End Sub

    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
        Reads.SelectFolder(BookFolderName, lbBookFolders, lblBooks, lvBooks, ImageListBooks)
    End Sub

    Private Sub RenameToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem2.Click
        If BookFolderName = "My Books" Then
            MsgBox("My Books is a default folder. Therefore it cannot be renamed.", MsgBoxStyle.Information)
        Else
            JournalDrive.RenameFolder(BookFolderName, lbBookFolders, JournalDrive.BooksPath, ".pdf")
            Reads.LoadBookFolders(lbBookFolders)
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem2.Click
        If BookFolderName = "My Books" Then
            MsgBox("My Books is a default folder. Therefore it cannot be deleted.", MsgBoxStyle.Information)
        Else
            JournalDrive.DeleteFolder(BookFolderName, lbBookFolders, ".pdf", JournalDrive.BooksPath)
            Reads.LoadBookFolders(lbBookFolders)
        End If
        
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        lbBookFolders.Hide()
        ButtonX1.Hide()
    End Sub

    Private Sub lblBooks_Click(sender As Object, e As EventArgs) Handles lblBooks.Click

    End Sub

    Private Sub MoveBookToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles MoveBookToolStripMenuItem.MouseHover
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)
        MoveBookToolStripMenuItem.DropDownItems.Clear()

        For Each Drive As String In IO.Directory.GetDirectories(JournalDrive.BooksPath)
            MoveBookToolStripMenuItem.DropDownItems.Add(System.IO.Path.GetFileName(Drive))
        Next Drive
    End Sub

    Private Sub MoveBookToolStripMenuItem_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MoveBookToolStripMenuItem.DropDownItemClicked
        JournalDrive.MoveFile(BookName, lvBooks, ".pdf", JournalDrive.BooksPath & "\" & lblBooks.Text, JournalDrive.BooksPath & "\" & e.ClickedItem.Text)

        JournalDrive.JournalLibraryItem(lvBooks, ".pdf", JournalDrive.BooksPath & "\" & lblBooks.Text)
        Reads.PreviewBookCover(lvBooks, ImageListBooks, lblBooks.Text)
    End Sub
End Class
