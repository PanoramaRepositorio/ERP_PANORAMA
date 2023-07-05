using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SectorBL
    {
        public List<SectorBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                return Sector.ListaTodosActivo(IdEmpresa, IdTienda, IdAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SectorBE pItem)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                Sector.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SectorBE pItem)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                Sector.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SectorBE pItem)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                Sector.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
