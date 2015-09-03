Option Explicit On

Imports Integration.BE
Imports Integration.BE.Persona
Imports Integration.BE.CtasCtes
Imports Integration.BL
Imports Integration.BL.BL_CtaCtes

Imports System.Transactions

Public Class FormPrcFormaPago

    Private Sub InicilizarCampos()

        LblNroRecibo.Text = TokenByKey(StrPasaValores, "cNroRecibo")
        LblImpRecibo.Text = TokenByKey(StrPasaValores, "nImpRecibo")

        If CDbl(LblTotalPago.Text) = 0 Then
            TxtImpPago.Text = TokenByKey(StrPasaValores, "nImpRecibo")
        End If

        If TokenByKey(StrPasaValores, "nTipoDocu") = 3007 Then '//CONDONACION
            CboFormaPago.SelectedValue = 4 'Condonacion
            CboFormaPago.Enabled = False
        Else
            CboFormaPago.SelectedValue = 1 'Defualt Nuevos Soles
            CboFormaPago.Enabled = True
        End If

        'CboFormaPago.SelectedValue = 1 'Defualt Nuevos Soles
        CboMoneda_SelectionChangeCommitted(CboMoneda, Nothing)
        'TxtImpPago.Text = CDbl(0.0)
        CboBanco.SelectedValue = -1
        CboTipoTarj.SelectedValue = -1
        CboNroCta_TarjetaDC.SelectedValue = -1
        TxtVoucher.Text = vbNullString
        GrpBoxBco.Visible = False

    End Sub

    Function ValidarCamposForAddItemGrd() As Boolean

        ValidarCamposForAddItemGrd = False

        If LblNroRecibo.Text = vbNullString Or LblNroRecibo.Text = "" Then MsgInfoCampoObligatorio(Label5.Text, BtnCancel) : Exit Function
        If CDbl(LblImpRecibo.Text) <= 0 Then MsgInfoCampoObligatorio(Label2.Text, BtnCancel) : Exit Function
        If CboFormaPago.SelectedValue = -1 Then MsgInfoCampoObligatorio(Label1.Text, CboFormaPago) : Exit Function
        If CboMoneda.SelectedValue = -1 Then MsgInfoCampoObligatorio(Label4.Text, CboMoneda) : Exit Function
        If CDbl(TxtImpPago.Text) <= 0 Then MsgInfoCampoObligatorio(Label17.Text, TxtImpPago) : Exit Function

        'If Table2.RowCount = 0 Then MsgInfoCampoObligatorio("No existe ningun medio de pago en el Detalle de Pago.", BtnAdd) : Exit Function

        If FormPrcFacturacion.CboTipoDocu.SelectedValue <> 3007 And CboFormaPago.SelectedValue = 4 Then '//recibo condonacion - forma pago: condonacion
            MessageBox.Show("No puede utilizar este medio de pago, para este tipo de comprobante de venta.", Label1.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        If CboMoneda.SelectedValue <> nTipoMoneda.nSoles Then
            If CDbl(LblTC.Text) <= 0 Then MsgInfoCampoObligatorio(Label20.Text, BtnCancel) : Exit Function
        End If

        Select Case CboFormaPago.SelectedValue
            Case nFomaPago.nDepositoBco
                If CboBanco.SelectedValue = -1 Then MsgInfoCampoObligatorio(Label13.Text, CboBanco) : Exit Function
                If CboNroCta_TarjetaDC.SelectedValue = -1 Then MsgInfoCampoObligatorio(Label10.Text, CboNroCta_TarjetaDC) : Exit Function
                If TxtVoucher.Text = vbNullString Then MsgInfoCampoObligatorio(Label15.Text, TxtVoucher) : Exit Function
            Case nFomaPago.nTarjetaCred
                If CboBanco.SelectedValue = -1 Then MsgInfoCampoObligatorio(Label13.Text, CboBanco) : Exit Function
                If CboTipoTarj.SelectedValue = -1 Then MsgInfoCampoObligatorio(Label12.Text, CboTipoTarj) : Exit Function
                If CboNroCta_TarjetaDC.SelectedValue = -1 Then MsgInfoCampoObligatorio(Label10.Text, CboNroCta_TarjetaDC) : Exit Function
                If TxtVoucher.Text = vbNullString Then MsgInfoCampoObligatorio(Label15.Text, TxtVoucher) : Exit Function
        End Select

        If CDbl(CDbl(Suma_Columna("nCtaCtePagImporte", Table2)) + CDbl(TxtImpPago.Text)) > CDbl(LblImpRecibo.Text) Then MessageBox.Show("Importe a Pagar exede el importe.", "Validando..", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Function

        ValidarCamposForAddItemGrd = True

    End Function

    Private Sub FormPrcFormaPago_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case AscW(Microsoft.VisualBasic.ChrW(Keys.Insert))
                BtnAdd_Click(BtnAdd, Nothing)

            Case AscW(Microsoft.VisualBasic.ChrW(Keys.Delete))
                BtnQuitar_Click(BtnQuitar, Nothing)

            Case AscW(Microsoft.VisualBasic.ChrW(Keys.F7))
                BtnRegPago_Click(BtnRegPago, Nothing)

            Case AscW(Microsoft.VisualBasic.ChrW(Keys.F8))
                BtnPagoDet_Click(BtnPagoDet, Nothing)

        End Select

    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click

        OperacionPago = 0
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub FormPrcFormaPago_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        FormatGrilla(Table2, Me, False, 30)

        LlenaDataCombo(CboMoneda, ObjConst.Get_Constante("C", CLng(TokenByKey(CboMoneda.Tag, "nConCodigo"))), "nConValor", "cConDescripcion")
        LlenaDataCombo(CboFormaPago, ObjConst.Get_Constante("C", CLng(TokenByKey(CboFormaPago.Tag, "nConCodigo"))), "nConValor", "cConDescripcion")

        TxtImpPago.Text = FormatNumber(CDbl(LblImpRecibo.Text), True)

        InicilizarCampos()

        CboFormaPago.Focus()

    End Sub

    Private Sub BtnRegPago_Click(sender As System.Object, e As System.EventArgs) Handles BtnRegPago.Click

        Try
            Dim BLCorrelativo As New BL_CtaCteNumeracion
            Dim BLComp As New BL_CtaCteComprobante

            Dim daCCPago As New BL_CtaCteServicioFacturacion
            Dim Resultado As Boolean ', ResultadoComp As Boolean, ResultadoCorrelativo As Boolean
            Dim ReqCCDet As New BE_ReqCtaCteDetalle

            Dim List As New List(Of BE_ReqCtaCteDetalle)
            Dim Item As BE_ReqCtaCteDetalle = Nothing '//Declara variable

            Dim ListRec As New Dictionary(Of String, Double)

            Dim cPerCodigo As String = FormPrcFacturacion.LblcPerCodigo.Text
            Dim nCajCodigo As Long = CLng(FormPrcFacturacion.LblNroCaja.Text)

            Dim nCtaCteComCodigo As Long = CLng(FormPrcFacturacion.CboTipoDocu.SelectedValue)
            Dim cCtaCteComNumero As String = BLCorrelativo.Get_CtaCteNumCorrelativo(StrcPerJuridica, nCajCodigo, nCtaCteComCodigo)

            '//Validando para que sea pago total si es Factura y/o Boleta
            If CLng(nCtaCteComCodigo) <> 3005 Then 'Recibo Ingreso
                If CDbl(LblTotalPago.Text) < CDbl(LblImpRecibo.Text) Then
                    MessageBox.Show("No podrá realizar ►" & FormPrcFacturacion.CboTipoDocu.Text & "◄ al Credito; Solo Recibo de Ingreso." & Chr(13) & _
                                        "Para realizar este tipo de pago debera pagar el ► Importe Total ◄.", "Validando facturación..", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If MessageBox.Show("¿Desea registrar el Pago.?", "Confirmar operación..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using scope As New TransactionScope()

                    'If CDbl(FormPrcFacturacion.LblTCancel.Text) = 0 Then
                    '    If CLng(FormPrcFacturacion.CboTipoDocu.SelectedValue) = 3005 Then '//recibo
                    '        '//Genera Recibo (99) en CtaCteComprobante
                    '        nCtaCteComCodigo = 3006 'RECIBO (REC)
                    '        cCtaCteComNumero = BLCorrelativo.Get_CtaCteNumCorrelativo(StrcPerJuridica, 0, nCtaCteComCodigo)

                    '        ResultadoComp = BLComp.Ins_CtaCteComprobante(StrcPerJuridica, cPerCodigo, nCajCodigo, nCtaCteComCodigo, cCtaCteComNumero, FormatDateTime(dFechaSistema & Space(1) & TimeOfDay, DateFormat.GeneralDate), CDbl(LblImpRecibo.Text), StrUser)

                    '        '//Actualiza correlativo Recibo
                    '        Dim BLUpdCorrelativo As New BL_CtaCteNumeracion
                    '        ResultadoCorrelativo = BLUpdCorrelativo.Upd_CtaCteNumeracion_nCtaCteNumero(StrcPerJuridica, 0, nCtaCteComCodigo, CLng(Val(Microsoft.VisualBasic.Right(cCtaCteComNumero, 8))))

                    '        '//Seteo variable Para CtaCtePago -> se registra recibo de ingreso (RI)
                    '        nCtaCteComCodigo = CLng(FormPrcFacturacion.CboTipoDocu.SelectedValue)
                    '        cCtaCteComNumero = BLCorrelativo.Get_CtaCteNumCorrelativo(StrcPerJuridica, nCajCodigo, nCtaCteComCodigo)
                    '    Else
                    '        nCtaCteComCodigo = CLng(FormPrcFacturacion.CboTipoDocu.SelectedValue)
                    '        cCtaCteComNumero = BLCorrelativo.Get_CtaCteNumCorrelativo(StrcPerJuridica, nCajCodigo, nCtaCteComCodigo)
                    '        ResultadoComp = BLComp.Ins_CtaCteComprobante(StrcPerJuridica, cPerCodigo, nCajCodigo, nCtaCteComCodigo, cCtaCteComNumero, FormatDateTime(dFechaSistema & Space(1) & TimeOfDay, DateFormat.GeneralDate), CDbl(LblImpRecibo.Text), StrUser)
                    '    End If
                    'Else
                    'nCtaCteComCodigo = CLng(FormPrcFacturacion.CboTipoDocu.SelectedValue)
                    'cCtaCteComNumero = BLCorrelativo.Get_CtaCteNumCorrelativo(StrcPerJuridica, nCajCodigo, nCtaCteComCodigo)
                    'End If

                    '//Llenando List para CtaCteDetalle
                    With Table2
                        If .RowCount > 0 Then
                            For i As Integer = 0 To .Rows.Count - 1
                                Item = New BE_ReqCtaCteDetalle 'Crear Nueva Instancia de clase(objeto) memoria
                                Item.nCtaCteForPago = CLng(.Item("nCtaCteForPago", i).Value)
                                Item.nPerCtaCodigo = CLng(.Item("nPerCtaCodigo", i).Value)
                                Item.cPerjurCodigoFin = .Item("cPerjurCodigoFin", i).Value
                                Item.dCtaCteFecTransacion = FormatDateTime(.Item("dCtaCteFecTransacion", i).Value & Space(1) & TimeOfDay, DateFormat.GeneralDate)
                                Item.cCtaCtePagTracer = .Item("cCtaCtePagTracer", i).Value
                                Item.nMonCodigo = CLng(.Item("nMonCodigo", i).Value)
                                Item.nCtaCtePagImpMon = CDbl(.Item("nCtaCtePagImpMon", i).Value)
                                Item.nTC = CDbl(.Item("nTC", i).Value)
                                Item.nCtaCtePagImporte = CDbl(.Item("nCtaCtePagImporte", i).Value)
                                List.Add(Item)
                            Next
                        Else
                            MsgInfoCampoObligatorio("No existe ningún medio de pago en el Detalle de Pago.", BtnAdd)
                            Exit Sub
                        End If

                    End With

                    Dim cTipCtaCodigo As String = ""

                    '//Recorre Table3 si hay recibos seleccionado para Pago multiple
                    For Each row As DataGridViewRow In FormPrcFacturacion.Table3.Rows
                        If FormPrcFacturacion.Table3.Item("nCtaCtePedCodigo", row.Index).Value = 1 Then '//Check Marcado
                            ListRec.Add(FormPrcFacturacion.Table3.Item("cCtaCteRecibo", row.Index).Value, CDbl(FormPrcFacturacion.Table3.Item("nCtaCteLinImporte", row.Index).Value))
                            cTipCtaCodigo = FormPrcFacturacion.Table3.Item("nCtaCteTipoCta", row.Index).Value
                        End If
                    Next

                    If ListRec.Count = 0 Then
                        cTipCtaCodigo = FormPrcFacturacion.Table3.Item("nCtaCteTipoCta", FormPrcFacturacion.Table3.CurrentRow.Index).Value
                    End If

                    Resultado = daCCPago.Ins_RealizarPago(StrcPerJuridica, cPerCodigo, FormMDI.CboAnno.SelectedValue, cTipCtaCodigo, LblNroRecibo.Text, ListRec, StrUser, nCajCodigo, nCtaCteComCodigo, cCtaCteComNumero, FormatDateTime(dFechaSistema & Space(1) & TimeOfDay, DateFormat.GeneralDate), CDbl(FormPrcFacturacion.LblImpRecibo.Text), CDbl(LblTotalPago.Text), CDbl(FormPrcFacturacion.LblTCancel.Text), TxtStrDetalle.Text, List)

                    If Resultado Then
                        FormPrcFacturacion.LblTCancel.Tag = CDbl(LblTotalPago.Text) 'pasando el importe que esta cancelando
                        MessageBox.Show("Registro de Pago se realizo con exito.", "Grabando..", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        OperacionPago = 1
                        Close()
                        Dispose()
                    End If

                    scope.Complete()

                    '//descargando variables
                    ListRec.Clear()
                    StrPasaValores = vbNullString

                End Using

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Mensaje:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click

        Dim Rows As Integer

        If ValidarCamposForAddItemGrd() Then

            'Verificando si benefiaciario ya esta en la grilla
            If BuscaCadenaDgView("nCtaCteForPago", CboFormaPago.SelectedValue.ToString, Table2) Then 'And BuscaCadenaDgView("cPerjurCodigoFin", CboFormaPago.SelectedValue.ToString, Table2) Then
                MessageBox.Show("Medio de pago ya sido utilizado, no podra utilizar el mismo medio de pago para el pago.", "Validando..", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                REM si no existe, aqui insertas el fila
                With Table2
                    Rows = .RowCount()
                    .Rows.Add()
                    .Item("nCtaCteForPago", Rows).Value = CLng(CboFormaPago.SelectedValue)
                    .Item("cDescForPago", Rows).Value = CboFormaPago.Text '**Desc Tipo de Moneda
                    .Item("nPerCtaCodigo", Rows).Value = IIf(CboFormaPago.SelectedValue = nFomaPago.nTarjetaCred, CboTipoTarj.SelectedValue, CboNroCta_TarjetaDC.SelectedValue)
                    .Item("cPerjurCodigoFin", Rows).Value = CboBanco.SelectedValue
                    .Item("cEntidadBanca", Rows).Value = CboBanco.Text
                    .Item("dCtaCteFecTransacion", Rows).Value = IIf(CboFormaPago.SelectedValue = nFomaPago.nEfectivo, FormatDateTime(DtpFecPago.Value, DateFormat.GeneralDate), FormatDateTime(DtpFecDeposito.Value, DateFormat.GeneralDate))
                    .Item("cCtaCtePagTracer", Rows).Value = Trim(TxtVoucher.Text)
                    .Item("nMonCodigo", Rows).Value = CLng(CboMoneda.SelectedValue)
                    .Item("cDescMoneda", Rows).Value = CboMoneda.Text
                    .Item("nCtaCtePagImpMon", Rows).Value = CDbl(TxtImpPago.Text)
                    .Item("nTC", Rows).Value = IIf(CboMoneda.SelectedValue = nTipoMoneda.nSoles, 1, CDbl(LblTC.Text))
                    .Item("nCtaCtePagImporte", Rows).Value = IIf(CboMoneda.SelectedValue = nTipoMoneda.nSoles, CDbl(TxtImpPago.Text), CDbl(TxtImpPago.Text) * CDbl(LblTC.Text))
                End With

                REM limpio para seguir agregando mas
                InicilizarCampos()
                LblTotalPago.Text = Suma_Columna("nCtaCtePagImporte", Table2)

                'Cuanto le falta para completar el total del recibo

                TxtImpPago.Text = FormatNumber(CDbl(LblImpRecibo.Text) - Suma_Columna("nCtaCtePagImporte", Table2), True)
            End If
        End If

    End Sub

    Private Sub BtnQuitar_Click(sender As System.Object, e As System.EventArgs) Handles BtnQuitar.Click
        Call EliminaRowSeleccionada(Table2)
    End Sub

    Private Sub CboFormaPago_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles CboFormaPago.SelectionChangeCommitted

        Select Case CLng(CboFormaPago.SelectedValue)
            Case nFomaPago.nEfectivo
                CboBanco.SelectedValue = -1
                CboTipoTarj.SelectedValue = -1
                CboNroCta_TarjetaDC.SelectedValue = -1
                GrpBoxBco.Visible = False

            Case nFomaPago.nTarjetaCred

                Dim ReqBco As New BE_ReqBuscarEntidadFinanciera
                Dim daBco As New BL_CtaCteServicioFacturacion

                Label13.Text = "Entidad Financiera:"
                CboBanco.SelectedValue = -1
                ReqBco.cFlag = "EBS"
                LlenaDataCombo(CboBanco, daBco.Get_EntidadFinaciera_Tarjetas(ReqBco), "cPerCodigo", "cPerApellido")

                Label12.Text = "Tarjeta:"
                CboTipoTarj.Enabled = True
                LlenaDataCombo(CboTipoTarj, ObjInterface.Get_Interface(CLng(TokenByKey(CboTipoTarj.Tag, "nIntClase")), CLng(TokenByKey(CboTipoTarj.Tag, "nIntTipo")), "T"), "nIntCodigo", "cIntDescripcion")

                Label10.Text = "Tipo de Tarjeta:"
                Call CboTipoTarj_SelectionChangeCommitted(CboTipoTarj, Nothing)

                Label15.Text = "Nro. Tarjeta Credito:"
                GrpBoxBco.Visible = True

            Case nFomaPago.nDepositoBco

                Dim ReqBco As New BE_ReqBuscarEntidadFinanciera
                Dim daBco As New BL_CtaCteServicioFacturacion

                Label13.Text = "Banco Deposito:"
                CboBanco.SelectedValue = -1

                ReqBco.cFlag = "EBE"
                ReqBco.cPerJurCodigo = StrcPerJuridica '// CboBanco.SelectedValue

                LlenaDataCombo(CboBanco, daBco.Get_EntidadFinaciera_Tarjetas(ReqBco), "cPerCodigo", "cPerApellido")

                CboTipoTarj.Enabled = False : CboTipoTarj.SelectedValue = -1
                Label12.Text = ""

                Label10.Text = "Nro. Cuenta:"
                CboBanco_SelectionChangeCommitted(CboBanco, Nothing)
                Label15.Text = "Nro. Voucher:"

                GrpBoxBco.Visible = True
        End Select

    End Sub

    Private Sub CboTipoTarj_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles CboTipoTarj.SelectionChangeCommitted

        Dim ReqBco As New BE_ReqBuscarEntidadFinanciera
        Dim daBco As New BL_CtaCteServicioFacturacion

        CboNroCta_TarjetaDC.SelectedValue = -1
        CboNroCta_TarjetaDC.DataSource = Nothing
        ReqBco.cFlag = "TDC"
        ReqBco.cPerCodigo = CboBanco.SelectedValue.ToString
        ReqBco.nPerIntCodigo = CboTipoTarj.SelectedValue
        LlenaDataCombo(CboNroCta_TarjetaDC, daBco.Get_EntidadFinaciera_Tarjetas(ReqBco), "cPerCodigo", "cPerIntDescripcion")

    End Sub

    Private Sub CboBanco_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles CboBanco.SelectionChangeCommitted

        If CboFormaPago.SelectedValue = nFomaPago.nDepositoBco Then
            'MsgBox("pasndo por aqui")
            Dim ReqBco As New BE_ReqBuscarEntidadFinanciera
            Dim daBco As New BL_CtaCteServicioFacturacion

            CboNroCta_TarjetaDC.SelectedValue = -1
            CboNroCta_TarjetaDC.DataSource = Nothing
            ReqBco.cFlag = "MCB"
            ReqBco.cPerJurCodigo = StrcPerJuridica
            ReqBco.cPerCodigo = CboBanco.SelectedValue
            LlenaDataCombo(CboNroCta_TarjetaDC, daBco.Get_EntidadFinaciera_Tarjetas(ReqBco), "nPerCtaCodigo", "cNroCuentaOpera")
        End If

    End Sub

    Private Sub CboMoneda_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles CboMoneda.SelectionChangeCommitted

        LblTC.Text = TipoCambio(CboMoneda.SelectedValue, "TCD", dFechaSistema)

    End Sub

    Private Sub BtnPagoDet_Click(sender As System.Object, e As System.EventArgs) Handles BtnPagoDet.Click

        'StrPasaValores = vbNullString

        If TxtStrDetalle.Enabled Then
            BtnPagoDet.Text = " Más detalles (F8) »"
            TxtStrDetalle.Enabled = False
            TxtStrDetalle.Text = vbNullString
            Me.Height = 444
        Else
            BtnPagoDet.Text = " Quitar detalles (F8) «"
            Me.Height = 553
            TxtStrDetalle.Enabled = True
            TxtStrDetalle.Focus()

        End If

        'FormPrcFormaPagoDetalle.ShowDialog()

        'Using frmDetalle As New FormPrcFormaPagoDetalle()
        '    Dim drDetalle As DialogResult = frmDetalle.ShowDialog(Me)

        '    If (drDetalle = Windows.Forms.DialogResult.Cancel) Then
        '        'MessageBox.Show("Se ha cancelado el cuadro de diálogo.", "Forma Pago", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return
        '    End If

        'End Using

        'BtnRegPago.Focus()

    End Sub

    Private Sub TxtImpPago_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImpPago.KeyPress

        'e.Handled = Numero(e, TxtImpPago) ' TxtImpPago, caja de texto a validar

        e.Handled = TextBoxImporte(e, TxtImpPago)

    End Sub

End Class