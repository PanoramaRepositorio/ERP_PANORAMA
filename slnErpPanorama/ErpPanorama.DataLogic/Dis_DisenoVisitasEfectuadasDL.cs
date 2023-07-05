using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_DisenoVisitasEfectuadasDL
    {
        public Dis_DisenoVisitasEfectuadasDL() { }

        public void Inserta(Dis_DisenoVisitasRealizadasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoVisitasRealizadas_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdAgendaVisita", DbType.Int32, pItem.IdAgendaVisita);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_DisenoVisitasRealizadasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoFuncional_Actualiza");

            //db.AddInParameter(dbCommand, "pIdDis_DisenoFuncional", DbType.Int32, pItem.IdDis_DisenoFuncional);
            //db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            //db.AddInParameter(dbCommand, "pIdDis_Ambiente", DbType.Int32, pItem.IdDis_Ambiente);
            //db.AddInParameter(dbCommand, "pDescActividad", DbType.String, pItem.DescActividad);
            //db.AddInParameter(dbCommand, "pIdDis_Pieza", DbType.Int32, pItem.IdDis_Pieza);
            //db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            //db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            //db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            //db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            //db.AddInParameter(dbCommand, "pDescVolumen", DbType.String, pItem.DescVolumen);
            //db.AddInParameter(dbCommand, "pDescTextura", DbType.String, pItem.DescTextura);
            //db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_DisenoVisitasRealizadasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenovisitasRealizadas_Elimina");

            db.AddInParameter(dbCommand, "pIdAgendaVisita", DbType.Int32, pItem.IdAgendaVisita);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaTodasVisitas(Dis_DisenoVisitasRealizadasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Diseno_EliminaTodosVisita");

            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_DisenoVisitasRealizadasBE> ListaTodosActivo(int IdDis_ProyectoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoVisitasRealizadas_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_DisenoVisitasRealizadasBE> Dis_DisenoFuncionallist = new List<Dis_DisenoVisitasRealizadasBE>();
            Dis_DisenoVisitasRealizadasBE Dis_DisenoVisitaRealizadas;
            while (reader.Read())
            {
                Dis_DisenoVisitaRealizadas = new Dis_DisenoVisitasRealizadasBE();

                Dis_DisenoVisitaRealizadas.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                Dis_DisenoVisitaRealizadas.IdAgendaVisita = Int32.Parse(reader["IdAgendaVisita"].ToString());

                Dis_DisenoVisitaRealizadas.NumAgendaVisita = reader["NumVisita"].ToString();
                Dis_DisenoVisitaRealizadas.HoraInicio = reader["HoraInicio"].ToString();
                Dis_DisenoVisitaRealizadas.HoraFin = reader["HoraFin"].ToString();
                Dis_DisenoVisitaRealizadas.FechaAgenda = DateTime.Parse( reader["FechaVisita"].ToString());
                Dis_DisenoVisitaRealizadas.Disenador = reader["Disenador"].ToString();
                Dis_DisenoVisitaRealizadas.Agenda = reader["Agenda"].ToString();
                Dis_DisenoVisitaRealizadas.MotivoVisita = reader["MotivoVisita"].ToString();
                Dis_DisenoVisitaRealizadas.Situacion = reader["Situacion"].ToString();
                Dis_DisenoVisitaRealizadas.PrecioVisita = Decimal.Parse(reader["PrecioVisita"].ToString());
                Dis_DisenoVisitaRealizadas.TipoOper = 4; //Consultar

                Dis_DisenoFuncionallist.Add(Dis_DisenoVisitaRealizadas);
            }
            reader.Close();
            reader.Dispose();
            return Dis_DisenoFuncionallist;
        }

        public void InsertaVisitasRealizadas(Dis_DisenoVisitasRealizadasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoProveedor_Inserta");

            //db.AddInParameter(dbCommand, "pIdCuentaBancoProveedor", DbType.Int32, pItem.IdDis_ProyectoServicio);
            //db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdAgendaVisita);
            //db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            //db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            //db.AddInParameter(dbCommand, "pCuenta", DbType.String, pItem.NumeroCuenta);
            //db.AddInParameter(dbCommand, "pcci", DbType.String, pItem.CCI);
            //db.AddInParameter(dbCommand, "pIdTipoCuenta", DbType.Int32, pItem.IdTipoCuenta);
            //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

    }
}
