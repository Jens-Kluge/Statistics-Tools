Imports System.Globalization
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmReadData

    Private _separator As Char = ","
    Private _datatable As DataTable = Nothing
    Private _fname As String = ""
    Private _culture As CultureInfo = CultureInfo.CreateSpecificCulture("en-us")
    Private _Datatbl As Object

    Property TblData

        Get
            Return _datatable
        End Get

        Set
            _datatable = Value
        End Set

    End Property

    Private Sub btnReadData_Click(sender As Object, e As EventArgs) Handles btnReadData.Click
        Dim fName As String = ""
        Dim numLines As Integer
        If Not System.IO.File.Exists(_fname) Then
            If modGlobals.gImportDir <> "" Then
                OpenFileDialog1.InitialDirectory = modGlobals.gImportDir
            Else
                OpenFileDialog1.InitialDirectory = "c:\desktop"
            End If

            OpenFileDialog1.Filter = "CSV files (*.csv)|*.CSV"
            OpenFileDialog1.FilterIndex = 2
            OpenFileDialog1.RestoreDirectory = True
            If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                fName = OpenFileDialog1.FileName
                modGlobals.gImportDir = path.getdirectoryname(OpenFileDialog1.FileName)
            End If
        Else
            fName = _fname
        End If

        txtpathfile.Text = fName

        'Read in data line by line, generate datatable
        'set data source of datagrid to datatable

        Dim TextLine As String = ""
        Dim SplitLine() As String
        Dim IsFirstLine As Boolean = True
        Dim linenr As Integer = 0

        If _datatable Is Nothing Then
            _datatable = New DataTable
        End If

        _datatable.TableName = "MyData"
        Try
            _datatable.Rows.Clear()
            _datatable.Columns.Clear()
            DataGridView1.Refresh()

            If System.IO.File.Exists(fName) = True Then
                numLines = GetNumberOfLines(fName)
                ProgressBar1.Maximum = numLines

                Dim objReader As New System.IO.StreamReader(fName)
                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine()
                    linenr += 1
                    ProgressBar1.Value = linenr

                    SplitLine = Split(TextLine, _separator)
                    If IsFirstLine Then
                        If chkHeaders.Checked Then
                            For i = 1 To SplitLine.Length
                                _datatable.Columns.Add(New DataColumn(SplitLine(i - 1), GetType(Double)))
                            Next
                        Else
                            For i = 1 To SplitLine.Length
                                _datatable.Columns.Add(New DataColumn("Column_" & i, GetType(Double)))
                            Next
                        End If
                        IsFirstLine = False
                    End If

                    Dim objFields = From field In SplitLine
                                    Select CType(Double.Parse(field, _culture), Object)
                    Dim newRow = _datatable.Rows.Add()
                    newRow.ItemArray = objFields.ToArray()
                Loop
                If Not chkHeaders.Checked Then
                    btnHeaders.Enabled = True
                End If

                DataGridView1.DataSource = _datatable
                objReader.Close()
                objReader.Dispose()

            Else
                MsgBox("File Does Not Exist")
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    ''' <summary>
    ''' Use RowPostPaintEvent to display row numbers
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim dg As DataGridView = DirectCast(sender, DataGridView)
        ' Current row record
        Dim rowNumber As String = (e.RowIndex + 1).ToString()

        ' Format row based on number of records displayed by using leading zeros
        While rowNumber.Length < dg.RowCount.ToString().Length
            rowNumber = "0" & rowNumber
        End While

        ' Position text
        Dim size As SizeF = e.Graphics.MeasureString(rowNumber, Me.Font)
        If dg.RowHeadersWidth < CInt(size.Width + 20) Then
            dg.RowHeadersWidth = CInt(size.Width + 20)
        End If

        ' Use default system text brush
        Dim b As Brush = SystemBrushes.ControlText

        ' Draw row number
        e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub frmReadData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSep.SelectedIndex = 0 'comma separator
        _fname = ""
        rbDot.Checked = True
        btnHeaders.Enabled = False

        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.EnableHeadersVisualStyles = False

    End Sub

    ''' <summary>
    ''' Select the CSV file from which to import data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSelFile_Click(sender As Object, e As EventArgs) Handles btnSelFile.Click

        Dim fName As String

        OpenFileDialog1.InitialDirectory = modGlobals.gImportDir
        OpenFileDialog1.Filter = "CSV files (*.csv)|*.CSV"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        modGlobals.gImportDir = OpenFileDialog1.Filter

        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            fName = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        _fname = fName
        txtpathfile.Text = fName
        'read in first lines and display them in the label

        Dim objReader As New System.IO.StreamReader(fName)
        Label2.Text = ""

        For i = 1 To 3

            If objReader.Peek() = -1 Then
                Exit For
            End If
            Label2.Text = Label2.Text & objReader.ReadLine() & vbCrLf

        Next i

    End Sub

    Private Sub cmbSep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSep.SelectedIndexChanged
        Dim selSep As String

        selSep = cmbSep.SelectedItem.ToString()
        Select Case selSep
            Case ",", ";", "|"
                _separator = selSep
            Case "Space"
                _separator = " "
            Case "Tab"
                _separator = vbTab
        End Select

    End Sub

    Private Sub rbDot_CheckedChanged(sender As Object, e As EventArgs) Handles rbDot.CheckedChanged

        If rbDot.Checked Then
            _culture = CultureInfo.CreateSpecificCulture("en-US")
        Else
            _culture = CultureInfo.CreateSpecificCulture("de-DE")
        End If

    End Sub

    Private Sub btnHeaders_Click(sender As Object, e As EventArgs) Handles btnHeaders.Click

        Dim headers() As String
        Dim fname As String

        OpenFileDialog1.InitialDirectory = modGlobals.gImportDir
        OpenFileDialog1.Filter = "CSV files (*.csv)|*.CSV"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True

        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            fname = OpenFileDialog1.FileName
        Else
            Exit Sub
        End If

        If System.IO.File.Exists(fname) = False Or _datatable Is Nothing Then
            Exit Sub
        End If

        Try

            headers = ReadHeadersFromFile(fname)

            For i = 1 To DataGridView1.Columns.Count
                DataGridView1.Columns(i - 1).HeaderText = headers(i - 1)
                _datatable.Columns(i - 1).ColumnName = headers(i - 1)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function ReadHeadersFromFile(filename As String) As String()
        Dim objReader As New System.IO.StreamReader(filename)

        If Not System.IO.File.Exists(filename) Then
            Return Nothing
        End If

        'read in first lines and display them in the label
        Dim parser As TextFieldParser = New TextFieldParser(objReader)
        parser.SetDelimiters(_separator)
        parser.CommentTokens = New String() {"#"}
        parser.HasFieldsEnclosedInQuotes = True

        Return parser.ReadFields
        objReader.Close()

    End Function

    Private Sub chkHeaders_CheckedChanged(sender As Object, e As EventArgs) Handles chkHeaders.CheckedChanged

        If chkHeaders.Checked Then
            btnHeaders.Enabled = False
        Else
            If _datatable IsNot Nothing Then
                btnHeaders.Enabled = True
            End If
        End If

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        Dim fname As String

        'set properties of select file control
        sfdExport.Filter = "Excel files (*.xlsx)|*.xlsx"
        sfdExport.FileName = "Mydata.xlsx"

        'ofdExport.FilterIndex = 2

        If modGlobals.gExportDir = "" Then
            sfdExport.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End If

        If (sfdExport.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            fname = sfdExport.FileName
            modGlobals.gExportDir = Path.GetDirectoryName(sfdExport.FileName)
        Else
            Exit Sub
        End If

        ExportDatasetToExcel(fname)

    End Sub


    Sub ExportDatasetToExcel(outputPath As String)
        ' Create the Excel Application object
        Dim excelApp As New Excel.Application

        ' Create a new Excel Workbook
        Dim excelWorkbook As Excel.Workbook = excelApp.Workbooks.Add(Type.Missing)


        Dim col, row As Integer
        Dim excelSheet As Excel.Worksheet

        Dim dt As DataTable = _datatable


        ' Copy the DataTable to an object array
        Dim rawData(dt.Rows.Count, dt.Columns.Count - 1) As Object
        Try
            Cursor = Cursors.WaitCursor
            btnExcel.Enabled = False
            ProgressBar1.Maximum = dt.Rows.Count
            ProgressBar1.Value = 0

            ' Copy the column names to the first row of the object array
            For col = 0 To dt.Columns.Count - 1
                rawData(0, col) = dt.Columns(col).ColumnName
            Next

            ' Copy the values to the object array

            For row = 0 To dt.Rows.Count - 1
                For col = 0 To dt.Columns.Count - 1
                    rawData(row + 1, col) = dt.Rows(row).ItemArray(col)
                Next
                ProgressBar1.Value = row
                'ProgressBar1.Update()
                ProgressBar1.Refresh()
            Next

            ' Calculate the final column letter
            Dim finalColLetter As String = String.Empty
            Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim colCharsetLen As Integer = colCharset.Length


            If dt.Columns.Count > colCharsetLen Then
                finalColLetter = colCharset.Substring(
                     (dt.Columns.Count - 1) \ colCharsetLen - 1, 1)
            End If


            finalColLetter += colCharset.Substring(
                  (dt.Columns.Count - 1) Mod colCharsetLen, 1)


            ' Create a new Sheet
            excelSheet = CType(excelWorkbook.Sheets.Add(excelWorkbook.Sheets(1),
                    Type.Missing, 1, Excel.XlSheetType.xlWorksheet), Excel.Worksheet)

            excelSheet.Name = dt.TableName

            ' Fast data export to Excel
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, dt.Rows.Count + 1)
            excelSheet.Range(excelRange, Type.Missing).Value2 = rawData


            ' Save and Close the Workbook
            excelWorkbook.SaveAs(Filename:=outputPath, FileFormat:=Excel.XlFileFormat.xlWorkbookDefault, AccessMode:=Excel.XlSaveAsAccessMode.xlExclusive)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
            btnExcel.Enabled = True
            excelSheet = Nothing
            excelWorkbook.Close(True, Type.Missing, Type.Missing)
            excelWorkbook = Nothing
            ' Release the Application object
            excelApp.Quit()
            excelApp = Nothing

            ' Collect the unreferenced objects
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class