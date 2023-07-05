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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManAgenciaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<AgenciaBE> lstAgencia;
        public List<CAgenciaOficina> mListaAgenciaOficinaOrigen = new List<CAgenciaOficina>();
        
        //public List<CAgenciaOficina> mListaAgenciaOficinaOrigen = new List<CAgenciaOficina>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public AgenciaBE pAgenciaBE { get; set; }

        int _IdAgencia = 0;

        public int IdAgencia
        {
            get { return _IdAgencia; }
            set { _IdAgencia = value; }
        }

        //public string NumeroDocumento { get; set; }
        //public string DescAgencia { get; set; }
        //public string AbrevDocimicilio { get; set; }
        //public string Direccion { get; set; }
        //public int IdClasificacionAgencia { get; set; }
        //public string TipoClasificacion { get; set; }

        #endregion

        #region "Eventos"

        public frmManAgenciaEdit()
        {
            InitializeComponent();
        }

        private void frmManAgenciaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Agencia Final - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Agencia Final - Modificar";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                //AgenciaBE objE_Agencia = new AgenciaBE();

                //objE_Agencia = new AgenciaBL().Selecciona(Parametros.intEmpresaId, IdAgencia);

                txtNumeroDocumento.EditValue = pAgenciaBE.Ruc.ToString().Trim();
                txtDescripcion.EditValue = pAgenciaBE.DescAgencia;

                if (pAgenciaBE.IdUbigeo.Trim() != "")
                    IdDepartamento = pAgenciaBE.IdUbigeo.Substring(0, 2);
                cboDepartamento.EditValue = IdDepartamento;
                if (pAgenciaBE.IdUbigeo.Trim() != "")
                    IdProvincia = pAgenciaBE.IdUbigeo.Substring(2, 2);
                cboProvincia.EditValue = IdProvincia;
                if (pAgenciaBE.IdUbigeo.Trim() != "")
                    IdDistrito = pAgenciaBE.IdUbigeo.Substring(4, 2);
                cboDistrito.EditValue = IdDistrito;

                txtDireccion.EditValue = pAgenciaBE.Direccion;
                txtReferencia.EditValue = pAgenciaBE.Referencia;
                txtTelefono.EditValue = pAgenciaBE.Telefono;
                txtEmail.EditValue = pAgenciaBE.Email;
                txtContacto.EditValue = pAgenciaBE.Contacto;
                txtPaginaWeb.EditValue = pAgenciaBE.PaginaWeb;
                txtObservacion.Text = pAgenciaBE.Observacion;
            }

            //CargaAgenciaOficina();

            txtNumeroDocumento.Select();

        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }
        }

        //private void nuevoAgenciaOficinaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        gvAgenciaOficina.AddNewRow();
        //        if (pOperacion == Operacion.Modificar)
        //        {
        //            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
        //            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "IdAgenciaOficina", 0);
        //        }
        //        else
        //        {
        //            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
        //            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "IdAgenciaOficina", 0);
        //        }
        //        gvAgenciaOficina.FocusedColumn = gvAgenciaOficina.Columns["Email"];
        //        gvAgenciaOficina.ShowEditor();

        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void eliminarAgenciaOficinaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int IdAgenciaOficina = 0;
        //        IdAgenciaOficina = int.Parse(gvAgenciaOficina.GetFocusedRowCellValue("IdAgenciaOficina").ToString());
        //        AgenciaOficinaBE objBE_AgenciaOficina = new AgenciaOficinaBE();
        //        objBE_AgenciaOficina.IdAgenciaOficina = IdAgenciaOficina;
        //        objBE_AgenciaOficina.IdEmpresa = Parametros.intEmpresaId;
        //        objBE_AgenciaOficina.Usuario = Parametros.strUsuarioLogin;
        //        objBE_AgenciaOficina.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

        //        AgenciaOficinaBL objBL_AgenciaOficina = new AgenciaOficinaBL();
        //        objBL_AgenciaOficina.Elimina(objBE_AgenciaOficina);
        //        gvAgenciaOficina.DeleteRow(gvAgenciaOficina.FocusedRowHandle);
        //        gvAgenciaOficina.RefreshData();
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    AgenciaBL objBL_Agencia = new AgenciaBL();
                    AgenciaBE objE_Agencia = new AgenciaBE();

                    objE_Agencia.IdAgencia = IdAgencia;
                    objE_Agencia.Ruc = txtNumeroDocumento.Text.ToString().Trim();
                    objE_Agencia.DescAgencia = txtDescripcion.Text;
                    objE_Agencia.Direccion = txtDireccion.Text;
                    objE_Agencia.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objE_Agencia.Direccion = txtDireccion.Text;
                    objE_Agencia.Referencia = txtReferencia.Text;
                    objE_Agencia.Telefono = txtTelefono.Text;
                    objE_Agencia.Email = txtEmail.Text;
                    objE_Agencia.Contacto = txtContacto.Text;
                    objE_Agencia.PaginaWeb = txtPaginaWeb.Text;
                    objE_Agencia.Observacion = txtObservacion.Text;
                    objE_Agencia.FlagEstado = true;
                    objE_Agencia.Usuario = Parametros.strUsuarioLogin;
                    objE_Agencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    //Agencia  Correo
                    //List<AgenciaOficinaBE> lstAgenciaOficina = new List<AgenciaOficinaBE>();
                    //foreach (var item in mListaAgenciaOficinaOrigen)
                    //{

                    //    AgenciaOficinaBE objE_AgenciaOficina = new AgenciaOficinaBE();
                    //    objE_AgenciaOficina.IdAgenciaOficina = item.IdAgenciaOficina;
                    //    objE_AgenciaOficina.IdAgencia = IdAgencia;
                    //    objE_AgenciaOficina.Email = item.Email;
                    //    objE_AgenciaOficina.FlagEstado = true;
                    //    objE_AgenciaOficina.Usuario = Parametros.strUsuarioLogin;
                    //    objE_AgenciaOficina.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    //    objE_AgenciaOficina.IdEmpresa = Parametros.intEmpresaId;
                    //    objE_AgenciaOficina.TipoOper = item.TipoOper;
                    //    lstAgenciaOficina.Add(objE_AgenciaOficina);
                    //}

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Agencia.Inserta(objE_Agencia);
                    else
                        objBL_Agencia.Actualiza(objE_Agencia);

                    //Devolvemos el Agencia Generado
                    this.DialogResult = DialogResult.OK;
                    //RUC = txtNumeroDocumento.Text;
                    //DescAgencia = txtDescripcion.Text;
                    //Direccion = txtDireccion.Text;
                    //AbrevDocimicilio = cboTipoDireccion.Text;
                    //IdClasificacionAgencia = Convert.ToInt32(cboClasificacion.EditValue);
                    //TipoClasificacion = "Agencia FINAL" + "-" + cboClasificacion.Text;


                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboDepartamento.Focus();
            }
        }

        private void cboDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboDistrito_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPaginaWeb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción de la Agencia.\n";
                flag = true;
            }

            if (txtDireccion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la dirección del Agencia.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                if (lstAgencia != null)
                {
                    var BuscarDocumento = lstAgencia.Where(oB => oB.Ruc.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
                    if (BuscarDocumento.Count > 0)
                    {
                        strMensaje = strMensaje + "- El número de documento ya existe.\n";
                        flag = true;
                    }

                    var BuscarDescripcion = lstAgencia.Where(oB => oB.DescAgencia.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                    if (BuscarDescripcion.Count > 0)
                    {
                        strMensaje = strMensaje + "- La descripción ya existe.\n";
                        flag = true;
                    }
                }

            }

            //foreach (CAgenciaOficina item in mListaAgenciaOficinaOrigen)
            //{
            //    var BuscarCorreoAsociado = mListaAgenciaOficinaOrigen.Where(oB => oB.Email.ToUpper() == item.Email.ToUpper()).ToList();
            //    if (BuscarCorreoAsociado.Count > 1)
            //    {
            //        strMensaje = strMensaje + "- El correo electronico se repite.\n";
            //        flag = true;
            //    }

            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaAgenciaOficina()
        {
            //List<AgenciaOficinaBE> lstTmpAgenciaOficina = null;
            //lstTmpAgenciaOficina = new AgenciaOficinaBL().ListaTodosActivo(Parametros.intEmpresaId, IdAgencia);

            //foreach (AgenciaOficinaBE item in lstTmpAgenciaOficina)
            //{
            //    CAgenciaOficina objE_AgenciaOficina = new CAgenciaOficina();
            //    objE_AgenciaOficina.IdEmpresa = item.IdEmpresa;
            //    objE_AgenciaOficina.IdAgenciaOficina = item.IdAgenciaOficina;
            //    objE_AgenciaOficina.IdAgencia = item.IdAgencia;
            //    objE_AgenciaOficina.Email = item.Email;
            //    objE_AgenciaOficina.TipoOper = item.TipoOper;
            //    mListaAgenciaOficinaOrigen.Add(objE_AgenciaOficina);
            //}

            //bsListadoAgenciaOficina.DataSource = mListaAgenciaOficinaOrigen;
            //gcAgenciaOficina.DataSource = bsListadoAgenciaOficina;
            //gcAgenciaOficina.RefreshDataSource();
        }

        #endregion


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManAgenciaOficinaEdit movDetalle = new frmManAgenciaOficinaEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaAgenciaOficinaOrigen.Count == 0)
                        {
                            gvAgenciaOficina.AddNewRow();
                            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "IdAgencia", movDetalle.oBE.IdAgencia);
                            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "IdAgenciaOficina", movDetalle.oBE.IdAgenciaOficina);
                            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "DescAgencia", movDetalle.oBE.DescAgencia);
                            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "Direccion", movDetalle.oBE.Direccion);
                            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "IdUbigeo", movDetalle.oBE.IdUbigeo);
                            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "Telefono", movDetalle.oBE.Telefono);
                            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvAgenciaOficina.SetRowCellValue(gvAgenciaOficina.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvAgenciaOficina.UpdateCurrentRow();


                            return;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvAgenciaOficina.RowCount > 0)
            {
                AgenciaOficinaBE objAgenciaOficinaBE = new AgenciaOficinaBE();
                objAgenciaOficinaBE.IdAgenciaOficina = int.Parse(gvAgenciaOficina.GetFocusedRowCellValue("IdAgenciaOficina").ToString());

                frmManAgenciaOficinaEdit objManAgenciaOficinaEdit = new frmManAgenciaOficinaEdit();
                objManAgenciaOficinaEdit.pOperacion = frmManAgenciaOficinaEdit.Operacion.Modificar;
                objManAgenciaOficinaEdit.IdAgenciaOficina = objAgenciaOficinaBE.IdAgenciaOficina;
                objManAgenciaOficinaEdit.StartPosition = FormStartPosition.CenterParent;
                objManAgenciaOficinaEdit.ShowDialog();

                //CargarBusqueda();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaAgenciaOficinaOrigen.Count > 0)
                {
                    if (int.Parse(gvAgenciaOficina.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdAgenciaOficina = 0;
                        if (gvAgenciaOficina.GetFocusedRowCellValue("IdAgenciaOficina") != null)
                            IdAgenciaOficina = int.Parse(gvAgenciaOficina.GetFocusedRowCellValue("IdAgenciaOficina").ToString());
                        AgenciaOficinaBE objBE_AgenciaOficina = new AgenciaOficinaBE();
                        objBE_AgenciaOficina.IdAgenciaOficina = IdAgenciaOficina;
                        objBE_AgenciaOficina.Usuario = Parametros.strUsuarioLogin;
                        objBE_AgenciaOficina.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        AgenciaOficinaBL objBL_AgenciaOficina = new AgenciaOficinaBL();
                        objBL_AgenciaOficina.Elimina(objBE_AgenciaOficina);
                        gvAgenciaOficina.DeleteRow(gvAgenciaOficina.FocusedRowHandle);
                        gvAgenciaOficina.RefreshData();

                    }
                    else
                    {
                        gvAgenciaOficina.DeleteRow(gvAgenciaOficina.FocusedRowHandle);
                        gvAgenciaOficina.RefreshData();
                    }

                  }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public class CAgenciaOficina
        {
            public Int32 IdPromocion { get; set; }
            public Int32 IdPromocionDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Precio { get; set; }
            public Int32 TipoOper { get; set; }

            public CAgenciaOficina()
            {

            }
        }



    }
}