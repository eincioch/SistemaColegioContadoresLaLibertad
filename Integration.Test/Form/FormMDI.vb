Option Explicit On

Public Class FormMDI

    Private Sub TSMnuItemConstante_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemConstante.Click
        llamarform(FormConstante, Me)
    End Sub

    Private Sub TSMnuItemCerrar_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemCerrar.Click
        Me.Close()
        Me.Dispose()
        End
    End Sub

    Private Sub TSMnuItemPersona_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemPersona.Click
        llamarform(FormGridPersona, Me)
    End Sub

    Private Sub TSMnuItemRegColegiado_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemRegColegiado.Click
        llamarform(FormPrcAdmision, Me)
    End Sub

    Private Sub TSMnuItemEstabEmpresa_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemEstabEmpresa.Click
        llamarform(FormMaSysJuridica, Me)
    End Sub

    Private Sub TSMnuItemTipoDocu_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemTipoDocu.Click
        llamarform(FormSunatTDocumento, Me)
    End Sub

    Private Sub TSMnuItemTipoProg_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemTipoProg.Click
        llamarform(FormTipoPrograma, Me)
    End Sub

    Private Sub TSMnuItemCajaNumeracion_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemCajaNumeracion.Click
        llamarform(FormCtaCteNumeracionC, Me)
    End Sub

    Private Sub TSMnuItemConceptoCaja_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemConceptoCaja.Click
        llamarform(FormMaTipoServicios, Me)
    End Sub

    Private Sub TSMnuItemAtenderSolicitud_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemAtenderSolicitud.Click
        llamarform(FormPrcAtenderSolicitudCole, Me)
    End Sub

    Private Sub TSMnuItemAfiliacionFMorto_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemAfiliacionFMorto.Click
        llamarform(FormGridAfiliacion, Me)
    End Sub

    Private Sub TSMnuItemImpuesto_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemImpuesto.Click
        llamarform(FormMaImpuestoPais, Me)
    End Sub

    Private Sub TSMnuItemTCambio_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemTCambio.Click
        llamarform(FormTipodeCambio, Me)
    End Sub

    Private Sub TSMnuItemPrdContable_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemPrdContable.Click
        llamarform(FormMaPeriodo, Me)
    End Sub

    Private Sub FormMDI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'carga periodo actual
        CargarPeriodoActual()

    End Sub

    Private Sub TSMnuItemSQLSunat_Click_1(sender As System.Object, e As System.EventArgs) Handles TSMnuItemSQLSunat.Click
        llamarform(FormRucSunat, Me)
    End Sub

    Private Sub TSMnuItemSysConfig_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemSysConfig.Click
        llamarform(FormConfigSys, Me)
    End Sub

    Private Sub TSMnuItemPrcFactu_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemPrcFactu.Click

        If ObtenerParametroAppConfig("NroCaja") = vbNullString Or ObtenerParametroAppConfig("NroCaja") = "0" Then
            If MessageBox.Show("No se ha configurado ninguna Caja para este equipo; ¿Desea configurar una Nro. Caja al equipo.?", "Validando..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                llamarform(FormConfigSys, Me)
            End If
        Else
            llamarform(FormPrcFacturacion, Me)
        End If

    End Sub

    Private Sub TSMnuItemConfigParamServ_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemConfigParamServ.Click
        llamarform(FormSysConfigServicio, Me)
    End Sub

    Private Sub TSMnuItemPrcProgramaCoutaOrdinaria_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemPrcProgramaCoutaOrdinaria.Click
        llamarform(FormPrcProgramaBathCuotaOrdinaria, Me)
    End Sub

    Private Sub TipoDeTarjetasCreditoPorEntidadFinancieraToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TipoDeTarjetasCreditoPorEntidadFinancieraToolStripMenuItem.Click
        llamarform(FormMaMedioPagoTipoTarjeta, Me)
    End Sub

    Private Sub TSMnuItemRptCuadreCaja_Click(sender As System.Object, e As System.EventArgs)
        llamarform(FormRptCuadreCaja, Me)
    End Sub

    Private Sub AnularComprobanteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AnularComprobanteToolStripMenuItem.Click
        llamarform(FormPrcAnulacionComprobante, Me)
    End Sub

    Private Sub TSMnuItemRptGeneral_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemRptGeneral.Click
        llamarform(FormRptMaster, Me)
    End Sub

    Private Sub TSMnuItemRptBookVta_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemRptBookVta.Click
        llamarform(FormPrcLibroVta, Me)
    End Sub

    Private Sub TSMnuItemRptCole_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemRptCole.Click
        llamarform(FormRptMasterColegiado, Me)
    End Sub

    Private Sub TSMnuItemHelp_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemHelp.Click
        Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\Ayuda Sistema de Gestón CCPLL.chm")
    End Sub

    Private Sub NotificarUnErrorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NotificarUnErrorToolStripMenuItem.Click
        'llamarform(NotificarErrorAyuda, Me)
        NotificarErrorAyuda.Show()
    End Sub

    Private Sub TSMnuItemVentMinimizar_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemVentMinimizar.Click
        For i As Integer = 0 To Me.MdiChildren.Length - 1
            Me.MdiChildren(i).WindowState = FormWindowState.Minimized
        Next
    End Sub

    Private Sub TSMnuItemVentMaximizar_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemVentMaximizar.Click
        For i As Integer = 0 To Me.MdiChildren.Length - 1
            Me.MdiChildren(i).WindowState = FormWindowState.Maximized
        Next
    End Sub

    Private Sub TSMnuItemRptReImprimir_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemRptReImprimir.Click
        llamarform(FormPrcReImpresionDocu, Me)
    End Sub

    Private Sub TSMnuItemRptSQLEstadoCuentaCole_Click(sender As System.Object, e As System.EventArgs) Handles TSMnuItemRptSQLEstadoCuentaCole.Click
        llamarform(FormSQLEstadoCuenta_for_Colegiado, Me)
    End Sub
End Class