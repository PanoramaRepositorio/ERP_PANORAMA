using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProductoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public ProductoBE Selecciona(int IdEmpresa, int IdTienda, string CodigoProveedor)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.Selecciona(IdEmpresa, IdTienda, CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaCodigoBarra(int IdEmpresa, int IdTienda, string CodigoBarra)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaCodigoBarra(IdEmpresa, IdTienda, CodigoBarra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaCodigoBarra(string CodigoBarra)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaCodigoBarra(CodigoBarra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaCodigoBarraInventario(string CodigoBarra)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaCodigoBarraInventario(CodigoBarra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaIdProductoInventario(int IdProducto)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaIdProductoInventario(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaID(int IdEmpresa, int IdTienda, int IdProducto)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaID(IdEmpresa, IdTienda, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaIDTodos(int IdProducto)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaIDTodos(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaParteCodigo(int IdEmpresa, string CodigoProveedor)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaParteCodigo(IdEmpresa, CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaCodigoProveedor(int IdEmpresa, string CodigoProveedor)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaCodigoProveedor(IdEmpresa, CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaCodigoProveedorI(int IdEmpresa, int CodigoProveedor)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaCodigoProveedorI(IdEmpresa, CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public ProductoBE SeleccionaCodigoProveedorInventario(string CodigoProveedor)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaCodigoProveedorInventario(CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaPrecio(int IdEmpresa, int IdTienda, string CodigoProveedor)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaPrecio(IdEmpresa, IdTienda, CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaImagen(int IdEmpresa, int IdProducto)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaImagen(IdEmpresa, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoBE SeleccionaMarca(int IdEmpresa, int IdProducto)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaMarca(IdEmpresa, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaTodosInActivo(int IdEmpresa)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaTodosInActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaImagen(int IdFactura, int IdPedido, int IdProforma, int IdSolicitudCompra, bool FlagRecomendado, bool FlagDestacado)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaImagen(IdFactura, IdPedido, IdProforma, IdSolicitudCompra, FlagRecomendado, FlagDestacado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> StockGeneral(int IdEmpresa)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.StockGeneral(IdEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;}
        }
        public List<ProductoBE> ListaFamilia(int IdEmpresa, int IdFamiliaProducto)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaFamilia(IdEmpresa, IdFamiliaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaLinea(int IdEmpresa, int IdLineaProducto)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaLinea(IdEmpresa, IdLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaSubLinea(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaSubLinea(IdEmpresa, IdLineaProducto, IdSubLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaModelo(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto, int IdModeloProducto)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaModelo(IdEmpresa, IdLineaProducto, IdSubLineaProducto , IdModeloProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaMarca(int IdEmpresa, int IdMarca)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaMarca(IdEmpresa, IdMarca);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaPeriodo(int IdEmpresa, int Periodo)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaPeriodo(IdEmpresa, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaTodosBusqueda()
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                return Productol.ListaTodosBusqueda();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> SeleccionaBusqueda(string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaBusqueda(pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> SeleccionaBusquedaUnidadMedida(string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaBusquedaUnidadMedida(pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public int SeleccionaBusquedaCount(string pFiltro)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.SeleccionaBusquedaCount(pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaBusqueda(int IdEmpresa, int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.ListaBusqueda(IdEmpresa, IdTienda, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaBusquedaKIRA(int IdEmpresa, int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.ListaBusquedaKIRA(IdEmpresa, IdTienda, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaBusquedaCount(int IdEmpresa, string pFiltro)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.ListaBusquedaCount(IdEmpresa,pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaJerarquica(int IdEmpresa, int IdFamiliaProducto, int IdLineaProducto, int IdSubLineaProducto, int IdModeloProducto, int IdMaterial, int TipoReporte)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.ListaJerarquica(IdEmpresa, IdFamiliaProducto, IdLineaProducto, IdSubLineaProducto, IdModeloProducto, IdMaterial, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaJerarquicaConFoto(int IdEmpresa, int IdFamiliaProducto, int IdLineaProducto, int IdSubLineaProducto, int IdModeloProducto, int IdMaterial, int TipoReporte)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.ListaJerarquicaConFoto(IdEmpresa, IdFamiliaProducto, IdLineaProducto, IdSubLineaProducto, IdModeloProducto, IdMaterial, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }



        public List<ProductoBE> ListaConsulta(int IdEmpresa, int IdTienda, string pFiltro)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.ListaConsulta(IdEmpresa, IdTienda, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaConsultaIdProducto(int IdEmpresa, int IdTienda, int IdProducto)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.ListaConsultaIdProducto(IdEmpresa, IdTienda, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoBE> ListaID(int IdProducto, int IdTienda)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.ListaID(IdProducto, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(ProductoBE pItem, ProductoFotoBE pProductoFoto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                   
                    ProductoDL Producto = new ProductoDL();
                    ProductoFotoDL ProductoFoto = new ProductoFotoDL();

                    int IdProducto = 0;
                    IdProducto = Producto.Inserta(pItem);

                    if (pProductoFoto != null)
                    {
                        pProductoFoto.IdProducto = IdProducto;
                        ProductoFoto.Inserta(pProductoFoto);
                    }
                    ts.Complete();
                    return IdProducto;                    
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 InsertaProforma(ProductoBE pItem, ProductoFotoBE pProductoFoto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoDL Producto = new ProductoDL();
                    ProductoFotoDL ProductoFoto = new ProductoFotoDL();

                    int IdProducto = 0;
                    IdProducto = Producto.InsertaProductoProforma(pItem);

                    if (pProductoFoto != null)
                    {
                        pProductoFoto.IdProducto = IdProducto;
                        ProductoFoto.InsertaFotoProforma(pProductoFoto);
                    }
                   ts.Complete();
                    return IdProducto;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProductoBE pItem, ProductoFotoBE pProductoFoto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoDL Producto = new ProductoDL();
                    ProductoFotoDL ProductoFoto = new ProductoFotoDL();

                    if (pProductoFoto != null)
                    {
                        if (pProductoFoto.IdProductoFoto == 0)//Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            pProductoFoto.IdProducto = pItem.IdProducto;
                            ProductoFoto.Inserta(pProductoFoto);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            ProductoFoto.Actualiza(pProductoFoto);
                        }
                    }

                    Producto.Actualiza(pItem);
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaProforma(ProductoBE pItem, ProductoFotoBE pProductoFoto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoDL Producto = new ProductoDL();
                    ProductoFotoDL ProductoFoto = new ProductoFotoDL();

                    if (pProductoFoto != null)
                    {
                        if (pProductoFoto.IdProductoFoto == 0)//Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            pProductoFoto.IdProducto = pItem.IdProducto;
                            ProductoFoto.InsertaProductoProforma(pProductoFoto);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            ProductoFoto.ActualizaProformaFoto(pProductoFoto);
                        }
                    }

                    Producto.ActualizaProdProforma(pItem);
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaImagen(ProductoBE pItem)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                Producto.ActualizaImagen(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaImagenIdProducto(ProductoBE pItem)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                Producto.ActualizaImagenIdProducto(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaClasificacion(ProductoBE pItem)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                Producto.ActualizaClasificacion(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaMedidasPesos(ProductoBE pItem)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                Producto.ActualizaMedidasPesos(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void UnificaCodigo(int IdProducto, int IdProducto2)
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                Producto.UnificaCodigo(IdProducto, IdProducto2);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCodigoBarra(List<ProductoBE> pListaProducto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaProducto)
                    {
                        ProductoDL objDL_Producto = new ProductoDL();
                        objDL_Producto.ActualizaCodigoBarra(item);
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCodigoBarraIdProducto(List<ProductoBE> pListaProducto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaProducto)
                    {
                        ProductoDL objDL_Producto = new ProductoDL();
                        objDL_Producto.ActualizaCodigoBarraIdProducto(item);
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProductoBE pItem)
        {
            try
            {
                ProductoDL Productol = new ProductoDL();
                Productol.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ProductoBE> StockAlmacenCentral()
        {
            try
            {
                ProductoDL Producto = new ProductoDL();
                return Producto.StockAlmacenCentral();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
