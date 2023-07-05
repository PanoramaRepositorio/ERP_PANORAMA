using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_ProyectoServicioDL
    {
        public Dis_ProyectoServicioDL() { }

        public Int32 Inserta(Dis_ProyectoServicioBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_Inserta");

            db.AddOutParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pRutaArchivo", DbType.String, pItem.RutaArchivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);

            db.AddInParameter(dbCommand, "pDescTipoCasa", DbType.String, pItem.DescTipoCasa);
            db.AddInParameter(dbCommand, "pDescAmbiente", DbType.String, pItem.DescAmbiente);
            db.AddInParameter(dbCommand, "pPiso", DbType.Int32, pItem.Piso);
            db.AddInParameter(dbCommand, "pObjetivos", DbType.String, pItem.Objetivos);
            db.AddInParameter(dbCommand, "pIluminacion", DbType.String, pItem.Iluminacion);
            db.AddInParameter(dbCommand, "pAcustica", DbType.String, pItem.Acustica);
            db.AddInParameter(dbCommand, "pArea", DbType.String, pItem.Area);
            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pFechaVisita", DbType.DateTime, pItem.FechaVisita);
            db.AddInParameter(dbCommand, "pIdDis_ContratoAsesoria", DbType.Int32, pItem.IdDis_ContratoAsesoria);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pPagoAsesoria", DbType.Decimal, pItem.PagoAsesoria);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdDis_ProyectoServicio");

            return intIdCliente;

        }

        public void Actualiza(Dis_ProyectoServicioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pRutaArchivo", DbType.String, pItem.RutaArchivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);

            db.AddInParameter(dbCommand, "pDescTipoCasa", DbType.String, pItem.DescTipoCasa);
            db.AddInParameter(dbCommand, "pDescAmbiente", DbType.String, pItem.DescAmbiente);
            db.AddInParameter(dbCommand, "pPiso", DbType.Int32, pItem.Piso);
            db.AddInParameter(dbCommand, "pObjetivos", DbType.String, pItem.Objetivos);
            db.AddInParameter(dbCommand, "pIluminacion", DbType.String, pItem.Iluminacion);
            db.AddInParameter(dbCommand, "pAcustica", DbType.String, pItem.Acustica);
            db.AddInParameter(dbCommand, "pArea", DbType.String, pItem.Area);
            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pFechaVisita", DbType.DateTime, pItem.FechaVisita);
            db.AddInParameter(dbCommand, "pIdDis_ContratoAsesoria", DbType.Int32, pItem.IdDis_ContratoAsesoria);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pPagoAsesoria", DbType.Decimal, pItem.PagoAsesoria);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaSituacion(Dis_ProyectoServicioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCierre(Dis_ProyectoServicioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_ActualizaCierre");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pFlagCerrado", DbType.Boolean, pItem.FlagCerrado);
            db.AddInParameter(dbCommand, "pFlagPlano", DbType.Boolean, pItem.FlagPlano);
            db.AddInParameter(dbCommand, "pFlagVisita", DbType.Boolean, pItem.FlagVisita);
            db.AddInParameter(dbCommand, "pFlagInstalaTermina", DbType.Boolean, pItem.FlagInstalaTermina);
            db.AddInParameter(dbCommand, "pFlagEncuestaPostVenta", DbType.Boolean, pItem.FlagEncuestaPostVenta);
            db.AddInParameter(dbCommand, "pFlagConforme", DbType.Boolean, pItem.FlagConforme);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }



        public void Elimina(Dis_ProyectoServicioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_ProyectoServicioBE> ListaTodosActivo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_ProyectoServicioBE> Dis_ProyectoServiciolist = new List<Dis_ProyectoServicioBE>();
            Dis_ProyectoServicioBE Dis_ProyectoServicio;
            while (reader.Read())
            {
                Dis_ProyectoServicio = new Dis_ProyectoServicioBE();
                Dis_ProyectoServicio.IdDis_ProyectoServicio = Int32.Parse(reader["idDis_ProyectoServicio"].ToString());
                Dis_ProyectoServicio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ProyectoServicio.Numero = reader["Numero"].ToString();
                Dis_ProyectoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Dis_ProyectoServicio.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Dis_ProyectoServicio.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                Dis_ProyectoServicio.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ProyectoServicio.DescCliente = reader["DescCliente"].ToString();
                Dis_ProyectoServicio.Direccion = reader["Direccion"].ToString();
                Dis_ProyectoServicio.IdAsesor = Convert.ToInt32(reader["IdAsesor"].ToString());
                Dis_ProyectoServicio.DescAsesor = reader["DescAsesor"].ToString();
                Dis_ProyectoServicio.IdVendedor = reader.IsDBNull(reader.GetOrdinal("IdVendedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor"));
                Dis_ProyectoServicio.DescVendedor = reader["DescVendedor"].ToString();
                Dis_ProyectoServicio.IdMoneda = Convert.ToInt32(reader["IdMoneda"].ToString());
                Dis_ProyectoServicio.DescMoneda = reader["DescMoneda"].ToString();
                Dis_ProyectoServicio.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                Dis_ProyectoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
                Dis_ProyectoServicio.RutaArchivo = reader["RutaArchivo"].ToString();
                Dis_ProyectoServicio.Observacion = reader["Observacion"].ToString();
                Dis_ProyectoServicio.IdSituacion = Convert.ToInt32(reader["IdSituacion"].ToString());
                Dis_ProyectoServicio.DescSituacion = reader["DescSituacion"].ToString();

                Dis_ProyectoServicio.DescTipoCasa = reader["DescTipoCasa"].ToString();
                Dis_ProyectoServicio.DescAmbiente = reader["DescAmbiente"].ToString();
                Dis_ProyectoServicio.Piso = Convert.ToInt32(reader["Piso"].ToString());
                Dis_ProyectoServicio.Objetivos = reader["Objetivos"].ToString();
                Dis_ProyectoServicio.Iluminacion = reader["Iluminacion"].ToString();
                Dis_ProyectoServicio.Acustica = reader["Acustica"].ToString();
                Dis_ProyectoServicio.Area = reader["Area"].ToString();
                Dis_ProyectoServicio.IdDis_Forma = Convert.ToInt32(reader["IdDis_Forma"].ToString());
                Dis_ProyectoServicio.DescDis_Forma = reader["DescDis_Forma"].ToString();
                Dis_ProyectoServicio.IdDis_Estilo = Convert.ToInt32(reader["IdDis_Estilo"].ToString());
                Dis_ProyectoServicio.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                Dis_ProyectoServicio.FechaVisita = reader.IsDBNull(reader.GetOrdinal("FechaVisita")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVisita"));
                Dis_ProyectoServicio.IdDis_ContratoAsesoria = Convert.ToInt32(reader["IdDis_ContratoAsesoria"].ToString());
                Dis_ProyectoServicio.Distrito = reader["Distrito"].ToString();
                Dis_ProyectoServicio.TotalPedido = Convert.ToDecimal(reader["TotalPedido"].ToString());
                Dis_ProyectoServicio.FechaPedido = reader.IsDBNull(reader.GetOrdinal("FechaPedido")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPedido"));
                Dis_ProyectoServicio.FlagCerrado = Boolean.Parse(reader["FlagCerrado"].ToString());
                Dis_ProyectoServicio.FlagPlano = Boolean.Parse(reader["FlagPlano"].ToString());
                Dis_ProyectoServicio.FlagVisita = Boolean.Parse(reader["FlagVisita"].ToString());
                Dis_ProyectoServicio.FlagInstalaTermina = Boolean.Parse(reader["FlagInstalaTermina"].ToString());
                Dis_ProyectoServicio.FlagEncuestaPostVenta = Boolean.Parse(reader["FlagEncuestaPostVenta"].ToString());
                Dis_ProyectoServicio.FlagConforme = Boolean.Parse(reader["FlagConforme"].ToString());
                Dis_ProyectoServicio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ProyectoServicio.Motivo = reader["Motivo"].ToString();

                Dis_ProyectoServiciolist.Add(Dis_ProyectoServicio);
            }
            reader.Close();
            reader.Dispose();
            return Dis_ProyectoServiciolist;
        }

        public List<Dis_ProyectoServicioBE> ListaSituacionCliente(int IdEmpresa, int IdCliente, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_ListaSituacionCliente");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_ProyectoServicioBE> Dis_ProyectoServiciolist = new List<Dis_ProyectoServicioBE>();
            Dis_ProyectoServicioBE Dis_ProyectoServicio;
            while (reader.Read())
            {
                Dis_ProyectoServicio = new Dis_ProyectoServicioBE();
                Dis_ProyectoServicio.IdDis_ProyectoServicio = Int32.Parse(reader["idDis_ProyectoServicio"].ToString());
                Dis_ProyectoServicio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ProyectoServicio.Numero = reader["Numero"].ToString();
                Dis_ProyectoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Dis_ProyectoServicio.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Dis_ProyectoServicio.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                Dis_ProyectoServicio.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ProyectoServicio.DescCliente = reader["DescCliente"].ToString();
                Dis_ProyectoServicio.Direccion = reader["Direccion"].ToString();
                Dis_ProyectoServicio.IdAsesor = Convert.ToInt32(reader["IdAsesor"].ToString());
                Dis_ProyectoServicio.DescAsesor = reader["DescAsesor"].ToString();
                Dis_ProyectoServicio.IdVendedor = reader.IsDBNull(reader.GetOrdinal("IdVendedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor"));
                Dis_ProyectoServicio.DescVendedor = reader["DescVendedor"].ToString();
                Dis_ProyectoServicio.IdMoneda = Convert.ToInt32(reader["IdMoneda"].ToString());
                Dis_ProyectoServicio.DescMoneda = reader["DescMoneda"].ToString();
                Dis_ProyectoServicio.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                Dis_ProyectoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
                Dis_ProyectoServicio.RutaArchivo = reader["RutaArchivo"].ToString();
                Dis_ProyectoServicio.Observacion = reader["Observacion"].ToString();
                Dis_ProyectoServicio.IdSituacion = Convert.ToInt32(reader["IdSituacion"].ToString());
                Dis_ProyectoServicio.DescSituacion = reader["DescSituacion"].ToString();

                Dis_ProyectoServicio.DescTipoCasa = reader["DescTipoCasa"].ToString();
                Dis_ProyectoServicio.DescAmbiente = reader["DescAmbiente"].ToString();
                Dis_ProyectoServicio.Piso = Convert.ToInt32(reader["Piso"].ToString());
                Dis_ProyectoServicio.Objetivos = reader["Objetivos"].ToString();
                Dis_ProyectoServicio.Iluminacion = reader["Iluminacion"].ToString();
                Dis_ProyectoServicio.Acustica = reader["Acustica"].ToString();
                Dis_ProyectoServicio.Area = reader["Area"].ToString();
                Dis_ProyectoServicio.IdDis_Forma = Convert.ToInt32(reader["IdDis_Forma"].ToString());
                Dis_ProyectoServicio.DescDis_Forma = reader["DescDis_Forma"].ToString();
                Dis_ProyectoServicio.IdDis_Estilo = Convert.ToInt32(reader["IdDis_Estilo"].ToString());
                Dis_ProyectoServicio.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                Dis_ProyectoServicio.FechaVisita = reader.IsDBNull(reader.GetOrdinal("FechaVisita")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVisita"));
                Dis_ProyectoServicio.IdDis_ContratoAsesoria = Convert.ToInt32(reader["IdDis_ContratoAsesoria"].ToString());
                Dis_ProyectoServicio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ProyectoServiciolist.Add(Dis_ProyectoServicio);
            }
            reader.Close();
            reader.Dispose();
            return Dis_ProyectoServiciolist;
        }

        public Dis_ProyectoServicioBE Selecciona(int IdDis_ProyectoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_Selecciona");
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            Dis_ProyectoServicioBE Dis_ProyectoServicio = null;
            while (reader.Read())
            {
                Dis_ProyectoServicio = new Dis_ProyectoServicioBE();
                Dis_ProyectoServicio.IdDis_ProyectoServicio = Int32.Parse(reader["idDis_ProyectoServicio"].ToString());
                Dis_ProyectoServicio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ProyectoServicio.Numero = reader["Numero"].ToString();
                Dis_ProyectoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Dis_ProyectoServicio.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Dis_ProyectoServicio.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                Dis_ProyectoServicio.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ProyectoServicio.DescCliente = reader["DescCliente"].ToString();
                Dis_ProyectoServicio.Direccion = reader["Direccion"].ToString();
                Dis_ProyectoServicio.IdAsesor = Convert.ToInt32(reader["IdAsesor"].ToString());
                Dis_ProyectoServicio.DescAsesor = reader["DescAsesor"].ToString();
                Dis_ProyectoServicio.IdVendedor = reader.IsDBNull(reader.GetOrdinal("IdVendedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor"));
                Dis_ProyectoServicio.DescVendedor = reader["DescVendedor"].ToString();
                Dis_ProyectoServicio.IdMoneda = Convert.ToInt32(reader["IdMoneda"].ToString());
                Dis_ProyectoServicio.DescMoneda = reader["DescMoneda"].ToString();
                Dis_ProyectoServicio.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                Dis_ProyectoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
                Dis_ProyectoServicio.RutaArchivo = reader["RutaArchivo"].ToString();
                Dis_ProyectoServicio.Observacion = reader["Observacion"].ToString();
                Dis_ProyectoServicio.IdSituacion = Convert.ToInt32(reader["IdSituacion"].ToString());
                Dis_ProyectoServicio.DescSituacion = reader["DescSituacion"].ToString();

                Dis_ProyectoServicio.DescTipoCasa = reader["DescTipoCasa"].ToString();
                Dis_ProyectoServicio.DescAmbiente = reader["DescAmbiente"].ToString();
                Dis_ProyectoServicio.Piso = Convert.ToInt32(reader["Piso"].ToString());
                Dis_ProyectoServicio.Objetivos = reader["Objetivos"].ToString();
                Dis_ProyectoServicio.Iluminacion = reader["Iluminacion"].ToString();
                Dis_ProyectoServicio.Acustica = reader["Acustica"].ToString();
                Dis_ProyectoServicio.Area = reader["Area"].ToString();
                Dis_ProyectoServicio.IdDis_Forma = Convert.ToInt32(reader["IdDis_Forma"].ToString());
                Dis_ProyectoServicio.DescDis_Forma = reader["DescDis_Forma"].ToString();
                Dis_ProyectoServicio.IdDis_Estilo = Convert.ToInt32(reader["IdDis_Estilo"].ToString());
                Dis_ProyectoServicio.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                Dis_ProyectoServicio.FechaVisita = reader.IsDBNull(reader.GetOrdinal("FechaVisita")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVisita"));
                Dis_ProyectoServicio.IdDis_ContratoAsesoria = Convert.ToInt32(reader["IdDis_ContratoAsesoria"].ToString());
                Dis_ProyectoServicio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ProyectoServicio.PagoAsesoria = Decimal.Parse(reader["PagoAsesoria"].ToString());
                Dis_ProyectoServicio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Dis_ProyectoServicio;
        }

        public Dis_ProyectoServicioBE SeleccionaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ProyectoServicio_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            Dis_ProyectoServicioBE Dis_ProyectoServicio = null;
            while (reader.Read())
            {
                Dis_ProyectoServicio = new Dis_ProyectoServicioBE();
                Dis_ProyectoServicio.IdDis_ProyectoServicio = Int32.Parse(reader["idDis_ProyectoServicio"].ToString());
                Dis_ProyectoServicio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ProyectoServicio.Numero = reader["Numero"].ToString();
                Dis_ProyectoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Dis_ProyectoServicio.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Dis_ProyectoServicio.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                Dis_ProyectoServicio.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ProyectoServicio.DescCliente = reader["DescCliente"].ToString();
                Dis_ProyectoServicio.Direccion = reader["Direccion"].ToString();
                Dis_ProyectoServicio.IdAsesor = Convert.ToInt32(reader["IdAsesor"].ToString());
                Dis_ProyectoServicio.DescAsesor = reader["DescAsesor"].ToString();
                Dis_ProyectoServicio.IdVendedor = reader.IsDBNull(reader.GetOrdinal("IdVendedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor"));
                Dis_ProyectoServicio.DescVendedor = reader["DescVendedor"].ToString();
                Dis_ProyectoServicio.IdMoneda = Convert.ToInt32(reader["IdMoneda"].ToString());
                Dis_ProyectoServicio.DescMoneda = reader["DescMoneda"].ToString();
                Dis_ProyectoServicio.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                Dis_ProyectoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
                Dis_ProyectoServicio.RutaArchivo = reader["RutaArchivo"].ToString();
                Dis_ProyectoServicio.Observacion = reader["Observacion"].ToString();
                Dis_ProyectoServicio.IdSituacion = Convert.ToInt32(reader["IdSituacion"].ToString());
                Dis_ProyectoServicio.DescSituacion = reader["DescSituacion"].ToString();

                Dis_ProyectoServicio.DescTipoCasa = reader["DescTipoCasa"].ToString();
                Dis_ProyectoServicio.DescAmbiente = reader["DescAmbiente"].ToString();
                Dis_ProyectoServicio.Piso = Convert.ToInt32(reader["Piso"].ToString());
                Dis_ProyectoServicio.Objetivos = reader["Objetivos"].ToString();
                Dis_ProyectoServicio.Iluminacion = reader["Iluminacion"].ToString();
                Dis_ProyectoServicio.Acustica = reader["Acustica"].ToString();
                Dis_ProyectoServicio.Area = reader["Area"].ToString();
                Dis_ProyectoServicio.IdDis_Forma = Convert.ToInt32(reader["IdDis_Forma"].ToString());
                Dis_ProyectoServicio.DescDis_Forma = reader["DescDis_Forma"].ToString();
                Dis_ProyectoServicio.IdDis_Estilo = Convert.ToInt32(reader["IdDis_Estilo"].ToString());
                Dis_ProyectoServicio.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                Dis_ProyectoServicio.FechaVisita = reader.IsDBNull(reader.GetOrdinal("FechaVisita")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVisita"));
                Dis_ProyectoServicio.IdDis_ContratoAsesoria = Convert.ToInt32(reader["IdDis_ContratoAsesoria"].ToString());
                Dis_ProyectoServicio.CantidadPago = Convert.ToInt32(reader["CantidadPago"].ToString());
                Dis_ProyectoServicio.FlagCerrado = Boolean.Parse(reader["FlagCerrado"].ToString());
                Dis_ProyectoServicio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ProyectoServicio.PagoAsesoria = Decimal.Parse(reader["PagoAsesoria"].ToString());


            }
            reader.Close();
            reader.Dispose();
            return Dis_ProyectoServicio;
        }

    }
}
