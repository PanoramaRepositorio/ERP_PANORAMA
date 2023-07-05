using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ContratoBL
    {
        public List<ContratoBE> ListaTodosActivo(int Periodo, string Dni)
        {
            try
            {
                ContratoDL Contrato = new ContratoDL();
                return Contrato.ListaTodosActivo(Periodo, Dni);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ContratoBE> ListaPersona(int IdPersona)
        {
            try
            {
                ContratoDL Contrato = new ContratoDL();
                return Contrato.ListaPersona(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ContratoBE Selecciona(int IdContrato)
        {
            try
            {
                ContratoDL Contrato = new ContratoDL();
                return Contrato.Selecciona(IdContrato);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ContratoBE SeleccionaUltimo(int IdPersona)
        {
            try
            {
                ContratoDL Contrato = new ContratoDL();
                return Contrato.SeleccionaUltimo(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ContratoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ContratoDL Contrato = new ContratoDL();
                    Contrato.Inserta(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ContratoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ContratoDL Contrato = new ContratoDL();
                    Contrato.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ContratoBE pItem)
        {
            try
            {
                ContratoDL Contrato = new ContratoDL();
                Contrato.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
