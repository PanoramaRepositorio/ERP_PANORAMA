using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;


namespace ErpPanorama.BusinessLogic
{
    public class AlmacenBL
    {

        public List<AlmacenBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                return Almacen.ListaTodosActivo(IdEmpresa,IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AlmacenBE> ListaTodosActivoPerfil(int IdEmpresa, int IdTienda, int IdPerfil)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                return Almacen.ListaTodosActivoPerfil(IdEmpresa, IdTienda, IdPerfil);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AlmacenBE> ListaTodosActivoPrincipal(int IdEmpresa, int IdTienda)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                return Almacen.ListaTodosActivoPrincipal(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AlmacenBE> ListaTodosActivoPrincipalMar(int IdEmpresa, int IdTienda)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                return Almacen.ListaTodosActivoPrincipalMar(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AlmacenBE> ListaAlmacenesTodosActivos(int IdEmpresa, int IdTienda)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                return Almacen.ListaAlmacenesTodosActivos(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AlmacenBE Selecciona(int IdAlmacen)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                return Almacen.Selecciona(IdAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AlmacenBE pItem)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                Almacen.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AlmacenBE pItem)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                Almacen.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AlmacenBE pItem)
        {
            try
            {
                AlmacenDL Almacen = new AlmacenDL();
                Almacen.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
