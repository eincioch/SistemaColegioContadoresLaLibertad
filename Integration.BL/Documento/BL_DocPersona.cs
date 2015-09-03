using Integration.BE.Documento;
using Integration.DAService.Documento;

namespace Integration.BL.Documento
{
    public class BL_DocPersona
    {
        //Store Procedure para Constante (Insert y Update)
        public bool InsDocPersona(BE_ReqDocPersona Request)
        {
            DA_DocPersona Obj = new DA_DocPersona();
            return Obj.InsDocPersona(Request);
        }
    }
}