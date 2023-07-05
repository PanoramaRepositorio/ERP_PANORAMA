using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TablaElementoBL
    {
        public List<TablaElementoBE> ListaTodosActivo(int IdEmpresa, int IdTabla)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                return TablaElemento.ListaTodosActivo(IdEmpresa, IdTabla);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<TablaElementoBE> ListaTodosActivoSinEcommerce(int IdEmpresa, int IdTabla, int IdTienda)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                return TablaElemento.ListaTodosActivoSinEcommerce(IdEmpresa, IdTabla, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TablaElementoBE> ListaTodosActivoPorTabla(int IdEmpresa, int IdTabla)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                return TablaElemento.ListaTodosActivoPorTabla(IdEmpresa, IdTabla);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TablaElementoBE> ListaTodosActivoPorTablaExterna(int IdEmpresa, int IdTabla, int IdTablaExterna)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                return TablaElemento.ListaTodosActivoPorTablaExterna(IdEmpresa, IdTabla, IdTablaExterna);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TablaElementoBE> ListaAlmacenIngreso(int IdEmpresa)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                return TablaElemento.ListaAlmacenIngreso(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TablaElementoBE> ListaAlmacenSalida(int IdEmpresa)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                return TablaElemento.ListaAlmacenSalida(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TablaElementoBE pItem)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                TablaElemento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TablaElementoBE pItem)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                TablaElemento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TablaElementoBE pItem)
        {
            try
            {
                TablaElementoDL TablaElemento = new TablaElementoDL();
                TablaElemento.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
