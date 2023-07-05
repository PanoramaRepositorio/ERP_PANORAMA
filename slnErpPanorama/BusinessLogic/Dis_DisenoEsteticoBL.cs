using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_DisenoEsteticoBL
    {
        public List<Dis_DisenoEsteticoBE> ListaTodosActivo(int IdDis_ProyectoServicio)
        {
            try
            {
                Dis_DisenoEsteticoDL Dis_DisenoEstetico = new Dis_DisenoEsteticoDL();
                return Dis_DisenoEstetico.ListaTodosActivo(IdDis_ProyectoServicio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_DisenoEsteticoBE pItem)
        {
            try
            {
                Dis_DisenoEsteticoDL Dis_DisenoEstetico = new Dis_DisenoEsteticoDL();
                Dis_DisenoEstetico.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_DisenoEsteticoBE pItem)
        {
            try
            {
                Dis_DisenoEsteticoDL Dis_DisenoEstetico = new Dis_DisenoEsteticoDL();
                Dis_DisenoEstetico.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_DisenoEsteticoBE pItem)
        {
            try
            {
                Dis_DisenoEsteticoDL Dis_DisenoEstetico = new Dis_DisenoEsteticoDL();
                Dis_DisenoEstetico.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
