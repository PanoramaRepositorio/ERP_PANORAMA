using System.ComponentModel;
using System;
using System.Collections.Generic;
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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Seguridad
{
    public partial class frmManPerfilEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<AccesoBE> pListaAcceso = new List<AccesoBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PerfilBE pPerfilBE { get; set; }

        bool find = false;

        int _IdPerfil = 0;

        public int IdPerfil
        {
            get { return _IdPerfil; }
            set { _IdPerfil = value; }
        }

        int menuID = 0;
        
        #endregion

        #region "Eventos"

        public frmManPerfilEdit()
        {
            InitializeComponent();
        }

        private void frmManPerfilEdit_Load(object sender, EventArgs e)
        {
            PopulateMenu(0, new MenuBL().ListaTodosActivo(), null);

            AccessByPerfilID(IdPerfil);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Perfil - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Perfil - Modificar";
                txtDescripcion.Text = pPerfilBE.DescPerfil.Trim();
                chkEstado.Checked = pPerfilBE.FlagEstado;
            }
            
            txtDescripcion.Select();
            chkEstado.Checked = true;
            
        }

        private void btnGrabar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PerfilBL objBL_Perfil = new PerfilBL();

                    PerfilBE objPerfil = new PerfilBE();
                    objPerfil.IdPerfil = IdPerfil;
                    objPerfil.DescPerfil = txtDescripcion.Text;
                    objPerfil.FlagEstado = chkEstado.Checked;
                    objPerfil.Usuario = Parametros.strUsuarioLogin;
                    objPerfil.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPerfil.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Perfil.Inserta(objPerfil, pListaAcceso);
                    else
                    {
                        objBL_Perfil.Actualiza(objPerfil, pListaAcceso);
                        XtraMessageBox.Show("Se actualizaron accesos de usuarios con perfil " + txtDescripcion.Text.Trim() , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void CheckAllNodes(TreeNodeCollection col, Boolean check)
        {
            foreach (TreeNode tN in col)
            {
                tN.Checked = check;

                this.CheckAllNodes(tN.Nodes, check);
            }
        }

        private void CheckNodes(TreeNodeCollection col, int menuID)
        {
            foreach (TreeNode tN in col)
            {
                string[] objectString = tN.Tag.ToString().Split(new char[] { ';' });

                if (Convert.ToInt32(objectString[0]) == menuID)
                {
                    tN.Checked = true;
                    if (tN.Parent != null)
                    {
                        tN.Parent.Checked = true;
                    }
                }
                this.CheckNodes(tN.Nodes, menuID);
            }
        }

        private void trwMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                //Para marcar y desmarcar todos los nodos            
                foreach (TreeNode oNodo in e.Node.Nodes)
                {
                    string[] objectString = oNodo.Tag.ToString().Split(new char[] { ';' });
                    //AGREGAR EL FLAG AQUI .....
                    if (find == false)
                        oNodo.Checked = e.Node.Checked;

                    //insertar en el datatable solo las ventanas que es el ultimo nivel
                    if (e.Node.Checked == true)
                    {
                        if (objectString[1] == "4")
                        {
                            //AGREGAR EL FLAG AQUI .....
                            if (find == false)
                                AddMenu(Convert.ToInt32(objectString[0]));
                        }
                    }
                    if (e.Node.Checked == false)
                    {
                        RemoveMenu(Convert.ToInt32(objectString[0]));
                    }
                }

                if (e.Node.Parent != null)
                {
                    string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                    //e.Node.Parent.Checked=true;
                    if (!e.Node.Checked == true)
                    {
                        //Desmarco
                        e.Node.Parent.NodeFont = new Font(this.trwMenu.Font, FontStyle.Regular);
                        RemoveMenu(Convert.ToInt32(objectString[0]));

                    }
                    else
                    {
                        e.Node.Parent.NodeFont = new Font(this.trwMenu.Font, FontStyle.Bold);
                        //AGREGAR EL FLAG AQUI .....
                        if (find == false)
                            AddMenu(Convert.ToInt32(objectString[0]));
                        //Marco
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trwMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string[] objectString = e.Node.Tag.ToString().Split(new char[] { ';' });
                this.lblMenu.Text = e.Node.Text;
                menuID = Convert.ToInt32(objectString[0]);

                if (pListaAcceso.Count > 0)
                {
                    AccesoBE Acceso = pListaAcceso.Find(delegate(AccesoBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    if (Acceso != null)
                    {
                        //Mostrar datos en los checkbox
                        this.chkAllowRead.Checked = Acceso.FlagLectura;
                        this.chkAllowWrite.Checked = Acceso.FlagAdicion; ;
                        this.chkAllowUpdate.Checked = Acceso.FlagActualizacion; ;
                        this.chkAllowDelete.Checked = Acceso.FlagEliminacion; ;
                        this.chkAllowPrint.Checked = Acceso.FlagImpresion; ;
                    }
                    else
                    {
                        this.chkAllowRead.Checked = false;
                        this.chkAllowWrite.Checked = false;
                        this.chkAllowUpdate.Checked = false;
                        this.chkAllowDelete.Checked = false;
                        this.chkAllowPrint.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAllowRead_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                AccesoBE Acceso = pListaAcceso.Find(delegate(AccesoBE _Acc)
                {
                    if (_Acc.IdMenu == menuID)
                    {
                        return true;
                    }
                    return false;
                });

                if (Acceso != null)
                {
                    CheckBox obj = new CheckBox();
                    obj = (CheckBox)sender;

                    AccesoBE AccesoMenu = pListaAcceso.Find(delegate(AccesoBE _Acc)
                    {
                        if (_Acc.IdMenu == menuID)
                        {
                            return true;
                        }
                        return false;
                    });

                    switch (obj.Name)
                    {
                        case "chkAllowRead":
                            if (IdPerfil == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagLectura = chkAllowRead.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagLectura = chkAllowRead.Checked;

                                if (AccesoMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowWrite":
                            if (IdPerfil == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagAdicion = chkAllowWrite.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagAdicion = chkAllowWrite.Checked;

                                if (AccesoMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }

                            break;
                        case "chkAllowUpdate":
                            if (IdPerfil == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagActualizacion = chkAllowUpdate.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagActualizacion = chkAllowUpdate.Checked;

                                if (AccesoMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowDelete":
                            if (IdPerfil == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagEliminacion = chkAllowDelete.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagEliminacion = chkAllowDelete.Checked;

                                if (AccesoMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        case "chkAllowPrint":
                            if (IdPerfil == 0)
                            {
                                if (AccesoMenu != null)
                                {
                                    AccesoMenu.FlagImpresion = chkAllowPrint.Checked;
                                }
                            }
                            else
                            {
                                AccesoMenu.FlagImpresion = chkAllowPrint.Checked;

                                if (AccesoMenu.TipOper == Convert.ToInt32(Operacion.Consultar))
                                    AccesoMenu.TipOper = Convert.ToInt32(Operacion.Modificar);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        public void PopulateMenu(int HijoID, List<MenuBE> pMenuAccess, TreeNode nodeParent)
        {
            try
            {
                var ListMenuHijos =
                    from p in pMenuAccess
                    where p.IdMenuPadre == HijoID
                    select p;

                foreach (var HijoMenu in ListMenuHijos)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = HijoMenu.MenuDescripcion;
                    switch (HijoMenu.IdMenuTipo)
                    {
                        case 0:
                            newNode.ImageIndex = 0;
                            newNode.SelectedImageIndex = 0;
                            break;
                        default:
                            newNode.ImageIndex = 1;
                            newNode.SelectedImageIndex = 1;
                            break;
                    }

                    newNode.Tag = HijoMenu.IdMenu.ToString() + ";" + HijoMenu.IdMenuTipo.ToString();
                    if (nodeParent == null)
                    {
                        this.trwMenu.Nodes.Add(newNode);
                    }
                    else
                    {
                        nodeParent.Nodes.Add(newNode);
                    }
                    PopulateMenu(HijoMenu.IdMenu, pMenuAccess, newNode);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void AddMenu(int IdMenu)
        {
            //verificar que no exista
            AccesoBE Acceso = pListaAcceso.Find(delegate(AccesoBE _Acc)
            {
                if (_Acc.IdMenu == IdMenu)
                {
                    return true;
                }
                return false;
            });

            if (Acceso == null)
            {
                AccesoBE acceso = null;
                acceso = new AccesoBE();
                acceso.IdPerfil = IdPerfil;
                acceso.IdMenu = IdMenu;
                acceso.FlagLectura = true;
                acceso.FlagAdicion = true;
                acceso.FlagActualizacion = true;
                acceso.FlagEliminacion = true;
                acceso.FlagImpresion = true;
                acceso.FlagEstado = true;
                acceso.TipOper = Convert.ToInt32(Operacion.Nuevo);
                pListaAcceso.Add(acceso);
            }
            else
            {
                if (IdPerfil != 0)
                {
                    if (Acceso.TipOper != Convert.ToInt32(Operacion.Eliminar))
                    {
                        if (Acceso.TipOper == Convert.ToInt32(Operacion.Modificar))
                        { Acceso.TipOper = Convert.ToInt32(Operacion.Nuevo); }
                        if (Acceso.TipOper == Convert.ToInt32(Operacion.Consultar))
                        { Acceso.TipOper = Convert.ToInt32(Operacion.Nuevo); }
                    }
                }
            }
        }


        void RemoveMenu(int IdMenu)
        {
            //Borrar en bloque
            AccesoBE Acceso = pListaAcceso.Find(delegate(AccesoBE _Acc)
            {
                if (_Acc.IdMenu == IdMenu)
                {
                    return true;
                }
                return false;
            });
            if (Acceso != null)
            {
                if (Acceso.TipOper == Convert.ToInt32(Operacion.Nuevo))
                { Acceso.TipOper = Convert.ToInt32(Operacion.Consultar); }
                if (Acceso.TipOper == Convert.ToInt32(Operacion.Modificar) || Acceso.TipOper == Convert.ToInt32(Operacion.Consultar))
                    Acceso.TipOper = Convert.ToInt32(Operacion.Eliminar);

            }

        }

        void AccessByPerfilID(int perfilID)
        {
            try
            {
                CheckAllNodes(this.trwMenu.Nodes, false);

                pListaAcceso = new AccesoBL().SeleccionaPerfil(perfilID).ToList();

                foreach (AccesoBE item in pListaAcceso)
                {
                    //AGREGAR EL FLAG AQUI .....
                    find = true;
                    CheckNodes(this.trwMenu.Nodes, item.IdMenu);
                }
                //AGREGAR EL FLAG AQUI .....
                find = false;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (txtDescripcion.Text.ToString() == "")
            {
                XtraMessageBox.Show("Ingrese la descripción del Perfil", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Select();
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}