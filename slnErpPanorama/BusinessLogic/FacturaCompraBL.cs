using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;
using System.Security.Principal;

namespace ErpPanorama.BusinessLogic
{
    public class FacturaCompraBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<FacturaCompraBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            try
            {
                FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                return FacturaCompra.ListaTodosActivo(IdEmpresa,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FacturaCompraBE> ListaProveedor(int IdEmpresa, int IdProveedor, string NumeroDocumento)
        {
            try
            {
                FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                return FacturaCompra.ListaProveedor(IdEmpresa, IdProveedor,NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FacturaCompraBE> ListadoPendientesProveedor(int IdEmpresa, int IdProveedor, string NumeroDocumento)
        {
            try
            {
                FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                return FacturaCompra.ListadoPendientesProveedor(IdEmpresa, IdProveedor, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FacturaCompraBE> ListaLineaProductoFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int IdTipoReporte)
        {
            try
            {
                FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                return FacturaCompra.ListaLineaProductoFecha(IdEmpresa, FechaDesde, FechaHasta, IdTipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public FacturaCompraBE Selecciona(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                return FacturaCompra.Selecciona(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public FacturaCompraBE SeleccionaProducto(int IdProducto)
        {
            try
            {
                FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                return FacturaCompra.SeleccionaProducto(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public FacturaCompraBE SeleccionaProductoUltimaCompra(int IdProducto)
        {
            try
            {
                FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                return FacturaCompra.SeleccionaProductoUltimaCompra(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(FacturaCompraBE pItem, List<FacturaCompraDetalleBE> pListaFacturaCompraDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                    FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                    //EstadoCuentaProveedorBL objBL_EstadoCuentaProveedor = new EstadoCuentaProveedorBL();

                    Int32 intIdFacturaCompra = 0;

                    //Insertamos la cabecera de la factura de compra
                    intIdFacturaCompra = FacturaCompra.Inserta(pItem);

                    foreach (FacturaCompraDetalleBE item in pListaFacturaCompraDetalle)
                    {
                        //Insertamos el producto si no existe
                        int IdProducto = 0;

                        //ProductoBE objE_Producto = new ProductoDL().SeleccionaCodigoProveedor(item.IdEmpresa, item.CodigoProveedor);
                        ProductoBE objE_Producto = new ProductoDL().SeleccionaCodigoProveedorInventario(item.CodigoProveedor);
                        if (objE_Producto == null)
                        {
                            ProductoBE objProducto = new ProductoBE();
                            objProducto.IdProducto = 0;
                            objProducto.IdEmpresa = item.IdEmpresa;
                            objProducto.CodigoProveedor = item.CodigoProveedor;
                            objProducto.CodigoPanorama = "";
                            objProducto.IdUnidadMedida = item.IdUnidadMedida;
                            if (pItem.FlagMuestra == true)
                            {
                                objProducto.IdLineaProducto = 10;
                            }
                            else
                            {
                                objProducto.IdLineaProducto = 0;
                            }
                            objProducto.IdSubLineaProducto = 0;
                            objProducto.IdModeloProducto = 0;
                            objProducto.IdMaterial = 0;
                            objProducto.IdMarca = 1;
                            objProducto.IdProcedencia = 0;
                            objProducto.NombreProducto = item.NombreProducto;
                            objProducto.Descripcion = "";
                            objProducto.Peso = 0;
                            objProducto.Medida = "";
                            objProducto.Imagen = item.Imagen;
                            objProducto.PrecioAB = 0;
                            objProducto.PrecioCD = 0;
                            objProducto.Descuento = 0;
                            objProducto.FlagCompuesto = false;
                            objProducto.FlagObsequio = false;
                            objProducto.FlagEscala = true;
                            objProducto.FlagDestacado = false;
                            objProducto.FlagRecomendado = false;
                            objProducto.Observacion = "Producto insertado de la factura de compra";
                            objProducto.Fecha = pItem.FechaCompra;
                            objProducto.IdTipoProducto = Parametros.intProductoAlmacenable;
                            objProducto.IdSubTipoProducto = 0;
                            objProducto.FlagEstado = true;
                            objProducto.Usuario = pItem.Usuario;
                            objProducto.Maquina = pItem.Maquina;

                            //Nacional
                            if (pItem.vNacionales)
                               // if (objProducto.FlagNacional)
                            {
                                objProducto.FlagEscala = false;//add 221215
                                objProducto.FlagNacional = true;                  
                            }


                            IdProducto = new ProductoDL().Inserta(objProducto);
                        }
                        else
                        {
                            //Si existe traemos el IdProduto
                            IdProducto = objE_Producto.IdProducto;

                            if (Parametros.intEmpresaId == Parametros.intPanoraramaDistribuidores)
                            { 
                                //Actualizamos la fecha de compra y el FlagEstado = True
                                ProductoBE objE_ProductoActualiza = new ProductoBE();
                                objE_ProductoActualiza.IdProducto = IdProducto;
                                objE_ProductoActualiza.Fecha = pItem.FechaCompra;

                                ProductoDL objDL_Producto = new ProductoDL();
                                objDL_Producto.ActualizaFecha(objE_ProductoActualiza);                            
                            }

                        }


                        #region "Muestra Feria Navideña Panorama"
                        if (pItem.FlagMuestra == true && Parametros.intEmpresaId == Parametros.intPanoraramaDistribuidores)
                        {
                            //Si es muestras insertamos en el kadex y el almacén

                            /*int IdKardex = 0;
                            //Insertar Kardex
                            KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaCompra);
                            objE_Kardex.IdAlmacen = Parametros.intAlmCentral;
                            objE_Kardex.IdProducto = IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = 24; //Factura Compra
                            objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                            objE_Kardex.Observacion = "Ingreso por recepción de bulto de factura de compra";
                            objE_Kardex.TipoMovimiento = "I";
                            objE_Kardex.MontoUnitarioCompra = item.PrecioUnitario;
                            objE_Kardex.PrecioCostoPromedio = item.PrecioUnitario;
                            objE_Kardex.MontoTotalCompra = item.PrecioUnitario;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, 1, 1, pItem.IdProducto);

                            if (objE_KardexValorizado != null)
                            {
                                decimal dmlPCP = 0;
                                decimal dmlCostoTotal = 0;

                                if (objE_KardexValorizado.Saldo != 0)
                                {
                                    //Calcula Precio Costo Promedio
                                    dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                                    dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;
                                }

                                objE_Kardex.PrecioCostoPromedio = dmlPCP;
                                objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            }
                            else
                            {
                                objE_Kardex.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            }

                            KardexDL objDL_Kardex = new KardexDL();
                            IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, 1, 1, IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock de Bultos
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = 0;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            }
                            else
                            {
                                //Insertamos Stock de Bultos
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }
                        }
                        #endregion

                        #region "Ingreso normal Panorama"

                        else if (pItem.FlagMuestra == false && Parametros.intEmpresaId == Parametros.intPanoraramaDistribuidores)
                        {
                            //Insertamos los bultos de la factura de compra
                            for (int i = 0; i < item.NumeroBultos; i++)
                            {
                                BultoBE objE_Bulto = new BultoBE();
                                objE_Bulto.IdBulto = 0;
                                objE_Bulto.IdEmpresa = pItem.IdEmpresa;
                                objE_Bulto.IdAlmacen = Parametros.intAlmBultos;
                                objE_Bulto.IdSector = Parametros.intNinguno;
                                objE_Bulto.IdBloque = Parametros.intNinguno;
                                objE_Bulto.IdProducto = IdProducto;
                                objE_Bulto.NumeroBulto = "";
                                objE_Bulto.Agrupacion = "";
                                objE_Bulto.IdFacturaCompra = intIdFacturaCompra;
                                objE_Bulto.PrecioUnitario = item.PrecioUnitario;
                                objE_Bulto.Cantidad = item.CantidadUM;
                                objE_Bulto.CostoUnitario = item.CantidadUM * item.PrecioUnitario;
                                objE_Bulto.FechaIngreso = pItem.FechaCompra;
                                objE_Bulto.IdSituacion = Parametros.intBULGenerado;
                                objE_Bulto.IdKardex = null;
                                objE_Bulto.FlagEstado = true;
                                objE_Bulto.Usuario = pItem.Usuario;

                                BultoDL objDL_Bulto = new BultoDL();
                                objDL_Bulto.Inserta(objE_Bulto);
                            }
                        }

                        #endregion

                        #region "Ingreso otras empresas"
                        else if (Parametros.intEmpresaId != Parametros.intPanoraramaDistribuidores)
                        {
                            //Si es muestras insertamos en el kadex y el almacén

                            /*int IdKardex = 0;
                            //Insertar Kardex
                            KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaCompra);
                            objE_Kardex.IdAlmacen = Parametros.intAlmCentral;// intAlmCentral;
                            objE_Kardex.IdProducto = IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = 24; //Factura Compra
                            objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                            objE_Kardex.Observacion = "Ingreso por recepción de factura de compra";
                            objE_Kardex.TipoMovimiento = "I";
                            objE_Kardex.MontoUnitarioCompra = item.PrecioUnitario;
                            objE_Kardex.PrecioCostoPromedio = item.PrecioUnitario;
                            objE_Kardex.MontoTotalCompra = item.PrecioUnitario;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, Parametros.intTiendaId, Parametros.intAlmCentral, pItem.IdProducto);

                            if (objE_KardexValorizado != null)
                            {
                                decimal dmlPCP = 0;
                                decimal dmlCostoTotal = 0;

                                if (objE_KardexValorizado.Saldo != 0)
                                {
                                    //Calcula Precio Costo Promedio
                                    dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                                    dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;
                                }

                                objE_Kardex.PrecioCostoPromedio = dmlPCP;
                                objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            }
                            else
                            {
                                objE_Kardex.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            }

                            KardexDL objDL_Kardex = new KardexDL();
                            IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, Parametros.intTiendaId, Parametros.intAlmAnaquelesKonceptos, IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock de Bultos
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = 0;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            }
                            else
                            {
                                //Insertamos Stock de Bultos
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0; //objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0; //objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }
                        }
                        #endregion


                        //Insertamos el detalle de la factura de compra
                        item.IdFacturaCompra = intIdFacturaCompra;
                        item.IdProducto = IdProducto;
                        FacturaCompraDetalle.Inserta(item);
                    }

                    //Insertando Al Estado de Cuenta del Proveedor
                    //Datos  del Estado de Cuenta Proveedor


                   //if(pItem.IdFormaPago==62)
                   // {

                   //     EstadoCuentaProveedorBE objBE_EstadoCuentaProveedor = new EstadoCuentaProveedorBE();
                   //     objBE_EstadoCuentaProveedor.IdEmpresa = pItem.IdEmpresa;
                   //     objBE_EstadoCuentaProveedor.Periodo = pItem.Periodo;
                   //     objBE_EstadoCuentaProveedor.IdProveedor = pItem.IdProveedor;
                   //     objBE_EstadoCuentaProveedor.NumeroDocumento = pItem.NumeroDocumento;
                   //     objBE_EstadoCuentaProveedor.FechaCredito = pItem.FechaCompra;//verificar la  fecha de credito
                   //     objBE_EstadoCuentaProveedor.FechaDeposito = null;
                   //     objBE_EstadoCuentaProveedor.Concepto = "CREDITO";
                   //     objBE_EstadoCuentaProveedor.FechaVencimiento = pItem.FechaVencimiento;
                   //     objBE_EstadoCuentaProveedor.Importe = pItem.Importe;
                   //     objBE_EstadoCuentaProveedor.TipoMovimiento = "C";
                   //     objBE_EstadoCuentaProveedor.IdFacturaCompra = intIdFacturaCompra;
                   //     objBE_EstadoCuentaProveedor.Observacion = "";
                   //     objBE_EstadoCuentaProveedor.IdUsuario = Parametros.intUsuarioId;
                   //     objBE_EstadoCuentaProveedor.FlagEstado = true;
                   //     objBE_EstadoCuentaProveedor.Usuario = Parametros.strUsuarioLogin;
                   //     objBE_EstadoCuentaProveedor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                   //     //objBE_EstadoCuentaProveedor.IdUsuario="" ? (DateTime?)null : Convert.ToDateTime(deFechaDeposito.DateTime.ToShortDateString());
                   //     objBL_EstadoCuentaProveedor.Inserta(objBE_EstadoCuentaProveedor);

                   //     //objE_EstadoCuenta.FechaPrueba = deFechaDeposito.Text == "" ? (DateTime?)null : Convert.ToDateTime(deFechaDeposito.DateTime.ToShortDateString());
                   // }

                    ts.Complete();
                }
                
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void InsertaDocumentoVenta(FacturaCompraBE pItem, List<FacturaCompraDetalleBE> pListaFacturaCompraDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                    FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                    Int32 intIdFacturaCompra = 0;

                    //Insertamos la cabecera de la factura de compra
                    intIdFacturaCompra = FacturaCompra.Inserta(pItem);

                    foreach (FacturaCompraDetalleBE item in pListaFacturaCompraDetalle)
                    {
                        int IdProducto = item.IdProducto;

                        #region "Muestra Feria Navideña Panorama"
                        if (pItem.FlagMuestra == true && Parametros.intEmpresaId == Parametros.intPanoraramaDistribuidores)
                        {
                            //Si es muestras insertamos en el kadex y el almacén

                            //int IdKardex = 0;
                            ////Insertar Kardex
                            //KardexBE objE_Kardex = new KardexBE();
                            //objE_Kardex.IdKardex = 0;
                            //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            //objE_Kardex.Periodo = pItem.Periodo;
                            //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaCompra);
                            //objE_Kardex.IdAlmacen = Parametros.intAlmCentral;
                            //objE_Kardex.IdProducto = IdProducto;
                            //objE_Kardex.Cantidad = item.Cantidad;
                            //objE_Kardex.IdTipoDocumento = 24; //Factura Compra
                            //objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                            //objE_Kardex.Observacion = "Ingreso por recepción de bulto de factura de compra";
                            //objE_Kardex.TipoMovimiento = "I";
                            //objE_Kardex.MontoUnitarioCompra = item.PrecioUnitario;
                            //objE_Kardex.PrecioCostoPromedio = item.PrecioUnitario;
                            //objE_Kardex.MontoTotalCompra = item.PrecioUnitario;
                            //objE_Kardex.FlagEstado = true;
                            //objE_Kardex.Usuario = pItem.Usuario;
                            //objE_Kardex.Maquina = pItem.Maquina;

                            //KardexBE objE_KardexValorizado = new KardexBE();
                            //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, 1, 1, pItem.IdProducto);

                            //if (objE_KardexValorizado != null)
                            //{
                            //    decimal dmlPCP = 0;
                            //    decimal dmlCostoTotal = 0;

                            //    if (objE_KardexValorizado.Saldo != 0)
                            //    {
                            //        //Calcula Precio Costo Promedio
                            //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                            //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;
                            //    }

                            //    objE_Kardex.PrecioCostoPromedio = dmlPCP;
                            //    objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            //}
                            //else
                            //{
                            //    objE_Kardex.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            //}

                            //KardexDL objDL_Kardex = new KardexDL();
                            //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, 1, 1, IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock de Bultos
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = 0;
                                objE_Stock.PrecioCostoPromedio = 0; // objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            }
                            else
                            {
                                //Insertamos Stock de Bultos
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }
                        }
                        #endregion

                        #region "Ingreso normal Panorama"

                        else if (pItem.FlagMuestra == false && Parametros.intEmpresaId == Parametros.intPanoraramaDistribuidores)
                        {
                            //Insertamos los bultos de la factura de compra
                            for (int i = 0; i < item.NumeroBultos; i++)
                            {
                                BultoBE objE_Bulto = new BultoBE();
                                objE_Bulto.IdBulto = 0;
                                objE_Bulto.IdEmpresa = pItem.IdEmpresa;
                                objE_Bulto.IdAlmacen = Parametros.intAlmBultos;
                                objE_Bulto.IdSector = Parametros.intNinguno;
                                objE_Bulto.IdBloque = Parametros.intNinguno;
                                objE_Bulto.IdProducto = IdProducto;
                                objE_Bulto.NumeroBulto = "";
                                objE_Bulto.Agrupacion = "";
                                objE_Bulto.IdFacturaCompra = intIdFacturaCompra;
                                objE_Bulto.PrecioUnitario = item.PrecioUnitario;
                                objE_Bulto.Cantidad = item.CantidadUM;
                                objE_Bulto.CostoUnitario = item.CantidadUM * item.PrecioUnitario;
                                objE_Bulto.FechaIngreso = pItem.FechaCompra;
                                objE_Bulto.IdSituacion = Parametros.intBULGenerado;
                                objE_Bulto.IdKardex = null;
                                objE_Bulto.FlagEstado = true;
                                objE_Bulto.Usuario = pItem.Usuario;

                                BultoDL objDL_Bulto = new BultoDL();
                                objDL_Bulto.Inserta(objE_Bulto);
                            }
                        }

                        #endregion

                        #region "Ingreso otras empresas"
                        else if (Parametros.intEmpresaId != Parametros.intPanoraramaDistribuidores)
                        {
                            //Si es muestras insertamos en el kadex y el almacén

                            /*int IdKardex = 0;
                            //Insertar Kardex
                            KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaCompra);
                            objE_Kardex.IdAlmacen = Parametros.intAlmCentral;// intAlmCentral;
                            objE_Kardex.IdProducto = IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = 24; //Factura Compra
                            objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                            objE_Kardex.Observacion = "Ingreso por recepción de factura de compra";
                            objE_Kardex.TipoMovimiento = "I";
                            objE_Kardex.MontoUnitarioCompra = item.PrecioUnitario;
                            objE_Kardex.PrecioCostoPromedio = item.PrecioUnitario;
                            objE_Kardex.MontoTotalCompra = item.PrecioUnitario;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, Parametros.intTiendaId, Parametros.intAlmCentral, pItem.IdProducto);

                            if (objE_KardexValorizado != null)
                            {
                                decimal dmlPCP = 0;
                                decimal dmlCostoTotal = 0;

                                if (objE_KardexValorizado.Saldo != 0)
                                {
                                    //Calcula Precio Costo Promedio
                                    dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                                    dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;
                                }

                                objE_Kardex.PrecioCostoPromedio = dmlPCP;
                                objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            }
                            else
                            {
                                objE_Kardex.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            }

                            KardexDL objDL_Kardex = new KardexDL();
                            IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, Parametros.intTiendaId, Parametros.intAlmAnaquelesKonceptos, IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock de Bultos
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = 0;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            }
                            else
                            {
                                //Insertamos Stock de Bultos
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0; //objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0; //objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }
                        }
                        #endregion


                        //Insertamos el detalle de la factura de compra
                        item.IdFacturaCompra = intIdFacturaCompra;
                        item.IdProducto = IdProducto;
                        FacturaCompraDetalle.Inserta(item);
                    }

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(FacturaCompraBE pItem, List<FacturaCompraDetalleBE> pListaFacturaCompraDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                    FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();

                    foreach (FacturaCompraDetalleBE item in pListaFacturaCompraDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdFacturaCompra = pItem.IdFacturaCompra;
                            FacturaCompraDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la factura de compra
                            FacturaCompraDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos la factura de compra
                    FacturaCompra.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(FacturaCompraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                    FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                    
                    ///Según factura de compra de los bultos generados
                    List<BultoBE> lstBulto = null;
                    lstBulto = new BultoDL().ListaFacturaCompra(pItem.IdEmpresa, pItem.IdFacturaCompra);
                    foreach (BultoBE itembulto in lstBulto)
                    {
                        ////Elimina el Kardex del bulto generado
                        //KardexBE objE_Kardex = new KardexBE();
                        //KardexDL objDL_Kardex = new KardexDL();

                        //objE_Kardex.IdKardex = Convert.ToInt32(itembulto.IdKardex);
                        //objE_Kardex.IdEmpresa = itembulto.IdEmpresa;
                        //objDL_Kardex.Elimina(objE_Kardex);

                        //Elimina los Bultos Generados
                        BultoDL objDL_Bulto = new BultoDL();
                        objDL_Bulto.Elimina_Producto(pItem.IdEmpresa, itembulto.IdBulto);
                    }

                    //Add 30/06/2015
                    foreach(BultoBE item in lstBulto)
                    {
                        if (item.IdSituacion == Parametros.intBULRecibido)
                        {
                            //Actualizamos Stock
                            StockDL objDL_Stock = new StockDL();
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = 0;
                            objE_Stock.ValorDescuenta = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;
                            objE_Stock.CostoTotal = 0;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.ActualizaCantidades(objE_Stock);                 
                        }

                    }


                    //tradicional
                    List<FacturaCompraDetalleBE> lstFacturaCompraDetalle = null;
                    lstFacturaCompraDetalle = new FacturaCompraDetalleDL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdFacturaCompra);
                    foreach (FacturaCompraDetalleBE item in lstFacturaCompraDetalle)
                    {
                        /*
                        //Actualizamos Stock
                        StockDL objDL_Stock = new StockDL();
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                        objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                        objE_Stock.IdProducto = item.IdProducto;
                        objE_Stock.ValorIncrementa = 0;
                        objE_Stock.ValorDescuenta = item.Cantidad;
                        objE_Stock.PrecioCostoPromedio = 0;
                        objE_Stock.CostoTotal = 0;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.ActualizaCantidades(objE_Stock);*/

                        //Elimina el detalle de la factura de compra
                        FacturaCompraDetalle.Elimina(item);
                    }

                    //Eliminar la factura de compra
                    FacturaCompra.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaFechaRecepcion(FacturaCompraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    FacturaCompraDL FacturaCompra = new FacturaCompraDL();
                  
                    //Eliminar la factura de compra
                    FacturaCompra.ActualizaFechaRecepcion(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaSituacionPago(int IdFacturaCompra, int IdSituacionPago, string Maquina, string Usuario)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    FacturaCompraDL FacturaCompra = new FacturaCompraDL();

                    //Eliminar la factura de compra
                    FacturaCompra.ActualizaSituacionPago(IdFacturaCompra,IdSituacionPago,Maquina,Usuario);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
