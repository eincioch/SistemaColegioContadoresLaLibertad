using Integration.BE.Documento;
using Integration.DAService.Documento;

namespace Integration.BL.Documento
{
    public class BL_DocIdentifica
    {
        //Store Procedure para Constante (Insert y Update)
        public bool InsDocIdentifica(BE_ReqDocIdentifica Request)
        {
            DA_DocIdentifica Obj = new DA_DocIdentifica();
            return Obj.InsDocIdentifica(Request);
        }
    }
}