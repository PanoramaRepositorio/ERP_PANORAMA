using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_DisenoVisitasRealizadasBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<Dis_DisenoVisitasRealizadasBE> ListaTodosActivo(int IdDis_ProyectoServicio)
        {
            try
            {
                Dis_DisenoVisitasEfectuadasDL Dis_DisenoFuncional = new Dis_DisenoVisitasEfectuadasDL();
                return Dis_DisenoFuncional.ListaTodosActivo(IdDis_ProyectoServicio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_DisenoVisitasRealizadasBE pItem)
        {
            try
            {
                Dis_DisenoVisitasEfectuadasDL Dis_DisenoFuncional = new Dis_DisenoVisitasEfectuadasDL();
                Dis_DisenoFuncional.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_DisenoVisitasRealizadasBE pItem)
        {
            try
            {
                Dis_DisenoVisitasEfectuadasDL Dis_DisenoFuncional = new Dis_DisenoVisitasEfectuadasDL();
                Dis_DisenoFuncional.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_DisenoVisitasRealizadasBE pItem)
        {
            try
            {
                Dis_DisenoVisitasEfectuadasDL Dis_DisenoVisitasEfectuadas = new Dis_DisenoVisitasEfectuadasDL();
                Dis_DisenoVisitasEfectuadas.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaTodosVisitas(Dis_DisenoVisitasRealizadasBE pItem)
        {
            try
            {
                Dis_DisenoVisitasEfectuadasDL Dis_DisenoVisitasEfectuadas = new Dis_DisenoVisitasEfectuadasDL();
                Dis_DisenoVisitasEfectuadas.EliminaTodasVisitas(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaVisitasRealizadas(List<Dis_DisenoVisitasRealizadasBE> pListaItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Dis_DisenoVisitasEfectuadasDL CuentaBancoProvee = new Dis_DisenoVisitasEfectuadasDL();

                    foreach (Dis_DisenoVisitasRealizadasBE item in pListaItem)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            CuentaBancoProvee.InsertaVisitasRealizadas(item);
                        }
                        else
                        {
                            CuentaBancoProvee.InsertaVisitasRealizadas(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
