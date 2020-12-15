Public Class DropDownCheckedListBox

    Private Const T_DisplayListSize As Integer = 6
    Private Const SelectNoneText As String = "(None Selected)"
    Private Const SelectAllText As String = "(All Selected)"
    Private Const SelectSomeText As String = "(Some Selected...)"
    Private Frm As Form
    Private LostFocus As Boolean
    Private CodeValue As String
    Private T_MustFill As Boolean
    Private Shared m_ChkItemsString As String
    Public Event DropDown()
    Public Shadows Event TextChanged()


    Public Sub New()
            InitializeComponent()
            InitializeNew()
        End Sub

        Private Sub InitializeNew()
            Dim strTemp As String
            ListSize = T_DisplayListSize
            T_DroppedDown = False
            T_ListText = ""
            T_MustFill = False
            txt.Text = strTemp
            chkListbox.Hide()
            Frm = New Form
            With Frm
                .ShowInTaskbar = False
                .FormBorderStyle = FormBorderStyle.None
                .ControlBox = False
                .StartPosition = FormStartPosition.Manual
                .TopMost = True
                .Location = chkListbox.Location
                .Width = chkListbox.Width
                .Controls.Add(chkListbox)
            End With
            SetSize()
        End Sub
        Private dataList() As String

    Public Property Items() As String()
        Get
            Return dataList
        End Get

        Set(ByVal value As String())
            dataList = value

            If value IsNot Nothing Then
                chkListbox.Items.Clear()
                FillListBox()
            End If

        End Set

    End Property

    Private ListSize As Integer
        Public Property DisplayListSize() As Integer
            Get
                Return ListSize
            End Get
            Set(ByVal value As Integer)
                ListSize = value
                SetList()
            End Set
        End Property
        Private T_DroppedDown As Boolean
        Public ReadOnly Property DroppedDown() As Boolean
            Get
                Return T_DroppedDown
            End Get
        End Property
        Private T_ListText As String
        Public ReadOnly Property ListText() As String
            Get
                Return T_ListText
            End Get
        End Property
        Private Sub ListButtonClick()
            Dim strTemp As String
            strTemp = T_ListText
            If T_DroppedDown Then
                T_DroppedDown = False
                txt.Text = GetSelectedItems()
                chkListbox.Hide()
                Frm.Hide()
                txt.Focus()
                If Not strTemp = T_ListText Then
                    RaiseEvent TextChanged()
                End If
            ElseIf Not LostFocus Then
                T_DroppedDown = True
                SetSize()
                Frm.Show()
                chkListbox.Show()
                chkListbox.Focus()
                RaiseEvent DropDown()
            End If
            LostFocus = False

        End Sub

        Private Function GetSelectedItems() As String
            Dim strLst As String
            Dim blnAllSelected As Boolean = False
            strLst = ""
            With chkListbox
                If .Items.Count > 0 Then
                    If .CheckedIndices.Count = 0 Then
                        strLst = SelectNoneText
                    Else
                        If .CheckedIndices.Count = .Items.Count Then
                            strLst = SelectAllText
                        Else
                            strLst = .CheckedIndices.Count & " selected" 'SelectSomeText
                        End If
                    End If
                Else
                    strLst = SelectNoneText
                End If
            End With
            Return strLst
        End Function

        Private Sub SetList()

            Dim oFrm As Form
            Dim oRect As Rectangle
            Dim oPt As Point

            If Frm IsNot Nothing Then
                Frm.Height = (ListSize * chkListbox.ItemHeight) + 3
                chkListbox.Height = Frm.Height
                chkListbox.Top = 0
                oFrm = Me.FindForm
                If oFrm IsNot Nothing Then
                    oPt = Me.ParentForm.PointToClient(Me.PointToScreen(Point.Empty))
                    oPt.Y = oPt.Y + Me.txt.Height
                    oRect = oFrm.RectangleToScreen(oFrm.ClientRectangle)
                    oPt.X = oPt.X + oRect.Left
                    oPt.Y = oPt.Y + oRect.Top
                    Frm.Location = oPt
                End If
                Frm.Width = chkListbox.Width
            End If
        End Sub
        Private Sub SetSize()
            LostFocus = False
            txt.Width = Me.Width
            btnDropdown.Left = txt.Width - btnDropdown.Width - 2
            chkListbox.Width = Me.Width
            Me.Height = txt.Height
            SetList()
        End Sub

        Private Sub bChkLstBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus, chkListBox.LostFocus
            Dim strTemp As String
            LostFocus = True
            strTemp = T_ListText
            T_DroppedDown = False
            chkListbox.Hide()
            Frm.Hide()
            If Not strTemp = T_ListText Then
                RaiseEvent TextChanged()
            End If
        End Sub
        Private Sub bChkLstBox_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            SetSize()
        End Sub
        Private Sub bChkLstBox_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.MouseHover, txt.MouseHover
            LostFocus = False
        End Sub

    Private Sub bLstList_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkListBox.MouseMove
        setText(Me.chkListbox)
    End Sub

    Private Sub bLstText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt.Click
        LostFocus = False
        If T_DroppedDown Then
            ListButtonClick()
        End If
    End Sub


    Private Sub bLstText_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt.KeyPress
        LostFocus = False
        Me.OnKeyPress(e)
    End Sub


    Private Sub bLstText_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt.KeyUp
        LostFocus = False
        Me.OnKeyUp(e)
    End Sub


    Public Event SelectedIndexChanged(ByVal sender As DropDownCheckedListBox)

    Public Shared Function GetItemsNameString(ByVal tempListBox As CheckedListBox) As String
        m_ChkItemsString = ""
        Try
            If tempListBox.CheckedItems.Count > 0 Then
                Dim tempItem As Object
                For Each tempItem In tempListBox.CheckedItems
                    m_ChkItemsString = m_ChkItemsString & "," & tempItem.ToString()
                Next
            End If
            m_ChkItemsString = m_ChkItemsString.Trim().Substring(1, m_ChkItemsString.Length - 1)
        Catch ex As Exception

        End Try
        Return m_ChkItemsString
    End Function

    Public Sub setText(ByVal chklist As CheckedListBox)
            If chklist.Items.Count > 0 Then
                If chklist.CheckedIndices.Count = chklist.Items.Count Then
                    txt.Text = SelectAllText
                    Exit Sub
                End If
                If chklist.CheckedIndices.Count > 0 Then
                    txt.Text = chklist.CheckedIndices.Count & " selected"
                ElseIf chklist.CheckedIndices.Count = 0 Then
                    txt.Text = SelectNoneText
                End If
            Else
                txt.Text = SelectNoneText
            End If

        End Sub

    Private Sub bChkLstBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FillListBox()
    End Sub


    Private Sub FillListBox()
        If dataList IsNot Nothing Then
            If dataList.GetUpperBound(0) > 0 Then
                For i As Integer = 0 To dataList.GetUpperBound(0)
                    If dataList(i) IsNot Nothing Then
                        chkListbox.Items.Add(dataList(i))
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnDropdown_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDropdown.MouseDown
            ListButtonClick()
        End Sub

        Private Sub btnDropdown_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDropdown.MouseHover
            LostFocus = False
        End Sub

        Private Sub btnDropdown_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDropdown.MouseUp
            LostFocus = False
        End Sub


End Class
