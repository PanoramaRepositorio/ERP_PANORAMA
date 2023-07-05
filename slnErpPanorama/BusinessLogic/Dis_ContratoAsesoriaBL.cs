using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_ContratoAsesoriaBL
    {
        public List<Dis_ContratoAsesoriaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                Dis_ContratoAsesoriaDL Dis_ContratoAsesoria = new Dis_ContratoAsesoriaDL();
                return Dis_ContratoAsesoria.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Dis_ContratoAsesoriaBE Selecciona(int IdDis_ContratoAsesoria)
        {
            try
            {
                Dis_ContratoAsesoriaDL Dis_ContratoAsesoria = new Dis_ContratoAsesoriaDL();
                return Dis_ContratoAsesoria.Selecciona(IdDis_ContratoAsesoria);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_ContratoAsesoriaBE pItem)
        {
            try
            {
                Dis_ContratoAsesoriaDL Dis_ContratoAsesoria = new Dis_ContratoAsesoriaDL();
                Dis_ContratoAsesoria.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_ContratoAsesoriaBE pItem)
        {
            try
            {
                Dis_ContratoAsesoriaDL Dis_ContratoAsesoria = new Dis_ContratoAsesoriaDL();
                Dis_ContratoAsesoria.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_ContratoAsesoriaBE pItem)
        {
            try
            {
                Dis_ContratoAsesoriaDL Dis_ContratoAsesoria = new Dis_ContratoAsesoriaDL();
                Dis_ContratoAsesoria.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
