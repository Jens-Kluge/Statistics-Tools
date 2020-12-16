Imports System.Globalization
Imports OxyPlot

Module modTest

    Public Sub ReadInTestFile()
        Dim testfileDir As String
        Dim testfileName, testFilePath As String
        testfileDir = "C:\Users\jens kluge\Documents\online learning\coursera\wind energy\wind resources\"
        testfileName = "Wind_Lidar_40and140.csv"
        testFilePath = testfileDir & testfileName

        Dim columns() As String = {"Year", "Month", "Day", "Hour", "Wind speed at 40m AGL", "Wind speed at 140m AGL"}
        Dim TextLine As String = ""
        Dim SplitLine() As String
        Dim IsFirstLine As Boolean = True
        Dim linenr As Integer = 0
        Dim dt As DataTable = modGlobals.TblData
        Dim cult As New CultureInfo("en-US")

        If dt Is Nothing Then
            dt = New DataTable
        End If

        dt.TableName = "MyData"
        dt.Rows.Clear()


        Dim objReader As New System.IO.StreamReader(testFilePath)

        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine()
            linenr += 1

            SplitLine = Split(TextLine, " ")
            If IsFirstLine Then
                For i = 1 To SplitLine.Length
                    dt.Columns.Add(New DataColumn(columns(i - 1), GetType(Double)))
                Next
                IsFirstLine = False
            End If
            Dim objFields = From field In SplitLine
                            Select CType(Double.Parse(field, cult), Object)
            Dim newRow = dt.Rows.Add()
            newRow.ItemArray = objFields.ToArray()
        Loop

        modGlobals.TblData = dt

        ''Dim fmplot As New frmHistPlot
        ''frmHistPlot.Show()
        Dim fboxplot As New frmBoxPlot
        fboxplot.Show()

    End Sub
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


    Public Function GenerateBoxPlot() As PlotModel

        Dim boxes As Integer = 16
        Dim plot As New PlotModel

        Dim items As New ObjectModel.Collection(Of Item)()


        For i = 1 To boxes
            items.Add(New Item With {.Label = i.ToString()})
        Next

        plot.Axes.Add(New Axes.LinearAxis With
    {
        .Position = Axes.AxisPosition.Left,
        .MajorStep = 1,
        .MinorStep = 0.25,
        .TickStyle = Axes.TickStyle.Crossing,
        .AbsoluteMaximum = 5.25,
        .AbsoluteMinimum = -0.25
    })

        plot.Axes.Add(New Axes.CategoryAxis With
    {
        .Position = Axes.AxisPosition.Bottom,
        .ItemsSource = items,
        .LabelField = "Label",
        .IsTickCentered = True,
        .TickStyle = TickStyle.None,
        .AbsoluteMinimum = -1,
        .AbsoluteMaximum = 17,
        .IsZoomEnabled = False
    })

        Dim lineAnnotation As New Annotations.LineAnnotation With
    {
        .Type = Annotations.LineAnnotationType.Horizontal,
        .Y = 5,
        .LineStyle = LineStyle.Dash,
        .StrokeThickness = 2,
        .Color = OxyColor.FromArgb(50, 0, 0, 0)
    }

        plot.Annotations.Add(lineAnnotation)

        lineAnnotation = New Annotations.LineAnnotation With
    {
        .Type = Annotations.LineAnnotationType.Horizontal,
        .Y = 1,
        .LineStyle = LineStyle.Dash,
        .StrokeThickness = 1.5,
        .Color = OxyColor.FromArgb(50, 0, 0, 0)
    }
        plot.Annotations.Add(lineAnnotation)

        lineAnnotation = New Annotations.LineAnnotation With
    {
        .Type = Annotations.LineAnnotationType.Horizontal,
        .Y = 4,
        .LineStyle = LineStyle.Solid,
        .StrokeThickness = 1.5,
        .Color = OxyColor.FromArgb(50, 0, 0, 0)
    }
        plot.Annotations.Add(lineAnnotation)

        lineAnnotation = New Annotations.LineAnnotation With
    {
        .Type = Annotations.LineAnnotationType.Horizontal,
        .Y = 2,
        .LineStyle = LineStyle.Solid,
        .StrokeThickness = 1.5,
        .Color = OxyColor.FromArgb(50, 0, 0, 0)
    }

        plot.Annotations.Add(lineAnnotation)

        Dim s1 As New Series.BoxPlotSeries()
        s1.Fill = OxyColor.FromRgb(&H1E, &HB4, &HDA)
        s1.StrokeThickness = 1.1
        s1.WhiskerWidth = 1
        Dim Random As New Random()

        Dim x, points As Integer
        Dim lowerWhisker, upperWhisker As Double

        Try
            For i = 0 To boxes - 1

                x = i
                points = 5 + Random.Next(15)
                Dim values As New List(Of Double)()
                For j = 0 To points - 1
                    values.Add((Random.NextDouble()) * 5)
                Next

                values.Sort()
                Dim median As Double = getMedian(values)
                Dim r As Integer = values.Count Mod 2
                Dim firstQuartil As Double = getMedian(values.Take((values.Count + r) / 2)) '25%-Quartil
                Dim thirdQuartil As Double = getMedian(values.Skip((values.Count - r) / 2))  '75%-Quartil

                Dim iqr As Double = thirdQuartil - firstQuartil 'Quartilabstand
                Dim varstep As Double = 1.5 * iqr
                upperWhisker = thirdQuartil + varstep
                If values.Where(Function(v) v >= v <= upperWhisker).Count > 0 Then
                    upperWhisker = values.Where(Function(v) v >= v <= upperWhisker).Max()
                End If
                lowerWhisker = firstQuartil - varstep
                If values.Where(Function(v) v >= v >= lowerWhisker).Count > 0 Then
                    lowerWhisker = values.Where(Function(v) v >= v >= lowerWhisker).Min()
                End If
                Dim outliers As List(Of Double) = values.Where(Function(v) v >= v > upperWhisker Or v < lowerWhisker).ToList()

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
End Module
