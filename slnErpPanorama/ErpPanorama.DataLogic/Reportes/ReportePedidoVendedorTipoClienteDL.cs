using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorTipoClienteDL
    {
        public List<ReportePedidoVendedorTipoClienteBE> Listado(int IdVendedor, int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorTipoCliente");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorTipoClienteBE> Pedidolist = new List<ReportePedidoVendedorTipoClienteBE>();
            ReportePedidoVendedorTipoClienteBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorTipoClienteBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.IdCliente = int.Parse(reader["IdCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdUbigeoDom = int.Parse(reader["IdUbigeoDom"].ToString());
                Pedido.NomDpto = reader["NomDpto"].ToString();
                Pedido.NomProv = reader["NomProv"].ToString();
                Pedido.NomDist = reader["NomDist"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoVendedorTipoClienteBE> ListadoDisenio(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVentasCanalDisenio");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorTipoClienteBE> Pedidolist = new List<ReportePedidoVendedorTipoClienteBE>();
            ReportePedidoVendedorTipoClienteBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorTipoClienteBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.TipoDoc = reader["TipoDoc"].ToString();
                Pedido.Serie = reader["Serie"].ToString();
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.FecDoc = DateTime.Parse(reader["Fecha"].ToString());

                //Pedido.IdCliente = int.Parse(reader["IdCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                //Pedido.IdUbigeoDom = int.Parse(reader["IdUbigeoDom"].ToString());
                Pedido.NomDpto = reader["NomDpto"].ToString();
                Pedido.NomProv = reader["NomProv"].ToString();
                Pedido.NomDist = reader["NomDist"].ToString();
                Pedido.IdMoneda = int.Parse(reader["IdMoneda"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());

                Pedido.NumeroServicio = reader["NumeroServicio"].ToString();
                Pedido.NumeroCFabricacion = reader["NumeroCFabricacion"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteAvanceMeta> ListadoAvanceMeta(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptAlcanceMetas2-Andahuaylas");  //Usp_RptAlcanceMetas2  //Usp_RptAlcanceMetas2-Prescott
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAvanceMeta> Pedidolist = new List<ReporteAvanceMeta>();
            ReporteAvanceMeta Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteAvanceMeta();
                Pedido.IdVendedor = int.Parse(reader["IdVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.IdCargo = int.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Cliente_Final        = decimal.Parse(reader["Cliente_Final"].ToString());
                Pedido.Cliente_Mayorista    = decimal.Parse(reader["Cliente_Mayorista"].ToString());
                Pedido.Cliente_Diseño       = decimal.Parse(reader["Cliente_Diseño"].ToString());
                Pedido.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());

                Pedido.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                Pedido.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                Pedido.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                Pedido.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteAvanceMeta> ListadoAvanceMetaCartera(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptAlcanceMetasVendedorCartera");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAvanceMeta> Pedidolist = new List<ReporteAvanceMeta>();
            ReporteAvanceMeta Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteAvanceMeta();
                Pedido.IdVendedor = int.Parse(reader["IdVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.IdCargo = int.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Cliente_Final = decimal.Parse(reader["Cliente_Final"].ToString());
                Pedido.Cliente_Mayorista = decimal.Parse(reader["Cliente_Mayorista"].ToString());
                Pedido.Cliente_Diseño = decimal.Parse(reader["Cliente_Diseño"].ToString());
                Pedido.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());

                Pedido.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                Pedido.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                Pedido.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                Pedido.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                Pedido.TotalCreditos = decimal.Parse(reader["TotalCreditos"].ToString());

                Pedido.RutaPropiag = decimal.Parse(reader["RutaPropiag"].ToString());
                Pedido.RutaTercerosg = decimal.Parse(reader["RutaTercerosg"].ToString());
                Pedido.RutaPropiap = decimal.Parse(reader["RutaPropiap"].ToString());
                Pedido.RutaTercerosp = decimal.Parse(reader["RutaTercerosp"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteAvanceMeta> ListadoSueldoVendPiso(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptSueldo_Vendedor_Piso");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            dbCommand.CommandTimeout = 500;
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAvanceMeta> Pedidolist = new List<ReporteAvanceMeta>();
            ReporteAvanceMeta Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteAvanceMeta();
                Pedido.IdVendedor = int.Parse(reader["IdVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.IdCargo = int.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Cliente_Final = decimal.Parse(reader["Cliente_Final"].ToString());
                Pedido.Cliente_Mayorista = decimal.Parse(reader["Cliente_Mayorista"].ToString());
                Pedido.Cliente_Diseño = decimal.Parse(reader["Cliente_Diseño"].ToString());
                Pedido.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());

                Pedido.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                Pedido.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                Pedido.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                Pedido.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                Pedido.RegClientes = int.Parse(reader["Regclientes"].ToString());
                Pedido.FechaCese = (reader["FechaCese"].ToString());
                Pedido.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteAvanceMeta> ListadoSueldoAsesorVentasVirtual(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptSueldo_Asesor_Digital");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAvanceMeta> Pedidolist = new List<ReporteAvanceMeta>();
            ReporteAvanceMeta Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteAvanceMeta();
                Pedido.IdVendedor = int.Parse(reader["IdVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.IdCargo = int.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Cliente_Final = decimal.Parse(reader["Cliente_Final"].ToString());
                Pedido.Cliente_Mayorista = decimal.Parse(reader["Cliente_Mayorista"].ToString());
                Pedido.Cliente_Diseño = decimal.Parse(reader["Cliente_Diseño"].ToString());
                Pedido.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());

                Pedido.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                Pedido.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                Pedido.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                Pedido.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                Pedido.RegClientes = int.Parse(reader["Regclientes"].ToString());
                Pedido.FechaCese = (reader["FechaCese"].ToString());
                Pedido.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteAvanceMeta> ListadoSueldoDisenioInterior(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptSueldo_Diseñador_Interiores");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAvanceMeta> Pedidolist = new List<ReporteAvanceMeta>();
            ReporteAvanceMeta Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteAvanceMeta();
                Pedido.IdVendedor = int.Parse(reader["IdVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.IdCargo = int.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Cliente_Final = decimal.Parse(reader["Cliente_Final"].ToString());
                Pedido.Cliente_Mayorista = decimal.Parse(reader["Cliente_Mayorista"].ToString());
                Pedido.Cliente_Diseño = decimal.Parse(reader["Cliente_Diseño"].ToString());
                Pedido.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());

                Pedido.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                Pedido.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                Pedido.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                Pedido.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                Pedido.RegClientes = int.Parse(reader["Regclientes"].ToString());

                Pedido.PFinal = decimal.Parse(reader["PFinal"].ToString());
                Pedido.PMayor = decimal.Parse(reader["PMayor"].ToString());
                Pedido.PFabrica = decimal.Parse(reader["PFabrica"].ToString());

                Pedido.BFinal = decimal.Parse(reader["BFinal"].ToString());
                Pedido.BMayor = decimal.Parse(reader["BMayor"].ToString());
                Pedido.BFabrica = decimal.Parse(reader["BFabrica"].ToString());
                Pedido.FechaCese = (reader["FechaCese"].ToString());
                Pedido.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteAvanceMeta> ListadoAvanceMetaJefeCartera(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptAlcanceMetasJefeCartera");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAvanceMeta> Pedidolist = new List<ReporteAvanceMeta>();
            ReporteAvanceMeta Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteAvanceMeta();
                //Pedido.IdVendedor = int.Parse(reader["IdVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                //Pedido.IdCargo = int.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                //Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                //Pedido.Cliente_Final = decimal.Parse(reader["Cliente_Final"].ToString());
                Pedido.Cliente_Mayorista = decimal.Parse(reader["Cliente_Mayorista"].ToString());
                //Pedido.Cliente_Diseño = decimal.Parse(reader["Cliente_Diseño"].ToString());
                Pedido.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());

                Pedido.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                Pedido.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                Pedido.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                Pedido.TotalNC = decimal.Parse(reader["TotalNC"].ToString());
                //Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                //Pedido.TotalCreditos = decimal.Parse(reader["TotalCreditos"].ToString());

                                              Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteAvanceMeta> ListadoAvanceMetaDisenio(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptAlcanceMetasDisenio");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAvanceMeta> Pedidolist = new List<ReporteAvanceMeta>();
            ReporteAvanceMeta Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteAvanceMeta();
                Pedido.IdVendedor = int.Parse(reader["IdVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.IdCargo = int.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Cliente_Final = decimal.Parse(reader["Cliente_Final"].ToString());
                Pedido.Cliente_Mayorista = decimal.Parse(reader["Cliente_Mayorista"].ToString());
                Pedido.Cliente_Diseño = decimal.Parse(reader["Cliente_Diseño"].ToString());
                Pedido.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());

                Pedido.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                Pedido.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                Pedido.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                Pedido.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }


        public List<ReporteSueldoAdmUcayali> SueldoAdmUcayali(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptSueldoAdministradorUcayali");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.Date, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.Date, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSueldoAdmUcayali> SueldoAdmUcalist = new List<ReporteSueldoAdmUcayali>();
            ReporteSueldoAdmUcayali SueldoAdmUcayali;
            while (reader.Read())
            {
                SueldoAdmUcayali = new ReporteSueldoAdmUcayali();
                SueldoAdmUcayali.Tienda = reader["Tienda"].ToString();
                SueldoAdmUcayali.ApeNom = reader["ApeNom"].ToString();                
                SueldoAdmUcayali.Cargo = reader["Cargo"].ToString();
                SueldoAdmUcayali.Meta = decimal.Parse(reader["Meta"].ToString());
                SueldoAdmUcayali.SueldoBasico = decimal.Parse(reader["SueldoBasico"].ToString());
                SueldoAdmUcayali.VentaTotal = decimal.Parse(reader["VentaTotal"].ToString());
                SueldoAdmUcayali.CMayorista = decimal.Parse(reader["CMayorista"].ToString());
                SueldoAdmUcayali.CDiseño = decimal.Parse(reader["CDiseño"].ToString());
                SueldoAdmUcayali.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                SueldoAdmUcayali.TasaConversion = decimal.Parse(reader["TasaConversion"].ToString());
                SueldoAdmUcayali.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                SueldoAdmUcayali.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                SueldoAdmUcayali.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                SueldoAdmUcayali.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                SueldoAdmUcayali.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                SueldoAdmUcayali.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                SueldoAdmUcalist.Add(SueldoAdmUcayali);
            }
            reader.Close();
            reader.Dispose();
            return SueldoAdmUcalist;
        }

        public List<ReporteSueldoAdmUcayali> SueldoSubAdm(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptSueldoSubAdministrador");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.Date, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.Date, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSueldoAdmUcayali> SueldoAdmUcalist = new List<ReporteSueldoAdmUcayali>();
            ReporteSueldoAdmUcayali SueldoAdmUcayali;
            while (reader.Read())
            {
                SueldoAdmUcayali = new ReporteSueldoAdmUcayali();
                SueldoAdmUcayali.Tienda = reader["Tienda"].ToString();
                SueldoAdmUcayali.ApeNom = reader["ApeNom"].ToString();
                SueldoAdmUcayali.Cargo = reader["Cargo"].ToString();
                SueldoAdmUcayali.Meta = decimal.Parse(reader["Meta"].ToString());
                SueldoAdmUcayali.SueldoBasico = decimal.Parse(reader["SueldoBasico"].ToString());
                SueldoAdmUcayali.VentaTotal = decimal.Parse(reader["VentaTotal"].ToString());
                SueldoAdmUcayali.CMayorista = decimal.Parse(reader["CMayorista"].ToString());
                SueldoAdmUcayali.CDiseño = decimal.Parse(reader["CDiseño"].ToString());
                SueldoAdmUcayali.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                SueldoAdmUcayali.TasaConversion = decimal.Parse(reader["TasaConversion"].ToString());
                SueldoAdmUcayali.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                SueldoAdmUcayali.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                SueldoAdmUcayali.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                SueldoAdmUcayali.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                SueldoAdmUcayali.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                SueldoAdmUcayali.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                SueldoAdmUcalist.Add(SueldoAdmUcayali);
            }
            reader.Close();
            reader.Dispose();
            return SueldoAdmUcalist;
        }

        public List<ReporteSueldoAdmUcayali> SueldoJefeCampo(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptSueldoJefeVentaCampo");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.Date, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.Date, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSueldoAdmUcayali> SueldoAdmUcalist = new List<ReporteSueldoAdmUcayali>();
            ReporteSueldoAdmUcayali SueldoAdmUcayali;
            while (reader.Read())
            {
                SueldoAdmUcayali = new ReporteSueldoAdmUcayali();
                SueldoAdmUcayali.Tienda = reader["Tienda"].ToString();
                SueldoAdmUcayali.ApeNom = reader["ApeNom"].ToString();
                SueldoAdmUcayali.Cargo = reader["Cargo"].ToString();
                SueldoAdmUcayali.Meta = decimal.Parse(reader["Meta"].ToString());
                SueldoAdmUcayali.SueldoBasico = decimal.Parse(reader["SueldoBasico"].ToString());
                SueldoAdmUcayali.VentaTotal = decimal.Parse(reader["VentaTotal"].ToString());
                SueldoAdmUcayali.CMayorista = decimal.Parse(reader["CMayorista"].ToString());
                SueldoAdmUcayali.CDiseño = decimal.Parse(reader["CDiseño"].ToString());
                SueldoAdmUcayali.VentaTotalPagada = decimal.Parse(reader["VentaTotalPagada"].ToString());
                SueldoAdmUcayali.TasaConversion = decimal.Parse(reader["TasaConversion"].ToString());
                SueldoAdmUcayali.BonificacionBasica = decimal.Parse(reader["BonificacionBasica"].ToString());
                SueldoAdmUcayali.PorcBonificacionBasica = decimal.Parse(reader["PorcBonificacionBasica"].ToString());
                SueldoAdmUcayali.ExtraBonificacion = decimal.Parse(reader["ExtraBonificacion"].ToString());
                SueldoAdmUcayali.CantidadExtra = decimal.Parse(reader["CantidadExtra"].ToString());
                SueldoAdmUcayali.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                SueldoAdmUcalist.Add(SueldoAdmUcayali);
            }
            reader.Close();
            reader.Dispose();
            return SueldoAdmUcalist;
        }

    }
}
