using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProductoDL
    {
         public ProductoDL() { }

        public Int32 Inserta(ProductoBE pItem)
        {
            Int32 intIdProducto = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_Inserta");

            db.AddOutParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pCodigoPanorama", DbType.String, pItem.CodigoPanorama);
            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, pItem.IdModeloProducto);

            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdMaterial2", DbType.Int32, pItem.IdMaterial2);

            db.AddInParameter(dbCommand, "pIdMarca", DbType.Int32, pItem.IdMarca);
            db.AddInParameter(dbCommand, "pIdProcedencia", DbType.Int32, pItem.IdProcedencia);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pPeso", DbType.Decimal, pItem.Peso);
            db.AddInParameter(dbCommand, "pMedida", DbType.String, pItem.Medida);

            db.AddInParameter(dbCommand, "pMedidaInternaAltura", DbType.Decimal, pItem.MedidaInternaAltura);
            db.AddInParameter(dbCommand, "pMedidaInternaAncho", DbType.Decimal, pItem.MedidaInternaAncho);
            db.AddInParameter(dbCommand, "pMedidaInternaProfundidad", DbType.Decimal, pItem.MedidaInternaProfundidad);

            db.AddInParameter(dbCommand, "pMedidaExternaAltura", DbType.Decimal, pItem.MedidaExternaAltura);
            db.AddInParameter(dbCommand, "pMedidaExternaAncho", DbType.Decimal, pItem.MedidaExternaAncho);
            db.AddInParameter(dbCommand, "pMedidaExternaProfundidad", DbType.Decimal, pItem.MedidaExternaProfundidad);

            db.AddInParameter(dbCommand, "pPesoBruto", DbType.Decimal, pItem.PesoBruto);
            db.AddInParameter(dbCommand, "pPesoNeto", DbType.Decimal, pItem.PesoNeto);

            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pFlagCompuesto", DbType.Boolean, pItem.FlagCompuesto);
            db.AddInParameter(dbCommand, "pFlagObsequio", DbType.Boolean, pItem.FlagObsequio);
            db.AddInParameter(dbCommand, "pFlagEscala", DbType.Boolean, pItem.FlagEscala);
            db.AddInParameter(dbCommand, "pFlagDestacado", DbType.Boolean, pItem.FlagDestacado);
            db.AddInParameter(dbCommand, "pFlagRecomendado", DbType.Boolean, pItem.FlagRecomendado);
            db.AddInParameter(dbCommand, "pFlagNacional", DbType.Boolean, pItem.FlagNacional);
            db.AddInParameter(dbCommand, "pIdProductoArmado", DbType.Int32, pItem.IdProductoArmado);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoProducto", DbType.Int32, pItem.IdTipoProducto);
            db.AddInParameter(dbCommand, "pIdSubTipoProducto", DbType.Int32, pItem.IdSubTipoProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdProducto = (int)db.GetParameterValue(dbCommand, "pIdProducto");

            return intIdProducto;
        }

        public Int32 InsertaProductoProforma(ProductoBE pItem)
        {
            Int32 intIdProducto = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoProforma_Inserta");

            db.AddOutParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pCodigoPanorama", DbType.String, pItem.CodigoPanorama);
            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, pItem.IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdMarca", DbType.Int32, pItem.IdMarca);
            db.AddInParameter(dbCommand, "pIdProcedencia", DbType.Int32, pItem.IdProcedencia);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pPeso", DbType.Decimal, pItem.Peso);
            db.AddInParameter(dbCommand, "pMedida", DbType.String, pItem.Medida);

            db.AddInParameter(dbCommand, "pMedidaInternaAltura", DbType.Decimal, pItem.MedidaInternaAltura);
            db.AddInParameter(dbCommand, "pMedidaInternaAncho", DbType.Decimal, pItem.MedidaInternaAncho);
            db.AddInParameter(dbCommand, "pMedidaInternaProfundidad", DbType.Decimal, pItem.MedidaInternaProfundidad);

            db.AddInParameter(dbCommand, "pMedidaExternaAltura", DbType.Decimal, pItem.MedidaExternaAltura);
            db.AddInParameter(dbCommand, "pMedidaExternaAncho", DbType.Decimal, pItem.MedidaExternaAncho);
            db.AddInParameter(dbCommand, "pMedidaExternaProfundidad", DbType.Decimal, pItem.MedidaExternaProfundidad);

            db.AddInParameter(dbCommand, "pPesoBruto", DbType.Decimal, pItem.PesoBruto);
            db.AddInParameter(dbCommand, "pPesoNeto", DbType.Decimal, pItem.PesoNeto);

            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pFlagCompuesto", DbType.Boolean, pItem.FlagCompuesto);
            db.AddInParameter(dbCommand, "pFlagObsequio", DbType.Boolean, pItem.FlagObsequio);
            db.AddInParameter(dbCommand, "pFlagEscala", DbType.Boolean, pItem.FlagEscala);
            db.AddInParameter(dbCommand, "pFlagDestacado", DbType.Boolean, pItem.FlagDestacado);
            db.AddInParameter(dbCommand, "pFlagRecomendado", DbType.Boolean, pItem.FlagRecomendado);
            db.AddInParameter(dbCommand, "pFlagNacional", DbType.Boolean, pItem.FlagNacional);
            db.AddInParameter(dbCommand, "pIdProductoArmado", DbType.Int32, pItem.IdProductoArmado);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoProducto", DbType.Int32, pItem.IdTipoProducto);
            db.AddInParameter(dbCommand, "pIdSubTipoProducto", DbType.Int32, pItem.IdSubTipoProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdProducto = (int)db.GetParameterValue(dbCommand, "pIdProducto");

            return intIdProducto;
        }
        public void Actualiza(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_Actualiza");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pCodigoPanorama", DbType.String, pItem.CodigoPanorama);
            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, pItem.IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdMaterial2", DbType.Int32, pItem.IdMaterial2);
            db.AddInParameter(dbCommand, "pIdMarca", DbType.Int32, pItem.IdMarca);
            db.AddInParameter(dbCommand, "pIdProcedencia", DbType.Int32, pItem.IdProcedencia);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pPeso", DbType.Decimal, pItem.Peso);
            db.AddInParameter(dbCommand, "pMedida", DbType.String, pItem.Medida);

            db.AddInParameter(dbCommand, "pMedidaInternaAltura", DbType.Decimal, pItem.MedidaInternaAltura);
            db.AddInParameter(dbCommand, "pMedidaInternaAncho", DbType.Decimal, pItem.MedidaInternaAncho);
            db.AddInParameter(dbCommand, "pMedidaInternaProfundidad", DbType.Decimal, pItem.MedidaInternaProfundidad);

            db.AddInParameter(dbCommand, "pMedidaExternaAltura", DbType.Decimal, pItem.MedidaExternaAltura);
            db.AddInParameter(dbCommand, "pMedidaExternaAncho", DbType.Decimal, pItem.MedidaExternaAncho);
            db.AddInParameter(dbCommand, "pMedidaExternaProfundidad", DbType.Decimal, pItem.MedidaExternaProfundidad);

            db.AddInParameter(dbCommand, "pPesoBruto", DbType.Decimal, pItem.PesoBruto);
            db.AddInParameter(dbCommand, "pPesoNeto", DbType.Decimal, pItem.PesoNeto);

            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pFlagCompuesto", DbType.Boolean, pItem.FlagCompuesto);
            db.AddInParameter(dbCommand, "pFlagObsequio", DbType.Boolean, pItem.FlagObsequio);
            db.AddInParameter(dbCommand, "pFlagEscala", DbType.Boolean, pItem.FlagEscala);
            db.AddInParameter(dbCommand, "pFlagDestacado", DbType.Boolean, pItem.FlagDestacado);
            db.AddInParameter(dbCommand, "pFlagRecomendado", DbType.Boolean, pItem.FlagRecomendado);
            db.AddInParameter(dbCommand, "pFlagNacional", DbType.Boolean, pItem.FlagNacional);
            db.AddInParameter(dbCommand, "pIdProductoArmado", DbType.Int32, pItem.IdProductoArmado);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoProducto", DbType.Int32, pItem.IdTipoProducto);
            db.AddInParameter(dbCommand, "pIdSubTipoProducto", DbType.Int32, pItem.IdSubTipoProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pColeccion", DbType.String, pItem.Coleccion);
 

            db.ExecuteNonQuery(dbCommand);
        }


        public void ActualizaProdProforma(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_Actualiza");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pCodigoPanorama", DbType.String, pItem.CodigoPanorama);
            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, pItem.IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdMarca", DbType.Int32, pItem.IdMarca);
            db.AddInParameter(dbCommand, "pIdProcedencia", DbType.Int32, pItem.IdProcedencia);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pPeso", DbType.Decimal, pItem.Peso);
            db.AddInParameter(dbCommand, "pMedida", DbType.String, pItem.Medida);

            db.AddInParameter(dbCommand, "pMedidaInternaAltura", DbType.Decimal, pItem.MedidaInternaAltura);
            db.AddInParameter(dbCommand, "pMedidaInternaAncho", DbType.Decimal, pItem.MedidaInternaAncho);
            db.AddInParameter(dbCommand, "pMedidaInternaProfundidad", DbType.Decimal, pItem.MedidaInternaProfundidad);

            db.AddInParameter(dbCommand, "pMedidaExternaAltura", DbType.Decimal, pItem.MedidaExternaAltura);
            db.AddInParameter(dbCommand, "pMedidaExternaAncho", DbType.Decimal, pItem.MedidaExternaAncho);
            db.AddInParameter(dbCommand, "pMedidaExternaProfundidad", DbType.Decimal, pItem.MedidaExternaProfundidad);

            db.AddInParameter(dbCommand, "pPesoBruto", DbType.Decimal, pItem.PesoBruto);
            db.AddInParameter(dbCommand, "pPesoNeto", DbType.Decimal, pItem.PesoNeto);

            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pFlagCompuesto", DbType.Boolean, pItem.FlagCompuesto);
            db.AddInParameter(dbCommand, "pFlagObsequio", DbType.Boolean, pItem.FlagObsequio);
            db.AddInParameter(dbCommand, "pFlagEscala", DbType.Boolean, pItem.FlagEscala);
            db.AddInParameter(dbCommand, "pFlagDestacado", DbType.Boolean, pItem.FlagDestacado);
            db.AddInParameter(dbCommand, "pFlagRecomendado", DbType.Boolean, pItem.FlagRecomendado);
            db.AddInParameter(dbCommand, "pFlagNacional", DbType.Boolean, pItem.FlagNacional);
            db.AddInParameter(dbCommand, "pIdProductoArmado", DbType.Int32, pItem.IdProductoArmado);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoProducto", DbType.Int32, pItem.IdTipoProducto);
            db.AddInParameter(dbCommand, "pIdSubTipoProducto", DbType.Int32, pItem.IdSubTipoProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pColeccion", DbType.String, pItem.Coleccion);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaImagen(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ActualizaImagen");

            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaImagenIdProducto(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ActualizaImagenIdProducto");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaFecha(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ActualizaFecha");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaClasificacion(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ActualizaClasificacion");

            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, pItem.IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdMarca", DbType.Int32, pItem.IdMarca);
            db.AddInParameter(dbCommand, "pColeccion", DbType.String, pItem.Coleccion);
            db.AddInParameter(dbCommand, "pIdProcedencia", DbType.Int32, pItem.IdProcedencia);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pPeso", DbType.Decimal, pItem.Peso);
            db.AddInParameter(dbCommand, "pMedida", DbType.String, pItem.Medida);
            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaMedidasPesos(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ActualizaMedidasPesos");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, Convert.ToInt32(pItem.IdProductoStr));
            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);

            db.AddInParameter(dbCommand, "pMedidaInternaAltura", DbType.Decimal, pItem.MedidaInternaAltura);
            db.AddInParameter(dbCommand, "pMedidaInternaAncho", DbType.Decimal, pItem.MedidaInternaAncho);
            db.AddInParameter(dbCommand, "pMedidaInternaProfundidad", DbType.Decimal, pItem.MedidaInternaProfundidad);

            db.AddInParameter(dbCommand, "pMedidaExternaAltura", DbType.Decimal, pItem.MedidaExternaAltura);
            db.AddInParameter(dbCommand, "pMedidaExternaAncho", DbType.Decimal, pItem.MedidaExternaAncho);
            db.AddInParameter(dbCommand, "pMedidaExternaProfundidad", DbType.Decimal, pItem.MedidaExternaProfundidad);

            db.AddInParameter(dbCommand, "pPesoBruto", DbType.Decimal, pItem.PesoBruto);
            db.AddInParameter(dbCommand, "pPesoNeto", DbType.Decimal, pItem.PesoNeto);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaCodigoBarra(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ActualizaCodigoBarra");

            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaCodigoBarraIdProducto(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ActualizaCodigoBarraIdProducto");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.String, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);

            db.ExecuteNonQuery(dbCommand);

        }

        public void UnificaCodigo(int IdProducto, int IdProducto2)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_UnificaCodigo");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pIdProducto2", DbType.Int32, IdProducto2);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_Elimina");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Eliminacion(int IdEmpresa, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_Eliminacion");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            db.ExecuteNonQuery(dbCommand);
        }

        public ProductoBE Selecciona(int IdEmpresa, int IdTienda, string CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();

                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();

                Producto.IdMaterial2 = reader.IsDBNull(reader.GetOrdinal("IdMaterial2")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial2"));
                Producto.DescMaterial2 = reader["DescMaterial2"].ToString();

                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura    = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());

                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                Producto.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                Producto.TipoCambioCD = Decimal.Parse(reader["TipoCambioCD"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.IdTipoProducto = Int32.Parse(reader["IdTipoProducto"].ToString());
                Producto.IdSubTipoProducto = Int32.Parse(reader["IdSubTipoProducto"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                Producto.Coleccion = reader["Coleccion"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaCodigoBarra(int IdEmpresa, int IdTienda, string CodigoBarra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaCodigoBarra");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, CodigoBarra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());

                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                Producto.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                Producto.TipoCambioCD = Decimal.Parse(reader["TipoCambioCD"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                Producto.Coleccion = reader["Coleccion"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaCodigoBarra(string CodigoBarra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaCodigoBarraTodos");
            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, CodigoBarra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());


                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                //Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                Producto.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaCodigoBarraInventario(string CodigoBarra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaCodigoBarraInventario");
            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, CodigoBarra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                //Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                //Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                //Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                //Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                //Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                //Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                //Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                //Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                //Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                //Producto.DescMaterial = reader["DescMaterial"].ToString();
                //Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                //Producto.DescMarca = reader["DescMarca"].ToString();
                //Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                //Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();



                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                //Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                //Producto.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaIdProductoInventario(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaIdProductoInventario");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();
                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaID(int IdEmpresa, int IdTienda, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaId");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());

                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.TipoCambioCD = Decimal.Parse(reader["TipoCambioCD"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.IdTipoProducto = Int32.Parse(reader["IdTipoProducto"].ToString());
                Producto.IdSubTipoProducto = Int32.Parse(reader["IdSubTipoProducto"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                Producto.Coleccion = reader["Coleccion"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaIDTodos(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaIdTodos");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());


                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaParteCodigo(int IdEmpresa, string CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaParteCodigo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());



                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaCodigoProveedor(int IdEmpresa, string CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaCodigoProveedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());

                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.Imagen = (byte[])reader["Imagen"];
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaCodigoProveedorI(int IdEmpresa, int CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaCodigoProveedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.Int32, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();
                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.Imagen = (byte[])reader["Imagen"];
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }



        public ProductoBE SeleccionaCodigoProveedorInventario(string CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaCodigoProveedorInventario");
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();
                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaImagen(int IdEmpresa, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaImagen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.Imagen = (byte[])reader["Imagen"];
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public ProductoBE SeleccionaMarca(int IdEmpresa, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaMarca");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdMarca = int.Parse(reader["IdMarca"].ToString());
                Producto.DescMarca = reader["DescMarca"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public List<ProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());

                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                //Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaTodosInActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaTodosInActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("IdFamiliaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFamiliaProducto"));
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdSubLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSubLineaProducto"));
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();

                Producto.MedidaInternaAltura = Decimal.Parse(reader["MedidaIh"].ToString());
                Producto.MedidaInternaAncho = Decimal.Parse(reader["MedidaIw"].ToString());
                Producto.MedidaInternaProfundidad = Decimal.Parse(reader["MedidaIp"].ToString());
                Producto.MedidaExternaAltura = Decimal.Parse(reader["MedidaEh"].ToString());
                Producto.MedidaExternaAncho = Decimal.Parse(reader["MedidaEw"].ToString());
                Producto.MedidaExternaProfundidad = Decimal.Parse(reader["MedidaEp"].ToString());
                Producto.PesoNeto = Decimal.Parse(reader["PesoNeto"].ToString());
                Producto.PesoBruto = Decimal.Parse(reader["PesoBruto"].ToString());

                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                //Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.FlagDestacado = Boolean.Parse(reader["FlagDestacado"].ToString());
                Producto.FlagRecomendado = Boolean.Parse(reader["FlagRecomendado"].ToString());
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.IdProductoArmado = reader.IsDBNull(reader.GetOrdinal("IdProductoArmado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProductoArmado"));
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaImagen(int IdFactura, int IdPedido, int IdProforma, int IdSolicitudCompra, bool FlagRecomendado, bool FlagDestacado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaImagen");
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFactura);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, IdProforma);
            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, IdSolicitudCompra);
            db.AddInParameter(dbCommand, "pFlagRecomendado", DbType.Int32, FlagRecomendado);
            db.AddInParameter(dbCommand, "pFlagDestacado", DbType.Int32, FlagDestacado);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                Producto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaFamilia(int IdEmpresa, int IdFamiliaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaFamilia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, IdFamiliaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaLinea(int IdEmpresa, int IdLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaLinea");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaSubLinea(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaSubLinea");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaModelo(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto, int IdModeloProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaModelo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, IdModeloProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaMarca(int IdEmpresa, int IdMarca)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaMarca");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMarca", DbType.Int32, IdMarca);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaPeriodo(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaPeriodo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaTodosBusqueda()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaTodosBusqueda");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> SeleccionaBusqueda(string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaBus");
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> SeleccionaBusquedaUnidadMedida(string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaBusUnidadMedida");
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public int SeleccionaBusquedaCount(string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<ProductoBE> ListaBusqueda(int IdEmpresa, int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaBus");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.DescUbicacion = reader["DescUbicacion"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaBusquedaKIRA(int IdEmpresa, int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaBuscaKira");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.DescUbicacion = reader["DescUbicacion"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public int ListaBusquedaCount(int IdEmpresa, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaBusCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public ProductoBE SeleccionaPrecio(int IdEmpresa, int IdTienda, string CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_SeleccionaPrecio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.DescUbicacion = reader["DescUbicacion"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public List<ProductoBE> ListaJerarquica(int IdEmpresa, int IdFamiliaProducto, int IdLineaProducto, int IdSubLineaProducto, int IdModeloProducto, int IdMaterial, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaJerarquica");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, IdMaterial);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);
  //          db.AddInParameter(dbCommand, "pProductoActivo", DbType.Int32, pProductoInactivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = int.TryParse(reader["idProducto"].ToString(), out int parsedId) ? parsedId : 0;
                Producto.IdEmpresa = int.TryParse(reader["IdEmpresa"].ToString(), out int parsedEmpresa) ? parsedEmpresa : 0;
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                //Producto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Producto.Periodo = int.TryParse(reader["Periodo"].ToString(), out int parsedPeriodo) ? parsedPeriodo : 0;
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = decimal.TryParse(reader["Descuento"].ToString(), out decimal parsedDescuento) ? parsedDescuento : 0;
                Producto.DescuentoTemporal = decimal.TryParse(reader["DescuentoTemporal"].ToString(), out decimal parsedDescuentoTemporal) ? parsedDescuentoTemporal : 0;
                Producto.PrecioAB = decimal.TryParse(reader["PrecioAB"].ToString(), out decimal parsedPrecioAB) ? parsedPrecioAB : 0;
                Producto.PrecioCD = decimal.TryParse(reader["PrecioCD"].ToString(), out decimal parsedPrecioCD) ? parsedPrecioCD : 0;
                Producto.PrecioABSoles = decimal.TryParse(reader["PrecioABSoles"].ToString(), out decimal parsedPrecioABSoles) ? parsedPrecioABSoles : 0;
                Producto.PrecioCDSoles = decimal.TryParse(reader["PrecioCDSoles"].ToString(), out decimal parsedPrecioCDSoles) ? parsedPrecioCDSoles : 0;
                Producto.DescFamiliaProducto = reader.IsDBNull(reader.GetOrdinal("DescFamiliaProducto")) ? null : reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = int.TryParse(reader["IdLineaProducto"].ToString(), out int parsedIdLineaProducto) ? parsedIdLineaProducto : 0;
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = int.TryParse(reader["IdSubLineaProducto"].ToString(), out int parsedIdSubLineaProducto) ? parsedIdSubLineaProducto : 0;
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.Medida = reader["Medida"].ToString();
                Producto.IdModeloProducto = int.TryParse(reader["IdModeloProducto"].ToString(), out int parsedIdModeloProducto) ? parsedIdModeloProducto : 0;
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.Coleccion = Producto.Coleccion = reader.IsDBNull(reader.GetOrdinal("Coleccion")) ? null : reader["Coleccion"].ToString();
                Producto.FlagNacional = bool.TryParse(reader["FlagNacional"].ToString(), out bool parsedFlagNacional) ? parsedFlagNacional : false;
                Producto.AlmacenTransitos_NS = int.TryParse(reader["AlmacenTransitos_NS"].ToString(), out int parsedAlmacenTransitosNS) ? parsedAlmacenTransitosNS : 0;
                //Producto.AlmacenTransitos_NS = Convert.ToInt32(reader["AlmacenTransitos_NS"]);
                //Producto.AlmacenTransito_PED = int.TryParse(reader["AlmacenTransitos_PED"].ToString(), out int parsedAlmacenTransitosPED) ? parsedAlmacenTransitosPED : 0;
                Producto.CantidadCompra = int.TryParse(reader["CantidadCompra"].ToString(), out int parsedCantidadCompra) ? parsedCantidadCompra : 0;
                Producto.AlmacenCentral = int.TryParse(reader["AlmacenCentral"].ToString(), out int parsedAlmacenCentral) ? parsedAlmacenCentral : 0;
                Producto.AlmacenTienda = int.TryParse(reader["AlmacenTienda"].ToString(), out int parsedAlmacenTienda) ? parsedAlmacenTienda : 0;
                Producto.AlmacenAndahuaylas = int.TryParse(reader["AlmacenAndahuaylas"].ToString(), out int parsedAlmacenAndahuaylas) ? parsedAlmacenAndahuaylas : 0;
                Producto.AlmacenOutlet = int.TryParse(reader["AlmacenOutlet"].ToString(), out int parsedAlmacenOutlet) ? parsedAlmacenOutlet : 0;
                Producto.AlmacenPrescott = int.TryParse(reader["AlmacenPrescott"].ToString(), out int parsedAlmacenPrescott) ? parsedAlmacenPrescott : 0;
                //Producto.AlmacenAviacion = int.TryParse(reader["AlmacenAviacion"].ToString(), out int parsedAlmacenAviacion) ? parsedAlmacenAviacion : 0;
                //Producto.AlmacenMegaPlaza = int.TryParse(reader["AlmacenMegaPlaza"].ToString(), out int parsedAlmacenMegaPlaza) ? parsedAlmacenMegaPlaza : 0;
                Producto.TotalStock = int.TryParse(reader["TotalStock"].ToString(), out int parsedTotalStock) ? parsedTotalStock : 0;
                Producto.AlmacenAviacion2 = int.TryParse(reader["AlmacenAviacion2"].ToString(), out int parsedAlmacenAviacion2) ? parsedAlmacenAviacion2 : 0;
                Producto.AlmacenSanMiguel = int.TryParse(reader["AlmacenSanMiguel"].ToString(), out int parsedAlmacenSanMiguel) ? parsedAlmacenSanMiguel : 0;
                Productolist.Add(Producto);

            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaJerarquicaConFoto(int IdEmpresa, int IdFamiliaProducto, int IdLineaProducto, int IdSubLineaProducto, int IdModeloProducto, int IdMaterial, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaJerarquicaConFoto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, IdMaterial);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoTemporal = Decimal.Parse(reader["DescuentoTemporal"].ToString());
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Producto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = Int32.Parse(reader["IdSubLineaProducto"].ToString());
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.IdModeloProducto = Int32.Parse(reader["IdModeloProducto"].ToString());
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                Producto.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                Producto.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                Producto.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                Producto.AlmacenOutlet = Int32.Parse(reader["AlmacenOutlet"].ToString());
                Producto.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                Producto.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                Producto.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
                Producto.AlmacenSanMiguel = Int32.Parse(reader["AlmacenSanMiguel"].ToString());
                Producto.Imagen = (byte[])reader["Imagen"];

                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> StockGeneral(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
         //   DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_StockGeneral");
           DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_StockGeneral_Prueba");
            dbCommand.CommandTimeout = 60;
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();

                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Producto.DescProveedor = reader["DescProveedor"].ToString();
                Producto.PrecioPromedio = Decimal.Parse(reader["PrecioPromedio"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = Int32.Parse(reader["IdSubLineaProducto"].ToString());
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                Producto.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                Producto.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                Producto.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                Producto.AlmacenOutlet = Int32.Parse(reader["AlmacenOutlet"].ToString());
                Producto.AlmacenTdaOutlet = Int32.Parse(reader["AlmacenTdaOutlet"].ToString());
                Producto.AlmacenReparacion = Int32.Parse(reader["AlmacenReparacion"].ToString());
                Producto.AlmacenMermas = Int32.Parse(reader["AlmacenMermas"].ToString());
                Producto.AlmacenDiferencias = Int32.Parse(reader["AlmacenDiferencias"].ToString());
                Producto.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                Producto.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                Producto.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
                //Producto.AlmacenTransito = Int32.Parse(reader["AlmacenTransitos"].ToString());
                Producto.AlmacenTransito_NS = Int32.Parse(reader["AlmacenTransitos_NS"].ToString());
                Producto.AlmacenTransito_PED =  Int32.Parse(reader["AlmacenTransitos_PED"].ToString()); 
                Producto.AlmacenPendiente = Int32.Parse(reader["AlmacenPendiente"].ToString());
                Producto.AlmacenMuestras = Int32.Parse(reader["AlmacenMuestras"].ToString());
                Producto.AlmacenMarketing = Int32.Parse(reader["AlmacenMarketing"].ToString());
                Producto.AlmacenAviacion2 = Int32.Parse(reader["AlmacenAviacion2"].ToString());
                Producto.AlmacenSanMiguel = Int32.Parse(reader["AlmacenSanMiguel"].ToString());
                
                Producto.TotalStock = Int32.Parse(reader["TotalStock"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaConsulta(int IdEmpresa, int IdTienda, string pFiltro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaConsulta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoTemporal = Decimal.Parse(reader["DescuentoTemporal"].ToString());
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Producto.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                Producto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaConsultaIdProducto(int IdEmpresa, int IdTienda, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaConsultaIdProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.DescuentoTemporal = Decimal.Parse(reader["DescuentoTemporal"].ToString());
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Producto.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                Producto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

        public List<ProductoBE> ListaID(int IdProducto, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_ListaID");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.DescUbicacion = reader["DescUbicacion"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }



        public List<ProductoBE> StockAlmacenCentral()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            //   DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_StockGeneral");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Producto_StockAlmacenCentral");
            dbCommand.CommandTimeout = 60;
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoBE> Productolist = new List<ProductoBE>();
            ProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ProductoBE();

                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Producto.DescProveedor = reader["DescProveedor"].ToString();
                Producto.PrecioPromedio = Decimal.Parse(reader["PrecioPromedio"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdSubLineaProducto = Int32.Parse(reader["IdSubLineaProducto"].ToString());
                Producto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Producto.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Producto.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                Producto.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                Producto.TotalStock = Int32.Parse(reader["TotalStock"].ToString());
                Producto.DescUbicacion = reader["DescUbicacion"].ToString();
                Producto.DescAlmacen = reader["DescAlmacen"].ToString();
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }


    }
}
