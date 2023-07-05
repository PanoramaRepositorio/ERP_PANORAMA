using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class TarjetaRegaloBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<TarjetaRegaloBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
		{
			try
			{
				TarjetaRegaloDL TarjetaRegalo = new TarjetaRegaloDL();
				return TarjetaRegalo.ListaTodosActivo(IdEmpresa, IdTienda);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public TarjetaRegaloBE Selecciona(int IdTarjetaRegalo)
		{
			try
			{
				TarjetaRegaloDL TarjetaRegalo = new TarjetaRegaloDL();
				return TarjetaRegalo.Selecciona(IdTarjetaRegalo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public TarjetaRegaloBE SeleccionaNumero(string Numero)
        {
            try
            {
                TarjetaRegaloDL TarjetaRegalo = new TarjetaRegaloDL();
                return TarjetaRegalo.SeleccionaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TarjetaRegaloBE pItem)
		{
			try
			{
				TarjetaRegaloDL TarjetaRegalo = new TarjetaRegaloDL();
				TarjetaRegalo.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(TarjetaRegaloBE pItem)
		{
			try
			{
				TarjetaRegaloDL TarjetaRegalo = new TarjetaRegaloDL();
				TarjetaRegalo.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}
        public void ActualizaDisponible(TarjetaRegaloBE pItem)
        {
            try
            {
                TarjetaRegaloDL TarjetaRegalo = new TarjetaRegaloDL();
                TarjetaRegalo.ActualizaDisponible(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Elimina(TarjetaRegaloBE pItem)
		{
			try
			{
				TarjetaRegaloDL TarjetaRegalo = new TarjetaRegaloDL();
				TarjetaRegalo.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
