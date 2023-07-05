using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConControlAuxiliar : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MovimientoPedidoBE> mLista = new List<MovimientoPedidoBE>();

        private int IdProducto = 0;
        


        #endregion

        #region "Eventos"

        public frmConControlAuxiliar()
        {
            InitializeComponent();
        }

        private void frmConControlAuxiliar_Load(object sender, EventArgs e)
        {
            Cargar();
            
        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

       
        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaPedidoPersonal";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPedido.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new MovimientoPedidoBL().ListaPersonalPickingDisponible(Parametros.intEmpresaId, DateTime.Now.Date);
            gcPedido.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            //if (gvPedido.RowCount > 0)
            //{
            //    PedidoBE objPedido = new PedidoBE();
            //    objPedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

            //    frmRegPedidoEdit objManPedidoEdit = new frmRegPedidoEdit();
            //    objManPedidoEdit.pOperacion = frmRegPedidoEdit.Operacion.Modificar;
            //    objManPedidoEdit.IdPedido = objPedido.IdPedido;
            //    objManPedidoEdit.StartPosition = FormStartPosition.CenterParent;
            //    objManPedidoEdit.ShowDialog();

            //    Cargar();
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo editar");
            //}
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        #endregion

        private void gvPedido_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPedido.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["CantidadPedido"]);
                    if (objDocRetiro != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento > 0)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            //gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor = Color.Red;
                            //gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PersonaBL objBL_Persona = new PersonaBL();
                    objBL_Persona.ActualizaDisponibilidad(frm._Be.IdPersona, 1);

                    XtraMessageBox.Show("Personal agregado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();                            
                }
             
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    if (XtraMessageBox.Show("Esta seguro de Retirar al personal de esta lista?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Validar Periodo
                        int IdPersona;
                        IdPersona = Int32.Parse(gvPedido.GetRowCellValue(gvPedido.FocusedRowHandle, "IdPersona").ToString());

                        PersonaBL objBL_Persona = new PersonaBL();
                        objBL_Persona.ActualizaDisponibilidad(IdPersona, 0);

                        XtraMessageBox.Show("Retirado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cargar();
            //IdProducto = IdProducto + 1;
            //label1.Text = IdProducto.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 1)
            {
                IdProducto = 0;
                timer1.Enabled = true;
                timer1.Interval = Convert.ToInt32(1000) * Convert.ToInt32(numericUpDown1.Value);
                label1.Text = "ACTIVO";
            }
            else
            {
                timer1.Enabled = false;
                label1.Text = "DETENIDO";
            }
        }


    }
}