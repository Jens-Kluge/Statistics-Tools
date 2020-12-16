Imports MathNet.Numerics.Statistics
Imports OxyPlot

Public Class frmBoxPlot
    Private m_SelDataCol As Integer

    Private Class Item
        Private _label As String

        Public Property Label As String
            Get
                Return _label
            End Get

            Set(ByVal value As String)
                _label = value
            End Set
        End Property
    End Class


    Private Function GenerateBoxPlot() As PlotModel

        Dim dt As DataTable = modGlobals.TblData
        Dim tbl As DataTable
        'will be set to the number of values in the category column
        Dim boxes As Integer = 1
        Dim strOrderBy As String
        Dim plot As New PlotModel

        Dim items As New ObjectModel.Collection(Of Item)()

        If cmbCatCols.SelectedIndex = -1 Then
            boxes = 1
            tbl = dt
            items.Add(New Item With {.Label = "1"})
        Else
            'return unique values, due to first function argument
            tbl = dt.DefaultView.ToTable(True, cmbCatCols.SelectedItem.ToString)
            'now use tbl.select to order the resultset
            strOrderBy = String.Format("[{0}] ASC", cmbCatCols.SelectedItem.ToString)
            Dim result() As DataRow = tbl.Select("", strOrderBy)

            boxes = result.Length
            For i = 0 To boxes - 1
                items.Add(New Item With {.Label = result(i)(0).ToString})
            Next
        End If



        'Add Y-Axis
        plot.Axes.Add(New Axes.LinearAxis With
        {
            .Position = Axes.AxisPosition.Left,
            .MajorStep = 1,
            .MinorStep = 0.25,
            .TickStyle = Axes.TickStyle.Crossing
        })


        plot.Axes.Add(New Axes.CategoryAxis With
        {
            .Position = Axes.AxisPosition.Bottom,
            .ItemsSource = items,
            .LabelField = "Label",
            .IsTickCentered = True,
            .TickStyle = TickStyle.None,
            .IsZoomEnabled = False
            })

        'upper dashed line at mean plus SQRT(VARIANCE)
        Dim strWHERE As String
        strWHERE = String.Format("AVG([{0}])", cmbDataCols.SelectedItem.ToString)
        Dim meanVal As Double = dt.Compute(strWHERE, "")
        Dim varVal As Double = dt.Compute(strWHERE, "")
        Dim lineAnnotation As New Annotations.LineAnnotation With
        {
            .Type = Annotations.LineAnnotationType.Horizontal,
            .Y = meanVal + Math.Sqrt(varVal),
            .LineStyle = LineStyle.Dash,
            .StrokeThickness = 2,
            .Color = OxyColor.FromArgb(50, 0, 0, 0)
        }

        plot.Annotations.Add(lineAnnotation)

        'lower dashed line at mean minus SQRT(VARIANCE) 
        lineAnnotation = New Annotations.LineAnnotation With
        {
            .Type = Annotations.LineAnnotationType.Horizontal,
            .Y = meanVal - Math.Sqrt(varVal),
            .LineStyle = LineStyle.Dash,
            .StrokeThickness = 1.5,
            .Color = OxyColor.FromArgb(50, 0, 0, 0)
        }
        plot.Annotations.Add(lineAnnotation)


        'plot solid line at mean value
        lineAnnotation = New Annotations.LineAnnotation With
        {
            .Type = Annotations.LineAnnotationType.Horizontal,
            .Y = meanVal,
            .LineStyle = LineStyle.Solid,
            .StrokeThickness = 1.5,
            .Color = OxyColor.FromArgb(50, 0, 0, 0)
        }
        plot.Annotations.Add(lineAnnotation)


        Dim s1 As New Series.BoxPlotSeries()
        s1.Fill = OxyColor.FromRgb(&H1E, &HB4, &HDA)
        s1.StrokeThickness = 1.1
        s1.WhiskerWidth = 1

        Dim x As Integer
        Dim lowerWhisker, upperWhisker As Double
        Dim random As New Random()
        Dim resultrows() As DataRow

        Try


            For i = 0 To boxes - 1

                If cmbCatCols.SelectedIndex = -1 Then
                    resultrows = dt.Select("", "")
                Else
                    strWHERE = String.Format("[{0}]={1}", cmbCatCols.SelectedItem.ToString, tbl.Rows(i)(0))
                    resultrows = dt.Select(strWHERE, "")
                End If

                x = i

                Dim values As New List(Of Double)()
                For j = 0 To resultrows.Count - 1
                    values.Add(resultrows(j)(m_SelDataCol))
                Next

                values.Sort()
                Dim median As Double = getMedian(values)
                Dim r As Integer = values.Count Mod 2
                Dim firstQuartil As Double = getMedian(values.Take((values.Count + r) / 2)) '25%-Quartil
                Dim thirdQuartil As Double = getMedian(values.Skip((values.Count - r) / 2))  '75%-Quartil

                Dim iqr As Double = thirdQuartil - firstQuartil 'Quartilabstand
                Dim varstep As Double = 1.5 * iqr
                upperWhisker = thirdQuartil + varstep
                upperWhisker = values.Where(Function(v) v <= upperWhisker).Max()

                lowerWhisker = firstQuartil - varstep
                lowerWhisker = values.Where(Function(v) v >= lowerWhisker).Min()

                Dim outliers As List(Of Double) = values.Where(Function(v) v > upperWhisker Or v < lowerWhisker).ToList()

                s1.Items.Add(New Series.BoxPlotItem(x, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker))
            Next
        Catch ex As Exception
            MsgBox("Error adding a box:" & ex.Message)
        End Try

        plot.Series.Add(s1)

        Return plot
    End Function

    Private Function getMedian(values As IEnumerable(Of Double)) As Double

        Dim sortedInterval As New List(Of Double)(values)

        sortedInterval.Sort()
        Dim count As Integer = sortedInterval.Count

        If count Mod 2 = 1 Then
            Return sortedInterval((count - 1) / 2)
        End If

        Return 0.5 * sortedInterval(count / 2) + 0.5 * sortedInterval((count / 2) - 1)

    End Function

    Private Sub frmBoxPlot_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Fill the combobox
        Try
            For i = 1 To modGlobals.TblData.Columns.Count
                cmbDataCols.Items.Add(modGlobals.TblData.Columns(i - 1).ColumnName)
                cmbCatCols.Items.Add(modGlobals.TblData.Columns(i - 1).ColumnName)
            Next
            cmbDataCols.SelectedIndex = 0
            cmbCatCols.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPlot_Click(sender As Object, e As EventArgs) Handles btnPlot.Click
        PlotView1.Model = GenerateBoxPlot()
    End Sub

    Private Sub cmbDataCols_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataCols.SelectedIndexChanged
        m_SelDataCol = cmbDataCols.SelectedIndex
    End Sub

    Private Sub cmbDataCols_DropDownClosed(sender As Object, e As EventArgs) Handles cmbDataCols.DropDownClosed
        cmbCatCols.SelectedIndex = -1
    End Sub
End Class