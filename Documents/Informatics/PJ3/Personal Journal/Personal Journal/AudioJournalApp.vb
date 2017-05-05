Public Class AudioJournalApp

    Private JournalDrive As New JDrive
    Private Declare Function mscSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstyCommand As String, ByVal lpstryReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallBack As Integer) As Integer
    Private Counter As Integer = 1
    Private CurrentAudio As Boolean = False

    Private Sec As Integer = 0
    Private Min As Integer = 0
    Private Hrs As Integer = 0

    Private DefaultArt As String = JournalDrive.DefaultMusic

    Public Sub RecordAudio(RecordTimer As System.Windows.Forms.Timer, RecordBtn As System.Windows.Forms.Panel, AudioGraph As System.Windows.Forms.Panel _
                           , lblSec As System.Windows.Forms.Label, lblMin As System.Windows.Forms.Label, lblHrs As System.Windows.Forms.Label)
        If CurrentAudio = False Then
            RecordTimer.Start()
            AudioGraph.Visible = True
            AudioGraph.Enabled = False
            RecordBtn.Enabled = False
            CurrentAudio = True

            lblSec.Text = "00"
            lblMin.Text = "00"
            lblHrs.Text = "00"

            Sec = 0
            Min = 0
            Hrs = 0

            mscSendString("open new Type waveaudio Alias recsound", "", 0, 0)
            mscSendString("record recsound", "", 0, 0)
        Else
            If (MsgBox("Are you sure you wanna overwrite previous Audio?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                CurrentAudio = False
                My.Computer.Audio.Stop()
                RecordAudio(RecordTimer, RecordBtn, AudioGraph, lblSec, lblMin, lblHrs) 'Recursion :)
            End If
        End If
    End Sub

    Public Sub StopRecording(RecordTimer As System.Windows.Forms.Timer, RecordBtn As System.Windows.Forms.Panel, AudioGraph As System.Windows.Forms.Panel)
        RecordBtn.Enabled = True
        RecordTimer.Stop()

        mscSendString("save recsound " & JournalDrive.UserDocumentsPath & "\JournalVoice.wav", "", 0, 0)
        mscSendString("close recsound", "", 0, 0)
    End Sub

    Public Sub PreviewAudio()
        Counter += 1
        If Counter Mod 2 = 0 Then
            My.Computer.Audio.Play(JournalDrive.UserDocumentsPath & "\JournalVoice.wav", AudioPlayMode.Background)
        Else
            My.Computer.Audio.Stop()
        End If
    End Sub

    Public Sub SaveAudio(JournalLibraryListView As System.Windows.Forms.ListView, AudioListView As System.Windows.Forms.ListView, AudioGraph As System.Windows.Forms.Panel, lblSec As System.Windows.Forms.Label, lblMin As System.Windows.Forms.Label, lblHrs As System.Windows.Forms.Label)
        JournalDrive.InitializeJL(LogIn.txtUsername.Text)

        Dim RenameAudio As String = InputBox("Save As:")
        My.Computer.FileSystem.RenameFile(JournalDrive.UserDocumentsPath & "JournalVoice.wav", RenameAudio & ".wav")
        My.Computer.FileSystem.MoveFile(JournalDrive.UserDocumentsPath & RenameAudio & ".wav", JournalDrive.AudioPath & "\" & RenameAudio & ".wav")

        Dim ACounter As Integer = JournalDrive.JournalLibraryItemCounter(LogIn.txtUsername.Text, JournalDrive.AudioPath, ".wav")
        JournalLibraryListView.Items.Item(2).Text = "Audio" & vbCrLf & ACounter & " items"
        JournalDrive.JournalLibraryItem(AudioListView, ".wav", JournalDrive.AudioPath)

        MsgBox("Successfully saved.", MsgBoxStyle.Information)

        My.Computer.Audio.Stop()
        AudioGraph.Visible = False
        CurrentAudio = False

        lblSec.Text = "00"
        lblMin.Text = "00"
        lblHrs.Text = "00"

        Sec = 0
        Min = 0
        Hrs = 0
    End Sub

    Public Sub RecordTime(lblSec As System.Windows.Forms.Label, lblMin As System.Windows.Forms.Label, lblHrs As System.Windows.Forms.Label)
        Sec += 1
        'Seconds
        If Sec < 10 Then
            lblSec.Text = "0" & Sec
        Else
            lblSec.Text = Sec
        End If

        If Sec = 60 Then
            lblSec.Text = "00"
            Sec = 0
            Min += 1
        End If

        'Minutes
        If Min < 10 Then
            lblMin.Text = "0" & Min
        Else
            lblMin.Text = Min
        End If

        If Min = 60 Then
            lblMin.Text = "00"
            Min = 0
            Hrs += 1
        End If

        'Hours
        If Hrs < 10 Then
            lblHrs.Text = "0" & Hrs
        Else
            lblHrs.Text = Hrs
        End If
    End Sub

    Public Sub LoadAudio(MusicPlayer As AxWMPLib.AxWindowsMediaPlayer, Location As String, PlayList As System.Windows.Forms.ListView, ImageList As System.Windows.Forms.ImageList, AlbumArt As System.Windows.Forms.PictureBox, AudioName As String)

        MusicPlayer.URL = Location & "\" & AudioName & ".wav" ' To Be Edited!!!

        'Initializing Playlist Mini Album-Arts
        ImageList.Images.Clear()

        'Loading Mini Album-Arts into ImageList
        Dim DefaultAlbumArt As New ID3TagLibrary.MP3File(DefaultArt) ' TO BE Edited

        ImageList.Images.Add(DefaultAlbumArt.Tag2.Artwork(38))

        'Initializing Playlist Content
        PlayList.Items.Clear()

        'Creating Playlist

        If MusicPlayer.currentPlaylist.Item(0).name.Length < 31 Then
            PlayList.Items.Add(MusicPlayer.currentPlaylist.Item(0).name)
        Else
            PlayList.Items.Add(MusicPlayer.currentPlaylist.Item(0).name.Substring(0, 27) & "...")
            PlayList.Items.Item(0).ToolTipText = MusicPlayer.currentPlaylist.Item(0).name
        End If

        PlayList.Items.Item(0).ImageIndex = 0

        'Resizing PlayList
        PlayList.Columns.Item(0).Width = PlayList.Width - 20

        'Resizing AlbumArt
        AlbumArt.SizeMode = PictureBoxSizeMode.StretchImage

        Dim mp3Default As New ID3TagLibrary.MP3File(DefaultArt)
        AlbumArt.Image = mp3Default.Tag2.Artwork(100)
    End Sub

End Class
