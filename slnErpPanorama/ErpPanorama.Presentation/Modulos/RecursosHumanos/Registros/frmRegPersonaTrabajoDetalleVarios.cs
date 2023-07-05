using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPersonaTrabajoDetalleVarios : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PersonaTrabajoDetalleBE> mLista = new List<PersonaTrabajoDetalleBE>();

        public PersonaTrabajoDetalleBE oBE;

        //public int intCorrelativo = 0;

        public int IdPersonaTrabajo = 0;
        public int IdPersonaTrabajoDetalle = 0;
        public DateTime Fecha;
        public int IdTienda = 0;
        public int IdArea = 0;
        public string ApeNom = "";

        public int IdPersona = 0;
        public bool FlagApoyo = false;
        public bool bNuevo = false;

        #endregion

        #region "Eventos"

        public frmRegPersonaTrabajoDetalleVarios()
        {
            InitializeComponent();
        }

        private void frmRegPersonaTrabajoDetalleVarios_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(gcCboTienda, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            
            Cargar();

            List<TiendaBE> lstTienda = new List<TiendaBE>();
            lstTienda = new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCboTienda.DataSource = lstTienda;
            gcCboTienda.DisplayMember = "DescTienda";
            gcCboTienda.ValueMember = "IdTienda";
            gcCboTienda.PopupWidth = 400;

            gcCboIdArea.DataSource = CargarPuesto();
            gcCboIdArea.DisplayMember = "Descripcion";
            gcCboIdArea.ValueMember = "Id";
            

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //oBE = new PersonaTrabajoDetalleBE();
                //oBE.IdPersona = IdPersona;
                ////oBE.IdEmpresa = Parametros.intEmpresaId;
                ////oBE.IdPersonaTrabajo = IdPersonaTrabajo;
                ////oBE.IdPersonaTrabajoDetalle = IdPersonaTrabajoDetalle;
                //////oBE.Item = intCorrelativo;
                ////oBE.Fecha = Convert.ToDateTime(deFecha.EditValue);
                ////oBE.ApeNom = txtPersona.Text;
                ////oBE.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                ////oBE.DescTienda = cboTienda.Text;
                ////oBE.IdArea = Convert.ToInt32(cboArea.EditValue);
                ////oBE.DescArea = cboArea.Text;
                ////oBE.Importe = Convert.ToDecimal(txtImporte.EditValue);
                ////oBE.Observacion = txtObservacion.Text;
                //oBE.FlagApoyo = FlagApoyo;
                //oBE.FlagEstado = true;

                this.DialogResult = DialogResult.OK;

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
        private void Cargar()
        {
            mLista = new PersonaTrabajoDetalleBL().ListaApoyo(Parametros.intEmpresaId);
            gcPersonaTrabajoDetalle.DataSource = mLista;
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            lblTotalRegistros.Text = gvPersonaTrabajoDetalle.RowCount.ToString() + " Registros";
        }

        private DataTable CargarPuesto()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "ND";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "ALMACEN";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "CAJA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "DESPACHO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "RECEPCION";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "SEGURIDAD";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "SISTEMAS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "VENTAS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "VISUAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "ETIQUETADOR";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "AUXILIAR DE TIENDA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "ENCARGADO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "ENCARGADO ALMACEN";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 13;
            dr["Descripcion"] = "ENCARGADO DESPACHO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 14;
            dr["Descripcion"] = "ENCARGADO VISUAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 15;
            dr["Descripcion"] = "ENCARGADO TIENDA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 16;
            dr["Descripcion"] = "DISEÑO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 17;
            dr["Descripcion"] = "INVENTARIO";
            dt.Rows.Add(dr);
            return dt;
        }


        #endregion

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void InicializarModificar()
        {
            if (mLista.Count > 0)
            {
                int xposition = 0;

                frmRegPersonaTrabajoDetalleEdit movDetalle = new frmRegPersonaTrabajoDetalleEdit();
                //movDetalle.IdPersonaTrabajo = IdPersonaTrabajo;
                movDetalle.IdPersonaTrabajo = Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersonaTrabajo"));
                movDetalle.IdPersonaTrabajoDetalle = Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersonaTrabajoDetalle"));
                //movDetalle.intCorrelativo = Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdPersona = Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersona").ToString());
                movDetalle.ApeNom = gvPersonaTrabajoDetalle.GetFocusedRowCellValue("ApeNom").ToString();
                movDetalle.Fecha = Convert.ToDateTime(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("Fecha"));
                movDetalle.IdTienda = Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdTienda").ToString());
                movDetalle.IdArea = Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdArea").ToString());
                movDetalle.txtImporte.EditValue = gvPersonaTrabajoDetalle.GetFocusedRowCellValue("Importe").ToString();
                movDetalle.txtObservacion.EditValue = gvPersonaTrabajoDetalle.GetFocusedRowCellValue("Observacion");
                movDetalle.FlagApoyo = Convert.ToBoolean(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("FlagApoyo"));
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPersonaTrabajoDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "IdPersonaTrabajo", movDetalle.oBE.IdPersonaTrabajo);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "IdPersonaTrabajoDetalle", movDetalle.oBE.IdPersonaTrabajoDetalle);
                        //gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "Fecha", movDetalle.oBE.Fecha);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "IdPersona", movDetalle.oBE.IdPersona);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "ApeNom", movDetalle.oBE.ApeNom);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "IdTienda", movDetalle.oBE.IdTienda);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "DescTienda", movDetalle.oBE.DescTienda);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "IdArea", movDetalle.oBE.IdArea);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "DescArea", movDetalle.oBE.DescArea);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "Importe", movDetalle.oBE.Importe);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "Observacion", movDetalle.oBE.Observacion);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "FlagApoyo", movDetalle.oBE.FlagApoyo);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "FlagEstado", true);
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "TipoOper", 1);
                        gvPersonaTrabajoDetalle.UpdateCurrentRow();

                        //bNuevo = movDetalle.bNuevo;

                        //btnNuevo.Focus();
                    }
                }
            }
        }

        private void exportartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPersonalApoyo";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPersonaTrabajoDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void gvPersonaTrabajoDetalle_DoubleClick(object sender, EventArgs e)
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

        private void gvPersonaTrabajoDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }
    }
}