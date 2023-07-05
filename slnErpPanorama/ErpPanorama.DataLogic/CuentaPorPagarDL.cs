using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CuentaPorPagarDL
    {
        public CuentaPorPagarDL() { }

        #region codigo comentado
        //public Int32 Inserta(CuentaPorPagarBE pItem)
        //{
        //    Int32 Id = 0;
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Inserta");

        //    db.AddOutParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
        //    db.AddInParameter(dbCommand, "pNumSolicitudEgreso", DbType.String, pItem.NumSolicitudEgreso);
        //    db.AddInParameter(dbCommand, "pFechaSolicitudEgreso", DbType.DateTime, pItem.FechaSolicitudEgreso);
        //    db.AddInParameter(dbCommand, "pDescSolicitudEgreso", DbType.String, pItem.DescSolicitudEgreso);
        //    db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
        //    db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
        //    db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
        //    db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
        //    db.AddInParameter(dbCommand, "pNumOCompra", DbType.String, pItem.NumOCompra);

        //    db.AddInParameter(dbCommand, "pNroAbonoInicio", DbType.Int32, pItem.NroAbonoInicio);
        //    db.AddInParameter(dbCommand, "pNroAbonoFin", DbType.Int32, pItem.NroAbonoFin);

        //    db.AddInParameter(dbCommand, "pIdTipoEgreso", DbType.Int32, pItem.IdTipoEgreso);
        //    db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);

        //    db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
        //    db.AddInParameter(dbCommand, "pRazonSocialFactura", DbType.String, pItem.RazonSocialFactura);

        //    db.AddInParameter(dbCommand, "pIdCentroCosto", DbType.Int32, pItem.IdCentroCosto);
        //    db.AddInParameter(dbCommand, "pIdDetalleCentroCosto", DbType.Int32, pItem.IdDetalleCentroCosto);
        //    db.AddInParameter(dbCommand, "pObs", DbType.String, pItem.Obs);
        //    db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

        //    db.AddInParameter(dbCommand, "pCuentaContable", DbType.String, pItem.CuentaContable);
        //    db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);

        //    db.ExecuteNonQuery(dbCommand);

        //    Id = (int)db.GetParameterValue(dbCommand, "pIdSolicitudEgreso");

        //    return Id;
        //}
        #endregion

        public List<CuentaPorPagarBE> ListaTodosActivo(DateTime pFechaInicio, DateTime pFechaFin, String pRazonSocial)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.Date, pFechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.Date, pFechaFin);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pRazonSocial);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaPorPagarBE> DocumentoBultolist = new List<CuentaPorPagarBE>();
            CuentaPorPagarBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new CuentaPorPagarBE();

                SolicitudEgreso.IdCuentaPagar = Int32.Parse(reader["IdCuentaPagar"].ToString());
                SolicitudEgreso.FechaDoc = DateTime.Parse(reader["FechaDoc"].ToString());
                SolicitudEgreso.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                SolicitudEgreso.RucProveedor = reader["RucProveedor"].ToString();
                SolicitudEgreso.NombreProveedor = reader["NombreProveedor"].ToString();
                SolicitudEgreso.NumDoc = (reader["NumDoc"].ToString());
                SolicitudEgreso.IndiceBloque = (reader["IndiceBloque"].ToString());
                SolicitudEgreso.DesMoneda = (reader["DesMoneda"].ToString());
                SolicitudEgreso.DesSituacion = (reader["DesSituacion"].ToString());
                SolicitudEgreso.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                SolicitudEgreso.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                SolicitudEgreso.Observacion = reader["Observacion"].ToString();



                SolicitudEgreso.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudEgreso.TipoDocProveedor = Int32.Parse(reader["TipoDocProveedor"].ToString());
                SolicitudEgreso.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                SolicitudEgreso.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                SolicitudEgreso.IdBienServicio = Int32.Parse(reader["IdBienServicio"].ToString());
                SolicitudEgreso.IdTipoOperacion = Int32.Parse(reader["IdTipoOperacion"].ToString());
                SolicitudEgreso.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());

                DocumentoBultolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }

        public List<CuentaPorPagarBE> ListaTodosActivoTodo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_ListaTodosActivoTodo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaPorPagarBE> DocumentoBultolist = new List<CuentaPorPagarBE>();
            CuentaPorPagarBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new CuentaPorPagarBE();

                SolicitudEgreso.IdCuentaPagar = Int32.Parse(reader["IdCuentaPagar"].ToString());
                SolicitudEgreso.FechaDoc = DateTime.Parse(reader["FechaDoc"].ToString());
                SolicitudEgreso.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                SolicitudEgreso.RucProveedor = reader["RucProveedor"].ToString();
                SolicitudEgreso.NombreProveedor = reader["NombreProveedor"].ToString();
                SolicitudEgreso.NumDoc = (reader["NumDoc"].ToString());
                SolicitudEgreso.IndiceBloque = (reader["IndiceBloque"].ToString());
                SolicitudEgreso.DesMoneda = (reader["DesMoneda"].ToString());
                SolicitudEgreso.DesSituacion = (reader["DesSituacion"].ToString());
                SolicitudEgreso.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                SolicitudEgreso.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                SolicitudEgreso.Observacion = reader["Observacion"].ToString();



                SolicitudEgreso.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudEgreso.TipoDocProveedor = Int32.Parse(reader["TipoDocProveedor"].ToString());
                SolicitudEgreso.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                SolicitudEgreso.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                SolicitudEgreso.IdBienServicio = Int32.Parse(reader["IdBienServicio"].ToString());
                SolicitudEgreso.IdTipoOperacion = Int32.Parse(reader["IdTipoOperacion"].ToString());
                SolicitudEgreso.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());

                DocumentoBultolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }

        // EDGAR 250123: AGREGAR LISTA DE DETRACCIONES CON SU VALOR
        public List<TablaElementoDetraccionBE> ListaTodosActivoDetracciones()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_ListaTodosActivoDetracciones");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaElementoDetraccionBE> Detraccionlist = new List<TablaElementoDetraccionBE>();
            TablaElementoDetraccionBE Detraccion;

            while (reader.Read())
            {
                Detraccion = new TablaElementoDetraccionBE();
                Detraccion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Detraccion.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                Detraccion.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                Detraccion.DescTabla = reader["descTabla"].ToString();
                Detraccion.Abreviatura = reader["Abreviatura"].ToString();
                Detraccion.DescTablaElemento = reader["descTablaElemento"].ToString();
                Detraccion.Valor = Decimal.Parse(reader["valor"].ToString());
                Detraccion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Detraccionlist.Add(Detraccion);
            }
            reader.Close();
            reader.Dispose();

            return Detraccionlist;
        }

        // EDGAR 240123: AVANCE INSERTAR CUENTAS POR PAGAR -->
        public Int32 Inserta(CuentaPorPagarBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_Inserta");

            db.AddOutParameter(dbCommand, "pIdCuentaPagar", DbType.Int32, pItem.IdCuentaPagar);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFechaDoc", DbType.DateTime, pItem.FechaDoc);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pTipoDocProveedor", DbType.Int32, pItem.TipoDocProveedor);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pRucProveedor", DbType.String, pItem.RucProveedor);
            db.AddInParameter(dbCommand, "pNombreProveedor", DbType.String, pItem.NombreProveedor);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pImporteDolares", DbType.Decimal, pItem.ImporteDolares);
            db.AddInParameter(dbCommand, "pMontoAbono", DbType.Decimal, pItem.MontoAbono);
            db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, pItem.Saldo);
            db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);
            db.AddInParameter(dbCommand, "pIdBienServicio", DbType.Int32, pItem.IdBienServicio);
            db.AddInParameter(dbCommand, "pIdTipoOperacion", DbType.Int32, pItem.IdTipoOperacion);
            db.AddInParameter(dbCommand, "pIdCentroCosto", DbType.Int32, pItem.IdCentroCosto);
            db.AddInParameter(dbCommand, "pIdAsignar", DbType.Int32, pItem.IdAsignar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pCuentaBN", DbType.String, pItem.CuentaBN);
            db.AddInParameter(dbCommand, "pCuentaProv", DbType.String, pItem.CuentaProv);
            db.AddInParameter(dbCommand, "pfechaBloque", DbType.String, pItem.NumeroBloque);
            db.AddInParameter(dbCommand, "pIndiceBloque", DbType.String, pItem.NumeroBloque);
            db.AddInParameter(dbCommand, "pNumeroBloque", DbType.String, pItem.NumeroBloque);
            db.AddInParameter(dbCommand, "pEstado", DbType.Int32, pItem.Estado);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdCuentaPagar");

            return Id;
        }

        // EDGAR 240123: AVANCE INSERTAR CUENTAS POR PAGAR -->
        public void Actualiza(CuentaPorPagarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_Actualiza");

            db.AddInParameter(dbCommand, "pIdCuentaPagar", DbType.Int32, pItem.IdCuentaPagar);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFechaDoc", DbType.DateTime, pItem.FechaDoc);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pTipoDocProveedor", DbType.Int32, pItem.TipoDocProveedor);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pRucProveedor", DbType.String, pItem.RucProveedor);
            db.AddInParameter(dbCommand, "pNombreProveedor", DbType.String, pItem.NombreProveedor);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pImporteDolares", DbType.Decimal, pItem.ImporteDolares);
            db.AddInParameter(dbCommand, "pMontoAbono", DbType.Decimal, pItem.MontoAbono);
            db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, pItem.Saldo);
            db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);
            db.AddInParameter(dbCommand, "pIdBienServicio", DbType.Int32, pItem.IdBienServicio);
            db.AddInParameter(dbCommand, "pIdTipoOperacion", DbType.Int32, pItem.IdTipoOperacion);
            db.AddInParameter(dbCommand, "pIdCentroCosto", DbType.Int32, pItem.IdCentroCosto);
            db.AddInParameter(dbCommand, "pIdAsignar", DbType.Int32, pItem.IdAsignar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pCuentaBN", DbType.String, pItem.CuentaBN);
            db.AddInParameter(dbCommand, "pCuentaProv", DbType.String, pItem.CuentaProv);
            db.AddInParameter(dbCommand, "pfechaBloque", DbType.DateTime, pItem.fechaBloque);
            db.AddInParameter(dbCommand, "pIndiceBloque", DbType.String, pItem.IndiceBloque);
            db.AddInParameter(dbCommand, "pNumeroBloque", DbType.String, pItem.NumeroBloque);
            db.AddInParameter(dbCommand, "pEstado", DbType.Int32, pItem.Estado);

            db.ExecuteNonQuery(dbCommand);
        }

        // EDGAR 250123: AGREGAR BUSCAR CUENTA PARA PAGAR
        public CuentaPorPagarBE Buscar_CuentaPorPagar(int pIdCuentaPagar)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_Buscar");
            db.AddInParameter(dbCommand, "pIdCuentaPagar", DbType.Int32, pIdCuentaPagar);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CuentaPorPagarBE SolicitudEgreso = null;
            while (reader.Read())
            {
                SolicitudEgreso = new CuentaPorPagarBE();
                SolicitudEgreso.IdCuentaPagar = Int32.Parse(reader["IdCuentaPagar"].ToString());

                SolicitudEgreso.IdTipoOperacion = Int32.Parse(reader["IdTipoOperacion"].ToString());
                SolicitudEgreso.IdBienServicio = Int32.Parse(reader["IdBienServicio"].ToString());
                SolicitudEgreso.IdCentroCosto = Int32.Parse(reader["IdCentroCosto"].ToString());
                SolicitudEgreso.IdAsignar = Int32.Parse(reader["IdAsignar"].ToString());
                SolicitudEgreso.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudEgreso.TipoDocumento = reader["TipoDocumento"].ToString();
                SolicitudEgreso.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());

                SolicitudEgreso.FechaDoc = DateTime.Parse(reader["FechaDoc"].ToString());
                SolicitudEgreso.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                SolicitudEgreso.fechaBloque = (reader["fechaBloque"].ToString()) == "" ? DateTime.Now : DateTime.Parse(reader["fechaBloque"].ToString());

                SolicitudEgreso.TipoDocProveedor = Int32.Parse(reader["TipoDocProveedor"].ToString());
                SolicitudEgreso.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());

                SolicitudEgreso.Serie = reader["Serie"].ToString();
                SolicitudEgreso.Numero = reader["Numero"].ToString();
                SolicitudEgreso.NumDoc = reader["NumDoc"].ToString();
                SolicitudEgreso.RucProveedor = reader["RucProveedor"].ToString();
                SolicitudEgreso.NombreProveedor = reader["NombreProveedor"].ToString();
                SolicitudEgreso.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudEgreso.ImporteDolares = (reader["ImporteDolares"].ToString()) == "" ? 0 : Decimal.Parse(reader["ImporteDolares"].ToString());
                SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                SolicitudEgreso.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                SolicitudEgreso.TCambio = Decimal.Parse(reader["TCambio"].ToString());
                SolicitudEgreso.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudEgreso.Observacion = reader["Observacion"].ToString();
                SolicitudEgreso.CuentaBN = reader["CuentaBN"].ToString();
                SolicitudEgreso.CuentaProv = reader["CuentaProv"].ToString() == null ? "" : reader["CuentaProv"].ToString();

                SolicitudEgreso.NumeroBloque = reader["NumeroBloque"].ToString() == null ? "" : reader["NumeroBloque"].ToString();
                SolicitudEgreso.IndiceBloque = reader["IndiceBloque"].ToString() == null ? "" : reader["IndiceBloque"].ToString();

            }
            reader.Close();
            reader.Dispose();
            return SolicitudEgreso;
        }

        #region codigo comentado
        //public void EliminaDetalle(CuentaPorPagarBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Elimina");

        //    db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
        //    //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void AnulaSolicitud(CuentaPorPagarBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_AnulaSolicitud");

        //    db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);

        //    db.ExecuteNonQuery(dbCommand);
        //}
        #endregion

        // EDGAR 260123: AGREGAR ANULAR CUENTA POR PAGAR
        public void Anula(CuentaPorPagarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_Elimina");

            db.AddInParameter(dbCommand, "pEstado", DbType.Int32, pItem.Estado);
            db.AddInParameter(dbCommand, "pIdCuentaPagar", DbType.Int32, pItem.IdCuentaPagar);

            db.ExecuteNonQuery(dbCommand);
        }
        //

        // EDGAR 260123: AGREGAR LISTADO POR SITUACION
        public List<CuentaPorPagarBE> ListaPorSituacion(Int32 pIdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_ListaPorSituacion");
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pIdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaPorPagarBE> DocumentoBultolist = new List<CuentaPorPagarBE>();
            CuentaPorPagarBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new CuentaPorPagarBE();

                SolicitudEgreso.IdCuentaPagar = Int32.Parse(reader["IdCuentaPagar"].ToString());
                SolicitudEgreso.TipoProveedor = reader["TipoProveedor"].ToString();
                SolicitudEgreso.RucProveedor = reader["RucProveedor"].ToString();
                SolicitudEgreso.NombreProveedor = reader["NombreProveedor"].ToString();
                SolicitudEgreso.Prof = reader["Prof"].ToString();
                SolicitudEgreso.AbBienServicio = reader["AbBienServicio"].ToString();
                SolicitudEgreso.CuentaBN = reader["CuentaBN"].ToString();
                SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                SolicitudEgreso.AbTipoOperacion = reader["AbTipoOperacion"].ToString();
                SolicitudEgreso.Periodo = reader["Periodo"].ToString();
                SolicitudEgreso.AbTipoDocumento = reader["AbTipoDocumento"].ToString();
                SolicitudEgreso.Serie = reader["Serie"].ToString();
                SolicitudEgreso.Numero = reader["Numero"].ToString();
                SolicitudEgreso.IdSituacion = Convert.ToInt32(reader["IdSituacion"].ToString());
                SolicitudEgreso.Saldo = Decimal.Parse(reader["Saldo"].ToString());


                SolicitudEgreso.TipoDocumento = (reader["TipoDocumento"].ToString());
                SolicitudEgreso.NumDoc = (reader["NumDoc"].ToString());
                SolicitudEgreso.Importe = Decimal.Parse(reader["Importe"].ToString());

                DocumentoBultolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }

        public List<CuentaPorPagarBE> ListaPorSituacionBloque(Int32 pIdSituacion, String pIndiceBloque)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_ListaPorSituacionBloque");
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pIdSituacion);
            db.AddInParameter(dbCommand, "pIndiceBloque", DbType.String, pIndiceBloque);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaPorPagarBE> DocumentoBultolist = new List<CuentaPorPagarBE>();
            CuentaPorPagarBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new CuentaPorPagarBE();

                SolicitudEgreso.IdCuentaPagar = Int32.Parse(reader["IdCuentaPagar"].ToString());
                SolicitudEgreso.indexcpp = Int32.Parse(reader["indexcpp"].ToString());
                SolicitudEgreso.TipoProveedor = reader["TipoProveedor"].ToString();
                SolicitudEgreso.RucProveedor = reader["RucProveedor"].ToString();
                SolicitudEgreso.NombreProveedor = reader["NombreProveedor"].ToString();
                SolicitudEgreso.Prof = reader["Prof"].ToString();
                SolicitudEgreso.AbBienServicio = reader["AbBienServicio"].ToString();
                SolicitudEgreso.CuentaBN = reader["CuentaBN"].ToString();
                SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                SolicitudEgreso.AbTipoOperacion = reader["AbTipoOperacion"].ToString();
                SolicitudEgreso.Periodo = reader["Periodo"].ToString();
                SolicitudEgreso.AbTipoDocumento = reader["AbTipoDocumento"].ToString();
                SolicitudEgreso.Serie = reader["Serie"].ToString();
                SolicitudEgreso.Numero = reader["Numero"].ToString();
                SolicitudEgreso.IdSituacion = Convert.ToInt32(reader["IdSituacion"].ToString());
                SolicitudEgreso.Saldo = Decimal.Parse(reader["Saldo"].ToString());


                SolicitudEgreso.TipoDocumento = (reader["TipoDocumento"].ToString());
                SolicitudEgreso.NumDoc = (reader["NumDoc"].ToString());
                SolicitudEgreso.Importe = Decimal.Parse(reader["Importe"].ToString());

                SolicitudEgreso.FechaDoc = DateTime.Parse(reader["FechaDoc"].ToString());
                SolicitudEgreso.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                SolicitudEgreso.fechaBloque = DateTime.Parse(reader["fechaBloque"].ToString());
                SolicitudEgreso.DesMoneda = (reader["DesMoneda"].ToString());
                SolicitudEgreso.Observacion = (reader["Observacion"].ToString());


                DocumentoBultolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }

        public List<CuentaPorPagarBE> ListaPorBloque(String pIndiceBloque)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_ListaPorBloque");
            db.AddInParameter(dbCommand, "pIndiceBloque", DbType.String, pIndiceBloque);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaPorPagarBE> DocumentoBultolist = new List<CuentaPorPagarBE>();
            CuentaPorPagarBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new CuentaPorPagarBE();

                SolicitudEgreso.IdCuentaPagar = Int32.Parse(reader["IdCuentaPagar"].ToString());
                SolicitudEgreso.indexcpp = Int32.Parse(reader["indexcpp"].ToString());
                SolicitudEgreso.TipoProveedor = reader["TipoProveedor"].ToString();
                SolicitudEgreso.RucProveedor = reader["RucProveedor"].ToString();
                SolicitudEgreso.NombreProveedor = reader["NombreProveedor"].ToString();
                SolicitudEgreso.Prof = reader["Prof"].ToString();
                SolicitudEgreso.AbBienServicio = reader["AbBienServicio"].ToString();
                SolicitudEgreso.CuentaBN = reader["CuentaBN"].ToString();
                SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                SolicitudEgreso.AbTipoOperacion = reader["AbTipoOperacion"].ToString();
                SolicitudEgreso.Periodo = reader["Periodo"].ToString();
                SolicitudEgreso.AbTipoDocumento = reader["AbTipoDocumento"].ToString();
                SolicitudEgreso.Serie = reader["Serie"].ToString();
                SolicitudEgreso.Numero = reader["Numero"].ToString();
                SolicitudEgreso.IdSituacion = Convert.ToInt32(reader["IdSituacion"].ToString());
                SolicitudEgreso.Saldo = Decimal.Parse(reader["Saldo"].ToString());


                SolicitudEgreso.TipoDocumento = (reader["TipoDocumento"].ToString());
                SolicitudEgreso.NumDoc = (reader["NumDoc"].ToString());
                SolicitudEgreso.Importe = Decimal.Parse(reader["Importe"].ToString());

                SolicitudEgreso.FechaDoc = DateTime.Parse(reader["FechaDoc"].ToString());
                SolicitudEgreso.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                SolicitudEgreso.fechaBloque = DateTime.Parse(reader["fechaBloque"].ToString());
                SolicitudEgreso.DesMoneda = (reader["DesMoneda"].ToString());
                SolicitudEgreso.Observacion = (reader["Observacion"].ToString());


                DocumentoBultolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }

        #region codigo comentado
        //public List<CuentaPorPagarBE> BuscarSolicitud(string pNumero)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_BuscarNumeroSolicitud");
        //    db.AddInParameter(dbCommand, "pNumero", DbType.String, pNumero);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<CuentaPorPagarBE> DocumentoBultolist = new List<CuentaPorPagarBE>();
        //    CuentasPorPagarE SolicitudEgreso;
        //    while (reader.Read())
        //    {
        //        SolicitudEgreso = new CuentaPorPagarBE();

        //        SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
        //        SolicitudEgreso.NumSolicitudEgreso = (reader["NumSolicitudEgreso"].ToString());
        //        SolicitudEgreso.FechaSolicitudEgreso = DateTime.Parse(reader["FechaSolicitudEgreso"].ToString());
        //        SolicitudEgreso.DescSolicitudEgreso = reader["DescSolicitudEgreso"].ToString();

        //        SolicitudEgreso.NumeroDocumento = reader["NumeroDocumento"].ToString();
        //        SolicitudEgreso.DescProveedor = reader["DescProveedor"].ToString();

        //        SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
        //        SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
        //        SolicitudEgreso.Moneda = reader["Moneda"].ToString();
        //        SolicitudEgreso.Solicita = reader["Solicita"].ToString();
        //        SolicitudEgreso.NumOCompra = reader["NumOCompra"].ToString();
        //        SolicitudEgreso.NroAbonos = reader["NroAbonos"].ToString();

        //        SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();

        //        SolicitudEgreso.Tienda = reader["Tienda"].ToString();
        //        SolicitudEgreso.RazonSocialFactura = reader["RazonSocialFactura"].ToString();
        //        SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();
        //        SolicitudEgreso.Asignar = reader["Asignar"].ToString();
        //        SolicitudEgreso.Obs = reader["Obs"].ToString();

        //        SolicitudEgreso.Total = Decimal.Parse(reader["Total"].ToString());
        //        SolicitudEgreso.Usuario = reader["Usuario"].ToString();
        //        SolicitudEgreso.Situacion = reader["Situacion"].ToString();

        //        SolicitudEgreso.Telefono = reader["Telefono"].ToString();
        //        SolicitudEgreso.Correo = reader["Correo"].ToString();

        //        DocumentoBultolist.Add(SolicitudEgreso);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return DocumentoBultolist;
        //}

        //public List<CuentaPorPagarBE> ObtenerCorrelativoPeriodo(int Periodo)
        //{
        //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionSolicitud_ObtenerCorrelativoPeriodo");
        //db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

        //IDataReader reader = db.ExecuteReader(dbCommand);
        //List<CuentaPorPagarBE> NumeracionDocumentolist = new List<CuentaPorPagarBE>();
        //SolicitudEgresoBE NumeracionDocumento;
        //while (reader.Read())
        //{
        //    NumeracionDocumento = new CuentaPorPagarBE();
        //    NumeracionDocumento.Numero = Int32.Parse(reader["NumeroSolicitudEgreso"].ToString());
        //    NumeracionDocumentolist.Add(NumeracionDocumento);
        //}
        //reader.Close();
        //reader.Dispose();
        //return NumeracionDocumentolist;

        //}

        //public CuentaPorPagarBE Buscar_SolicitudEgreso(int IdSolicitudEgreso)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Buscar");
        //    db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, IdSolicitudEgreso);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    CuentaPorPagarBE SolicitudEgreso = null;
        //    while (reader.Read())
        //    {
        //        SolicitudEgreso = new CuentaPorPagarBE();

        //        SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
        //        SolicitudEgreso.NumSolicitudEgreso = (reader["NumSolicitudEgreso"].ToString());
        //        SolicitudEgreso.FechaSolicitudEgreso = DateTime.Parse(reader["FechaSolicitudEgreso"].ToString());
        //        SolicitudEgreso.DescSolicitudEgreso = reader["DescSolicitudEgreso"].ToString();

        //        SolicitudEgreso.NumeroDocumento = reader["NumeroDocumento"].ToString();

        //        SolicitudEgreso.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
        //        SolicitudEgreso.DescProveedor = reader["DescProveedor"].ToString();

        //        SolicitudEgreso.IdBanco = Int32.Parse(reader["IdBanco"].ToString());

        //        SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
        //        SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
        //        SolicitudEgreso.CCI = reader["CCI"].ToString();
        //        SolicitudEgreso.Moneda = reader["Moneda"].ToString();
        //        SolicitudEgreso.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());

        //        SolicitudEgreso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
        //        SolicitudEgreso.Solicita = reader["Solicita"].ToString();
        //        SolicitudEgreso.NumOCompra = reader["NumOCompra"].ToString();

        //        SolicitudEgreso.NroAbonoInicio = Int32.Parse(reader["NroAbonoInicio"].ToString());
        //        SolicitudEgreso.NroAbonoFin = Int32.Parse(reader["NroAbonoFin"].ToString());
        //        SolicitudEgreso.NroAbonos = reader["NroAbonos"].ToString();

        //        SolicitudEgreso.IdTipoEgreso = Int32.Parse(reader["IdTipoEgreso"].ToString());
        //        SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();

        //        SolicitudEgreso.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
        //        SolicitudEgreso.Tienda = reader["Tienda"].ToString();

        //        SolicitudEgreso.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
        //        SolicitudEgreso.RazonSocialFactura = reader["DescCliente"].ToString();

        //        SolicitudEgreso.IdCentroCosto = Int32.Parse(reader["IdCentroCosto"].ToString());
        //        SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();

        //        SolicitudEgreso.IdDetalleCentroCosto = Int32.Parse(reader["IdDetalleCentroCosto"].ToString());
        //        SolicitudEgreso.Asignar = reader["Asignar"].ToString();

        //        SolicitudEgreso.Obs = reader["Obs"].ToString();

        //        SolicitudEgreso.Total = Decimal.Parse(reader["Total"].ToString());
        //        SolicitudEgreso.Usuario = reader["Usuario"].ToString();
        //        SolicitudEgreso.Situacion = reader["Situacion"].ToString();

        //        SolicitudEgreso.Telefono = reader["Telefono"].ToString();
        //        SolicitudEgreso.Correo = reader["Correo"].ToString();

        //        SolicitudEgreso.CuentaContable = reader["cuentacontable"].ToString();
        //        SolicitudEgreso.TCambio = Decimal.Parse(reader["TCambio"].ToString());
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return SolicitudEgreso;
        //}
        #endregion

        #region codigo comentado
        //public CuentaPorPagarBE TotalPendientePago(DateTime pFechaInicio, DateTime pFechaFin)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_ConsultaPagosPendientesSolicitudes");
        //    db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pFechaInicio);
        //    db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pFechaFin);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    CuentaPorPagarBE SolicitudEgreso = null;
        //    while (reader.Read())
        //    {
        //        SolicitudEgreso = new CuentaPorPagarBE();

        //        SolicitudEgreso.Panorama = Decimal.Parse(reader["Panorama"].ToString());
        //        SolicitudEgreso.Decoratex = Decimal.Parse(reader["Decoratex"].ToString());

        //        SolicitudEgreso.PanoramaD = Decimal.Parse(reader["PanoramaD"].ToString());
        //        SolicitudEgreso.DecoratexD = Decimal.Parse(reader["DecoratexD"].ToString());
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return SolicitudEgreso;
        //}

        //public List<CuentaPorPagarBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_ListaFecha");
        //    db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
        //    db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<CuentaPorPagarBE> PrestamoBancolist = new List<CuentaPorPagarBE>();
        //    CuentaPorPagarBE SolicitudEgreso;
        //    while (reader.Read())
        //    {
        //        SolicitudEgreso = new CuentaPorPagarBE();
        //        SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
        //        SolicitudEgreso.FechaAPagar = DateTime.Parse(reader["FechaAPagar"].ToString());
        //        SolicitudEgreso.NumSolicitudEgreso = reader["NumSolicitudEgreso"].ToString();

        //        SolicitudEgreso.Solicita = reader["Solicita"].ToString();

        //        SolicitudEgreso.DescProveedor = reader["Proveedor"].ToString();
        //        SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
        //        SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
        //        SolicitudEgreso.RazonSocialFactura = reader["RazonSocialAFacturar"].ToString();
        //        SolicitudEgreso.DescMoneda = reader["Moneda"].ToString();
        //        SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
        //        SolicitudEgreso.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));

        //        SolicitudEgreso.UsuarioPago = reader["UsuarioPago"].ToString();

        //        PrestamoBancolist.Add(SolicitudEgreso);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return PrestamoBancolist;
        //}


        //public void Actualiza(CuentaPorPagarBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Actualiza");

        //    db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
        //    db.AddInParameter(dbCommand, "pDescSolicitudEgreso", DbType.String, pItem.DescSolicitudEgreso);
        //    db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
        //    db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
        //    db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
        //    db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
        //    db.AddInParameter(dbCommand, "pNumOCompra", DbType.String, pItem.NumOCompra);

        //    db.AddInParameter(dbCommand, "pNroAbonoInicio", DbType.Int32, pItem.NroAbonoInicio);
        //    db.AddInParameter(dbCommand, "pNroAbonoFin", DbType.Int32, pItem.NroAbonoFin);

        //    db.AddInParameter(dbCommand, "pIdTipoEgreso", DbType.Int32, pItem.IdTipoEgreso);
        //    db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);

        //    db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
        //    db.AddInParameter(dbCommand, "pRazonSocialFactura", DbType.String, pItem.RazonSocialFactura);

        //    db.AddInParameter(dbCommand, "pIdCentroCosto", DbType.Int32, pItem.IdCentroCosto);
        //    db.AddInParameter(dbCommand, "pIdDetalleCentroCosto", DbType.Int32, pItem.IdDetalleCentroCosto);
        //    db.AddInParameter(dbCommand, "pObs", DbType.String, pItem.Obs);
        //    db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    //db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);

        //    db.AddInParameter(dbCommand, "pCuentaContable", DbType.String, pItem.CuentaContable);
        //    db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);
        //    db.ExecuteNonQuery(dbCommand);
        //}
        #endregion

        // EDGAR 260123: AGREGAR CAMBIO SITUACION -->
        public void CambiaSituacion(CuentaPorPagarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_CambiaSituacion");

            db.AddInParameter(dbCommand, "pIdCuentaPagar", DbType.Int32, pItem.IdCuentaPagar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pfechaBloque", DbType.DateTime, pItem.fechaBloque);
            db.AddInParameter(dbCommand, "pIndiceBloque", DbType.String, pItem.IndiceBloque);
            db.AddInParameter(dbCommand, "pNumeroBloque", DbType.String, pItem.NumeroBloque);

            db.ExecuteNonQuery(dbCommand);
        }

        public void VolverSituacion(CuentaPorPagarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_VolverSituacion");

            db.AddInParameter(dbCommand, "pIdCuentaPagar", DbType.Int32, pItem.IdCuentaPagar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);

            db.ExecuteNonQuery(dbCommand);
        }
        //

        public void VolverSituacion2(CuentaPorPagarBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_VolverSituacion2");

            db.AddInParameter(dbCommand, "pIdCuentaPagar", DbType.Int32, pItem.IdCuentaPagar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pfechaBloque", DbType.DateTime, pItem.fechaBloque);
            db.AddInParameter(dbCommand, "pIndiceBloque", DbType.String, pItem.IndiceBloque);
            db.AddInParameter(dbCommand, "pNumeroBloque", DbType.String, pItem.NumeroBloque);

            db.ExecuteNonQuery(dbCommand);
        }

        public CuentaPorPagarBE GetCorrelativo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_GetCorrelativo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            CuentaPorPagarBE SolicitudEgreso = null;
            while (reader.Read())
            {
                SolicitudEgreso = new CuentaPorPagarBE();
                SolicitudEgreso.fechaBloque = DateTime.Parse(reader["fechaBloque"].ToString());
                SolicitudEgreso.NumeroBloque = reader["NumeroBloque"].ToString();
                SolicitudEgreso.cantbloque = Int32.Parse(reader["cantbloque"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEgreso;
        }

        public String GetGetCuentaBN(Int32 IdProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_GetCuentaBN");
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CuentaBancoProveedorBE CuentaBancoProveedor = null;
            while (reader.Read())
            {
                CuentaBancoProveedor = new CuentaBancoProveedorBE();
                CuentaBancoProveedor.Cuenta = reader["Cuenta"].ToString();
            }

            return CuentaBancoProveedor.Cuenta;
        }

        public Decimal GetTCxFechaEmision(DateTime FechaDoc, Int32 IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaPorPagar_GetTCxFechaEmision");
            db.AddInParameter(dbCommand, "pFechaDoc", DbType.DateTime, FechaDoc);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoCambioBE TipoCambio = null;
            while (reader.Read())
            {
                TipoCambio = new TipoCambioBE();
                TipoCambio.Venta = decimal.Parse(reader["Venta"].ToString());
            }

            return TipoCambio.Venta;
        }
    }
}
