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
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPersonaTrabajoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<PersonaTrabajoBE> lstPersonaTrabajo;

        public List<CPersonaTrabajoDetalle> mListaPersonaTrabajoDetalleOrigen = new List<CPersonaTrabajoDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdPersonaTrabajo = 0;

        public int IdPersonaTrabajo
        {
            get { return _IdPersonaTrabajo; }
            set { _IdPersonaTrabajo = value; }
        }
        private bool bCargar = true;
        #endregion

        #region "Eventos"

        public frmRegPersonaTrabajoEdit()
        {
            InitializeComponent();
        }

        private void frmRegPersonaTrabajoEdit_Load(object sender, EventArgs e)
        {
            //deFecha.EditValue = DateTime.Now;

            List<TiendaBE> lstTienda = new List<TiendaBE>();
            lstTienda = new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcCboTienda.DataSource = lstTienda;
            gcCboTienda.DisplayMember = "DescTienda";
            gcCboTienda.ValueMember = "IdTienda";

            gcCboIdArea.DataSource = CargarPuesto();
            gcCboIdArea.DisplayMember = "Descripcion";
            gcCboIdArea.ValueMember = "Id";

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Lista Domingo y Feriado - Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Lista Domingo y Feriado - Modificar";

                PersonaTrabajoBE objE_PersonaTrabajo = new PersonaTrabajoBE();
                objE_PersonaTrabajo = new PersonaTrabajoBL().Selecciona(IdPersonaTrabajo);
                bCargar = false;
                deFecha.EditValue = objE_PersonaTrabajo.Fecha;
                deFechaIni.EditValue = objE_PersonaTrabajo.HoraInicio;
                deFechaFin.EditValue = objE_PersonaTrabajo.HoraFin;
                txtObservacion.EditValue = objE_PersonaTrabajo.Observacion;
                eliminartodotoolStripMenuItem.Visible = false;
                
            }
            CargaPersonaTrabajoDetalle();

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
            {
                gcPersonaTrabajoDetalle.ContextMenuStrip = mnuContextual;
                btnGrabar.Enabled = true;
            }
            else
            {
                nuevoToolStripMenuItem.Visible = false;
                modificarprecioToolStripMenuItem.Visible = false;
                eliminarToolStripMenuItem.Visible = false;
                eliminartodotoolStripMenuItem.Visible = false;
                ImportarrecuperaciontoolStripMenuItem.Visible = false;
                exportartoolStripMenuItem.Visible = false;
                //gcPersonaTrabajoDetalle.ContextMenuStrip = null;
                btnGrabar.Enabled = false;
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PersonaTrabajoBL objBL_PersonaTrabajo = new PersonaTrabajoBL();
                    PersonaTrabajoBE objPersonaTrabajo = new PersonaTrabajoBE();

                    objPersonaTrabajo.IdPersonaTrabajo = IdPersonaTrabajo;
                    objPersonaTrabajo.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPersonaTrabajo.HoraInicio = Convert.ToDateTime(deFechaIni.EditValue);
                    objPersonaTrabajo.HoraFin = Convert.ToDateTime(deFechaFin.EditValue);
                    objPersonaTrabajo.Observacion = txtObservacion.Text;
                    objPersonaTrabajo.FlagEstado = true;
                    objPersonaTrabajo.Usuario = Parametros.strUsuarioLogin;
                    objPersonaTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPersonaTrabajo.IdEmpresa = Parametros.intEmpresaId;

                    //Solciitud Producto Detalle
                    List<PersonaTrabajoDetalleBE> lstPersonaTrabajoDetalle = new List<PersonaTrabajoDetalleBE>();

                    foreach (var item in mListaPersonaTrabajoDetalleOrigen)
                    {
                        PersonaTrabajoDetalleBE objE_PersonaTrabajoDetalle = new PersonaTrabajoDetalleBE();
                        objE_PersonaTrabajoDetalle.IdPersonaTrabajoDetalle = item.IdPersonaTrabajoDetalle;
                        objE_PersonaTrabajoDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_PersonaTrabajoDetalle.IdPersonaTrabajo = IdPersonaTrabajo;
                        objE_PersonaTrabajoDetalle.IdPersona = item.IdPersona;
                        objE_PersonaTrabajoDetalle.Fecha = item.Fecha;
                        objE_PersonaTrabajoDetalle.IdTienda = item.IdTienda;
                        objE_PersonaTrabajoDetalle.IdArea = item.IdArea;
                        objE_PersonaTrabajoDetalle.Importe = item.Importe;
                        objE_PersonaTrabajoDetalle.Observacion = item.Observacion;
                        objE_PersonaTrabajoDetalle.FlagEstado = true;
                        objE_PersonaTrabajoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_PersonaTrabajoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PersonaTrabajoDetalle.TipoOper = item.TipoOper;
                        lstPersonaTrabajoDetalle.Add(objE_PersonaTrabajoDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_PersonaTrabajo.Inserta(objPersonaTrabajo, lstPersonaTrabajoDetalle);
                        
                    }
                    else
                    {
                        objBL_PersonaTrabajo.Actualiza(objPersonaTrabajo, lstPersonaTrabajoDetalle);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (deFecha.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar una Fecha.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmRegPersonaTrabajoDetalleEdit movDetalle = new frmRegPersonaTrabajoDetalleEdit();
                //int i = 0;
                //if (mListaPersonaTrabajoDetalleOrigen.Count > 0)
                //    i = mListaPersonaTrabajoDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                //movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                movDetalle.Fecha = Convert.ToDateTime(deFecha.EditValue);
                movDetalle.bNuevo = true;
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        gvPersonaTrabajoDetalle.Columns["IdTienda"].OptionsColumn.AllowEdit = true;
                        gvPersonaTrabajoDetalle.Columns["IdArea"].OptionsColumn.AllowEdit = true;
                        gvPersonaTrabajoDetalle.Columns["IdTienda"].OptionsColumn.AllowFocus = true;
                        gvPersonaTrabajoDetalle.Columns["IdArea"].OptionsColumn.AllowFocus = true;

                        if (mListaPersonaTrabajoDetalleOrigen.Count == 0)
                        {
                            gvPersonaTrabajoDetalle.AddNewRow();
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajo", movDetalle.oBE.IdPersonaTrabajo);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajoDetalle", movDetalle.oBE.IdPersonaTrabajoDetalle);
                            //gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Fecha", movDetalle.oBE.Fecha);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersona", movDetalle.oBE.IdPersona);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "ApeNom", movDetalle.oBE.ApeNom);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescTienda", movDetalle.oBE.DescTienda);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdArea", movDetalle.oBE.IdArea);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescArea", movDetalle.oBE.DescArea);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescCargo", movDetalle.oBE.DescCargo);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Importe", movDetalle.oBE.Importe);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "FlagApoyo", movDetalle.oBE.FlagApoyo);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPersonaTrabajoDetalle.UpdateCurrentRow();

                            //bNuevo = movDetalle.bNuevo;

                            CalculaTotales();
                            deFecha.Properties.ReadOnly = true;
                            //btnNuevo.Focus();

                            return;

                        }
                        if (mListaPersonaTrabajoDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaPersonaTrabajoDetalleOrigen.Where(oB => oB.IdPersona == movDetalle.oBE.IdPersona).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El Colaborador ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPersonaTrabajoDetalle.AddNewRow();
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajo", movDetalle.oBE.IdPersonaTrabajo);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajoDetalle", movDetalle.oBE.IdPersonaTrabajoDetalle);
                            //gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Fecha", movDetalle.oBE.Fecha);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersona", movDetalle.oBE.IdPersona);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "ApeNom", movDetalle.oBE.ApeNom);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescTienda", movDetalle.oBE.DescTienda);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdArea", movDetalle.oBE.IdArea);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescArea", movDetalle.oBE.DescArea);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescCargo", movDetalle.oBE.DescCargo);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Importe", movDetalle.oBE.Importe);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "FlagApoyo", movDetalle.oBE.FlagApoyo);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPersonaTrabajoDetalle.UpdateCurrentRow();

                            //bNuevo = movDetalle.bNuevo;

                            CalculaTotales();
                            deFecha.Properties.ReadOnly = true;
                            //btnNuevo.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void InicializarModificar()
        {
            if (mListaPersonaTrabajoDetalleOrigen.Count > 0)
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
                movDetalle.TipoOper = Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("TipoOper"));
                //movDetalle.bNuevo = true;
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
                        gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "TipoOper", movDetalle.oBE.TipoOper);
                        //gvPersonaTrabajoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvPersonaTrabajoDetalle.UpdateCurrentRow();

                        //bNuevo = movDetalle.bNuevo;

                        CalculaTotales();

                        //btnNuevo.Focus();
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //for (int i = 0; i < gvPersonaTrabajoDetalle.SelectedRowsCount; i++)
                //{
                //    int row = gvPersonaTrabajoDetalle.GetSelectedRows()[i];

                //    int IdPersonaTrabajoDetalle = 0;
                //    IdPersonaTrabajoDetalle = int.Parse(gvPersonaTrabajoDetalle.GetRowCellValue(row, "IdPersonaTrabajoDetalle").ToString());

                //    //if (gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersonaTrabajoDetalle") != null)
                //    //    IdPersonaTrabajoDetalle = int.Parse(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersonaTrabajoDetalle").ToString());
                //    ////int Item = 0;
                //    ////if (gvPersonaTrabajoDetalle.GetFocusedRowCellValue("Item") != null)
                //    ////    Item = int.Parse(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("Item").ToString());
                //    PersonaTrabajoDetalleBE objBE_PersonaTrabajoDetalle = new PersonaTrabajoDetalleBE();
                //    objBE_PersonaTrabajoDetalle.IdPersonaTrabajoDetalle = IdPersonaTrabajoDetalle;
                //    objBE_PersonaTrabajoDetalle.IdEmpresa = Parametros.intEmpresaId;
                //    objBE_PersonaTrabajoDetalle.Usuario = Parametros.strUsuarioLogin;
                //    objBE_PersonaTrabajoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                //    PersonaTrabajoDetalleBL objBL_PersonaTrabajoDetalle = new PersonaTrabajoDetalleBL();
                //    objBL_PersonaTrabajoDetalle.Elimina(objBE_PersonaTrabajoDetalle);
                //    gvPersonaTrabajoDetalle.DeleteRow(gvPersonaTrabajoDetalle.FocusedRowHandle);
                //    gvPersonaTrabajoDetalle.RefreshData();

                //}


                int IdPersonaTrabajoDetalle = 0;
                if (gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersonaTrabajoDetalle") != null)
                    IdPersonaTrabajoDetalle = int.Parse(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersonaTrabajoDetalle").ToString());
                //int Item = 0;
                //if (gvPersonaTrabajoDetalle.GetFocusedRowCellValue("Item") != null)
                //    Item = int.Parse(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("Item").ToString());
                PersonaTrabajoDetalleBE objBE_PersonaTrabajoDetalle = new PersonaTrabajoDetalleBE();
                objBE_PersonaTrabajoDetalle.IdPersonaTrabajoDetalle = IdPersonaTrabajoDetalle;
                objBE_PersonaTrabajoDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_PersonaTrabajoDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_PersonaTrabajoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                PersonaTrabajoDetalleBL objBL_PersonaTrabajoDetalle = new PersonaTrabajoDetalleBL();
                objBL_PersonaTrabajoDetalle.Elimina(objBE_PersonaTrabajoDetalle);
                gvPersonaTrabajoDetalle.DeleteRow(gvPersonaTrabajoDetalle.FocusedRowHandle);
                gvPersonaTrabajoDetalle.RefreshData();

                ////RegeneraItem
                //int i = 0;
                //int cuenta = 0;
                //foreach (var item in mListaPersonaTrabajoDetalleOrigen)
                //{
                //    item.Item = Convert.ToByte(cuenta + 1);
                //    cuenta++;
                //    i++;
                //}

                CalculaTotales();
                if (gvPersonaTrabajoDetalle.RowCount == 0) deFecha.Properties.ReadOnly = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void gvPersonaTrabajoDetalle_DoubleClick(object sender, EventArgs e)
        {
            //modificarprecioToolStripMenuItem_Click(sender, e);
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

        private void ImportarrecuperaciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PersonaCalendarioLaboralBE> lstPersonaCalendario = new List<PersonaCalendarioLaboralBE>();
            lstPersonaCalendario = new PersonaCalendarioLaboralBL().ListaRecuperacion(Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

            if (lstPersonaCalendario.Count > 0)
            {
                foreach (var item in lstPersonaCalendario)
                {
                    gvPersonaTrabajoDetalle.AddNewRow();
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajo", IdPersonaTrabajo);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajoDetalle", 0);
                    //gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Fecha", item.Fecha);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersona", item.IdPersona);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "ApeNom", item.ApeNom);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdTienda", item.IdTienda);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescTienda", item.DescTienda);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdArea", 1);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescArea", "ND");
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescCargo", item.DescCargo);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Importe", 0);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Observacion", "Recuperación del " + Convert.ToDateTime(item.FechaOrigen).ToShortDateString());
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "FlagApoyo", false);
                    gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    gvPersonaTrabajoDetalle.UpdateCurrentRow();
                }

                CalculaTotales();
            }
            //else
            //{
            //    //XtraMessageBox.Show("No exiten registros en este fecha, Verificar la fecha antes de importar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}


        }

        private void exportartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPersonaDomingoFeriado";
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

        private void gvPersonaTrabajoDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalculaTotales();
        }

        private void deFecha_EditValueChanged(object sender, EventArgs e)
        {
            if (deFecha.Text != "" & bCargar)
            {
                SeteaMovimientoDetalle();
                List<PersonaBE> lstPersonaCalendario = new List<PersonaBE>();
                lstPersonaCalendario = new PersonaBL().ListaDescanso(Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                if (lstPersonaCalendario.Count > 0)
                {
                    foreach (var item in lstPersonaCalendario)
                    {
                        gvPersonaTrabajoDetalle.AddNewRow();
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajo", IdPersonaTrabajo);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajoDetalle", 0);
                        //gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Fecha", deFecha.EditValue);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersona", item.IdPersona);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "ApeNom", item.ApeNom);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdTienda", item.IdTienda);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescTienda", item.DescTienda);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdArea", 0);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescArea", "ND");
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescCargo", item.DescCargo);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Importe", 0);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Observacion", "Día Normal");
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "FlagApoyo", item.FlagApoyo);
                        gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        gvPersonaTrabajoDetalle.UpdateCurrentRow();
                    }

                    CalculaTotales();


                }
                //else
                //{
                //    XtraMessageBox.Show("No exiten registros en este fecha, Verificar la fecha antes de importar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

                ImportarrecuperaciontoolStripMenuItem_Click(sender, e);

            }

        }

        #endregion

        #region "Metodos"
        private void SeteaMovimientoDetalle()
        {
            mListaPersonaTrabajoDetalleOrigen.Clear();
            bsListado.DataSource = mListaPersonaTrabajoDetalleOrigen;
            gcPersonaTrabajoDetalle.DataSource = bsListado;
            gcPersonaTrabajoDetalle.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (deFecha.Text == "")
            {
                strMensaje = strMensaje + "- Ingresar una Fecha válida.\n";
                flag = true;
            }


            foreach (CPersonaTrabajoDetalle item in mListaPersonaTrabajoDetalleOrigen)
            {
                var BuscarCodigo = mListaPersonaTrabajoDetalleOrigen.Where(oB => oB.ApeNom.ToUpper() == item.ApeNom.ToUpper()).ToList();
                if (BuscarCodigo.Count > 1)
                {
                    strMensaje = strMensaje + "- El personal ya existe.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaPersonaTrabajoDetalle()
        {
            List<PersonaTrabajoDetalleBE> lstTmpPersonaTrabajoDetalle = null;
            lstTmpPersonaTrabajoDetalle = new PersonaTrabajoDetalleBL().ListaTodosActivo(IdPersonaTrabajo);

            foreach (PersonaTrabajoDetalleBE item in lstTmpPersonaTrabajoDetalle)
            {
                CPersonaTrabajoDetalle objE_PersonaTrabajoDetalle = new CPersonaTrabajoDetalle();
                objE_PersonaTrabajoDetalle.IdEmpresa = item.IdEmpresa;
                objE_PersonaTrabajoDetalle.IdPersonaTrabajo = item.IdPersonaTrabajo;
                objE_PersonaTrabajoDetalle.IdPersonaTrabajoDetalle = item.IdPersonaTrabajoDetalle;
                //objE_PersonaTrabajoDetalle.Item = item.Item;
                objE_PersonaTrabajoDetalle.IdPersona = item.IdPersona;
                objE_PersonaTrabajoDetalle.ApeNom = item.ApeNom;
                objE_PersonaTrabajoDetalle.Fecha = item.Fecha;
                objE_PersonaTrabajoDetalle.IdTienda = item.IdTienda;
                objE_PersonaTrabajoDetalle.DescTienda = item.DescTienda;
                objE_PersonaTrabajoDetalle.IdArea = item.IdArea;
                objE_PersonaTrabajoDetalle.DescArea = item.DescArea;
                objE_PersonaTrabajoDetalle.DescCargo = item.DescCargo;
                objE_PersonaTrabajoDetalle.Importe = item.Importe;
                objE_PersonaTrabajoDetalle.Observacion = item.Observacion;
                objE_PersonaTrabajoDetalle.FlagApoyo = item.FlagApoyo;
                objE_PersonaTrabajoDetalle.Asistencia = item.Asistencia;
                objE_PersonaTrabajoDetalle.HoraIngreso = item.HoraIngreso;
                objE_PersonaTrabajoDetalle.HoraSalida = item.HoraSalida;
                objE_PersonaTrabajoDetalle.FlagEstado = true;
                objE_PersonaTrabajoDetalle.TipoOper = item.TipoOper;
                mListaPersonaTrabajoDetalleOrigen.Add(objE_PersonaTrabajoDetalle);
            }

            bsListado.DataSource = mListaPersonaTrabajoDetalleOrigen;
            gcPersonaTrabajoDetalle.DataSource = bsListado;
            gcPersonaTrabajoDetalle.RefreshDataSource();

            if (gvPersonaTrabajoDetalle.RowCount > 0)deFecha.Properties.ReadOnly = true;
            CalculaTotales();
        }

        private void CalculaTotales()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvPersonaTrabajoDetalle.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvPersonaTrabajoDetalle.GetRowCellValue(i, (gvPersonaTrabajoDetalle.Columns["Importe"])));
                }
                txtTotal.EditValue = decTotal;

                lblTotalRegistros.Text = gvPersonaTrabajoDetalle.RowCount.ToString() + " Registros";

                //decimal deTotal = 0;

                //if (gvPersonaTrabajoDetalle.RowCount > 0)
                //{
                //    foreach (var item in mListaPersonaTrabajoDetalleOrigen)
                //    {
                //          deTotal = deTotal + item.Importe;
                //    }

                //    txtTotal.EditValue = Math.Round(deTotal, 2);
                //    //deFecha.Properties.ReadOnly = true;
                //}
                //else
                //{
                //    txtTotal.EditValue = 0;
                //    //deFecha.Properties.ReadOnly = false;
                //}

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtApeNom_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void CargarBusqueda()
        {
            gcPersonaTrabajoDetalle.DataSource = mListaPersonaTrabajoDetalleOrigen.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtApeNom.Text.ToUpper())).ToList();
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

        public class CPersonaTrabajoDetalle
        {
            public Int32 IdPersonaTrabajoDetalle { get; set; }
            public Int32 IdPersonaTrabajo { get; set; }
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPersona { get; set; }
            public String ApeNom { get; set; }
            public DateTime Fecha { get; set; }
            public Int32 IdTienda { get; set; }
            public String DescTienda { get; set; }
            public Int32 IdArea { get; set; }
            public String DescArea { get; set; }
            public String DescCargo { get; set; }
            public Decimal Importe { get; set; }
            public String Observacion { get; set; }
            public Int32 IdAusencia { get; set; }
            public Boolean FlagApoyo { get; set; }
            public String Asistencia { get; set; }
            public String HoraIngreso { get; set; }
            public String HoraSalida { get; set; }
            public Boolean FlagEstado { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public Int32 TipoOper { get; set; }

            public CPersonaTrabajoDetalle()
            {

            }
        }

        private void importarapoyotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deFecha.Text == "")
            {
                XtraMessageBox.Show("Favor de ingresar la fecha de trabajo.", this.Text);
                return;
            }

            frmRegPersonaTrabajoDetalleVarios frm = new frmRegPersonaTrabajoDetalleVarios();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in frm.mLista)
                {
                    if (item.FlagEstado)
                    {
                        var Buscar = mListaPersonaTrabajoDetalleOrigen.Where(oB => oB.IdPersona == item.IdPersona).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("El Colaborador " + item.ApeNom + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            gvPersonaTrabajoDetalle.AddNewRow();
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajo", IdPersonaTrabajo);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersonaTrabajoDetalle", 0);
                            //gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Fecha", Convert.ToDateTime(deFecha.DateTime).ToShortDateString());
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdPersona", item.IdPersona);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "ApeNom", item.ApeNom);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdTienda", item.IdTienda);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescTienda", item.DescTienda);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "IdArea", item.IdArea);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "DescArea", item.DescArea);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Importe", item.Importe);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "Observacion", "Apoyo");
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "FlagApoyo", item.FlagApoyo);
                            gvPersonaTrabajoDetalle.SetRowCellValue(gvPersonaTrabajoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPersonaTrabajoDetalle.UpdateCurrentRow();
                        }


                    }

                }
                CalculaTotales();
                deFecha.Properties.ReadOnly = true;
            }
            
        }

        private void gvPersonaTrabajoDetalle_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPersonaTrabajoDetalle.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {

                    object objDocRetiroNac = View.GetRowCellValue(e.RowHandle, View.Columns["Asistencia"]); 
                    if (objDocRetiroNac != null)
                    {
                        string IdTipoDocumento = objDocRetiroNac.ToString();
                        if (IdTipoDocumento == "FALTÓ")
                        {
                            gvPersonaTrabajoDetalle.Columns["Asistencia"].AppearanceCell.BackColor = Color.Red;
                            gvPersonaTrabajoDetalle.Columns["Asistencia"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }
                        else
                        {
                            gvPersonaTrabajoDetalle.Columns["Asistencia"].AppearanceCell.BackColor = Color.White;
                            //gvPersonaTrabajoDetalle.Columns["Asistencia"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminartodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvPersonaTrabajoDetalle.SelectAll();
            gvPersonaTrabajoDetalle.DeleteSelectedRows();
            mListaPersonaTrabajoDetalleOrigen.Clear();


            //for (int i = 0; i < gvPersonaTrabajoDetalle.RowCount; i++)
            //{
            //    gvPersonaTrabajoDetalle.DeleteRow(i);
            //}
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReportePersonaTrabajoBE> lstReporte = null;
                lstReporte = new ReportePersonaTrabajoBL().ListadoFechaPersona(Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersona").ToString())
                                                                              , Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersonaTrabajo").ToString())
                                                                              , Convert.ToInt32(gvPersonaTrabajoDetalle.GetFocusedRowCellValue("IdPersonaTrabajoDetalle").ToString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptPersonaTrabajo = new RptVistaReportes();
                        objRptPersonaTrabajo.VerRptPersonaTrabajoSel(lstReporte);
                        objRptPersonaTrabajo.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}