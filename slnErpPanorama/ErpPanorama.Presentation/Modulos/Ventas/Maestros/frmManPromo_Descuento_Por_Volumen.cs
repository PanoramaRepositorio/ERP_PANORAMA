using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManPromo_Descuento_Por_Volumen : DevExpress.XtraEditors.XtraForm
    {

        private List<PromocionVolumenBE> mLista = new List<PromocionVolumenBE>();
        private List<PromocionVolumenBE> mLista2 = new List<PromocionVolumenBE>();
        public frmManPromo_Descuento_Por_Volumen()
        {
            InitializeComponent();
        }

        private void Cargar()
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPageTienda)
            {
                mLista = new PromocionVolumenBL().ListaFecha(Parametros.intEmpresaId, true, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                gcPromocionVolumen.DataSource = mLista;
            }
            else //Eliminados
            {
                mLista2 = new PromocionVolumenBL().ListaFecha(Parametros.intEmpresaId, false, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                gcPromocionTemporal2.DataSource = mLista2;
            }
        }

        private void frmManPromo_Descuento_Por_Volumen_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = Convert.ToDateTime("01/01/" + Parametros.intPeriodo);
            deHasta.EditValue = Convert.ToDateTime("31/12/" + Parametros.intPeriodo);
            deDesde2.EditValue = Convert.ToDateTime("01/01/" + Parametros.intPeriodo);
            deHasta2.EditValue = Convert.ToDateTime("31/12/" + Parametros.intPeriodo);
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPromo_Descuento_Por_VolumenEdit objManPromocionTemporal = new frmManPromo_Descuento_Por_VolumenEdit();
                //objManPromocionTemporal. = mLista;
                objManPromocionTemporal.pOperacion = frmManPromo_Descuento_Por_VolumenEdit.Operacion.Nuevo;
                objManPromocionTemporal.IdPromocionVolumen = 0;
                objManPromocionTemporal.StartPosition = FormStartPosition.CenterParent;
                if (objManPromocionTemporal.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvPromocionVolumen_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }


        public void InicializarModificar()
        {
            if (gvPromocionVolumen.RowCount > 0)
            {
                PromocionVolumenBE objPromocionVolumen = new PromocionVolumenBE();
                objPromocionVolumen.IdPromocionVolumen = int.Parse(gvPromocionVolumen.GetFocusedRowCellValue("IdPromocionVolumen").ToString());
                objPromocionVolumen.IdEmpresa = int.Parse(gvPromocionVolumen.GetFocusedRowCellValue("IdEmpresa").ToString());
                objPromocionVolumen.DescPromocionVolumen = gvPromocionVolumen.GetFocusedRowCellValue("DescPromocionVolumen").ToString();
                objPromocionVolumen.IdTipoCliente = int.Parse(gvPromocionVolumen.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objPromocionVolumen.IdFormaPago = int.Parse(gvPromocionVolumen.GetFocusedRowCellValue("IdFormaPago").ToString());
                objPromocionVolumen.IdTienda = int.Parse(gvPromocionVolumen.GetFocusedRowCellValue("IdTienda").ToString());
                objPromocionVolumen.IdTipoVenta = int.Parse(gvPromocionVolumen.GetFocusedRowCellValue("IdTipoVenta").ToString());
                objPromocionVolumen.FechaInicio = DateTime.Parse(gvPromocionVolumen.GetFocusedRowCellValue("FechaInicio").ToString());
                objPromocionVolumen.FechaFin = DateTime.Parse(gvPromocionVolumen.GetFocusedRowCellValue("FechaFin").ToString());
                objPromocionVolumen.FlagContado = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagContado").ToString());
                objPromocionVolumen.FlagCFrabricacion = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagCFrabricacion").ToString());
                objPromocionVolumen.FlagAplicaCombinacion = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagAplicaCombinacion").ToString());
                objPromocionVolumen.FlagAplicaxCodigo = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagAplicaxCodigo").ToString());
                objPromocionVolumen.FlagContraentrega = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagContraentrega").ToString());
                objPromocionVolumen.FlagCopagan = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagCopagan").ToString());
                objPromocionVolumen.FlagObsequio = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagObsequio").ToString());
                objPromocionVolumen.FlagAsaf = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagAsaf").ToString());
                objPromocionVolumen.FlagClienteMayorista = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagClienteMayorista").ToString());
                objPromocionVolumen.FlagClienteFinal = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagClienteFinal").ToString());
                objPromocionVolumen.FlagUcayali = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagUcayali").ToString());
                objPromocionVolumen.FlagAndahuaylas = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagAndahuaylas").ToString());
                objPromocionVolumen.FlagPrescott = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagPrescott").ToString());
                objPromocionVolumen.FlagAviacion = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagAviacion").ToString());
                objPromocionVolumen.FlagMegaplaza = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagMegaplaza").ToString());
                objPromocionVolumen.FlagWeb = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagWeb").ToString());
                objPromocionVolumen.FechaInicioImpresion = DateTime.Parse(gvPromocionVolumen.GetFocusedRowCellValue("FechaInicioImpresion").ToString());
                objPromocionVolumen.FechaFinImpresion = DateTime.Parse(gvPromocionVolumen.GetFocusedRowCellValue("FechaFinImpresion").ToString());
                objPromocionVolumen.FlagEstado = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagEstado").ToString());
                objPromocionVolumen.FlagAviacion2 = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagAviacion2").ToString());
                objPromocionVolumen.FlagSanMiguel = Convert.ToBoolean(gvPromocionVolumen.GetFocusedRowCellValue("FlagSanMiguel").ToString());

                frmManPromo_Descuento_Por_VolumenEdit objManPromocionVolumenlEdit = new frmManPromo_Descuento_Por_VolumenEdit();
                objManPromocionVolumenlEdit.pOperacion = frmManPromo_Descuento_Por_VolumenEdit.Operacion.Modificar;
                objManPromocionVolumenlEdit.IdPromocionVolumen = objPromocionVolumen.IdPromocionVolumen;
                objManPromocionVolumenlEdit.pPromocionVolumenBE = objPromocionVolumen;
                objManPromocionVolumenlEdit.StartPosition = FormStartPosition.CenterParent;
                if (objManPromocionVolumenlEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvPromocionVolumen.GetFocusedRowCellValue("IdPromocionVolumen").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione PromocionVolumen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void tlbMenu_DeleteClick()
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPageTienda)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarIngreso())
                        {
                            PromocionVolumenBE objE_PromocionVolumen = new PromocionVolumenBE();
                            objE_PromocionVolumen.IdPromocionVolumen = int.Parse(gvPromocionVolumen.GetFocusedRowCellValue("IdPromocionVolumen").ToString());
                            objE_PromocionVolumen.Usuario = Parametros.strUsuarioLogin;
                            objE_PromocionVolumen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_PromocionVolumen.IdEmpresa = Parametros.intEmpresaId;

                            PromocionVolumenBL objBL_PromocionVolumen= new PromocionVolumenBL();
                            objBL_PromocionVolumen.Elimina(objE_PromocionVolumen);
                            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
                    }
                    Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("La promoción ya está eliminada, a donde más lo vas a enviar!!!\nSi Ud. desea activar la promoción tiene que usar las esferas del dragón(Sistemas).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
