using Integration.BE.Documento;
using Integration.DAService.Documento;

namespace Integration.BL.Documento
{
    public class BL_DocFecTramite
    {
        //Store Procedure para Constante (Insert y Update)
        public bool InsDocFecTramite(BE_ReqDocFecTramite Request)
        {
            DA_DocFecTramite Obj = new DA_DocFecTramite();
            return Obj.InsDocFecTramite(Request);
        }
    }
}