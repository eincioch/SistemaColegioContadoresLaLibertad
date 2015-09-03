Option Explicit On
Imports Integration.DataIntegration
Imports Integration.BE
Imports Integration.BL

Public Class FormMaPersona

    Function ValidaCamposObligatorios() As Boolean

        ValidaCamposObligatorios = False
        If LblcPerCodigo.Text = vbNullString Then
            MsgInfoCampoObligatorio(Label1.Text, CboTipoPer)
            Exit Function
        ElseIf CboTipoPer.SelectedIndex = -1 Then
            MsgInfoCampoObligatorio(Label5.Text, CboTipoPer)
            Exit Function
        ElseIf CboTipoDocu.SelectedIndex = -1 Then
            MsgInfoCampoObligatorio(Label11.Text, CboTipoDocu)
            Exit Function
        ElseIf Trim(TxtNroDocu.Text) = vbNullString Then
            MsgInfoCampoObligatorio(LblNroDocu.Text, TxtNroDocu)
            Exit Function
        ElseIf CboTipoPer.SelectedValue = nConTipoPersona.nPerJuridica Then
            If CboTipoDocu.SelectedValue = nConTipoDocPerJuridica.nRUC Then
                If Not Valida_RUT(TxtNroDocu.Text) Then
                    MsgInfoCampoObligatorio("RUC no es valido, por favor de verificar.", TxtNroDocu)
                    Exit Function
                End If
            End If
        ElseIf Trim(TxtApePat.Text) = vbNullString Then
            MsgInfoCampoObligatorio(Label2.Text, TxtApePat)
            Exit Function
        ElseIf CboTipoPer.SelectedValue = nConTipoPersona.nPerNatural Then
            If TxtApeMat.Text = vbNullString Then
                MsgInfoCampoObligatorio(Label3.Text, TxtApeMat)
                Exit Function
            End If
        ElseIf Txt1Nombre.Text = vbNullString Then
            MsgInfoCampoObligatorio(Label6.Text, Txt1Nombre)
            Exit Function
        ElseIf CboNacionalidad.SelectedValue = -1 Then
            MsgInfoCampoObligatorio(Label12.Text, CboNacionalidad)
            Exit Function
        ElseIf CboSexoTEmp.SelectedIndex = -1 Then
            MsgInfoCampoObligatorio(Label13.Text, CboSexoTEmp)
            Exit Function
        ElseIf CboEstadoCivil.SelectedIndex = -1 Then
            MsgInfoCampoObligatorio(Label8.Text, CboEstadoCivil)
            Exit Function
        End If
        ValidaCamposObligatorios = True

    End Function

    Private Sub GeneraNewIdcPerCodigo()
        'Genera cPerCodigo nuevo "usp_Persona_Get_NewId"
        Dim Request As New Persona.BE_ReqPersona
        Dim ObjNewId As New BL_Persona

        Request.cPerCodigo = vbNullString
        If ObjNewId.Get_NewIdcPerCodigo(Request).Rows.Count > 0 Then
            LblcPerCodigo.Text = ObjNewId.Get_NewIdcPerCodigo(Request).Rows(0)("NewCodigo")
        End If
    End Sub

    Private Sub EstablecerFormPredeterminado(ByVal nTipoPersona As Integer)

        If nTipoPersona = nConTipoPersona.nPerNatural Then

            CboTipoPer.SelectedValue = nConTipoPersona.nPerNatural

            CboTratoPer.Enabled = True : TxtApePat.Enabled = True : TxtApeMat.Enabled = True : Txt2Nombre.Enabled = True : Txt3Nombre.Enabled = True
            Label4.Text = "Fecha Nacimiento:" : Label6.Text = "Primer nombre:" : Label13.Text = "Sexo:" : Label8.Text = "Estado civil:"

            LlenaDataCombo(CboTipoDocu, ObjConst.Get_Constante("C", CLng(nConPerNatural)), "nConValor", "cConDescripcion")
            LlenaDataCombo(CboSexoTEmp, ObjConst.Get_Constante("C", CLng(CboSexoTEmp.Tag)), "nConValor", "cConDescripcion")
            LlenaDataCombo(CboEstadoCivil, ObjConst.Get_Constante("C", CLng(CboEstadoCivil.Tag)), "nConValor", "cConDescripcion")

            CboTipoDocu.SelectedValue = nConTipoDocPerNatural.nDNI

        ElseIf nTipoPersona = nConTipoPersona.nPerJuridica Then

            CboTipoPer.SelectedValue = nConTipoPersona.nPerJuridica

            LlenaDataCombo(CboTipoDocu, ObjConst.Get_Constante("C", CLng(nConPerJuridica)), "nConValor", "cConDescripcion")

            CboTratoPer.Enabled = False : TxtApePat.Enabled = False : TxtApeMat.Enabled = False : Txt2Nombre.Enabled = False : Txt3Nombre.Enabled = False
            Label4.Text = "Fecha creación:" : Label6.Text = "Razon Social:" : Label13.Text = "Tipo Empresa:" : Label8.Text = "Sector Economico:"

            'RequestConst.nConCodigo = 1023 'Tipo de Empresa
            LlenaDataCombo(CboSexoTEmp, ObjConst.Get_Constante("C", CLng(1023)), "nConValor", "cConDescripcion")

            'RequestConst.nConCodigo = 1024 'Sector economico
            LlenaDataCombo(CboEstadoCivil, ObjConst.Get_Constante("C", CLng(1024)), "nConValor", "cConDescripcion")

        End If

        TxtNroDocu.Focus()

    End Sub

    Private Sub FormMaPersona_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Tipo de persona
        LlenaDataCombo(CboTipoPer, ObjConst.Get_Constante("C", CLng(CboTipoPer.Tag)), "nConValor", "cConDescripcion")

        'Trato de persona
        LlenaDataCombo(CboTratoPer, ObjConst.Get_Constante("C", CLng(CboTratoPer.Tag)), "nConValor", "cConDescripcion")

        'Nacionalidad
        LlenaDataCombo(CboNacionalidad, ObjInterface.Get_Interface(CLng(TokenByKey(CboNacionalidad.Tag, "nIntClase")), CLng(TokenByKey(CboNacionalidad.Tag, "nIntTipo")), "T"), "nIntCodigo", "cIntDescripcion")

        If nAccionBotones = nAccionButton.nAccionNuevo Then

            LimpiarTextBox(Me)
            'nuevo codigo
            GeneraNewIdcPerCodigo()

            If nFormPerPredeterminado = 0 Then
                EstablecerFormPredeterminado(1)
                CboTipoPer.Enabled = True
            Else
                EstablecerFormPredeterminado(nFormPerPredeterminado)
                CboTipoPer.Enabled = False
            End If

            CboNacionalidad.SelectedValue = 9256 'Default: Perú (9256)

        ElseIf nAccionBotones = nAccionButton.nAccionEdit Then

            EstablecerFormPredeterminado(nFormPerPredeterminado)
            'recuperando datos
            LblcPerCodigo.Text = TokenByKey(StrPasaValores, "cPercodigo")
            CboTipoPer.SelectedValue = TokenByKey(StrPasaValores, "nPerTipo")
            Call CboTipoPer_SelectionChangeCommitted(CboTipoPer, Nothing)
            CboTipoDocu.SelectedValue = TokenByKey(StrPasaValores, "nPerIdeTipo")
            TxtNroDocu.Text = TokenByKey(StrPasaValores, "cPerIdeNumero")
            CboTratoPer.SelectedValue = IIf(TokenByKey(StrPasaValores, "nPerTratamiento") <> 0, TokenByKey(StrPasaValores, "nPerTratamiento"), CboTratoPer.SelectedValue = 1)
            TxtApePat.Text = TokenByKey(StrPasaValores, "cPerApellPaterno")
            TxtApeMat.Text = TokenByKey(StrPasaValores, "cPerApellMaterno")
            Txt1Nombre.Text = IIf(TokenByKey(StrPasaValores, "cPerPriNombre") <> vbNullString, TokenByKey(StrPasaValores, "cPerPriNombre"), TokenByKey(StrPasaValores, "cpernombre"))
            Txt2Nombre.Text = TokenByKey(StrPasaValores, "cPerSegNombre")
            Txt3Nombre.Text = TokenByKey(StrPasaValores, "cPerTerNombre")
            DtpFecNacCrea.Value = CDate(TokenByKey(StrPasaValores, "dPerNacimiento"))
            CboSexoTEmp.SelectedValue = IIf(TokenByKey(StrPasaValores, "nPerNatSexo") <> 0, Val(TokenByKey(StrPasaValores, "nPerNatSexo")), TokenByKey(StrPasaValores, "nPerJurTipInversion"))
            CboEstadoCivil.SelectedValue = IIf(TokenByKey(StrPasaValores, "nPerNatEstCivil") <> 0, TokenByKey(StrPasaValores, "nPerNatEstCivil"), TokenByKey(StrPasaValores, "nPerJurSecEconomico"))
            LblUbigeo.Text = TokenByKey(StrPasaValores, "cUbiGeoCodigo")
            CboNacionalidad.SelectedValue = TokenByKey(StrPasaValores, "nIntCodigo")

            CboTipoPer.Enabled = False

        End If

    End Sub

    Private Sub BtnSelectUbigeo_Click(sender As System.Object, e As System.EventArgs) Handles BtnSelectUbigeo.Click
        FormUbigeo.ShowDialog()
    End Sub

    Private Sub CboTipoPer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboTipoPer.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub LblUbigeo_TextChanged(sender As Object, e As System.EventArgs) Handles LblUbigeo.TextChanged

        Dim Request As New Sistema.BE_ReqUbigeo
        Dim ObjUbigeo As New BL_Sistema

        Request.Codigo = LblUbigeo.Text
        LblDetalleUbigeo.Text = ObjUbigeo.Get_Ubigeo(Request)
    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click

        Try
            Dim Request As New Persona.BE_ReqPersona
            Dim ObjPer As New BL_Persona

            Dim StrSQl As String = ""
            Dim Resultado As Boolean

            If ValidaCamposObligatorios() Then

                Request.cPerCodigo = LblcPerCodigo.Text
                Request.nPerIdeTipo = CboTipoDocu.SelectedValue
                Request.cPerIdeNumero = Trim(TxtNroDocu.Text)
                Request.cPerApellPaterno = Replace(TxtApePat.Text, "'", "{")
                Request.cPerApellMaterno = Replace(TxtApeMat.Text, "'", "{")
                Request.cPerPriNombre = Replace(Txt1Nombre.Text, "'", "{")
                Request.cPerSegNombre = Replace(Txt2Nombre.Text, "'", "{")
                Request.cPerTerNombre = Replace(Txt3Nombre.Text, "'", "{")
                Request.dPerNacimiento = FormatDateTime(DtpFecNacCrea.Value, DateFormat.ShortDate)
                Request.nPerTipo = CboTipoPer.SelectedValue
                Request.cUbiGeoCodigo = Trim(LblUbigeo.Text)
                Request.nPerTratamiento = CboTratoPer.SelectedValue
                Request.nPerNatSexo = CboSexoTEmp.SelectedValue
                Request.nPerNatEstCivil = CboEstadoCivil.SelectedValue
                Request.nPerNatTipResidencia = 0 'Tipo de residencia?
                Request.nPerNatSitLaboral = 0 'Situacion laboral?
                Request.nPerNatOcupacion = 0 'Ocupacion?
                Request.nPerNatCondicion = 0 'condicion?
                Request.cPerJurRepCodigo = vbNullString 'representante legal de la empresa
                Request.nPerJurTipInversion = CboSexoTEmp.SelectedValue
                Request.nPerJurSecEconomico = CboEstadoCivil.SelectedValue
                Request.nCarCodigo = CboNacionalidad.SelectedValue
                Request.cCarValor = CboNacionalidad.Text
                Request.dFecha = FormatDateTime(dFechaSistema & Space(1) & TimeOfDay, DateFormat.GeneralDate)

                If MsgGrabar() = System.Windows.Forms.DialogResult.Yes Then

                    If nAccionBotones = nAccionButton.nAccionNuevo Then
                        Resultado = ObjPer.Ins_Persona(Request)
                    ElseIf nAccionBotones = nAccionButton.nAccionEdit Then
                        Resultado = ObjPer.Upd_Persona(Request)
                    End If

                    If Resultado Then
                        StrPasaValores = vbNullString 'seteo la variable
                        StrPasaValores = "cPerCodigo=" & LblcPerCodigo.Text & ";"
                        StrPasaValores = StrPasaValores & "cPerIdeNumero=" & TxtNroDocu.Text & ";"
                        StrPasaValores = StrPasaValores & "cNombCompleto=" & TxtApePat.Text & " " & TxtApeMat.Text & ", " & Txt1Nombre.Text & " " & Txt2Nombre.Text & " " & Txt3Nombre.Text & ";"
                        StrPasaValores = StrPasaValores & "nPerJurTipInversion=" & CboSexoTEmp.SelectedValue & ";"
                        StrPasaValores = StrPasaValores & "nPerJurSecEconomico=" & CboEstadoCivil.SelectedValue

                        MessageBox.Show("Operacion se realizo con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        If MessageBox.Show("¿Desea agregar mas información de la persona.?", "Mas..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Me.Width = 578
                            BtnGrabar.Visible = False
                            GrpBoxDatos.Enabled = False
                        Else
                            Call BtnCancel_Click(BtnCancel, Nothing)
                            BtnGrabar.Visible = True
                            GrpBoxDatos.Enabled = True
                        End If
                        'Else
                        'MessageBox.Show("!Se encontraron errores..!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CboTipoDocu_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboTipoDocu.KeyPress, CboTratoPer.KeyPress, CboSexoTEmp.KeyPress, CboEstadoCivil.KeyPress, CboNacionalidad.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub TxtNroDocu_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocu.KeyPress, TxtApePat.KeyPress, TxtApeMat.KeyPress, Txt1Nombre.KeyPress, Txt2Nombre.KeyPress, Txt3Nombre.KeyPress

        Dim StrResultado As String

        Dim ReqIdentifica As New Persona.BE_ReqPerIdentifica
        Dim ObjIdentifica As New BL_Persona

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then SendKeys.Send("{Tab}")
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            '------------------
            'Verifica si existe
            '------------------
            ReqIdentifica.nPerIdeTipo = CboTipoDocu.SelectedValue
            ReqIdentifica.cPerIdeNumero = Trim(TxtNroDocu.Text)

            If ObjIdentifica.Get_ExistePerIdentifica(ReqIdentifica) <> 0 Then
                MessageBox.Show("Numero de Documento Identidad ya se encuentra registrada.", "Validando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtnGrabar.Enabled = False
                Exit Sub
            Else
                BtnGrabar.Enabled = True
            End If
            '
            LblEstadoSUNAT.Visible = False : LblEstadoSUNAT.Text = vbNullString
            If CboTipoPer.SelectedValue = nConTipoPersona.nPerJuridica And CboTipoDocu.SelectedValue = nConTipoDocPerJuridica.nRUC Then
                StrResultado = FindRUCPageSUNAT(Trim(TxtNroDocu.Text))
                If TokenByKey(StrResultado, "RazonSocial") = vbNullString Then Exit Sub
                Txt1Nombre.Text = TokenByKey(StrResultado, "RazonSocial")
                LblEstadoSUNAT.Visible = True : LblEstadoSUNAT.Text = TokenByKey(StrResultado, "Estado")
            End If

        End If

    End Sub

    Private Sub DtpFecNacCrea_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DtpFecNacCrea.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub BtnDireccion_Click(sender As System.Object, e As System.EventArgs) Handles BtnDireccion.Click
        nOperacion = BtnDireccion.Tag
        FormMaPerMasDetalle.ShowDialog()
    End Sub

    Private Sub BtnFono_Click(sender As System.Object, e As System.EventArgs) Handles BtnFono.Click
        nOperacion = BtnFono.Tag
        FormMaPerMasDetalle.ShowDialog()
    End Sub

    Private Sub BtnEmail_Click(sender As System.Object, e As System.EventArgs) Handles BtnEmail.Click
        nOperacion = BtnEmail.Tag
        FormMaPerMasDetalle.ShowDialog()
    End Sub

    Private Sub CboTipoPer_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles CboTipoPer.SelectionChangeCommitted

        If CboTipoPer.SelectedValue = nConTipoPersona.nPerNatural Then
            EstablecerFormPredeterminado(nConTipoPersona.nPerNatural)
        ElseIf CboTipoPer.SelectedValue = nConTipoPersona.nPerJuridica Then
            EstablecerFormPredeterminado(nConTipoPersona.nPerJuridica)
        End If
    End Sub

    Private Sub BtnTipoDocu_Click(sender As System.Object, e As System.EventArgs) Handles BtnTipoDocu.Click
        nOperacion = BtnTipoDocu.Tag
        FormMaPerMasDetalle.ShowDialog()
    End Sub

    Private Sub BtnFoto_Click(sender As System.Object, e As System.EventArgs) Handles BtnFoto.Click
        nOperacion = BtnFoto.Tag
        FormMaPerMasDetalle.ShowDialog()
    End Sub

    Private Sub Txt1Nombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt1Nombre.TextChanged
        If CboTipoPer.SelectedValue = nConTipoPersona.nPerJuridica Then
            TxtApePat.Text = Txt1Nombre.Text
        End If

    End Sub

    Private Sub BtnJoby_Click(sender As System.Object, e As System.EventArgs) Handles BtnJoby.Click
        nOperacion = BtnJoby.Tag
        FormMaPerMasDetalle.ShowDialog()
    End Sub

    Private Sub CboTipoDocu_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboTipoDocu.SelectedIndexChanged
        If CboTipoDocu.SelectedValue = nConTipoDocPerNatural.nDNI Then TxtNroDocu.MaxLength = 8
        If CboTipoDocu.SelectedValue = nConTipoDocPerJuridica.nRUC Then TxtNroDocu.MaxLength = 11
    End Sub

End Class