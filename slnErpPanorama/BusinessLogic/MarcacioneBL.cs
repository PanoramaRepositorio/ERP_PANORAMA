using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MarcacionesBL
    {
        public List<MarcacionesBE> ListaTodos(String dni,String fecha)
        {
            try
            {
                MarcacionesDL Marcaciones = new MarcacionesDL();
                return Marcaciones.ListaTodos(dni,fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void InsertaHE(MarcacionesBE pItem)
        {
            try
            {
                MarcacionesDL Marca = new MarcacionesDL();
                Marca.InsertaHE(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MarcacionesBE> ListaMaciones(String IdEmpresa)
        {
            try
            {
                MarcacionesDL Marca = new MarcacionesDL();
                return Marca.ListaMarcaciones(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
  

    }
}

