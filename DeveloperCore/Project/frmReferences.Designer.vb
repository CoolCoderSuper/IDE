<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReferences
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
        Me.ReferencesView1 = New CodingCool.DeveloperCore.Views.ReferencesView()
        Me.btOk = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ReferencesView1
        '
        Me.ReferencesView1.Location = New System.Drawing.Point(12, 12)
        Me.ReferencesView1.Name = "ReferencesView1"
        Me.ReferencesView1.Size = New System.Drawing.Size(555, 400)
        Me.ReferencesView1.TabIndex = 0
        '
        'btOk
        '
        Me.btOk.Location = New System.Drawing.Point(390, 418)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(75, 23)
        Me.btOk.TabIndex = 1
        Me.btOk.Text = "Ok"
        Me.btOk.UseVisualStyleBackColor = True
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(481, 418)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 2
        Me.btCancel.Text = "Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'frmReferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 451)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btOk)
        Me.Controls.Add(Me.ReferencesView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReferences"
        Me.Text = "References"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReferencesView1 As Views.ReferencesView
    Friend WithEvents btOk As Button
    Friend WithEvents btCancel As Button
End Class
