Public Class InitializePJ

    Public Sub Initialize(WebBrower As Awesomium.Windows.Forms.WebControl, SideAppBar As DevComponents.DotNetBar.SuperTabControl, StatusBar As System.Windows.Forms.PictureBox, TextEditor As AxEDOfficeLib.AxEDOffice, MainTab As DevComponents.DotNetBar.SuperTabControl, Quotes As DevComponents.DotNetBar.LabelX, Form As System.Windows.Forms.Form)
        WebBrower.Height = SideAppBar.Height - StatusBar.Height
        TextEditor.Height = MainTab.Height
        Quotes.Width = Form.Width
        StatusBar.Width = Form.Width

    End Sub

End Class
