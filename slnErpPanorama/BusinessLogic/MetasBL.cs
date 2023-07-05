using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MetasBL
    {
        public List<MetasBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                MetasDL Metas = new MetasDL();
                return Metas.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MetasBE> ListaPeriodo(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                MetasDL Metas = new MetasDL();
                return Metas.ListaPeriodo(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MetasBE Selecciona(int IdEmpresa, int IdMeta)
        {
            try
            {
                MetasDL Metas = new MetasDL();
                return Metas.Selecciona(IdEmpresa, IdMeta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MetasBE SeleccionaCargoMes(int IdEmpresa, int IdTienda, int Periodo, int Mes, int IdCargo)
        {
            try
            {
                MetasDL Metas = new MetasDL();
                return Metas.SeleccionaCargoMes(IdEmpresa, IdTienda, Periodo, Mes, IdCargo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MetasBE pItem)
        {
            try
            {
                MetasDL Metas = new MetasDL();
                Metas.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MetasBE pItem)
        {
            try
            {
                MetasDL Metas = new MetasDL();
                Metas.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MetasBE pItem)
        {
            try
            {
                MetasDL Metas = new MetasDL();
                Metas.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
