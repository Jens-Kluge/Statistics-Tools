Imports System.Globalization

Module modUtilities

    Public Sub EstimateWeibullDistParams(Colno As Integer, ByRef alpha As Double, ByRef beta As Double)

        Dim strAgg As String
        Dim colname As String
        Dim x3_avg As Double = 0
        colname = modGlobals.TblData.Columns(Colno).ColumnName

        'use the power density method to get a simple estimate of alpha and beta
        For Each dr As DataRow In modGlobals.TblData.Rows
            x3_avg += Math.Pow(dr.Field(Of Double)(colname), 3)
        Next

        Dim samplesize As Long = modGlobals.TblData.Rows.Count
        x3_avg = x3_avg / samplesize

        strAgg = String.Format("AVG([{0}])", colname)
        Dim avg As Double = modGlobals.TblData.Compute(strAgg, "")
        Dim avgx3 As Double = Math.Pow(avg, 3)

        Dim epattern As Double = x3_avg / avgx3

        beta = 1 + 3.69 / Math.Pow(epattern, 2)
        alpha = avg / MathNet.Numerics.SpecialFunctions.Gamma(1 + 1 / beta)

    End Sub

    Public Sub ShowForm(ByRef fm As Windows.Forms.Form, formType As Type, Optional modal As Boolean = False)


        If fm Is Nothing OrElse fm.IsDisposed() Then
            fm = Activator.CreateInstance(formType)
        End If

        If fm.Visible Then
            fm.BringToFront()
        Else
            If modal Then
                fm.ShowDialog()
            Else
                fm.Show()
            End If
        End If

    End Sub

    Public Function createObject(Of T)() As T
        Dim tmp As T = GetType(T).GetConstructor(New System.Type() {}).Invoke(New Object() {})
        Return tmp
    End Function

    Public Function GetNumberOfLines(filename As String) As Integer
        Dim lineCount As Integer = 0
        Dim reader As New System.IO.StreamReader(filename)

        While Not (reader.ReadLine() Is Nothing)
            lineCount += 1
        End While
        reader.Close()
        GetNumberOfLines = lineCount
    End Function

    Public Function GetDouble(value As String, Optional defaultValue As String = "0.0") As Double
        Dim result As Double

        ''Try parsing in the current culture
        If Not Double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, result) Then
            If Not Double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), result) Then
                If Not Double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, result) Then
                    result = defaultValue
                End If
            End If
        End If

        Return result
    End Function
End Module
