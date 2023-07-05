using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessLogic
{
    public class TipificacionesBL
    {
        public List<TipificacionesBE> Listar(string Buscartipificacion)
        {
            try
            {
                TipificacionesDL Tabla = new TipificacionesDL();
                return Tabla.Listar(Buscartipificacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipificacionesBE> ListarPorTipoGestion(string pIdTipoGestion)
        {
            try
            {
                TipificacionesDL Tabla = new TipificacionesDL();
                return Tabla.ListarPorTipoGestion(pIdTipoGestion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipificacionesBE> ListarIdTipificacion(int pIdTipificacion)
        {
            try
            {
                TipificacionesDL Tabla = new TipificacionesDL();
                return Tabla.ListarIdTipificacion(pIdTipificacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipificacionesBE pItem)
        {
            try
            {
                TipificacionesDL Tipificaciones = new TipificacionesDL();
                Tipificaciones.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipificacionesBE pItem)
        {
            try
            {
                TipificacionesDL Tipificaciones = new TipificacionesDL();
                Tipificaciones.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
