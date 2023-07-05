using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PerfilBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PerfilBE> ListaTodosActivo()
        {
            try
            {
                PerfilDL perfil = new PerfilDL();
                return perfil.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public PerfilBE Selecciona(int idPerfil)
        {
            try
            {
                PerfilDL perfil = new PerfilDL();
                return perfil.Selecciona(idPerfil);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PerfilBE pItem, List<AccesoBE> pListaAcceso)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PerfilDL objPerfil = new PerfilDL();
                    AccesoDL objAcceso = new AccesoDL();
                    Int32 intIdPerfil = 0;

                    intIdPerfil = objPerfil.Inserta(pItem);
                    foreach (AccesoBE item in pListaAcceso)
                    {
                        if (item.TipOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdPerfil = intIdPerfil;
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAcceso.Inserta(item);
                        }

                        if (item.TipOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAcceso.Actualiza(item);
                        }

                        if (item.TipOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAcceso.Elimina(item);
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


        public void Actualiza(PerfilBE pItem, List<AccesoBE> pListaAcceso)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PerfilDL objPerfil = new PerfilDL();
                    AccesoDL objAcceso = new AccesoDL();

                    objPerfil.Actualiza(pItem);
                    foreach (AccesoBE item in pListaAcceso)
                    {

                        //item.Usuario = pItem.Usuario;
                        //item.Maquina = pItem.Maquina;
                        //item.IdEmpresa = pItem.IdEmpresa;
                        //objAcceso.Elimina(item);

                        //item.Usuario = pItem.Usuario;
                        //item.Maquina = pItem.Maquina;
                        //item.IdEmpresa = pItem.IdEmpresa;
                        //item.IdPerfil = pItem.IdPerfil;
                        //objAcceso.Inserta(item);




                        if (item.TipOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            item.IdPerfil = pItem.IdPerfil;
                            objAcceso.Inserta(item);
                        }

                        if (item.TipOper == Convert.ToInt32(Operacion.Modificar)) //Modificar
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAcceso.Actualiza(item);
                        }

                        if (item.TipOper == Convert.ToInt32(Operacion.Eliminar)) //Eliminar
                        {
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            item.IdEmpresa = pItem.IdEmpresa;
                            objAcceso.Elimina(item);
                        }

                    }

                    //Actualizar Permisos de Usuarios
                    //................................. Add 03/06/2015
                    PerfilBE objE_Perfil = new PerfilBE();
                    objE_Perfil.IdPerfil = pItem.IdPerfil;
                    objE_Perfil.DescPerfil = pItem.DescPerfil;
                    objE_Perfil.FlagEstado = pItem.FlagEstado;
                    objE_Perfil.Usuario = pItem.Usuario;
                    objE_Perfil.Maquina = pItem.Maquina;
                    objE_Perfil.IdEmpresa = pItem.IdEmpresa;

                    objPerfil.ActualizaUsuario(objE_Perfil);


                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }

        }

        public void Elimina(PerfilBE pItem)
        {
            try
            {
                PerfilDL perfil = new PerfilDL();
                perfil.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
