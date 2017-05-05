<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAccount
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtSecurityCode = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtRetypepass = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSecurityCode = New System.Windows.Forms.Label()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblRetypePass = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.pnlCreateAccount = New System.Windows.Forms.Panel()
        Me.tmrPassword = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPasswordRetype = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSecurityCode
        '
        Me.txtSecurityCode.Location = New System.Drawing.Point(129, 449)
        Me.txtSecurityCode.Name = "txtSecurityCode"
        Me.txtSecurityCode.Size = New System.Drawing.Size(100, 20)
        Me.txtSecurityCode.TabIndex = 12
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(129, 373)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(100, 20)
        Me.txtEmail.TabIndex = 10
        '
        'txtRetypepass
        '
        Me.txtRetypepass.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetypepass.Location = New System.Drawing.Point(122, 281)
        Me.txtRetypepass.Name = "txtRetypepass"
        Me.txtRetypepass.Size = New System.Drawing.Size(123, 33)
        Me.txtRetypepass.TabIndex = 9
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(122, 213)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(192, 33)
        Me.txtPassword.TabIndex = 8
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(145, 38)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Personal_Journal.My.Resources.Resources.sign_uppp
        Me.Panel1.Controls.Add(Me.lblSecurityCode)
        Me.Panel1.Controls.Add(Me.lblCode)
        Me.Panel1.Controls.Add(Me.lblEmail)
        Me.Panel1.Controls.Add(Me.lblRetypePass)
        Me.Panel1.Controls.Add(Me.lblPassword)
        Me.Panel1.Controls.Add(Me.lblUsername)
        Me.Panel1.Controls.Add(Me.pnlCreateAccount)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 551)
        Me.Panel1.TabIndex = 13
        '
        'lblSecurityCode
        '
        Me.lblSecurityCode.BackColor = System.Drawing.Color.Transparent
        Me.lblSecurityCode.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        Me.lblSecurityCode.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblSecurityCode.Location = New System.Drawing.Point(125, 445)
        Me.lblSecurityCode.Name = "lblSecurityCode"
        Me.lblSecurityCode.Size = New System.Drawing.Size(189, 28)
        Me.lblSecurityCode.TabIndex = 9
        Me.lblSecurityCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCode
        '
        Me.lblCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCode.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblCode.Location = New System.Drawing.Point(81, 391)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(233, 32)
        Me.lblCode.TabIndex = 8
        Me.lblCode.Text = "HGKAD"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEmail
        '
        Me.lblEmail.BackColor = System.Drawing.Color.Transparent
        Me.lblEmail.Font = New System.Drawing.Font("Century Gothic", 13.75!)
        Me.lblEmail.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblEmail.Location = New System.Drawing.Point(125, 334)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(189, 26)
        Me.lblEmail.TabIndex = 7
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRetypePass
        '
        Me.lblRetypePass.BackColor = System.Drawing.Color.Transparent
        Me.lblRetypePass.Font = New System.Drawing.Font("Wingdings", 15.75!)
        Me.lblRetypePass.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblRetypePass.Location = New System.Drawing.Point(125, 284)
        Me.lblRetypePass.Name = "lblRetypePass"
        Me.lblRetypePass.Size = New System.Drawing.Size(189, 23)
        Me.lblRetypePass.TabIndex = 6
        Me.lblRetypePass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Wingdings", 15.75!)
        Me.lblPassword.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblPassword.Location = New System.Drawing.Point(125, 224)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(189, 22)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsername
        '
        Me.lblUsername.BackColor = System.Drawing.Color.Transparent
        Me.lblUsername.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblUsername.Location = New System.Drawing.Point(125, 171)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(189, 28)
        Me.lblUsername.TabIndex = 4
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCreateAccount
        '
        Me.pnlCreateAccount.BackColor = System.Drawing.Color.Transparent
        Me.pnlCreateAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlCreateAccount.Location = New System.Drawing.Point(81, 495)
        Me.pnlCreateAccount.Name = "pnlCreateAccount"
        Me.pnlCreateAccount.Size = New System.Drawing.Size(233, 30)
        Me.pnlCreateAccount.TabIndex = 1
        '
        'tmrPassword
        '
        Me.tmrPassword.Interval = 1
        '
        'tmrPasswordRetype
        '
        Me.tmrPasswordRetype.Interval = 1
        '
        'NewAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 551)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSecurityCode)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtRetypepass)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.MaximizeBox = False
        Me.Name = "NewAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSecurityCode As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtRetypepass As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents pnlCreateAccount As System.Windows.Forms.Panel
    Friend WithEvents lblSecurityCode As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblRetypePass As System.Windows.Forms.Label
    Friend WithEvents tmrPassword As System.Windows.Forms.Timer
    Friend WithEvents tmrPasswordRetype As System.Windows.Forms.Timer
End Class
