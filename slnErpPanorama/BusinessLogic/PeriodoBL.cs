using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PeriodoBL
    {
        public List<PeriodoBE> ListaTodosActivo()
        {
            try
            {
                PeriodoDL Periodo = new PeriodoDL();
                return Periodo.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PeriodoBE pItem)
        {
            try
            {
                PeriodoDL Periodo = new PeriodoDL();
                Periodo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PeriodoBE pItem)
        {
            try
            {
                PeriodoDL Periodo = new PeriodoDL();
                Periodo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PeriodoBE pItem)
        {
            try
            {
                PeriodoDL Periodo = new PeriodoDL();
                Periodo.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PeriodoBE Selecciona(int Periodo, int Mes)
        {
            try
            {
                PeriodoDL Periodos = new PeriodoDL();
                PeriodoBE objPeriodo = Periodos.Selecciona(Periodo, Mes);
                return objPeriodo;
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
