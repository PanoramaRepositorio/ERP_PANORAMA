using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class ModuloDespachoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<ModuloDespachoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				ModuloDespachoDL ModuloDespacho = new ModuloDespachoDL();
				return ModuloDespacho.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public ModuloDespachoBE Selecciona(int IdModuloDespacho)
		{
			try
			{
				ModuloDespachoDL ModuloDespacho = new ModuloDespachoDL();
				return ModuloDespacho.Selecciona(IdModuloDespacho);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public ModuloDespachoBE SeleccionaDespachador(int IdDespachador)
        {
            try
            {
                ModuloDespachoDL ModuloDespacho = new ModuloDespachoDL();
                return ModuloDespacho.SeleccionaDespachador(IdDespachador);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ModuloDespachoBE pItem)
		{
			try
			{
				ModuloDespachoDL ModuloDespacho = new ModuloDespachoDL();
				ModuloDespacho.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(ModuloDespachoBE pItem)
		{
			try
			{
				ModuloDespachoDL ModuloDespacho = new ModuloDespachoDL();
				ModuloDespacho.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(ModuloDespachoBE pItem)
		{
			try
			{
				ModuloDespachoDL ModuloDespacho = new ModuloDespachoDL();
				ModuloDespacho.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
