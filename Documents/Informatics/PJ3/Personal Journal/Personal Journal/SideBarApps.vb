Public Class SideBarApps

    Private Const LEFT_PANEL As Integer = 1
    Private Const RIGHT_PANEL As Integer = 2
    Private Const SOCIAL_NETWORK_PAGE As Integer = 0

    Private Sub PanelShow(SideBar As System.Windows.Forms.Panel, StatusBar As System.Windows.Forms.PictureBox)
        SideBar.Height = Form1.Height - Form1.bbSmartDock.Height - Form1.MSMain.Height - StatusBar.Height - 40
        SideBar.Visible = True
        SideBar.BringToFront()
        StatusBar.BringToFront()
    End Sub

    Private Sub HideSideBar(SideBar As System.Windows.Forms.Panel, TimerPop As System.Windows.Forms.Timer)
        SideBar.Visible = False
        TimerPop.Start()
    End Sub

    Public Sub PanelShow(SideBar As System.Windows.Forms.Panel, StatusBar As System.Windows.Forms.PictureBox, MousePosition As System.Drawing.Point, Form As System.Windows.Forms.Form, MenuStrip As System.Windows.Forms.MenuStrip, SmartDock As DevComponents.DotNetBar.BubbleBar, MainTab As DevComponents.DotNetBar.SuperTabControl, Timer As System.Windows.Forms.Timer, SideBarType As Integer)
        Dim X As Integer = (MousePosition.X - Form.Bounds.Location.X)
        Dim Y As Integer = (MousePosition.Y - Form.Bounds.Location.Y)


        If SideBarType = LEFT_PANEL Then
            If (X >= 0) And (X <= 15) And (Y >= MenuStrip.Height + SmartDock.Height) And (Y <= MenuStrip.Height + SmartDock.Height + MainTab.Height) Then
                PanelShow(SideBar, StatusBar)
                Timer.Stop()
            End If
        End If

        If SideBarType = RIGHT_PANEL Then
            If (X >= Form.Width - 11) And (X <= Form.Width) And (Y >= MenuStrip.Height + SmartDock.Height) And (Y <= MenuStrip.Height + SmartDock.Height + MainTab.Height) Then
                PanelShow(SideBar, StatusBar)
                Timer.Stop()
            End If
        End If
    End Sub

    Public Sub PanelHider(TimerHider As System.Windows.Forms.Timer, TimerPop As System.Windows.Forms.Timer, SideBar As System.Windows.Forms.Panel, ByRef Counter As Integer)
        Counter += 1

        If Counter = 2 Then
            HideSideBar(SideBar, TimerPop)
            Counter = 0
            TimerHider.Stop()
        End If
    End Sub

    Public Sub AppHider(SideApp As DevComponents.DotNetBar.SuperTabControl, SideBar As System.Windows.Forms.Panel, TimerPop As System.Windows.Forms.Timer)
        SideApp.Visible = False
        HideSideBar(SideBar, TimerPop)
    End Sub

    Public Sub LeftSideBarApps(SideBar As System.Windows.Forms.Panel, TimerPop As System.Windows.Forms.Timer, SideApp As DevComponents.DotNetBar.SuperTabControl, WebBrowser As Awesomium.Windows.Forms.WebControl, URL As String, AppType As Integer)
        HideSideBar(SideBar, TimerPop)

        SideApp.SelectedTabIndex = AppType
        SideApp.Visible = True

        If AppType = 0 Then
            WebBrowser.Source = New Uri("http://" & URL)
        End If
    End Sub

    Public Sub RightSideBarApps(TimerHider As System.Windows.Forms.Timer, TimerPop As System.Windows.Forms.Timer, SideBar As System.Windows.Forms.Panel, SideBarApp As DevComponents.DotNetBar.SuperTabControl, AppType As Integer, ByRef Counter As Integer)
        HideSideBar(SideBar, TimerPop)

        SideBarApp.SelectedTabIndex = AppType
        SideBarApp.Visible = True

    End Sub

    
End Class
