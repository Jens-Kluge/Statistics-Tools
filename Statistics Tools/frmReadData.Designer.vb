<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReadData
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
        Me.btnReadData = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtpathfile = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSep = New System.Windows.Forms.ComboBox()
        Me.btnSelFile = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbcomma = New System.Windows.Forms.RadioButton()
        Me.rbDot = New System.Windows.Forms.RadioButton()
        Me.chkHeaders = New System.Windows.Forms.CheckBox()
        Me.btnHeaders = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.sfdExport = New System.Windows.Forms.SaveFileDialog()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReadData
        '
        Me.btnReadData.Location = New System.Drawing.Point(666, 234)
        Me.btnReadData.Name = "btnReadData"
        Me.btnReadData.Size = New System.Drawing.Size(127, 40)
        Me.btnReadData.TabIndex = 0
        Me.btnReadData.Text = "Read in data"
        Me.btnReadData.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "Mydata.csv"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 162)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 29
        Me.DataGridView1.Size = New System.Drawing.Size(627, 453)
        Me.DataGridView1.TabIndex = 1
        '
        'txtpathfile
        '
        Me.txtpathfile.Location = New System.Drawing.Point(12, 22)
        Me.txtpathfile.Name = "txtpathfile"
        Me.txtpathfile.Size = New System.Drawing.Size(781, 27)
        Me.txtpathfile.TabIndex = 2
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 635)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(627, 25)
        Me.ProgressBar1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(666, 294)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Column separator"
        '
        'cmbSep
        '
        Me.cmbSep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSep.FormattingEnabled = True
        Me.cmbSep.Items.AddRange(New Object() {",", ";", ":", "|", "Space", "Tab"})
        Me.cmbSep.Location = New System.Drawing.Point(666, 328)
        Me.cmbSep.Name = "cmbSep"
        Me.cmbSep.Size = New System.Drawing.Size(127, 28)
        Me.cmbSep.TabIndex = 5
        '
        'btnSelFile
        '
        Me.btnSelFile.Location = New System.Drawing.Point(666, 66)
        Me.btnSelFile.Name = "btnSelFile"
        Me.btnSelFile.Size = New System.Drawing.Size(127, 36)
        Me.btnSelFile.TabIndex = 6
        Me.btnSelFile.Text = "Select &File"
        Me.btnSelFile.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(627, 63)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "First rows"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbcomma)
        Me.GroupBox1.Controls.Add(Me.rbDot)
        Me.GroupBox1.Location = New System.Drawing.Point(666, 376)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(127, 118)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Decimal Separator"
        '
        'rbcomma
        '
        Me.rbcomma.AutoSize = True
        Me.rbcomma.Location = New System.Drawing.Point(17, 81)
        Me.rbcomma.Name = "rbcomma"
        Me.rbcomma.Size = New System.Drawing.Size(80, 24)
        Me.rbcomma.TabIndex = 1
        Me.rbcomma.TabStop = True
        Me.rbcomma.Text = "comma"
        Me.rbcomma.UseVisualStyleBackColor = True
        '
        'rbDot
        '
        Me.rbDot.AutoSize = True
        Me.rbDot.Location = New System.Drawing.Point(17, 51)
        Me.rbDot.Name = "rbDot"
        Me.rbDot.Size = New System.Drawing.Size(53, 24)
        Me.rbDot.TabIndex = 0
        Me.rbDot.TabStop = True
        Me.rbDot.Text = "dot"
        Me.rbDot.UseVisualStyleBackColor = True
        '
        'chkHeaders
        '
        Me.chkHeaders.Location = New System.Drawing.Point(666, 120)
        Me.chkHeaders.Name = "chkHeaders"
        Me.chkHeaders.Size = New System.Drawing.Size(106, 55)
        Me.chkHeaders.TabIndex = 10
        Me.chkHeaders.Text = "headers in first row"
        Me.chkHeaders.UseVisualStyleBackColor = True
        '
        'btnHeaders
        '
        Me.btnHeaders.Location = New System.Drawing.Point(666, 181)
        Me.btnHeaders.Name = "btnHeaders"
        Me.btnHeaders.Size = New System.Drawing.Size(127, 38)
        Me.btnHeaders.TabIndex = 11
        Me.btnHeaders.Text = "Read in headers"
        Me.btnHeaders.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(666, 559)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(127, 40)
        Me.btnExcel.TabIndex = 12
        Me.btnExcel.Text = "Export to Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(666, 620)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 40)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmReadData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 688)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnHeaders)
        Me.Controls.Add(Me.chkHeaders)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSelFile)
        Me.Controls.Add(Me.cmbSep)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtpathfile)
        Me.Controls.Add(Me.btnReadData)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmReadData"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnReadData As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtpathfile As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSep As ComboBox
    Friend WithEvents btnSelFile As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbcomma As RadioButton
    Friend WithEvents rbDot As RadioButton
    Friend WithEvents chkHeaders As CheckBox
    Friend WithEvents btnHeaders As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents sfdExport As SaveFileDialog
    Friend WithEvents btnClose As Button
End Class
