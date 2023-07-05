using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class HoraExtraBL
    {
        public List<HoraExtraBE> ListaTodosActivo(int Periodo, int Mes)
        {
            try
            {
                HoraExtraDL HoraExtra = new HoraExtraDL();
                return HoraExtra.ListaTodosActivo(Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<HoraExtraBE> ListaFecha(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                HoraExtraDL HoraExtra = new HoraExtraDL();
                return HoraExtra.ListaFecha(IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<HoraExtraBE> ListaPersonaFecha(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                HoraExtraDL HoraExtra = new HoraExtraDL();
                return HoraExtra.ListaPersonaFecha(IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<HoraExtraBE> ListaValida(int IdHoraExtra, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                HoraExtraDL HoraExtra = new HoraExtraDL();
                return HoraExtra.ListaValida(IdHoraExtra, IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<HoraExtraBE> ListaPersonaPendientePago(int IdPersona)
        {
            try
            {
                HoraExtraDL HoraExtra = new HoraExtraDL();
                return HoraExtra.ListaPersonaPendientePago(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public HoraExtraBE Selecciona(int IdHoraExtra)
        {
            try
            {
                HoraExtraDL HoraExtra = new HoraExtraDL();
                return HoraExtra.Selecciona(IdHoraExtra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(HoraExtraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraDL HoraExtra = new HoraExtraDL();
                    HoraExtra.Inserta(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaMarcacion(HoraExtraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraDL HoraExtra = new HoraExtraDL();
                    HoraExtra.InsertaMarcacion(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(HoraExtraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraDL HoraExtra = new HoraExtraDL();
                    HoraExtra.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCalculo(HoraExtraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraDL HoraExtra = new HoraExtraDL();
                    HoraExtra.ActualizaCalculo(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza_Totales(HoraExtraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraDL HoraExtra = new HoraExtraDL();
                    HoraExtra.Actualiza_Totales(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaAprobado(HoraExtraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraDL HoraExtra = new HoraExtraDL();
                    HoraExtra.ActualizaAprobado(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaMovimientoCaja(int IdHoraExtra, int IdMovimientoCaja)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraDL HoraExtra = new HoraExtraDL();
                    HoraExtra.ActualizaMovimientoCaja(IdHoraExtra, IdMovimientoCaja);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEliminaMovimientoCaja(int IdMovimientoCaja)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraDL HoraExtra = new HoraExtraDL();
                    HoraExtra.ActualizaEliminaMovimientoCaja(IdMovimientoCaja);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(HoraExtraBE pItem)
        {
            try
            {
                HoraExtraDL HoraExtra = new HoraExtraDL();
                HoraExtra.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
        public HoraExtraTotalBE CalcularHora(int intExtra, decimal GanaHora, decimal GanaMin)
        {
            decimal decExtra = Convert.ToDecimal(intExtra) / 100;
            // Cuanto Se le adiciona , el 25% o 35%
            decimal ADDHora = GanaHora * decExtra;
            decimal ADDMin = GanaMin * decExtra;
            // Cuanto Gana Hora Exta
            decimal GanaHoraExtra = Math.Round((GanaHora + ADDHora), 2);
            decimal GanaMinExtra = Math.Round((GanaMin + ADDMin), 2);
            //Seteo
            HoraExtraTotalBE HE = new HoraExtraTotalBE();
            HE.PorHorasExtras = intExtra.ToString() + "%";
            HE.ADDHora = ADDHora;
            HE.ADDMin = ADDMin;
            HE.GanaHoraExtra = GanaHoraExtra;
            HE.GanaMinExtra = GanaMinExtra;
            return HE;
        }

        public void CalcularTotalPagar(int IdHoraExtra, decimal intPorcentajeAsigFamiliar)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraExtraBE objE_HoraExtra = new HoraExtraBL().Selecciona(IdHoraExtra);
                    if (objE_HoraExtra.FlagCompensacion) return;
                    int IdPersona = objE_HoraExtra.IdPersona;

                    PersonaBE objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);
                    if (objE_Persona != null)
                    {
                        decimal Sueldo = objE_Persona.Sueldo;
                        DateTime dFechaDesde = Convert.ToDateTime(objE_HoraExtra.FechaDesde);
                        DateTime dFechaHasta = Convert.ToDateTime(objE_HoraExtra.FechaHasta);
                        TimeSpan Diff_dates = dFechaHasta.Subtract(dFechaDesde);
                        int Horas = Diff_dates.Hours;
                        int Minutos = Convert.ToInt32(Diff_dates.TotalMinutes);

                        int Ptro_PorDosHorasExtras = Convert.ToInt32(new ParametroBL().Selecciona("PorcentajeDosHorasExtras").Numero);
                        int Ptro_PorMasDeDosHorasExtras = Convert.ToInt32(new ParametroBL().Selecciona("PorcentajeMasDeDosHorasExtras").Numero);
                        // Aumentar Asignación Familiar
                        if (objE_Persona.FlagAsignacion)
                        {
                            ParametroBE Ptro_SueldoMinimo = new ParametroBL().Selecciona("SueldoMinimo");
                            decimal dAsigFam = (Ptro_SueldoMinimo.Numero * intPorcentajeAsigFamiliar);
                            Sueldo += dAsigFam;
                        }
                        // Cuanto Gana Por Hora
                        decimal SueldoHora = Math.Round((Math.Round(((Sueldo) / Convert.ToDecimal("30")), 2) / Convert.ToDecimal("8")), 2);
                        decimal SueldoMin = Math.Round(((Sueldo) / Convert.ToDecimal("30")), 2) / Convert.ToDecimal("8") / Convert.ToDecimal("60");

                        int G1PagarHoras = Horas;
                        int G1PagarMinutos = Minutos;

                        int G2PagarHoras = 0;
                        int G2PagarMinutos = 0;
                        // Horas Total
                        decimal Horas_25 = 0;
                        decimal Horas_35 = 0;
                        decimal Horas_total = 0;

                        int Horas25Diff = (Minutos - Horas * 60);
                        Horas_total = Convert.ToDecimal(Convert.ToString(Horas) + '.' + Horas25Diff.ToString("D2"));
                        Horas_25 = Convert.ToDecimal(Convert.ToString(Horas) + '.' + Horas25Diff.ToString("D2"));
                        if (Horas >= 3)
                        {
                            G1PagarHoras = 2;
                            G1PagarMinutos = 120;

                            G2PagarHoras = Horas - G1PagarHoras;
                            G2PagarMinutos = Minutos - G1PagarMinutos;

                            Horas_25 = 2;
                            int aHora35 = (Minutos - G1PagarMinutos);
                            int aMinuto35 = (Horas - G1PagarHoras);
                            int Horas35Diff = ((aHora35) - ((aMinuto35) * 60));
                            Horas_35 = Convert.ToDecimal(Convert.ToString(aMinuto35) + '.' + Horas35Diff.ToString("D2"));
                        }

                        //SET DATOS PERSONAL 25%
                        int intExtra = Ptro_PorDosHorasExtras;
                        decimal G1GanaHora = Math.Round((SueldoHora * G1PagarHoras), 2);
                        decimal G1GanaMin = Math.Round((SueldoMin * G1PagarMinutos), 2);
                        HoraExtraTotalBE G1HE25 = new HoraExtraBL().CalcularHora(intExtra, G1GanaHora, G1GanaMin);

                        //SET DATOS PERSONAL 35%
                        intExtra = Ptro_PorMasDeDosHorasExtras;
                        decimal G2GanaHora = Math.Round((SueldoHora * G2PagarHoras), 2);
                        decimal G2GanaMin = Math.Round((SueldoMin * G2PagarMinutos), 2);
                        HoraExtraTotalBE G2HE35 = new HoraExtraBL().CalcularHora(intExtra, G2GanaHora, G2GanaMin);

                        HoraExtraBE HoraExtra = new HoraExtraBE();
                        HoraExtra.IdHoraExtra = IdHoraExtra;
                        HoraExtra.Total25 = G1HE25.GanaMinExtra;
                        HoraExtra.Total35 = G2HE35.GanaMinExtra;
                        HoraExtra.Total100 = 0;
                        HoraExtra.SueldoHora = SueldoHora;
                        HoraExtra.Importe = Math.Round(G1HE25.GanaMinExtra + G2HE35.GanaMinExtra, 2);
                        HoraExtra.Horas25 = Horas_25;
                        HoraExtra.Horas35 = Horas_35;
                        HoraExtra.TotalHoras = Horas_total;
                        HoraExtraBL objBL_HoraExtra = new HoraExtraBL();
                        objBL_HoraExtra.Actualiza_Totales(HoraExtra);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }



        public HoraExtraBE ValidaExisteRegistro(int IdPersona, DateTime pFecInicio, DateTime pFecFin)
        {
            try
            {
                HoraExtraDL HoraExtra = new HoraExtraDL();
                return HoraExtra.ValidaExisteRegistro(IdPersona, pFecInicio, pFecFin);
            }
            catch (Exception ex)
            { throw ex; }
        }




    }
}

