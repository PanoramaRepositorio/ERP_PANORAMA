using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class UbigeoBL
    {
        public List<UbigeoBE> SeleccionaDepartamento()
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaDepartamento();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbigeoBE> SeleccionaProvincia(string IdDepartamento)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaProvincia(IdDepartamento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbigeoBE> SeleccionaDistrito(string IdDepartamento, string IdProvincia)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaDistrito(IdDepartamento,IdProvincia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbigeoBE> SeleccionaDistritoDelivery(string IdDepartamento, string IdProvincia)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.SeleccionaDistritoDelivery(IdDepartamento, IdProvincia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UbigeoBE Selecciona(string IdUbigeo)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.Selecciona(IdUbigeo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UbigeoBE Selecciona_Ubigeo_xDistrito(string DesDistrito)
        {
            try
            {
                UbigeoDL Ubigeo = new UbigeoDL();
                return Ubigeo.Selecciona_UbigeoxDistrito(DesDistrito);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbigeoBE> Selecciona_Ubigeo_xDistrito2(string DesDistrito)
        {
            try
            {
                UbigeoDL PedidoDetalle = new UbigeoDL();
                return PedidoDetalle.Selecciona_UbigeoxDistrito2(DesDistrito);
            }
            catch (Exception ex)
            { throw ex; }
        }



    }
}
