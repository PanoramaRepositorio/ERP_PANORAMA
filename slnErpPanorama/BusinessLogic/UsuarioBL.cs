using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class UsuarioBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<UsuarioBE> SeleccionaEmpresa(int IdEmpresa, string Descripcion)
        {
            try
            {
                UsuarioDL usuario = new UsuarioDL();
                return usuario.SeleccionaEmpresa(IdEmpresa, Descripcion);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<UsuarioBE> ListaTodosActivo()
        {
            try
            {
                UsuarioDL usuario = new UsuarioDL();
                return usuario.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public UsuarioBE Selecciona(int idUsuario)
        {
            try
            {
                UsuarioDL usuario = new UsuarioDL();
                return usuario.Selecciona(idUsuario);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UsuarioBE LogOnUser(string Usuario, string Password)
        {
            try
            {
                UsuarioDL usuario = new UsuarioDL();
                UsuarioBE objUsuBE = usuario.LogOnUser(Usuario, Password);
                return objUsuBE;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public UsuarioBE SeleccionaUsuario(string Usuario)
        {
            try
            {
                UsuarioDL usuario = new UsuarioDL();
                return usuario.SeleccionaUsuario(Usuario);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(UsuarioBE pItem, List<AccesoUsuarioBE> pListaAcceso)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    UsuarioDL objUsuario = new UsuarioDL();
                    AccesoUsuarioDL objAccesoUsuario = new AccesoUsuarioDL();
                    Int32 intIdUser = 0;

                    intIdUser = objUsuario.Inserta(pItem);
                    foreach (AccesoUsuarioBE item in pListaAcceso)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdUser = intIdUser;
                            item.IdPerfil = pItem.IdPerfil;
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAccesoUsuario.Inserta(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAccesoUsuario.Actualiza(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAccesoUsuario.Elimina(item);
                        }

                    }
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(UsuarioBE pItem, List<AccesoUsuarioBE> pListaAcceso)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    UsuarioDL objUsuario = new UsuarioDL();
                    AccesoUsuarioDL objAccesoUsuario = new AccesoUsuarioDL();

                    objUsuario.Actualiza(pItem);
                    foreach (AccesoUsuarioBE item in pListaAcceso)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdUser = pItem.IdUser;
                            item.IdPerfil = pItem.IdPerfil;
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAccesoUsuario.Inserta(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAccesoUsuario.Actualiza(item);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAccesoUsuario.Elimina(item);
                        }

                    }
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(UsuarioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    UsuarioDL objUsuario = new UsuarioDL();
                    AccesoUsuarioDL objAccesoUsuario = new AccesoUsuarioDL();

                    objUsuario.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertaPorPerfil(UsuarioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    UsuarioDL objUsuario = new UsuarioDL();
                    AccesoUsuarioBE ObjAccesoBE = new AccesoUsuarioBE();
                    AccesoUsuarioDL objAccesoUsuario = new AccesoUsuarioDL();
                    Int32 intIdUser = 0;

                    intIdUser = objUsuario.Inserta(pItem);

                    ObjAccesoBE.IdUser = intIdUser;
                    ObjAccesoBE.IdPerfil = pItem.IdPerfil;
                    ObjAccesoBE.Usuario = pItem.Usuario;
                    ObjAccesoBE.Maquina = pItem.Maquina;
                    ObjAccesoBE.IdEmpresa = pItem.IdEmpresa;

                    objAccesoUsuario.InsertaPorPerfil(ObjAccesoBE);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizaEmpresa(UsuarioBE pItem)
        {
            try
            {
                    UsuarioDL objUsuario = new UsuarioDL();
                    objUsuario.ActualizaEmpresa(pItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizaPassword(UsuarioBE pItem)
        {
            try
            {
                UsuarioDL objUsuario = new UsuarioDL();
                objUsuario.ActualizaPassword(pItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Elimina(UsuarioBE pItem)
        {
            try
            {
                UsuarioDL usuario = new UsuarioDL();
                usuario.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaPorPerfil(UsuarioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AccesoUsuarioBE ObjAccesoBE = new AccesoUsuarioBE();
                    AccesoUsuarioDL objAccesoUsuario = new AccesoUsuarioDL();

                    ObjAccesoBE.IdUser = pItem.IdUser;
                    ObjAccesoBE.IdPerfil = pItem.IdPerfil;
                    ObjAccesoBE.Usuario = pItem.Usuario;
                    ObjAccesoBE.Maquina = pItem.Maquina;
                    ObjAccesoBE.IdEmpresa = pItem.IdEmpresa;

                    objAccesoUsuario.InsertaPorPerfil(ObjAccesoBE);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
