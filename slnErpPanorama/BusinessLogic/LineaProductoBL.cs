using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class LineaProductoBL
    {
        public List<LineaProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                LineaProductoDL LineaProducto = new LineaProductoDL();
                return LineaProducto.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LineaProductoBE> ListaTodosActivoKardex(int IdEmpresa)
        {
            try
            {
                LineaProductoDL LineaProducto = new LineaProductoDL();
                return LineaProducto.ListaTodosActivoKardex(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LineaProductoBE> ListaTodosActivoFamilia(int IdEmpresa, int IdFamiliaProducto)
        {
            try
            {
                LineaProductoDL LineaProducto = new LineaProductoDL();
                return LineaProducto.ListaTodosActivoFamilia(IdEmpresa, IdFamiliaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(LineaProductoBE pItem)
        {
            try
            {
                LineaProductoDL LineaProducto = new LineaProductoDL();
                LineaProducto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(LineaProductoBE pItem)
        {
            try
            {
                LineaProductoDL LineaProducto = new LineaProductoDL();
                LineaProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(LineaProductoBE pItem)
        {
            try
            {
                LineaProductoDL LineaProducto = new LineaProductoDL();
                LineaProducto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}


