using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClienteDL
    {
        public ClienteDL() { }

        public Int32 Inserta(ClienteBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_Inserta");

            db.AddOutParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pApePaterno", DbType.String, pItem.ApePaterno);
            db.AddInParameter(dbCommand, "pApeMaterno", DbType.String, pItem.ApeMaterno);
            db.AddInParameter(dbCommand, "pNombres", DbType.String, pItem.Nombres);
            db.AddInParameter(dbCommand, "pTipoPersona", DbType.String, pItem.TipoPersona);
            db.AddInParameter(dbCommand, "pIdSexo", DbType.String, pItem.IdSexo);
            db.AddInParameter(dbCommand, "pRepresentante", DbType.String, pItem.Representante);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pIdTipoDireccion", DbType.Int32, pItem.IdTipoDireccion);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pNumDireccion", DbType.String, pItem.NumDireccion);
            db.AddInParameter(dbCommand, "pUrbanizacion", DbType.String, pItem.Urbanizacion);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pIdUbigeoDom", DbType.String, pItem.IdUbigeoDom);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pOtroTelefono", DbType.String, pItem.OtroTelefono);
            db.AddInParameter(dbCommand, "pTelefonoAdicional", DbType.String, pItem.TelefonoAdicional);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pEmailFE", DbType.String, pItem.EmailFE);
            db.AddInParameter(dbCommand, "pFechaNac", DbType.DateTime, pItem.FechaNac);
            db.AddInParameter(dbCommand, "pFechaAniv", DbType.DateTime, pItem.FechaAniv);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdClasificacionCliente", DbType.Int32, pItem.IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pIdCategoria", DbType.Int32, pItem.IdCategoria);
            db.AddInParameter(dbCommand, "pIdUbicacionEstrategica", DbType.Int32, pItem.IdUbicacionEstrategica);
            db.AddInParameter(dbCommand, "pIdTamanoLocal", DbType.Int32, pItem.IdTamanoLocal);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pIdTipoLocal", DbType.Int32, pItem.IdTipoLocal);
            db.AddInParameter(dbCommand, "pIdCondicion", DbType.Int32, pItem.IdCondicion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pIdDestino", DbType.Int32, pItem.IdDestino);
            db.AddInParameter(dbCommand, "pLineaUnica", DbType.Int32, pItem.LineaUnica);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pAgencia", DbType.String, pItem.Agencia);
            db.AddInParameter(dbCommand, "pFlagSuspendido", DbType.Boolean, pItem.FlagSuspendido);
            db.AddInParameter(dbCommand, "pIdMotivoSituacion", DbType.Int32, pItem.IdMotivoSituacion);
            db.AddInParameter(dbCommand, "pFlagAsesorExterno", DbType.Boolean, pItem.FlagAsesorExterno);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pFlagComercio", DbType.Boolean, pItem.FlagComercio);

            db.AddInParameter(dbCommand, "pProcede", DbType.Int32, pItem.Procede);
            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdCliente");

            return intIdCliente;
        }

        public void Actualiza(ClienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_Actualiza");

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pApePaterno", DbType.String, pItem.ApePaterno);
            db.AddInParameter(dbCommand, "pApeMaterno", DbType.String, pItem.ApeMaterno);
            db.AddInParameter(dbCommand, "pNombres", DbType.String, pItem.Nombres);
            db.AddInParameter(dbCommand, "pTipoPersona", DbType.String, pItem.TipoPersona);
            db.AddInParameter(dbCommand, "pIdSexo", DbType.String, pItem.IdSexo);
            db.AddInParameter(dbCommand, "pRepresentante", DbType.String, pItem.Representante);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pIdTipoDireccion", DbType.Int32, pItem.IdTipoDireccion);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pNumDireccion", DbType.String, pItem.NumDireccion);
            db.AddInParameter(dbCommand, "pUrbanizacion", DbType.String, pItem.Urbanizacion);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pIdUbigeoDom", DbType.String, pItem.IdUbigeoDom);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pOtroTelefono", DbType.String, pItem.OtroTelefono);
            db.AddInParameter(dbCommand, "pTelefonoAdicional", DbType.String, pItem.TelefonoAdicional);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pEmailFE", DbType.String, pItem.EmailFE);
            db.AddInParameter(dbCommand, "pFechaNac", DbType.DateTime, pItem.FechaNac);
            db.AddInParameter(dbCommand, "pFechaAniv", DbType.DateTime, pItem.FechaAniv);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdClasificacionCliente", DbType.Int32, pItem.IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pIdCategoria", DbType.Int32, pItem.IdCategoria);
            db.AddInParameter(dbCommand, "pIdUbicacionEstrategica", DbType.Int32, pItem.IdUbicacionEstrategica);
            db.AddInParameter(dbCommand, "pIdTamanoLocal", DbType.Int32, pItem.IdTamanoLocal);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pIdTipoLocal", DbType.Int32, pItem.IdTipoLocal);
            db.AddInParameter(dbCommand, "pIdCondicion", DbType.Int32, pItem.IdCondicion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pIdDestino", DbType.Int32, pItem.IdDestino);
            db.AddInParameter(dbCommand, "pLineaUnica", DbType.Int32, pItem.LineaUnica);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pAgencia", DbType.String, pItem.Agencia);
            db.AddInParameter(dbCommand, "pFlagSuspendido", DbType.Boolean, pItem.FlagSuspendido);
            db.AddInParameter(dbCommand, "pIdMotivoSituacion", DbType.Int32, pItem.IdMotivoSituacion);
            db.AddInParameter(dbCommand, "pFlagAsesorExterno", DbType.Boolean, pItem.FlagAsesorExterno);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pProcede", DbType.Int32, pItem.Procede);
            db.AddInParameter(dbCommand, "pFlagComercio", DbType.Boolean, pItem.FlagComercio);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ClienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_Elimina");

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaMayorista(ClienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_ActualizaMayorista");

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaMinorista(ClienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_ActualizaMinorista");

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdClasificacion", DbType.Int32, pItem.IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public ClienteBE Selecciona(int IdEmpresa, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteBE Cliente = null;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.ApePaterno = reader["ApePaterno"].ToString();
                Cliente.ApeMaterno = reader["ApeMaterno"].ToString();
                Cliente.Nombres = reader["Nombres"].ToString();
                Cliente.TipoPersona = reader["TipoPersona"].ToString();
                Cliente.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Cliente.Representante = reader["Representante"].ToString();
                Cliente.Contacto = reader["Contacto"].ToString();
                Cliente.IdTipoDireccion = Int32.Parse(reader["idTipoDireccion"].ToString());
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.Urbanizacion = reader["urbanizacion"].ToString();
                Cliente.Referencia = reader["Referencia"].ToString();
                Cliente.IdUbigeoDom = reader["idUbigeoDom"].ToString();
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Cliente.Telefono = reader["telefono"].ToString();
                Cliente.Celular = reader["celular"].ToString();
                Cliente.OtroTelefono = reader["otroTelefono"].ToString();
                Cliente.TelefonoAdicional = reader["TelefonoAdicional"].ToString();
                Cliente.Email = reader["email"].ToString();
                Cliente.EmailFE = reader["EmailFE"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Cliente.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                Cliente.IdTipoCliente = Int32.Parse(reader["idTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.IdCategoria = Int32.Parse(reader["idCategoria"].ToString());
                Cliente.DescCategoria = reader["DescCategoria"].ToString();
                Cliente.IdUbicacionEstrategica = Int32.Parse(reader["idUbicacionEstrategica"].ToString());
                Cliente.DescUbicacion = reader["DescUbicacion"].ToString();
                Cliente.IdTamanoLocal = Int32.Parse(reader["IdTamanoLocal"].ToString());
                Cliente.DescTamanoLocal = reader["DescTamanoLocal"].ToString();
                Cliente.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Cliente.DescVendedor = reader["DescVendedor"].ToString();
                Cliente.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                Cliente.DescRuta = reader["DescRuta"].ToString();
                Cliente.IdTipoLocal = Int32.Parse(reader["IdTipoLocal"].ToString());
                Cliente.DescTipoLocal = reader["DescTipoLocal"].ToString();
                Cliente.IdCondicion = Int32.Parse(reader["IdCondicion"].ToString());
                Cliente.DescCondicion = reader["DescCondicion"].ToString();
                Cliente.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cliente.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                Cliente.IdDestino = Int32.Parse(reader["IdDestino"].ToString());
                Cliente.LineaUnica = Int32.Parse(reader["LineaUnica"].ToString());
                Cliente.IdDestino = Int32.Parse(reader["IdDestino"].ToString());
                Cliente.Observacion = reader["Observacion"].ToString();
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FlagSuspendido = Boolean.Parse(reader["FlagSuspendido"].ToString());
                Cliente.IdMotivoSituacion = Int32.Parse(reader["IdMotivoSituacion"].ToString());
                Cliente.TotalVenta = Decimal.Parse(reader["TotalVenta"].ToString());
                Cliente.FechaRegistroTipoCliente = DateTime.Parse(reader["FechaRegistroTipoCliente"].ToString());
                Cliente.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                Cliente.FlagAsesorExterno = Boolean.Parse(reader["FlagAsesorExterno"].ToString());
                Cliente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cliente.Procede = Int32.Parse(reader["Procede"].ToString());
                Cliente.FlagComercio = Boolean.Parse(reader["FlagComercio"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cliente; 
        }

        public List<ClienteBE> SeleccionaLista(int IdEmpresa, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente = null;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.Representante = reader["Representante"].ToString();
                Cliente.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Cliente.Contacto = reader["Contacto"].ToString();
                Cliente.IdTipoDireccion = Int32.Parse(reader["idTipoDireccion"].ToString());
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.Urbanizacion = reader["urbanizacion"].ToString();
                Cliente.Referencia = reader["Referencia"].ToString();
                Cliente.IdUbigeoDom = reader["idUbigeoDom"].ToString();
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Cliente.Telefono = reader["telefono"].ToString();
                Cliente.Celular = reader["celular"].ToString();
                Cliente.OtroTelefono = reader["otroTelefono"].ToString();
                Cliente.TelefonoAdicional = reader["TelefonoAdicional"].ToString();
                Cliente.Email = reader["email"].ToString();
                Cliente.EmailFE = reader["EmailFE"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Cliente.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                Cliente.IdTipoCliente = Int32.Parse(reader["idTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.IdCategoria = Int32.Parse(reader["idCategoria"].ToString());
                Cliente.DescCategoria = reader["DescCategoria"].ToString();
                Cliente.IdUbicacionEstrategica = Int32.Parse(reader["idUbicacionEstrategica"].ToString());
                Cliente.DescUbicacion = reader["DescUbicacion"].ToString();
                Cliente.IdTamanoLocal = Int32.Parse(reader["IdTamanoLocal"].ToString());
                Cliente.DescTamanoLocal = reader["DescTamanoLocal"].ToString();
                Cliente.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Cliente.DescVendedor = reader["DescVendedor"].ToString();
                Cliente.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                Cliente.DescRuta = reader["DescRuta"].ToString();
                Cliente.Observacion = reader["Observacion"].ToString();
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FlagAsesorExterno = Boolean.Parse(reader["FlagAsesorExterno"].ToString());
                Cliente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cliente.FlagComercio = Boolean.Parse(reader["FlagComercio"].ToString());
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ClienteBE> ListaTodosActivo(int IdEmpresa, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.Representante = reader["Representante"].ToString();
                Cliente.Contacto = reader["Contacto"].ToString();
                Cliente.IdTipoDireccion = Int32.Parse(reader["idTipoDireccion"].ToString());
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.Urbanizacion = reader["urbanizacion"].ToString();
                Cliente.IdUbigeoDom = reader["idUbigeoDom"].ToString();
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Cliente.Telefono = reader["telefono"].ToString();
                Cliente.Celular = reader["celular"].ToString();
                Cliente.OtroTelefono = reader["otroTelefono"].ToString();
                Cliente.TelefonoAdicional = reader["TelefonoAdicional"].ToString();
                Cliente.Email = reader["email"].ToString();
                Cliente.EmailFE = reader["EmailFE"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Cliente.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                Cliente.IdTipoCliente = Int32.Parse(reader["idTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.IdCategoria = Int32.Parse(reader["idCategoria"].ToString());
                Cliente.DescCategoria = reader["DescCategoria"].ToString();
                Cliente.IdUbicacionEstrategica = Int32.Parse(reader["idUbicacionEstrategica"].ToString());
                Cliente.DescUbicacion = reader["DescUbicacion"].ToString();
                Cliente.IdTamanoLocal = Int32.Parse(reader["IdTamanoLocal"].ToString());
                Cliente.DescTamanoLocal = reader["DescTamanoLocal"].ToString();
                Cliente.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Cliente.DescVendedor = reader["DescVendedor"].ToString();
                Cliente.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                Cliente.DescRuta = reader["DescRuta"].ToString();
                Cliente.IdTipoLocal = Int32.Parse(reader["IdTipoLocal"].ToString());
                Cliente.DescTipoLocal = reader["DescTipoLocal"].ToString();
                Cliente.IdCondicion = Int32.Parse(reader["IdCondicion"].ToString());
                Cliente.DescCondicion = reader["DescCondicion"].ToString();
                Cliente.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cliente.DescCondicion = reader["DescCondicion"].ToString();
                Cliente.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                Cliente.IdDestino = Int32.Parse(reader["IdDestino"].ToString());
                Cliente.LineaUnica = Int32.Parse(reader["LineaUnica"].ToString());
                Cliente.Observacion = reader["Observacion"].ToString();
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cliente.FlagComercio = Boolean.Parse(reader["FlagComercio"].ToString());

                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ClienteBE> SeleccionaBusqueda(int IdEmpresa, int IdTipoCliente,string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaBus");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pTipoBusqueda", DbType.String, TipoBusqueda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Cliente.Telefono = reader["telefono"].ToString();
                Cliente.Celular = reader["celular"].ToString();
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ClienteBE> SeleccionaBusquedaClienteSolicitud(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaBusClienteSolicitud");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pTipoBusqueda", DbType.String, TipoBusqueda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Cliente.Telefono = reader["telefono"].ToString();
                Cliente.Celular = reader["celular"].ToString();
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ClienteBE> SeleccionaBusquedaComercio(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaBusComercio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pTipoBusqueda", DbType.String, TipoBusqueda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Cliente.Telefono = reader["telefono"].ToString();
                Cliente.Celular = reader["celular"].ToString();
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ClienteBE> SeleccionaBusquedaConAsociado(int IdEmpresa, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaBus_Asociado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdTipoCliente, string pFiltro, int TipoBusqueda)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pTipoBusqueda", DbType.Int32, TipoBusqueda);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public ClienteBE SeleccionaNumero(int IdEmpresa, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteBE Cliente = null;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.Representante = reader["Representante"].ToString();
                Cliente.Contacto = reader["Contacto"].ToString();
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Cliente.FlagAsesorExterno = Boolean.Parse(reader["FlagAsesorExterno"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cliente;
        }

        public ClienteBE SeleccionaNumeroAgenda(int IdEmpresa, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaNumeroAgenda");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteBE Cliente = null;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.Representante = reader["Representante"].ToString();
                Cliente.Contacto = reader["Contacto"].ToString();
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Cliente.FlagAsesorExterno = Boolean.Parse(reader["FlagAsesorExterno"].ToString());
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Cliente.IdUbigeoDom = reader["IdUbigeoDom"].ToString();
                Cliente.Celular = reader["Celular"].ToString();
                Cliente.Correo = reader["Correo"].ToString();
                Cliente.Referencia = reader["Referencia"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Cliente;
        }

        public ClienteBE SeleccionaNumeroComercio(int IdEmpresa, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaNumeroComercio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteBE Cliente = null;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.Representante = reader["Representante"].ToString();
                Cliente.Contacto = reader["Contacto"].ToString();
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Cliente.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cliente.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Cliente.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Cliente.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cliente.Agencia = reader["Agencia"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Cliente.FlagAsesorExterno = Boolean.Parse(reader["FlagAsesorExterno"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cliente;
        }

        public ClienteBE SeleccionaUsuarioNumero(int IdEmpresa, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaUsuarioNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteBE Cliente = null;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();

                Cliente.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Cliente.IdPerfil = Int32.Parse(reader["IdPerfil"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cliente;
        }

        public ClienteBE SeleccionaNumeroSunat(int IdEmpresa, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaNumeroSunat");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteBE Cliente = null;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.NumeroDocumento = reader["RUC"].ToString();
                Cliente.DescCliente = reader["RazonSocial"].ToString();
                Cliente.DescCategoria = reader["EstadoContribuyente"].ToString();
                Cliente.DescCondicion = reader["CondicionDomicilio"].ToString();
                Cliente.AbrevDomicilio = reader["TipoVia"].ToString();
                Cliente.Direccion = reader["Direccion"].ToString();
                Cliente.IdUbigeoDom = reader["Ubigeo"].ToString();
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Cliente;
        }


        public ClienteBE SeleccionaDescripcion(int IdEmpresa, string DescCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, DescCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteBE Cliente = null;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["descCliente"].ToString();
                Cliente.Representante = reader["Representante"].ToString();
                Cliente.Contacto = reader["Contacto"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Cliente;
        }

        public List<ClienteBE> ListaTelefonos(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_ListaTelefonos");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.Telefonos = reader["telefonos"].ToString();
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ClienteBE> ListaCelulares(int TipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_ListaCelulares");
            db.AddInParameter(dbCommand, "pTipoCliente", DbType.Int32, TipoCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.DescCliente = reader["DescCliente"].ToString();
                Cliente.Telefonos = reader["telefonos"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ClienteBE> ListaTodosActivoRuta(int IdRuta, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_ListaTodosActivoRuta");
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, IdRuta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                //Cliente.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                //Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["DescCliente"].ToString();
                Cliente.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                Cliente.DescRuta = reader["DescRuta"].ToString();
                Cliente.DescVendedor = reader["DescVendedor"].ToString();
                //Cliente.IdTipoDireccion = Int32.Parse(reader["idTipoDireccion"].ToString());
                Cliente.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Cliente.Direccion = reader["direccion"].ToString();
                Cliente.NumDireccion = reader["numDireccion"].ToString();
                Cliente.Urbanizacion = reader["urbanizacion"].ToString();
                Cliente.Referencia = reader["Referencia"].ToString();
                //Cliente.IdUbigeoDom = reader["idUbigeoDom"].ToString();
                //Cliente.Representante = reader["Representante"].ToString();
                Cliente.NomDpto = reader["NomDpto"].ToString();
                Cliente.NomProv = reader["NomProv"].ToString();
                Cliente.NomDist = reader["NomDist"].ToString();
                Cliente.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                Cliente.Contacto = reader["Contacto"].ToString();
                Cliente.Telefono = reader["telefono"].ToString();
                Cliente.Celular = reader["celular"].ToString();
                Cliente.OtroTelefono = reader["otroTelefono"].ToString();
                Cliente.TelefonoAdicional = reader["TelefonoAdicional"].ToString();
                Cliente.Email = reader["email"].ToString();
                //Cliente.EmailFE = reader["EmailFE"].ToString();
                Cliente.DescCategoria = reader["DescCategoria"].ToString();
                Cliente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cliente.FechaCompra = reader.IsDBNull(reader.GetOrdinal("FechaCompra")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompra"));
                Cliente.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                Cliente.IdTipoLocal = Int32.Parse(reader["IdTipoLocal"].ToString());
                Cliente.DescTipoLocal = reader["DescTipoLocal"].ToString();
                Cliente.IdCondicion = Int32.Parse(reader["IdCondicion"].ToString());
                Cliente.DescCondicion = reader["DescCondicion"].ToString();
                Cliente.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                Cliente.DescAgencia = reader["DescAgencia"].ToString();
                Cliente.IdDestino = Int32.Parse(reader["IdDestino"].ToString());
                Cliente.DescDestino = reader["DescDestino"].ToString();
                Cliente.Observacion = reader["Observacion"].ToString();
                Cliente.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                Cliente.NumeroDias = Int32.Parse(reader["NumeroDias"].ToString());
                Cliente.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cliente.DescSituacion = reader["DescSituacion"].ToString();

                Cliente.IdMotivoSituacion = Int32.Parse(reader["IdMotivoSituacion"].ToString());
                Cliente.DescMotivoSituacion = reader["DescMotivoSituacion"].ToString();

                Cliente.Ninguno = Decimal.Parse(reader["Ninguno"].ToString());
                Cliente.Textiles = Decimal.Parse(reader["Textiles"].ToString());
                Cliente.Religioso = Decimal.Parse(reader["Religioso"].ToString());
                Cliente.CocinaMenaje = Decimal.Parse(reader["CocinaMenaje"].ToString());
                Cliente.FloresArtificiales = Decimal.Parse(reader["FloresArtificiales"].ToString());
                Cliente.SalaTerraza = Decimal.Parse(reader["SalaTerraza"].ToString());
                Cliente.Oficina = Decimal.Parse(reader["Oficina"].ToString());
                Cliente.LineaInfantil = Decimal.Parse(reader["LineaInfantil"].ToString());
                Cliente.Carteras = Decimal.Parse(reader["Carteras"].ToString());
                Cliente.Accesorios = Decimal.Parse(reader["Accesorios"].ToString());
                Cliente.Navidad = Decimal.Parse(reader["Navidad"].ToString());
                Cliente.DormitorioBano = Decimal.Parse(reader["DormitorioBano"].ToString());
                Cliente.TotalLinea = Decimal.Parse(reader["TotalLinea"].ToString());
                Cliente.LineaUnica = Int32.Parse(reader["LineaUnica"].ToString());
                Cliente.DescLineaUnica = reader["DescLineaUnica"].ToString();
                //Cliente.TotalLinea = Decimal.Parse(reader["TotalLinea"].ToString());
                Cliente.TotalPreVenta = Decimal.Parse(reader["TotalPreVenta"].ToString());

                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }


        public List<ClienteBE> ListaAsesorExterno(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_ListaAsesorExterno");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteBE> Clientelist = new List<ClienteBE>();
            ClienteBE Cliente;
            while (reader.Read())
            {
                Cliente = new ClienteBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.DescCliente = reader["DescCliente"].ToString();
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }


        public void ActualizaPadron(ClienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cliente_ActualizaPadron");

            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pEstadoContribuyente", DbType.String, pItem.EstadoContribuyente);
            db.AddInParameter(dbCommand, "pCondicionDomicilio", DbType.String, pItem.CondicionDomicilio);
            db.ExecuteNonQuery(dbCommand);
        }


    }
}
