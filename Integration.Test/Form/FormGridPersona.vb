Option Explicit On
Imports Integration.BE
Imports Integration.BL

Public Class FormGridPersona

    'Dim RequestConst As New BE.Constante.BE_ReqConstante
    'Dim ObjConst As New BL_Constante

    Enum GrillaPersona
        ColcPercodigo = 0
        ColnPerTipo = 1
        ColTipoPersona = 2
        ColnPerIdeTipo = 3
        ColTipoDocu = 4
        ColcPerIdeNumero = 5
        ColnPerTratamiento = 6
        ColcPerApellPaterno = 7
        ColcPerApellMaterno = 8
        ColcPerPriNombre = 9
        ColcPerSegNombre = 10
        ColcPerTerNombre = 11
        Colcpernombre = 12
        ColdPerNacimiento = 13
        ColnPerNatSexo = 14
        ColnPerNatEstCivil = 15
        ColnPerJurSecEconomico = 16
        ColnPerJurTipInversion = 17
        ColcUbiGeoCodigo = 18
        ColnIntCodigo = 19 'nacionalidad

    End Enum

    Private Sub FormGridPersona_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        nFormPerPredeterminado = 0

        LlenaDataCombo(CboTipoPer, ObjConst.Get_Constante("C", CLng(CboTipoPer.Tag)), "nConValor", "cConDescripcion")

        CboFiltro.SelectedIndex = 2
        Me.WindowState = FormWindowState.Maximized
        FormatGrilla(Table1, Me, True)

    End Sub

    Private Sub c1CmdNuevo_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles c1CmdNuevo.Click

        nAccionBotones = nAccionButton.nAccionNuevo
        'cNewCodigoPer = Get_Valor("Exec usp_Persona_Get_NewId", "NewCodigo")
        FormMaPersona.Width = 435
        FormMaPersona.Text = "Agregando Persona.."
        FormMaPersona.ShowDialog()
        C1CmdBuscar_Click(C1CmdBuscar, Nothing)

    End Sub

    Private Sub C1CmdBuscar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1CmdBuscar.Click

        Dim StrFiltro As String = ""
        Dim StrFilNroDocu As String = ""

        Dim Request As New BE.Persona.BE_ReqPersonaSearh
        Dim ObjBL As New BL_Persona

        Select Case CboFiltro.SelectedIndex
            Case 0 'DNI/RUC
                StrFilNroDocu = TxtBuscar.Text
            Case 1 'Comienza
                StrFiltro = DBTilde(TxtBuscar.Text) & "%"
            Case 2 'Contiene
                StrFiltro = "%" & DBTilde(TxtBuscar.Text) & "%"
            Case 3 'Termina
                StrFiltro = "%" & DBTilde(TxtBuscar.Text)
        End Select

        If TxtBuscar.Text = vbNullString Or Len(TxtBuscar.Text) <= 2 Then Exit Sub

        'mando los parametros al Request
        Request.cNombre = StrFiltro
        Request.cPerIdeNumero = StrFilNroDocu
        Request.nPerTipo = CboTipoPer.SelectedValue
        'Request.cCodColegio = "N"

        'recuperando registros en la DataGridView
        Table1.DataSource = ObjBL.Get_SearhPersona(Request)

        LblMsg.Text = "Se encontraron " & Table1.RowCount & " registros, como resultado de la busqueda."

    End Sub

    Private Sub FormGridPersona_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        'Table1.Width = Width - 35
        'Table1.Height = Height - 155
        Table1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Bottom _
            Or System.Windows.Forms.AnchorStyles.Left _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    End Sub

    Private Sub C1CmdCerrar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1CmdCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TxtBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBuscar.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then Call C1CmdCerrar_Click(C1CmdCerrar, Nothing)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then Call C1CmdBuscar_Click(C1CmdBuscar, Nothing)

    End Sub

    Private Sub C1CmdEdit_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1CmdEdit.Click

        If Table1.RowCount = 0 Then Exit Sub

        'determinando acccion
        nAccionBotones = nAccionButton.nAccionEdit

        'formulario predeterminado
        If CboTipoPer.SelectedValue = nConTipoPersona.nPerNatural Then nFormPerPredeterminado = nConTipoPersona.nPerNatural Else nFormPerPredeterminado = nConTipoPersona.nPerJuridica

        With Table1
            If Not .CurrentCell Is Nothing Then
                If .RowCount > 0 Then
                    StrPasaValores = vbNullString
                    StrPasaValores = "cPercodigo=" & .Item(GrillaPersona.ColcPercodigo, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "nPerTipo=" & .Item(GrillaPersona.ColnPerTipo, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "nPerIdeTipo=" & .Item(GrillaPersona.ColnPerIdeTipo, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "cPerIdeNumero=" & .Item(GrillaPersona.ColcPerIdeNumero, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "nPerTratamiento=" & .Item(GrillaPersona.ColnPerTratamiento, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "cPerApellPaterno=" & .Item(GrillaPersona.ColcPerApellPaterno, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "cPerApellMaterno=" & .Item(GrillaPersona.ColcPerApellMaterno, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "cPerPriNombre=" & .Item(GrillaPersona.ColcPerPriNombre, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "cPerSegNombre=" & .Item(GrillaPersona.ColcPerSegNombre, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "cPerTerNombre=" & .Item(GrillaPersona.ColcPerTerNombre, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "cpernombre=" & .Item(GrillaPersona.Colcpernombre, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "dPerNacimiento=" & .Item(GrillaPersona.ColdPerNacimiento, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "nPerNatSexo=" & .Item(GrillaPersona.ColnPerNatSexo, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "nPerNatEstCivil=" & .Item(GrillaPersona.ColnPerNatEstCivil, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "nPerJurSecEconomico=" & .Item(GrillaPersona.ColnPerJurSecEconomico, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "nPerJurTipInversion=" & .Item(GrillaPersona.ColnPerJurTipInversion, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "cUbiGeoCodigo=" & .Item(GrillaPersona.ColcUbiGeoCodigo, .CurrentRow.Index).Value.ToString & ";"
                    StrPasaValores = StrPasaValores & "nIntCodigo=" & .Item(GrillaPersona.ColnIntCodigo, .CurrentRow.Index).Value.ToString
                    FormMaPersona.Text = "Actualizando datos Persona.."
                    FormMaPersona.ShowDialog()
                    C1CmdBuscar_Click(C1CmdBuscar, Nothing)
                End If

            End If
        End With
    End Sub

    Private Sub Table1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Table1.CellDoubleClick
        Call C1CmdEdit_Click(C1CmdEdit, Nothing)
    End Sub

End Class