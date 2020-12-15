<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DropDownCheckedListBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DropDownCheckedListBox))
        Me.chkListbox = New System.Windows.Forms.CheckedListBox()
        Me.btnDropdown = New System.Windows.Forms.Button()
        Me.txt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'chkListbox
        '
        Me.chkListbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkListbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chkListbox.FormattingEnabled = True
        Me.chkListbox.Location = New System.Drawing.Point(0, 30)
        Me.chkListbox.Name = "chkListbox"
        Me.chkListbox.Size = New System.Drawing.Size(156, 24)
        Me.chkListbox.TabIndex = 0
        '
        'btnDropdown
        '
        Me.btnDropdown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDropdown.Image = CType(resources.GetObject("btnDropdown.Image"), System.Drawing.Image)
        Me.btnDropdown.Location = New System.Drawing.Point(124, 0)
        Me.btnDropdown.Name = "btnDropdown"
        Me.btnDropdown.Size = New System.Drawing.Size(32, 29)
        Me.btnDropdown.TabIndex = 1
        Me.btnDropdown.UseVisualStyleBackColor = True
        '
        'txt
        '
        Me.txt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt.Location = New System.Drawing.Point(0, 0)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(156, 27)
        Me.txt.TabIndex = 2
        '
        'DropDownCheckedListBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnDropdown)
        Me.Controls.Add(Me.chkListbox)
        Me.Controls.Add(Me.txt)
        Me.Name = "DropDownCheckedListBox"
        Me.Size = New System.Drawing.Size(156, 57)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkListbox As CheckedListBox
    Friend WithEvents btnDropdown As Button
    Friend WithEvents txt As TextBox
End Class
