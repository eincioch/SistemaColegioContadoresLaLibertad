using Integration.BE.Documento;
using Integration.DAService.Documento;

namespace Integration.BL.Documento
{
    public class BL_GeneraNewIdcDocCodigo
    {
        public string Get_NewIdcDocCodigo(BE_GeneraNewIdcDocCodigo Request)
        {
            DA_NewIdcDocCodigo Obj = new DA_NewIdcDocCodigo();
            return Obj.Get_NewIdcDocCodigo(Request);
        }
    }
}