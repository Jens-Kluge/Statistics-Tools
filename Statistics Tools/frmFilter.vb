
Public Class FrmFilter

    Sub FillTreeView()
        Dim tbl As DataTable

        Dim strSelField As String
        Dim strSelect As String
        Dim strSort As String
        Dim result() As DataRow
        Dim i As Integer

        'Creating the root node
        Dim root = New TreeNode("Data")
        TreeView1.Nodes.Add(root)

        For i = 1 To modGlobals.TblData.Columns.Count
            TreeView1.Nodes(0).Nodes.Add(New TreeNode(modGlobals.TblData.Columns(i - 1).ColumnName))
        Next


        For i = 1 To modGlobals.TblData.Columns.Count
            strSelField = modGlobals.TblData.Columns(i - 1).ToString
            'return unique values, due to first function argument
            tbl = modGlobals.TblData.DefaultView.ToTable(True, strSelField)
            Dim lst(tbl.Rows.Count) As String

            strSelect = ""
            strSort = String.Format("[{0}] ASC", strSelField)
            result = tbl.Select(strSelect, strSort)

            For Each dr As DataRow In result
                TreeView1.Nodes(0).Nodes(i - 1).Nodes.Add(New TreeNode(dr(0).ToString))
            Next

        Next

        TreeView1.Nodes(0).Checked = True

    End Sub

    Private Sub CheckTreeViewNode(node As TreeNode, isChecked As Boolean)

        For Each item As TreeNode In node.Nodes
            item.Checked = isChecked

            If item.Nodes.Count > 0 Then
                CheckTreeViewNode(item, isChecked)
            End If
        Next

    End Sub


    Private Sub FrmFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillTreeView()
    End Sub

    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        CheckTreeViewNode(e.Node, e.Node.Checked)
    End Sub
End Class