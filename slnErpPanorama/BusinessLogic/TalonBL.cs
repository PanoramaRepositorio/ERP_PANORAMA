using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TalonBL
    {
        public List<TalonBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                TalonDL Talon = new TalonDL();
                return Talon.ListaTodosActivo(IdEmpresa,IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TalonBE> ListaCaja(int IdEmpresa, int IdCaja)
        {
            try
            {
                TalonDL Talon = new TalonDL();
                return Talon.ListaCaja(IdEmpresa, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public TalonBE Selecciona(int IdEmpresa, int IdTienda, int IdTalon)
        {
            try
            {
                TalonDL Talon = new TalonDL();
                return Talon.Selecciona(IdEmpresa, IdTienda, IdTalon);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TalonBE SeleccionaCajaDocumento(int IdEmpresa, int IdTienda, int IdCaja, int IdTipoDocumento)
        {
            try
            {
                TalonDL Talon = new TalonDL();
                return Talon.SeleccionaCajaDocumento(IdEmpresa, IdTienda, IdCaja, IdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TalonBE pItem)
        {
            try
            {
                TalonDL Talon = new TalonDL();
                Talon.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TalonBE pItem)
        {
            try
            {
                TalonDL Talon = new TalonDL();
                Talon.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TalonBE pItem)
        {
            try
            {
                TalonDL Talon = new TalonDL();
                Talon.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

