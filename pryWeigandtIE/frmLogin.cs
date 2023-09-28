using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryWeigandtIE
{
   
    public partial class frmLogin : Form
    {
       

        public frmLogin()
        {
            InitializeComponent();
        }

       

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            DateTime fechaHoraActual = DateTime.Now;

            // Comprobar las credenciales (aquí puedes agregar tu lógica de autenticación)
            if (Autenticar(usuario, contraseña))
            {
                // Registro de inicio de sesión en el archivo LOG.txt
                string registro = $"Usuario: {usuario}, Hora: {fechaHoraActual.ToString("HH:mm:ss")}, Fecha: {fechaHoraActual.ToShortDateString()}";
                RegistrarLog(registro);

                // Abre la ventana principal o realiza cualquier acción que desees
                MessageBox.Show("Inicio de sesión exitoso");
                // Supongamos que esto ocurre después de una verificación exitosa de las credenciales.
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                // Aquí puedes abrir la ventana principal de tu aplicación
                FrmPrincipal forPrincipal = new FrmPrincipal();
                forPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private bool Autenticar(string usuario, string contraseña)
        {
            // Aquí debes implementar tu lógica de autenticación.
            // Puedes comparar el usuario y la contraseña con una base de datos o valores almacenados.
            // En este ejemplo, se permite el acceso si el usuario es "admin" y la contraseña es "password".

            return usuario == "admin" && contraseña == "password";
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
    }

    public static class UsuarioActual
    {
        public static string NombreUsuario { get; set; }
    }

}
