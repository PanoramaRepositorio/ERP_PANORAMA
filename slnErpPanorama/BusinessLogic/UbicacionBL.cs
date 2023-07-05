using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class UbicacionBL
    {
        public List<UbicacionBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                UbicacionDL Ubicacion = new UbicacionDL();
                return Ubicacion.ListaTodosActivo(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(UbicacionBE pItem)
        {
            try
            {
                UbicacionDL Ubicacion = new UbicacionDL();
                Ubicacion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(UbicacionBE pItem)
        {
            try
            {
                UbicacionDL Ubicacion = new UbicacionDL();
                Ubicacion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(UbicacionBE pItem)
        {
            try
            {
                UbicacionDL Ubicacion = new UbicacionDL();
                Ubicacion.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
