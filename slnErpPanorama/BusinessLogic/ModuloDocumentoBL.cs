using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ModuloDocumentoBL
    {
        public List<ModuloDocumentoBE> ListaTodosActivo(int IdModulo, int IdTipoDocumento)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                return ModuloDocumento.ListaTodosActivo(IdModulo, IdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ModuloDocumentoBE> ListaVentas(int IdModulo, int IdTipoDocumento)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                return ModuloDocumento.ListaVentas(IdModulo, IdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ModuloDocumentoBE> ListaVentasNC(int IdModulo, int IdTipoDocumento)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                return ModuloDocumento.ListaVentasNC(IdModulo, IdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ModuloDocumentoBE> ListaDevolucion(int IdModulo, int IdTipoDocumento)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                return ModuloDocumento.ListaDevolucion(IdModulo, IdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ModuloDocumentoBE> ListaNotaIngreso(int IdModulo)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                return ModuloDocumento.ListaNotaIngreso(IdModulo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ModuloDocumentoBE> ListaNotaSalida(int IdModulo)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                return ModuloDocumento.ListaNotaSalida(IdModulo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ModuloDocumentoBE pItem)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                ModuloDocumento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ModuloDocumentoBE pItem)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                ModuloDocumento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ModuloDocumentoBE pItem)
        {
            try
            {
                ModuloDocumentoDL ModuloDocumento = new ModuloDocumentoDL();
                ModuloDocumento.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
