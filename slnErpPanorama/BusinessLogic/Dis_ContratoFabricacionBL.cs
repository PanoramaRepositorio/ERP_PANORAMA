using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_ContratoFabricacionBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<Dis_ContratoFabricacionBE> ListaTodosActivo(int IdEmpresa,int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                return Dis_ContratoFabricacion.ListaTodosActivo(IdEmpresa, IdVendedor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<Dis_ContratoFabricacionBE> ListaProyecto(int IdEmpresa, int IdProyecto)
        {
            try
            {
                Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                return Dis_ContratoFabricacion.ListaProyecto(IdEmpresa, IdProyecto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<Dis_ContratoFabricacionBE> ListaTracking(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                return Dis_ContratoFabricacion.ListaTracking(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Dis_ContratoFabricacionBE Selecciona(int IdDis_ContratoFabricacion)
        {
            try
            {
                Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                return Dis_ContratoFabricacion.Selecciona(IdDis_ContratoFabricacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Dis_ContratoFabricacionBE SeleccionaNumero(int Periodo, string Numero)
        {
            try
            {
                Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                return Dis_ContratoFabricacion.SeleccionaNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_ContratoFabricacionBE pItem, List<Dis_ContratoFabricacionDetalleBE> pListaDis_ContratoFabricacionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                    Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();

                    int IdDis_ContratoFabricacion = 0;
                    IdDis_ContratoFabricacion = Dis_ContratoFabricacion.Inserta(pItem);

                    foreach (Dis_ContratoFabricacionDetalleBE item in pListaDis_ContratoFabricacionDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdDis_ContratoFabricacion = IdDis_ContratoFabricacion;
                        Dis_ContratoFabricacionDetalle.Inserta(item);
                    }

                    //Actualizamos correlativos de diseño
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intIdPanoramaDistribuidores, Parametros.intTipoDocContratoFabricacion, pItem.Periodo);


                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_ContratoFabricacionBE pItem, List<Dis_ContratoFabricacionDetalleBE> pListaDis_ContratoFabricacionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                    Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();


                    foreach (Dis_ContratoFabricacionDetalleBE item in pListaDis_ContratoFabricacionDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdDis_ContratoFabricacion = pItem.IdDis_ContratoFabricacion;
                            Dis_ContratoFabricacionDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            Dis_ContratoFabricacionDetalle.Actualiza(item);
                        }
                    }

                    Dis_ContratoFabricacion.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_ContratoFabricacionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                    Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();

                    List<Dis_ContratoFabricacionDetalleBE> lstDis_ContratoFabricacionDetalle = null;
                    lstDis_ContratoFabricacionDetalle = Dis_ContratoFabricacionDetalle.ListaTodosActivo(pItem.IdDis_ContratoFabricacion);

                    foreach (Dis_ContratoFabricacionDetalleBE item in lstDis_ContratoFabricacionDetalle)
                    {
                        Dis_ContratoFabricacionDetalle.Elimina(item);
                    }

                    //Eliminamos el Solicitud Principal
                    Dis_ContratoFabricacion.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCerrado(int IdDis_ContratoFabricacion, bool FlagCerrado)
        {
            try
            {
                Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                Dis_ContratoFabricacion.ActualizaCerrado(IdDis_ContratoFabricacion, FlagCerrado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaAtender(int IdDis_ContratoFabricacion, string Usuario)
        {
            try
            {
                Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                Dis_ContratoFabricacion.ActualizaAtender(IdDis_ContratoFabricacion, Usuario);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEncuesta(Dis_ContratoFabricacionBE pItem)
        {
            try
            {
                Dis_ContratoFabricacionDL Dis_ContratoFabricacion = new Dis_ContratoFabricacionDL();
                Dis_ContratoFabricacion.ActualizaEncuesta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
