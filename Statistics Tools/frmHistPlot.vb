Imports Microsoft.Office.Interop
Imports MathNet.Numerics.Statistics
Imports OxyPlot

Public Class frmHistPlot
    Private m_XUnits As Integer = 5
    Private m_SelCol As Integer = 0
    Private m_Min As Double = 0
    Private m_Max As Double = 100
    Private m_Bins As Integer
    Private fmFilter As FrmFilter

    Private Sub btnPlot_Click(sender As Object, e As EventArgs) Handles btnPlot.Click

        PlotDataColumnHistogram()

    End Sub

    Private Sub frmPlot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Fill the combobox
        Try
            For i = 1 To modGlobals.TblData.Columns.Count
                cmbCols.Items.Add(modGlobals.TblData.Columns(i - 1).ColumnName)
            Next
            cmbCols.SelectedIndex = 0
            txtBins.Text = "10"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmbCols_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCols.SelectedIndexChanged
        m_SelCol = cmbCols.SelectedIndex
        SetMinMaxValues()
    End Sub

    Private Sub PlotDataColumnHistogram()

        Dim min As Double
        Dim max As Double
        Dim numbuckets As Integer
        Dim binsize As Double
        Dim xval As Double

        min = m_Min
        max = m_Max
        numbuckets = Integer.Parse(txtBins.Text)
        binsize = (max - min) / numbuckets

        Dim lst As List(Of Double) = New List(Of Double)
        'create arraylist from DataTable
        For Each dr As DataRow In modGlobals.TblData.Rows
            lst.Add(dr(m_SelCol))
        Next

        Dim hist As Histogram = New Histogram(lst, numbuckets, min, max)
        Dim buck As Bucket

        Dim xvalues(hist.BucketCount) As Double
        Dim yvalues(hist.BucketCount) As Double

        Try

            'generate data
            For i = 1 To hist.BucketCount
                xval = min + (i - 0.5) * binsize
                buck = hist.GetBucketOf(xval)
                xvalues(i - 1) = xval
                yvalues(i - 1) = buck.Count
            Next


            'Plot the histogram
            'create a series of bars And populate them with data
            Dim seriesA As Series.ColumnSeries = New Series.ColumnSeries With
            {
                .Title = cmbCols.SelectedItem.ToString,
                .StrokeColor = OxyPlot.OxyColors.Black,
                .FillColor = OxyPlot.OxyColors.Red,
                .StrokeThickness = 1,
                .ColumnWidth = 100,
                .LabelPlacement = OxyPlot.Series.LabelPlacement.Outside
            }


            For i = 1 To hist.BucketCount
                seriesA.Items.Add(New Series.ColumnItem(yvalues(i - 1), i - 1))
            Next

            'create a model And add the series to it
            Dim Model As PlotModel = New PlotModel With {
                .Title = cmbCols.SelectedItem.ToString
            }

            'overlay a Weibull distribution
            If (chkWeibull.Checked) Then

                Dim alpha As Double = 3, beta As Double = 2
                modUtilities.EstimateWeibullDistParams(m_SelCol, alpha, beta)
                Dim value As Double

                Dim scalefactor As Double = modGlobals.TblData.Rows.Count * binsize

                'line series overlay
                Dim lsFit As OxyPlot.Series.LineSeries = New OxyPlot.Series.LineSeries() With {
                        .Color = OxyPlot.OxyColors.Green
                }

                For i = 1 To hist.BucketCount
                    value = modPdfs.WeibullPdf(alpha, beta, xvalues(i - 1))
                    value *= scalefactor
                    lsFit.Points.Add(New OxyPlot.DataPoint(i - 1, value))
                Next
                Model.Series.Add(lsFit)

            End If 'Weibull checked

            ''Add labels to the X-Axis
            Dim catLabels(hist.BucketCount) As String


            For i = 1 To hist.BucketCount

                If (i Mod m_XUnits = 0) Then
                    catLabels(i) = String.Format("{0:0.#}", xvalues(i - 1))
                End If

            Next

            Model.Axes.Add(New Axes.CategoryAxis() With {
                    .ItemsSource = catLabels,
                    .Angle = 90
                })


            Model.Series.Add(seriesA)


            PlotView1.Model = Model

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetMinMaxValues()
        Dim strSel As String
        Dim min, max As Double

        Try
            strSel = String.Format("MAX([{0}])", cmbCols.SelectedItem.ToString)
            max = modGlobals.TblData.Compute(strSel, "")
            m_Max = max
            txtMax.Text = max.ToString()
            strSel = String.Format("MIN([{0}])", cmbCols.SelectedItem.ToString)
            min = modGlobals.TblData.Compute(strSel, "")
            m_Min = min
            txtMin.Text = min.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtMin_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMin.Validating
        Try
            m_Min = GetDouble(txtMin.Text)
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub txtMax_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMax.Validating
        Try
            m_Max = GetDouble(txtMax.Text)
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub txtBins_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBins.Validating
        Try
            m_Bins = CInt(txtBins.Text)
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub chkFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkFilter.CheckedChanged
        If chkFilter.Checked Then
            modUtilities.ShowForm(fmFilter, FrmFilter.GetType)
        End If
    End Sub


End Class