<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnShowPv = New System.Windows.Forms.Button()
        Me.btnReadData = New System.Windows.Forms.Button()
        Me.btnBoxPlot = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnShowPv
        '
        Me.btnShowPv.Location = New System.Drawing.Point(30, 92)
        Me.btnShowPv.Name = "btnShowPv"
        Me.btnShowPv.Size = New System.Drawing.Size(153, 40)
        Me.btnShowPv.TabIndex = 0
        Me.btnShowPv.Text = "&Histogram"
        Me.btnShowPv.UseVisualStyleBackColor = True
        '
        'btnReadData
        '
        Me.btnReadData.Location = New System.Drawing.Point(30, 34)
        Me.btnReadData.Name = "btnReadData"
        Me.btnReadData.Size = New System.Drawing.Size(153, 39)
        Me.btnReadData.TabIndex = 1
        Me.btnReadData.Text = "&Read in data"
        Me.btnReadData.UseVisualStyleBackColor = True
        '
        'btnBoxPlot
        '
        Me.btnBoxPlot.Enabled = False
        Me.btnBoxPlot.Location = New System.Drawing.Point(30, 156)
        Me.btnBoxPlot.Name = "btnBoxPlot"
        Me.btnBoxPlot.Size = New System.Drawing.Size(153, 40)
        Me.btnBoxPlot.TabIndex = 2
        Me.btnBoxPlot.Text = "&Boxplot"
        Me.btnBoxPlot.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(204, 237)
        Me.Controls.Add(Me.btnBoxPlot)
        Me.Controls.Add(Me.btnReadData)
        Me.Controls.Add(Me.btnShowPv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnShowPv As Button
    Friend WithEvents btnReadData As Button
    Friend WithEvents btnBoxPlot As Button
End Class
