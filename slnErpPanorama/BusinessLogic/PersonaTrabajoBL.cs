using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PersonaTrabajoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PersonaTrabajoBE> ListaTodosActivo(int Periodo)
		{
			try
			{
				PersonaTrabajoDL PersonaTrabajo = new PersonaTrabajoDL();
				return PersonaTrabajo.ListaTodosActivo(Periodo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public PersonaTrabajoBE Selecciona(int IdPersonaTrabajo)
		{
			try
			{
				PersonaTrabajoDL PersonaTrabajo = new PersonaTrabajoDL();
				return PersonaTrabajo.Selecciona(IdPersonaTrabajo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public PersonaTrabajoBE SeleccionaFecha(DateTime Fecha)
        {
            try
            {
                PersonaTrabajoDL PersonaTrabajo = new PersonaTrabajoDL();
                return PersonaTrabajo.SeleccionaFecha(Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PersonaTrabajoBE pItem, List<PersonaTrabajoDetalleBE> pListaPersonaTrabajoDetalle)
		{
			try
			{
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonaTrabajoDL PersonaTrabajo = new PersonaTrabajoDL();
                    PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();

                    int IdPersonaTrabajo = 0;
                    IdPersonaTrabajo = PersonaTrabajo.Inserta(pItem);

                    foreach (PersonaTrabajoDetalleBE item in pListaPersonaTrabajoDetalle)
                    {
                        //Insertamos el detalle
                        item.IdPersonaTrabajo = IdPersonaTrabajo;
                        PersonaTrabajoDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PersonaTrabajoBE pItem, List<PersonaTrabajoDetalleBE> pListaPersonaTrabajoDetalle)
		{
			try
			{
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonaTrabajoDL PersonaTrabajo = new PersonaTrabajoDL();
                    PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();

                    foreach (PersonaTrabajoDetalleBE item in pListaPersonaTrabajoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle
                            item.IdPersonaTrabajo = pItem.IdPersonaTrabajo;
                            PersonaTrabajoDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle
                            PersonaTrabajoDetalle.Actualiza(item);
                        }
                    }

                    PersonaTrabajo.Actualiza(pItem);

                    ts.Complete();
                }
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PersonaTrabajoBE pItem)
		{
			try
			{
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonaTrabajoDL PersonaTrabajo = new PersonaTrabajoDL();
                    PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();

                    List<PersonaTrabajoDetalleBE> lstPersonaTrabajoDetalle = null;
                    lstPersonaTrabajoDetalle = PersonaTrabajoDetalle.ListaTodosActivo(pItem.IdPersonaTrabajo);

                    foreach (PersonaTrabajoDetalleBE item in lstPersonaTrabajoDetalle)
                    {
                        PersonaTrabajoDetalle.Elimina(item);
                    }

                    //Eliminamos el Solicitud Principal
                    PersonaTrabajo.Elimina(pItem);

                    ts.Complete();
                }
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
