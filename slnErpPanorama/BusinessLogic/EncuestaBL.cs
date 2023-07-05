using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EncuestaBL
    {
        public List<EncuestaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                EncuestaDL Encuesta = new EncuestaDL();
                return Encuesta.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EncuestaBE Selecciona(int IdCliente)
        {
            try
            {
                EncuestaDL Encuesta = new EncuestaDL();
                EncuestaBE objEmp = Encuesta.Selecciona(IdCliente);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EncuestaBE SeleccionaDescuento(int IdCliente)
        {
            try
            {
                EncuestaDL Encuesta = new EncuestaDL();
                EncuestaBE objEmp = Encuesta.SeleccionaDescuento(IdCliente);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EncuestaBE pItem)
        {
            try
            {
                EncuestaDL Encuesta = new EncuestaDL();
                Encuesta.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaLista(List<EncuestaBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPrecioDetalle)
                    {
                        EncuestaBE objE_Encuesta = new EncuestaBE();
                        objE_Encuesta = new EncuestaBL().Selecciona(item.IdCliente);
                        if (objE_Encuesta == null)
                        {
                            EncuestaDL objDL_Encuesta = new EncuestaDL();
                            objDL_Encuesta.Inserta(item);                        
                        }
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EncuestaBE pItem)
        {
            try
            {
                EncuestaDL Encuesta = new EncuestaDL();
                Encuesta.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaFlagDescuento(int IdCliente)
        {
            try
            {
                EncuestaDL Encuesta = new EncuestaDL();
                Encuesta.ActualizaFlagDescuento(IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public void ActualizaFlagDescuento(List<EncuestaBE> pListaPrecioDetalle)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            foreach (var item in pListaPrecioDetalle)
        //            {
        //                EncuestaDL objDL_Encuesta = new EncuestaDL();
        //                objDL_Encuesta.ActualizaFlagDescuento(item.IdCliente);
        //            }

        //            ts.Complete();
        //        }
        //    }

        //    catch (Exception ex)
        //    { throw ex; }
        //}


        public void Elimina(int IdCliente)
        {
            try
            {
                EncuestaDL Encuesta = new EncuestaDL();
                Encuesta.Elimina(IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
