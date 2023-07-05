using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AnuncioBL
    {
        public List<AnuncioBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                AnuncioDL Anuncio = new AnuncioDL();
                return Anuncio.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AnuncioBE> ListaUltimoTipo(int IdTipoAnuncio)
        {
            try
            {
                AnuncioDL Anuncio = new AnuncioDL();
                return Anuncio.ListaUltimoTipo(IdTipoAnuncio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AnuncioBE Selecciona(int IdAusencia)
        {
            try
            {
                AnuncioDL Anuncio = new AnuncioDL();
                return Anuncio.Selecciona(IdAusencia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AnuncioBE SeleccionaUltimo()
        {
            try
            {
                AnuncioDL Anuncio = new AnuncioDL();
                return Anuncio.SeleccionaUltimo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AnuncioBE pItem)
        {
            try
            {
                AnuncioDL Anuncio = new AnuncioDL();
                Anuncio.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AnuncioBE pItem)
        {
            try
            {
                AnuncioDL Anuncio = new AnuncioDL();
                Anuncio.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AnuncioBE pItem)
        {
            try
            {
                AnuncioDL Anuncio = new AnuncioDL();
                Anuncio.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
