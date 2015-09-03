using Integration.BE.Documento;
using Integration.DAService.Documento;

namespace Integration.BL.Documento
{
    public class BL_DocVigencia
    {
        //Store Procedure para Constante (Insert y Update)
        public bool InsDocVigencia(BE_ReqDocVigencia Request)
        {
            DA_DocVigencia Obj = new DA_DocVigencia();
            return Obj.InsDocVigencia(Request);
        }
    }
}