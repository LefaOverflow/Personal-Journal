Public Class LogIn

    Private SignIn As New SignIn
    Private JournalDrive As New JDrive

    Private Sub lblUsername_Click(sender As Object, e As EventArgs) Handles lblUsername.Click
        txtUsername.Focus()
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        lblUsername.Text = txtUsername.Text
    End Sub

    Private Sub lblPassword_Click(sender As Object, e As EventArgs) Handles lblPassword.Click
        txtPassword.Focus()
    End Sub

    Private Sub LogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        JournalDrive.SetAllVariables()
        ' JournalDrive.InitializeDirectories(LogIn.txtUsername.Text)
        JournalDrive.InitializeJL(txtUsername.Text)
        SignIn.OpenDB()
        SignIn.LogIn("+", "+", Form1, Me)
    End Sub

    Private Sub tmrPassword_Tick(sender As Object, e As EventArgs) Handles tmrPassword.Tick
        For k As Integer = 0 To txtPassword.Text.Length - 1
            lblPassword.Text = lblPassword.Text.Replace(txtPassword.Text.Substring(k, 1), "l")
        Next
        tmrPassword.Stop()
    End Sub

   
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        lblPassword.Text = txtPassword.Text
        tmrPassword.Start()
    End Sub

    Private Sub pnlCreateAccount_Click(sender As Object, e As EventArgs) Handles pnlCreateAccount.Click
        NewAccount.Show()
        Me.Hide()
    End Sub

    Private Sub pnlLogIn_Click(sender As Object, e As EventArgs) Handles pnlLogIn.Click
        SignIn.LogIn(txtUsername.Text, txtPassword.Text, Form1, Me)
    End Sub

    Private Sub LogIn_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SignIn.LogIn(txtUsername.Text, txtPassword.Text, Form1, Me)
        End If
    End Sub

    Private Sub LogIn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class