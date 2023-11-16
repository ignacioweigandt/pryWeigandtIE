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
    public partial class frmProveedores : Form
    {
        private const string ProveedoresFolder = "Proveedores";
        private string selectedFilePath = "";
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            LoadProveedoresFolder();
        }

        private void LoadProveedoresFolder()
        {
            // Verifica si la carpeta de proveedores existe
            if (Directory.Exists(ProveedoresFolder))
            {
                // Limpia el control TreeView
                tvProveedores.Nodes.Clear();

                // Agrega un nodo raíz para la carpeta de proveedores
                TreeNode rootNode = new TreeNode("Proveedores");
                tvProveedores.Nodes.Add(rootNode);

                // Recorre las carpetas y archivos en la carpeta de proveedores
                foreach (string directoryPath in Directory.GetDirectories(ProveedoresFolder))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                    TreeNode directoryNode = new TreeNode(directoryInfo.Name);

                    foreach (string filePath in Directory.GetFiles(directoryPath))
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        directoryNode.Nodes.Add(new TreeNode(fileInfo.Name));
                    }

                    rootNode.Nodes.Add(directoryNode);
                }

                // Expande el nodo raíz
                rootNode.Expand();
            }
            else
            {
                MessageBox.Show("La carpeta de proveedores no existe.");
            }
        }

        private void tvProveedores_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode != null && selectedNode.Parent != null)
            {
                string selectedFilePath = Path.Combine(ProveedoresFolder, selectedNode.Parent.Text, selectedNode.Text);

                if (File.Exists(selectedFilePath))
                {
                    // Borra los elementos anteriores en el ListView
                    listViewProveedores.Items.Clear();

                    // Lee el contenido del archivo de texto y muestra las líneas en el ListView
                    string[] lines = File.ReadAllLines(selectedFilePath);
                    foreach (string line in lines)
                    {
                        listViewProveedores.Items.Add(line);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
