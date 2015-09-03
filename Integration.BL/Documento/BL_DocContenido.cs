using Integration.BE.Documento;
using Integration.DAService.Documento;

namespace Integration.BL.Documento
{
    public class BL_DocContenido
    {
        //Store Procedure para Constante (Insert y Update)
        public bool InsDocContenido(BE_ReqDocContenido Request)
        {
            DA_DocContenido Obj = new DA_DocContenido();
            return Obj.InsDocContenido(Request); ;
        }
    }
}