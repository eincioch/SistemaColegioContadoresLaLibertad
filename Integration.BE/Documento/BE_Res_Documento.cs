﻿using System;

namespace Integration.BE.Documento
{
    public class BE_Res_Documento
    {
        public string cNumero { get; set; }

        public string cDocCodigo { get; set; }

        public int nDocTipoNum { get; set; }

        public string cDocNDoc { get; set; }

        public string cPerCodigo { get; set; }

        public int nAdministrativo { get; set; }

        public int nAlumno { get; set; }

        public DateTime dDocFecha { get; set; }

        public string cPerApellido { get; set; }
    }
}