<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoxPlot
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
        Me.PlotView1 = New OxyPlot.WindowsForms.PlotView()
        Me.btnPlot = New System.Windows.Forms.Button()
        Me.cmbDataCols = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCatCols = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PlotView1
        '
        Me.PlotView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlotView1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PlotView1.Location = New System.Drawing.Point(248, 42)
        Me.PlotView1.Name = "PlotView1"
        Me.PlotView1.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.PlotView1.Size = New System.Drawing.Size(539, 386)
        Me.PlotView1.TabIndex = 0
        Me.PlotView1.Text = "PlotView1"
        Me.PlotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.PlotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.PlotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'btnPlot
        '
        Me.btnPlot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPlot.Location = New System.Drawing.Point(33, 388)
        Me.btnPlot.Name = "btnPlot"
        Me.btnPlot.Size = New System.Drawing.Size(181, 40)
        Me.btnPlot.TabIndex = 1
        Me.btnPlot.Text = "&Plot"
        Me.btnPlot.UseVisualStyleBackColor = True
        '
        'cmbDataCols
        '
        Me.cmbDataCols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataCols.FormattingEnabled = True
        Me.cmbDataCols.Location = New System.Drawing.Point(33, 88)
        Me.cmbDataCols.Name = "cmbDataCols"
        Me.cmbDataCols.Size = New System.Drawing.Size(181, 28)
        Me.cmbDataCols.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select data column"
        '
        'cmbCatCols
        '
        Me.cmbCatCols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCatCols.FormattingEnabled = True
        Me.cmbCatCols.Location = New System.Drawing.Point(33, 172)
        Me.cmbCatCols.Name = "cmbCatCols"
        Me.cmbCatCols.Size = New System.Drawing.Size(181, 28)
        Me.cmbCatCols.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Select category column"
        '
        'frmBoxPlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 461)
        Me.Controls.Add(Me.cmbCatCols)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbDataCols)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPlot)
        Me.Controls.Add(Me.PlotView1)
        Me.Name = "frmBoxPlot"
        Me.Text = "frmBoxPlot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PlotView1 As OxyPlot.WindowsForms.PlotView
    Friend WithEvents btnPlot As Button
    Friend WithEvents cmbDataCols As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCatCols As ComboBox
    Friend WithEvents Label2 As Label
End Class
