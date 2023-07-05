using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_TipoColorBL
    {
        public List<Dis_TipoColorBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                Dis_TipoColorDL Dis_TipoColor = new Dis_TipoColorDL();
                return Dis_TipoColor.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_TipoColorBE pItem)
        {
            try
            {
                Dis_TipoColorDL Dis_TipoColor = new Dis_TipoColorDL();
                Dis_TipoColor.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_TipoColorBE pItem)
        {
            try
            {
                Dis_TipoColorDL Dis_TipoColor = new Dis_TipoColorDL();
                Dis_TipoColor.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_TipoColorBE pItem)
        {
            try
            {
                Dis_TipoColorDL Dis_TipoColor = new Dis_TipoColorDL();
                Dis_TipoColor.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
