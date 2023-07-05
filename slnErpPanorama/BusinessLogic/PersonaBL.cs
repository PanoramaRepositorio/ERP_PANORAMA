using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PersonaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PersonaBE> SeleccionaBusqueda()
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaBusqueda();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaBusquedaSinUsuario()
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaBusquedaSinUsuario();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaCargo(int IdEmpresa, int IdCargo)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaCargo(IdEmpresa, IdCargo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaVendedor(int IdEmpresa)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaVendedor(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaDisenador(int IdEmpresa)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaDisenador(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<PersonaBE> SeleccionaVendedorTodos(int IdEmpresa)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaVendedorTodos(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaGerencia(int IdEmpresa)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaGerencia(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaConductor(int IdEmpresa)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaConductor(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaAuxiliar(int IdEmpresa)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaAuxiliar(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaAsesor(int IdEmpresa)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaAsesor(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaSistemas(int IdEmpresa)
        {
            try
            {
                PersonalDL persona = new PersonalDL();
                return persona.SeleccionaSistemas(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                return Personal.ListaTodosActivo(IdEmpresa,IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> ListaTodos(int IdEmpresa, int IdTienda)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();



                return Personal.ListaTodos(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> ListaDescanso(DateTime Fecha)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                return Personal.ListaDescanso(Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> ListaApoyo(int IdEmpresa)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                return Personal.ListaApoyo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> ListaArea(int IdEmpresa, int IdArea)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                return Personal.ListaArea(IdEmpresa, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> ListaCumpleaño()
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                return Personal.ListaCumpleaño();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> ListaEnviaCorreoErrorPSE()
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                return Personal.ListaEnviaCorreoErrorPSE();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public PersonaBE Selecciona(int IdEmpresa, int IdPersona)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                PersonaBE objAna = Personal.Selecciona(IdEmpresa, IdPersona);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaBE Selecciona_UsuarioValidar(int IdEmpresa, int IdPersona)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                PersonaBE objAna = Personal.Selecciona_UsuarioValidar(IdEmpresa, IdPersona);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public PersonaBE SeleccionaNumeroDocumento(string Dni)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                PersonaBE objAna = Personal.SeleccionaNumeroDocumento(Dni);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PersonaBE pItem, List<DerechoHabienteBE> pListaDerechoHabiente, List<EstudioRealizadoBE> pListaEstudioRealizado, List<PersonaCuentaBancariaBE> pListaPersonaCuentaBancaria, List<ContratoBE> pListaContrato)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonalDL Personal = new PersonalDL();
                    DerechoHabienteDL DerechoHabiente = new DerechoHabienteDL();
                    EstudioRealizadoDL EstudioRealizado = new EstudioRealizadoDL();
                    PersonaCuentaBancariaDL PersonaCuentaBancaria = new PersonaCuentaBancariaDL();
                    ContratoDL Contrato = new ContratoDL();

                    int IdPersona = 0;
                    IdPersona = Personal.Inserta(pItem);

                    foreach (DerechoHabienteBE item in pListaDerechoHabiente)
                    {
                        //Insertamos el derecho habiente del personal
                        item.IdPersona = IdPersona;
                        DerechoHabiente.Inserta(item);
                    }

                    foreach (EstudioRealizadoBE item in pListaEstudioRealizado)
                    {
                        //Insertamos el derecho habiente del personal
                        item.IdPersona = IdPersona;
                        EstudioRealizado.Inserta(item);
                    }

                    foreach (PersonaCuentaBancariaBE item in pListaPersonaCuentaBancaria)
                    {
                        //Insertamos el derecho habiente del personal
                        item.IdPersona = IdPersona;
                        PersonaCuentaBancaria.Inserta(item);
                    }

                    foreach (ContratoBE item in pListaContrato)
                    {
                        //Insertamos el derecho habiente del personal
                        item.IdPersona = IdPersona;
                        Contrato.Inserta(item);
                    }

                    if (pItem.FechaIngreso != null)
                    {
                        //for (int i = 1; i < pItem.FechaIngreso.Day; i++)
                        //{

                        if (pItem.FechaIngreso.Day > 1)
                        {
                            AusenciaBL objBL_Ausencia = new AusenciaBL();
                            AusenciaBE objE_Ausencia = new AusenciaBE();

                            objE_Ausencia.IdAusencia = 0;
                            objE_Ausencia.IdEmpresa = pItem.IdPersona;
                            objE_Ausencia.IdPersona = IdPersona;
                            objE_Ausencia.Periodo = Parametros.intPeriodo;
                            objE_Ausencia.FechaDesde = Convert.ToDateTime("01/" + pItem.FechaIngreso.Month + "/" + pItem.FechaIngreso.Year);
                            //objE_Ausencia.FechaHasta = Convert.ToDateTime(i + "/" + pItem.FechaIngreso.Month + "/" + pItem.FechaIngreso.Year);
                            objE_Ausencia.FechaHasta = Convert.ToDateTime(pItem.FechaIngreso.AddDays(-1).Day + "/" + pItem.FechaIngreso.Month + "/" + pItem.FechaIngreso.Year);
                            objE_Ausencia.Dias = 1;
                            objE_Ausencia.IdMotivoAusencia = 10;//Falta Justificada
                            objE_Ausencia.IdAutorizado = pItem.IdPersona;
                            objE_Ausencia.Observacion = "Ingreso el " + pItem.FechaIngreso;
                            objE_Ausencia.FlagEstado = true;
                            objE_Ausencia.Usuario = Parametros.strUsuarioLogin;
                            objE_Ausencia.Maquina = pItem.Maquina;
                            objE_Ausencia.IdEmpresa = pItem.IdEmpresa;

                            objBL_Ausencia.Inserta(objE_Ausencia);
                        }

                        //}
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PersonaBE pItem, List<DerechoHabienteBE> pListaDerechoHabiente, List<EstudioRealizadoBE> pListaEstudioRealizado, List<PersonaCuentaBancariaBE> pListaPersonaCuentaBancaria, List<ContratoBE> pListaContrato)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonalDL objPersonal = new PersonalDL();
                    DerechoHabienteDL DerechoHabiente = new DerechoHabienteDL();
                    EstudioRealizadoDL EstudioRealizado = new EstudioRealizadoDL();
                    PersonaCuentaBancariaDL PersonaCuentaBancaria = new PersonaCuentaBancariaDL();
                    ContratoDL Contrato = new ContratoDL();

                    foreach (DerechoHabienteBE item in pListaDerechoHabiente)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del derecho habiente
                            item.IdPersona = pItem.IdPersona;
                            DerechoHabiente.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del derecho habiente
                            DerechoHabiente.Actualiza(item);
                        }
                    }

                    foreach (EstudioRealizadoBE item in pListaEstudioRealizado)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del estudio realizado
                            item.IdPersona = pItem.IdPersona;
                            EstudioRealizado.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del estudio realizado
                            EstudioRealizado.Actualiza(item);
                        }
                    }

                    foreach (PersonaCuentaBancariaBE item in pListaPersonaCuentaBancaria)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del derecho habiente
                            item.IdPersona = pItem.IdPersona;
                            PersonaCuentaBancaria.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del derecho habiente
                            PersonaCuentaBancaria.Actualiza(item);
                        }
                    }

                    foreach (ContratoBE item in pListaContrato)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del derecho habiente
                            item.IdPersona = pItem.IdPersona;
                            Contrato.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del derecho habiente
                            Contrato.Actualiza(item);
                        }
                    }


                    objPersonal.Actualiza(pItem);

                    UsuarioBE objE_Usuario = new UsuarioBE();
                    UsuarioDL objUsuario = new UsuarioDL();

                    objE_Usuario.IdPersona = pItem.IdPersona;
                    objE_Usuario.IdEmpresa = pItem.IdEmpresa;
                    objUsuario.ActualizaEmpresa(objE_Usuario);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDisponibilidad(int IdPersona, int IdDisponibilidad)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                Personal.ActualizaDisponibilidad(IdPersona, IdDisponibilidad);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PersonaBE pItem)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                Personal.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaFisico(PersonaBE pItem)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                Personal.EliminaFisico(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaBE SeleccionaNumeroDocumentoPersonal(string Dni)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                PersonaBE objAna = Personal.SeleccionaNumeroDocumentoPersonal(Dni);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaBE SeleccionaPersonal(string pNumeroDocumento)
        {
            try
            {
                PersonalDL Personal = new PersonalDL();
                PersonaBE objAna = Personal.SeleccionaPersonal(pNumeroDocumento);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaBusqueda(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            try
            {
                PersonalDL personal = new PersonalDL();
                return personal.SeleccionaBusqueda(IdEmpresa, IdTipoCliente, pFiltro, Pagina, CantidadRegistro, TipoBusqueda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdTipoCliente, string pFiltro, int TipoBusqueda)
        {
            try
            {
                PersonalDL Persona = new PersonalDL();
                return Persona.SeleccionaBusquedaCount(IdEmpresa, IdTipoCliente, pFiltro, TipoBusqueda);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
