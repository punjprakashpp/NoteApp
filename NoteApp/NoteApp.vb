Public Class NoteApp
    Dim cc As Boolean
    Dim sa As Boolean
    Dim FileName As String
    Dim zm As Double = 1.0

    Private Sub OpenFile()
        OpenFileDialog1.AddExtension = True
        OpenFileDialog1.DefaultExt = ".txt"
        OpenFileDialog1.ShowDialog()
        FileName = OpenFileDialog1.FileName
        If FileName <> "" Then
            RichTextBox1.LoadFile(FileName)
            Me.Text = FileName + " - " + "NoteApp"
            CloseToolStripMenuItem.Enabled = True
            SaveAsToolStripMenuItem.Enabled = True
            sa = False
        Else
            OpenFileDialog1.Dispose()
        End If
    End Sub

    Private Sub SaveFile()
        If RichTextBox1.Text <> "" = True Then
            If FileName = "" Then
                SaveFileDialog1.AddExtension = True
                SaveFileDialog1.DefaultExt = ".txt"
                If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                    FileName = SaveFileDialog1.FileName
                    RichTextBox1.SaveFile(FileName)
                    sa = True
                    SaveAsToolStripMenuItem.Enabled = True
                    CloseToolStripMenuItem.Enabled = True
                    Me.Text = FileName + " - " + "NoteApp"
                Else
                    Return
                End If
            ElseIf FileName <> "" Then
                RichTextBox1.SaveFile(FileName)
                sa = True
                SaveAsToolStripMenuItem.Enabled = True
                CloseToolStripMenuItem.Enabled = True
                Me.Text = FileName + " - " + "NoteApp"
            Else
                sa = False
                SaveAsToolStripMenuItem.Enabled = False
                CloseToolStripMenuItem.Enabled = False
                Me.Text = "Unsaved - " + "NoteApp"
            End If
            Else
                If FileName = "" Then
                    Return
                ElseIf FileName <> "" Then
                    RichTextBox1.SaveFile(FileName)
                    sa = True
                    SaveAsToolStripMenuItem.Enabled = True
                    CloseToolStripMenuItem.Enabled = True
                    Me.Text = FileName + " - " + "NoteApp"
                End If
            End If
    End Sub

    Private Sub SaveAsFile()
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            FileName = SaveFileDialog1.FileName
            RichTextBox1.SaveFile(FileName)
            Me.Text = FileName + " - " + "NoteApp"
        End If
    End Sub

    Private Sub CloseFile()
        RichTextBox1.Clear()
        sa = False
        SaveAsToolStripMenuItem.Enabled = False
        Me.Text = "Unsaved - " + "NoteApp"
        FileName = ""
    End Sub

    Private Sub exitNoteApp()
        If RichTextBox1.Text <> "" Then
            Dim res As Integer
            res = MsgBox("Do you want to save the File?", MsgBoxStyle.YesNoCancel, "Close File")
            If res = vbYes Then
                SaveFile()
                CloseFile()
            ElseIf res = vbNo Then
                CloseFile()
            End If
            CloseToolStripMenuItem.Enabled = False
        End If
        Me.Dispose()
    End Sub

    Private Sub NoteApp_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        exitNoteApp()
    End Sub

    Private Sub NoteApp_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.RichTextBox1.Width = Me.Width - 35
        Me.RichTextBox1.Height = Me.Height - 70
        FileName = ""
        cc = False
        sa = False
        RichTextBox1.WordWrap = False
        StatusStrip1.Visible = False
        UndoToolStripMenuItem.Enabled = False
        UndoToolStripMenuItem1.Enabled = False
        CutToolStripMenuItem.Enabled = False
        CutToolStripMenuItem1.Enabled = False
        CopyToolStripMenuItem.Enabled = False
        CopyToolStripMenuItem1.Enabled = False
        DeleteToolStripMenuItem.Enabled = False
        DeleteToolStripMenuItem1.Enabled = False
        SelectAllToolStripMenuItem.Enabled = False
        SelectAllToolStripMenuItem1.Enabled = False
        FindToolStripMenuItem.Enabled = False
        FindNextToolStripMenuItem.Enabled = False
        FindPreviousToolStripMenuItem.Enabled = False
        SaveAsToolStripMenuItem.Enabled = False
        CloseToolStripMenuItem.Enabled = False
        Me.Text = "Unsaved - " + "NoteApp"
    End Sub

    Private Sub NoteApp_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.RichTextBox1.Width = Me.Width - 35
        Me.RichTextBox1.Height = Me.Height - 70
    End Sub

    Private Sub NoteApp_ResizeBegin(sender As Object, e As System.EventArgs) Handles Me.ResizeBegin
        Me.RichTextBox1.Width = Me.Width - 35
        Me.RichTextBox1.Height = Me.Height - 70
    End Sub

    Private Sub NoteApp_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd
        Me.RichTextBox1.Width = Me.Width - 35
        Me.RichTextBox1.Height = Me.Height - 70
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CutToolStripMenuItem.Click
        If RichTextBox1.Text <> "" Then
            Clipboard.Clear()
            RichTextBox1.Cut()
            cc = True
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If RichTextBox1.Text <> "" Then
            Clipboard.Clear()
            RichTextBox1.Copy()
            cc = False
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        If cc = True Then
            RichTextBox1.Paste()
            Clipboard.Clear()
        Else
            RichTextBox1.Paste()
        End If
    End Sub

    Private Sub CutToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CutToolStripMenuItem1.Click
        If RichTextBox1.Text <> "" Then
            Clipboard.Clear()
            RichTextBox1.Cut()
            cc = True
        End If
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        If RichTextBox1.Text <> "" Then
            Clipboard.Clear()
            RichTextBox1.Copy()
            cc = False
        End If
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles PasteToolStripMenuItem1.Click
        If cc = True Then
            RichTextBox1.Paste()
            Clipboard.Clear()
        Else
            RichTextBox1.Paste()
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        RichTextBox1.Redo()
    End Sub

    Private Sub UndoToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles UndoToolStripMenuItem1.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs)
        RichTextBox1.Redo()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub SelectAllToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SelectAllToolStripMenuItem1.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        RichTextBox1.SelectionFont = FontDialog1.Font
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        RichTextBox1.SelectionColor = ColorDialog1.Color
    End Sub

    Private Sub FontToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles FontToolStripMenuItem1.Click
        FontDialog1.ShowDialog()
        RichTextBox1.SelectionFont = FontDialog1.Font
    End Sub

    Private Sub ColorToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ColorToolStripMenuItem1.Click
        ColorDialog1.ShowDialog()
        RichTextBox1.SelectionColor = ColorDialog1.Color
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        If RichTextBox1.Text <> "" Then
            Dim res As Integer
            res = MsgBox("Do you want to save the File?", MsgBoxStyle.YesNoCancel, "Open File")
            If res = vbYes Then
                SaveFile()
                CloseFile()
                OpenFile()
            ElseIf res = vbNo Then
                RichTextBox1.Clear()
                OpenFile()
            End If
        Else
            OpenFile()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFile()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If RichTextBox1.Text <> "" Then
            Dim res As Integer
            res = MsgBox("Do you want to save the File?", MsgBoxStyle.YesNoCancel, "New File")
            If res = vbYes Then
                SaveFile()
                CloseFile()
            ElseIf res = vbNo Then
                CloseFile()
            End If
        End If
        sa = False
        SaveAsToolStripMenuItem.Enabled = False
        CloseToolStripMenuItem.Enabled = False
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        If RichTextBox1.Text <> "" Then
            Dim res As Integer
            res = MsgBox("Do you want to save the File?", MsgBoxStyle.YesNoCancel, "Close File")
            If res = vbYes Then
                SaveFile()
                CloseFile()
            ElseIf res = vbNo Then
                CloseFile()
            End If
            CloseToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveAsFile()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        exitNoteApp()
    End Sub

    Private Sub AboutNoteAppToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutNoteAppToolStripMenuItem.Click
        MsgBox("NoteApp Version 1.0" & vbNewLine & vbNewLine & "Developed by Punj Prakash", MsgBoxStyle.OkOnly, "About NoteApp")
    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WordWrapToolStripMenuItem.Click
        If WordWrapToolStripMenuItem.Checked = True Then
            RichTextBox1.WordWrap = True
        Else
            RichTextBox1.WordWrap = False
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As System.EventArgs) Handles RichTextBox1.TextChanged
        LineLabel.Text = "Line : " + Str(RichTextBox1.Lines.Length)
        CharLabel.Text = "Char : " + Str(RichTextBox1.TextLength)
        UndoToolStripMenuItem.Enabled = True
        UndoToolStripMenuItem1.Enabled = True
        CutToolStripMenuItem.Enabled = True
        CutToolStripMenuItem1.Enabled = True
        CopyToolStripMenuItem.Enabled = True
        CopyToolStripMenuItem1.Enabled = True
        DeleteToolStripMenuItem.Enabled = True
        DeleteToolStripMenuItem1.Enabled = True
        SelectAllToolStripMenuItem.Enabled = True
        SelectAllToolStripMenuItem1.Enabled = True
        FindToolStripMenuItem.Enabled = True
        FindNextToolStripMenuItem.Enabled = True
        FindPreviousToolStripMenuItem.Enabled = True
    End Sub

    Private Sub DateTimeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DateTimeToolStripMenuItem.Click
        RichTextBox1.AppendText(DateTime.Now.ToString)
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ZoomInToolStripMenuItem.Click
        If zm < 64.0 And zm >= 1.0 Then
            zm = zm + 0.25
            RichTextBox1.ZoomFactor = zm
        End If
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ZoomOutToolStripMenuItem.Click
        If zm < 64.0 And zm >= 1.0 Then
            zm = zm - 0.25
            RichTextBox1.ZoomFactor = zm
        End If
    End Sub

    Private Sub DefaultZoomToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DefaultZoomToolStripMenuItem.Click
        zm = 1.0
        RichTextBox1.ZoomFactor = zm
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StatusBarToolStripMenuItem.Click
        If StatusBarToolStripMenuItem.Checked = True Then
            StatusStrip1.Visible = True
            StatusStrip1.Show()
        Else
            StatusStrip1.Visible = False
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(RichTextBox1.Text, FontDialog1.Font, Brushes.Black, 100, 100)
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click
        PageSetupDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings
        PageSetupDialog1.ShowDialog()
    End Sub
End Class
