using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PlaAfpBL
    {
        public List<PlaAfpBE> ListaTodosActivo()
        {
            try
            {
                PlaAfpDL PlaAfp = new PlaAfpDL();
                return PlaAfp.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PlaAfpBE Selecciona( int IdPlaAfp)
        {
            try
            {
                PlaAfpDL PlaAfp = new PlaAfpDL();
                return PlaAfp.Selecciona( IdPlaAfp);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PlaAfpBE pItem)
        {
            try
            {
                PlaAfpDL PlaAfp = new PlaAfpDL();
                PlaAfp.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PlaAfpBE pItem)
        {
            try
            {
                PlaAfpDL PlaAfp = new PlaAfpDL();
                PlaAfp.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PlaAfpBE pItem)
        {
            try
            {
                PlaAfpDL PlaAfp = new PlaAfpDL();
                PlaAfp.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
