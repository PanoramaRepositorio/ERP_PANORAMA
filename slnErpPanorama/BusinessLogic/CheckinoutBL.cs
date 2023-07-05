using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CheckinoutBL
    {
        public List<CheckinoutBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                return Checkinout.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CheckinoutBE> ListaTodosActivoFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                return Checkinout.ListaTodosActivoFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CheckinoutBE> ListaMarcacion(string Dni , int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                return Checkinout.ListaMarcacion(Dni, IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<CheckinoutBE> ListaTardanza(string Dni, int IdPersona, DateTime FechaDesde, DateTime FechaHasta,int TipoReporte)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                return Checkinout.ListaTardanza(Dni, IdPersona, FechaDesde, FechaHasta,TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CheckinoutBE Selecciona(int IdEmpresa)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                return Checkinout.Selecciona(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CheckinoutBE SeleccionaFecha(string Dni, DateTime Fecha)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                return Checkinout.SeleccionaFecha(Dni, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public CheckinoutBE SeleccionaFechaRecuperacion(string Dni, DateTime Fecha)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                return Checkinout.SeleccionaFechaRecuperacion(Dni, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(List<CheckinoutBE> pListaCheckinout)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaCheckinout)
                    {
                        CheckinoutDL Checkinout = new CheckinoutDL();
                        Checkinout.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CheckinoutBE pItem)
        {
            try
            {
                TempCheckinoutBL TempCheckinout = new TempCheckinoutBL();
                CheckinoutDL Checkinout = new CheckinoutDL();
                CheckinoutBE objE_Checkinout = new CheckinoutBE();
                //Checkinout Temp

                objE_Checkinout = Checkinout.Selecciona(pItem.IdCheckinout);

                TempCheckinoutBE objE_TempCheckinout = new TempCheckinoutBE();
                objE_TempCheckinout.IdTempCheckinout = 0;
                objE_TempCheckinout.IdCheckinout = objE_Checkinout.IdCheckinout;
                objE_TempCheckinout.Dni = pItem.Dni;
                objE_TempCheckinout.Fecha = Convert.ToDateTime(objE_Checkinout.FechaHora.DateTime.ToShortDateString());
                objE_TempCheckinout.FechaOriginal = objE_Checkinout.FechaHora.DateTime;
                objE_TempCheckinout.FechaUpdate = pItem.Fecha;
                objE_TempCheckinout.FechaRegistro = DateTime.Now;
                objE_TempCheckinout.UsuarioRegistro = pItem.Usuario;
                objE_TempCheckinout.MaquinaRegistro = pItem.Maquina;
                objE_TempCheckinout.FlagEstado = true;
                objE_TempCheckinout.Usuario = pItem.Usuario;
                objE_TempCheckinout.Maquina = pItem.Maquina;

                TempCheckinout.Inserta(objE_TempCheckinout);

                //Actualiza marcación
                Checkinout.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CheckinoutBE pItem)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                Checkinout.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void SincronizarReloj2(int Dias, bool bElimina)
        {
            try
            {
                CheckinoutDL Checkinout = new CheckinoutDL();
                Checkinout.SincronizarReloj2(Dias, bElimina);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void InsertaSimple(CheckinoutBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TempCheckinoutBL TempCheckinout = new TempCheckinoutBL();
                    CheckinoutDL Checkinout = new CheckinoutDL();

                    TempCheckinoutBE objE_TempCheckinout = new TempCheckinoutBE();
                    objE_TempCheckinout.IdTempCheckinout = 0;
                    objE_TempCheckinout.IdCheckinout = 0;
                    objE_TempCheckinout.Dni = pItem.Dni;
                    objE_TempCheckinout.Fecha = Convert.ToDateTime(pItem.FechaHora.DateTime.ToShortDateString());
                    objE_TempCheckinout.FechaOriginal = pItem.FechaHora.DateTime;
                    objE_TempCheckinout.FechaUpdate = pItem.Fecha;
                    objE_TempCheckinout.FechaRegistro = DateTime.Now;
                    objE_TempCheckinout.UsuarioRegistro = pItem.Usuario;
                    objE_TempCheckinout.MaquinaRegistro = pItem.Maquina;
                    objE_TempCheckinout.FlagEstado = true;
                    objE_TempCheckinout.Usuario = pItem.Usuario;
                    objE_TempCheckinout.Maquina = pItem.Maquina;

                    TempCheckinout.Inserta(objE_TempCheckinout);

                    //Agregar Checkinout
                    Checkinout.InsertaSimple(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
