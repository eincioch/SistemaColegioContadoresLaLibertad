<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrcFormaPago
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DtpFecDeposito = New System.Windows.Forms.DateTimePicker()
        Me.Table2 = New System.Windows.Forms.DataGridView()
        Me.nCtaCteForPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescForPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nPerCtaCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPerjurCodigoFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEntidadBanca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dCtaCteFecTransacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCtaCtePagTracer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nMonCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescMoneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nCtaCtePagImpMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nCtaCtePagImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboFormaPago = New System.Windows.Forms.ComboBox()
        Me.LblNroRecibo = New System.Windows.Forms.Label()
        Me.CboMoneda = New System.Windows.Forms.ComboBox()
        Me.LblImpRecibo = New System.Windows.Forms.Label()
        Me.GrpBox = New System.Windows.Forms.GroupBox()
        Me.GrpBoxBco = New System.Windows.Forms.GroupBox()
        Me.TxtVoucher = New System.Windows.Forms.TextBox()
        Me.CboNroCta_TarjetaDC = New System.Windows.Forms.ComboBox()
        Me.CboTipoTarj = New System.Windows.Forms.ComboBox()
        Me.CboBanco = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtImpPago = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.BtnQuitar = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.DtpFecPago = New System.Windows.Forms.DateTimePicker()
        Me.LblTC = New System.Windows.Forms.Label()
        Me.LblTotalPago = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnRegPago = New System.Windows.Forms.Button()
        Me.BtnPagoDet = New System.Windows.Forms.Button()
        Me.TxtStrDetalle = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.Table2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBox.SuspendLayout()
        Me.GrpBoxBco.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Importe Recibo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(318, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Fecha de Pago:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(38, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Moneda:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nro. Recibo:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(792, 20)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "҉҉    Registro de Pago"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFecDeposito
        '
        Me.DtpFecDeposito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DtpFecDeposito.CustomFormat = ""
        Me.DtpFecDeposito.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecDeposito.Location = New System.Drawing.Point(107, 83)
        Me.DtpFecDeposito.Name = "DtpFecDeposito"
        Me.DtpFecDeposito.Size = New System.Drawing.Size(98, 20)
        Me.DtpFecDeposito.TabIndex = 3
        Me.DtpFecDeposito.Value = New Date(2013, 10, 17, 0, 0, 0, 0)
        '
        'Table2
        '
        Me.Table2.AllowUserToAddRows = False
        Me.Table2.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Table2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Table2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Table2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Table2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nCtaCteForPago, Me.cDescForPago, Me.nPerCtaCodigo, Me.cPerjurCodigoFin, Me.cEntidadBanca, Me.dCtaCteFecTransacion, Me.cCtaCtePagTracer, Me.nMonCodigo, Me.cDescMoneda, Me.nCtaCtePagImpMon, Me.nTC, Me.nCtaCtePagImporte})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Table2.DefaultCellStyle = DataGridViewCellStyle7
        Me.Table2.Location = New System.Drawing.Point(8, 237)
        Me.Table2.Name = "Table2"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Table2.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Table2.Size = New System.Drawing.Size(776, 155)
        Me.Table2.TabIndex = 0
        '
        'nCtaCteForPago
        '
        Me.nCtaCteForPago.HeaderText = "nCtaCteForPago"
        Me.nCtaCteForPago.Name = "nCtaCteForPago"
        Me.nCtaCteForPago.Visible = False
        '
        'cDescForPago
        '
        Me.cDescForPago.HeaderText = "Forma de Pago"
        Me.cDescForPago.Name = "cDescForPago"
        Me.cDescForPago.Width = 110
        '
        'nPerCtaCodigo
        '
        Me.nPerCtaCodigo.HeaderText = "nPerCtaCodigo"
        Me.nPerCtaCodigo.Name = "nPerCtaCodigo"
        Me.nPerCtaCodigo.Visible = False
        '
        'cPerjurCodigoFin
        '
        Me.cPerjurCodigoFin.HeaderText = "cPerjurCodigoFin"
        Me.cPerjurCodigoFin.Name = "cPerjurCodigoFin"
        Me.cPerjurCodigoFin.Visible = False
        '
        'cEntidadBanca
        '
        Me.cEntidadBanca.HeaderText = "Entidad"
        Me.cEntidadBanca.Name = "cEntidadBanca"
        Me.cEntidadBanca.Width = 190
        '
        'dCtaCteFecTransacion
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.dCtaCteFecTransacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.dCtaCteFecTransacion.HeaderText = "Fecha Operación"
        Me.dCtaCteFecTransacion.Name = "dCtaCteFecTransacion"
        Me.dCtaCteFecTransacion.Width = 75
        '
        'cCtaCtePagTracer
        '
        Me.cCtaCtePagTracer.HeaderText = "Voucher / Nº. Ope - Tarj."
        Me.cCtaCtePagTracer.Name = "cCtaCtePagTracer"
        '
        'nMonCodigo
        '
        Me.nMonCodigo.HeaderText = "nMonCodigo"
        Me.nMonCodigo.Name = "nMonCodigo"
        Me.nMonCodigo.Visible = False
        '
        'cDescMoneda
        '
        Me.cDescMoneda.HeaderText = "Moneda"
        Me.cDescMoneda.Name = "cDescMoneda"
        Me.cDescMoneda.Width = 80
        '
        'nCtaCtePagImpMon
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        Me.nCtaCtePagImpMon.DefaultCellStyle = DataGridViewCellStyle4
        Me.nCtaCtePagImpMon.HeaderText = "Importe Recibe"
        Me.nCtaCtePagImpMon.Name = "nCtaCtePagImpMon"
        Me.nCtaCtePagImpMon.Width = 70
        '
        'nTC
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N3"
        Me.nTC.DefaultCellStyle = DataGridViewCellStyle5
        Me.nTC.HeaderText = "TC"
        Me.nTC.Name = "nTC"
        Me.nTC.Width = 50
        '
        'nCtaCtePagImporte
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N2"
        Me.nCtaCtePagImporte.DefaultCellStyle = DataGridViewCellStyle6
        Me.nCtaCtePagImporte.HeaderText = "Importe S/."
        Me.nCtaCtePagImporte.Name = "nCtaCtePagImporte"
        Me.nCtaCtePagImporte.Width = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Forma de Pago:"
        '
        'CboFormaPago
        '
        Me.CboFormaPago.ForeColor = System.Drawing.Color.Black
        Me.CboFormaPago.FormattingEnabled = True
        Me.CboFormaPago.Location = New System.Drawing.Point(93, 62)
        Me.CboFormaPago.Name = "CboFormaPago"
        Me.CboFormaPago.Size = New System.Drawing.Size(202, 21)
        Me.CboFormaPago.TabIndex = 0
        Me.CboFormaPago.Tag = "nConCodigo=1086"
        '
        'LblNroRecibo
        '
        Me.LblNroRecibo.BackColor = System.Drawing.SystemColors.Info
        Me.LblNroRecibo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNroRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNroRecibo.ForeColor = System.Drawing.Color.Black
        Me.LblNroRecibo.Location = New System.Drawing.Point(94, 12)
        Me.LblNroRecibo.Name = "LblNroRecibo"
        Me.LblNroRecibo.Size = New System.Drawing.Size(151, 20)
        Me.LblNroRecibo.TabIndex = 115
        Me.LblNroRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboMoneda
        '
        Me.CboMoneda.ForeColor = System.Drawing.Color.Black
        Me.CboMoneda.FormattingEnabled = True
        Me.CboMoneda.Location = New System.Drawing.Point(93, 89)
        Me.CboMoneda.Name = "CboMoneda"
        Me.CboMoneda.Size = New System.Drawing.Size(168, 21)
        Me.CboMoneda.TabIndex = 1
        Me.CboMoneda.Tag = "nConCodigo=1001"
        '
        'LblImpRecibo
        '
        Me.LblImpRecibo.BackColor = System.Drawing.SystemColors.Info
        Me.LblImpRecibo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblImpRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblImpRecibo.ForeColor = System.Drawing.Color.Black
        Me.LblImpRecibo.Location = New System.Drawing.Point(94, 37)
        Me.LblImpRecibo.Name = "LblImpRecibo"
        Me.LblImpRecibo.Size = New System.Drawing.Size(98, 20)
        Me.LblImpRecibo.TabIndex = 117
        Me.LblImpRecibo.Text = "0.00"
        Me.LblImpRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GrpBox
        '
        Me.GrpBox.Controls.Add(Me.GrpBoxBco)
        Me.GrpBox.Controls.Add(Me.TxtImpPago)
        Me.GrpBox.Controls.Add(Me.CboFormaPago)
        Me.GrpBox.Controls.Add(Me.Label5)
        Me.GrpBox.Controls.Add(Me.Label17)
        Me.GrpBox.Controls.Add(Me.BtnQuitar)
        Me.GrpBox.Controls.Add(Me.Label20)
        Me.GrpBox.Controls.Add(Me.Label2)
        Me.GrpBox.Controls.Add(Me.BtnAdd)
        Me.GrpBox.Controls.Add(Me.DtpFecPago)
        Me.GrpBox.Controls.Add(Me.Label4)
        Me.GrpBox.Controls.Add(Me.LblTC)
        Me.GrpBox.Controls.Add(Me.LblImpRecibo)
        Me.GrpBox.Controls.Add(Me.Label1)
        Me.GrpBox.Controls.Add(Me.CboMoneda)
        Me.GrpBox.Controls.Add(Me.Label3)
        Me.GrpBox.Controls.Add(Me.LblNroRecibo)
        Me.GrpBox.Location = New System.Drawing.Point(8, 19)
        Me.GrpBox.Name = "GrpBox"
        Me.GrpBox.Size = New System.Drawing.Size(776, 194)
        Me.GrpBox.TabIndex = 119
        Me.GrpBox.TabStop = False
        '
        'GrpBoxBco
        '
        Me.GrpBoxBco.Controls.Add(Me.TxtVoucher)
        Me.GrpBoxBco.Controls.Add(Me.CboNroCta_TarjetaDC)
        Me.GrpBoxBco.Controls.Add(Me.CboTipoTarj)
        Me.GrpBoxBco.Controls.Add(Me.CboBanco)
        Me.GrpBoxBco.Controls.Add(Me.Label15)
        Me.GrpBoxBco.Controls.Add(Me.Label10)
        Me.GrpBoxBco.Controls.Add(Me.Label14)
        Me.GrpBoxBco.Controls.Add(Me.Label12)
        Me.GrpBoxBco.Controls.Add(Me.Label13)
        Me.GrpBoxBco.Controls.Add(Me.DtpFecDeposito)
        Me.GrpBoxBco.ForeColor = System.Drawing.Color.Navy
        Me.GrpBoxBco.Location = New System.Drawing.Point(301, 57)
        Me.GrpBoxBco.Name = "GrpBoxBco"
        Me.GrpBoxBco.Size = New System.Drawing.Size(449, 132)
        Me.GrpBoxBco.TabIndex = 119
        Me.GrpBoxBco.TabStop = False
        Me.GrpBoxBco.Text = " Detalle "
        Me.GrpBoxBco.Visible = False
        '
        'TxtVoucher
        '
        Me.TxtVoucher.BackColor = System.Drawing.SystemColors.Info
        Me.TxtVoucher.ForeColor = System.Drawing.Color.Black
        Me.TxtVoucher.Location = New System.Drawing.Point(107, 107)
        Me.TxtVoucher.Name = "TxtVoucher"
        Me.TxtVoucher.Size = New System.Drawing.Size(246, 20)
        Me.TxtVoucher.TabIndex = 4
        '
        'CboNroCta_TarjetaDC
        '
        Me.CboNroCta_TarjetaDC.ForeColor = System.Drawing.Color.Black
        Me.CboNroCta_TarjetaDC.FormattingEnabled = True
        Me.CboNroCta_TarjetaDC.Location = New System.Drawing.Point(107, 60)
        Me.CboNroCta_TarjetaDC.Name = "CboNroCta_TarjetaDC"
        Me.CboNroCta_TarjetaDC.Size = New System.Drawing.Size(332, 21)
        Me.CboNroCta_TarjetaDC.TabIndex = 2
        Me.CboNroCta_TarjetaDC.Tag = "nConCodigo=1086"
        '
        'CboTipoTarj
        '
        Me.CboTipoTarj.ForeColor = System.Drawing.Color.Black
        Me.CboTipoTarj.FormattingEnabled = True
        Me.CboTipoTarj.Location = New System.Drawing.Point(107, 37)
        Me.CboTipoTarj.Name = "CboTipoTarj"
        Me.CboTipoTarj.Size = New System.Drawing.Size(332, 21)
        Me.CboTipoTarj.TabIndex = 1
        Me.CboTipoTarj.Tag = "nIntClase=1023;nIntTipo=6003"
        '
        'CboBanco
        '
        Me.CboBanco.ForeColor = System.Drawing.Color.Black
        Me.CboBanco.FormattingEnabled = True
        Me.CboBanco.Location = New System.Drawing.Point(107, 14)
        Me.CboBanco.Name = "CboBanco"
        Me.CboBanco.Size = New System.Drawing.Size(332, 21)
        Me.CboBanco.TabIndex = 0
        Me.CboBanco.Tag = "nConCodigo=1086"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(6, 110)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Nro. Operacion:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Cuenta:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(6, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Fecha Deposito:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(6, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Tipo de Tarjeta:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(9, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Banco:"
        '
        'TxtImpPago
        '
        Me.TxtImpPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImpPago.ForeColor = System.Drawing.Color.Black
        Me.TxtImpPago.Location = New System.Drawing.Point(92, 116)
        Me.TxtImpPago.Name = "TxtImpPago"
        Me.TxtImpPago.Size = New System.Drawing.Size(100, 22)
        Me.TxtImpPago.TabIndex = 2
        Me.TxtImpPago.Text = "0.00"
        Me.TxtImpPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(44, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Importe:"
        '
        'BtnQuitar
        '
        Me.BtnQuitar.ForeColor = System.Drawing.Color.Black
        Me.BtnQuitar.Image = Global.Integration.Test.My.Resources.Resources.money_delete
        Me.BtnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnQuitar.Location = New System.Drawing.Point(164, 155)
        Me.BtnQuitar.Name = "BtnQuitar"
        Me.BtnQuitar.Size = New System.Drawing.Size(114, 29)
        Me.BtnQuitar.TabIndex = 4
        Me.BtnQuitar.Text = "Quitar Item (Supr)"
        Me.BtnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnQuitar.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(574, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Tipo de Cambio:"
        '
        'BtnAdd
        '
        Me.BtnAdd.ForeColor = System.Drawing.Color.Black
        Me.BtnAdd.Image = Global.Integration.Test.My.Resources.Resources.money_add
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAdd.Location = New System.Drawing.Point(47, 155)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(111, 29)
        Me.BtnAdd.TabIndex = 3
        Me.BtnAdd.Text = "Agregar (Insert)"
        Me.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'DtpFecPago
        '
        Me.DtpFecPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DtpFecPago.CustomFormat = ""
        Me.DtpFecPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecPago.Location = New System.Drawing.Point(406, 12)
        Me.DtpFecPago.Name = "DtpFecPago"
        Me.DtpFecPago.Size = New System.Drawing.Size(98, 20)
        Me.DtpFecPago.TabIndex = 112
        Me.DtpFecPago.Value = New Date(2013, 10, 17, 0, 0, 0, 0)
        '
        'LblTC
        '
        Me.LblTC.BackColor = System.Drawing.SystemColors.Info
        Me.LblTC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTC.ForeColor = System.Drawing.Color.Black
        Me.LblTC.Location = New System.Drawing.Point(659, 13)
        Me.LblTC.Name = "LblTC"
        Me.LblTC.Size = New System.Drawing.Size(98, 20)
        Me.LblTC.TabIndex = 117
        Me.LblTC.Text = "0.00"
        Me.LblTC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalPago
        '
        Me.LblTotalPago.BackColor = System.Drawing.SystemColors.Info
        Me.LblTotalPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTotalPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPago.ForeColor = System.Drawing.Color.Black
        Me.LblTotalPago.Location = New System.Drawing.Point(667, 395)
        Me.LblTotalPago.Name = "LblTotalPago"
        Me.LblTotalPago.Size = New System.Drawing.Size(98, 27)
        Me.LblTotalPago.TabIndex = 117
        Me.LblTotalPago.Text = "0.00"
        Me.LblTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(584, 403)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Total Cobrado:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(9, 217)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(775, 20)
        Me.Label18.TabIndex = 120
        Me.Label18.Text = "Detalle de pago"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Image = Global.Integration.Test.My.Resources.Resources.cancel1
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(176, 398)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(147, 40)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "         Cancelar (ESC)"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnRegPago
        '
        Me.BtnRegPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegPago.ForeColor = System.Drawing.Color.Black
        Me.BtnRegPago.Image = Global.Integration.Test.My.Resources.Resources.accept
        Me.BtnRegPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRegPago.Location = New System.Drawing.Point(8, 398)
        Me.BtnRegPago.Name = "BtnRegPago"
        Me.BtnRegPago.Size = New System.Drawing.Size(162, 40)
        Me.BtnRegPago.TabIndex = 1
        Me.BtnRegPago.Text = "          Registrar Pago (F7)"
        Me.BtnRegPago.UseVisualStyleBackColor = True
        '
        'BtnPagoDet
        '
        Me.BtnPagoDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPagoDet.ForeColor = System.Drawing.Color.Black
        Me.BtnPagoDet.Image = Global.Integration.Test.My.Resources.Resources.google_adsense
        Me.BtnPagoDet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPagoDet.Location = New System.Drawing.Point(355, 398)
        Me.BtnPagoDet.Name = "BtnPagoDet"
        Me.BtnPagoDet.Size = New System.Drawing.Size(159, 40)
        Me.BtnPagoDet.TabIndex = 0
        Me.BtnPagoDet.Text = "      Más detalles (F8) »"
        Me.BtnPagoDet.UseVisualStyleBackColor = True
        '
        'TxtStrDetalle
        '
        Me.TxtStrDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtStrDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStrDetalle.Enabled = False
        Me.TxtStrDetalle.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStrDetalle.Location = New System.Drawing.Point(9, 17)
        Me.TxtStrDetalle.Multiline = True
        Me.TxtStrDetalle.Name = "TxtStrDetalle"
        Me.TxtStrDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtStrDetalle.Size = New System.Drawing.Size(761, 78)
        Me.TxtStrDetalle.TabIndex = 121
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtStrDetalle)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(8, 444)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 101)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Detalles... "
        '
        'FormPrcFormaPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(792, 445)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GrpBox)
        Me.Controls.Add(Me.Table2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BtnPagoDet)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.LblTotalPago)
        Me.Controls.Add(Me.BtnRegPago)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FormPrcFormaPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormPrcFormaPago"
        CType(Me.Table2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBox.ResumeLayout(False)
        Me.GrpBox.PerformLayout()
        Me.GrpBoxBco.ResumeLayout(False)
        Me.GrpBoxBco.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DtpFecDeposito As System.Windows.Forms.DateTimePicker
    Friend WithEvents Table2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents LblNroRecibo As System.Windows.Forms.Label
    Friend WithEvents CboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents LblImpRecibo As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnQuitar As System.Windows.Forms.Button
    Friend WithEvents GrpBox As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBoxBco As System.Windows.Forms.GroupBox
    Friend WithEvents TxtVoucher As System.Windows.Forms.TextBox
    Friend WithEvents CboTipoTarj As System.Windows.Forms.ComboBox
    Friend WithEvents CboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DtpFecPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblTotalPago As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnRegPago As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtImpPago As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents LblTC As System.Windows.Forms.Label
    Friend WithEvents CboNroCta_TarjetaDC As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents nCtaCteForPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDescForPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nPerCtaCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cPerjurCodigoFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEntidadBanca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dCtaCteFecTransacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCtaCtePagTracer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nMonCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDescMoneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nCtaCtePagImpMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nCtaCtePagImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnPagoDet As System.Windows.Forms.Button
    Friend WithEvents TxtStrDetalle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
