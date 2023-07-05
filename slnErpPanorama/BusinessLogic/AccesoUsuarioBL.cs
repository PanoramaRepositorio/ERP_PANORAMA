using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AccesoUsuarioBL
    {
        public List<AccesoUsuarioBE> SeleccionaCriterioVarios(int IdUser, int IdPerfil)
        {
            try
            {
                AccesoUsuarioDL accesousuario = new AccesoUsuarioDL();
                return accesousuario.SeleccionaCriterioVarios(IdUser, IdPerfil);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccesoUsuarioBE> SeleccionaUserPerfil(int IdUser, int IdPerfil)
        {
            try
            {
                AccesoUsuarioDL accesousuario = new AccesoUsuarioDL();
                return accesousuario.SeleccionaUserPerfil(IdUser, IdPerfil);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccesoUsuarioBE> SeleccionaUser(int IdUser)
        {
            try
            {
                AccesoUsuarioDL accesousuario = new AccesoUsuarioDL();
                return accesousuario.SeleccionaUser(IdUser);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccesoUsuarioBE> SeleccionaPermisoAcceso(string Usuario, int IdPerfil)
        {
            try
            {
                AccesoUsuarioDL accesousuario = new AccesoUsuarioDL();
                return accesousuario.SeleccionaPermisoAcceso(Usuario, IdPerfil);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccesoUsuarioBE> ListaTodosActivo()
        {
            try
            {
                AccesoUsuarioDL accesousuario = new AccesoUsuarioDL();
                return accesousuario.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccesoUsuarioBE pItem)
        {
            try
            {
                AccesoUsuarioDL accesousuario = new AccesoUsuarioDL();
                accesousuario.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
