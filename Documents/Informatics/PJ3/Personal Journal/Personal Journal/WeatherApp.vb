Public Class WeatherApp

    Public Sub SetWeather(WeatherApp As Awesomium.Windows.Forms.WebControl)
        Try
            WeatherApp.Source = New Uri("http://m.accuweather.com/en/za/johannesburg/305448/weather-forecast/305448")
        Catch ex As Exception : End Try

    End Sub
End Class
