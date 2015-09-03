using Integration.BE;
using Integration.BE.CtasCtes;
using Integration.DAService.DA_CtaCte;
using System.Data;

namespace Integration.BL.BL_CtaCtes
{
    public class BL_CtaCteSerImpuesto
    {
        //------------------------
        //Insert CtaCteSerImpuesto
        //------------------------
        public BE_ResGenerico Ins_CtaCteSerImpuesto(BE_ReqCtaCteSerImpuesto Request)
        {
            BE_ResGenerico Item = new BE_ResGenerico();
            DA_CtaCteSerImpuesto Obj = new DA_CtaCteSerImpuesto();
            Item = Obj.Ins_CtaCteSerImpuesto(Request);
            return Item;
        }

        //------------------------
        //Delete CtaCteSerImpuesto
        //------------------------
        public BE_ResGenerico Del_CtaCteSerImpuesto(BE_ReqCtaCteSerImpuesto Request)
        {
            BE_ResGenerico Item = new BE_ResGenerico();
            DA_CtaCteSerImpuesto Obj = new DA_CtaCteSerImpuesto();
            Item = Obj.Del_CtaCteSerImpuesto(Request);
            return Item;
        }

        //------------------------
        //select CtaCteSerImpuesto
        //------------------------
        public DataTable Get_CtaCteSerImpuesto(BE_ReqCtaCteSerImpuesto Request)
        {
            //Recuperando registros
            DA_CtaCteSerImpuesto Obj = new DA_CtaCteSerImpuesto();
            return Obj.Get_CtaCteSerImpuesto(Request);
        }
    }
}