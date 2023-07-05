using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AsesoriaBL
    {
        public List<AsesoriaBE> ListaTodosActivo(int IdEmpresa,DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AsesoriaDL Asesoria = new AsesoriaDL();
                return Asesoria.ListaTodosActivo(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public AsesoriaBE Selecciona(int IdEmpresa, int IdAsesoria)
        //{
        //    //try
        //    //{
        //    //    AsesoriaDL Asesoria = new AsesoriaDL();
        //    //    return Asesoria.Selecciona(IdEmpresa, IdAsesoria);
        //    //}
        //    //catch (Exception ex)
        //    //{ throw ex; }
        //}

        public void Inserta(AsesoriaBE pItem)
        {
            try
            {
                AsesoriaDL Asesoria = new AsesoriaDL();
                Asesoria.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AsesoriaBE pItem)
        {
            try
            {
                AsesoriaDL Asesoria = new AsesoriaDL();
                Asesoria.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AsesoriaBE pItem)
        {
            try
            {
                AsesoriaDL Asesoria = new AsesoriaDL();
                Asesoria.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaFecha(AsesoriaBE pItem)
        {
            try
            {
                AsesoriaDL Asesoria = new AsesoriaDL();
                Asesoria.ActualizaFecha(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaVinculoPedido(int IdAsesoria, int IdPedido)
        {
            try
            {
                AsesoriaDL Asesoria = new AsesoriaDL();
                Asesoria.ActualizaVinculoPedido(IdAsesoria, IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
