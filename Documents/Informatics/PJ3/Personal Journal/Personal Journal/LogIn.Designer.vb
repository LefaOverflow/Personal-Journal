<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogIn
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
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.tmrPassword = New System.Windows.Forms.Timer(Me.components)
        Me.pnlCreateAccount = New System.Windows.Forms.Panel()
        Me.pnlRecover = New System.Windows.Forms.Panel()
        Me.pnlLogIn = New System.Windows.Forms.Panel()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(128, 257)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(186, 33)
        Me.txtPassword.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(47, 364)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 2
        '
        'tmrPassword
        '
        Me.tmrPassword.Interval = 1
        '
        'pnlCreateAccount
        '
        Me.pnlCreateAccount.BackColor = System.Drawing.Color.Transparent
        Me.pnlCreateAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlCreateAccount.Location = New System.Drawing.Point(186, 349)
        Me.pnlCreateAccount.Name = "pnlCreateAccount"
        Me.pnlCreateAccount.Size = New System.Drawing.Size(120, 14)
        Me.pnlCreateAccount.TabIndex = 0
        '
        'pnlRecover
        '
        Me.pnlRecover.BackColor = System.Drawing.Color.Transparent
        Me.pnlRecover.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlRecover.Location = New System.Drawing.Point(217, 368)
        Me.pnlRecover.Name = "pnlRecover"
        Me.pnlRecover.Size = New System.Drawing.Size(89, 16)
        Me.pnlRecover.TabIndex = 1
        '
        'pnlLogIn
        '
        Me.pnlLogIn.BackColor = System.Drawing.Color.Transparent
        Me.pnlLogIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlLogIn.Location = New System.Drawing.Point(81, 304)
        Me.pnlLogIn.Name = "pnlLogIn"
        Me.pnlLogIn.Size = New System.Drawing.Size(233, 30)
        Me.pnlLogIn.TabIndex = 1
        '
        'lblUsername
        '
        Me.lblUsername.BackColor = System.Drawing.Color.Transparent
        Me.lblUsername.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblUsername.Location = New System.Drawing.Point(125, 205)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(189, 23)
        Me.lblUsername.TabIndex = 4
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Wingdings", 15.75!)
        Me.lblPassword.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblPassword.Location = New System.Drawing.Point(125, 257)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(189, 22)
        Me.lblPassword.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Personal_Journal.My.Resources.Resources.login_copy
        Me.Panel1.Controls.Add(Me.lblPassword)
        Me.Panel1.Controls.Add(Me.lblUsername)
        Me.Panel1.Controls.Add(Me.pnlLogIn)
        Me.Panel1.Controls.Add(Me.pnlRecover)
        Me.Panel1.Controls.Add(Me.pnlCreateAccount)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 388)
        Me.Panel1.TabIndex = 0
        '
        'LogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 388)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "LogIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents tmrPassword As System.Windows.Forms.Timer
    Friend WithEvents pnlCreateAccount As System.Windows.Forms.Panel
    Friend WithEvents pnlRecover As System.Windows.Forms.Panel
    Friend WithEvents pnlLogIn As System.Windows.Forms.Panel
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
