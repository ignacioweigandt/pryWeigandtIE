using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace pryWeigandtIE
{
    public partial class FrmPrincipal : Form
    {
        private clsUsuario usuario;
        public FrmPrincipal(clsUsuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            toolStripStatusLabel1.Text = usuario.Nombre;

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void registroProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsRegistrarLogs LogsReg = new clsRegistrarLogs();
            LogsReg.RegistrarLog(toolStripStatusLabel1.Text, DateTime.Now, "Prueba", "Ingreso a Registro Proveedores");

            StreamWriter sw = new StreamWriter("logGeneral", true);
            sw.WriteLine(toolStripStatusLabel1.Text + "- Fecha: " + DateTime.Now + "- Ingreso a: " + registroProveedoresToolStripMenuItem.Text);
            sw.Close();
            FrmRegProv formProveedores = new FrmRegProv();
            formProveedores.Show();
            this.Hide();
        }

        private void accesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsRegistrarLogs LogsReg = new clsRegistrarLogs();
            LogsReg.RegistrarLog(toolStripStatusLabel1.Text, DateTime.Now, "Prueba", "Ingreso a Registro Proveedores");

            StreamWriter sw = new StreamWriter("logGeneral", true);
            sw.WriteLine(toolStripStatusLabel1.Text + "- Fecha: " + DateTime.Now + "- Ingreso a: " + AccesoProveedores.Text);
            sw.Close();
            frmProveedores formProveedores = new frmProveedores();
            formProveedores.Show();
            this.Hide();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel2.Spring = true;
            toolStripStatusLabel1.Spring = true;
            //toolStripStatusLabel1.Text = $"Usuario: {UsuarioActual.NombreUsuario}";
            
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
