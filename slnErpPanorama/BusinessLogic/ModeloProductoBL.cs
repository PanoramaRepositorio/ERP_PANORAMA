using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ModeloProductoBL
    {
        public List<ModeloProductoBE> ListaTodosActivo(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto)
        {
            try
            {
                ModeloProductoDL ModeloProducto = new ModeloProductoDL();
                return ModeloProducto.ListaTodosActivo(IdEmpresa, IdLineaProducto, IdSubLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ModeloProductoBE> ListaTodos(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto)
        {
            try
            {
                ModeloProductoDL ModeloProducto = new ModeloProductoDL();
                return ModeloProducto.ListaTodos(IdEmpresa, IdLineaProducto, IdSubLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ModeloProductoBE Selecciona(int IdEmpresa, int IdModeloProducto)
        {
            try
            {
                ModeloProductoDL ModeloProducto = new ModeloProductoDL();
                return ModeloProducto.Selecciona(IdEmpresa, IdModeloProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ModeloProductoBE pItem)
        {
            try
            {
                ModeloProductoDL ModeloProducto = new ModeloProductoDL();
                ModeloProducto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ModeloProductoBE pItem)
        {
            try
            {
                ModeloProductoDL ModeloProducto = new ModeloProductoDL();
                ModeloProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ModeloProductoBE pItem)
        {
            try
            {
                ModeloProductoDL ModeloProducto = new ModeloProductoDL();
                ModeloProducto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
