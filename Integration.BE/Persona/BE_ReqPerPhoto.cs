﻿using System;

namespace Integration.BE.Persona
{
    public class BE_ReqPerPhoto
    {
        public string cPerCodigo { get; set; }

        public long nPerTipImagen { get; set; }

        public Byte[] iPerImaFoto { get; set; }

        public string cUltimaPhoto { get; set; }
    }
}