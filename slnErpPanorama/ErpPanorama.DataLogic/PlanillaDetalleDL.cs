using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PlanillaDetalleDL
    {
        public PlanillaDetalleDL() { }

        public void Inserta(PlanillaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanillaDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPlanillaDetalle", DbType.Int32, pItem.IdPlanillaDetalle);
            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, pItem.IdPlanilla);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pSueldoBruto", DbType.Decimal, pItem.SueldoBruto);
            db.AddInParameter(dbCommand, "pHorasLaboradas", DbType.Int32, pItem.HorasLaboradas);
            db.AddInParameter(dbCommand, "pHorasExtras25", DbType.Decimal, pItem.HorasExtras25);
            db.AddInParameter(dbCommand, "pRemuneracionBasica", DbType.Decimal, pItem.RemuneracionBasica);
            db.AddInParameter(dbCommand, "pHorasExtras250105", DbType.Decimal, pItem.HorasExtras250105);
            db.AddInParameter(dbCommand, "pAsignacionFamiliar", DbType.Decimal, pItem.AsignacionFamiliar);
            db.AddInParameter(dbCommand, "pRemuneracionVacacional", DbType.Decimal, pItem.RemuneracionVacacional);
            db.AddInParameter(dbCommand, "pRemuneracionTrunca", DbType.Decimal, pItem.RemuneracionTrunca);
            db.AddInParameter(dbCommand, "pBonificacionEspecial0306", DbType.Decimal, pItem.BonificacionEspecial0306);
            db.AddInParameter(dbCommand, "pIngresosComisiones", DbType.Decimal, pItem.IngresosComisiones);
            db.AddInParameter(dbCommand, "pBonificacionExtraordinaria", DbType.Decimal, pItem.BonificacionExtraordinaria);
            db.AddInParameter(dbCommand, "pMovilidad", DbType.Decimal, pItem.Movilidad);
            db.AddInParameter(dbCommand, "pGratificaciones", DbType.Decimal, pItem.Gratificaciones);
            db.AddInParameter(dbCommand, "pBonificacionEspecial", DbType.Decimal, pItem.BonificacionEspecial);
            db.AddInParameter(dbCommand, "pRepartoUtilidad", DbType.Decimal, pItem.RepartoUtilidad);
            db.AddInParameter(dbCommand, "pCts", DbType.Decimal, pItem.Cts);
            db.AddInParameter(dbCommand, "pTotalRemuneraciones", DbType.Decimal, pItem.TotalRemuneraciones);
            db.AddInParameter(dbCommand, "pFaltasTardanzas", DbType.Decimal, pItem.FaltasTardanzas);
            db.AddInParameter(dbCommand, "pIdPlaAfp", DbType.Int32, pItem.IdPlaAfp);
            db.AddInParameter(dbCommand, "pOnp", DbType.Decimal, pItem.Onp);
            db.AddInParameter(dbCommand, "pFondoPensiones", DbType.Decimal, pItem.FondoPensiones);
            db.AddInParameter(dbCommand, "pPrimaSeguros", DbType.Decimal, pItem.PrimaSeguros);
            db.AddInParameter(dbCommand, "pComisionAFP", DbType.Decimal, pItem.ComisionAFP);
            db.AddInParameter(dbCommand, "pPacifico", DbType.Decimal, pItem.Pacifico);
            db.AddInParameter(dbCommand, "pRetencion5Categoria", DbType.Decimal, pItem.Retencion5Categoria);
            db.AddInParameter(dbCommand, "pTotalDescuento", DbType.Decimal, pItem.TotalDescuento);
            db.AddInParameter(dbCommand, "pNetoPagar", DbType.Decimal, pItem.NetoPagar);
            db.AddInParameter(dbCommand, "pAportacion75", DbType.Decimal, pItem.Aportacion75);
            db.AddInParameter(dbCommand, "pAportacion25", DbType.Decimal, pItem.Aportacion25);
            db.AddInParameter(dbCommand, "pAportacion9", DbType.Decimal, pItem.Aportacion9);
            db.AddInParameter(dbCommand, "pAporteEps", DbType.Decimal, pItem.AporteEps);
            db.AddInParameter(dbCommand, "pDiasNoLaboradoVacaciones", DbType.Int32, pItem.DiasNoLaboradoVacaciones);
            db.AddInParameter(dbCommand, "pDiasNoLaboradoJustificados", DbType.Int32, pItem.DiasNoLaboradoJustificados);
            db.AddInParameter(dbCommand, "pDiasNoLaboradoFaltas", DbType.Int32, pItem.DiasNoLaboradoFaltas);
            db.AddInParameter(dbCommand, "pDiasNoLaboradoDm", DbType.Int32, pItem.DiasNoLaboradoDm);
            db.AddInParameter(dbCommand, "pTotalDias", DbType.Int32, pItem.TotalDias);
            db.AddInParameter(dbCommand, "pFechaCese", DbType.DateTime, pItem.FechaCese);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(PlanillaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanillaDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPlanillaDetalle", DbType.Int32, pItem.IdPlanillaDetalle);
            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, pItem.IdPlanilla);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pSueldoBruto", DbType.Decimal, pItem.SueldoBruto);
            db.AddInParameter(dbCommand, "pHorasLaboradas", DbType.Int32, pItem.HorasLaboradas);
            db.AddInParameter(dbCommand, "pHorasExtras25", DbType.Decimal, pItem.HorasExtras25);
            db.AddInParameter(dbCommand, "pRemuneracionBasica", DbType.Decimal, pItem.RemuneracionBasica);
            db.AddInParameter(dbCommand, "pHorasExtras250105", DbType.Decimal, pItem.HorasExtras250105);
            db.AddInParameter(dbCommand, "pAsignacionFamiliar", DbType.Decimal, pItem.AsignacionFamiliar);
            db.AddInParameter(dbCommand, "pRemuneracionVacacional", DbType.Decimal, pItem.RemuneracionVacacional);
            db.AddInParameter(dbCommand, "pRemuneracionTrunca", DbType.Decimal, pItem.RemuneracionTrunca);
            db.AddInParameter(dbCommand, "pBonificacionEspecial0306", DbType.Decimal, pItem.BonificacionEspecial0306);
            db.AddInParameter(dbCommand, "pIngresosComisiones", DbType.Decimal, pItem.IngresosComisiones);
            db.AddInParameter(dbCommand, "pBonificacionExtraordinaria", DbType.Decimal, pItem.BonificacionExtraordinaria);
            db.AddInParameter(dbCommand, "pMovilidad", DbType.Decimal, pItem.Movilidad);
            db.AddInParameter(dbCommand, "pGratificaciones", DbType.Decimal, pItem.Gratificaciones);
            db.AddInParameter(dbCommand, "pBonificacionEspecial", DbType.Decimal, pItem.BonificacionEspecial);
            db.AddInParameter(dbCommand, "pRepartoUtilidad", DbType.Decimal, pItem.RepartoUtilidad);
            db.AddInParameter(dbCommand, "pCts", DbType.Decimal, pItem.Cts);
            db.AddInParameter(dbCommand, "pTotalRemuneraciones", DbType.Decimal, pItem.TotalRemuneraciones);
            db.AddInParameter(dbCommand, "pFaltasTardanzas", DbType.Decimal, pItem.FaltasTardanzas);
            db.AddInParameter(dbCommand, "pIdPlaAfp", DbType.Int32, pItem.IdPlaAfp);
            db.AddInParameter(dbCommand, "pOnp", DbType.Decimal, pItem.Onp);
            db.AddInParameter(dbCommand, "pFondoPensiones", DbType.Decimal, pItem.FondoPensiones);
            db.AddInParameter(dbCommand, "pPrimaSeguros", DbType.Decimal, pItem.PrimaSeguros);
            db.AddInParameter(dbCommand, "pComisionAFP", DbType.Decimal, pItem.ComisionAFP);
            db.AddInParameter(dbCommand, "pPacifico", DbType.Decimal, pItem.Pacifico);
            db.AddInParameter(dbCommand, "pRetencion5Categoria", DbType.Decimal, pItem.Retencion5Categoria);
            db.AddInParameter(dbCommand, "pTotalDescuento", DbType.Decimal, pItem.TotalDescuento);
            db.AddInParameter(dbCommand, "pNetoPagar", DbType.Decimal, pItem.NetoPagar);
            db.AddInParameter(dbCommand, "pAportacion75", DbType.Decimal, pItem.Aportacion75);
            db.AddInParameter(dbCommand, "pAportacion25", DbType.Decimal, pItem.Aportacion25);
            db.AddInParameter(dbCommand, "pAportacion9", DbType.Decimal, pItem.Aportacion9);
            db.AddInParameter(dbCommand, "pAporteEps", DbType.Decimal, pItem.AporteEps);
            db.AddInParameter(dbCommand, "pDiasNoLaboradoVacaciones", DbType.Int32, pItem.DiasNoLaboradoVacaciones);
            db.AddInParameter(dbCommand, "pDiasNoLaboradoJustificados", DbType.Int32, pItem.DiasNoLaboradoJustificados);
            db.AddInParameter(dbCommand, "pDiasNoLaboradoFaltas", DbType.Int32, pItem.DiasNoLaboradoFaltas);
            db.AddInParameter(dbCommand, "pDiasNoLaboradoDm", DbType.Int32, pItem.DiasNoLaboradoDm);
            db.AddInParameter(dbCommand, "pTotalDias", DbType.Int32, pItem.TotalDias);
            db.AddInParameter(dbCommand, "pFechaCese", DbType.DateTime, pItem.FechaCese);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PlanillaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanillaDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPlanillaDetalle", DbType.Int32, pItem.IdPlanillaDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public List<PlanillaDetalleBE> ListaTodosActivo(int IdPlanilla)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanillaDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, IdPlanilla);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanillaDetalleBE> PlanillaDetallelist = new List<PlanillaDetalleBE>();
            PlanillaDetalleBE PlanillaDetalle;
            while (reader.Read())
            {
                PlanillaDetalle = new PlanillaDetalleBE();
                PlanillaDetalle.IdPlanilla = Int32.Parse(reader["idPlanilla"].ToString());
                PlanillaDetalle.IdPlanillaDetalle = Int32.Parse(reader["idPlanillaDetalle"].ToString());
                PlanillaDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PlanillaDetalle.ApeNom = reader["ApeNom"].ToString();
                PlanillaDetalle.SueldoBruto = Decimal.Parse(reader["SueldoBruto"].ToString());
                PlanillaDetalle.HorasLaboradas = Int32.Parse(reader["HorasLaboradas"].ToString());
                PlanillaDetalle.HorasExtras25 = Decimal.Parse(reader["HorasExtras25"].ToString());
                PlanillaDetalle.RemuneracionBasica = Decimal.Parse(reader["RemuneracionBasica"].ToString());
                PlanillaDetalle.HorasExtras250105 = Decimal.Parse(reader["HorasExtras250105"].ToString());
                PlanillaDetalle.AsignacionFamiliar = Decimal.Parse(reader["AsignacionFamiliar"].ToString());
                PlanillaDetalle.RemuneracionVacacional = Decimal.Parse(reader["RemuneracionVacacional"].ToString());
                PlanillaDetalle.RemuneracionTrunca = Decimal.Parse(reader["RemuneracionTrunca"].ToString());
                PlanillaDetalle.BonificacionEspecial0306 = Decimal.Parse(reader["BonificacionEspecial0306"].ToString());
                PlanillaDetalle.IngresosComisiones = Decimal.Parse(reader["IngresosComisiones"].ToString());
                PlanillaDetalle.BonificacionExtraordinaria = Decimal.Parse(reader["BonificacionExtraordinaria"].ToString());
                PlanillaDetalle.Movilidad = Decimal.Parse(reader["Movilidad"].ToString());
                PlanillaDetalle.Gratificaciones = Decimal.Parse(reader["Gratificaciones"].ToString());
                PlanillaDetalle.BonificacionEspecial = Decimal.Parse(reader["BonificacionEspecial"].ToString());
                PlanillaDetalle.RepartoUtilidad = Decimal.Parse(reader["RepartoUtilidad"].ToString());
                PlanillaDetalle.Cts = Decimal.Parse(reader["Cts"].ToString());
                PlanillaDetalle.TotalRemuneraciones = Decimal.Parse(reader["TotalRemuneraciones"].ToString());
                PlanillaDetalle.FaltasTardanzas = Decimal.Parse(reader["FaltasTardanzas"].ToString());
                PlanillaDetalle.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                PlanillaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PlanillaDetalle.Onp = Decimal.Parse(reader["Onp"].ToString());
                PlanillaDetalle.FondoPensiones = Decimal.Parse(reader["FondoPensiones"].ToString());
                PlanillaDetalle.PrimaSeguros = Decimal.Parse(reader["PrimaSeguros"].ToString());
                PlanillaDetalle.ComisionAFP = Decimal.Parse(reader["ComisionAFP"].ToString());
                PlanillaDetalle.Pacifico = Decimal.Parse(reader["Pacifico"].ToString());
                PlanillaDetalle.Retencion5Categoria = Decimal.Parse(reader["Retencion5Categoria"].ToString());
                PlanillaDetalle.TotalDescuento = Decimal.Parse(reader["TotalDescuento"].ToString());
                PlanillaDetalle.NetoPagar = Decimal.Parse(reader["NetoPagar"].ToString());
                PlanillaDetalle.Aportacion75 = Decimal.Parse(reader["Aportacion75"].ToString());
                PlanillaDetalle.Aportacion25 = Decimal.Parse(reader["Aportacion25"].ToString());
                PlanillaDetalle.Aportacion9 = Decimal.Parse(reader["Aportacion9"].ToString());
                PlanillaDetalle.AporteEps = Decimal.Parse(reader["AporteEps"].ToString());
                PlanillaDetalle.DiasNoLaboradoVacaciones = Int32.Parse(reader["DiasNoLaboradoVacaciones"].ToString());
                PlanillaDetalle.DiasNoLaboradoJustificados = Int32.Parse(reader["DiasNoLaboradoJustificados"].ToString());
                PlanillaDetalle.DiasNoLaboradoFaltas = Int32.Parse(reader["DiasNoLaboradoFaltas"].ToString());
                PlanillaDetalle.DiasNoLaboradoDm = Int32.Parse(reader["DiasNoLaboradoDm"].ToString());
                PlanillaDetalle.TotalDias = Int32.Parse(reader["TotalDias"].ToString());
                PlanillaDetalle.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                PlanillaDetalle.Observacion = reader["Observacion"].ToString();
                PlanillaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PlanillaDetalle.TipoOper = 4;
                PlanillaDetallelist.Add(PlanillaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PlanillaDetallelist;
        }

        public List<PlanillaDetalleBE> ListaCalculo(int IdPlanilla, int IdEmpresa, int Periodo, int Mes, int DiasEfectivoTrabajo, decimal HoraOrdinaria, decimal HoraExtraDiaria, decimal RMV, decimal AporteSeguroMinimo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlanillaDetalle_ListaCalculo");
            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, IdPlanilla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pDiasEfectivoTrabajo", DbType.Int32, DiasEfectivoTrabajo);
            db.AddInParameter(dbCommand, "pHoraOrdinaria", DbType.Decimal, HoraOrdinaria);
            db.AddInParameter(dbCommand, "pHoraExtraDiaria", DbType.Decimal, HoraExtraDiaria);
            db.AddInParameter(dbCommand, "pRMV", DbType.Decimal, RMV);
            db.AddInParameter(dbCommand, "pAporteSeguroMinimo", DbType.Decimal, AporteSeguroMinimo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanillaDetalleBE> PlanillaDetallelist = new List<PlanillaDetalleBE>();
            PlanillaDetalleBE PlanillaDetalle;
            while (reader.Read())
            {
                PlanillaDetalle = new PlanillaDetalleBE();
                PlanillaDetalle.IdPlanilla = Int32.Parse(reader["idPlanilla"].ToString());
                PlanillaDetalle.IdPlanillaDetalle = Int32.Parse(reader["idPlanillaDetalle"].ToString());
                PlanillaDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PlanillaDetalle.ApeNom = reader["ApeNom"].ToString();
                PlanillaDetalle.SueldoBruto = Decimal.Parse(reader["SueldoBruto"].ToString());
                PlanillaDetalle.HorasLaboradas = Int32.Parse(reader["HorasLaboradas"].ToString());
                PlanillaDetalle.HorasExtras25 = Decimal.Parse(reader["HorasExtras25"].ToString());
                PlanillaDetalle.RemuneracionBasica = Decimal.Parse(reader["RemuneracionBasica"].ToString());
                PlanillaDetalle.HorasExtras250105 = Decimal.Parse(reader["HorasExtras250105"].ToString());
                PlanillaDetalle.AsignacionFamiliar = Decimal.Parse(reader["AsignacionFamiliar"].ToString());
                PlanillaDetalle.RemuneracionVacacional = Decimal.Parse(reader["RemuneracionVacacional"].ToString());
                PlanillaDetalle.RemuneracionTrunca = Decimal.Parse(reader["RemuneracionTrunca"].ToString());
                PlanillaDetalle.BonificacionEspecial0306 = Decimal.Parse(reader["BonificacionEspecial0306"].ToString());
                PlanillaDetalle.IngresosComisiones = Decimal.Parse(reader["IngresosComisiones"].ToString());
                PlanillaDetalle.BonificacionExtraordinaria = Decimal.Parse(reader["BonificacionExtraordinaria"].ToString());
                PlanillaDetalle.Movilidad = Decimal.Parse(reader["Movilidad"].ToString());
                PlanillaDetalle.Gratificaciones = Decimal.Parse(reader["Gratificaciones"].ToString());
                PlanillaDetalle.BonificacionEspecial = Decimal.Parse(reader["BonificacionEspecial"].ToString());
                PlanillaDetalle.RepartoUtilidad = Decimal.Parse(reader["RepartoUtilidad"].ToString());
                PlanillaDetalle.Cts = Decimal.Parse(reader["Cts"].ToString());
                PlanillaDetalle.TotalRemuneraciones = Decimal.Parse(reader["TotalRemuneraciones"].ToString());
                PlanillaDetalle.FaltasTardanzas = Decimal.Parse(reader["FaltasTardanzas"].ToString());
                PlanillaDetalle.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                PlanillaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PlanillaDetalle.Onp = Decimal.Parse(reader["Onp"].ToString());
                PlanillaDetalle.FondoPensiones = Decimal.Parse(reader["FondoPensiones"].ToString());
                PlanillaDetalle.PrimaSeguros = Decimal.Parse(reader["PrimaSeguros"].ToString());
                PlanillaDetalle.ComisionAFP = Decimal.Parse(reader["ComisionAFP"].ToString());
                PlanillaDetalle.Pacifico = Decimal.Parse(reader["Pacifico"].ToString());
                PlanillaDetalle.Retencion5Categoria = Decimal.Parse(reader["Retencion5Categoria"].ToString());
                PlanillaDetalle.TotalDescuento = Decimal.Parse(reader["TotalDescuento"].ToString());
                PlanillaDetalle.NetoPagar = Decimal.Parse(reader["NetoPagar"].ToString());
                PlanillaDetalle.Aportacion75 = Decimal.Parse(reader["Aportacion75"].ToString());
                PlanillaDetalle.Aportacion25 = Decimal.Parse(reader["Aportacion25"].ToString());
                PlanillaDetalle.Aportacion9 = Decimal.Parse(reader["Aportacion9"].ToString());
                PlanillaDetalle.AporteEps = Decimal.Parse(reader["AporteEps"].ToString());
                PlanillaDetalle.DiasNoLaboradoVacaciones = Int32.Parse(reader["DiasNoLaboradoVacaciones"].ToString());
                PlanillaDetalle.DiasNoLaboradoJustificados = Int32.Parse(reader["DiasNoLaboradoJustificados"].ToString());
                PlanillaDetalle.DiasNoLaboradoFaltas = Int32.Parse(reader["DiasNoLaboradoFaltas"].ToString());
                PlanillaDetalle.DiasNoLaboradoDm = Int32.Parse(reader["DiasNoLaboradoDm"].ToString());
                PlanillaDetalle.TotalDias = Int32.Parse(reader["TotalDias"].ToString());
                PlanillaDetalle.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                PlanillaDetalle.Observacion = reader["Observacion"].ToString();
                //PlanillaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                //PlanillaDetalle.TipoOper = 4;
                PlanillaDetallelist.Add(PlanillaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PlanillaDetallelist;
        }

    }
}
