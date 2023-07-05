using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.ws_integrens;

namespace ErpPanorama.Presentation.Funciones
{
    class FacturacionElectronica
    {
        ws_integrensSoapClient WS = new ws_integrensSoapClient();

        public string GrabarVentaIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);

            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);


            DataTable facelecab = new DataTable();
            facelecab.Columns.Add("ipserver", Type.GetType("System.String"));
            facelecab.Columns.Add("instance", Type.GetType("System.String"));
            facelecab.Columns.Add("dbname", Type.GetType("System.String"));
            facelecab.Columns.Add("numruc", Type.GetType("System.String"));
            facelecab.Columns.Add("altido", Type.GetType("System.String"));
            facelecab.Columns.Add("sersun", Type.GetType("System.String"));
            facelecab.Columns.Add("numsun", Type.GetType("System.String"));
            facelecab.Columns.Add("fecemi", Type.GetType("System.String"));
            facelecab.Columns.Add("codmnd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidoid", Type.GetType("System.String"));
            facelecab.Columns.Add("numidn", Type.GetType("System.String"));
            facelecab.Columns.Add("nomcli", Type.GetType("System.String"));
            facelecab.Columns.Add("tidore", Type.GetType("System.String"));
            facelecab.Columns.Add("nudore", Type.GetType("System.String"));
            facelecab.Columns.Add("basafe", Type.GetType("System.String"));
            facelecab.Columns.Add("basina", Type.GetType("System.String"));
            facelecab.Columns.Add("basexo", Type.GetType("System.String"));
            facelecab.Columns.Add("mongra", Type.GetType("System.String"));
            facelecab.Columns.Add("mondsc", Type.GetType("System.String"));
            facelecab.Columns.Add("monigv", Type.GetType("System.String"));
            facelecab.Columns.Add("monisc", Type.GetType("System.String"));
            facelecab.Columns.Add("monotr", Type.GetType("System.String"));
            facelecab.Columns.Add("dscglo", Type.GetType("System.String"));
            facelecab.Columns.Add("monoca", Type.GetType("System.String"));
            facelecab.Columns.Add("mondoc", Type.GetType("System.String"));
            facelecab.Columns.Add("basper", Type.GetType("System.String"));
            facelecab.Columns.Add("monper", Type.GetType("System.String"));
            facelecab.Columns.Add("totdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("mopedo", Type.GetType("System.String"));
            facelecab.Columns.Add("todope", Type.GetType("System.String"));
            facelecab.Columns.Add("totant", Type.GetType("System.String"));
            facelecab.Columns.Add("cobide", Type.GetType("System.String"));
            facelecab.Columns.Add("ctadet", Type.GetType("System.String"));
            facelecab.Columns.Add("prcdet", Type.GetType("System.String"));
            facelecab.Columns.Add("mondet", Type.GetType("System.String"));
            facelecab.Columns.Add("codmot", Type.GetType("System.String"));
            facelecab.Columns.Add("tidomd", Type.GetType("System.String"));
            facelecab.Columns.Add("nudomd", Type.GetType("System.String"));
            facelecab.Columns.Add("fedomd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidove", Type.GetType("System.String"));
            facelecab.Columns.Add("nudove", Type.GetType("System.String"));
            facelecab.Columns.Add("tipcam", Type.GetType("System.String"));
            facelecab.Columns.Add("codcli", Type.GetType("System.String"));
            facelecab.Columns.Add("ubifis", Type.GetType("System.String"));
            facelecab.Columns.Add("dirfis", Type.GetType("System.String"));
            facelecab.Columns.Add("tiodre", Type.GetType("System.String"));
            facelecab.Columns.Add("nuodre", Type.GetType("System.String"));
            facelecab.Columns.Add("coddoc", Type.GetType("System.String"));
            facelecab.Columns.Add("numdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("tipped", Type.GetType("System.String"));
            facelecab.Columns.Add("numped", Type.GetType("System.String"));
            facelecab.Columns.Add("dester", Type.GetType("System.String"));
            facelecab.Columns.Add("ordcom", Type.GetType("System.String"));
            facelecab.Columns.Add("fecvct", Type.GetType("System.String"));
            facelecab.Columns.Add("observ", Type.GetType("System.String"));
            facelecab.Columns.Add("estreg", Type.GetType("System.String"));
            facelecab.Columns.Add("defopa", Type.GetType("System.String"));
            facelecab.Columns.Add("texglo", Type.GetType("System.String"));
            facelecab.Columns.Add("corepe", Type.GetType("System.String"));
            facelecab.Columns.Add("prcper", Type.GetType("System.String"));
            facelecab.Columns.Add("fecped", Type.GetType("System.String"));

            DataRow dr;
            dr = facelecab.NewRow();
            dr["ipserver"] = "panorama_interface";
            dr["instance"] = "postgres";
            dr["dbname"] = "ifac_panorama";
            dr["numruc"] = objE_DocumentoVenta.Ruc;// Parametros.strEmpresaRuc;
            dr["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;//"01";
            dr["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr["fecemi"] = objE_DocumentoVenta.Fecha;// "27/11/2017 10:00:00 a.m.";
            dr["codmnd"] = objE_DocumentoVenta.CodMoneda;//"USD";
            dr["tidoid"] = objE_DocumentoVenta.IdTipoIdentidad;// "6";
            dr["numidn"] = objE_DocumentoVenta.NumeroDocumento;// "20330676826"; //****ACTIVO Y HABIDO
            dr["nomcli"] = objE_DocumentoVenta.DescCliente.Replace("'","''");// "PANORAMA DISTRIB";
            dr["tidore"] = "";
            dr["nudore"] = "";
            dr["basafe"] = objE_DocumentoVenta.SubTotal;// "19226.86000"; ??
            dr["basina"] = "0.00000";
            dr["basexo"] = "0.00000";
            dr["mongra"] = objE_DocumentoVenta.OperacionGratuita; //"0.00000";//SÓLO SIN SON GRATUITAS
            dr["mondsc"] = objE_DocumentoVenta.Descuentos; //"0.00000";
            dr["monigv"] = objE_DocumentoVenta.Igv;//"3460.83000";
            dr["monisc"] = "0.00000";
            dr["monotr"] = "0.00000";
            dr["dscglo"] = "0.00000";//Descuentos globales
            dr["monoca"] = "0.00000";
            dr["mondoc"] = objE_DocumentoVenta.Total; //"22687.69000";
            dr["basper"] = "0.00000";
            dr["monper"] = "0.00000";
            dr["totdoc"] = "0.00000";
            dr["mopedo"] = "0.00000";
            dr["todope"] = objE_DocumentoVenta.Total;// "22687.69000";
            dr["totant"] = "0";//objE_DocumentoVenta.Total;//"22687.69000"; ANTICIPOS
            dr["cobide"] = "";
            dr["ctadet"] = "";
            dr["prcdet"] = "0.00000";
            dr["mondet"] = "0.00000";
            dr["codmot"] = "";
            dr["tidomd"] = "";
            dr["nudomd"] = "";
            dr["fedomd"] = "";
            dr["tidove"] = "1";//Ver caso Carnet de Extranjería
            dr["nudove"] = objE_DocumentoVenta.DniVendedor;//"42309349";
            dr["tipcam"] = objE_DocumentoVenta.TipoCambio;// "3.42100";
            dr["codcli"] = objE_DocumentoVenta.IdCliente;// "80-00-5089";
            dr["ubifis"] = objE_DocumentoVenta.IdUbigeoDom;// "110108";
            dr["dirfis"] = objE_DocumentoVenta.Direccion.Replace("'", "''"); ;//"AV.EL ZINC 271 URB.INSDUSTRIAL INFENTAS";
            dr["tiodre"] = "";
            dr["nuodre"] = "";
            dr["coddoc"] = "";
            dr["numdoc"] = "";
            dr["tipped"] = "NRO";
            dr["numped"] = objE_DocumentoVenta.NumeroPedido;// "000001";
            dr["dester"] = objE_DocumentoVenta.DescFormaPago;// "CONTADO CONTRA ENTREGA";
            dr["ordcom"] = objE_DocumentoVenta.Periodo.ToString() + "-" + objE_DocumentoVenta.NumeroPedido;// "GG-0034-2016";
            dr["fecvct"] = objE_DocumentoVenta.FechaVencimiento; //""  ; //Consultar //Fecha Vencimiento para créditos
            dr["observ"] = "";//"CONTROL: 22216 MERCADERIA ENTREGADA EN: T.C: 3.42100 VENDEDOR: EMMA GARCIA FECHA PEDIDO: 2017 - 06 - 19 FECHA ORD: 2017 - 06 - 19 - INCORPORADO AL REGIMEN DE AGENTES DE RETENCION DEL IGV SEGUN RS Nchar(176) 378 - 2013 SUNAT";
            dr["estreg"] = "CO";//CO = Correcto; AN= Anulado
            dr["defopa"] = "";
            dr["texglo"] = "";
            dr["corepe"] = "";
            dr["prcper"] = "0";
            dr["fecped"] = objE_DocumentoVenta.Fecha;// "27/11/2017 09:00:00 a.m.";

            if (objE_DocumentoVenta.OperacionGratuita > 0)
            {
                dr["mongra"] = objE_DocumentoVenta.OperacionGratuita; //"0.00000";//SÓLO SIN SON GRATUITAS
                dr["basafe"] = "0.00000";
                dr["monigv"] = "0.00000";
                dr["mondoc"] = "0.00000";
                dr["todope"] = "0.00000"; //Si pasa--> "0.01000";
                dr["prcper"] = "0";
            }

            ////if (objE_DocumentoVenta.OperacionGratuita > 0)
            ////{
            ////    dr["mongra"] = objE_DocumentoVenta.OperacionGratuita; //"0.00000";//SÓLO SIN SON GRATUITAS
            ////    ////dr["basafe"] = "0.00000";
            ////    ////dr["monigv"] = "0.00000";
            ////    ////dr["mondoc"] = "0.00000";
            ////    //dr["todope"] = "0.00000"; //Si pasa--> "0.01000";
            ////    //dr["prcper"] = "0";

            ////    ////dr["mondoc"] = objE_DocumentoVenta.OperacionGratuita;//objE_DocumentoVenta.Total; //"22687.69000";
            ////    ////dr["mopedo"] = 0;

            ////    ////dr["corepe"] = "";
            ////    ////dr["prcper"] = "0";
            ////}


            facelecab.Rows.Add(dr);
            facelecab.TableName = "facelecab";

            DataSet dsCabecera = new DataSet();
            dsCabecera.Tables.Add(facelecab);

            #endregion

            #region "Detalle"

            DataTable faceledet = new DataTable();
            faceledet.Columns.Add("numruc");
            faceledet.Columns.Add("altido");
            faceledet.Columns.Add("sersun");
            faceledet.Columns.Add("numsun");
            faceledet.Columns.Add("nroitm");
            faceledet.Columns.Add("coduni");
            faceledet.Columns.Add("canped");
            faceledet.Columns.Add("codpro");
            faceledet.Columns.Add("nompro");
            faceledet.Columns.Add("valbas");
            faceledet.Columns.Add("mondsc");
            faceledet.Columns.Add("preuni");
            faceledet.Columns.Add("monigv");
            faceledet.Columns.Add("codafe");
            faceledet.Columns.Add("monisc");
            faceledet.Columns.Add("tipisc");
            faceledet.Columns.Add("prelis");
            faceledet.Columns.Add("valref");
            faceledet.Columns.Add("totuni");
            faceledet.Columns.Add("montot");
            faceledet.Columns.Add("monper");
            faceledet.Columns.Add("nomabr");
            faceledet.Columns.Add("eanbar");
            faceledet.Columns.Add("desdet");

            foreach (var item in lstTmpDocumentoVentaDetalle)
            {
                DataRow dr2;
                dr2 = faceledet.NewRow();
                dr2["numruc"] = objE_DocumentoVenta.Ruc;//Parametros.strEmpresaRuc;//"20330676826";
                dr2["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
                dr2["sersun"] = objE_DocumentoVenta.Serie;// "F001";
                dr2["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
                dr2["nroitm"] = item.Item; //"1";
                dr2["coduni"] = item.Abreviatura;//"UND";
                dr2["canped"] = item.Cantidad;// "1.00000";
                dr2["codpro"] = item.IdProducto;// "PB000001";
                //dr2["nompro"] = item.NombreProducto;// "ANTICIPO DE ORDEN DE COMPRA GG-0034-2016";
                dr2["nompro"] = item.NombreProducto.Replace("'","''");// "ANTICIPO DE ORDEN DE COMPRA GG-0034-2016";
                dr2["valbas"] = item.ValorUnitario;// "19226.86000";
                dr2["mondsc"] = item.Descuento;//Math.Round((Convert.ToDouble(item.Descuento) / Parametros.dblIGV), 2);///item.Descuento; //"0.00000";
                dr2["preuni"] = item.ValorUnitDscto;// Math.Round(((Convert.ToDouble(item.ValorVenta)/ Parametros.dblIGV)/ item.Cantidad),2) ;// "19226.86000";valor con descuento sin IGV
                dr2["monigv"] = item.Igv;  //(Convert.ToDouble(item.Cantidad) * (Convert.ToDouble(item.PrecioVenta) - ((Convert.ToDouble(item.PrecioVenta) / Parametros.dblIGV)))).ToString(); //"3460.83000";
                dr2["codafe"] = "10"; //Tipo de Afectación del IGV
                //dr2["codafe"] = item.CodAfeIGV; //Tipo de Afectación del IGV
                dr2["monisc"] = "0.00000";
                dr2["tipisc"] = "0";
                dr2["prelis"] = item.PrecioVenta;//"22687.69000";
                dr2["valref"] = "0.00000"; //Sólo si es gratuito
                dr2["totuni"] = item.TotalValorUnitDscto;// Math.Round((Convert.ToDouble(item.ValorVenta) / Parametros.dblIGV), 2);//item.TotalValor;// "19226.86000";
                dr2["montot"] = item.ValorVenta; //"22687.69000";
                dr2["monper"] = "0.00000";
                dr2["nomabr"] = "PRODUCTO";//"ANTICIPO DE ORDEN DE COMP";//??? DACTA
                dr2["eanbar"] = "";
                dr2["desdet"] = "";

                #region "Transferencia Gratuita"
                if (objE_DocumentoVenta.OperacionGratuita > 0)
                {
                    dr2["valbas"] = "0.00000";
                    dr2["mondsc"] = "0.00000";
                    dr2["preuni"] = "0.00000";
                    dr2["monigv"] = "0.00000";
                    dr2["codafe"] = "16"; //Tipo de Afectación del IGV
                    dr2["monisc"] = "0.00000";
                    dr2["tipisc"] = "0";
                    dr2["prelis"] = "0.00000";
                    dr2["valref"] = item.ValorUnitDscto; //Sólo si es gratuito
                    dr2["totuni"] = "0.00000";
                    dr2["montot"] = "0.00000";
                    dr2["monper"] = "0.00000";
                    dr2["nomabr"] = "PRODUCTO";//"ANTICIPO DE ORDEN DE COMP";//??? DACTA
                    dr2["eanbar"] = "";
                    dr2["desdet"] = "";
                }
                #endregion

                #region "Bonificaciones"
                if (item.CodAfeIGV == "15") //Ver iddoc=1230215 
                {
                    dr2["codafe"] = "15"; //Tipo de Afectación del IGV

                    //dr2["valbas"] = "0.00000";
                    //dr2["mondsc"] = "0.00000";
                    //dr2["preuni"] = "0.00000";
                    //dr2["monigv"] = "0.00000";
                    //dr2["codafe"] = "15"; //Tipo de Afectación del IGV
                    //dr2["monisc"] = "0.00000";
                    //dr2["tipisc"] = "0";
                    //dr2["prelis"] = "0.00000";
                    //dr2["valref"] = "0.00000"; 
                    //dr2["totuni"] = "0.00000";
                    //dr2["montot"] = "0.00000";
                    //dr2["monper"] = "0.00000";
                    //dr2["nomabr"] = "PRODUCTO";//"ANTICIPO DE ORDEN DE COMP";//??? DACTA
                    //dr2["eanbar"] = "";
                    //dr2["desdet"] = "";
                }
                #endregion


                //if (item.CodAfeIGV == "15") //Ver iddoc=1230215 
                //{
                //    dr2["codafe"] = "15"; //Tipo de Afectación del IGV
                //}

                //if (item.CodAfeIGV == "21") 
                //{
                //    dr2["valbas"] = "0.00000";
                //    dr2["mondsc"] = "0.00000";
                //    dr2["preuni"] = "0.00000";
                //    dr2["monigv"] = "0.00000";
                //    dr2["codafe"] = "21"; //Tipo de Afectación del IGV
                //    dr2["monisc"] = "0.00000";
                //    dr2["tipisc"] = "0";
                //    dr2["prelis"] = "0.00000";
                //    dr2["valref"] = "1.00000";//"0.00000"; //item.ValorUnitDscto; //Sólo si es gratuito
                //    dr2["totuni"] = "0.00000";
                //    dr2["montot"] = "0.00000";
                //    dr2["monper"] = "0.00000";
                //    dr2["nomabr"] = "PRODUCTO";//"ANTICIPO DE ORDEN DE COMP";//??? DACTA
                //    dr2["eanbar"] = "";
                //    dr2["desdet"] = "";
                //}


                faceledet.Rows.Add(dr2);
            }

            faceledet.TableName = "faceledet";

            DataSet dsDetalle = new DataSet();
            dsDetalle.Tables.Add(faceledet);

            #endregion

            #region "Correo"

            DataTable Eememifae = new DataTable();
            Eememifae.Columns.Add("numruc");
            Eememifae.Columns.Add("altido");
            Eememifae.Columns.Add("sersun");
            Eememifae.Columns.Add("numsun");
            Eememifae.Columns.Add("nroitm");
            Eememifae.Columns.Add("cemail");

            DataRow dr3;
            dr3 = Eememifae.NewRow();
            dr3["numruc"] = objE_DocumentoVenta.Ruc;// Parametros.strEmpresaRuc;//"20330676826";
            dr3["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            dr3["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr3["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr3["nroitm"] = "1";
            dr3["cemail"] = "sistemas@panoramahogar.com";

            Eememifae.Rows.Add(dr3);
            Eememifae.TableName = "eememifae";

            DataSet dsCorreo = new DataSet();
            dsCorreo.Tables.Add(Eememifae);

            #endregion

            #region "Adicional"

            DataTable faceleant = new DataTable();
            faceleant.Columns.Add("numruc");
            faceleant.Columns.Add("altido");
            faceleant.Columns.Add("sersun");
            faceleant.Columns.Add("numsun");
            faceleant.Columns.Add("nroitm");
            faceleant.Columns.Add("tidoan");
            faceleant.Columns.Add("docant");
            faceleant.Columns.Add("tidoem");
            faceleant.Columns.Add("nudoem");
            faceleant.Columns.Add("monant");

            DataRow dr4;
            dr4 = faceleant.NewRow();
            dr4["numruc"] = objE_DocumentoVenta.Ruc;//Parametros.strEmpresaRuc;//"20330676826";
            dr4["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            dr4["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr4["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr4["nroitm"] = "1";
            dr4["tidoan"] = "01";
            dr4["docant"] = objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero;//  "F001-00000001";
            dr4["tidoem"] = "6";//Ruc de Panorama
            dr4["nudoem"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;//"20330676826";
            dr4["monant"] = objE_DocumentoVenta.Total;//"22687.69000";

            faceleant.Rows.Add(dr4);
            faceleant.TableName = "faceleant";

            DataSet dsAdicional = new DataSet();
            dsAdicional.Tables.Add(faceleant);

            #endregion

            //string Cab1 = dsCabecera.GetXml();
            //string Cab2 = dsDetalle.GetXml();
            //string Cab3 = dsCorreo.GetXml();

            //string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", dsAdicional.GetXml(), "N"); v1
            //string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), dsCorreo.GetXml(), dsAdicional.GetXml(), "N"); v2
            //string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), dsCorreo.GetXml(), "<NewDataSet/>", "N"); //funcionando
            string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", "<NewDataSet/>", "N");

            if (MensajeService.ToUpper() == "OK")
            {
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                //objBL_DocumentoVenta.ActualizaSituacionPSE(objE_DocumentoVenta.IdEmpresa, IdDocumentoVenta, Parametros.intSitCorrectoPSE);
            }

            if (MensajeService.ToUpper().Contains("CO~20")) //Correcto
            {
                if (objE_DocumentoVenta.IdSituacionPSE == 0)
                {
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    //objBL_DocumentoVenta.ActualizaSituacionPSE(objE_DocumentoVenta.IdEmpresa, IdDocumentoVenta, Parametros.intSitCorrectoPSE);
                }
            }

            return MensajeService;

            //if (MensajeService.ToUpper() != "OK")
            //{
            //    //XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    //XtraMessageBox.Show("Documento enviado correctamente. " + MensajeService.ToUpper(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
            //    objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);
            //    Cargar();

            //    //if (XtraMessageBox.Show("Desea Imprimir el Comprobante", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    //{
            //    //    //ImpresionTicketElectronico("G");
            //    //    ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
            //    //}
            //}
            ////MessageBox.Show(WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", dsAdicional.GetXml(), "N"));
            ////txtObservacion.Text = dsCabecera.GetXml();

        }

        public string GrabarNotaCreditoIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);
            //mDocumentoVentaE = objE_DocumentoVenta;

            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

            #region "Datatable"
            DataTable facelecab = new DataTable();
            facelecab.Columns.Add("ipserver", Type.GetType("System.String"));
            facelecab.Columns.Add("instance", Type.GetType("System.String"));
            facelecab.Columns.Add("dbname", Type.GetType("System.String"));
            facelecab.Columns.Add("numruc", Type.GetType("System.String"));
            facelecab.Columns.Add("altido", Type.GetType("System.String"));
            facelecab.Columns.Add("sersun", Type.GetType("System.String"));
            facelecab.Columns.Add("numsun", Type.GetType("System.String"));
            facelecab.Columns.Add("fecemi", Type.GetType("System.String"));
            facelecab.Columns.Add("codmnd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidoid", Type.GetType("System.String"));
            facelecab.Columns.Add("numidn", Type.GetType("System.String"));
            facelecab.Columns.Add("nomcli", Type.GetType("System.String"));
            facelecab.Columns.Add("tidore", Type.GetType("System.String"));
            facelecab.Columns.Add("nudore", Type.GetType("System.String"));
            facelecab.Columns.Add("basafe", Type.GetType("System.String"));
            facelecab.Columns.Add("basina", Type.GetType("System.String"));
            facelecab.Columns.Add("basexo", Type.GetType("System.String"));
            facelecab.Columns.Add("mongra", Type.GetType("System.String"));
            facelecab.Columns.Add("mondsc", Type.GetType("System.String"));
            facelecab.Columns.Add("monigv", Type.GetType("System.String"));
            facelecab.Columns.Add("monisc", Type.GetType("System.String"));
            facelecab.Columns.Add("monotr", Type.GetType("System.String"));
            facelecab.Columns.Add("dscglo", Type.GetType("System.String"));
            facelecab.Columns.Add("monoca", Type.GetType("System.String"));
            facelecab.Columns.Add("mondoc", Type.GetType("System.String"));
            facelecab.Columns.Add("basper", Type.GetType("System.String"));
            facelecab.Columns.Add("monper", Type.GetType("System.String"));
            facelecab.Columns.Add("totdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("mopedo", Type.GetType("System.String"));
            facelecab.Columns.Add("todope", Type.GetType("System.String"));
            facelecab.Columns.Add("totant", Type.GetType("System.String"));
            facelecab.Columns.Add("cobide", Type.GetType("System.String"));
            facelecab.Columns.Add("ctadet", Type.GetType("System.String"));
            facelecab.Columns.Add("prcdet", Type.GetType("System.String"));
            facelecab.Columns.Add("mondet", Type.GetType("System.String"));
            facelecab.Columns.Add("codmot", Type.GetType("System.String"));
            facelecab.Columns.Add("tidomd", Type.GetType("System.String"));
            facelecab.Columns.Add("nudomd", Type.GetType("System.String"));
            facelecab.Columns.Add("fedomd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidove", Type.GetType("System.String"));
            facelecab.Columns.Add("nudove", Type.GetType("System.String"));
            facelecab.Columns.Add("tipcam", Type.GetType("System.String"));
            facelecab.Columns.Add("codcli", Type.GetType("System.String"));
            facelecab.Columns.Add("ubifis", Type.GetType("System.String"));
            facelecab.Columns.Add("dirfis", Type.GetType("System.String"));
            facelecab.Columns.Add("tiodre", Type.GetType("System.String"));
            facelecab.Columns.Add("nuodre", Type.GetType("System.String"));
            facelecab.Columns.Add("coddoc", Type.GetType("System.String"));
            facelecab.Columns.Add("numdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("tipped", Type.GetType("System.String"));
            facelecab.Columns.Add("numped", Type.GetType("System.String"));
            facelecab.Columns.Add("dester", Type.GetType("System.String"));
            facelecab.Columns.Add("ordcom", Type.GetType("System.String"));
            facelecab.Columns.Add("fecvct", Type.GetType("System.String"));
            facelecab.Columns.Add("observ", Type.GetType("System.String"));
            facelecab.Columns.Add("estreg", Type.GetType("System.String"));
            facelecab.Columns.Add("defopa", Type.GetType("System.String"));
            facelecab.Columns.Add("texglo", Type.GetType("System.String"));
            facelecab.Columns.Add("corepe", Type.GetType("System.String"));
            facelecab.Columns.Add("prcper", Type.GetType("System.String"));
            facelecab.Columns.Add("fecped", Type.GetType("System.String"));
            #endregion

            DataRow dr;
            dr = facelecab.NewRow();
            dr["ipserver"] = "panorama_interface";
            dr["instance"] = "postgres";
            dr["dbname"] = "ifac_panorama";
            dr["numruc"] = objE_DocumentoVenta.Ruc;//Parametros.strEmpresaRuc;
            dr["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;//"01";
            dr["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr["fecemi"] = objE_DocumentoVenta.Fecha;// "27/11/2017 10:00:00 a.m.";
            dr["codmnd"] = objE_DocumentoVenta.CodMoneda;//"USD";
            dr["tidoid"] = objE_DocumentoVenta.IdTipoIdentidad;// "6";
            dr["numidn"] = objE_DocumentoVenta.NumeroDocumento;// "20330676826"; //****ACTIVO Y HABIDO
            dr["nomcli"] = objE_DocumentoVenta.DescCliente.Replace("'", "''");// "PANORAMA DISTRIB";
            dr["tidore"] = "";
            dr["nudore"] = "";
            dr["basafe"] = objE_DocumentoVenta.SubTotal;// "19226.86000"; ??
            dr["basina"] = "0.00000";
            dr["basexo"] = "0.00000";
            dr["mongra"] = "0.00000"; //SÓLO SIN SON GRATUITAS
            dr["mondsc"] = objE_DocumentoVenta.Descuentos; //"0.00000";
            dr["monigv"] = objE_DocumentoVenta.Igv;//"3460.83000";
            dr["monisc"] = "0.00000";
            dr["monotr"] = "0.00000";
            dr["dscglo"] = "0.00000";//Descuentos globales
            dr["monoca"] = "0.00000";
            dr["mondoc"] = objE_DocumentoVenta.Total; //"22687.69000";
            dr["basper"] = "0.00000";
            dr["monper"] = "0.00000";
            dr["totdoc"] = "0.00000";
            dr["mopedo"] = "0.00000";
            dr["todope"] = objE_DocumentoVenta.Total;// "22687.69000";
            dr["totant"] = 0;// objE_DocumentoVenta.Total;//"22687.69000"; ANTICIPOS no va en NCV
            dr["cobide"] = "";
            dr["ctadet"] = "";
            dr["prcdet"] = "0.00000";
            dr["mondet"] = "0.00000";
            dr["codmot"] = objE_DocumentoVenta.CodigoNC;//"07";//MOTIVO DE DEVOLUCION --AGREGAR MAS
            dr["tidomd"] = objE_DocumentoVenta.IdConTipoComprobantePagoRef;
            dr["nudomd"] = objE_DocumentoVenta.SerieReferencia + "-" + objE_DocumentoVenta.NumeroReferencia;
            dr["fedomd"] = objE_DocumentoVenta.FechaReferencia;
            dr["tidove"] = "1";//Dni Vendedor - Ver caso Carnet de Extranjería
            dr["nudove"] = objE_DocumentoVenta.DniVendedor;//"42309349";
            dr["tipcam"] = objE_DocumentoVenta.TipoCambio;// "3.42100";
            dr["codcli"] = objE_DocumentoVenta.IdCliente;// "80-00-5089";
            dr["ubifis"] = objE_DocumentoVenta.IdUbigeoDom;// "110108";
            dr["dirfis"] = objE_DocumentoVenta.Direccion.Replace("'", "''"); ;//"AV.EL ZINC 271 URB.INSDUSTRIAL INFENTAS";
            dr["tiodre"] = "";
            dr["nuodre"] = "";
            dr["coddoc"] = "";
            dr["numdoc"] = "";
            dr["tipped"] = "NRO";
            dr["numped"] = objE_DocumentoVenta.NumeroPedido;// "000001";
            dr["dester"] = objE_DocumentoVenta.DescFormaPago;// "CONTADO CONTRA ENTREGA";
            dr["ordcom"] = objE_DocumentoVenta.Periodo.ToString() + "-" + objE_DocumentoVenta.NumeroPedido;// "GG-0034-2016";
            dr["fecvct"] = ""; //Consultar
            dr["observ"] = "";//"CONTROL: 22216 MERCADERIA ENTREGADA EN: T.C: 3.42100 VENDEDOR: EMMA GARCIA FECHA PEDIDO: 2017 - 06 - 19 FECHA ORD: 2017 - 06 - 19 - INCORPORADO AL REGIMEN DE AGENTES DE RETENCION DEL IGV SEGUN RS Nchar(176) 378 - 2013 SUNAT";
            dr["estreg"] = "CO";//??? a Dacta
            dr["defopa"] = "";
            dr["texglo"] = "";
            dr["corepe"] = "";
            dr["prcper"] = "0";
            dr["fecped"] = objE_DocumentoVenta.Fecha;// "27/11/2017 09:00:00 a.m.";

            facelecab.Rows.Add(dr);
            facelecab.TableName = "facelecab";

            DataSet dsCabecera = new DataSet();
            dsCabecera.Tables.Add(facelecab);

            #endregion

            #region "Detalle"

            DataTable faceledet = new DataTable();
            faceledet.Columns.Add("numruc");
            faceledet.Columns.Add("altido");
            faceledet.Columns.Add("sersun");
            faceledet.Columns.Add("numsun");
            faceledet.Columns.Add("nroitm");
            faceledet.Columns.Add("coduni");
            faceledet.Columns.Add("canped");
            faceledet.Columns.Add("codpro");
            faceledet.Columns.Add("nompro");
            faceledet.Columns.Add("valbas");
            faceledet.Columns.Add("mondsc");
            faceledet.Columns.Add("preuni");
            faceledet.Columns.Add("monigv");
            faceledet.Columns.Add("codafe");
            faceledet.Columns.Add("monisc");
            faceledet.Columns.Add("tipisc");
            faceledet.Columns.Add("prelis");
            faceledet.Columns.Add("valref");
            faceledet.Columns.Add("totuni");
            faceledet.Columns.Add("montot");
            faceledet.Columns.Add("monper");
            faceledet.Columns.Add("nomabr");
            faceledet.Columns.Add("eanbar");
            faceledet.Columns.Add("desdet");

            foreach (var item in lstTmpDocumentoVentaDetalle)
            {
                DataRow dr2;
                dr2 = faceledet.NewRow();
                dr2["numruc"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;//"20330676826";
                dr2["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
                dr2["sersun"] = objE_DocumentoVenta.Serie;// "F001";
                dr2["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
                dr2["nroitm"] = item.Item; //"1";
                dr2["coduni"] = item.Abreviatura;//"UND";
                dr2["canped"] = item.Cantidad;// "1.00000";
                dr2["codpro"] = item.IdProducto;// "PB000001";
                dr2["nompro"] = item.NombreProducto.Replace("'", "''");// "ANTICIPO DE ORDEN DE COMPRA GG-0034-2016";
                dr2["valbas"] = item.ValorUnitario;// "19226.86000";
                dr2["mondsc"] = item.Descuento;//Math.Round((Convert.ToDouble(item.Descuento) / Parametros.dblIGV), 2);///item.Descuento; //"0.00000";
                dr2["preuni"] = item.ValorUnitDscto;// Math.Round(((Convert.ToDouble(item.ValorVenta)/ Parametros.dblIGV)/ item.Cantidad),2) ;// "19226.86000";valor con descuento sin IGV
                dr2["monigv"] = item.Igv;  //(Convert.ToDouble(item.Cantidad) * (Convert.ToDouble(item.PrecioVenta) - ((Convert.ToDouble(item.PrecioVenta) / Parametros.dblIGV)))).ToString(); //"3460.83000";
                dr2["codafe"] = "10"; //Tipo de Afectación del IGV
                dr2["monisc"] = "0.00000";
                dr2["tipisc"] = "0";
                dr2["prelis"] = item.PrecioVenta;//"22687.69000";
                dr2["valref"] = "0.00000"; //Sólo si es gratuito
                dr2["totuni"] = item.TotalValorUnitDscto;// Math.Round((Convert.ToDouble(item.ValorVenta) / Parametros.dblIGV), 2);//item.TotalValor;// "19226.86000";
                dr2["montot"] = item.ValorVenta; //"22687.69000";
                dr2["monper"] = "0.00000";
                dr2["nomabr"] = "PRODUCTO";//"ANTICIPO DE ORDEN DE COMP";//??? DACTA
                dr2["eanbar"] = "";
                dr2["desdet"] = "";


                faceledet.Rows.Add(dr2);
            }

            faceledet.TableName = "faceledet";

            DataSet dsDetalle = new DataSet();
            dsDetalle.Tables.Add(faceledet);

            #endregion

            #region "Correo"

            DataTable Eememifae = new DataTable();
            Eememifae.Columns.Add("numruc");
            Eememifae.Columns.Add("altido");
            Eememifae.Columns.Add("sersun");
            Eememifae.Columns.Add("numsun");
            Eememifae.Columns.Add("nroitm");
            Eememifae.Columns.Add("cemail");

            DataRow dr3;
            dr3 = Eememifae.NewRow();
            dr3["numruc"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;//"20330676826";
            dr3["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            dr3["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr3["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr3["nroitm"] = "1";
            dr3["cemail"] = "sistemas@panoramahogar.com";

            Eememifae.Rows.Add(dr3);
            Eememifae.TableName = "eememifae";

            DataSet dsCorreo = new DataSet();
            dsCorreo.Tables.Add(Eememifae);

            #endregion

            #region "Adicional"

            DataTable faceleant = new DataTable();
            faceleant.Columns.Add("numruc");
            faceleant.Columns.Add("altido");
            faceleant.Columns.Add("sersun");
            faceleant.Columns.Add("numsun");
            faceleant.Columns.Add("nroitm");
            faceleant.Columns.Add("tidoan");
            faceleant.Columns.Add("docant");
            faceleant.Columns.Add("tidoem");
            faceleant.Columns.Add("nudoem");
            faceleant.Columns.Add("monant");

            DataRow dr4;
            dr4 = faceleant.NewRow();
            dr4["numruc"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;//"20330676826";
            dr4["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            dr4["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr4["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr4["nroitm"] = "1";
            dr4["tidoan"] = objE_DocumentoVenta.IdConTipoComprobantePagoRef;// "01";
            dr4["docant"] = objE_DocumentoVenta.SerieReferencia +"-"+ objE_DocumentoVenta.NumeroReferencia;//objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero;//  "F001-00000001";
            dr4["tidoem"] = "6";//Ruc de Panorama
            dr4["nudoem"] = objE_DocumentoVenta.Ruc;// Parametros.strEmpresaRuc;//"20330676826";EL ANTICIPO ????
            dr4["monant"] = 0;// objE_DocumentoVenta.Total;//"22687.69000";

            faceleant.Rows.Add(dr4);
            faceleant.TableName = "faceleant";

            DataSet dsAdicional = new DataSet();
            dsAdicional.Tables.Add(faceleant);

            #endregion

            string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", "<NewDataSet/>", "N");// dsAdicional.GetXml(), "N");
            //string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), dsCorreo.GetXml(), "<NewDataSet/>", "N");// dsAdicional.GetXml(), "N"); //Envío con correo
            
            if (MensajeService.ToUpper() == "OK")
            {
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                //objBL_DocumentoVenta.ActualizaSituacionPSE(objE_DocumentoVenta.IdEmpresa, IdDocumentoVenta, Parametros.intSitCorrectoPSE);
            }
            if (MensajeService.ToUpper().Contains("CO~20")) //Correcto
            {
                if (objE_DocumentoVenta.IdSituacionPSE == 0)
                {
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    //objBL_DocumentoVenta.ActualizaSituacionPSE(objE_DocumentoVenta.IdEmpresa, IdDocumentoVenta, Parametros.intSitCorrectoPSE);
                }
            }

            return MensajeService;

            //if (MensajeService.ToUpper() != "OK")
            //{
            //    XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
            //    objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);
            //    Cargar();
            //    //if (XtraMessageBox.Show("Desea Imprimir el Comprobante", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    //{
            //    //    //ImpresionTicketElectronico("G");
            //    //    ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
            //    //}
            //}
        }

        public string AnulaVentaIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);

            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);


            DataTable facelecab = new DataTable();
            facelecab.Columns.Add("ipserver", Type.GetType("System.String"));
            facelecab.Columns.Add("instance", Type.GetType("System.String"));
            facelecab.Columns.Add("dbname", Type.GetType("System.String"));
            facelecab.Columns.Add("numruc", Type.GetType("System.String"));
            facelecab.Columns.Add("altido", Type.GetType("System.String"));
            facelecab.Columns.Add("sersun", Type.GetType("System.String"));
            facelecab.Columns.Add("numsun", Type.GetType("System.String"));
            facelecab.Columns.Add("fecemi", Type.GetType("System.String"));
            facelecab.Columns.Add("codmnd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidoid", Type.GetType("System.String"));
            facelecab.Columns.Add("numidn", Type.GetType("System.String"));
            facelecab.Columns.Add("nomcli", Type.GetType("System.String"));
            facelecab.Columns.Add("tidore", Type.GetType("System.String"));
            facelecab.Columns.Add("nudore", Type.GetType("System.String"));
            facelecab.Columns.Add("basafe", Type.GetType("System.String"));
            facelecab.Columns.Add("basina", Type.GetType("System.String"));
            facelecab.Columns.Add("basexo", Type.GetType("System.String"));
            facelecab.Columns.Add("mongra", Type.GetType("System.String"));
            facelecab.Columns.Add("mondsc", Type.GetType("System.String"));
            facelecab.Columns.Add("monigv", Type.GetType("System.String"));
            facelecab.Columns.Add("monisc", Type.GetType("System.String"));
            facelecab.Columns.Add("monotr", Type.GetType("System.String"));
            facelecab.Columns.Add("dscglo", Type.GetType("System.String"));
            facelecab.Columns.Add("monoca", Type.GetType("System.String"));
            facelecab.Columns.Add("mondoc", Type.GetType("System.String"));
            facelecab.Columns.Add("basper", Type.GetType("System.String"));
            facelecab.Columns.Add("monper", Type.GetType("System.String"));
            facelecab.Columns.Add("totdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("mopedo", Type.GetType("System.String"));
            facelecab.Columns.Add("todope", Type.GetType("System.String"));
            facelecab.Columns.Add("totant", Type.GetType("System.String"));
            facelecab.Columns.Add("cobide", Type.GetType("System.String"));
            facelecab.Columns.Add("ctadet", Type.GetType("System.String"));
            facelecab.Columns.Add("prcdet", Type.GetType("System.String"));
            facelecab.Columns.Add("mondet", Type.GetType("System.String"));
            facelecab.Columns.Add("codmot", Type.GetType("System.String"));
            facelecab.Columns.Add("tidomd", Type.GetType("System.String"));
            facelecab.Columns.Add("nudomd", Type.GetType("System.String"));
            facelecab.Columns.Add("fedomd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidove", Type.GetType("System.String"));
            facelecab.Columns.Add("nudove", Type.GetType("System.String"));
            facelecab.Columns.Add("tipcam", Type.GetType("System.String"));
            facelecab.Columns.Add("codcli", Type.GetType("System.String"));
            facelecab.Columns.Add("ubifis", Type.GetType("System.String"));
            facelecab.Columns.Add("dirfis", Type.GetType("System.String"));
            facelecab.Columns.Add("tiodre", Type.GetType("System.String"));
            facelecab.Columns.Add("nuodre", Type.GetType("System.String"));
            facelecab.Columns.Add("coddoc", Type.GetType("System.String"));
            facelecab.Columns.Add("numdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("tipped", Type.GetType("System.String"));
            facelecab.Columns.Add("numped", Type.GetType("System.String"));
            facelecab.Columns.Add("dester", Type.GetType("System.String"));
            facelecab.Columns.Add("ordcom", Type.GetType("System.String"));
            facelecab.Columns.Add("fecvct", Type.GetType("System.String"));
            facelecab.Columns.Add("observ", Type.GetType("System.String"));
            facelecab.Columns.Add("estreg", Type.GetType("System.String"));
            facelecab.Columns.Add("defopa", Type.GetType("System.String"));
            facelecab.Columns.Add("texglo", Type.GetType("System.String"));
            facelecab.Columns.Add("corepe", Type.GetType("System.String"));
            facelecab.Columns.Add("prcper", Type.GetType("System.String"));
            facelecab.Columns.Add("fecped", Type.GetType("System.String"));

            DataRow dr;
            dr = facelecab.NewRow();
            dr["ipserver"] = "panorama_interface";
            dr["instance"] = "postgres";
            dr["dbname"] = "ifac_panorama";
            dr["numruc"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;
            dr["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;//"01";
            dr["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr["fecemi"] = objE_DocumentoVenta.Fecha;// "27/11/2017 10:00:00 a.m.";
            dr["codmnd"] = objE_DocumentoVenta.CodMoneda;//"USD";
            dr["tidoid"] = objE_DocumentoVenta.IdTipoIdentidad;// "6";
            dr["numidn"] = objE_DocumentoVenta.NumeroDocumento;// "20330676826"; //****ACTIVO Y HABIDO
            dr["nomcli"] = objE_DocumentoVenta.DescCliente.Replace("'", "''");// "PANORAMA DISTRIB";
            dr["tidore"] = "";
            dr["nudore"] = "";
            dr["basafe"] = objE_DocumentoVenta.SubTotal;// "19226.86000"; ??
            dr["basina"] = "0.00000";
            dr["basexo"] = "0.00000";
            dr["mongra"] = "0.00000"; //SÓLO SIN SON GRATUITAS
            dr["mondsc"] = objE_DocumentoVenta.Descuentos; //"0.00000";
            dr["monigv"] = objE_DocumentoVenta.Igv;//"3460.83000";
            dr["monisc"] = "0.00000";
            dr["monotr"] = "0.00000";
            dr["dscglo"] = "0.00000";//Descuentos globales
            dr["monoca"] = "0.00000";
            dr["mondoc"] = objE_DocumentoVenta.Total; //"22687.69000";
            dr["basper"] = "0.00000";
            dr["monper"] = "0.00000";
            dr["totdoc"] = "0.00000";
            dr["mopedo"] = "0.00000";
            dr["todope"] = objE_DocumentoVenta.Total;// "22687.69000";
            dr["totant"] = "0";//objE_DocumentoVenta.Total;//"22687.69000"; ANTICIPOS
            dr["cobide"] = "";
            dr["ctadet"] = "";
            dr["prcdet"] = "0.00000";
            dr["mondet"] = "0.00000";
            dr["codmot"] = "";
            dr["tidomd"] = "";
            dr["nudomd"] = "";
            dr["fedomd"] = "";
            dr["tidove"] = "1";//Ver caso Carnet de Extranjería
            dr["nudove"] = objE_DocumentoVenta.DniVendedor;//"42309349";
            dr["tipcam"] = objE_DocumentoVenta.TipoCambio;// "3.42100";
            dr["codcli"] = objE_DocumentoVenta.IdCliente;// "80-00-5089";
            dr["ubifis"] = objE_DocumentoVenta.IdUbigeoDom;// "110108";
            dr["dirfis"] = objE_DocumentoVenta.Direccion.Replace("'", "''"); ;//"AV.EL ZINC 271 URB.INSDUSTRIAL INFENTAS";
            dr["tiodre"] = "";
            dr["nuodre"] = "";
            dr["coddoc"] = "";
            dr["numdoc"] = "";
            dr["tipped"] = "NRO";
            dr["numped"] = objE_DocumentoVenta.NumeroPedido;// "000001";
            dr["dester"] = objE_DocumentoVenta.DescFormaPago;// "CONTADO CONTRA ENTREGA";
            dr["ordcom"] = objE_DocumentoVenta.Periodo.ToString() + "-" + objE_DocumentoVenta.NumeroPedido;// "GG-0034-2016";
            dr["fecvct"] = objE_DocumentoVenta.FechaVencimiento; //""  ; //Consultar //Fecha Vencimiento para créditos
            dr["observ"] = "";//"CONTROL: 22216 MERCADERIA ENTREGADA EN: T.C: 3.42100 VENDEDOR: EMMA GARCIA FECHA PEDIDO: 2017 - 06 - 19 FECHA ORD: 2017 - 06 - 19 - INCORPORADO AL REGIMEN DE AGENTES DE RETENCION DEL IGV SEGUN RS Nchar(176) 378 - 2013 SUNAT";
            dr["estreg"] = "AN";//CO = Correcto; AN= Anulado
            dr["defopa"] = "";
            dr["texglo"] = "";
            dr["corepe"] = "";
            dr["prcper"] = "0";
            dr["fecped"] = objE_DocumentoVenta.Fecha;// "27/11/2017 09:00:00 a.m.";

            facelecab.Rows.Add(dr);
            facelecab.TableName = "facelecab";

            DataSet dsCabecera = new DataSet();
            dsCabecera.Tables.Add(facelecab);

            #endregion

            #region "Detalle"

            DataTable faceledet = new DataTable();
            faceledet.Columns.Add("numruc");
            faceledet.Columns.Add("altido");
            faceledet.Columns.Add("sersun");
            faceledet.Columns.Add("numsun");
            faceledet.Columns.Add("nroitm");
            faceledet.Columns.Add("coduni");
            faceledet.Columns.Add("canped");
            faceledet.Columns.Add("codpro");
            faceledet.Columns.Add("nompro");
            faceledet.Columns.Add("valbas");
            faceledet.Columns.Add("mondsc");
            faceledet.Columns.Add("preuni");
            faceledet.Columns.Add("monigv");
            faceledet.Columns.Add("codafe");
            faceledet.Columns.Add("monisc");
            faceledet.Columns.Add("tipisc");
            faceledet.Columns.Add("prelis");
            faceledet.Columns.Add("valref");
            faceledet.Columns.Add("totuni");
            faceledet.Columns.Add("montot");
            faceledet.Columns.Add("monper");
            faceledet.Columns.Add("nomabr");
            faceledet.Columns.Add("eanbar");
            faceledet.Columns.Add("desdet");

            foreach (var item in lstTmpDocumentoVentaDetalle)
            {
                DataRow dr2;
                dr2 = faceledet.NewRow();
                dr2["numruc"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;//"20330676826";
                dr2["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
                dr2["sersun"] = objE_DocumentoVenta.Serie;// "F001";
                dr2["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
                dr2["nroitm"] = item.Item; //"1";
                dr2["coduni"] = item.Abreviatura;//"UND";
                dr2["canped"] = item.Cantidad;// "1.00000";
                dr2["codpro"] = item.IdProducto;// "PB000001";
                dr2["nompro"] = item.NombreProducto.Replace("'", "''");// "ANTICIPO DE ORDEN DE COMPRA GG-0034-2016";
                dr2["valbas"] = item.ValorUnitario;// "19226.86000";
                dr2["mondsc"] = item.Descuento;//Math.Round((Convert.ToDouble(item.Descuento) / Parametros.dblIGV), 2);///item.Descuento; //"0.00000";
                dr2["preuni"] = item.ValorUnitDscto;// Math.Round(((Convert.ToDouble(item.ValorVenta)/ Parametros.dblIGV)/ item.Cantidad),2) ;// "19226.86000";valor con descuento sin IGV
                dr2["monigv"] = item.Igv;  //(Convert.ToDouble(item.Cantidad) * (Convert.ToDouble(item.PrecioVenta) - ((Convert.ToDouble(item.PrecioVenta) / Parametros.dblIGV)))).ToString(); //"3460.83000";
                //dr2["codafe"] = "10"; //Tipo de Afectación del IGV
                dr2["monisc"] = "0.00000";
                dr2["tipisc"] = "0";
                dr2["prelis"] = item.PrecioVenta;//"22687.69000";
                dr2["valref"] = "0.00000"; //Sólo si es gratuito
                dr2["totuni"] = item.TotalValorUnitDscto;// Math.Round((Convert.ToDouble(item.ValorVenta) / Parametros.dblIGV), 2);//item.TotalValor;// "19226.86000";
                dr2["montot"] = item.ValorVenta; //"22687.69000";
                dr2["monper"] = "0.00000";
                dr2["nomabr"] = "PRODUCTO";//"ANTICIPO DE ORDEN DE COMP";//??? DACTA
                dr2["eanbar"] = "";
                dr2["desdet"] = "";

                #region "Bonificaciones"
                if (item.CodAfeIGV == "15") //Ver iddoc=1230215 
                {
                    dr2["codafe"] = "15"; //Tipo de Afectación del IGV
                }else
                {
                    dr2["codafe"] = "10"; //Tipo de Afectación del IGV
                }
                #endregion


                faceledet.Rows.Add(dr2);
            }

            faceledet.TableName = "faceledet";

            DataSet dsDetalle = new DataSet();
            dsDetalle.Tables.Add(faceledet);

            #endregion

            #region "Adicional"

            DataTable faceleant = new DataTable();
            faceleant.Columns.Add("numruc");
            faceleant.Columns.Add("altido");
            faceleant.Columns.Add("sersun");
            faceleant.Columns.Add("numsun");
            faceleant.Columns.Add("nroitm");
            faceleant.Columns.Add("tidoan");
            faceleant.Columns.Add("docant");
            faceleant.Columns.Add("tidoem");
            faceleant.Columns.Add("nudoem");
            faceleant.Columns.Add("monant");

            DataRow dr3;
            dr3 = faceleant.NewRow();
            dr3["numruc"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;//"20330676826";
            dr3["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            dr3["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr3["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr3["nroitm"] = "1";
            dr3["tidoan"] = "01";
            dr3["docant"] = objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero;//  "F001-00000001";
            dr3["tidoem"] = "6";//Ruc de Panorama
            dr3["nudoem"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;//"20330676826";
            dr3["monant"] = objE_DocumentoVenta.Total;//"22687.69000";

            faceleant.Rows.Add(dr3);
            faceleant.TableName = "faceleant";

            DataSet dsAdicional = new DataSet();
            dsAdicional.Tables.Add(faceleant);

            #endregion


            //string Cab1 = dsCabecera.GetXml();
            //string Cab2 = dsDetalle.GetXml();

            //string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", dsAdicional.GetXml(), "N"); V1
            string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", "<NewDataSet/>", "N");

            if (MensajeService.ToUpper() == "OK")
            {
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                //objBL_DocumentoVenta.ActualizaSituacionPSE(objE_DocumentoVenta.IdEmpresa, IdDocumentoVenta, Parametros.intSitAnuladoPSE);
            }

            return MensajeService;

            //if (MensajeService.ToUpper() != "OK")
            //{
            //    XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
            //    objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);

            //    XtraMessageBox.Show("Documento dado de baja correctamente. " + MensajeService.ToUpper(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

        public string AnulaNotaCreditoIntegrens(int IdEmpresa, int IdDocumentoVenta)
        {
            #region "Cabecera"

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaFE(IdEmpresa, IdDocumentoVenta);
            //mDocumentoVentaE = objE_DocumentoVenta;

            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);

            #region "Datatable"
            DataTable facelecab = new DataTable();
            facelecab.Columns.Add("ipserver", Type.GetType("System.String"));
            facelecab.Columns.Add("instance", Type.GetType("System.String"));
            facelecab.Columns.Add("dbname", Type.GetType("System.String"));
            facelecab.Columns.Add("numruc", Type.GetType("System.String"));
            facelecab.Columns.Add("altido", Type.GetType("System.String"));
            facelecab.Columns.Add("sersun", Type.GetType("System.String"));
            facelecab.Columns.Add("numsun", Type.GetType("System.String"));
            facelecab.Columns.Add("fecemi", Type.GetType("System.String"));
            facelecab.Columns.Add("codmnd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidoid", Type.GetType("System.String"));
            facelecab.Columns.Add("numidn", Type.GetType("System.String"));
            facelecab.Columns.Add("nomcli", Type.GetType("System.String"));
            facelecab.Columns.Add("tidore", Type.GetType("System.String"));
            facelecab.Columns.Add("nudore", Type.GetType("System.String"));
            facelecab.Columns.Add("basafe", Type.GetType("System.String"));
            facelecab.Columns.Add("basina", Type.GetType("System.String"));
            facelecab.Columns.Add("basexo", Type.GetType("System.String"));
            facelecab.Columns.Add("mongra", Type.GetType("System.String"));
            facelecab.Columns.Add("mondsc", Type.GetType("System.String"));
            facelecab.Columns.Add("monigv", Type.GetType("System.String"));
            facelecab.Columns.Add("monisc", Type.GetType("System.String"));
            facelecab.Columns.Add("monotr", Type.GetType("System.String"));
            facelecab.Columns.Add("dscglo", Type.GetType("System.String"));
            facelecab.Columns.Add("monoca", Type.GetType("System.String"));
            facelecab.Columns.Add("mondoc", Type.GetType("System.String"));
            facelecab.Columns.Add("basper", Type.GetType("System.String"));
            facelecab.Columns.Add("monper", Type.GetType("System.String"));
            facelecab.Columns.Add("totdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("mopedo", Type.GetType("System.String"));
            facelecab.Columns.Add("todope", Type.GetType("System.String"));
            facelecab.Columns.Add("totant", Type.GetType("System.String"));
            facelecab.Columns.Add("cobide", Type.GetType("System.String"));
            facelecab.Columns.Add("ctadet", Type.GetType("System.String"));
            facelecab.Columns.Add("prcdet", Type.GetType("System.String"));
            facelecab.Columns.Add("mondet", Type.GetType("System.String"));
            facelecab.Columns.Add("codmot", Type.GetType("System.String"));
            facelecab.Columns.Add("tidomd", Type.GetType("System.String"));
            facelecab.Columns.Add("nudomd", Type.GetType("System.String"));
            facelecab.Columns.Add("fedomd", Type.GetType("System.String"));
            facelecab.Columns.Add("tidove", Type.GetType("System.String"));
            facelecab.Columns.Add("nudove", Type.GetType("System.String"));
            facelecab.Columns.Add("tipcam", Type.GetType("System.String"));
            facelecab.Columns.Add("codcli", Type.GetType("System.String"));
            facelecab.Columns.Add("ubifis", Type.GetType("System.String"));
            facelecab.Columns.Add("dirfis", Type.GetType("System.String"));
            facelecab.Columns.Add("tiodre", Type.GetType("System.String"));
            facelecab.Columns.Add("nuodre", Type.GetType("System.String"));
            facelecab.Columns.Add("coddoc", Type.GetType("System.String"));
            facelecab.Columns.Add("numdoc", Type.GetType("System.String"));
            facelecab.Columns.Add("tipped", Type.GetType("System.String"));
            facelecab.Columns.Add("numped", Type.GetType("System.String"));
            facelecab.Columns.Add("dester", Type.GetType("System.String"));
            facelecab.Columns.Add("ordcom", Type.GetType("System.String"));
            facelecab.Columns.Add("fecvct", Type.GetType("System.String"));
            facelecab.Columns.Add("observ", Type.GetType("System.String"));
            facelecab.Columns.Add("estreg", Type.GetType("System.String"));
            facelecab.Columns.Add("defopa", Type.GetType("System.String"));
            facelecab.Columns.Add("texglo", Type.GetType("System.String"));
            facelecab.Columns.Add("corepe", Type.GetType("System.String"));
            facelecab.Columns.Add("prcper", Type.GetType("System.String"));
            facelecab.Columns.Add("fecped", Type.GetType("System.String"));
            #endregion

            DataRow dr;
            dr = facelecab.NewRow();
            dr["ipserver"] = "panorama_interface";
            dr["instance"] = "postgres";
            dr["dbname"] = "ifac_panorama";
            dr["numruc"] = objE_DocumentoVenta.Ruc;//Parametros.strEmpresaRuc;
            dr["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;//"01";
            dr["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr["fecemi"] = objE_DocumentoVenta.Fecha;// "27/11/2017 10:00:00 a.m.";
            dr["codmnd"] = objE_DocumentoVenta.CodMoneda;//"USD";
            dr["tidoid"] = objE_DocumentoVenta.IdTipoIdentidad;// "6";
            dr["numidn"] = objE_DocumentoVenta.NumeroDocumento;// "20330676826"; //****ACTIVO Y HABIDO
            dr["nomcli"] = objE_DocumentoVenta.DescCliente.Replace("'", "''");// "PANORAMA DISTRIB";
            dr["tidore"] = "";
            dr["nudore"] = "";
            dr["basafe"] = objE_DocumentoVenta.SubTotal;// "19226.86000"; ??
            dr["basina"] = "0.00000";
            dr["basexo"] = "0.00000";
            dr["mongra"] = "0.00000"; //SÓLO SIN SON GRATUITAS
            dr["mondsc"] = objE_DocumentoVenta.Descuentos; //"0.00000";
            dr["monigv"] = objE_DocumentoVenta.Igv;//"3460.83000";
            dr["monisc"] = "0.00000";
            dr["monotr"] = "0.00000";
            dr["dscglo"] = "0.00000";//Descuentos globales
            dr["monoca"] = "0.00000";
            dr["mondoc"] = objE_DocumentoVenta.Total; //"22687.69000";
            dr["basper"] = "0.00000";
            dr["monper"] = "0.00000";
            dr["totdoc"] = "0.00000";
            dr["mopedo"] = "0.00000";
            dr["todope"] = objE_DocumentoVenta.Total;// "22687.69000";
            dr["totant"] = 0;// objE_DocumentoVenta.Total;//"22687.69000"; ANTICIPOS no va en NCV
            dr["cobide"] = "";
            dr["ctadet"] = "";
            dr["prcdet"] = "0.00000";
            dr["mondet"] = "0.00000";
            dr["codmot"] = objE_DocumentoVenta.CodigoNC;//"07";//MOTIVO DE DEVOLUCION --AGREGAR MAS
            dr["tidomd"] = objE_DocumentoVenta.IdConTipoComprobantePagoRef;
            dr["nudomd"] = objE_DocumentoVenta.SerieReferencia + "-" + objE_DocumentoVenta.NumeroReferencia;
            dr["fedomd"] = objE_DocumentoVenta.FechaReferencia;
            dr["tidove"] = "1";//Dni Vendedor - Ver caso Carnet de Extranjería
            dr["nudove"] = objE_DocumentoVenta.DniVendedor;//"42309349";
            dr["tipcam"] = objE_DocumentoVenta.TipoCambio;// "3.42100";
            dr["codcli"] = objE_DocumentoVenta.IdCliente;// "80-00-5089";
            dr["ubifis"] = objE_DocumentoVenta.IdUbigeoDom;// "110108";
            dr["dirfis"] = objE_DocumentoVenta.Direccion.Replace("'", "''"); ;//"AV.EL ZINC 271 URB.INSDUSTRIAL INFENTAS";
            dr["tiodre"] = "";
            dr["nuodre"] = "";
            dr["coddoc"] = "";
            dr["numdoc"] = "";
            dr["tipped"] = "NRO";
            dr["numped"] = objE_DocumentoVenta.NumeroPedido;// "000001";
            dr["dester"] = objE_DocumentoVenta.DescFormaPago;// "CONTADO CONTRA ENTREGA";
            dr["ordcom"] = objE_DocumentoVenta.Periodo.ToString() + "-" + objE_DocumentoVenta.NumeroPedido;// "GG-0034-2016";
            dr["fecvct"] = ""; //Consultar
            dr["observ"] = "";//"CONTROL: 22216 MERCADERIA ENTREGADA EN: T.C: 3.42100 VENDEDOR: EMMA GARCIA FECHA PEDIDO: 2017 - 06 - 19 FECHA ORD: 2017 - 06 - 19 - INCORPORADO AL REGIMEN DE AGENTES DE RETENCION DEL IGV SEGUN RS Nchar(176) 378 - 2013 SUNAT";
            dr["estreg"] = "AN";//CO=Correcto, AN=Anulado
            dr["defopa"] = "";
            dr["texglo"] = "";
            dr["corepe"] = "";
            dr["prcper"] = "0";
            dr["fecped"] = objE_DocumentoVenta.Fecha;// "27/11/2017 09:00:00 a.m.";

            facelecab.Rows.Add(dr);
            facelecab.TableName = "facelecab";

            DataSet dsCabecera = new DataSet();
            dsCabecera.Tables.Add(facelecab);

            #endregion

            #region "Detalle"

            DataTable faceledet = new DataTable();
            faceledet.Columns.Add("numruc");
            faceledet.Columns.Add("altido");
            faceledet.Columns.Add("sersun");
            faceledet.Columns.Add("numsun");
            faceledet.Columns.Add("nroitm");
            faceledet.Columns.Add("coduni");
            faceledet.Columns.Add("canped");
            faceledet.Columns.Add("codpro");
            faceledet.Columns.Add("nompro");
            faceledet.Columns.Add("valbas");
            faceledet.Columns.Add("mondsc");
            faceledet.Columns.Add("preuni");
            faceledet.Columns.Add("monigv");
            faceledet.Columns.Add("codafe");
            faceledet.Columns.Add("monisc");
            faceledet.Columns.Add("tipisc");
            faceledet.Columns.Add("prelis");
            faceledet.Columns.Add("valref");
            faceledet.Columns.Add("totuni");
            faceledet.Columns.Add("montot");
            faceledet.Columns.Add("monper");
            faceledet.Columns.Add("nomabr");
            faceledet.Columns.Add("eanbar");
            faceledet.Columns.Add("desdet");

            foreach (var item in lstTmpDocumentoVentaDetalle)
            {
                DataRow dr2;
                dr2 = faceledet.NewRow();
                dr2["numruc"] = objE_DocumentoVenta.Ruc; //Parametros.strEmpresaRuc;//"20330676826";
                dr2["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
                dr2["sersun"] = objE_DocumentoVenta.Serie;// "F001";
                dr2["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
                dr2["nroitm"] = item.Item; //"1";
                dr2["coduni"] = item.Abreviatura;//"UND";
                dr2["canped"] = item.Cantidad;// "1.00000";
                dr2["codpro"] = item.IdProducto;// "PB000001";
                dr2["nompro"] = item.NombreProducto.Replace("'", "''");
                dr2["valbas"] = item.ValorUnitario;// "19226.86000";
                dr2["mondsc"] = item.Descuento;//Math.Round((Convert.ToDouble(item.Descuento) / Parametros.dblIGV), 2);///item.Descuento; //"0.00000";
                dr2["preuni"] = item.ValorUnitDscto;// Math.Round(((Convert.ToDouble(item.ValorVenta)/ Parametros.dblIGV)/ item.Cantidad),2) ;// "19226.86000";valor con descuento sin IGV
                dr2["monigv"] = item.Igv;  //(Convert.ToDouble(item.Cantidad) * (Convert.ToDouble(item.PrecioVenta) - ((Convert.ToDouble(item.PrecioVenta) / Parametros.dblIGV)))).ToString(); //"3460.83000";
                dr2["codafe"] = "10"; //Tipo de Afectación del IGV
                dr2["monisc"] = "0.00000";
                dr2["tipisc"] = "0";
                dr2["prelis"] = item.PrecioVenta;//"22687.69000";
                dr2["valref"] = "0.00000"; //Sólo si es gratuito
                dr2["totuni"] = item.TotalValorUnitDscto;// Math.Round((Convert.ToDouble(item.ValorVenta) / Parametros.dblIGV), 2);//item.TotalValor;// "19226.86000";
                dr2["montot"] = item.ValorVenta; //"22687.69000";
                dr2["monper"] = "0.00000";
                dr2["nomabr"] = "PRODUCTO";//"ANTICIPO DE ORDEN DE COMP";//??? DACTA
                dr2["eanbar"] = "";
                dr2["desdet"] = "";


                faceledet.Rows.Add(dr2);
            }

            faceledet.TableName = "faceledet";

            DataSet dsDetalle = new DataSet();
            dsDetalle.Tables.Add(faceledet);

            #endregion

            #region "Correo"

            DataTable Eememifae = new DataTable();
            Eememifae.Columns.Add("numruc");
            Eememifae.Columns.Add("altido");
            Eememifae.Columns.Add("sersun");
            Eememifae.Columns.Add("numsun");
            Eememifae.Columns.Add("nroitm");
            Eememifae.Columns.Add("cemail");

            DataRow dr3;
            dr3 = Eememifae.NewRow();
            dr3["numruc"] = objE_DocumentoVenta.Ruc;// Parametros.strEmpresaRuc;//"20330676826";
            dr3["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            dr3["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr3["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr3["nroitm"] = "1";
            dr3["cemail"] = "sistemas@panoramahogar.com";

            Eememifae.Rows.Add(dr3);
            Eememifae.TableName = "eememifae";

            DataSet dsCorreo = new DataSet();
            dsCorreo.Tables.Add(Eememifae);

            #endregion

            #region "Adicional"

            DataTable faceleant = new DataTable();
            faceleant.Columns.Add("numruc");
            faceleant.Columns.Add("altido");
            faceleant.Columns.Add("sersun");
            faceleant.Columns.Add("numsun");
            faceleant.Columns.Add("nroitm");
            faceleant.Columns.Add("tidoan");
            faceleant.Columns.Add("docant");
            faceleant.Columns.Add("tidoem");
            faceleant.Columns.Add("nudoem");
            faceleant.Columns.Add("monant");

            DataRow dr4;
            dr4 = faceleant.NewRow();
            dr4["numruc"] = objE_DocumentoVenta.Ruc;// Parametros.strEmpresaRuc;//"20330676826";
            dr4["altido"] = objE_DocumentoVenta.IdConTipoComprobantePago;// "01";
            dr4["sersun"] = objE_DocumentoVenta.Serie;// "F001";
            dr4["numsun"] = objE_DocumentoVenta.Numero;//"00000019";
            dr4["nroitm"] = "1";
            dr4["tidoan"] = objE_DocumentoVenta.IdConTipoComprobantePagoRef;// "01";
            dr4["docant"] = objE_DocumentoVenta.SerieReferencia + "-" + objE_DocumentoVenta.NumeroReferencia;//objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero;//  "F001-00000001";
            dr4["tidoem"] = "6";//Ruc de Panorama
            dr4["nudoem"] = objE_DocumentoVenta.Ruc;// Parametros.strEmpresaRuc;//"20330676826";EL ANTICIPO ????
            dr4["monant"] = 0;// objE_DocumentoVenta.Total;//"22687.69000";

            faceleant.Rows.Add(dr4);
            faceleant.TableName = "faceleant";

            DataSet dsAdicional = new DataSet();
            dsAdicional.Tables.Add(faceleant);

            #endregion

            //string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), "<NewDataSet/>", "<NewDataSet/>", "N");// dsAdicional.GetXml(), "N");
            string MensajeService = WS.sendBill(dsCabecera.GetXml(), dsDetalle.GetXml(), dsCorreo.GetXml(), "<NewDataSet/>", "N");// dsAdicional.GetXml(), "N");

            if (MensajeService.ToUpper() == "OK")
            {
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                //objBL_DocumentoVenta.ActualizaSituacionPSE(objE_DocumentoVenta.IdEmpresa, IdDocumentoVenta, Parametros.intSitAnuladoPSE);
            }

            return MensajeService;

            //if (MensajeService.ToUpper() != "OK")
            //{
            //    XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
            //    objBL_DocumentoVenta.ActualizaSituacionPSE(Parametros.intEmpresaId, IdDocumentoVenta, Parametros.intSitCorrectoPSE);
            //    Cargar();
            //    //if (XtraMessageBox.Show("Desea Imprimir el Comprobante", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    //{
            //    //    //ImpresionTicketElectronico("G");
            //    //    ImpresionElectronicaLocal(IdDocumentoVenta, Convert.ToInt32(cboDocumento.EditValue), "A4");
            //    //}
            //}
        }


    }
}
