using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SubLineaProductoBL
    {
        public List<SubLineaProductoBE> ListaTodosActivo(int IdEmpresa, int IdLineaProducto)
        {
            try
            {
                SubLineaProductoDL SubLineaProducto = new SubLineaProductoDL();
                return SubLineaProducto.ListaTodosActivo(IdEmpresa, IdLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SubLineaProductoBE> ListaTodos(int IdEmpresa, int IdLineaProducto)
        {
            try
            {
                SubLineaProductoDL SubLineaProducto = new SubLineaProductoDL();
                return SubLineaProducto.ListaTodos(IdEmpresa, IdLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SubLineaProductoBE pItem)
        {
            try
            {
                SubLineaProductoDL SubLineaProducto = new SubLineaProductoDL();
                SubLineaProducto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SubLineaProductoBE pItem)
        {
            try
            {
                SubLineaProductoDL SubLineaProducto = new SubLineaProductoDL();
                SubLineaProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SubLineaProductoBE pItem)
        {
            try
            {
                SubLineaProductoDL SubLineaProducto = new SubLineaProductoDL();
                SubLineaProducto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
