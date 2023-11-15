using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryWeigandtIE
{
   
    public partial class frmLogin : Form
    {
       

        public frmLogin()
        {
            InitializeComponent();
        }


        int intentos = 0;
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //string usuario = txtUsuario.Text;
            //string contraseña = txtContraseña.Text;
            // DateTime fechaHoraActual = DateTime.Now;

            //Usuario objValidaUsuario = new Usuario();

            // objValidaUsuario.ConectarBD();
            //Realizar y Corregir lo de los parametros
            // objValidaUsuario.RegistrarLog();

            //label3.Text = objValidaUsuario.estadoConexion;

            clsUsuario Usuario = new clsUsuario();

            
            if (Usuario.ValidarUsuario(txtUsuario.Text, txtContraseña.Text))
           
            {
                StreamWriter sw = new StreamWriter("logInicio", true);
                sw.WriteLine(txtUsuario.Text + "- Fecha: " + DateTime.Now);
                sw.Close();

                // Escribe el log en la BD
                clsRegistrarLogs LogsR = new clsRegistrarLogs();
                LogsR.RegistrarLog(txtUsuario.Text, DateTime.Now, "Prueba", "Inicio Sesión");

               
                FrmPrincipal principalForm = new FrmPrincipal();
                principalForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos de inicio de sesion incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                intentos++;
                MessageBox.Show(intentos + " de 3 intentos posibles", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Clear();
                txtContraseña.Clear();


                if (intentos >= 3)
                {
                    MessageBox.Show("Ha superado el limite de los intentos"  + " segundos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Enabled = false;
                    txtContraseña.Enabled = false;
                    btnIniciar.Enabled = false;

                    
                }
            }
        }

      

        private void RegistrarLog(string registro)
        {
            string archivoLog = "LOG.txt";

            try
            {
                using (StreamWriter sw = File.AppendText(archivoLog))
                {
                    sw.WriteLine(registro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar en el archivo LOG: {ex.Message}");
    
            }
    }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistrarUsuario forRegistrarUsuario = new frmRegistrarUsuario();
            forRegistrarUsuario.Show();
            this.Hide();
        }
    }

    public static class UsuarioActual
    {
        public static string NombreUsuario { get; set; }
    }

}
