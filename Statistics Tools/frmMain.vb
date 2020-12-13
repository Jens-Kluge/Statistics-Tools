Public Class frmMain
    Private fmPlot As frmPlot
    Private fmReaddata As frmReadData


    Private Sub btnReadData_Click(sender As Object, e As EventArgs) Handles btnReadData.Click
        modUtilities.ShowForm(fmReaddata, frmReadData.GetType, True)
        modGlobals.TblData = fmReaddata.TblData
        btnShowPv.Enabled = True
    End Sub

    Private Sub btnShowPv_Click(sender As Object, e As EventArgs) Handles btnShowPv.Click
        modUtilities.ShowForm(fmPlot, frmPlot.GetType)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        btnReadData.Select()
        'The data needs to be read in before it can be plotted
        btnShowPv.Enabled = False

    End Sub
End Class
