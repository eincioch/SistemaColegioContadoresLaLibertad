Imports Integration.BE
Imports Integration.BL

Module mdlVariblesG

    Public frm As New FormPrcFormaPagoDetalle

    'para Contante
    'Public RequestConst As New BE.Constante.BE_ReqConstante
    Public ObjConst As New BL_Constante

    'Para Photos
    Public RequestImg As New Persona.BE_ReqPerPhoto
    Public ObjImg As New BL_Persona

    'para Interface
    Public RequestInterface As New [Interface].BE_ReqInterface
    Public ObjInterface As New BL_Interface

    'Interface configuration
    Public BLInterfaceCFG As New BL_Interface

    Public StrUser As String 'Usuario actual del sistema logeado
    Public StrcPerJuridica As String 'cPerCodigo Empresa actual

    Public StrNroDocuPersona As String

    Public FieldFoto As Byte()

    Public StrPasaValores As String 'TokenKey

    Public nOperacion As Integer
    Public OperacionPago As Integer = 0

    Public nFormPerPredeterminado As Integer

    Public cPathRPT As String 'para los reportes
    Public cNroCaja As String 'la sabe que nro de caja es

    'var. fecha del servidor
    Public dFechaSistema As String

    REM ----------
    REM constante
    REM ----------
    REM 1013 natural
    Public Const nConPerNatural As Double = 1013
    REM 1012 juridica
    Public Const nConPerJuridica As Double = 1012

    Public nAccionBotones As Long

    Public Enum nAccionButton
        nAccionNuevo = 1000
        nAccionGrabar = 1001
        nAccionCancel = 1002
        nAccionEdit = 1002
        nAccionFind = 1004
        nAccionCerrar = 1005
    End Enum

    Public Enum nConTipoPersona
        nPerNatural = 1
        nPerJuridica = 2
    End Enum

    Public Enum nConTipoDocPerNatural
        nDNI = 25
    End Enum

    Public Enum nConTipoDocPerJuridica
        nRUC = 11
    End Enum

    Public Enum nFomaPago
        nEfectivo = 1
        nTarjetaCred = 2
        nDepositoBco = 3
    End Enum

    Public Enum nTipoMoneda
        nSoles = 1
        nDolar = 2
        nEuros = 3
    End Enum

End Module