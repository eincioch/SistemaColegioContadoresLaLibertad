﻿using System;

namespace Integration.BE.TraDoc
{
    public class BE_Req_TraDoc
    {
        public string cPerCodigo { get; set; }

        public int nPrdCodigo { get; set; }

        public int nDocTipo { get; set; }

        public string cDocNDoc { get; set; }

        public string cDocCodigo { get; set; }

        public DateTime dDocFecha { get; set; }

        public string cDocObserv { get; set; }

        public int nDocEstado { get; set; }

        public string Asunto { get; set; }

        public string Detalle { get; set; }

        public DateTime dFechaIni { get; set; }

        public DateTime dFechaFin { get; set; }

        public string CodPerSolicita { get; set; }

        public int PerRelSolicita { get; set; }

        public int CodUORemite { get; set; }

        public int nDocPerTipo { get; set; }

        public string CodPerRegistra { get; set; }

        public string CodPerRecibe { get; set; }

        public int CodUODestino { get; set; }

        public int NumDocumento { get; set; }

        public int DocEstado { get; set; }

        public int nPerRemFiltro { get; set; }

        public int nPerRecFiltro { get; set; }

        public int nDocNumFiltro { get; set; }

        public int nItemFiltro { get; set; }

        public int nAsuFiltro { get; set; }

        public string cDocConContenido { get; set; }

        public string cInvPerCodigo { get; set; }

        public int nFilMes { get; set; }

        public int iOpcion { get; set; }

        public string cDocEstado { get; set; }

        public int nMesCodigo { get; set; }

        public string cUniOrgTransferencia { get; set; }

        public string cDocPerTipo { get; set; }

        public string cFecIni { get; set; }

        public Int32 nUniOrgCodigo { get; set; }
    }
}