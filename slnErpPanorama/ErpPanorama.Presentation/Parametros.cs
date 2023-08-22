using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation
{
    public class Parametros
    {
        public static List<AccesoUsuarioBE> pListaPermisoAcceso = new List<AccesoUsuarioBE>();
        public static List<ProveedorBE> pListaProveedores = new List<ProveedorBE>();
        public static List<TablaElementoBE> pListaFormaPago = new List<TablaElementoBE>();
        public static List<TablaElementoBE> pListaContenedor = new List<TablaElementoBE>();
        public static List<UnidadMedidaBE> pListaUnidadMedida = new List<UnidadMedidaBE>();
        public static List<PersonaBE> pListaPersonal = new List<PersonaBE>();
        public static List<FAreasBE> pListaAreas = new List<FAreasBE>();
        public static List<DescuentoClienteFinalBE> pListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();

        public static string Key = "YUXTAPUESTO/ARIN";
        public static string IV = "kabosilva0123456";

        public static DateTime dtFechaHoraServidor = DateTime.Today;
        public static string strVersion = "11.8.39"; //LIMA
        public static string strDBUse = "BD_ERPPANORAMA";
        public static string strDB = "";
        public static string CurrentCulture = "";
        public static string CurrentCultureERP = "es-PE";

        public static string sIdDepartamento = "15"; //LIMA
        public static string sIdProvincia = "01"; //LIMA
        public static string sIdDistrito = "01"; //LIMA

        public static int intPerfilId = 0;
        public static int intMenuId = 23;

        public static string strNomPerfil = "";
        public static int intUsuarioId = 0;
        public static int intPeriodo = DateTime.Today.Year;
        public static int intMes = DateTime.Today.Month;
        public static string strUsuarioLogin = "";
        public static string strUsuarioNombres = "";
        public static string strUsuarioApellidos = "";
        public static int intEmpresaId = 1;
        public static int intPersonaId = 1;
        public static int intTiendaId = 1;
        public static string strDescTienda = "";
        public static string strEmpresaNombre = "";
        public static string strEmpresaRuc = "";
        public static int intCajaId = 0;
        public static string strDescCaja = "<No Asignada>";

        public static int intTblMotivoCheque = 100;
        public static int intChequeVigente = 640;
        public static int intChequeCobrado = 641;
        public static int intChequeAnulado = 642;

        public static int intIdPanoramaDistribuidores = 13;

        public static double dblIGV = 1.18;
        public static decimal dmlIGV = 18;

        // Tipo de Gestión
        public static int intTGestionIngreso = 425;
        public static int intTGestionEgreso = 426;

        //Tipo de cambio
        public static double dmlTCMayorista = 4.01;
        public static double dmlTCMayoristaInterna = 4.01;
        public static double dmlTCMinorista = 3.10;
        public static double dmlTCMinoristaNacional = 3.10;

        //cambiar
        public static int intSoles = 5;
        public static int intDolares = 6;

        public static int intOperacionIngreso = 565;
        public static int intOperacionEgreso = 566;

        public static int intNinguno = 0;

        public static int intAlmTienda = 0;

        public static int intHERechazado = 478;
        public static int intHEAprobado = 477;
        public static int intHEGenerado = 476;



        //Almacenes Ucayali
        public static int intAlmCentralUcayali = 1;
        public static int intAlmTiendaUcayali = 2;
        public static int intAlmBultos = 3;
        public static int intAlmOutlet = 12;
        public static int intAlmAnaqueles = 14;
        public static int intAlmTiendaPrescott = 15;
        public static int intAlmReparacion = 4;
        public static int intAlmTiendaAviacion = 17;
        public static int intAlmTiendaMegaplaza = 18;
        public static int intAlmTiendaAviacion2 = 23;

        //Almacen Tienda Andahuaylas
        public static int intAlmTiendaAndahuaylas = 5;

        //Almacen Tienda MegaPlaza
        public static int intAlmKonceptos = 7;

        //Almacen Tienda San Miguel
        public static int intAlmTiendaSanMiguel = 24;

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
        public static int intTipoDocGuiaElectronica = 10;

        public static int intTipoDocFacturaCompra = 24;
        public static int intTipoDocFacturaVenta = 26;
        public static int intTipoDocNotaIngreso = 27;
        public static int intTipoDocGuiaRemision = 28;
        public static int intTipoDocNotaSalida = 29;
        public static int intTipoDocNotaCredito = 36;
        public static int intTipoDocReciboPago = 49;
        public static int intTipoDocRecibPorHonorario = 51;
        public static int intTipoDocPrestamoBancario = 74;
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
        public static int intTipoDocTicketAgenteBanco = 100;
        public static int intTipoDocCambios = 101;
        public static int intTipoDocProyectoServicio = 103;
        public static int intTipoDocReparacion = 57;
        public static int intTipoDocValeDescuento = 17;
        public static int intTipoDocContratoFabricacion = 79;
        public static int intTipoDocPrestamo = 73;
        public static int intTipoDocReciboEgreso = 60;
        public static int intTipoDocReciboDescuentoPlanilla = 104;
        public static int intTipoDocPagoBancoCuenta = 63;
        public static int intTipoDocSolicitudCompra = 68;
        public static int intTipoDocIngresoCaja = 105;
        public static int intTipoDocFacturaCompraInsumo = 106;
        public static int intTipoDocNovioRegalo = 107;


        //Cargos
        public static int intVendedor = 14;
        public static int intCajero = 15;
        public static int intGestorCartera = 37;
        public static int intSupervisoraVentaPiso = 51;
        public static int intSupervisoraVentaPisoDiseno = 38;
        public static int intDisenadorInteriorMaster = 120;
        public static int intDisenadorInteriorSenior = 469;
        public static int intDisenadorInteriorJunior = 467;

        public static int intAsesorVentaPisoJunior = 35;
        public static int intAsesorVentaPisoSenior = 44;
        public static int intAsesorVentaPisoMaster = 225;


        //Modulo

        public static int intModLogistica = 1;
        public static int intModVentas = 2;
        public static int intModVentasReferencia = 3;
        public static int intModVentasSunat = 6;
        public static int intModVentasRER = 7;

        //Tabla
        public static int intTblRegimenTributario = 1;
        public static int intTblMoneda = 2;
        public static int intTblOperacionCaja = 94;
        public static int intTblCargos = 3;
        public static int intTblSexo = 4;
        public static int intTblEstadoCivil = 5;
        public static int intTblTipoDocCliente = 8;
        public static int intTblTipoDireccion = 9;
        public static int intTblCausal = 97;
        public static int intTblNotaDebito = 99;

        public static int intTblFormaPago = 10;

        public static int intTblContenedor = 85;

        public static int intTblTipoMovimientoAlmacen = 11;
        public static int intTblMotivoAlmancen = 12;
        public static int intTblTipoCliente = 13;
        public static int intTblCategoria = 14;
        public static int intTblUbicacionEstrategica = 15;
        public static int intTblTipoFormato = 16;
        public static int intTblCondicionPago = 17;
        public static int intTblClasificacionCliente = 19;
        public static int intTblSituacionPedidoVenta = 20;
        public static int intTblSituacionProformaVenta = 21;
        public static int intTblTipoPrecio = 23;
        public static int intTblClasificacionClienteFinal = 24;
        public static int intTblCambioDevolucion = 25;
        public static int intTblMotivoDevolucion = 26;
        public static int intTblSituacionAlmacen = 27;
        public static int intTblMotivoVenta = 30;
        public static int intTblTipoVenta = 31;
        public static int intTblTamanoLocal = 32;
        public static int intTblPrioridadDespacho = 33;
        public static int intTblDestinoDespacho = 34;
        public static int intTblPagoFleteDespacho = 35;
        public static int intTblParentesco = 40;
        public static int intTblNivelEstudio = 41;
        public static int intTblTipoContrato = 42;
        public static int intTblTipoTrabajador = 43;
        public static int intTblTipoRenta = 44;
        public static int intTblClasificacionTrabajador = 45;
        public static int intTblTipoPieza = 46;
        public static int intTblTrackingCliente = 47;
        public static int intTblTipoInmueble = 48;
        public static int intTblSituacionVacaciones = 49;
        public static int intTblTipoLocal = 50;
        public static int intTblCondicionCliente = 51;
        public static int intTblSituacionCliente = 52;
        public static int intTblTipoProducto = 53;
        public static int intTblTicketPrioridad = 38;
        public static int intTblTicketSituacion = 39;
        public static int intTblMotivoAnulacioDocumento = 54;
        public static int intTblTipoAplicacionNotaCredito = 55;
        public static int intTblMotivoSituacionCliente = 56;
        public static int intTblSituacionPago = 57;
        public static int intTblTipoCuentaBanco = 58;
        public static int intTblSituacionProyectoServicio = 59;
        public static int intTblSubTipoProducto = 60;
        public static int intTblTurno = 61;
        public static int intTblTipoAnuncio = 62;
        public static int intTblTipoPrestamo = 63;
        public static int intTblSituacionGiftCard = 64;
        public static int intTblMotivoNCSunat = 66;
        public static int intTblSituacionDocContable = 67;
        public static int intTblTamanoHoja = 68;
        public static int intTblFacturaCompraTipoGasto = 69;
        public static int intTblTipoPromocion = 70;
        public static int intTblTipoGestion = 73;
        public static int intTblLocal = 81;
        public static int intTipoLetra = 98;

        //Clasificación ClienteCredito
        public static int intTopMejor = 105;
        public static int intBueno = 106;
        public static int intRegular = 107;
        public static int intRiesgo = 108;
        public static int intMoroso = 109;

        //Motivo Movimiento Almacen
        public static int intMovTranferenciaDirecta = 79;
        public static int intMovTransferenciaAndahuaylas = 80;
        public static int intMovSaldoInicial = 82;
        public static int intMovTransferenciaUcayali = 83;
        public static int intMovMuestrasUcayali = 84;
        public static int intMovAjusteInventario = 85;
        public static int intMovMermas = 115;
        public static int intMovReparacionTaller = 119;

        public static int intMovMuestrasAndahuaylas = 132;
        public static int intAutoservicioUcayali = 133;
        public static int intMovAutoservicioAndahuaylas = 134;

        public static int intMovDevolucion = 131;
        public static int intMovTransferencia = 160;
        public static int intMovFaltanteOrigen = 127;

        //Tipo Motivo Venta
        public static int intMotivoVenta = 170;
        public static int intMotivoVentaNavidad = 171;
        public static int intMotivoVentaReligioso = 299;

        //Tipo Movimiento Almacen
        public static int intTipMovIngreso = 77;
        public static int intTipMovSalida = 78;

        //Tipo Cliente
        public static int intTipClienteFinal = 86;
        public static int intTipClienteMayorista = 87;

        public static int intTipoDocumentoCEX = 54;
        public static int intTipoDocumentoDNI = 55;
        public static int intTipoDocumentoRUC = 56;

        public static int intTipoDireccionAV = 57;


        //Razon Social
        public static int intPanoraramaDistribuidores = 13;
        public static int intCoronaImportadores = 3;
        public static int intTapiaTarrilloEleazar = 23;
        public static int intHuamanBramonTeodoraAmalia = 8;
        public static int intTapiaCalderonOlgaLidia = 18;
        public static int intTapiaHuamanRoxana = 20;
        public static int intDecoratex = 27;

        //Tienda
        public static int intTiendaUcayali = 1;
        public static int intTiendaAndahuaylas = 2;
        public static int intTiendaKonceptos = 3;
        public static int intTiendaPrescott = 4;
        public static int intTiendaAviacion = 5;
        public static int intTiendaMegaplaza = 6;
        public static int intTiendaAviacion2 = 11;
        public static int intTiendaSanMiguel = 19;

        //Forma Pago
        public static int intContado = 61;
        public static int intCredito = 62;
        public static int intConsignacion = 65;
        public static int intSeparacion = 67;
        public static int intContraEntrega = 68;
        public static int intCopagan = 69;
        public static int intObsequio = 130;
        public static int intASAF = 144;


        //Condicion Pago
        public static int intEfectivo = 98;
        public static int intVisa = 99;
        public static int intMasterCard = 100;
        public static int intVisaPuntosVida = 192;
        public static int intMasterCardPuntosVida = 193;
        public static int intCheque = 193;
        public static int intCupon = 298;


        //Situacion Documento Venta
        public static int intDVGenerado = 102;
        public static int intDVCancelado = 103;
        public static int intDVAnulado = 104;

        //Causal NS y SP
        public static int intAbastecimientoStock = 618;
        public static int intDeterioroProducto = 619;
        public static int intFaltanteFisico = 615;
        public static int intPedidoVenta = 616;
        public static int intSobranteFisico = 617;
        public static int intSobreStock = 620;


        //Datos Cliente General
        public static int intIdClienteGeneral = 2218;
        public static string strNumeroCliente = "00000000";
        public static string strDescCliente = "<CLIENTE GENERAL>";
        public static string strDireccion = "LIMA";
        //Cliente Super Especial...
        public static int intIdClienteLockFLoresFannyIrene = 2756;

        //Datos Producto Reajuste
        public static int intIdProductoReajuste = 44654;
        public static string strCodigoProveedorReajuste = "REAJUSTE";
        public static string strNombreProductoReajuste = "INGRESO DE CODIGO";

        //Situacion Pedido Venta
        public static int intPVGenerado = 110;
        public static int intFacturado = 111;
        public static int intPVAprobado = 112;
        public static int intPVDespachado = 113;
        public static int intPVAnulado = 114;
        public static int intPendiente = 410;
        public static int intCancelado = 522;
        public static int intReprogramado = 556;
        public static int intProgramado = 557;
        public static int intVisitado = 558;

        //Situacion Proforma Venta
        public static int intPFGenerado = 116;
        public static int intPFAprobado = 117;
        public static int intPFAnulado = 118;

        //Direccion Facturacion
        public static string strDireccionUcayali = "JR. UCAYALI 425 - LIMA-LIMA-LIMA";
        public static string strDireccionUcayali2 = "JR. UCAYALI 431 - LIMA-LIMA-LIMA";
        public static string strDireccionUcayali3 = "JR. UCAYALI 435 - LIMA-LIMA-LIMA";
        public static string strDireccionAndahuaylas = "JR. ANDAHUAYLAS NRO 787 - LIMA-LIMA-LIMA";
        public static string strDireccionMegaplaza = "AV.ALFREDO MENDIOLA Nº3698 INT.L515-L516-INDEPENDENCIA-LIMA-LIMA";
        public static string strDireccionPrescott = "GMO PRESCOT N° 329-LIMA-LIMA-SAN ISIDRO";
        public static string strDireccionAviacion = "AV. AVIACION 3441 - URB. LAS CAMELIAS - SAN BORJA";
        public static string strDireccionAviacion2 = "AV. AVIACION 2630 - URB. SAN BORJA NORTE - SAN BORJA";
        public static string strDireccionSanMiguel = "AV. GENERAL JOSÉ DE LA MAR NRO 2278 URB. PANDO SEXTA ETAPA - SAN MIGUEL";


        public static string strDireccionCoronaImportadores = "JR. UCAYALI 431 - LIMA-LIMA-LIMA";

        // CAJA
        public static int intCajaToldo1 = 4;
        public static int intCajaToldo2 = 7;
        public static int intCaja7 = 9;

        //TIPO DE PRECIO
        public static int intTipoPrecioAB = 122;
        public static int intTipoPrecioCD = 123;

        //CLASIFICACION CLIENTE FINAL
        public static int intClasico = 124;
        public static int intPlatinum = 125;
        public static int intGold = 126;
        public static int intPublicitario = 129;
        public static int intBlack = 137;
        public static int intClubDesign = 313;

        //TIPO DE CAMBIO
        public static int intTCCambio = 135;
        public static int intTCDevolucion = 136;

        //Situacion Almacén Pedido
        public static int intRecepcionDocumento = 146;
        public static int intEnPreparacion = 147;
        public static int intRecibidoPedido = 148;
        public static int intEnChequeo = 149;
        public static int intEnEmbalaje = 150;
        public static int intEnAlmacenDespacho = 151;
        public static int intSeparado = 152;
        public static int intSitNinguno = 153;
        public static int intEnAlmacenPT = 161;

        //Familia Producto
        public static int intFamiliaRegular = 1;
        public static int intFamiliaNavidad = 2;
        public static int intFamiliaReligioso = 4;

        //Linea Producto
        public static int intLineaNavidad = 10;
        public static int intLineaReligioso = 2;

        //Marca Producto
        public static int intIdMarcaKira = 153;

        //Regimen Tributario
        public static int intRegimenTributarioRER = 1;
        public static int intRegimenTributarioRUS = 4;
        public static decimal dmlTopeEmpresaDiarioRUS = 3000;

        //Prioridad Despacho
        public static int intPDUrgente = 176;
        public static decimal intPDNormal = 177;

        //Destino Despacho
        public static int intDDAgencia = 178;
        public static decimal intDDDOMICILIO = 179;

        //Pago Flete Despacho
        public static int intPFDPagina = 180;
        public static decimal intPFDCliente = 181;

        //Situacion Tipo Venta
        public static int intPorAsesoria = 167;
        public static int intPorAsesoriaExterna = 251;
        public static int intPorMercadoPago = 414;
        public static int intPorCorreo = 168;
        public static int intPorInternet = 169;
        public static int intPorVisitaCampo = 279;

        //Parametro 
        public static string strDescuentoClienteFechaCompra = "DescuentoClienteFechaCompra";
        public static string strOnp = "ONP";

        //Parametros Planilla
        public static int intHorasOrdinarias = 8;
        public static double dblHorasExtrasDiarias = 1.15;
        public static double dblPorAporteSeguro = 0.09;
        public static decimal dmlRemuneracionVital = 750;

        //Parametros Tracking Vendedor Mayorista
        public static int intSITPendiente = 223;
        public static int intSITCerrado = 224;

        //Parametros Situacion Vacaciones
        public static int intSITVacacionesPendiente = 253;
        public static int intSITVacacionesCurso = 254;
        public static int intSITVVacacionesTomadas = 255;

        //Parametros Situacion Cliente
        public static int intSITClienteActivo = 263;
        public static int intSITClienteInactivo = 264;
        public static int intSITClienteInactivoCerroTienda = 282;

        //Parametros Situacion Pago
        public static int intSITPagoPendiente = 283;
        public static int intSITPagoCancelado = 284;

        //Parametros Codigo Delivery
        public static int intIdProductoDelivery = 44651;

        //Parametros Codigo Reparación
        public static int intIdProductoReparacion = 40538;


        //Tipo de Producto
        public static int intProductoAlmacenable = 268;
        public static int intProductoServicio = 269;

        //Parametros Descuento x Encuesta
        public static decimal dmlDescuentoEncuesta = 10;


        //Parametros Descuento x Cliente Mayorista
        //public static decimal dmlDescuentoMayoristaExtra = Convert.ToDecimal("10");//ANTES 8.5
        public static decimal dmlDescuentoMayoristaExtra = Convert.ToDecimal("8.5");//ANTES 10
        public static decimal dmlDescuentoMayoristaExtraReligioso = Convert.ToDecimal("10"); //add 07/02/2020


        //Parametros Descuento x Venta de Preventa
        public static decimal dmlDescuentoPreventaVenta = Convert.ToDecimal("0.00");

        //Parametros Comisión Club Design
        public static decimal dmlClubDesign = 0;

        //Parametros Stock Negativo
        public static bool bStockNegativo = true;
        public static bool bStockNegativoPreventa = true;

        //Parametros Parametro
        public static bool bConsultaReniec = false;
        public static bool bConsultaSunat = false;
        public static bool bInventarioCodigoUnico = true; //change by false
        public static decimal dmlTamanioImagen = 50;
        public static bool bValidarStockDetallePedido = false;
        public static bool bValidarPINUsuario = false;
        public static bool bValidarFechaServidor = false;
        public static bool bBusquedaTimer = true; //Buscar con timer
        public static bool bAperturaPedidoUnico = true; //Abrir pedido una sola Vez
        public static bool bImpresionPedidoDirecto = false;
        public static bool bImpresionSPDirecto = false;

        public static bool bOnlineBoletaElectronica = false;
        public static bool bOnlineFacturaElectronica = false;



        //Perfil
        public static int intPerAdministrador = 1;
        public static int intPerAdministradorTienda = 14;
        public static int intPerJefeAlmacen = 18;
        public static int intPerCoordinadorAlmacen = 60;
        public static int intPerAsesorVentaPiso = 4;
        public static int intPerAsesorDiseñoInterior = 10;
        public static int intPerCoordinadorDespacho = 16;
        public static int intPerAsistenteAlmacen = 20;
        public static int intPerSupervisorAlmacen = 19;
        public static int intPerAsistenteCompras = 28;
        public static int intPerAsistenteMarketing = 29;
        public static int intPerCajeroCentral = 32;
        public static int intPerSupervisorVentasPiso = 14;
        public static int intPerCajeroSucursal = 15;
        public static int intPerJefeRRHH = 7;
        public static int intPerCoodinadorComprasDiseno = 34;
        public static int intPerAuditorCajaDespacho = 35;
        public static int intPerHelpDesk = 36;
        public static int intPerProgramador = 68;
        public static int intPerJefeCreditoCobranzas = 26;
        public static int intPerAsistenteFacturacion = 27;
        public static int intPerCoordinadorContabilidad = 30;
        public static int intPerCoordinacionFacturacion = 31;
        public static int intPerFacturacion = 27;
        public static int intPerSupervisorDiseno = 38;
        public static int intPerSupervisorAlmacenTienda = 40;
        public static int intPerAsistenteRRHH = 42;
        public static int intPerJefeMarketingPublicidad = 43;
        public static int intPerTesoreria = 65;
        public static int intPerCajeraDigital = 66;

        public static int intPerAuxiliarAlmacen = 22;
        public static int intPerAuxiliarVisual = 12;
        public static int intPerCoordinadorMuestrasVisual = 13;
        public static int intPerCoordinadorVisualCentral = 44;
        public static int intPerEncargadoAnaqueles = 200;
        public static int intPerAsistenteCreditos = 50;
        public static int intPerSubAdministrador = 53;
        public static int intPerJefeVisual = 54;
        public static int intPerJefeCanalMayorista = 55;
        public static int intPerAscesorVentasCartera = 17;
        public static int intPerAnalistaProducto = 56;
        public static int intPerAnalistaInventario = 58;
        public static int intPerGerenteComercial = 75;
        public static int intPerComunity = 61;
        public static int intPerJefeProduccion = 71;
        public static int intPerJefeProduccion1 = 38;
        //Tipo de Formato de impresión
        public static int intTipoFormatoDesglosable = 96;
        public static int intTipoFormatoContinuo = 97;

        //Parametros Network
        public static string strMacAddress = "00:00:00:00:00";
        public static string strDireccionIP = "172.0.0.0";

        //Parametros Situacion Proyecto de Asesoria
        public static int intSITProyectoServicioEvaluacion = 289;
        public static int intSITProyectoServicioEjecucion = 290;
        public static int intSITProyectoServicioCerrado = 291;

        //Parametros Turno
        public static int intTurnoManana = 16;
        public static int intTurnoTarde = 17;
        public static int intTurnoNoche = 18;

        //Parametros Tipo Anuncio
        public static int intAnuncioInicioSesion = 309;
        public static int intAnuncioPedido = 310;
        public static int intAnuncioAlerta = 311;
        public static int intAnuncioAlertaPopup = 312;

        //Parametros GIFT CARD
        public static int intGiftCardActivo = 321;
        public static int intGiftCardPerdido = 322;
        public static int intGiftCardVencido = 323;
        public static int intGiftCard = 324;

        //Parametros Situacion PSE
        public static int intSitCorrectoPSE = 335;
        public static int intSitAnuladoPSE = 336;

        //Parametros Situacion Contable
        public static int intSitPendienteCon = 350;
        public static int intSitPagadoCon = 351;
        public static int intSitAplicadoCon = 352;
        public static int intSitAnuladoCon = 353;

        //Parametros Tamaño Hoja
        public static int intTamanoA4 = 355;
        public static int intTamano80mmTermico = 356;
        public static int intTamano80mmMatricial = 357;

        //Parametros Tipo Afectación IGV
        public static string strGravadoOnerosa = "10";
        public static string strGravadoPublicidad = "14";
        public static string strGravadoBonificaciones = "15";
        public static string strGravadoEntregaTrabajadores = "16";
        public static string strGravadoRetiroPremio = "11";

        //Parametros Tipo Promoción
        public static int intPromClienteReferido = 379;

        //Parametros Busqueda Promociones
        public static bool bPromocion2x1 = false;
        public static bool bPromocion3x2 = false;
        public static bool bPromocion3x1 = false;
        public static bool bPromocion4x1 = false;

        //Parametros Hora Extra
        public static decimal intPorcentajeAsigFamiliar = Convert.ToDecimal("0.1");

        //Parametros MARGEN DE CONTRIBUCION modulo KIRA (Costo gastos)
        public static decimal margencontri = 0.4m;

        //Parametros TABLA ELEMENTOS modulo KIRA (Costo gastos Materiales)
        public static int idACERO = 714;
        public static string idACEROedit = "714";

        public static int idBRONCE = 715;
        public static string idBRONCEedit = "715";

        public static int idCASO = 716;
        public static string idCASOedit = "716";

        public static int idESPUMA = 717;
        public static string idESPUMAedit = "717";

        public static int idESPEJO = 718;
        public static string idESPEJOedit = "718";

        public static int idFIERRO = 719;
        public static string idFIERROedit = "719";

        public static int idMADERA = 720;
        public static string idMADERAedit = "720";

        public static int idMDF = 721;
        public static string idMDFedit = "721";

        public static int idMELAMINE = 722;
        public static string idMELAMINEedit = "722";

        public static int idNAPA = 723;
        public static string idNAPAedit = "723";

        public static int idNOTEX = 724;
        public static string idNOTEXedit = "724";

        public static int idPIEDRA = 725;
        public static string idPIEDRAedit = "725";

        public static int idTELA = 726;
        public static string idTELAedit = "726";

        public static int idVIDRIO = 727;
        public static string idVIDRIOedit = "727";

        public static int idENCHAPE = 728;
        public static string idENCHAPEedit = "728";

        //Parametros TABLA ELEMENTOS modulo KIRA (Costo gastos INSUMOS)
        public static int idCARTON_PRENSADO = 729;
        public static string idCARTON_PRENSADOedit = "729";

        public static int idCRUDO = 730;
        public static string idCRUDOedit = "730";

        public static int idNOSAG = 731;
        public static string idNOSAGedit = "731";

        public static int idPINTURA = 732;
        public static string iidPINTURAedit = "732";

        public static int idPOLISEA = 733;
        public static string idPOLISEAedit = "733";

        //Parametros TABLA ELEMENTOS modulo KIRA (Costo gastos ACCESORIOS)
        public static int idBISAGRAS = 734;
        public static string idBISAGRASedit = "734";

        public static int idCORREDERAS = 735;
        public static string idCORREDERASedit = "735";

        public static int idTIRADORES = 736;
        public static string idTIRADORESedit = "736";

        public static int idILUMINACION = 737;
        public static string idILUMINACIONedit = "737";

        public static int idPATASZOCALO = 738;
        public static string idPATASZOCALOedit = "738";

        public static int idPATASMADERA = 739;
        public static string idPATASMADERAedit = "739";

        public static int idPATASMETALICAS = 740;
        public static string idPATASMETALICASedit = "740";


        //Parametros TABLA ELEMENTOS modulo KIRA (Costo gastos MANODEOBRA)
        public static int idCARPINTERIA = 741;
        public static string idCARPINTERIAedit = "741";

        public static int idCOSTURERO = 742;
        public static string idCOSTUREROEDIT = "742";

        public static int idELECTRICISTA = 743;
        public static string idELECTRICISTAedit = "743";

        public static int idESAMBLADOR = 744;
        public static string idESAMBLADORedit = "744";

        public static int idPINTURAS = 745;
        public static string idPINTURASedit = "745";

        public static int idSOLDADOR = 746;
        public static string idSOLDADORedit = "746";

        public static int idTAPICERO = 747;
        public static string idTAPICEROedit = "747";

        public static int idVIDRIERO = 748;
        public static string idVIDRIEROedit = "748";

        //Parametros TABLA ELEMENTOS modulo KIRA (Costo gastos MOVILIDADYVIATICOS)
        public static int idPASAJEDISENADORA = 749;
        public static string idPASAJEDISENADORAedit = "749";

        public static int idPASAJEPARAENTREGA = 750;
        public static string idPASAJEPARAENTREGAedit = "750";

        public static int idPASAJEPRODUCCION = 751;
        public static string idPASAJEPRODUCCIONedit = "751";

        public static int idVIATICOS = 752;
        public static string idVIATICOSedit = "752";

        //Parametros TABLA ELEMENTOS modulo KIRA (Costo gastos EquiposYHerramientas)
        public static int idequiposHerramientas = 753;

       
        //Parametros TABLA ELEMENTOS modulo KIRA-Productos Terminados (Costo gastos ProductoTerminado)
        public static int idCostoINC_IGV = 754;
        public static string idCostoINC_IGVedit = "754";
        public static int idMovilidad = 755;
        public static string idMovilidadedit = "755";
        public static int idServiciosAdicionales = 756;
        public static string idServiciosAdicionalesedit = "756";

    }

}