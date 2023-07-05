using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class VacacionesBL
    {
        public List<VacacionesBE> ListaTodosActivo(int Periodo)
        {
            try
            {
                VacacionesDL Vacaciones = new VacacionesDL();
                return Vacaciones.ListaTodosActivo(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public VacacionesBE Selecciona(int IdVacaciones)
        {
            try
            {
                VacacionesDL Vacaciones = new VacacionesDL();
                return Vacaciones.Selecciona(IdVacaciones);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(VacacionesBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    VacacionesDL Vacaciones = new VacacionesDL();
                    Vacaciones.Inserta(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(VacacionesBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    VacacionesDL Vacaciones = new VacacionesDL();
                    Vacaciones.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(VacacionesBE pItem)
        {
            try
            {
                VacacionesDL Vacaciones = new VacacionesDL();
                Vacaciones.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
