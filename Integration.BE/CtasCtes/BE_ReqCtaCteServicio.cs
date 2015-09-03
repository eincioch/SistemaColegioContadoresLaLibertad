﻿namespace Integration.BE.CtasCtes
{
    public class BE_ReqCtaCteServicio
    {
        public long nCtaCteSerCodigo { get; set; }

        public string cPerJurCodigo { get; set; }

        public string cCtaCteSerJerarquia { get; set; }

        public string cCtaCteSerKeyWord { get; set; }

        public long nBieCodigo { get; set; }

        public long nCtaCteSerAfecto { get; set; }

        public long nCtaCteSerExonerado { get; set; }

        public long nMonCodigo { get; set; }

        public double nCtaCteSerImpMin { get; set; }

        public double nCtaCteSerImpMax { get; set; }

        public double nCtaCteSerImpDef { get; set; }

        public int nSeuCodigo { get; set; }

        public long nCtaCteSerFacturable { get; set; }

        public long nCtaCteTipoCta { get; set; }

        public long nCtaAlterna { get; set; }
    }

    public class BE_ReqCtaCteSerImpuesto
    {
        public string cPerJurCodigo { get; set; }

        public long nCtaCteSerCodigo { get; set; }

        public long nSysTasContry { get; set; }

        public long nSysTasCodigo { get; set; }
    }

    public class BE_ReqServicioporTipoCta
    {
        public long nCtaCteTipoCta { get; set; }
    }

    public class BE_ReqCtaCteServBusca
    {
        public long nCtaCteSerCodigo { get; set; }

        public string cPerJurCodigo { get; set; }

        public string nFlag { get; set; }

        public long nCtaCteTipoCta { get; set; }
    }

    public class BE_ReqCtaCteSerImpDefault
    {
        public string cPerJurCodigo { get; set; }

        public long nCtaCteSerCodigo { get; set; }
    }
}