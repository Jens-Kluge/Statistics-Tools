<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistPlot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistPlot))
        Me.btnPlot = New System.Windows.Forms.Button()
        Me.PlotView1 = New OxyPlot.WindowsForms.PlotView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCols = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMin = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.txtBins = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkFilter = New System.Windows.Forms.CheckBox()
        Me.chkWeibull = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnPlot
        '
        Me.btnPlot.Location = New System.Drawing.Point(25, 506)
        Me.btnPlot.Name = "btnPlot"
        Me.btnPlot.Size = New System.Drawing.Size(181, 44)
        Me.btnPlot.TabIndex = 0
        Me.btnPlot.Text = "&Plot"
        Me.btnPlot.UseVisualStyleBackColor = True
        '
        'PlotView1
        '
        Me.PlotView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlotView1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PlotView1.Location = New System.Drawing.Point(273, 48)
        Me.PlotView1.Name = "PlotView1"
        Me.PlotView1.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.PlotView1.Size = New System.Drawing.Size(841, 509)
        Me.PlotView1.TabIndex = 1
        Me.PlotView1.Text = "PlotView1"
        Me.PlotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.PlotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.PlotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select data column"
        '
        'cmbCols
        '
        Me.cmbCols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCols.FormattingEnabled = True
        Me.cmbCols.Location = New System.Drawing.Point(25, 82)
        Me.cmbCols.Name = "cmbCols"
        Me.cmbCols.Size = New System.Drawing.Size(181, 28)
        Me.cmbCols.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 223)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Set bin width"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Min"
        '
        'txtMin
        '
        Me.txtMin.Location = New System.Drawing.Point(87, 260)
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(89, 27)
        Me.txtMin.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 304)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Max"
        '
        'txtMax
        '
        Me.txtMax.Location = New System.Drawing.Point(87, 304)
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(89, 27)
        Me.txtMax.TabIndex = 9
        '
        'txtBins
        '
        Me.txtBins.Location = New System.Drawing.Point(87, 351)
        Me.txtBins.Name = "txtBins"
        Me.txtBins.Size = New System.Drawing.Size(89, 27)
        Me.txtBins.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 351)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Bins"
        '
        'chkFilter
        '
        Me.chkFilter.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFilter.AutoSize = True
        Me.chkFilter.Image = CType(resources.GetObject("chkFilter.Image"), System.Drawing.Image)
        Me.chkFilter.Location = New System.Drawing.Point(25, 136)
        Me.chkFilter.Name = "chkFilter"
        Me.chkFilter.Size = New System.Drawing.Size(54, 54)
        Me.chkFilter.TabIndex = 13
        Me.chkFilter.UseVisualStyleBackColor = True
        '
        'chkWeibull
        '
        Me.chkWeibull.AutoSize = True
        Me.chkWeibull.Location = New System.Drawing.Point(31, 414)
        Me.chkWeibull.Name = "chkWeibull"
        Me.chkWeibull.Size = New System.Drawing.Size(101, 24)
        Me.chkWeibull.TabIndex = 14
        Me.chkWeibull.Text = "Fit Weibull"
        Me.chkWeibull.UseVisualStyleBackColor = True
        '
        'frmPlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 608)
        Me.Controls.Add(Me.chkWeibull)
        Me.Controls.Add(Me.chkFilter)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBins)
        Me.Controls.Add(Me.txtMax)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbCols)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PlotView1)
        Me.Controls.Add(Me.btnPlot)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPlot"
        Me.Text = "Plot histogram"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPlot As Button
    Friend WithEvents PlotView1 As OxyPlot.WindowsForms.PlotView
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCols As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMin As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMax As TextBox
    Friend WithEvents txtBins As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chkFilter As CheckBox
    Friend WithEvents chkWeibull As CheckBox
End Class
