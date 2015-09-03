﻿Option Explicit On
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Imports Integration.BE
Imports Integration.BL

Imports System.IO
Imports Integration.DataIntegration

Public Class FormMaPerMasDetalle

    Dim ObjADO As New Integration.DataIntegration.ClsADONET
    Dim ObjImage As New Integration.DataIntegration.ImageClass

    Private Sub FormatDataGridView()

        With Table5
            .AutoGenerateColumns = False
            .Columns.Clear()

            Dim ColumnaCodigoProducto As New DataGridViewTextBoxColumn()
            With ColumnaCodigoProducto
                .DataPropertyName = "cPerCodigo"
                .HeaderText = "Codigo"
                .ReadOnly = True : .Visible = False
                .Width = 0
            End With
            .Columns.Add(ColumnaCodigoProducto)

            Dim ColumnaDescripcionProducto As New DataGridViewTextBoxColumn()
            With ColumnaDescripcionProducto
                .DataPropertyName = "nPerTipImagen"
                .HeaderText = "Tipo Imagen"
                .ReadOnly = True : .Visible = False
                .Width = 400
            End With
            .Columns.Add(ColumnaDescripcionProducto)

            Dim ColumnaPrecioProducto As New DataGridViewTextBoxColumn()
            With ColumnaPrecioProducto
                .DataPropertyName = "dPerImaFecRegistro"
                .HeaderText = "Fecha Efectiva"
                .ReadOnly = True : .Visible = True
                .Width = 200
            End With
            .Columns.Add(ColumnaPrecioProducto)

            Dim ColumnaImagen As New DataGridViewImageColumn()
            With ColumnaImagen
                .DataPropertyName = "iPerImaFoto"
                .HeaderText = "Foto(s)"
                .ImageLayout = DataGridViewImageCellLayout.Zoom
                .ReadOnly = True : .Visible = True
                .Width = 150
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            .Columns.Add(ColumnaImagen)
        End With

    End Sub

    Function ValidarCampos() As Boolean

        ValidarCampos = False
        Select Case nOperacion
            Case 1
                If CboTVia.SelectedValue = -1 Then
                    MsgInfoCampoObligatorio(Label1.Text, CboTVia)
                    Exit Function
                ElseIf TxtDir.Text = vbNullString Then
                    MsgInfoCampoObligatorio("Direccion", TxtDir)
                    Exit Function
                ElseIf CboTDpto.SelectedValue = -1 Then
                    MsgInfoCampoObligatorio(Label2.Text, CboTDpto)
                    Exit Function
                ElseIf CboUrb.SelectedValue = -1 Then
                    MsgInfoCampoObligatorio(Label5.Text, CboUrb)
                    Exit Function
                ElseIf CboEtapaS.SelectedValue = -1 Then
                    MsgInfoCampoObligatorio(Label3.Text, CboEtapaS)
                    Exit Function
                ElseIf CboStatusDom.SelectedValue = -1 Then
                    MsgInfoCampoObligatorio(Label4.Text, CboStatusDom)
                    Exit Function
                End If
            Case 2
                If TxtNroFono.Text = vbNullString Then
                    MsgInfoCampoObligatorio("Numero telefono", TxtNroFono)
                    Exit Function
                ElseIf CboStatusFono.SelectedValue = -1 Then
                    MsgInfoCampoObligatorio("Tipo de telefono", CboStatusFono)
                    Exit Function
                End If
            Case 3
                If TxtEmail.Text = vbNullString Then
                    MsgInfoCampoObligatorio("Email", TxtEmail)
                    Exit Function
                ElseIf IsValidEmail(TxtEmail.Text) Then
                    MsgInfoCampoObligatorio("direccion E-mail puede ser no correcta.", TxtEmail)
                    Exit Function
                End If
            Case 4
                If TxtNroDocu.Text = vbNullString Then
                    MsgInfoCampoObligatorio("Nro. documento", TxtNroDocu)
                    Exit Function
                ElseIf CboTipoDocu.SelectedValue = -1 Then
                    MsgInfoCampoObligatorio("Tipo de documento", CboTipoDocu)
                    Exit Function
                End If
        End Select
        ValidarCampos = True

    End Function

    Private Sub FormMaPerDomicilio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim ObjPersona As New BL_Persona

        If nOperacion = 1 Then 'Direccion
            'Dim RequestHouse As New Persona.BE_ReqPerDomicilio

            LlenaDataCombo(CboTVia, ObjConst.Get_Constante("C", CLng(CboTVia.Tag)), "nConValor", "cConDescripcion")
            LlenaDataCombo(CboTDpto, ObjConst.Get_Constante("C", CLng(CboTDpto.Tag)), "nConValor", "cConDescripcion")
            LlenaDataCombo(CboUrb, ObjConst.Get_Constante("C", CLng(CboUrb.Tag)), "nConValor", "cConDescripcion")
            LlenaDataCombo(CboEtapaS, ObjConst.Get_Constante("C", CLng(CboEtapaS.Tag)), "nConValor", "cConDescripcion")
            LlenaDataCombo(CboStatusDom, ObjConst.Get_Constante("C", CLng(CboStatusDom.Tag)), "nConValor", "cConDescripcion")

            FormatGrilla(Table1, Me, False, 20)
            Table1.DataSource = Consulta_Reader("Exec usp_Get_PerDomicilio @cPerCodigo='" & FormMaPersona.LblcPerCodigo.Text & "'")
            GrpBoxAdress.Visible = True : GrpBoxFono.Visible = False : GrpBoxMail.Visible = False : GrpBoxTipoDocu.Visible = False : GrpBoxFoto.Visible = False : GrpBoxHobbie.Visible = False : BtnAceptar.Visible = True

        ElseIf nOperacion = 2 Then 'Telefonos
            'Dim RequestFono As New Persona.BE_ReqPerTelefono

            LlenaDataCombo(CboTFono, ObjConst.Get_Constante("C", CLng(CboTFono.Tag)), "nConValor", "cConDescripcion")
            LlenaDataCombo(CboStatusFono, ObjConst.Get_Constante("C", CLng(CboStatusFono.Tag)), "nConValor", "cConDescripcion")

            FormatGrilla(Table2, Me, False, 20)
            Table2.DataSource = Consulta_Reader("Exec usp_Get_PerTelefono @cPerCodigo='" & FormMaPersona.LblcPerCodigo.Text & "'")

            GrpBoxFono.Visible = True : GrpBoxAdress.Visible = False : GrpBoxMail.Visible = False : GrpBoxTipoDocu.Visible = False : GrpBoxFoto.Visible = False : GrpBoxHobbie.Visible = False : BtnAceptar.Visible = True
            GrpBoxFono.Location = New Point(9, GrpBoxFono.Location.Y)
            GrpBoxFono.Location = New Point(GrpBoxFono.Location.X, 6)

        ElseIf nOperacion = 3 Then 'E-mail
            'Dim RequestMail As New Persona.BE_ReqPerMail

            LlenaDataCombo(CboStatusEmail, ObjConst.Get_Constante("C", CLng(CboStatusEmail.Tag)), "nConValor", "cConDescripcion")

            FormatGrilla(Table3, Me, False, 20)
            Table3.DataSource = Consulta_Reader("Exec usp_Get_PerMail @cPerCodigo='" & FormMaPersona.LblcPerCodigo.Text & "'")

            GrpBoxMail.Visible = True : GrpBoxAdress.Visible = False : GrpBoxFono.Visible = False : GrpBoxTipoDocu.Visible = False : GrpBoxFoto.Visible = False : GrpBoxHobbie.Visible = False : BtnAceptar.Visible = True
            GrpBoxMail.Location = New Point(9, GrpBoxMail.Location.Y)
            GrpBoxMail.Location = New Point(GrpBoxMail.Location.X, 6)

        ElseIf nOperacion = 4 Then 'Tipo de documentos
            'Dim RequesIde As New Persona.BE_ReqPerIdentifica

            If FormMaPersona.CboTipoPer.SelectedValue = nConTipoPersona.nPerNatural Then
                LlenaDataCombo(CboTipoDocu, ObjConst.Get_Constante("C", CLng(nConPerJuridica)), "nConValor", "cConDescripcion")

            ElseIf FormMaPersona.CboTipoPer.SelectedValue = nConTipoPersona.nPerJuridica Then
                LlenaDataCombo(CboTipoDocu, ObjConst.Get_Constante("C", CLng(nConPerNatural)), "nConValor", "cConDescripcion")

            End If
            FormatGrilla(Table4, Me, False, 20)
            Table4.DataSource = Consulta_Reader("Exec usp_Get_PerIdentifica @cPerCodigo='" & FormMaPersona.LblcPerCodigo.Text & "'")

            GrpBoxTipoDocu.Visible = True : GrpBoxAdress.Visible = False : GrpBoxFono.Visible = False : GrpBoxMail.Visible = False : GrpBoxFoto.Visible = False : GrpBoxHobbie.Visible = False : BtnAceptar.Visible = True
            GrpBoxTipoDocu.Location = New Point(9, GrpBoxTipoDocu.Location.Y)
            GrpBoxTipoDocu.Location = New Point(GrpBoxTipoDocu.Location.X, 6)

        ElseIf nOperacion = 5 Then 'Foto

            FormatDataGridView()
            FormatGrilla(Table5, Me, False, 20)
            'Recuperar Photos en Grilla
            RequestImg.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
            Table5.DataSource = ObjImg.Get_PerImagen(RequestImg)

            GrpBoxFoto.Visible = True : GrpBoxTipoDocu.Visible = False : GrpBoxAdress.Visible = False : GrpBoxFono.Visible = False : GrpBoxMail.Visible = False : GrpBoxHobbie.Visible = False : BtnAceptar.Visible = False
            GrpBoxFoto.Location = New Point(9, GrpBoxFoto.Location.Y)
            GrpBoxFoto.Location = New Point(GrpBoxFoto.Location.X, 6)

        ElseIf nOperacion = 6 Then 'Hobbies
            Dim RequesHobbie As New Persona.BE_ReqPerIdioma

            LlenaDataCombo(CboHobbie, ObjConst.Get_Constante("C", CLng(CboHobbie.Tag)), "nConValor", "cConDescripcion")
            LlenaDataCombo(CboHabilidad, ObjConst.Get_Constante("C", CLng(CboHabilidad.Tag)), "nConValor", "cConDescripcion")

            FormatGrilla(Table6, Me, False, 20)

            'Llena DataGridView Hobbie
            RequesHobbie.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
            Table6.DataSource = ObjPersona.Get_PerIdioma(RequesHobbie)

            GrpBoxHobbie.Visible = True : GrpBoxTipoDocu.Visible = False : GrpBoxAdress.Visible = False : GrpBoxFono.Visible = False : GrpBoxMail.Visible = False : GrpBoxFoto.Visible = False : BtnAceptar.Visible = True
            GrpBoxHobbie.Location = New Point(9, GrpBoxHobbie.Location.Y)
            GrpBoxHobbie.Location = New Point(GrpBoxHobbie.Location.X, 6)

        End If

    End Sub

    Private Sub Table5_CellMouseClick(ByVal sender As Object, ByVal e As  _
                System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Table5.CellMouseClick

        If Table5.RowCount > 0 Then
            PictureBox1.BackgroundImage = ObtenerPhoto(Table5.CurrentRow.Cells(3).Value)
            GrpBoxFoto.SendToBack()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        nOperacion = 0
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BtnSelectUbigeo_Click(sender As System.Object, e As System.EventArgs) Handles BtnSelectUbigeo.Click
        FormUbigeo.ShowDialog()
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click

        Try
            Dim RequestHouse As New Persona.BE_ReqPerDomicilio
            Dim RequestFono As New Persona.BE_ReqPerTelefono
            Dim RequestMail As New Persona.BE_ReqPerMail
            Dim RequesIde As New Persona.BE_ReqPerIdentifica
            Dim RequesHobbie As New Persona.BE_ReqPerIdioma

            Dim ObjPersona As New BL_Persona

            Dim StrSQl As String = ""

            Dim Response As New BE_ResGenerico
            Dim Resultado As Long

            If ValidarCampos() Then
                If nOperacion = 1 Then 'direccion
                    RequestHouse.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
                    RequestHouse.nPerDomTipo = CboTVia.SelectedValue
                    RequestHouse.cPerDomDireccion = TxtDir.Text
                    RequestHouse.cPerDomNumero = TxtNro.Text
                    RequestHouse.cPerDomManzana = TxtMz.Text
                    RequestHouse.cPerDomLote = TxtLt.Text
                    RequestHouse.nPerDomSubTipo = CboTDpto.SelectedValue
                    RequestHouse.cPerDomSubTipoNumero = TxtDptoPiso.Text
                    RequestHouse.nPerDomResTipo = CboUrb.SelectedValue
                    RequestHouse.cPerDomResNombre = TxtUrba.Text
                    RequestHouse.nPerDomSecTipo = CboEtapaS.SelectedValue
                    RequestHouse.cPerDomSecNombre = TxtEtapaS.Text
                    RequestHouse.cUbiGeoCodigo = LblUbigeo.Text
                    RequestHouse.nPerDomStatus = CboStatusDom.SelectedValue

                ElseIf nOperacion = 2 Then ' fono
                    RequestFono.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
                    RequestFono.nPerTelTipo = CboTFono.SelectedValue
                    RequestFono.cPerTelNumero = TxtNroFono.Text
                    RequestFono.nPerTelStatus = CboStatusFono.SelectedValue

                ElseIf nOperacion = 3 Then ' Email
                    RequestMail.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
                    RequestMail.nPerMaiTipo = CboStatusEmail.SelectedValue
                    RequestMail.cPerMaiNombre = TxtEmail.Text

                ElseIf nOperacion = 4 Then 'Docu
                    RequesIde.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
                    RequesIde.nPerIdeTipo = CboTipoDocu.SelectedValue
                    RequesIde.cPerIdeNumero = TxtNroDocu.Text

                ElseIf nOperacion = 6 Then 'Hobbie
                    RequesHobbie.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
                    RequesHobbie.nIdioma = CboHobbie.SelectedValue
                    RequesHobbie.nIdiHabilidad = 0
                    RequesHobbie.nNivel = CboHabilidad.SelectedValue
                End If

                Select Case nOperacion
                    Case 1 'direccion
                        Response = ObjPersona.InsPerDomicilio(RequestHouse)
                    Case 2 'fono
                        Response = ObjPersona.InsPerTelefono(RequestFono)
                    Case 3 'mail
                        Response = ObjPersona.InsPerMail(RequestMail)
                    Case 4 'docu
                        Response = ObjPersona.InsPerIdentifica(RequesIde)
                    Case 6 'Hobbie
                        Response = ObjPersona.InsPerIdioma(RequesHobbie)
                End Select
                Resultado = Response.Resultado

                If Resultado <> 0 Then
                    MessageBox.Show("Operacion se realizo con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call BtnCancel_Click(BtnCancel, Nothing)
                    'Else
                    '    MessageBox.Show("!Se encontraron errores..!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub LblUbigeo_TextChanged(sender As Object, e As System.EventArgs) Handles LblUbigeo.TextChanged

        Dim Request As New Sistema.BE_ReqUbigeo
        Dim ObjUbigeo As New BL_Sistema

        Request.Codigo = LblUbigeo.Text
        LblDetalleUbigeo.Text = ObjUbigeo.Get_Ubigeo(Request)

    End Sub

    Private Sub BtnSubirFoto_Click(sender As System.Object, e As System.EventArgs) Handles BtnSubirFoto.Click

        Dim Response As New BE_ResGenerico
        Dim Resultado As Long

        Using OpenFileDialog1 As New OpenFileDialog()

            With OpenFileDialog1
                .CheckFileExists = True
                .ShowReadOnly = False
                .Title = "Buscando archivo - Foto"
                .Filter = "All Files|*.*|Tipos archivos (*)|*.bmp;*.gif;*.jpg;*.png"
                .FilterIndex = 2

                If .ShowDialog = DialogResult.OK Then
                    ' Mostramos la imagen en el control PictureBox
                    If CDbl(GetTamFile(.FileName)) > 55 Then
                        MessageBox.Show("Tamaño de archivo es demasiado grande, el tamaño maximo es 55 Kbytes.", "Validando..", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    PictureBox1.BackgroundImage = Image.FromFile(.FileName)
                    'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                    Dim ms As New MemoryStream()
                    PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
                    FieldFoto = ms.GetBuffer()

                    'Resultado = ObjImage.Upd_InsertPerImagen(FormMaPersona.LblcPerCodigo.Text, 1, FieldFoto)
                    RequestImg.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
                    RequestImg.nPerTipImagen = 1
                    RequestImg.iPerImaFoto = FieldFoto
                    Response = ObjImg.InsPerImagen(RequestImg)

                    Resultado = Response.Resultado

                    If Resultado <> 0 Then
                        MessageBox.Show("Operacion se realizo con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Table5.DataSource = consulta_reader("Exec usp_SelectPerImagen @cPerCodigo='" & FormMaPersona.LblcPerCodigo.Text & "'")
                        RequestImg.cPerCodigo = FormMaPersona.LblcPerCodigo.Text
                        Table5.DataSource = ObjImg.Get_PerImagen(RequestImg)
                        'Call BtnCancel_Click(BtnCancel, Nothing)
                    Else
                        MessageBox.Show("!Se encontraron errores..!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If

            End With

        End Using

    End Sub

    Private Sub TxtNroDocu_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocu.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If CboTipoDocu.SelectedValue = nConTipoDocPerJuridica.nRUC Then

                LblPerJuridica.Text = TokenByKey(FindRUCPageSUNAT(TxtNroDocu.Text), "RazonSocial")
                If Not Valida_RUT(TxtNroDocu.Text) Then Exit Sub
            End If
        End If
    End Sub

End Class