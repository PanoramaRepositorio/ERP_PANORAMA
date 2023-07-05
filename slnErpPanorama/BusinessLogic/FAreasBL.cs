using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessLogic
{
    public class FAreasBL
    {
        public List<FAreasBE> Listar(string pBuscar)
        {
            try
            {
                FAreasDL Tabla = new FAreasDL();
                return Tabla.Listar(pBuscar);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(FAreasBE pItem)
        {
            try
            {
                FAreasDL FAreas = new FAreasDL();
                FAreas.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(FAreasBE pItem)
        {
            try
            {
                FAreasDL SubTipificaciones = new FAreasDL();
                SubTipificaciones.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
