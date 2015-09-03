using Integration.BE.TraDoc;
using Integration.DAService;
using System.Data;

namespace Integration.BL
{
    public class BL_TraDoc
    {
        public DataTable get_TraDoc_Procesos(BE_Req_TraDoc Request)
        {
            DATraDoc ObjTraDoc = new DATraDoc();
            return ObjTraDoc.get_TraDoc_Procesos(Request);
        }
    }
}