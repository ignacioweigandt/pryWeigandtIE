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
    public partial class FrmRegProv : Form
    {
        // Ruta del archivo CSV
        string filePath = "listado de aseguradores.csv";
        public FrmRegProv()
        {
            InitializeComponent();
        }

        private void FrmRegProv_Load(object sender, EventArgs e)
        {
            
            // Cargar Combos Proveedores
            string archivoProveedor = "listado de aseguradores.csv";

            try
            {
                using (StreamReader sr = new StreamReader(archivoProveedor))
                {
                    string readLine = sr.ReadLine();
                    if (readLine != null)
                    {
                        string[] separador = readLine.Split(';');

                        foreach (string columna in separador)
                        {
                            dgvProveedores.Columns.Add(columna, columna);
                        }
                        HashSet<string> jurisdiccionesUnicas = new HashSet<string>();
                        HashSet<string> responsablesUnicos = new HashSet<string>();
                        HashSet<string> jurisdiccionesUnicasCmbJurisd = new HashSet<string>(); // Nueva colección para jurisdicciones en cmbJurisd

                        while (!sr.EndOfStream)
                        {
                            readLine = sr.ReadLine();
                            separador = readLine.Split(';');
                            dgvProveedores.Rows.Add(separador);
                            jurisdiccionesUnicas.Add(separador[4]);
                            jurisdiccionesUnicasCmbJurisd.Add(separador[5]);
                            responsablesUnicos.Add(separador[7]);
                        }

                        // Carga de juzg unicas sin repetir
                        foreach (string juzgado in jurisdiccionesUnicas)
                        {
                            cmbJuzg.Items.Add(juzgado);
                        }

                        foreach (string jurisdiccion in jurisdiccionesUnicasCmbJurisd)
                        {
                            cmbJurisd.Items.Add(jurisdiccion);
                        }

                        foreach (string responsable in responsablesUnicos)
                        {
                            cmbLiquidador.Items.Add(responsable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo: " + ex.Message, "error");
            }


            //Traer Todos los proveedores Registrados
            StreamReader lectorArchivo = new StreamReader("listado de aseguradores.csv");

            bool eslaprimerafila = true; //Primera Fila

            string leerElrenglon = "";
            string[] separarDatos;

            while (!lectorArchivo.EndOfStream)
            {
                leerElrenglon = lectorArchivo.ReadLine();
                separarDatos = leerElrenglon.Split(';');
                if(eslaprimerafila==true)
                {
                    //Crear las columnas de la grilla con los datos de la primer fila

                    for(int indice = 0; indice < separarDatos.Length; indice++)
                    {
                        dgvProveedores.Columns.Add(separarDatos[indice], separarDatos[indice]);
                    }
                    eslaprimerafila = false;
                }
                else
                {
                   dgvProveedores.Rows.Add(separarDatos);
                }
            }
            lectorArchivo.Close();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string numero = txtNum.Text;
            string entidad = txtEntidad.Text;
            string apertura = txtApertura.Text;
            string numeroExpediente = txtNumExp.Text;
            string juzgado = cmbJuzg.Text;
            string jurisdiccion = cmbJurisd.Text;
            string direccion = txtDireccion.Text;
            string liquidadorResponsable = cmbLiquidador.Text;

            // Crear una lista para almacenar las líneas del archivo CSV
            List<string> lines = new List<string>();

            try
            {
                // Leer las líneas existentes del archivo CSV
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                // Buscar la línea que se va a modificar (por ejemplo, usando el número de expediente)
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length >= 8 && parts[3] == numeroExpediente)
                    {
                        // Modificar los campos específicos
                        parts[0] = numero;
                        parts[1] = entidad;
                        parts[2] = apertura;
                        parts[6] = juzgado;
                        parts[7] = jurisdiccion;
                        parts[8] = liquidadorResponsable;

                        // Actualizar la línea en la lista
                        lines[i] = string.Join(",", parts);
                        break;
                    }
                }

                // Escribir las líneas actualizadas de nuevo en el archivo CSV
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }

                MessageBox.Show("Archivo CSV modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el archivo CSV: " + ex.Message);
            }
        }

        

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores ingresados por el usuario
                string numero = txtNum.Text;
                string entidad = txtEntidad.Text;
                string apertura = txtApertura.Text;
                string numExpte = txtNumExp.Text;
                string juzgado = cmbJuzg.SelectedItem.ToString();
                string jurisdiccion = cmbJurisd.SelectedItem.ToString();
                string direccion = txtDireccion.Text;
                string liquidador = cmbLiquidador.SelectedItem.ToString();

                // Crear una nueva línea con los datos
                string nuevaLinea = $"{numero};{entidad};{apertura};{numExpte};{juzgado};{jurisdiccion};{direccion};{liquidador}";

                // Escribir la nueva línea en el archivo CSV
                File.AppendAllText("listado de aseguradores.csv", nuevaLinea + Environment.NewLine);

                // Agregar una nueva fila en el DataGridView
                dgvProveedores.Rows.Add(numero, entidad, apertura, numExpte, juzgado,jurisdiccion, direccion, liquidador);

                // Limpiar los campos después de agregar los datos
                txtNum.Clear();
                txtEntidad.Clear();
                txtApertura.Clear();
                txtNumExp.Clear();
                txtDireccion.Clear();

                // Confirmación al usuario
                MessageBox.Show("Datos agregados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir la ventana principal de tu aplicación
            FrmPrincipal forPrincipal = new FrmPrincipal();
            forPrincipal.Show();
            this.Hide();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProveedores.Rows[e.RowIndex];
                txtNum.Text = row.Cells["Nº"].Value.ToString();
                txtEntidad.Text = row.Cells["Entidad"].Value.ToString();
                txtApertura.Text = row.Cells["APERTURA"].Value.ToString();
                txtNumExp.Text = row.Cells["Nº EXPTE."].Value.ToString();
                cmbJuzg.SelectedItem = row.Cells["JUZG."].Value.ToString();
                cmbJurisd.SelectedItem = row.Cells["JURISD"].Value.ToString();
                txtDireccion.Text = row.Cells["DIRECCION"].Value.ToString();
                cmbLiquidador.SelectedItem = row.Cells["LIQUIDADOR RESPONSABLE"].Value.ToString();
            }
        }
    }
}
