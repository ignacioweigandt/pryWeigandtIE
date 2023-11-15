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
using System.Data.SqlClient;
using System.Data.OleDb;

namespace pryWeigandtIE
{
    public partial class frmRegistrarUsuario : Form
    {
        private Bitmap signatureBitmap;
        public frmRegistrarUsuario()
        {
            InitializeComponent();
            signatureBitmap = new Bitmap(pbFirma.Width, pbFirma.Height);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistrarUsuario_Load(object sender, EventArgs e)
        {
                clsRegistroUsuario registroUsuario = new clsRegistroUsuario(); // Instancia de la clase clsRegistroUsuario.
            
        }

        private bool isDrawing = false;
        private Point previousPoint;
        private void pbFirma_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            previousPoint = e.Location;
        }

        private void pbFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(signatureBitmap))
                {
                    g.DrawLine(new Pen(Color.Black, 2), previousPoint, e.Location);
                    previousPoint = e.Location;
                    pbFirma.Image = signatureBitmap;
                }
            }
        }

        private void pbFirma_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void pbFirma_Paint(object sender, PaintEventArgs e)
        {
            if (pbFirma.Image != null)
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Asegurarse de que se hayan proporcionado un nombre y una contraseña
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingrese un nombre y una contraseña.");
                return;
            }

            // Convertir la firma 
            byte[] firmaData;
            using (MemoryStream ms = new MemoryStream())
            {
                pbFirma.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                firmaData = ms.ToArray();
            }

            clsRegistroUsuario registroUsuario = new clsRegistroUsuario(); // Instancia de la clase clsRegistroU
            bool registroExitoso = registroUsuario.InsertarUsuario(nombre, contraseña, firmaData);

            if (registroExitoso)
            {
                MessageBox.Show("Registro exitoso.");
                LimpiarFormulario();

                

            }
            else
            {
                MessageBox.Show("Error al registrar.");
            }
        }

        private void LimpiarFormulario()
        {
            txtNuevoUsuario.Text = "";
            txtContraseña.Text = "";
            pbFirma.Image = new Bitmap(pbFirma.Width, pbFirma.Height);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmLogin forLogin = new frmLogin();
            forLogin.Show();
            this.Hide();
        }
    }
}
        