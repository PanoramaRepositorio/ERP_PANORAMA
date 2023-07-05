using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AreaBL
    {
        public List<AreaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                AreaDL Area = new AreaDL();
                return Area.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AreaBE Selecciona(int IdEmpresa, int IdArea)
        {
            try
            {
                AreaDL Area = new AreaDL();
                return Area.Selecciona(IdEmpresa, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AreaBE pItem)
        {
            try
            {
                AreaDL Area = new AreaDL();
                Area.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AreaBE pItem)
        {
            try
            {
                AreaDL Area = new AreaDL();
                Area.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AreaBE pItem)
        {
            try
            {
                AreaDL Area = new AreaDL();
                Area.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
