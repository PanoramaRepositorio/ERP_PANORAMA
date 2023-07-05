using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_PiezaBL
    {
        public List<Dis_PiezaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                Dis_PiezaDL Dis_Pieza = new Dis_PiezaDL();
                return Dis_Pieza.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_PiezaBE pItem)
        {
            try
            {
                Dis_PiezaDL Dis_Pieza = new Dis_PiezaDL();
                Dis_Pieza.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_PiezaBE pItem)
        {
            try
            {
                Dis_PiezaDL Dis_Pieza = new Dis_PiezaDL();
                Dis_Pieza.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_PiezaBE pItem)
        {
            try
            {
                Dis_PiezaDL Dis_Pieza = new Dis_PiezaDL();
                Dis_Pieza.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
