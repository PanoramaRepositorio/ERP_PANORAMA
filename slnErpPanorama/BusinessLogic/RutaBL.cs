using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class RutaBL
    {
        public List<RutaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                RutaDL Ruta = new RutaDL();
                return Ruta.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public RutaBE Selecciona(int IdEmpresa, int IdRuta)
        {
            try
            {
                RutaDL Ruta = new RutaDL();
                return Ruta.Selecciona(IdEmpresa,IdRuta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(RutaBE pItem)
        {
            try
            {
                RutaDL Ruta = new RutaDL();
                Ruta.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(RutaBE pItem)
        {
            try
            {
                RutaDL Ruta = new RutaDL();
                Ruta.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(RutaBE pItem)
        {
            try
            {
                RutaDL Ruta = new RutaDL();
                Ruta.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
