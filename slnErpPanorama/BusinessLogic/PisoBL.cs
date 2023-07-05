using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PisoBL
    {
        public List<PisoBE> ListaTodosActivo(int IdEmpresa,int IdUbicacion)
        {
            try
            {
                PisoDL Piso = new PisoDL();
                return Piso.ListaTodosActivo(IdEmpresa,IdUbicacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PisoBE pItem)
        {
            try
            {
                PisoDL Piso = new PisoDL();
                Piso.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PisoBE pItem)
        {
            try
            {
                PisoDL Piso = new PisoDL();
                Piso.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PisoBE pItem)
        {
            try
            {
                PisoDL Piso = new PisoDL();
                Piso.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

