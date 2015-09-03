using Integration.BE;
using Integration.BE.PerUsuario;
using Integration.DAService;
using System.Data;

namespace Integration.BL
{
    public class BL_PerUsuario
    {
        public DataTable Get_SearhUsuario(BE_ReqSearhUsuario Request)
        {
            //Recuperando registros
            DataTable dt = new DataTable();
            DA_PerUsuario Obj = new DA_PerUsuario();
            return Obj.Get_SearhUsuario(Request);
        }

        public BE_ResGenerico UpdChangePassword(BE_ReqSearhUsuario Request)
        {
            BE_ResGenerico Item = new BE_ResGenerico();
            DA_PerUsuario Obj = new DA_PerUsuario();
            Item = Obj.UpdChangePassword(Request);
            return Item;
        }

        public DataTable Get_CboListUsuario(BE_ReqSearhUsuario Request)
        {
            //Recuperando registros
            DataTable dt = new DataTable();
            DA_PerUsuario Obj = new DA_PerUsuario();
            return Obj.Get_CboListUsuario(Request);
        }
    }
}