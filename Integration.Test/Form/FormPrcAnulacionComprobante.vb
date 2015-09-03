Option Explicit On
Imports Integration.BL.BL_CtaCtes

Public Class FormPrcAnulacionComprobante

    Private Sub FormPrcAnulacionComprobante_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        FormatGrilla(Table1, Me, True, 30, False, DataGridViewSelectionMode.CellSelect)
        FormatGrilla(Table2, Me, True, 30, False, DataGridViewSelectionMode.CellSelect)

        CboFiltro.SelectedIndex = 0

    End Sub

    Private Sub C1CmdBuscar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1CmdBuscar.Click

        Dim BL As New BL_AnularComprobante
        Table1.DataSource = BL.Get_CtaCteItem_for_cCtaCteRecibo_by_range_fechas("ITEM", FormatDateTime(DtpFecIni.Value, DateFormat.ShortDate), FormatDateTime(DtpFecFin.Value, DateFormat.ShortDate), "")

    End Sub

    Private Sub Table1_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles Table1.SelectionChanged

        If Table1.RowCount > 0 Then
            Dim BL As New BL_AnularComprobante
            Table2.DataSource = BL.Get_CtaCteItem_for_cCtaCteRecibo_by_range_fechas("PAGO", FormatDateTime(DtpFecIni.Value, DateFormat.ShortDate), FormatDateTime(DtpFecIni.Value, DateFormat.ShortDate), Table1.Item("cCtaCteRecibo", Table1.CurrentRow.Index).Value)
        End If

    End Sub

    Private Sub Table1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles Table1.CellFormatting

        With Table1
            For i As Integer = 0 To .Rows.Count - 1

                If (CDbl(.Item("nCtaCteImporte", i).Value) > 0 And CDbl(.Item("nCtaCteImpAplicado", i).Value) = 0) Then .Rows(i).Cells("nCtaCteEstado").Value = 3

                Dim columnHeaderStyle As New DataGridViewCellStyle()

                '.Rows(i).Cells("DescCtaCteEstado").Style.Font.Style = FontStyle.Bold.ToString
                columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)

                '.ColumnHeadersDefaultCellStyle = columnHeaderStyle
                .RowHeadersDefaultCellStyle = columnHeaderStyle

                Select Case .Rows(i).Cells("nCtaCteEstado").Value
                    Case Is = 0 'Anulado
                        .Rows(i).Cells("DescCtaCteEstado").Style.ForeColor = Color.Red

                    Case Is = 1 'Pendiente
                        .Rows(i).Cells("DescCtaCteEstado").Style.ForeColor = Color.BlueViolet

                        '.Rows(i).Cells("DescCtaCteEstado").Style.Font.Style.Bold.TryParse  = FontStyle.Bold
                        '.Rows(i).DefaultCellStyle.BackColor = Color.Blue

                    Case Is = 2  'Cancelado
                        .Rows(i).Cells("DescCtaCteEstado").Style.ForeColor = Color.Blue

                    Case Is = 3 ' Cargado
                        .Rows(i).Cells("DescCtaCteEstado").Style.ForeColor = Color.Green
                End Select
            Next
        End With

    End Sub

    Private Sub FormPrcAnulacionComprobante_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        Table1.Width = Width - 30
        Label1.Width = Table1.Width

        Table2.Width = Width - 30
        Label2.Width = Table2.Width
        Table2.Height = Height - 430

    End Sub

    Private Sub C1CmdAnular_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1CmdAnular.Click

        Dim cFlag As String = ""

        With Table1

            If .RowCount = 0 Then Exit Sub

            '//Si estado es = ANULADO
            If Microsoft.VisualBasic.Left(.Item("DescCtaCteEstado", .CurrentRow.Index).Value, 3) = "ANU" Then
                MessageBox.Show("Comprobante ya ha sido Anulado; No se puede volver a Anular.", "Validando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            '//Caso contrario
            cFlag = Microsoft.VisualBasic.Left(.Item("DescCtaCteEstado", .CurrentRow.Index).Value, 3)

            If MessageBox.Show("Esta seguro de Anular comprobante: " & .Item("cCtaCteRecibo", .CurrentRow.Index).Value & Chr(13) & "; Si anula este Docuemnto no podra revertir la operación." _
                                    , "Anular comprobante..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim BL As New BL_AnularComprobante

                If BL.Set_AnularComprobante(cFlag, .Item("cPerJurCodigo", .CurrentRow.Index).Value, .Item("cPerCodigo", .CurrentRow.Index).Value, .Item("cCtaCteRecibo", .CurrentRow.Index).Value, .Item("cCtaCteRecAbono1", .CurrentRow.Index).Value, StrUser) Then
                    MessageBox.Show("Comprobante ya ha sido Anualdo. No se puede volver a Anular", "Validando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End With

    End Sub

    Private Sub C1CmdCerrar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1CmdCerrar.Click

        Close()
        Dispose()

    End Sub

    'Private Sub InitializeContextMenu()

    '    ' Create the menu item.
    '    Dim getRecipe As New ToolStripMenuItem( _
    '        "Search for recipe", Nothing, AddressOf ShortcutMenuClick)

    '    ' Add the menu item to the shortcut menu.
    '    Dim recipeMenu As New ContextMenuStrip()
    '    recipeMenu.Items.Add(getRecipe)

    '    ' Set the shortcut menu for the first column.
    '    Table1.Columns(0).ContextMenuStrip = recipeMenu

    'End Sub

    'Private clickedCell As DataGridViewCell

    'Private Sub dataGridView1_MouseDown(ByVal sender As Object, _
    '                                        ByVal e As MouseEventArgs) Handles Table1.MouseDown

    '    ' If the user right-clicks a cell, store it for use by the
    '    ' shortcut menu.
    '    If e.Button = MouseButtons.Right Then
    '        Dim hit As DataGridView.HitTestInfo = _
    '            Table1.HitTest(e.X, e.Y)
    '        If hit.Type = DataGridViewHitTestType.Cell Then
    '            clickedCell = _
    '                Table1.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
    '        End If
    '    End If

    'End Sub

    'Private Sub ShortcutMenuClick(ByVal sender As Object, _
    '                                            ByVal e As System.EventArgs)

    '    If (clickedCell IsNot Nothing) Then
    '        'Retrieve the recipe name.
    '        Dim recipeName As String = CStr(clickedCell.Value)

    '        'Search for the recipe.
    '        System.Diagnostics.Process.Start( _
    '            "http://search.msn.com/results.aspx?q=" + recipeName)
    '    End If

    'End Sub

End Class