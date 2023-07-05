using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MetasComisionBL
    {
        public List<MetasComisionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                MetasComisionDL MetasComision = new MetasComisionDL();
                return MetasComision.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MetasComisionBE Selecciona(int IdEmpresa, int IdMetaComision)
        {
            try
            {
                MetasComisionDL MetasComision = new MetasComisionDL();
                return MetasComision.Selecciona(IdEmpresa, IdMetaComision);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MetasComisionBE pItem)
        {
            try
            {
                MetasComisionDL MetasComision = new MetasComisionDL();
                MetasComision.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MetasComisionBE pItem)
        {
            try
            {
                MetasComisionDL MetasComision = new MetasComisionDL();
                MetasComision.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MetasComisionBE pItem)
        {
            try
            {
                MetasComisionDL MetasComision = new MetasComisionDL();
                MetasComision.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
