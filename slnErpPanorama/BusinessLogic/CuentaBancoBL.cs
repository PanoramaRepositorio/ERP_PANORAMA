using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CuentaBancoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<CuentaBancoBE> ListaTodosActivo(int IdBanco)
        {
            try
            {
                CuentaBancoDL CuentaBanco = new CuentaBancoDL();
                return CuentaBanco.ListaTodosActivo(IdBanco);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CuentaBancoBE> Lista(int IdBanco)
        {
            try
            {
                CuentaBancoDL CuentaBanco = new CuentaBancoDL();
                return CuentaBanco.Lista(IdBanco);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CuentaBancoBE Selecciona(int IdCuentaBanco)
        {
            try
            {
                CuentaBancoDL CuentaBanco = new CuentaBancoDL();
                CuentaBancoBE objEmp = CuentaBanco.Selecciona(IdCuentaBanco);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

       public void Inserta(CuentaBancoBE pItem)
        {
            try
            {
                CuentaBancoDL CuentaBanco = new CuentaBancoDL();
                CuentaBanco.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CuentaBancoBE pItem)
        {
            try
            {
                CuentaBancoDL CuentaBanco = new CuentaBancoDL();
                CuentaBanco.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CuentaBancoBE pItem)
        {
            try
            {
                CuentaBancoDL CuentaBanco = new CuentaBancoDL();
                CuentaBanco.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CuentaBancoBE> ListaTodosActivoProveedor(int IdProveedor)
        {
            try
            {
                CuentaBancoDL CuentasBancos = new CuentaBancoDL();
                return CuentasBancos.ListaTodosActivoProveedor(IdProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaCuentaBancoProveedor(List<CuentaBancoBE> pListaItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaBancoDL CuentaBancoProvee = new CuentaBancoDL();

                    foreach (CuentaBancoBE item in pListaItem)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            CuentaBancoProvee.InsertaCuentaBancoProveedor(item);
                        }
                        else //if (item.TipoOper == Convert.ToInt32(Operacion.Modificar))
                        {
                            CuentaBancoProvee.ActualizaCuentaBancoProveedor(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaCuentaBancoProvee(CuentaBancoBE pItem)
        {
            try
            {
                CuentaBancoDL CuentaBancoProvee = new CuentaBancoDL();
                CuentaBancoProvee.Elimina_CuentaBancoProvee(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CuentaBancoBE> ListaTodosCuentaBancosProveedor(int IdProveedor, int IdMoneda)
        {
            try
            {
                CuentaBancoDL CuentasBancos = new CuentaBancoDL();
                return CuentasBancos.ListaTodosCuentaBancoProveedor(IdProveedor, IdMoneda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CuentaBancoBE Selecciona_CuentaBancoProveedor(int IdCuentaBancoProveedor)
        {
            try
            {
                CuentaBancoDL CuentaBanco = new CuentaBancoDL();
                CuentaBancoBE objEmp = CuentaBanco.Selecciona_CuentaBancoProveedor(IdCuentaBancoProveedor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}

