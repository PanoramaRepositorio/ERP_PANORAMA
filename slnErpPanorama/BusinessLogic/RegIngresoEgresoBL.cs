using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessLogic
{
    public class RegIngresoEgresoBL 
    {
        public List<RegIngresoEgresoBE> ListaTodosActivo(int IdTipoRegistro, int IdTipificacion)
        {
            try
            {
                RegIngresoEgresoDL DetalleIE = new RegIngresoEgresoDL();
                return DetalleIE.ListaTodosActivo(IdTipoRegistro, IdTipificacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<RegIngresoEgresoBE> Listar(string Buscartipificacion)
        {
            try
            {
                RegIngresoEgresoDL Tabla = new RegIngresoEgresoDL();
                return Tabla.Listar(Buscartipificacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<RegIngresoEgresoBE> ListarPorTipificacion(string Buscartipificacion)
        {
            try
            {
                RegIngresoEgresoDL Tabla = new RegIngresoEgresoDL();
                return Tabla.Listar(Buscartipificacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(RegIngresoEgresoBE pItem)
        {
            try
            {
                RegIngresoEgresoDL SubTipificaciones = new RegIngresoEgresoDL();
                SubTipificaciones.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(RegIngresoEgresoBE pItem)
        {
            try
            {
                RegIngresoEgresoDL SubTipificaciones = new RegIngresoEgresoDL();
                SubTipificaciones.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
