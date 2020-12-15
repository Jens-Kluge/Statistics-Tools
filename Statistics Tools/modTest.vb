Imports System.Globalization

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

        Dim fmplot As New frmPlot
        frmPlot.Show()

    End Sub
End Module
