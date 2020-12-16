Public Class frmMain
    Private fmPlot As frmHistPlot
    Private fmBoxPlot As frmBoxPlot
    Private fmReaddata As frmReadData


    Private Sub btnReadData_Click(sender As Object, e As EventArgs) Handles btnReadData.Click
        modUtilities.ShowForm(fmReaddata, frmReadData.GetType, True)
        modGlobals.TblData = fmReaddata.TblData
        If fmReaddata.TblData IsNot Nothing Then
            btnShowPv.Enabled = True
            btnBoxPlot.Enabled = True
        End If
    End Sub

    Private Sub btnShowPv_Click(sender As Object, e As EventArgs) Handles btnShowPv.Click
        modUtilities.ShowForm(fmPlot, frmHistPlot.GetType)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        btnReadData.Select()
        'The data needs to be read in before it can be plotted
        btnShowPv.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBoxPlot.Click
        modUtilities.ShowForm(fmBoxPlot, frmBoxPlot.GetType)
    End Sub
End Class
