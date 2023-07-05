using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessLogic
{
    public class IngresoEgresoBL
    {
        public List<IngresoEgresoBE> Listar(string Buscar)
        {
            try
            {
                IngresoEgresoDL Tabla = new IngresoEgresoDL();
                return Tabla.Listar(Buscar);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(IngresoEgresoBE pItem)
        {
            try
            {
                IngresoEgresoDL IngresoEgreso = new IngresoEgresoDL();
                IngresoEgreso.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(IngresoEgresoBE pItem)
        {
            try
            {
                IngresoEgresoDL SubTipificaciones = new IngresoEgresoDL();
                SubTipificaciones.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
