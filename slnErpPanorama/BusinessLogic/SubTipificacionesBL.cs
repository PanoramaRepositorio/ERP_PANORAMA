using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessLogic
{
    public class SubTipificacionesBL
    {
        public List<SubTipificacionesBE> Listar(string Buscartipificacion)
        {
            try
            {
                SubTipificacionesDL Tabla = new SubTipificacionesDL();
                return Tabla.Listar(Buscartipificacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SubTipificacionesBE> ListarPorTipificacion(string Buscartipificacion)
        {
            try
            {
                SubTipificacionesDL Tabla = new SubTipificacionesDL();
                return Tabla.Listar(Buscartipificacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SubTipificacionesBE pItem)
        {
            try
            {
                SubTipificacionesDL SubTipificaciones = new SubTipificacionesDL();
                SubTipificaciones.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SubTipificacionesBE pItem)
        {
            try
            {
                SubTipificacionesDL SubTipificaciones = new SubTipificacionesDL();
                SubTipificaciones.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
