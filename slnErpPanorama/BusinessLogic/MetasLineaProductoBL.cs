using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MetasLineaProductoBL
    {
        public List<MetasLineaProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                MetasLineaProductoDL MetasLineaProducto = new MetasLineaProductoDL();
                return MetasLineaProducto.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MetasLineaProductoBE Selecciona(int IdEmpresa, int IdMetasLineaProducto)
        {
            try
            {
                MetasLineaProductoDL MetasLineaProducto = new MetasLineaProductoDL();
                return MetasLineaProducto.Selecciona(IdEmpresa, IdMetasLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MetasLineaProductoBE pItem)
        {
            try
            {
                MetasLineaProductoDL MetasLineaProducto = new MetasLineaProductoDL();
                MetasLineaProducto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MetasLineaProductoBE pItem)
        {
            try
            {
                MetasLineaProductoDL MetasLineaProducto = new MetasLineaProductoDL();
                MetasLineaProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MetasLineaProductoBE pItem)
        {
            try
            {
                MetasLineaProductoDL MetasLineaProducto = new MetasLineaProductoDL();
                MetasLineaProducto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
