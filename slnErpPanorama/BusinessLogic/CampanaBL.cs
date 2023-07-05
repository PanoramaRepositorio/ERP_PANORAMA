using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CampanaBL
    {
        public List<CampanaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                CampanaDL Campana = new CampanaDL();
                return Campana.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CampanaBE pItem)
        {
            try
            {
                CampanaDL Campana = new CampanaDL();
                Campana.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CampanaBE pItem)
        {
            try
            {
                CampanaDL Campana = new CampanaDL();
                Campana.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CampanaBE pItem)
        {
            try
            {
                CampanaDL Campana = new CampanaDL();
                Campana.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

