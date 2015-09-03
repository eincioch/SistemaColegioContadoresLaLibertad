Option Explicit On

Imports Integration.DataIntegration
Imports Integration.BE
Imports Integration.BL
'Imports Integration.DAService
'Imports Microsoft.VisualBasic

Public Class FormAcceso

    Dim ObjEncrypt As New Integration.Conection.clsCrypt

    Dim Request As New BE.Sistema.BE_ReqFechaServidor
    Dim ObjBL As New BL_Sistema

    Dim RequestPer As New BE.PerUsuario.BE_ReqSearhUsuario
    Dim ObjBLPer As New BL_PerUsuario

    'Dim StrUser As String
    Dim SrtPass As String

    Private Function validar() As Boolean

        validar = False

        'If Not ValidatePassword(Txt_NewPass.Text) Then
        '    MessageBox.Show("Campo <Nueva contraseña> No cumple la complejidad  de contraseñas..! " & Chr(13) &
        '           "Debe tener 8 caracteres como minimo y contener la siguiente complejidad: " & Chr(13) &
        '           "2 Mayusculas, 2 minusculas, 2 Numeros y 2 caracteres especiales (%$&@>#).", "Validando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Txt_NewPass.Focus()
        '    Exit Function
        'End If
        'If Not ValidatePassword(Txt_RNewPass.Text) Then
        '    MessageBox.Show("Campo <Repetir nueva contraseña> No cumple la complejidad  de contraseñas..! " & Chr(13) &
        '           "Debe tener 8 caracteres como minimo y contener la siguiente complejidad: " & Chr(13) &
        '           "2 Mayusculas, 2 minusculas, 2 Numeros y 2 caracteres especiales (%$&@>#).", "Validando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Txt_RNewPass.Focus()
        '    Exit Function
        'End If
        If Trim(Txt_NewPass.Text) <> Trim(Txt_RNewPass.Text) Then
            MsgBox("Contraseña no es igual cuando repite la contraseña, vuelva a ingresar ambas contraseñas por favor..!", vbExclamation, "Validando")
            Txt_NewPass.Text = "" : Txt_RNewPass.Text = ""
            Txt_NewPass.Focus()
            Exit Function
        End If
        'If Not Len(Trim(Txt_NewPass.Text)) > 7 Or Not Len(Trim(Txt_RNewPass.Text)) > 7 Then
        '    MsgBox("La contraseña debe contener como minimo 8 caracteres," & Chr(13) & "y un maximo de 15 caracteres." & Chr(13) & "Vuelva a ingresar su nueva contraseña, por favor..!", vbExclamation, "Validando")
        '    Txt_NewPass.Text = "" : Txt_RNewPass.Text = ""
        '    Txt_NewPass.Focus()
        '    Exit Function
        'End If
        validar = True

    End Function

    Private Sub FormAcceso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'lleno los ComboBox
        Request.dFechaServer = vbNullString
        LlenaDataCombo(CboEmpresa, ObjBL.Get_SysEmpresa(Request), "cPerCodigo", "cPerNombre")
        RequestPer.PerCodigo = vbNullString
        LlenaDataCombo(Cbo_User, ObjBLPer.Get_CboListUsuario(RequestPer), "cPerCodigo", "cPerUsuCodigo")

    End Sub

    Private Sub BtnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrar.Click
        End
    End Sub

    Private Sub BtnAccesar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAccesar.Click

        If Cbo_User.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione usuario de la lista..!!", "Validando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cbo_User.Focus()
        Else
            StrUser = UCase(Trim(Cbo_User.Text))
            SrtPass = ObjEncrypt.EncryptByCode(StrUser, Txt_Pass.Text)

            RequestPer.PerCodigo = StrUser
            RequestPer.cPerUsuClave = SrtPass

            If ObjBLPer.Get_SearhUsuario(RequestPer).Rows.Count > 0 Then
                REM Obteniendo fecha del servidor
                Request.dFechaServer = ""
                dFechaSistema = ObjBL.Get_FechaServidor(Request)

                'cPerJuridica.- Empresa a nivel de todo el sistema
                StrcPerJuridica = CboEmpresa.SelectedValue

                'Ruta de repotes
                cPathRPT = ObtenerParametroAppConfig("RutaRpt")
                cNroCaja = ObtenerParametroAppConfig("NroCaja")

                FormMDI.Show()
                FormMDI.SSServer.Text = " SRV-CCPLL "
                FormMDI.SSNameDB.Text = " BDIntegration "
                FormMDI.SSUser.Text = Trim(Cbo_User.Text)
                FormMDI.SSReport.Text = cPathRPT
                FormMDI.SSNroCaja.Text = "Caja Nro.: " & Microsoft.VisualBasic.Right("00" & cNroCaja, 2)
                FormMDI.SSfecha.Text = UCase(Format(dFechaSistema, "Long Date"))
                FormMDI.SSVersion.Text = FormMDI.SSVersion.Text & Space(1) & Status_Version()
                Me.Hide()
            Else
                MsgBox("Usted No tiene permiso para acceder al Sistema..!!", vbExclamation, "Denegado...")
                Txt_Pass.Text = ""
                Txt_Pass.Focus()
            End If
        End If

    End Sub

    Private Sub LnkLbl_ChangePass_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkLbl_ChangePass.LinkClicked
        GroupBox4.Visible = True
        Txt_PassActual.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        GroupBox4.Visible = False
        Txt_Pass.Focus()
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click

        Dim Request As New BE.PerUsuario.BE_ReqSearhUsuario
        Dim ObjBL As New BL_Sistema
        Dim Response As New BE_ResGenerico

        Dim Resultado As Long

        StrUser = UCase(Trim(Cbo_User.Text))
        SrtPass = ObjEncrypt.EncryptByCode(StrUser, Txt_PassActual.Text)

        RequestPer.PerCodigo = StrUser
        RequestPer.cPerUsuClave = SrtPass

        If ObjBLPer.Get_SearhUsuario(RequestPer).Rows.Count > 0 Then
            If validar() Then

                RequestPer.PerCodigo = StrUser
                RequestPer.cPerUsuClave = ObjEncrypt.EncryptByCode(StrUser, Txt_NewPass.Text)

                Response = ObjBLPer.UpdChangePassword(RequestPer)
                Resultado = Response.Resultado

                If Resultado <> 0 Then
                    MessageBox.Show("Se ha cambiado la contraseña.", "Cambio contraseña..", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call BtnCancel_Click(BtnCancel, Nothing)
                Else
                    MessageBox.Show("!Se encontraron errores..!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Else
            MessageBox.Show("Contraseña actual no es la correcta, vuelva a ingresar la contrasela actual..!!", "Validando..", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Txt_PassActual.Text = "" : Txt_PassActual.Focus()
        End If

    End Sub

End Class