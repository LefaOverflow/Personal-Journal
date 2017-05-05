Public Class NewAccount

    Private JournalDrive As New JDrive
    Private NewAccount As New CreateNewAccount

    Private Sub NewAccount_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LogIn.Show()
        Me.Hide()
    End Sub

    Private Sub lblUsername_Click(sender As Object, e As EventArgs) Handles lblUsername.Click
        txtUsername.Focus()
    End Sub

    Private Sub lblPassword_Click(sender As Object, e As EventArgs) Handles lblPassword.Click
        txtPassword.Focus()
    End Sub

    Private Sub lblRetypePass_Click(sender As Object, e As EventArgs) Handles lblRetypePass.Click
        txtRetypepass.Focus()
    End Sub

    Private Sub lblEmail_Click(sender As Object, e As EventArgs) Handles lblEmail.Click
        txtEmail.Focus()
    End Sub

    Private Sub lblSecurityCode_Click(sender As Object, e As EventArgs) Handles lblSecurityCode.Click
        txtSecurityCode.Focus()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

        lblPassword.Text = txtPassword.Text
        tmrPassword.Start()
    End Sub

    Private Sub tmrPassword_Tick(sender As Object, e As EventArgs) Handles tmrPassword.Tick
        For k As Integer = 0 To txtPassword.Text.Length - 1
            lblPassword.Text = lblPassword.Text.Replace(txtPassword.Text.Substring(k, 1), "l")
        Next
        tmrPassword.Stop()
    End Sub

    Private Sub txtRetypepass_TextChanged(sender As Object, e As EventArgs) Handles txtRetypepass.TextChanged
        lblRetypePass.Text = txtRetypepass.Text
        tmrPasswordRetype.Start()
    End Sub

    Private Sub tmrPasswordRetype_Tick(sender As Object, e As EventArgs) Handles tmrPasswordRetype.Tick
        For k As Integer = 0 To txtRetypepass.Text.Length - 1
            lblRetypePass.Text = lblRetypePass.Text.Replace(txtRetypepass.Text.Substring(k, 1), "l")
        Next
        tmrPasswordRetype.Stop()
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        lblEmail.Text = txtEmail.Text
    End Sub

    Private Sub txtSecurityCode_TextChanged(sender As Object, e As EventArgs) Handles txtSecurityCode.TextChanged
        lblSecurityCode.Text = txtSecurityCode.Text
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        lblUsername.Text = txtUsername.Text
    End Sub
 
    Private Sub NewAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Flag As New ToolTip

        Flag.SetToolTip(lblUsername, "New Username")
        Flag.SetToolTip(lblPassword, "New Password")
        Flag.SetToolTip(lblRetypePass, "Retype Password")
        Flag.SetToolTip(lblEmail, "New Email Address")
        Flag.SetToolTip(lblSecurityCode, "Retype Security Code")

    End Sub

    Private Sub pnlCreateAccount_Click(sender As Object, e As EventArgs) Handles pnlCreateAccount.Click
        Dim Validate As Integer = NewAccount.Validation(txtUsername.Text, txtPassword.Text, txtRetypepass.Text, txtEmail.Text, lblCode.Text, txtSecurityCode.Text)

        If Validate = 1 Then
            MsgBox("Some fields are empty!", MsgBoxStyle.Exclamation)
        ElseIf Validate = 2 Then
            MsgBox("Username already taken!", MsgBoxStyle.Exclamation)
            txtUsername.Focus()
        ElseIf Validate = 3 Then

            MsgBox("Passwords don't match!", MsgBoxStyle.Exclamation)
            txtPassword.Clear()
            txtRetypepass.Clear()

            lblPassword.Text = " "
            lblRetypePass.Text = " "

            txtPassword.Focus()

        ElseIf Validate = 4 Then
            MsgBox("Incorrect Security Code!", MsgBoxStyle.Exclamation)
            txtSecurityCode.Focus()
        ElseIf Validate = 5 Then
            NewAccount.CreateAccount(txtUsername.Text, txtPassword.Text, txtEmail.Text)
            MsgBox("Successfully Registered.", MsgBoxStyle.Information)
            Application.Restart()
        End If


    End Sub
End Class