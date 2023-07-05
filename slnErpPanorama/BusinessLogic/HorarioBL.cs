using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class HorarioBL
    {
        public List<HorarioBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                HorarioDL Horario = new HorarioDL();
                return Horario.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public HorarioBE Selecciona(int IdEmpresa, int IdHorario)
        {
            try
            {
                HorarioDL Horario = new HorarioDL();
                return Horario.Selecciona(IdEmpresa, IdHorario);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(HorarioBE pItem)
        {
            try
            {
                HorarioDL Horario = new HorarioDL();
                Horario.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(HorarioBE pItem)
        {
            try
            {
                HorarioDL Horario = new HorarioDL();
                Horario.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(HorarioBE pItem)
        {
            try
            {
                HorarioDL Horario = new HorarioDL();
                Horario.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
