using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EquipoBL
    {
        public List<EquipoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                return Equipo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EquipoBE> ListaTodosConexion(int IdEmpresa)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                return Equipo.ListaTodosConexion(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<EquipoBE> ListaCaja(int IdEmpresa, int IdTienda, int IdEquipo)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                return Equipo.ListaCaja(IdEmpresa, IdTienda, IdEquipo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EquipoBE Selecciona(int IdEquipo)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                return Equipo.Selecciona(IdEquipo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EquipoBE SeleccionaHostName(string HostName)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                return Equipo.SeleccionaHostName(HostName);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(EquipoBE pItem)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                Equipo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EquipoBE pItem)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                Equipo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EquipoBE pItem)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                Equipo.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
