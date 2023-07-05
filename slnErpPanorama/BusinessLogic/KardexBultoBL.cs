using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class KardexBultoBL
    {
        public List<KardexBultoBE> ListaTodosActivo(int IdEmpresa, int IdAlmacen)
        {
            try
            {
                KardexBultoDL KardexBulto = new KardexBultoDL();
                return KardexBulto.ListaTodosActivo(IdEmpresa, IdAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBultoBE> ListaInventario(int IdEmpresa, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                KardexBultoDL KardexBulto = new KardexBultoDL();
                return KardexBulto.ListaInventario(IdEmpresa, IdProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBultoBE> ListaInventarioDetalle(int IdEmpresa, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                KardexBultoDL KardexBulto = new KardexBultoDL();
                return KardexBulto.ListaInventarioDetalle(IdEmpresa, IdAlmacen, IdProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(KardexBultoBE pItem)
        {
            try
            {
                Int32 IdKardexBulto = 0;
                KardexBultoDL KardexBulto = new KardexBultoDL();
                IdKardexBulto = KardexBulto.Inserta(pItem);

                return IdKardexBulto = 0;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(KardexBultoBE pItem)
        {
            try
            {
                KardexBultoDL KardexBulto = new KardexBultoDL();
                KardexBulto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(KardexBultoBE pItem)
        {
            try
            {
                KardexBultoDL KardexBulto = new KardexBultoDL();
                KardexBulto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
