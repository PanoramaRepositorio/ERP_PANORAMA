using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MovimientoPedidoBL
    {
        public List<MovimientoPedidoBE> ListaTodosActivo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta, int Periodo, string Numero)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.ListaTodosActivo(IdEmpresa, FechaDesde, FechaHasta, TipoConsulta, Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoPedidoBE> ListaNumero(int Periodo, string Numero)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.ListaNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoPedidoBE> ListaPersonalPickingDisponible(int IdEmpresa, DateTime Fecha)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.ListaPersonalPickingDisponible(IdEmpresa, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoPedidoBE SeleccionaDespacho(int IdPedido)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.SeleccionaDespacho(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoPedidoBE Selecciona(int IdPedido)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.Selecciona(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoPedidoBE SeleccionaChequeo(int IdPedido)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.SeleccionaChequeo(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoPedidoBE SeleccionaDireccionEnvio(int IdPedido)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.SeleccionaDireccionEnvio(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }



        //public void Inserta(MovimientoPedidoBE pItem)
        //{
        //    try
        //    {
        //        MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
        //        MovimientoPedido.Inserta(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Actualiza(MovimientoPedidoBE pItem)
        //{
        //    try
        //    {
        //        MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
        //        MovimientoPedido.Actualiza(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Elimina(MovimientoPedidoBE pItem)
        //{
        //    try
        //    {
        //        MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
        //        MovimientoPedido.Elimina(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public void ActualizaSituacion(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaSituacion(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaAuxiliar(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaAuxiliar(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEmbalador(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaEmbalador(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDespachador(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaDespachador(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaOrigenDespacho(int IdPedido, string OrigenDespacho)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaOrigenDespacho(IdPedido, OrigenDespacho);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaConductor(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaConductor(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaConductorDespacho(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaConductorDespacho(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void ActualizaChequeador(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaChequeador(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCierreChequeado(MovimientoPedidoBE pItem)
        {
            try
            {
                PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                PedidoBL objBL_Pedido = new PedidoBL();

                List<PedidoDetalleBE> lstTmpPedidoDetalleMenor = new List<PedidoDetalleBE>();
                List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(pItem.IdPedido);

                //foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                //{
                //    if (item.CantidadChequeo == 0)
                //    {
                //        PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                //        objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                //        objE_PedidoDetalle.IdPedido = item.IdPedido;
                //        objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                //        objE_PedidoDetalle.Item = item.Item;
                //        objE_PedidoDetalle.IdProducto = item.IdProducto;
                //        objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                //        objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                //        objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                //        objE_PedidoDetalle.Cantidad = item.Cantidad;
                //        objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
                //        objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                //        objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                //        objE_PedidoDetalle.Descuento = item.Descuento;
                //        objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                //        objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                //        objE_PedidoDetalle.Observacion = item.Observacion;
                //        objE_PedidoDetalle.IdKardex = item.IdKardex;
                //        objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                //        objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen; //add
                //        objE_PedidoDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle; //add
                //        objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                //        objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                //        objE_PedidoDetalle.IdPromocion = item.IdPromocion;
                //        objE_PedidoDetalle.DescPromocion = item.DescPromocion;
                //        objE_PedidoDetalle.FlagBultoCerrado = item.FlagBultoCerrado;
                //        objE_PedidoDetalle.FlagNacional = item.FlagNacional;
                //        objE_PedidoDetalle.PorcentajeDescuentoInicial = 0;
                //        objE_PedidoDetalle.IdLineaProducto = 0;
                //        objE_PedidoDetalle.FlagEstado = false;
                //        objE_PedidoDetalle.TipoOper = item.TipoOper;

                //        objBL_PedidoDetalle.Elimina(objE_PedidoDetalle);
                //        //mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);
                //    }
                //    else
                //    if (item.CantidadChequeo < item.Cantidad)
                //    {
                //        PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                //        objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                //        objE_PedidoDetalle.IdPedido = item.IdPedido;
                //        objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                //        objE_PedidoDetalle.Item = item.Item;
                //        objE_PedidoDetalle.IdProducto = item.IdProducto;
                //        objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                //        objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                //        objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                //        objE_PedidoDetalle.Cantidad = item.CantidadChequeo;
                //        objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
                //        objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                //        objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                //        objE_PedidoDetalle.Descuento = item.Descuento;
                //        objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                //        objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                //        objE_PedidoDetalle.Observacion = item.Observacion;
                //        objE_PedidoDetalle.IdKardex = item.IdKardex;
                //        objE_PedidoDetalle.IdAlmacen = item.IdAlmacen;
                //        objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen;
                //        objE_PedidoDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                //        objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                //        objE_PedidoDetalle.FlagRegalo = false;
                //        objE_PedidoDetalle.FlagBultoCerrado = item.FlagBultoCerrado;
                //        objE_PedidoDetalle.IdPromocion = item.IdPromocion;
                //        objE_PedidoDetalle.DescPromocion = item.DescPromocion;
                //        objE_PedidoDetalle.FlagEstado = true;
                //        objE_PedidoDetalle.TipoOper = 2;// item.TipoOper;
                //        lstTmpPedidoDetalleMenor.Add(objE_PedidoDetalle); //add 0805

                //        //objBL_PedidoDetalle.Actualiza(objE_PedidoDetalle);
                //    }
                //}

                //PedidoBE objE_Pedido2 = new PedidoBE();
                //objE_Pedido2 = objBL_Pedido.Selecciona(pItem.IdPedido);

                //objBL_Pedido.Actualiza(objE_Pedido2, lstTmpPedidoDetalleMenor);


                #region "Calcular Totales"

                ////if (FlagPromocion2x1 == true)
                ////{
                ////    CalculaTotalPromocion2x1();
                ////    return;
                ////}

                //decimal deImpuesto = 0;
                //decimal deValorVenta = 0;
                //decimal deSubTotal = 0;
                //decimal deTotal = 0;
                //decimal deTotalBruto = 0;
                ////decimal deTotal2 = 0;
                //int intTotalCantidad = 0;

                //lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(pItem.IdPedido);

                //if (lstTmpPedidoDetalle.Count > 0)
                //{
                //    foreach (var item in lstTmpPedidoDetalle)
                //    {
                //        intTotalCantidad = intTotalCantidad + item.Cantidad;
                //        deValorVenta = item.ValorVenta;
                //        deTotal = deTotal + deValorVenta;
                //    }

                //    //txtTotalBruto.EditValue = 0;//add may 25

                //    //if (mListaPromocionVale.Count > 0)//add 250516
                //    //{
                //    //    CalculaTotalesVale(intTotalCantidad, deTotal);
                //    //    return;
                //    //}

                //    deTotal = Math.Round(deTotal, 2);
                //    deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                //    deImpuesto = deTotal - deSubTotal; //Math.Round((deTotal - deSubTotal),2);
                //    deImpuesto = Math.Round(deImpuesto, 2);
                //    //txtTotalBruto.EditValue = 0;//add may 25

                //}
                //else
                //{
                //    deTotal = 0;
                //    deSubTotal = 0;
                //    deImpuesto = 0;
                //    deTotalBruto = 0;
                //}

                //PedidoBE objE_Pedido = new PedidoBE();
                ////PedidoBL objBL_Pedido = new PedidoBL();

                //objE_Pedido = objBL_Pedido.Selecciona(pItem.IdPedido);
                //objE_Pedido.TotalCantidad = intTotalCantidad;
                //objE_Pedido.SubTotal = deSubTotal;
                //objE_Pedido.Igv = deImpuesto;
                //objE_Pedido.Total = deTotal;
                //objE_Pedido.TotalBruto = deTotalBruto;

                //objBL_Pedido.ActualizaCabecera(objE_Pedido);


                #endregion

                //Movimiento Almacén
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaCierreChequeado(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCierrePicking(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaCierrePicking(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaCierreCalidad(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaCierreCalidad(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaCierreEmbalaje2(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaCierreEmbalaje2(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCierreEmbalaje(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaCierreEmbalaje(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEstado(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaEstado(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaObservacion(int IdPedido, string Observacion)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaObservacion(IdPedido, Observacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDespacho(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaDespacho(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCantidadBulto(MovimientoPedidoBE pItem)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaCantidadBulto(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoPedidoBE> ListaPadron(string NumeroRuc)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.ListaPadron(NumeroRuc);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaTotalPesoPedido(int pIdPedido, decimal pTotalPeso)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizaTotalPesoPedido(pIdPedido, pTotalPeso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoPedidoBE> ListaDuracionProcesos(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.ListaDuracionProcesos(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoPedidoBE> CierrePedidos(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                return MovimientoPedido.CierrePedidos(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizarDescuentoPorCumpleanios(int IdPedido, decimal TotalDscCumpleanios)
        {
            try
            {
                MovimientoPedidoDL MovimientoPedido = new MovimientoPedidoDL();
                MovimientoPedido.ActualizarDescuentoPorCumpleanios(IdPedido, TotalDscCumpleanios);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
