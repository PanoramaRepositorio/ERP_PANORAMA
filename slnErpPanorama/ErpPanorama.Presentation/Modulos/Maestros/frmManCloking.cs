using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Net;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;


namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManCloking : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        
        #endregion

        public int conta = 0;

        public int conta1 = 0;
        public Boolean  act = true;
        public Boolean reloj = true;
      public   ClockingBL obj = new ClockingBL();
      public CocklingBE obj1 = new CocklingBE();
      public List<CocklingBE> lista = new List<CocklingBE>();
      public int valor = 0;
      String dni = "";
      public Boolean error = true;
      public int cue = 0;
      public string men = "";

        #region "Eventos"

        public frmManCloking()
        {
            InitializeComponent();
        }

        private void frmManCloking_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString().ToString();
            timer1.Start();
            timer4.Enabled = true;
            this.txtDni.Select();
            this.txtDni.Focus();
            DateTime FechaActual = DateTime.Now;
            deFechaIngreso.EditValue = FechaActual;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblHora.Text = DateTime.Now.TimeOfDay.ToString();
            lblHora.Text = DateTime.Now.ToLongTimeString(); 

            DateTime t1 = Convert.ToDateTime(DateTime.Now);
            DateTime t2 =  Convert.ToDateTime(("16:00:00"));
            if (t1.TimeOfDay.Ticks >= t2.TimeOfDay.Ticks)
            {
                optSalida.Checked = true;
                optIngreso.Checked = false;
            }
            else
            {
                optSalida.Checked = false;
                optIngreso.Checked = true;
            }
            //this.txtDni.Focus();

        }

        #endregion

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDni.Text == "")
                    {
                        //XtraMessageBox.Show("Ingresar un N° de Dni", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDni.Focus();
                        return;
                    }

                    if (txtDni.Text == "00000001" || txtDni.Text == "00000002" || txtDni.Text == "00000003" || txtDni.Text == "00000004")
                    {
                        CheckinoutBE objE_Checkinout = new CheckinoutBE();
                        objE_Checkinout.IdCheckinout = 0;
                        objE_Checkinout.IdEmpresa = Parametros.intEmpresaId;
                        objE_Checkinout.Dni = txtDni.Text;
                        objE_Checkinout.Fecha = DateTime.Now;

                        if (optIngreso.Checked)
                            objE_Checkinout.Tipo = "I";
                        else
                            objE_Checkinout.Tipo = "O";

                        objE_Checkinout.FlagEstado = true;
                        objE_Checkinout.flagManual = true;
                        objE_Checkinout.IdTienda = Parametros.intTiendaId;
                        objE_Checkinout.Usuario = Parametros.strUsuarioLogin;
                        objE_Checkinout.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        CheckinoutBL objBL_Checkinout = new CheckinoutBL();
                        List<CheckinoutBE> mListaCheckinout = new List<CheckinoutBE>();
                        mListaCheckinout.Add(objE_Checkinout);
                        objBL_Checkinout.Inserta(mListaCheckinout);
                        textBox3.Text = ""; 
                        //XtraMessageBox.Show("Tu Marcación ha sido registrada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        men = "Tu Marcación ha sido registrada correctamente.";
                        timer4.Enabled = true;
                        txtDni.Text = "";
                        return;  
                    }


                    PersonaBE objE_Persona = null;
                    objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(txtDni.Text.Trim());
                    if (objE_Persona != null)
                    {
                        CheckinoutBE objE_Checkinout = new CheckinoutBE();
                        objE_Checkinout.IdCheckinout = 0;
                        objE_Checkinout.IdEmpresa = objE_Persona.IdEmpresa;
                        objE_Checkinout.Dni = objE_Persona.Dni;
                        objE_Checkinout.Fecha   =   Convert.ToDateTime(deFechaIngreso.Text);
                       // objE_Checkinout.Fecha = DateTime.Now;

                        if (optIngreso.Checked)
                            objE_Checkinout.Tipo = "I";
                        else
                            objE_Checkinout.Tipo = "O";
                        objE_Checkinout.FlagEstado = true;
                        objE_Checkinout.flagManual = true;
                        objE_Checkinout.IdTienda = Parametros.intTiendaId;
                        objE_Checkinout.Usuario = Parametros.strUsuarioLogin;
                        objE_Checkinout.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        CheckinoutBL objBL_Checkinout = new CheckinoutBL();
                        List<CheckinoutBE> mListaCheckinout = new List<CheckinoutBE>();
                        mListaCheckinout.Add(objE_Checkinout);
                        objBL_Checkinout.Inserta(mListaCheckinout);

                        obj1.Dni = this.txtDni.Text;


                        this.timer2.Enabled = true;
                        conta = 0;
                        //XtraMessageBox.Show(objE_Persona.ApeNom + "\nTu Marcación ha sido registrada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Text = ""; 
                        men = "Tu Marcación ha sido registrada correctamente.";
                        timer4.Enabled = true;
                        txtDni.Text = "";
                    }
                    else
                    {
                        if (error == true) { 
                       // XtraMessageBox.Show("El N° Dni no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox3.Text = ""; 
                            men = "El N° Dni no existe, por favor verifique.";
                        timer4.Enabled = true;
                        txtDni.SelectAll();
                        txtDni.Focus();
                        error = false;
                            goto salir;
                        
                    }

                    }


                }
            salir:
               
          
                error = true;
            }
               

            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

       
        private void optSalida_CheckedChanged(object sender, EventArgs e)
        {
            txtDni.Focus();
        }

        private void txtDni_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Delete)
            //{
            //    dni = "";
            //    this.txtHoraExtra.Text = "";
            //    //MessageBox.Show("Registre su Marcacion de Horas Extras ....!");
            //    textBox3.Text = ""; 
            //    men = "Registre su Marcacion de Horas Extras ....!";
            //    timer4.Enabled = true;
            //    //timer1.Enabled = false;
            //    this.txtHoraExtra.Visible = true;
              
            //    this.txtHoraExtra.Focus();
            //}
            //else
            //{


                //if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
                //{
                //    String dato = this.txtDni.Text;

                //   // MessageBox.Show(dato.Length.ToString());

                //    textBox3.Text = ""; 
                //    //MessageBox.Show("Solo se permiten .numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    men="Solo se permiten .numeros, Advertencia";
                //    timer4.Enabled = true;
                //    e.Handled = true;
                //    return;
                //}


            //}

        }
        #region "Metodos"

        private void marcaciones()
        {
           
            //mListaCheckinout.Add(objE_Checkinout);
           
            lista=obj.ListaTodosActivo(obj1.Dni);
            this.gcMarcacion.DataSource = lista; 


        }


        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {

                if (conta < 5)
                {
                    if (act == true)
                    {
                        marcaciones();
                        act = false;
                    }
                    conta++;
                   // this.textEdit1.Text = conta.ToString();

                }
                else
                {
                    gcMarcacion.DataSource = null;
                    //  gridView1.Columns.Clear();
                    conta = 0;
                    act = true;
                    this.timer2.Enabled = false;
                  //  MessageBox.Show("acabo");

                }
            }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //txtHoraExtraAnt
        {
          
            this.txtDni.Text = "";
            if (e.KeyChar == (char)Keys.Enter )
            {
                dni = "";
               
                dni = this.txtHoraExtra.Text ;
                MarcacionesBE obj = new MarcacionesBE();
                MarcacionesBL obj1 = new MarcacionesBL ();
                obj.dni = dni;
                obj1.InsertaHE(obj);

                

                int cuenta=obj1.ListaMaciones(obj.dni).Count();
                this.gridControl2.DataSource = obj1.ListaMaciones(obj.dni);
  
                if (cuenta > 0)
                {
                   //this.gridControl2.Visible = true;
                    this.timer3.Enabled =true;
                  //  MessageBox.Show("Marcacion Registrada Correctamente ...!");
                    textBox3.Text = ""; 
                    men = "Marcacion Registrada Correctamente ...!";
                    timer4.Enabled = true;
                    this.txtHoraExtra.Visible = false;
                    this.txtHoraExtra.Text = "";
                    dni = "";
                    this.txtDni.Focus();
                }
                else
                {
                    textBox3.Text = ""; 
                    //MessageBox.Show("No Cuenta con Programacion en Horas Extras ...!");
                    men = "No Cuenta con Programacion en Horas Extras ...!";
                    timer4.Enabled = true;
                    this.txtHoraExtra.Visible = false;
                    this.txtHoraExtra.Text = "";
                    dni = "";
                    this.txtDni.Focus();
                }

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
            if (conta1 <= 5)
            {
                this.gridControl2.Visible = true;
                conta1++;
            }else{
                this.gridControl2.Visible = false;
                this.timer3.Enabled = false; 
                conta1 = 0;
                this.txtDni.Focus(); 
            }
            }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (cue < 6)
            {
                this.textBox3.Text = men;
                this.textBox3.ForeColor = Color.Yellow ; 
                cue++;
            }
            else
            {
                textBox3.Text = ""; 
                men = "Cualquier Percanse en la Marcacion Acercarse al Dpto Sistemas ...!";
//                men = " Feliz  Navidad ....!";
                this.textBox3.Text = men;
                this.textBox3.ForeColor = Color.White; 

                
                timer4.Enabled = false;
                cue = 0;
            }
        }

        private void txtHoraExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //PersonaBE objE_Persona = new PersonaBE();
            //objE_Persona = new PersonaBL().SeleccionaNumeroDocumento


            //HoraExtraBE objE_HoraExtra = new HoraExtraBE();
            //HoraExtraBL objBL_HoraExtra = new HoraExtraBL();

            //objE_HoraExtra.IdPersona = 
            //objBL_HoraExtra.InsertaMarcacion()
        }

        private void gvMarcacion_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvMarcacion.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["Marcacion"]);
                    if (objDocRetiro != null)
                    {
                        string Tipo = objDocRetiro.ToString();
                        if (Tipo.ToLower() == "entrada")
                        {
                            gvMarcacion.Columns["Marcacion"].AppearanceCell.BackColor = Color.Green;
                            gvMarcacion.Columns["Marcacion"].AppearanceCell.BackColor2 = Color.SeaShell;
                            gvMarcacion.Columns["Marcacion"].AppearanceCell.ForeColor = Color.White;
                        }
                        else
                        {
                            gvMarcacion.Columns["Marcacion"].AppearanceCell.BackColor = Color.Red;
                            gvMarcacion.Columns["Marcacion"].AppearanceCell.BackColor2 = Color.SeaShell;
                            gvMarcacion.Columns["Marcacion"].AppearanceCell.ForeColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 

        
    
