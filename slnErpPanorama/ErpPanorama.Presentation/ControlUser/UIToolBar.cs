using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.ControlUser
{
    public partial class UIToolBar : UserControl
    {
        #region Variables

        //Variables para definir los accesos
        //***********************************************
        bool _LECTURA = false;
        bool _ADICION = false;
        bool _ACTUALIZACION = false;
        bool _ELIMINACION = false;
        bool _IMPRESION = false;
        //***********************************************

        //Declaracion de delegados para controlar los botones       
        public delegate void delegateNewClick();
        public delegate void delegateEditClick();
        public delegate void delegateDeleteClick();
        public delegate void delegateRefreshClick();
        public delegate void delegatePrintClick();
        public delegate void delegateExportClick();
        public delegate void delegateExitClick();

        //Declaracion de eventos       
        public event delegateNewClick NewClick;
        public event delegateEditClick EditClick;
        public event delegateDeleteClick DeleteClick;
        public event delegateRefreshClick RefreshClick;
        public event delegatePrintClick PrintClick;
        public event delegateExportClick ExportClick;
        public event delegateExitClick ExitClick;

        string _Ensamblado = "";

        public string Ensamblado
        {
            get { return _Ensamblado; }
            set 
            { 
                _Ensamblado = value;
                if (Ensamblado != "")
                {
                    Accesos(Ensamblado);
                }
            }
        }

        #endregion

        #region Eventos

        public UIToolBar()
        {
            InitializeComponent();
        }

        private void UIToolBar_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_ADICION == false)
            {
                XtraMessageBox.Show("No cuenta con el permiso de agregar registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NewClick != null)
                NewClick();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_ACTUALIZACION == false)
            {
                XtraMessageBox.Show("No cuenta con el permiso de modificar registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EditClick != null)
                EditClick();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_ELIMINACION == false)
            {
                XtraMessageBox.Show("No cuenta con el permiso de eliminar registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DeleteClick != null)
                DeleteClick();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if (RefreshClick != null)
                RefreshClick();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_IMPRESION == false)
            {
                XtraMessageBox.Show("No cuenta con el permiso de imprimir registros.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PrintClick != null)
                PrintClick();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (ExportClick != null)
                ExportClick();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (ExitClick != null)
                ExitClick();
        }

        #endregion

        #region Metodos

        void Accesos(string Ensamblado)
        {
            AccesoUsuarioBE PermisoAcceso = Parametros.pListaPermisoAcceso.Find(delegate(AccesoUsuarioBE _Acc)
            {
                if (_Acc.Ensamblado == Ensamblado)
                {
                    return true;
                }
                return false;
            });

            if (PermisoAcceso != null)
            {
                _LECTURA = PermisoAcceso.FlagLectura;
                _ADICION = PermisoAcceso.FlagAdicion;
                _ACTUALIZACION = PermisoAcceso.FlagActualizacion;
                _ELIMINACION = PermisoAcceso.FlagEliminacion;
                _IMPRESION = PermisoAcceso.FlagImpresion;
            }
        }

        #endregion

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
