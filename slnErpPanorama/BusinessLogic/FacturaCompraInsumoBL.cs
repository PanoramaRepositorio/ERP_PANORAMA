using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class FacturaCompraInsumoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<FacturaCompraInsumoBE> ListaTodosActivo(int IdEmpresa, int Periodo)
		{
			try
			{
				FacturaCompraInsumoDL FacturaCompraInsumo = new FacturaCompraInsumoDL();
				return FacturaCompraInsumo.ListaTodosActivo(IdEmpresa, Periodo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<FacturaCompraInsumoBE> ListaProveedor(int IdEmpresa, int IdProveedor, string NumeroDocumento)
        {
            try
            {
                FacturaCompraInsumoDL FacturaCompraInsumo = new FacturaCompraInsumoDL();
                return FacturaCompraInsumo.ListaProveedor(IdEmpresa, IdProveedor, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public FacturaCompraInsumoBE Selecciona(int IdFacturaCompraInsumo)
		{
			try
			{
				FacturaCompraInsumoDL FacturaCompraInsumo = new FacturaCompraInsumoDL();
				return FacturaCompraInsumo.Selecciona(IdFacturaCompraInsumo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(FacturaCompraInsumoBE pItem, List<FacturaCompraInsumoDetalleBE> pListaFacturaCompraInsumoDetalle)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    FacturaCompraInsumoDL FacturaCompraInsumo = new FacturaCompraInsumoDL();
                    FacturaCompraInsumoDetalleDL FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleDL();
                    Int32 intIdFacturaCompraInsumo = 0;

                    //Insertamos la cabecera de la factura de compra
                    intIdFacturaCompraInsumo = FacturaCompraInsumo.Inserta(pItem);

                    foreach (FacturaCompraInsumoDetalleBE item in pListaFacturaCompraInsumoDetalle)
                    {
                        //Insertamos el producto si no existe
                        int IdInsumo = 0;

                        ProductoBE objE_Producto = new ProductoDL().SeleccionaCodigoProveedor(item.IdEmpresa, item.Descripcion);
                        if (objE_Producto == null)
                        {
                            InsumoBE objInsumo = new InsumoBE();
                            objInsumo.IdInsumo = 0;
                            objInsumo.IdEmpresa = item.IdEmpresa;
                            objInsumo.IdUnidadMedida = item.IdUnidadMedida;
                            objInsumo.IdInsumoClasificacion = 0;
                            objInsumo.Descripcion = item.Descripcion;
                            objInsumo.Imagen = item.Imagen;
                            objInsumo.Precio = 0;
                            objInsumo.Stock = 0;
                            objInsumo.Observacion = "Insumo insertado de la Solicitud de compra";
                            objInsumo.Fecha = pItem.FechaCompra;
                            objInsumo.FlagEstado = true;
                            objInsumo.Usuario = pItem.Usuario;
                            objInsumo.Maquina = pItem.Maquina;

                            IdInsumo = new InsumoDL().Inserta(objInsumo);
                        }
                        //else
                        //{
                        //    //Si existe traemos el IdProduto
                        //    //IdInsumo = objE_Insumo.IdInsumo;

                        //    if (Parametros.intEmpresaId == Parametros.intPanoraramaDistribuidores)
                        //    {
                        //        //Actualizamos la fecha de compra y el FlagEstado = True
                        //        InsumoBE objE_InsumoActualiza = new InsumoBE();
                        //        objE_InsumoActualiza.IdInsumo = IdInsumo;
                        //        objE_InsumoActualiza.Fecha = pItem.FechaCompra;

                        //        InsumoDL objDL_Insumo = new InsumoDL();
                        //        objDL_Insumo.ActualizaFecha(objE_InsumoActualiza);
                        //    }

                        //}

                        //Insertamos el detalle de la factura de compra
                        item.IdFacturaCompraInsumo = intIdFacturaCompraInsumo;
                        item.IdInsumo = IdInsumo;
                        FacturaCompraInsumoDetalle.Inserta(item);
                    }

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }

            //try
            //{
            //    FacturaCompraInsumoDL FacturaCompraInsumo = new FacturaCompraInsumoDL();
            //    FacturaCompraInsumo.Inserta(pItem);
            //}
            //catch (Exception ex)
            //{ throw ex; }
        }

		public void Actualiza(FacturaCompraInsumoBE pItem, List<FacturaCompraInsumoDetalleBE> pListaFacturaCompraInsumoDetalle)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    FacturaCompraInsumoDL FacturaCompraInsumo = new FacturaCompraInsumoDL();
                    FacturaCompraInsumoDetalleDL FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleDL();

                    foreach (FacturaCompraInsumoDetalleBE item in pListaFacturaCompraInsumoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdFacturaCompraInsumo = pItem.IdFacturaCompraInsumo;
                            FacturaCompraInsumoDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la factura de compra
                            FacturaCompraInsumoDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos la factura de compra
                    FacturaCompraInsumo.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
		}

		public void Elimina(FacturaCompraInsumoBE pItem)
		{
			try
			{
				FacturaCompraInsumoDL FacturaCompraInsumo = new FacturaCompraInsumoDL();
				FacturaCompraInsumo.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
