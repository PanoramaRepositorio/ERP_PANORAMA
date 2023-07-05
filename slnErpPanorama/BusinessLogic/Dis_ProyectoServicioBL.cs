using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_ProyectoServicioBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<Dis_ProyectoServicioBE> ListaTodosActivo(int IdEmpresa,DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                return Dis_ProyectoServicio.ListaTodosActivo(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<Dis_ProyectoServicioBE> ListaSituacionCliente(int IdEmpresa, int IdCliente, int IdSituacion)
        {
            try
            {
                Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                return Dis_ProyectoServicio.ListaSituacionCliente(IdEmpresa, IdCliente, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Dis_ProyectoServicioBE Selecciona(int IdDis_ProyectoServicio)
        {
            try
            {
                Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                Dis_ProyectoServicioBE objAna = Dis_ProyectoServicio.Selecciona(IdDis_ProyectoServicio);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Dis_ProyectoServicioBE SeleccionaNumero(int Periodo, string Numero)
        {
            try
            {
                Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                Dis_ProyectoServicioBE objAna = Dis_ProyectoServicio.SeleccionaNumero(Periodo, Numero);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public  Int32 Inserta(Dis_ProyectoServicioBE pItem, List<Dis_DisenoFuncionalBE> pListaDis_DisenoFuncional, List<Dis_DisenoEsteticoBE> pListaDis_DisenoEstetico)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                    Dis_DisenoFuncionalDL Dis_DisenoFuncional = new Dis_DisenoFuncionalDL();
                    Dis_DisenoEsteticoDL Dis_DisenoEstetico = new Dis_DisenoEsteticoDL();
                    Dis_DisenoVisitasEfectuadasDL Dis_DisenoVisitasRealizadas = new Dis_DisenoVisitasEfectuadasDL();

                    int IdDis_ProyectoServicioN = 0;
                    IdDis_ProyectoServicioN = Dis_ProyectoServicio.Inserta(pItem);

                    foreach (Dis_DisenoFuncionalBE item in pListaDis_DisenoFuncional)
                    {
                        //Insertamos el diseño Funcional
                        item.IdDis_ProyectoServicio = IdDis_ProyectoServicioN;
                        Dis_DisenoFuncional.Inserta(item);
                    }

                    foreach (Dis_DisenoEsteticoBE item in pListaDis_DisenoEstetico)
                    {
                        //Insertamos el diseño Estetico
                        item.IdDis_ProyectoServicio = IdDis_ProyectoServicioN;
                        Dis_DisenoEstetico.Inserta(item);
                    }

                    //Visitas Realizadas
                    //foreach (Dis_DisenoVisitasRealizadasBE item in pListaDis_DisenoVisitasRealizadas)
                    //{
                    //    //Insertamos 
                    //    item.IdDis_ProyectoServicio = IdDis_ProyectoServicioN;
                    //    Dis_DisenoVisitasRealizadas.Inserta(item);
                    //}

                    //Actualizamos correlativos de diseño
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intIdPanoramaDistribuidores, Parametros.intTipoDocProyectoServicio, pItem.Periodo);

                    ts.Complete();

                    return IdDis_ProyectoServicioN;


                }
            }
            catch (Exception ex)
            { throw ex; }

        }


        public void InsertaVisitas(List<CuentaBancoBE> pListaItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaBancoDL CuentaBancoProvee = new CuentaBancoDL();

                    foreach (CuentaBancoBE item in pListaItem)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            CuentaBancoProvee.InsertaCuentaBancoProveedor(item);
                        }
                        else //if (item.TipoOper == Convert.ToInt32(Operacion.Modificar))
                        {
                            CuentaBancoProvee.ActualizaCuentaBancoProveedor(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }



        public void Actualiza(Dis_ProyectoServicioBE pItem, List<Dis_DisenoFuncionalBE> pListaDis_DisenoFuncional, List<Dis_DisenoEsteticoBE> pListaDis_DisenoEstetico)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                    Dis_DisenoFuncionalDL Dis_DisenoFuncional = new Dis_DisenoFuncionalDL();
                    Dis_DisenoEsteticoDL Dis_DisenoEstetico = new Dis_DisenoEsteticoDL();
                    Dis_DisenoVisitasEfectuadasDL Dis_DisenoVisitasEfectuadas = new Dis_DisenoVisitasEfectuadasDL();

                    foreach (Dis_DisenoFuncionalBE item in pListaDis_DisenoFuncional)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el diseño Funcional
                            item.IdDis_ProyectoServicio = pItem.IdDis_ProyectoServicio;
                            Dis_DisenoFuncional.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            Dis_DisenoFuncional.Actualiza(item);
                        }
                    }

                    foreach (Dis_DisenoEsteticoBE item in pListaDis_DisenoEstetico)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el diseño Estetico
                            item.IdDis_ProyectoServicio = pItem.IdDis_ProyectoServicio;
                            Dis_DisenoEstetico.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            Dis_DisenoEstetico.Actualiza(item);
                        }
                    }

                    Dis_ProyectoServicio.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(Dis_ProyectoServicioBE pItem)
        {
            try
            {
                Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                Dis_ProyectoServicio.ActualizaSituacion(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaCierre(Dis_ProyectoServicioBE pItem)
        {
            try
            {
                Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                Dis_ProyectoServicio.ActualizaCierre(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_ProyectoServicioBE pItem)
        {
            try
            {
                Dis_ProyectoServicioDL Dis_ProyectoServicio = new Dis_ProyectoServicioDL();
                Dis_ProyectoServicio.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
