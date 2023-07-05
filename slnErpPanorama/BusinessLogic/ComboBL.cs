using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ComboBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ComboBE> ListaTodosActivo(int IdCombo)
        {
            try
            {
                ComboDL Combo = new ComboDL();
                return Combo.ListaTodosActivo(IdCombo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ComboBE pItem, List<ComboDetalleBE> pListaComboDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ComboDL Combo = new ComboDL();
                    ComboDetalleDL ComboDetalle = new ComboDetalleDL();

                    int IdCombo = 0;
                    IdCombo = Combo.Inserta(pItem);

                    foreach (ComboDetalleBE item in pListaComboDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdCombo = IdCombo;
                        ComboDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ComboBE pItem, List<ComboDetalleBE> pListaComboDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ComboDL Combo = new ComboDL();
                    ComboDetalleDL ComboDetalle = new ComboDetalleDL();


                    foreach (ComboDetalleBE item in pListaComboDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdCombo = pItem.IdCombo;
                            ComboDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            ComboDetalle.Actualiza(item);
                        }
                    }

                    Combo.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ComboBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ComboDL Combo = new ComboDL();
                    ComboDetalleDL ComboDetalle = new ComboDetalleDL();

                    List<ComboDetalleBE> lstComboDetalle = null;
                    lstComboDetalle = ComboDetalle.ListaTodosActivo(pItem.IdCombo);

                    foreach (ComboDetalleBE item in lstComboDetalle)
                    {
                        ComboDetalle.Elimina(item);
                    }

                    //Eliminamos el Solicitud Principal
                    Combo.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
