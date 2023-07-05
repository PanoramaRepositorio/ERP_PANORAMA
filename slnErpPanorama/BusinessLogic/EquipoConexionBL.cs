using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EquipoConexionBL
    {
        public List<EquipoConexionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                EquipoConexionDL EquipoConexion = new EquipoConexionDL();
                return EquipoConexion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EquipoConexionBE Selecciona(int IdEquipoConexion)
        {
            try
            {
                EquipoConexionDL EquipoConexion = new EquipoConexionDL();
                return EquipoConexion.Selecciona(IdEquipoConexion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EquipoConexionBE pItem)
        {
            try
            {
                EquipoConexionDL EquipoConexion = new EquipoConexionDL();
                EquipoConexion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EquipoConexionBE pItem)
        {
            try
            {
                EquipoConexionDL EquipoConexion = new EquipoConexionDL();
                EquipoConexion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EquipoConexionBE pItem)
        {
            try
            {
                EquipoConexionDL EquipoConexion = new EquipoConexionDL();
                EquipoConexion.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
