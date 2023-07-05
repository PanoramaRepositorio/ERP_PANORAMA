using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.ClienteAPI;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ErpPanorama.Presentation.Funciones
{
      class FacturacionElectronicaSUNAT_THB
    {
        private const string UrlSunat = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService";
       // private const string UrlSunat = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";

        private const string FormatoFecha = "yyyy-MM-dd";
        private string MensajeOSE = "";
        public bool bEnviar = true;
        //public static string RutaArchivo = "";

        private static Compania CrearEmisor()
        {
            return new Compania
            {
                NroDocumento = "10727472873",
                TipoDocumento = "6",
                NombreComercial = "",
                NombreLegal = "TAPIA HUAMAN NELLY BETHSABE",
                CodigoAnexo = "0000"
            };
        }

        private static Negocio ToNegocio(Compania compania)
        {
            return new Negocio
            {
                NroDocumento = compania.NroDocumento,
                TipoDocumento = compania.TipoDocumento,
                NombreComercial = compania.NombreComercial,
                NombreLegal = compania.NombreLegal,
                Distrito = "LIMA",
                Provincia = "LIMA",
                Departamento = "LIMA",
                Direccion = "JR. UCAYALI NRO. 425 INT. 103 LIMA - LIMA - LIMA",
                Ubigeo = "150101"
            };
        }

        public string CrearFactura(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                MensajeOSE = string.Empty;
                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);

                List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

                List<DetalleDocumento> lstDetalleDoc = new List<DetalleDocumento>();
                foreach (var item in lstTmpDocumentoVentaDetalle)
                {
                    DetalleDocumento Detalle = new DetalleDocumento();
                    Detalle.Id = item.Item;
                    Detalle.Cantidad = item.Cantidad;
                    Detalle.PrecioReferencial = item.CodAfeIGV == "30" ? 25 : item.ValorUnitDscto;
                    Detalle.PrecioUnitario = item.CodAfeIGV == "30" ? 25 : item.ValorUnitDscto;
                    Detalle.TipoPrecio = item.CodAfeIGV == "30" ? "02" : "01"; //Verificar en el catálogo
                    Detalle.CodigoItem = item.IdProducto.ToString();
                    Detalle.Descripcion = item.NombreProducto;
                    Detalle.UnidadMedida = "NIU"; //Verificar unidad de medida
                    Detalle.Impuesto = item.CodAfeIGV=="30"? 0: item.Igv;
                    Detalle.TipoImpuesto = item.CodAfeIGV;
                    Detalle.TotalVenta = item.CodAfeIGV == "30" ? 0 : item.ValorVenta;
                    //Detalle.OtroImpuesto = 0.10m;//add
                    lstDetalleDoc.Add(Detalle);
                }

                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = objE_DocumentoVenta.NumeroDocumento,
                        TipoDocumento = objE_DocumentoVenta.IdTipoIdentidad.ToString(),
                        NombreLegal = objE_DocumentoVenta.DescCliente
                    },
                    IdDocumento = $"{objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}",
                    FechaEmision = objE_DocumentoVenta.Fecha.ToString(FormatoFecha),//  DateTime.Today.ToString(FormatoFecha),//"2019-07-31",
                    HoraEmision = objE_DocumentoVenta.FechaRegistro.ToString("HH:mm:ss"),// "12:00:00",
                    Moneda = objE_DocumentoVenta.IdMoneda == 5 ? "PEN" : "USD",
                    TipoDocumento = objE_DocumentoVenta.IdConTipoComprobantePago,
                    TotalIgv = objE_DocumentoVenta.Igv,
                    TotalVenta = objE_DocumentoVenta.Total,
                    
                    Gravadas = objE_DocumentoVenta.SubTotal,
                    //TotalOtrosTributos = 0.10m,
                    Items = lstDetalleDoc
                };

                MensajeOSE = FirmaryEnviarOSE(documento, GenerarDocumento(documento));

                #region "Grabar Mensaje"
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion

                return MensajeOSE;
            }
            catch (Exception ex)
            {
                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion
                return ex.Message;
            }
        }

        public string CrearFacturaGratuita(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                MensajeOSE = string.Empty;

                // Jala los datos de la cabecera del documento
                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);

                // Jala los datos del detalle del documento
                List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

                List<DetalleDocumento> lstDetalleDoc = new List<DetalleDocumento>();
                foreach (var item in lstTmpDocumentoVentaDetalle)
                {
                    DetalleDocumento Detalle = new DetalleDocumento();
                    Detalle.Id = item.Item;
                    Detalle.Cantidad = item.Cantidad;
                    Detalle.PrecioReferencial = item.ValorUnitDscto;
                    Detalle.PrecioUnitario = 0;// item.ValorUnitDscto;
                    Detalle.TipoPrecio = "01"; //Verificar en el catálogo
                    Detalle.CodigoItem = item.IdProducto.ToString();
                    Detalle.Descripcion = item.NombreProducto;
                    Detalle.UnidadMedida = "NIU"; //Verificar unidad de medida
                    Detalle.Impuesto = 0;//item.Igv;
                    Detalle.TipoImpuesto = "21";// item.CodAfeIGV;// "21", // Gratuita, Promocion, Retiro, Donacion
                    Detalle.TotalVenta = 0;//item.ValorVenta;
                    lstDetalleDoc.Add(Detalle);
                    //DetalleDocumento Detalle = new DetalleDocumento();
                    //Detalle.Id = item.Item;
                    //Detalle.Cantidad = item.Cantidad;
                    //Detalle.PrecioReferencial = 0; // item.ValorUnitDscto;

                    //Detalle.PrecioUnitario = item.ValorVenta;
                    //Detalle.TipoPrecio = "02"; //Verificar en el catálogo  01
                    //Detalle.CodigoItem = item.IdProducto.ToString();
                    //Detalle.Descripcion = item.NombreProducto;
                    //Detalle.UnidadMedida = "NIU"; //Verificar unidad de medida
                    //Detalle.Impuesto = Convert.ToDecimal(9.70); //  item.Igv;
                    //Detalle.TipoImpuesto = "11"; // item.CodAfeIGV;// "21", // Gratuita, Promocion, Retiro, Donacion
                    //Detalle.TotalVenta = 100; //item.TotalValor;
                    //Detalle.PrecioReferencial = 11  ;                    
                    //Detalle.ValorReferencial =22;    
                    //lstDetalleDoc.Add(Detalle);

                    //******************
                    //Detalle.Id = item.Item;
                    //Detalle.Cantidad = item.Cantidad;
                    //Detalle.PrecioReferencial = 1000; //item.ValorUnitDscto;
                    //Detalle.PrecioUnitario = item.ValorVenta; // item.ValorUnitDscto;
                    //Detalle.TipoPrecio = "02"; //Verificar en el catálogo
                    //Detalle.CodigoItem = item.IdProducto.ToString();
                    //Detalle.Descripcion = item.NombreProducto;
                    //Detalle.UnidadMedida = "NIU"; //Verificar unidad de medida
                    //Detalle.Impuesto = item.Igv;
                    //Detalle.TipoImpuesto = item.CodAfeIGV;
                    //Detalle.TotalVenta = 100;  /// item.ValorVenta;
                    //Detalle.Descuento = 100;//item.Descuento;
                    //lstDetalleDoc.Add(Detalle);
                }

                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = objE_DocumentoVenta.NumeroDocumento,
                        TipoDocumento = objE_DocumentoVenta.IdTipoIdentidad.ToString(),
                        NombreLegal = objE_DocumentoVenta.DescCliente
                    },
                    IdDocumento = $"{objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}",
                    FechaEmision = objE_DocumentoVenta.Fecha.ToString(FormatoFecha),//"2019-07-31", 
                    HoraEmision = objE_DocumentoVenta.FechaRegistro.ToString("HH:mm:ss"),// "12:00:00",
                    Moneda = objE_DocumentoVenta.IdMoneda == 5 ? "PEN" : "USD",
                    TipoDocumento = objE_DocumentoVenta.IdConTipoComprobantePago,
                    TotalIgv = objE_DocumentoVenta.Igv,
                    TotalVenta = objE_DocumentoVenta.Total,
                    Gratuitas = objE_DocumentoVenta.OperacionGratuita,
                    /// DETALLE
                    Items = lstDetalleDoc
                };

                MensajeOSE = FirmaryEnviarOSE(documento, GenerarDocumento(documento));

                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion

                return MensajeOSE;
            }
            catch (Exception ex)
            {
                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion

                return ex.Message;
            }
        }

        public string CrearFacturaGravadoConGratuita(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                MensajeOSE = string.Empty;
                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);

                List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

                List<DetalleDocumento> lstDetalleDoc = new List<DetalleDocumento>();
                foreach (var item in lstTmpDocumentoVentaDetalle)
                {
                    DetalleDocumento Detalle = new DetalleDocumento();
                    Detalle.Id = item.Item;
                    Detalle.Cantidad = item.Cantidad;
                    Detalle.PrecioReferencial = 1000; //item.ValorUnitDscto;
                    Detalle.PrecioUnitario = item.ValorVenta; // item.ValorUnitDscto;
                    Detalle.TipoPrecio = "02"; //Verificar en el catálogo
                    Detalle.CodigoItem = item.IdProducto.ToString();
                    Detalle.Descripcion = item.NombreProducto;
                    Detalle.UnidadMedida = "NIU"; //Verificar unidad de medida
                    Detalle.Impuesto = item.Igv;
                    Detalle.TipoImpuesto = item.CodAfeIGV;
                    Detalle.TotalVenta = 100;  /// item.ValorVenta;
                    Detalle.Descuento = 100;//item.Descuento;
                    lstDetalleDoc.Add(Detalle);
                }

                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = objE_DocumentoVenta.NumeroDocumento,
                        TipoDocumento = objE_DocumentoVenta.IdTipoIdentidad.ToString(),
                        NombreLegal = objE_DocumentoVenta.DescCliente
                    },
                    IdDocumento = $"{objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}",
                    FechaEmision = objE_DocumentoVenta.Fecha.ToString(FormatoFecha),//  DateTime.Today.ToString(FormatoFecha),"2019-07-31",
                    HoraEmision = objE_DocumentoVenta.FechaRegistro.ToString("HH:mm:ss"),// "12:00:00",
                    Moneda = objE_DocumentoVenta.IdMoneda == 5 ? "PEN" : "USD",
                    TipoDocumento = objE_DocumentoVenta.IdConTipoComprobantePago,
                    TotalIgv = objE_DocumentoVenta.Igv,
                    TotalVenta = objE_DocumentoVenta.Total,
                    Gravadas = objE_DocumentoVenta.SubTotal,
                    Exoneradas = 0m,
                    Inafectas = 0m,
                    Gratuitas = objE_DocumentoVenta.OperacionGratuita,
                    DescuentoGlobal = 0,//5m,
                    Items = lstDetalleDoc
                };

                MensajeOSE = FirmaryEnviarOSE(documento, GenerarDocumento(documento));

                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion

                return MensajeOSE;
            }
            catch (Exception ex)
            {
                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion
                return ex.Message;
            }
        }


        public string CrearNotaCredito(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                MensajeOSE = string.Empty;
                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);

                List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

                List<DetalleDocumento> lstDetalleDoc = new List<DetalleDocumento>();
                foreach (var item in lstTmpDocumentoVentaDetalle)
                {
                    DetalleDocumento Detalle = new DetalleDocumento();
                    Detalle.Id = item.Item;
                    Detalle.Cantidad = item.Cantidad;
                    Detalle.PrecioReferencial = item.ValorUnitDscto;
                    Detalle.PrecioUnitario = item.ValorUnitDscto;
                    Detalle.TipoPrecio = "01"; //Verificar en el catálogo
                    Detalle.CodigoItem = item.IdProducto.ToString();
                    Detalle.Descripcion = item.NombreProducto;
                    Detalle.UnidadMedida = "NIU"; //Verificar unidad de medida
                    Detalle.Impuesto = item.Igv;
                    Detalle.TipoImpuesto = item.CodAfeIGV;
                    Detalle.TotalVenta = item.TotalValorUnitDscto;
                    lstDetalleDoc.Add(Detalle);
                }

                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = objE_DocumentoVenta.NumeroDocumento,
                        TipoDocumento = objE_DocumentoVenta.IdTipoIdentidad.ToString(),
                        NombreLegal = objE_DocumentoVenta.DescCliente,
                        CodigoAnexo = ""
                    },
                    IdDocumento = objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero,
                    FechaEmision = objE_DocumentoVenta.Fecha.ToString(FormatoFecha),//  DateTime.Today.ToString(FormatoFecha),"2019-07-31",
                    HoraEmision = objE_DocumentoVenta.FechaRegistro.ToString("HH:mm:ss"),// "12:00:00",
                    MontoEnLetras = string.Empty,
                    Moneda = objE_DocumentoVenta.IdMoneda == 5 ? "PEN" : "USD",
                    TipoDocumento = objE_DocumentoVenta.IdConTipoComprobantePago,
                    TotalIgv = objE_DocumentoVenta.Igv,
                    TotalVenta = objE_DocumentoVenta.Total,
                    Gravadas = objE_DocumentoVenta.SubTotal,
                    Items = lstDetalleDoc,

                    Discrepancias = new List<Discrepancia>
                    {
                        new Discrepancia
                        {
                            NroReferencia = objE_DocumentoVenta.SerieReferencia + "-" + objE_DocumentoVenta.NumeroReferencia,
                            Tipo = objE_DocumentoVenta.CodigoNC,
                            Descripcion = objE_DocumentoVenta.DescMotivoAnula.ToLowerInvariant()
                        }
                    },
                    Relacionados = new List<DocumentoRelacionado>
                    {
                        new DocumentoRelacionado
                        {
                            NroDocumento = objE_DocumentoVenta.SerieReferencia + "-" + objE_DocumentoVenta.NumeroReferencia,
                            TipoDocumento = objE_DocumentoVenta.IdConTipoComprobantePagoRef
                        }
                    }
                };

                File.WriteAllText("notacredito.json", Newtonsoft.Json.JsonConvert.SerializeObject(documento));

                MensajeOSE = FirmaryEnviarOSE(documento, GenerarDocumento(documento));

                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion

                return MensajeOSE;
            }
            catch (Exception ex)
            {
                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion
                return ex.Message;
            }
        }

        public string CrearGuiaRemision(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                MensajeOSE = string.Empty;

                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaGuiaFE(IdDocumentoVenta);

                List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

                var guia = new GuiaRemision
                {
                    IdDocumento = $"{objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}", //"T001-00000001",
                    FechaEmision = objE_DocumentoVenta.Fecha.ToString(FormatoFecha),//"2019-08-02",
                    TipoDocumento = "09",
                    Glosa = objE_DocumentoVenta.Observacion, //"Guia Fac:" + $"{objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}", //REFERENCIA LA FACTURA
                    Remitente = CrearEmisor(),
                    Destinatario = new Contribuyente
                    {
                        NroDocumento = objE_DocumentoVenta.NumeroDocumento, //"20330676826",
                        TipoDocumento = objE_DocumentoVenta.IdTipoIdentidad,//"6",
                        NombreLegal = objE_DocumentoVenta.DescCliente,//"PANORAMA DISTRIBUIDORES S.A.",
                    },
                    ShipmentId = "001",
                    //CodigoMotivoTraslado = "02",
                    CodigoMotivoTraslado = objE_DocumentoVenta.MotivoTraslado,// "01",
                    DescripcionMotivo = "VENTA DIRECTA",
                    Transbordo = false,
                    PesoBrutoTotal = objE_DocumentoVenta.PesoBultos, // 50,
                    NroPallets = objE_DocumentoVenta.NumeroBultos, //0, //Numero de Bultos
                    ModalidadTraslado = objE_DocumentoVenta.ModalidadTraslado,//  "02", //01: PUBLICO  02: PRIVADO
                    FechaInicioTraslado = Convert.ToDateTime(objE_DocumentoVenta.FechaTraslado).ToString(FormatoFecha),//DateTime.Today.ToString(FormatoFecha),
                    RucTransportista = "20330676826",
                    RazonSocialTransportista = "PANORAMA DISTRIBUIDORES S.A.",
                    NroPlacaVehiculo = objE_DocumentoVenta.NumeroPlaca,// "BOY-901",
                    NroDocumentoConductor = objE_DocumentoVenta.NumeroDocTra,// "09991329",
                    DireccionPartida = new Direccion
                    {
                        Ubigeo = objE_DocumentoVenta.IdUbigeoOrigen, //"150101",
                        DireccionCompleta = objE_DocumentoVenta.DireccionEmpresa //"JR. UCAYALI 425"
                    },
                    DireccionLlegada = new Direccion
                    {
                        Ubigeo = objE_DocumentoVenta.IdUbigeo,  //               "040129",  // objE_DocumentoVenta.IdUbigeo,//"150101",
                        DireccionCompleta = objE_DocumentoVenta.Direccion //  "AV. A. A. CACERES SIGLO 20JOSE LUIS B. Y RIVERO-AREQUIPA-AREQUIPA",   //objE_DocumentoVenta.Direccion// "AV. ARGENTINA 2388"
                    },
                    NumeroContenedor = string.Empty,
                    CodigoPuerto = string.Empty,
                    BienesATransportar = new List<DetalleGuia>()
                    //{
                    //    new DetalleGuia
                    //    {
                    //        Correlativo = 1,
                    //        CodigoItem = "XXXX",
                    //        Descripcion = "XXXXXXX",
                    //        UnidadMedida = "NIU",
                    //        Cantidad = 4,
                    //        LineaReferencia = 1
                    //    }
                    //}
                };

                //Agregando Detalle
                foreach (var item in lstTmpDocumentoVentaDetalle)
                {
                    guia.BienesATransportar.Add(new DetalleGuia
                    {
                        Correlativo = item.Item,
                        CodigoItem = item.IdProducto.ToString(),
                        Descripcion = item.NombreProducto,
                        UnidadMedida = "NIU",
                        Cantidad = item.Cantidad,
                        LineaReferencia = 1
                    });
                }

                //Generando XML...
                var documentoResponse = RestHelper<GuiaRemision, DocumentoResponse>.Execute("GenerarGuiaRemision", guia);

                if (!documentoResponse.Exito)
                {
                    MensajeOSE = documentoResponse.MensajeError;
                    //throw new InvalidOperationException(documentoResponse.MensajeError);
                }

                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C21010838734-THL.pfx")),
                    PasswordCertificado = "THLpanorama2021",
                };


                var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                if (!responseFirma.Exito)
                {
                    MensajeOSE = responseFirma.MensajeError;
                    //throw new InvalidOperationException(responseFirma.MensajeError);
                }

                File.WriteAllBytes($"{guia.Remitente.NroDocumento}-{guia.TipoDocumento}-{guia.IdDocumento}.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));

                //Enviando a SUNAT...
                var documentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = guia.Remitente.NroDocumento,
                    //UsuarioSol = "MODDATOS",
                    //ClaveSol = "MODDATOS",

                    UsuarioSol = "USERTHSL",
                    ClaveSol = "LTpanorama21",
                    EndPointUrl = UrlSunat,
                    IdDocumento = guia.IdDocumento,
                    TipoDocumento = guia.TipoDocumento,
                    TramaXmlFirmado = responseFirma.TramaXmlFirmado
                };

                var enviarDocumentoResponse = RestHelper<EnviarDocumentoRequest, EnviarDocumentoResponse>.Execute("EnviarDocumento", documentoRequest);

                if (!enviarDocumentoResponse.Exito)
                {
                    SunatErrorFEBE errorFE = new SunatErrorFEBE();
                    errorFE = new SunatErrorFEBL().Selecciona(enviarDocumentoResponse.MensajeError.Replace("Server", ""));

                    DocumentoVentaBL objBL_DocumentoVentaER = new DocumentoVentaBL();
                    objBL_DocumentoVentaER.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, $"{errorFE.Codigo} - {errorFE.DescError}", 0, "", Convert.ToDateTime("01/01/1999"), "");

                    return $"{errorFE.Codigo} - {errorFE.DescError}";

                    //MensajeOSE = enviarDocumentoResponse.MensajeError;
                    //throw new InvalidOperationException(enviarDocumentoResponse.MensajeError);
                }

                File.WriteAllBytes($"{guia.Remitente.NroDocumento}-{guia.TipoDocumento}-{guia.IdDocumento}-Cdr.zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr));

                //Respuesta de SUNAT
                MensajeOSE = enviarDocumentoResponse.MensajeRespuesta;

                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion

                return MensajeOSE;
            }
            catch (Exception ex)
            {
                #region "Grabar Mensaje"
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, ex.Message, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion
                return ex.Message;
            }
        }

        public string CrearResumenDiario() //Anulación de boletas
        {
            try
            {
                List<DocumentoVentaBE> lstDocumentoVenta = null;
                lstDocumentoVenta = new DocumentoVentaBL().ListaPendienteBajaFE(19, Parametros.intTipoDocBoletaElectronica);
                if (lstDocumentoVenta.Count == 0)
                {
                    return MensajeOSE = "ERROR INTERNO: No hay documentos para dar de baja";
                }
                MensajeOSE = "Resumen diario del " + lstDocumentoVenta[0].Fecha.ToString("dd-MM-yyyy") + "\nEnviado en el archivo " + lstDocumentoVenta[0].GrupoBaja + "\nESTADO: ACEPTADO";

                var documentoResumenDiario = new ResumenDiarioNuevo
                {
                    //IdDocumento = $"RC-20190731-002",
                    IdDocumento = lstDocumentoVenta[0].GrupoBaja,// $"RC-{DateTime.Today:yyyyMMdd}-001",
                    FechaEmision = lstDocumentoVenta[0].Fecha.ToString(FormatoFecha), //DateTime.Today.ToString(FormatoFecha),
                    FechaReferencia = lstDocumentoVenta[0].Fecha.ToString(FormatoFecha),// DateTime.Today.AddDays(-1).ToString(FormatoFecha),
                    Emisor = CrearEmisor(),
                    Resumenes = new List<GrupoResumenNuevo>()
                };

                // Para los casos de envio de boletas anuladas, se debe primero informar las boletas creadas (1) y 
                //luego en un segundo resumen se envian las anuladas. De lo contrario se presentará el error 'El documento indicado no existe no puede ser modificado/eliminado'
                foreach (var item in lstDocumentoVenta)
                {
                    documentoResumenDiario.Resumenes.Add(new GrupoResumenNuevo
                    {
                        Id = item.Item,
                        TipoDocumento = item.IdConTipoComprobantePago,
                        IdDocumento = $"{item.Serie}-{item.Numero}",
                        NroDocumentoReceptor = item.NumeroDocumento,
                        TipoDocumentoReceptor = item.IdTipoIdentidad,
                        CodigoEstadoItem = 3, // 1 - Agregar. 2 - Modificar. 3 - Eliminar
                        Moneda = item.CodMoneda,
                        TotalVenta = item.Total,
                        TotalIgv = item.Igv,
                        Gravadas = item.SubTotal
                    });
                }

                //"Generando XML....";

                var documentoResponse = RestHelper<ResumenDiarioNuevo, DocumentoResponse>.Execute("GenerarResumenDiario/v2", documentoResumenDiario);

                if (!documentoResponse.Exito)
                {
                    SunatErrorFEBE errorFE = new SunatErrorFEBE();
                    errorFE = new SunatErrorFEBL().Selecciona(documentoResponse.MensajeError.Replace("Server", ""));
                    return $"{errorFE.Codigo} - {errorFE.DescError}";
                }

                //"Firmando XML..."
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    //CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("Certificado.pfx")),
                    //PasswordCertificado = "pedrocelinda",
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C21010838785-THB.pfx")),
                    PasswordCertificado = "THBpanorama2021",
                };

                var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                if (!responseFirma.Exito)
                {
                    SunatErrorFEBE errorFE = new SunatErrorFEBE();
                    errorFE = new SunatErrorFEBL().Selecciona(responseFirma.MensajeError.Replace("Server", ""));
                    return $"{errorFE.Codigo} - {errorFE.DescError}";
                }

                //"Guardando XML de Resumen....(Revisar carpeta del ejecutable)

                File.WriteAllBytes($"resumendiario-{lstDocumentoVenta[0].GrupoBaja}.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));
                //File.WriteAllBytes("resumendiario.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));

                //"Enviando a SUNAT....

                var enviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = documentoResumenDiario.Emisor.NroDocumento,
                    //UsuarioSol = "MODDATOS",
                    //ClaveSol = "MODDATOS",

                    UsuarioSol = "USERTHNB",
                    ClaveSol = "BTpanorama21",

                    EndPointUrl = UrlSunat,
                    IdDocumento = documentoResumenDiario.IdDocumento,
                    TramaXmlFirmado = responseFirma.TramaXmlFirmado
                };

                var enviarResumenResponse = RestHelper<EnviarDocumentoRequest, EnviarResumenResponse>.Execute("EnviarResumen", enviarDocumentoRequest);

                if (!enviarResumenResponse.Exito)
                {
                    SunatErrorFEBE errorFE = new SunatErrorFEBE();
                    errorFE = new SunatErrorFEBL().Selecciona(enviarResumenResponse.MensajeError.Replace("Server", ""));
                    return $"{errorFE.Codigo} - {errorFE.DescError}";
                }

                //Console.WriteLine("Nro de Ticket: {0}", enviarResumenResponse.NroTicket);
                #region "Grabar Ticket"
                SunatConsultaTicketBE objE_SunatTicket = new SunatConsultaTicketBE();
                SunatConsultaTicketBL objBL_SunatTicket = new SunatConsultaTicketBL();

                objE_SunatTicket.IdSunatConsultaTicket = 0;
                objE_SunatTicket.Ruc = enviarDocumentoRequest.Ruc;
                objE_SunatTicket.Fecha = lstDocumentoVenta[0].Fecha;
                objE_SunatTicket.IdTipoDocumento = Parametros.intTipoDocBoletaElectronica;
                objE_SunatTicket.IdGrupoBaja = lstDocumentoVenta[0].IdGrupoBaja;
                objE_SunatTicket.GrupoBaja = lstDocumentoVenta[0].GrupoBaja;
                objE_SunatTicket.NumeroTicket = enviarResumenResponse.NroTicket;
                objE_SunatTicket.MensajeTicket = "";
                objE_SunatTicket.FlagEstado = true;
                objE_SunatTicket.IdEmpresa = 19;
                objE_SunatTicket.Usuario = Parametros.strUsuarioLogin;
                objE_SunatTicket.Maquina = "SERVER-MACHINE";//WindowsIdentity.GetCurrent().Name.ToString();

                objBL_SunatTicket.Inserta(objE_SunatTicket);

                #endregion

                //MensajeOSE = ConsultarTicket(enviarResumenResponse.NroTicket, documentoResumenDiario.Emisor.NroDocumento);

                #region "Grabar Mensaje"
                foreach (var item in lstDocumentoVenta)
                {
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objBL_DocumentoVenta.ActualizaSituacionPSE(item.IdEmpresa, item.IdDocumentoVenta, Parametros.intSitAnuladoPSE, DateTime.Now, MensajeOSE, lstDocumentoVenta[0].IdGrupoBaja, "", Convert.ToDateTime("01/01/1999"), "");
                }
                #endregion



                return MensajeOSE;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CrearComunicacionBaja() //Anulación de Facturas
        {
            try
            {
                MensajeOSE = string.Empty;

                List<DocumentoVentaBE> lstDocumentoVenta = new List<DocumentoVentaBE>();
                lstDocumentoVenta = new DocumentoVentaBL().ListaPendienteBajaFE(19, Parametros.intTipoDocFacturaElectronica);
                if (lstDocumentoVenta.Count == 0)
                {
                    return MensajeOSE = "ERROR INTERNO: No hay documentos para dar de baja";
                }

                MensajeOSE = "Comunicación de Baja del " + lstDocumentoVenta[0].Fecha.ToString("dd-MM-yyyy") + "\nEnviado en el archivo " + lstDocumentoVenta[0].GrupoBaja + "\nESTADO: ACEPTADO";

                var documentoBaja = new ComunicacionBaja
                {
                    //IdDocumento = "RA-20190731-001"
                    IdDocumento = lstDocumentoVenta[0].GrupoBaja,
                    FechaEmision = lstDocumentoVenta[0].Fecha.ToString(FormatoFecha),
                    FechaReferencia = lstDocumentoVenta[0].Fecha.ToString(FormatoFecha),
                    Emisor = CrearEmisor(),
                    Bajas = new List<DocumentoBaja>()
                };

                // En las comunicaciones de Baja ya no se pueden colocar boletas, ya que la anulacion de las mismas
                // la realiza el resumen diario.
                foreach (var item in lstDocumentoVenta)
                {
                    documentoBaja.Bajas.Add(new DocumentoBaja
                    {
                        Id = item.Item,
                        Correlativo = item.Numero, // Convert.ToInt32(item.Numero).ToString(),
                        TipoDocumento = item.IdConTipoComprobantePago,
                        Serie = item.Serie,
                        MotivoBaja = item.MotivoBaja
                    });
                }

                //Generando XML....

                var documentoResponse = RestHelper<ComunicacionBaja, DocumentoResponse>.Execute("GenerarComunicacionBaja", documentoBaja);
                if (!documentoResponse.Exito)
                {
                    SunatErrorFEBE errorFE = new SunatErrorFEBE();
                    errorFE = new SunatErrorFEBL().Selecciona(documentoResponse.MensajeError.Replace("Server", ""));
                    return $"{errorFE.Codigo} - {errorFE.DescError}";
                }

                //Firmando XML...
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    //CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C21010838785-THB.pfx")),
                    //PasswordCertificado = "THBpanorama2021",

                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("Certificado.pfx")),
                    PasswordCertificado = "pedrocelinda",
                };

                var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                if (!responseFirma.Exito)
                {
                    SunatErrorFEBE errorFE = new SunatErrorFEBE();
                    errorFE = new SunatErrorFEBL().Selecciona(responseFirma.MensajeError.Replace("Server", ""));
                    return $"{errorFE.Codigo} - {errorFE.DescError}";
                }

                //Guardando XML de la Comunicacion de Baja....(Revisar carpeta del ejecutable)
                File.WriteAllBytes($"comunicacionbaja-{lstDocumentoVenta[0].GrupoBaja}.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado)); //Renumerar Comunicación

                //Enviando a SUNAT....
                var sendBill = new EnviarDocumentoRequest
                {
                    Ruc = documentoBaja.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",

                    //UsuarioSol = "USERTHNB",
                    //ClaveSol = "BTpanorama21",
                    EndPointUrl = UrlSunat,
                    IdDocumento = documentoBaja.IdDocumento,
                    TramaXmlFirmado = responseFirma.TramaXmlFirmado
                };

                var enviarResumenResponse = RestHelper<EnviarDocumentoRequest, EnviarResumenResponse>.Execute("EnviarResumen", sendBill);
                //EnviarResumenResponse enviarResumenResponse = RestHelper<EnviarDocumentoRequest, EnviarResumenResponse>.Execute("EnviarResumen", sendBill);

                if (!enviarResumenResponse.Exito)
                {
                    SunatErrorFEBE errorFE = new SunatErrorFEBE();
                    errorFE = new SunatErrorFEBL().Selecciona(enviarResumenResponse.MensajeError.Replace("Server", ""));
                    return $"{errorFE.Codigo} - {errorFE.DescError}";
                }

                ////"Nro de Ticket: {0}", enviarResumenResponse.NroTicket; //Almacenar en Log
                #region "Grabar Ticket"
                SunatConsultaTicketBE objE_SunatTicket = new SunatConsultaTicketBE();
                SunatConsultaTicketBL objBL_SunatTicket = new SunatConsultaTicketBL();

                objE_SunatTicket.IdSunatConsultaTicket = 0;
                objE_SunatTicket.Ruc = documentoBaja.Emisor.NroDocumento;
                objE_SunatTicket.Fecha = lstDocumentoVenta[0].Fecha;
                objE_SunatTicket.IdTipoDocumento = Parametros.intTipoDocFacturaElectronica;
                objE_SunatTicket.IdGrupoBaja = lstDocumentoVenta[0].IdGrupoBaja;
                objE_SunatTicket.GrupoBaja = lstDocumentoVenta[0].GrupoBaja;
                objE_SunatTicket.NumeroTicket = enviarResumenResponse.NroTicket;
                objE_SunatTicket.MensajeTicket = "";
                objE_SunatTicket.FlagEstado = true;
                objE_SunatTicket.IdEmpresa = Parametros.intEmpresaId;
                objE_SunatTicket.Usuario = Parametros.strUsuarioLogin;
                objE_SunatTicket.Maquina = "SERVER-MACHINE";//WindowsIdentity.GetCurrent().Name.ToString();

                objBL_SunatTicket.Inserta(objE_SunatTicket);

                #endregion



                //Realizar una nueva consulta para grabar --por error en int y string
                //MensajeOSE = ConsultarTicket(enviarResumenResponse.NroTicket, documentoBaja.Emisor.NroDocumento);

                #region "Grabar Mensaje"
                foreach (var item in lstDocumentoVenta)
                {
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objBL_DocumentoVenta.ActualizaSituacionPSE(item.IdEmpresa, item.IdDocumentoVenta, Parametros.intSitAnuladoPSE, DateTime.Now, MensajeOSE, lstDocumentoVenta[0].IdGrupoBaja, "", Convert.ToDateTime("01/01/1999"), "");
                }
                #endregion


                return MensajeOSE;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static DocumentoResponse GenerarDocumento(DocumentoElectronico documento)
        {
            //Console.WriteLine("Generando XML....");

            var metodo = "GenerarFactura";
            switch (documento.TipoDocumento)
            {
                case "01":
                case "03":
                    metodo = "GenerarFactura";
                    break;
                case "07":
                    metodo = "GenerarNotaCredito";
                    break;
                case "08":
                    metodo = "GenerarNotaDebito";
                    break;
            }

            var documentoResponse = RestHelper<DocumentoElectronico, DocumentoResponse>.Execute(metodo, documento);

            if (!documentoResponse.Exito)
            {
                throw new InvalidOperationException(documentoResponse.MensajeError);
            }

            return documentoResponse;
        }

        private static string FirmaryEnviarOSE(DocumentoElectronico documento, DocumentoResponse documentoResponse)
        {
            var firmado = new FirmadoRequest
            {
                TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                //CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C21010838785-THB.pfx")),
                //PasswordCertificado = "THBpanorama2021",

                CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                PasswordCertificado = "pedrocelinda",
                ValoresQr = documentoResponse.ValoresParaQr
            };

            var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

            if (!responseFirma.Exito)
            {
                SunatErrorFEBE errorFE = new SunatErrorFEBE();
                errorFE = new SunatErrorFEBL().Selecciona(responseFirma.MensajeError);
                return $"{errorFE.Codigo} - {errorFE.DescError}";
            }

            //if (!string.IsNullOrEmpty(responseFirma.CodigoQr))
            //{
            //    using (var mem = new MemoryStream(Convert.FromBase64String(responseFirma.CodigoQr)))
            //    {
            //        //Guardando Imagen QR para el documento...
            //        var imagen = Image.FromStream(mem);
            //        imagen.Save($"{documento.IdDocumento}.png");
            //    }
            //}
            var Emisor = CrearEmisor();
            //Escribiendo el archivo {0}.xml .....

            var path = $"{Emisor.NroDocumento}-{documento.TipoDocumento}-{documento.IdDocumento}.xml";
            //var path = $@"C:\Temp\{Emisor.NroDocumento}-{documento.TipoDocumento}-{documento.IdDocumento}.xml";
            File.WriteAllBytes(path, Convert.FromBase64String(responseFirma.TramaXmlFirmado));

            ///return "Archivo creado!";
            //Enviando al OSE....
            var documentoRequest = new EnviarDocumentoRequest
            {
                Ruc = documento.Emisor.NroDocumento,
                UsuarioSol = "MODDATOS",
                ClaveSol = "MODDATOS",

                //UsuarioSol = "USERTHNB",
                //ClaveSol = "BTpanorama21",
                EndPointUrl = UrlSunat,
                IdDocumento = documento.IdDocumento,
                TipoDocumento = documento.TipoDocumento,
                TramaXmlFirmado = responseFirma.TramaXmlFirmado
            };



            var enviarDocumentoResponse = RestHelper<EnviarDocumentoRequest, EnviarDocumentoResponse>.Execute("EnviarDocumento", documentoRequest);

            if (!enviarDocumentoResponse.Exito)
            {
                SunatErrorFEBE errorFE = new SunatErrorFEBE();
                errorFE = new SunatErrorFEBL().Selecciona(enviarDocumentoResponse.MensajeError.Replace("Server", ""));
                return $"{errorFE.Codigo} - {errorFE.DescError}";
            }
            File.WriteAllBytes($"{Emisor.NroDocumento}-{documento.TipoDocumento}-{documento.IdDocumento}.zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr));
            return enviarDocumentoResponse.MensajeRespuesta;

            //Cargar Errores al iniciar proyecto
        }

        public string ConsultarTicket(string nroTicket, string nroRuc)
        {
            var consultarTicketRequest = new ConsultaTicketRequest
            {
                Ruc = nroRuc,
                NroTicket = nroTicket,
                //      UsuarioSol = "MODDATOS",
                //       ClaveSol = "MODDATOS",
                UsuarioSol = "USERTHNB",
                ClaveSol = "BTpanorama21",
                EndPointUrl = UrlSunat
            };

            var response = RestHelper<ConsultaTicketRequest, EnviarDocumentoResponse>.Execute("ConsultarTicket", consultarTicketRequest);

            if (!response.Exito)
            {
                SunatErrorFEBE errorFE = new SunatErrorFEBE();
                errorFE = new SunatErrorFEBL().Selecciona(response.MensajeError.Replace("Server", ""));
                return $"{errorFE.Codigo} - {errorFE.DescError}";
            }

            var archivo = response.NombreArchivo.Replace(".xml", string.Empty);

            //Escribiendo documento en la carpeta del ejecutable...
            File.WriteAllBytes($"{archivo}.zip", Convert.FromBase64String(response.TramaZipCdr));

            return ($"Código: {response.CodigoRespuesta.ToString()} => {response.MensajeRespuesta}");
        }

        private static void CrearFacturaInafecta()
        {
            try
            {
                //Console.WriteLine("Ejemplo Factura Inafecta (FF11-003)");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20600071344",
                        TipoDocumento = "6",
                        NombreLegal = "DECORATEX S.A."
                    },
                    IdDocumento = "FF11-003",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    HoraEmision = "12:30:00", //DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "PEN",
                    TipoDocumento = "01",
                    TotalIgv = 0,
                    TotalVenta = 468.60m,
                    Inafectas = 468.60m,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 100,
                            PrecioReferencial = 4.20m,
                            PrecioUnitario = 4.20m,
                            TipoPrecio = "01",
                            CodigoItem = "1675",
                            Descripcion = "HUEVOS PARDOS (GRANEL)",
                            UnidadMedida = "NIU",
                            Impuesto = 0,
                            TipoImpuesto = "30", // Inafecta
                            TotalVenta = 420,
                        },new DetalleDocumento
                        {
                            Id = 2,
                            Cantidad = 15,
                            PrecioReferencial = 3.24m,
                            PrecioUnitario = 3.24m,
                            TipoPrecio = "01",
                            CodigoItem = "1676",
                            Descripcion = "HUEVITOS DE CODORNIZ MALLA X 25",
                            UnidadMedida = "NIU",
                            Impuesto = 0,
                            TipoImpuesto = "30", // Inafecta
                            TotalVenta = 48.60m,
                        },
                    }
                };

                FirmaryEnviarOSE(documento, GenerarDocumento(documento));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public string CrearFacturaConDescuento(int IdEmpresa, int IdDocumentoVenta)  
        {
            try
            {
                MensajeOSE = string.Empty;
                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);

                List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

                List<DetalleDocumento> lstDetalleDoc = new List<DetalleDocumento>();
                foreach (var item in lstTmpDocumentoVentaDetalle)
                {
                    DetalleDocumento Detalle = new DetalleDocumento();
                    Detalle.Id = item.Item;
                    Detalle.Cantidad = item.Cantidad;
                    Detalle.PrecioReferencial = item.ValorUnitDscto;
                    Detalle.PrecioUnitario = item.ValorUnitDscto;
                    Detalle.TipoPrecio = "01"; //Verificar en el catálogo
                    Detalle.CodigoItem = item.IdProducto.ToString();
                    Detalle.Descripcion = item.NombreProducto;
                    Detalle.UnidadMedida = "NIU"; //Verificar unidad de medida
                    Detalle.Impuesto = item.Igv;
                    Detalle.TipoImpuesto = item.CodAfeIGV;
                    Detalle.TotalVenta = item.ValorVenta;
                    lstDetalleDoc.Add(Detalle);
                }

                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = objE_DocumentoVenta.NumeroDocumento,
                        TipoDocumento = objE_DocumentoVenta.IdTipoIdentidad.ToString(),
                        NombreLegal = objE_DocumentoVenta.DescCliente
                    },
                    IdDocumento = $"{objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}",
                    FechaEmision = objE_DocumentoVenta.Fecha.ToString(FormatoFecha),//  DateTime.Today.ToString(FormatoFecha),//"2019-07-31",
                    HoraEmision = objE_DocumentoVenta.FechaRegistro.ToString("HH:mm:ss"),// "12:00:00",
                    Moneda = objE_DocumentoVenta.IdMoneda == 5 ? "PEN" : "USD",
                    TipoDocumento = objE_DocumentoVenta.IdConTipoComprobantePago,
                    TotalIgv = objE_DocumentoVenta.Igv,
                    TotalVenta = objE_DocumentoVenta.Total,
                    Gravadas = objE_DocumentoVenta.SubTotal,

                    DescuentoGlobal = 9.32m, //sumatoria de todos los descuentos
                    CodigoRazonDcto = "00", //Catalogo N°53 - Descuentos que afectan la base imponible del IGV
                    FactorMultiplicadorDscto = 69,
                    LineExtensionAmount = 1149.5m,
                    Items = lstDetalleDoc
                };

                //MensajeOSE = FirmaryEnviarOSE(documento, GenerarDocumento(documento));

                #region "Grabar Mensaje"
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion

                return MensajeOSE;
            }
            catch (Exception ex)
            {
                #region "Grabar Mensaje"

                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE, DateTime.Now, MensajeOSE, 0, "", Convert.ToDateTime("01/01/1999"), "");

                #endregion
                return ex.Message;
            }
        }

    }
}
