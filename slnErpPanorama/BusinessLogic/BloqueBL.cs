using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class BloqueBL
    {
        public List<BloqueBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen, int IdSector)
        {
            try
            {
                BloqueDL Bloque = new BloqueDL();
                return Bloque.ListaTodosActivo(IdEmpresa, IdTienda, IdAlmacen, IdSector);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(BloqueBE pItem)
        {
            try
            {
                BloqueDL Bloque = new BloqueDL();
                Bloque.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(BloqueBE pItem)
        {
            try
            {
                BloqueDL Bloque = new BloqueDL();
                Bloque.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(BloqueBE pItem)
        {
            try
            {
                BloqueDL Bloque = new BloqueDL();
                Bloque.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

