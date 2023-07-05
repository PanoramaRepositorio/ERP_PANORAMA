using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegAnulacionVentas : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        
        #endregion

        #region "Eventos"

        public frmRegAnulacionVentas()
        {
            InitializeComponent();
        }

        private void frmRegAnulacionVentas_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocTicketBoleta;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdAlmacen = 0;
                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumero.Text.Trim());
                if (objE_DocumentoVenta == null)
                {
                    XtraMessageBox.Show("El documento de venta no existe, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Verificamos si tiene Pedido
                    if (objE_DocumentoVenta.IdPedido != null)
                    {
                        DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                        objBL_DocumentoVenta.Elimina(objE_DocumentoVenta);
                        XtraMessageBox.Show("El Documento de venta se anuló correctamente.\nEl Pedido se anuló correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XtraMessageBox.Show("POR FAVOR VERIFIQUE LA NUMERACIÓN CORRELATIVA \n" + "PARA QUE VUELVA A IMPRIMIR OTRO DOCUMENTO DE VENTA..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSerie.Text = "";
                        txtNumero.Text = "";
                    }
                    else
                    {

                        //Traemos el detalle del documento
                        List<DocumentoVentaDetalleBE> lstDetalle = null;
                        lstDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(objE_DocumentoVenta.IdDocumentoVenta);
                        foreach (var item in lstDetalle)
                        {
                            List<KardexBE> lstKardex = null;
                            lstKardex = new KardexBL().Selecciona(objE_DocumentoVenta.IdEmpresa, Convert.ToInt32(item.IdKardex));
                            if (lstKardex.Count > 0)
                            {
                                IdAlmacen = lstKardex[0].IdAlmacen;
                            }
                        }


                        DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                        objE_DocumentoVenta.IdAlmacen = IdAlmacen;
                        objBL_DocumentoVenta.EliminaAutoservicio(objE_DocumentoVenta);
                        XtraMessageBox.Show("El documento de venta se anuló correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XtraMessageBox.Show("POR FAVOR VERIFIQUE LA NUMERACIÓN CORRELATIVA \n" + "PARA QUE VUELVA A IMPRIMIR OTRO DOCUMENTO DE VENTA..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSerie.Text = "";
                        txtNumero.Text = "";
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        #endregion

        
    }
}