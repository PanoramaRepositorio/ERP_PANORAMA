using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;
namespace ErpPanorama.BusinessLogic
{
    public class AusenciaBL
    {
        public List<AusenciaBE> ListaTodosActivo(int Periodo)
        {
            try
            {
                AusenciaDL Ausencia = new AusenciaDL();
                return Ausencia.ListaTodosActivo(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AusenciaBE Selecciona(int IdAusencia)
        {
            try
            {
                AusenciaDL Ausencia = new AusenciaDL();
                return Ausencia.Selecciona(IdAusencia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AusenciaBE SeleccionaFechaDni(DateTime Fecha, String Dni)
        {
            try
            {
                AusenciaDL Ausencia = new AusenciaDL();
                return Ausencia.SeleccionaFechaDni(Fecha, Dni);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AusenciaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AusenciaDL Ausencia = new AusenciaDL();
                    Ausencia.Inserta(pItem);



                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AusenciaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AusenciaDL Ausencia = new AusenciaDL();
                    Ausencia.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCalendario(int IdAusencia, int IdIdPersonaCalendarioLaboral,string Observacion)
        {
            try
            {
                AusenciaDL Ausencia = new AusenciaDL();
                Ausencia.ActualizaCalendario(IdAusencia, IdIdPersonaCalendarioLaboral, Observacion);

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AusenciaBE pItem)
        {
            try
            {
                AusenciaDL Ausencia = new AusenciaDL();
                Ausencia.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaCalendario(AusenciaBE pItem)
        {
            try
            {
                AusenciaDL Ausencia = new AusenciaDL();
                Ausencia.EliminaCalendario(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
