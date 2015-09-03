Option Explicit On
Imports Integration.BE
Imports Integration.BL.BL_CtaCtes
Imports Integration.BL.BL_SeuConAssetModelo
Imports System.Data
Imports System.Data.SqlClient

Public Class FormMaTipoServicios

    Private dataSetArbol As DataSet
    Dim nFlag As Integer
    Dim KeyNodecIntNombre As Long

    Function ValidaCamposObligatorios() As Boolean

        Dim NroKey As Integer = 0

        For Each row As DataGridViewRow In Table1.Rows
            If row.Cells("nKey").Value = 1 Then
                NroKey = 1
            End If
        Next

        ValidaCamposObligatorios = False

        If LblCodigo.Text = vbNullString Then MsgInfoCampoObligatorio(Label4.Text, TreeViewC) : Exit Function
        If LblJerarquia.Text = vbNullString Then MsgInfoCampoObligatorio(Label5.Text, TreeViewC) : Exit Function
        If CboTMoneda.SelectedIndex = -1 Then MsgInfoCampoObligatorio(Label7.Text, CboTMoneda) : Exit Function
        If CboAfecto.SelectedIndex = -1 Then MsgInfoCampoObligatorio(Label11.Text, CboAfecto) : Exit Function
        If CboExo.SelectedIndex = -1 Then MsgInfoCampoObligatorio(Label14.Text, CboExo) : Exit Function
        If CboFacturable.SelectedIndex = -1 Then MsgInfoCampoObligatorio(Label12.Text, CboFacturable) : Exit Function
        If CboExo.SelectedValue = 2 Then '// si NO esta exonerado
            If NroKey = 0 Then MsgInfoCampoObligatorio("Debe seleccionar por lo menos un Impuesto", Table1) : Exit Function
        End If
        If CboModAsiento.SelectedIndex = -1 Then MsgInfoCampoObligatorio(Label16.Text, CboModAsiento) : Exit Function

        ValidaCamposObligatorios = True

    End Function

    Private Sub CargarTreeview()

        '
        TreeViewC.Nodes.Clear()
        TreeViewC.BeginUpdate()

        'Dim ldr As New List(Of IDataReader)

        'RequestInterface.nIntClase = 1014 '//Servicio
        'RequestInterface.nIntTipo = 1000

        Dim Ds As New DataSet
        'Dim Le As IDataReader
        'Dim dt As New DataTable

        Dim NodeForm As New TreeNode("TIPOS DE SERVICIOS")
        TreeViewC.Nodes.Add(NodeForm)

        Try
            'dt = ObjInterface.Get_Interface_Datareader(RequestInterface)
            'Le = dt.CreateDataReader()

            '1014 '//Servicio
            Ds.Tables.Add(ObjInterface.Get_Interface(1014, 1000, "T"))
            Ds.Tables(0).TableName = "Interface"

            Call CrearNodosDelPadre(0, NodeForm, TreeViewC, Ds)

            ' habilita la actualización en pantalla del control TreeView
            TreeViewC.EndUpdate()

            ' modifico la propiedad Sorted a True para que los nodos estén ordenados
            TreeViewC.Sorted = True
            TreeViewC.ExpandAll()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub SelectImpGrilla()

        '---------------------------------------
        'LLENA VALORES QUE YA FUERON REGISTRADOS
        '---------------------------------------
        Dim ReqImp As New CtasCtes.BE_ReqCtaCteSerImpuesto
        Dim ObjImp As New BL_CtaCteSerImpuesto

        ReqImp.nCtaCteSerCodigo = IIf(LblCodigo.Text = vbNullString, 0, LblCodigo.Text)

        If ObjImp.Get_CtaCteSerImpuesto(ReqImp).Rows.Count > 0 Then
            For x As Integer = 0 To ObjImp.Get_CtaCteSerImpuesto(ReqImp).Rows.Count - 1
                With Table1
                    If .RowCount > 0 Then
                        'Where
                        For I As Integer = 0 To .RowCount - 1
                            If LblCodigo.Text = ObjImp.Get_CtaCteSerImpuesto(ReqImp).Rows(x)("nCtaCteSerCodigo") And
                                     .Item(1, I).Value = ObjImp.Get_CtaCteSerImpuesto(ReqImp).Rows(x)("nSysTasContry") And
                                     .Item(3, I).Value = ObjImp.Get_CtaCteSerImpuesto(ReqImp).Rows(x)("nSysTasCodigo") Then

                                .Item(0, I).Value = 1
                                'Call Table1_CellContentClick(Table1, Nothing)
                            End If
                        Next
                    End If
                End With
            Next
        End If

    End Sub

    Private Sub FillGridImp()
        'Llenando Grilla con los tipos de impuestos
        Dim Request As New BE.Sistema.BE_ReqSysConTasImpuesto
        Dim ObjImp As New BL.BL_Sistema

        Request.nSysTasContry = 9256 '//Default Peru (OJO AQUI)
        Table1.DataSource = ObjImp.Get_SysConTasImpuesto(Request)
        '
    End Sub

    Private Sub FormMaTipoServicios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        SplitContainer2.Panel2.Visible = False

        'Llenando combox
        LlenaDataCombo(CboTMoneda, ObjConst.Get_Constante("C", CLng(TokenByKey(CboTMoneda.Tag, "nConCodigo"))), "nConValor", "cConDescripcion")
        LlenaDataCombo(CboAfecto, ObjConst.Get_Constante("C", CLng(TokenByKey(CboAfecto.Tag, "nConCodigo"))), "nConValor", "cConDescripcion")
        LlenaDataCombo(CboExo, ObjConst.Get_Constante("C", CLng(TokenByKey(CboExo.Tag, "nConCodigo"))), "nConValor", "cConDescripcion")
        LlenaDataCombo(CboFacturable, ObjConst.Get_Constante("C", CLng(TokenByKey(CboFacturable.Tag, "nConCodigo"))), "nConValor", "cConDescripcion")
        LlenaDataCombo(CboTipoCta, ObjConst.Get_Constante("C", CLng(TokenByKey(CboTipoCta.Tag, "nConCodigo"))), "nConValor", "cConDescripcion")

        '--//Modelo de asiento //--
        Dim BL As New BL_SeuConAssetModelo
        LlenaDataCombo(CboModAsiento, BL.Get_SeuConAssetModelo(StrcPerJuridica), "nSeuCodigo", "cSeusName")

        FormatGrilla(Table1, Me, False, 25, False, DataGridViewSelectionMode.CellSelect)

        Call CargarTreeview()

        EstadoCmdLink(c1CmdNuevo, True, c1CmdGrabar, False, c1CmdCancel, False, C1CmdEdit, True, C1CmdCerrar, True, GrpBox, False)

        '
    End Sub

    Private Sub TreeViewC_AfterCollapse(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewC.AfterCollapse

        Select Case e.Node.Level
            Case 1
                e.Node.ImageKey = "folder"
                e.Node.SelectedImageKey = "folder"
                Return
            Case 2
                e.Node.ImageKey = "folder_add"
                e.Node.SelectedImageKey = "folder_add"
                Return
        End Select

    End Sub

    Private Sub TreeViewC_AfterExpand(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewC.AfterExpand

        Select Case e.Node.Level
            Case 1, 2
                e.Node.ImageKey = "folder_add"
                e.Node.SelectedImageKey = "folder_add"
                Return
        End Select

    End Sub

    Private Sub TreeView_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewC.AfterSelect

        'MessageBox.Show(e.Node.Name.ToString())
        'MessageBox.Show(TreeViewC.SelectedNode.Name)
        'MessageBox.Show(TreeViewC.SelectedNode.Tag)
        'MessageBox.Show(TreeViewC.SelectedNode.ToolTipText)

        If TreeViewC.SelectedNode Is Nothing Or TreeViewC.SelectedNode.Tag = "" Then Exit Sub

        If TreeViewC.SelectedNode.Tag > 0 Then
            SplitContainer2.Panel1.Enabled = True
            GrpBox.Visible = True
        Else
            SplitContainer2.Panel1.Enabled = False
            GrpBox.Visible = False
        End If

        TreeViewC.FullRowSelect = True

        Dim Request As New CtasCtes.BE_ReqCtaCteServBusca
        Dim ObjCtaCteServ As New BL_CtaCtaServicio

        Request.nCtaCteSerCodigo = TreeViewC.SelectedNode.Name
        Request.cPerJurCodigo = StrcPerJuridica 'EMPRESA

        If ObjCtaCteServ.Get_CtaCteServicio(Request).Rows.Count > 0 Then
            '//recuperando valores
            LblCodigo.Text = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaCteSerCodigo")
            LblJerarquia.Text = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("cIntDescripcion") 'cCtaCteSerJerarquia
            CboTMoneda.SelectedValue = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nMonCodigo")
            TxtImpMin.Text = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaCteSerImpMin")
            TxtImpMax.Text = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaCteSerImpMax")
            TxtImpDef.Text = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaCteSerImpDef")
            CboModAsiento.SelectedValue = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nSeuCodigo")
            CboAfecto.SelectedValue = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaCteSerAfecto")
            CboExo.SelectedValue = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaCteSerExonerado")
            CboFacturable.SelectedValue = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaCteSerFacturable")
            CboTipoCta.SelectedValue = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaCteTipoCta")
            TxtCtaAlter.Text = ObjCtaCteServ.Get_CtaCteServicio(Request).Rows(0)("nCtaAlterna")

            Call FillGridImp()

        Else
            LblCodigo.Text = vbNullString : LblJerarquia.Text = vbNullString
            TxtImpMin.Text = "0.00" : TxtImpMax.Text = "0.00" : TxtImpDef.Text = "0.00"
            CboTMoneda.SelectedValue = -1 : CboAfecto.SelectedValue = -1 : CboFacturable.SelectedValue = -1 : CboTipoCta.SelectedValue = -1
            Call EliminarRowsDgView(Table1)
        End If

        'Marcando Impuestos en la Grilla segun Servicio seleccionado
        Call SelectImpGrilla()

    End Sub

    Private Sub TreeView1_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeViewC.BeforeExpand
        ' TreeViewC.SelectedImageIndex = 1
    End Sub

    Private Sub TreeViewC_BeforeCollapse(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs) Handles TreeViewC.BeforeCollapse
        If (e.Node.Level = 0) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripMnuPopupAddS_Click(sender As Object, e As System.EventArgs) Handles ToolStripMnuPopupAddS.Click

        'validando si no hay nada seleccionado
        If TreeViewC.SelectedNode Is Nothing Then Exit Sub

        nFlag = 0 'Agregando
        SplitContainer2.Panel2.Visible = True : TxtJerarquia.Enabled = True : Label1.Text = "Agregando Servicio.." : SplitContainer2.Panel1.Enabled = False

        If TreeViewC.SelectedNode.Tag = "" Then 'para agregar padres
            Label13.Text = "Agregando nueva lista.."
            KeyNodecIntNombre = 0
        Else
            'Obtengo el Key de arbol Padre el hijo seleccionado
            If TreeViewC.SelectedNode.Tag = 0 Then
                KeyNodecIntNombre = TreeViewC.SelectedNode.ToolTipText 'para agregar un primer Hijos
                Label13.Text = TreeViewC.SelectedNode.ToolTipText & " - " & TreeViewC.SelectedNode.Text
            Else
                KeyNodecIntNombre = TreeViewC.SelectedNode.Tag 'para agregar mas hijos
                Label13.Text = TreeViewC.SelectedNode.Tag & " - " & TreeViewC.SelectedNode.Parent.Text
            End If
        End If

        TreeViewC.HideSelection = True
        TreeViewC.Enabled = False

        'Obtengo correlativo sgte cIntJerarquia
        RequestInterface.nIntClase = TokenByKey(TxtJerarquia.Tag, "nIntClase")
        RequestInterface.nIntTipo = TokenByKey(TxtJerarquia.Tag, "nIntTipo")
        TxtJerarquia.Text = ObjInterface.Get_NewIdcIntJerarquia(RequestInterface)
        '
        TxtJerarquia.ReadOnly = True
        TxtDesc.Text = vbNullString
        TxtDesc.Focus()

        'End If

    End Sub

    Private Sub ToolStripMnuPopupEditS_Click(sender As Object, e As System.EventArgs) Handles ToolStripMnuPopupEditS.Click

        nFlag = 1 'modificando
        SplitContainer2.Panel2.Visible = True : TxtJerarquia.Enabled = False : Label1.Text = "Modificando Servicio.." : SplitContainer2.Panel1.Enabled = False

        TxtJerarquia.Text = TreeViewC.SelectedNode.ToolTipText ' Microsoft.VisualBasic.Left(TreeViewC.SelectedNode.Text, 4)
        KeyNodecIntNombre = TreeViewC.SelectedNode.Tag
        TxtDesc.Text = TreeViewC.SelectedNode.Text 'Microsoft.VisualBasic.Mid(TreeViewC.SelectedNode.Text, 8, 250)
        TxtDesc.Focus()

    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        SplitContainer2.Panel2.Visible = False
        SplitContainer2.Panel1.Enabled = True
        TreeViewC.Enabled = True
        TreeViewC.Focus()
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click

        Try
            Dim Response As New BE_ResGenerico
            Dim Resultado As Long

            RequestInterface.nIntClase = TokenByKey(TxtJerarquia.Tag, "nIntClase")
            RequestInterface.cIntJerarquia = TxtJerarquia.Text  'correlativo
            RequestInterface.cIntNombre = KeyNodecIntNombre     'TxtDesc.Text 'key
            RequestInterface.cIntDescripcion = TxtDesc.Text
            RequestInterface.nIntTipo = TokenByKey(TxtJerarquia.Tag, "nIntTipo")

            If nFlag = 0 Then
                Response = ObjInterface.InsInterface(RequestInterface)
            ElseIf nFlag = 1 Then
                RequestInterface.nIntCodigo = TreeViewC.SelectedNode.Name 'nIntCodigo
                Response = ObjInterface.UpdInterface(RequestInterface)
            End If

            Resultado = Response.Resultado

            Call BtnCancel_Click(BtnCancel, Nothing)
            Call CargarTreeview()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub c1CmdNuevo_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles c1CmdNuevo.Click

        'Aqui es donde valido si es cabezera o Item
        If TreeViewC.SelectedNode.Tag = vbNullString Or TreeViewC.SelectedNode.Tag = 0 Then Exit Sub

        If LblCodigo.Text <> vbNullString Then MessageBox.Show("Servicio ya tiene detalle.!", "Validando", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

        TreeViewC.Enabled = False
        nFlag = 0
        CboTMoneda.Text = vbNullString : TxtImpMin.Text = "0.00" : TxtImpMax.Text = "0.00" : TxtImpDef.Text = "0.00" : CboAfecto.Text = vbNullString : CboFacturable.Text = vbNullString : CboExo.Text = vbNullString : CboTipoCta.Text = vbNullString : TxtCtaAlter.Text = "0"
        EstadoCmdLink(c1CmdNuevo, False, c1CmdGrabar, True, c1CmdCancel, True, C1CmdEdit, False, C1CmdCerrar, False, GrpBox, True)

        LblCodigo.Text = TreeViewC.SelectedNode.Name    'nIntCodigo
        LblJerarquia.Text = TreeViewC.SelectedNode.Text 'Microsoft.VisualBasic.Left(TreeViewC.SelectedNode.Text, 4)

        Call FillGridImp()

        CboTMoneda.Focus()

    End Sub

    Private Sub c1CmdGrabar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles c1CmdGrabar.Click

        Try
            'CtaCtaServicio
            Dim Request As New CtasCtes.BE_ReqCtaCteServicio
            Dim ObjCtaCteServ As New BL_CtaCtaServicio

            'CtaCtaServicio
            Dim ReqCtaImp As New CtasCtes.BE_ReqCtaCteSerImpuesto
            Dim ObjCtaImp As New BL_CtaCteSerImpuesto

            Dim Response As BE_ResGenerico

            Dim ResultadoG As Boolean
            Dim Resultado As Long

            If ValidaCamposObligatorios() Then

                'enviando parameter
                Request.nCtaCteSerCodigo = CLng(TreeViewC.SelectedNode.Name)
                Request.cPerJurCodigo = StrcPerJuridica 'Empresa
                Request.cCtaCteSerJerarquia = TreeViewC.SelectedNode.ToolTipText   'Trim(LblJerarquia.Text)
                Request.cCtaCteSerKeyWord = Trim(LblJerarquia.Text) '""
                Request.nBieCodigo = CLng(TreeViewC.SelectedNode.Name)
                Request.nCtaCteSerAfecto = CLng(CboAfecto.SelectedValue)
                Request.nCtaCteSerExonerado = CLng(CboExo.SelectedValue)
                Request.nMonCodigo = CLng(CboTMoneda.SelectedValue)
                Request.nCtaCteSerImpMin = CDbl(TxtImpMin.Text)
                Request.nCtaCteSerImpMax = CDbl(TxtImpMax.Text)
                Request.nCtaCteSerImpDef = CDbl(TxtImpDef.Text)
                Request.nSeuCodigo = CLng(CboModAsiento.SelectedValue)
                Request.nCtaCteSerFacturable = CLng(CboFacturable.SelectedValue)
                Request.nCtaCteTipoCta = CboTipoCta.SelectedValue
                Request.nCtaAlterna = CLng(TxtCtaAlter.Text)

                If nFlag = 0 Then
                    REM Insert
                    ResultadoG = ObjCtaCteServ.Ins_CtaCteServicio(Request)

                ElseIf nFlag = 1 Then
                    REM Update
                    ResultadoG = ObjCtaCteServ.Upd_CtaCteServicio(Request)

                End If

                If Table1.RowCount > 0 Then
                    '-------------------
                    '-- Delete Impuesto
                    '-------------------
                    For Each row As DataGridViewRow In Table1.Rows
                        'Elimina Imp
                        ReqCtaImp.cPerJurCodigo = StrcPerJuridica
                        ReqCtaImp.nCtaCteSerCodigo = TreeViewC.SelectedNode.Name
                        ReqCtaImp.nSysTasContry = row.Cells("nSysTasContry").Value
                        ReqCtaImp.nSysTasCodigo = row.Cells("nSysTasCodigo").Value

                        Response = ObjCtaImp.Del_CtaCteSerImpuesto(ReqCtaImp)
                        Resultado = Response.Resultado
                    Next
                End If

                If CboExo.SelectedValue = 2 AndAlso Table1.RowCount > 0 Then
                    '----------------------------------------
                    '-- Grabando Impuesto que aplica (Update)
                    '---------------------------------------
                    For Each row As DataGridViewRow In Table1.Rows
                        If Convert.ToInt16(row.Cells("nKey").Value) = 1 Then
                            'Grabar
                            ReqCtaImp.cPerJurCodigo = StrcPerJuridica
                            ReqCtaImp.nCtaCteSerCodigo = TreeViewC.SelectedNode.Name
                            ReqCtaImp.nSysTasContry = row.Cells("nSysTasContry").Value
                            ReqCtaImp.nSysTasCodigo = row.Cells("nSysTasCodigo").Value

                            Response = ObjCtaImp.Ins_CtaCteSerImpuesto(ReqCtaImp)
                            Resultado = Response.Resultado

                        End If
                    Next
                End If

                If ResultadoG Or Resultado > 0 Then
                    MessageBox.Show("Operacion se realizo con exito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call c1CmdCancel_Click(c1CmdCancel, Nothing)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub C1CmdEdit_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1CmdEdit.Click

        If LblCodigo.Text = vbNullString Then
            MessageBox.Show("Selecciona un item de la grilla para modificar.", "Validando", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        nFlag = 1
        EstadoCmdLink(c1CmdNuevo, False, c1CmdGrabar, True, c1CmdCancel, True, C1CmdEdit, False, C1CmdCerrar, False, GrpBox, True)

        TreeViewC.Enabled = False

    End Sub

    Private Sub c1CmdCancel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles c1CmdCancel.Click

        EstadoCmdLink(c1CmdNuevo, True, c1CmdGrabar, False, c1CmdCancel, False, C1CmdEdit, True, C1CmdCerrar, True, GrpBox, False)
        TreeViewC.Enabled = True

    End Sub

    Private Sub C1CmdCerrar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1CmdCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub CboTMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboTMoneda.KeyPress, CboFacturable.KeyPress, CboTipoCta.KeyPress, CboAfecto.KeyPress, CboExo.KeyPress, CboTipoCta.KeyPress, CboModAsiento.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub TxtImpMin_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImpMin.KeyPress, TxtImpMax.KeyPress, TxtImpDef.KeyPress, TxtCtaAlter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub TxtImpMin_LostFocus(sender As Object, e As System.EventArgs) Handles TxtImpMin.LostFocus, TxtImpMax.LostFocus, TxtImpDef.LostFocus, TxtCtaAlter.LostFocus
        TxtImpMin.Text = FormatNumber(TxtImpMin.Text, Microsoft.VisualBasic.vbTrue)
        TxtImpMax.Text = FormatNumber(TxtImpMax.Text, Microsoft.VisualBasic.vbTrue)
        TxtImpDef.Text = FormatNumber(TxtImpDef.Text, Microsoft.VisualBasic.vbTrue)
    End Sub

    Private Sub Table1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Table1.CellContentClick
        '
        ' Detecta si se ha seleccionado el header de la grilla
        '
        If e.RowIndex = -1 Then
            Return
        End If

        If Table1.Columns(e.ColumnIndex).Name = "nKey" Then

            '
            ' Se toma la fila seleccionada
            '
            Dim row As DataGridViewRow = Table1.Rows(e.RowIndex)

            '
            ' Se selecciona la celda del checkbox
            '
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("nKey"), DataGridViewCheckBoxCell)

            'If Convert.ToBoolean(cellSelecion.Value) Then
            If Convert.ToInt16(cellSelecion.Value) Then
                row.DefaultCellStyle.BackColor = Color.LightCoral
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If

        End If
    End Sub

    Private Sub Table1_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles Table1.CurrentCellDirtyStateChanged

        If Table1.IsCurrentCellDirty Then
            Table1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    Private Sub CboExo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboExo.SelectedIndexChanged, CboModAsiento.SelectedIndexChanged

        If CboExo.SelectedValue = 1 Then 'Si
            For Each row As DataGridViewRow In Table1.Rows
                'desactivar todo a cero
                row.Cells("nKey").Value = 0
            Next
            GrpBoxImp.Visible = False
            'Call EliminarRowsDgView(Table1)
        Else
            GrpBoxImp.Visible = True
        End If

    End Sub

End Class