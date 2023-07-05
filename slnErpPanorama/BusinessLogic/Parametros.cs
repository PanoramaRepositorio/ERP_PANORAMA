using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpPanorama.BusinessLogic
{
    public class Parametros
    {
        public static string Key = "YUXTAPUESTO/ARIN";
        public static string IV = "kabosilva0123456";

        public static DateTime dtFechaHoraServidor = DateTime.Today;

        public static string sIdDepartamento = "15"; //LIMA
        public static string sIdProvincia = "01"; //LIMA
        public static string sIdDistrito = "01"; //LIMA

        public static int intPerfilId = 0;
        public static int intMenuId = 23;
        public static string strNomPerfil = "";
        public static int intUsuarioId = 0;
        public static int intPeriodo = DateTime.Today.Year;
        public static string strUsuarioLogin = "";
        public static string strUsuarioNombres = "";
        public static string strUsuarioApellidos = "";
        public static int intEmpresaId = 13;
        public static string strEmpresaNombre = "";
        public static int intTiendaId = 1;

        public static int intIdPanoramaDistribuidores = 13;

        public static decimal dmlIGV = 18;
        public static double dblIGV = 1.18;

        public static int intSoles = 5;
        public static int intDolares = 6;

        public static int intNinguno = 0;

        //Tipo de cambio
        public static double dmlTCMayorista = 4.01;
        public static double dmlTCMayoristaInterna = 4.01;
        public static double dmlTCMinorista = 3.10;
        public static double dmlTCMinoristaNacional = 3.10;

        //Almacenes
        public static int intAlmCentral = 1;
        public static int intAlmAnaqueles = 14;
        public static int intAlmTiendaUcayali = 2;
        public static int intAlmBultos = 3;
        public static int intAlmTaller = 4;
        public static int intAlmTiendaAndahuaylas = 5;
        public static int intAlmAnaquelesKonceptos = 7;
        public static int intAlmOfertaRemate = 12;
        public static int intAlmPrescott = 15;
        public static int intAlmAviacion = 17;
        public static int intAlmMegaPlaza = 18;
       
        //Situacion Bultos
        public static int intBULGenerado = 74;
        public static int intBULRecibido = 75;
        public static int intBULTransferido = 76;

        //Tipo de Documento
        public static int intTipoDocBoletaVenta = 9;
        public static int intTipoDocNotaCreditoElectronica = 11;
        public static int intTipoDocNotaDebitoElectronica = 110;
        public static int intTipoDocBoletaElectronica = 12;
        public static int intTipoDocFacturaElectronica = 13;
        public static int intTipoDocFacturaCompra = 24;
        public static int intTipoDocFacturaVenta = 26;
        public static int intTipoDocNotaIngreso = 27;
        public static int intTipoDocGuiaRemision = 28;
        public static int intTipoDocNotaSalida = 29;
        public static int intTipoDocNotaCredito = 36;
        public static int intTipoDocReciboPago = 49;
        public static int intTipoDocSaldoFavorDiseño = 75;
        public static int intTipoDocPedidoVenta = 87;
        public static int intTipoDocTransferencia = 88;
        public static int intTipoDocSolicitudProducto = 89;
        public static int intTipoDocTicketBoleta = 90;
        public static int intTipoDocTicketFactura = 91;
        public static int intTipoDocAperturaCaja = 92;
        public static int intTipoDocRetiroCaja = 93;
        public static int intTipoDocProforma = 94;
        public static int intTipoDocCambiosDevoluciones = 95;
        public static int intTipoDocBoletaVentaTraslado = 96;
        public static int intTipoDocFacturaVentaTraslado = 97;
        public static int intTipoDocCotizacionCredito = 98;
        public static int intTipoDocFacturaCredito = 99;
        public static int intTipoDocProyectoServicio = 103;
        public static int intTipoDocReparacion = 57;
        public static int intTipoDocContratoFabricacion = 79;



        //Cargos
        public static int intGerente = 1;
        public static int intDirector = 2;
        public static int intMecanico = 3;
        public static int intAdministrador = 4;
        public static int intAsesorServicio = 5;
        public static int intGerentePOstVenta = 6;

        //Modulo
        public static int intPostVenta = 1;
        public static int intAlmacen = 2;
        public static int intLogistica = 3;
        public static int intVentas = 4;

        //Tabla
        public static int intTblRegimenTributario = 1;
        public static int intTblMoneda = 2;
        public static int intTblCargos = 3;
        public static int intTblSexo = 4;
        public static int intTblEstadoCivil = 5;
        public static int intTblFormaPago = 10;
        public static int intTblTipoMovimientoAlmacen = 11;
        public static int intTblMotivoAlmancen = 12;

        //Motivo Movimiento Almacen
        public static int intMovTranferenciaDirecta = 79;
        public static int intMovTransferencia = 80;
        public static int intMovDevolucion = 81;
        public static int intMovSaldoInicial = 82;
        public static int intMovVentas = 83;
        public static int intMovPrestamos = 84;
        public static int intMovOtros = 85;
        public static int intMovMermas = 115;

        //Tipo Movimiento Almacen
        public static int intTipMovIngreso = 77;
        public static int intTipMovSalida = 78;

        //Tipo Cliente
        public static int intTipClienteMinorista = 86;
        public static int intTipClienteMayorista = 87;

        public static int intTipoDocumentoDNI = 55;
        public static int intTipoDocumentoRUC = 56;

        public static int intTipoDireccionAV = 57;

        //Razon Social
        public static int intPanoraramaDistribuidores = 13;
        public static int intCoronaImportadores = 3;

        //Tienda
        public static int intTiendaUcayali = 1;
        public static int intTiendaAndahuaylas = 2;
        public static int intTiendaKonceptos = 3;
        public static int intTiendaPrescott = 4;
        public static int intTiendaAviacion = 5;
        public static int intTiendaMegaplaza = 6;

        //Forma Pago
        public static int intContado = 61;
        public static int intCredito = 62;
        public static int intConsignacion = 65;
        public static int intSeparacion = 67;
        public static int intCopagan = 69;
        public static int intContraEntrega = 68;
        public static int intCredito30 = 70;
        public static int intCredito45 = 72;
        public static int intCredito60 = 71;
        public static int intObsequio = 130;
        public static int intASAF = 144;

        //Condicion Pago
        public static int intEfectivo = 98;

        //Situacion Documento Venta
        public static int intDVGenerado = 102;
        public static int intDVCancelado = 103;
        public static int intDVAnulado = 104;

        //Datos Cliente General
        public static int intIdClienteGeneral = 2218;
        public static string strNumeroCliente = "00000000";
        public static string strDescCliente = "<CLIENTE GENERAL>";
        public static string strDireccion = "LIMA";

        //Situacion Pedido Venta
        public static int intPVGenerado = 110;
        public static int intFacturado = 111;
        public static int intPVAprobado = 112;
        public static int intPVDespachado = 113;
        public static int intPVAnulado = 114;
        public static int intPVEnProceso = 145;

        //Situacion Proforma Venta
        public static int intPFGenerado = 116;
        public static int intPFAprobado = 117;
        public static int intPFAnulado = 118;

        //CLASIFICACION CLIENTE FINAL
        public static int intClasico = 124;
        public static int intPlatinum = 125;
        public static int intGold = 126;
        public static int intPublicitario = 129;
        public static int intBlack = 137;

        //Tipo Motivo Venta
        public static int intMotivoVenta = 170;
        public static int intMotivoVentaNavidad = 171;


        //Tipo de Producto
        public static int intProductoAlmacenable = 268;
        public static int intProductoServicio = 269;

        //Datos Producto Reajuste
        public static int intIdProductoReajuste = 44654;
        public static string strCodigoProveedorReajuste = "REAJUSTE";
        public static string strNombreProductoReajuste = "INGRESO DE CODIGO";

        //Parametros Situacion PSE
        public static int intSitCorrectoPSE = 335;
        public static int intSitAnuladoPSE = 336;

        public static int intIdMarcaKira = 153;


    }
}
