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
        private List<clsRegistro> registros = new List<clsRegistro>();
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


           
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            int Numero = int.Parse(txtNum.Text);
            string Entidad = txtEntidad.Text;
            string Expediente = txtNumExp.Text;
            string Juzgado = cmbJuzg.Text;
            string Jurisdiccion = cmbJurisd.Text;
            string Direccion = txtDireccion.Text;
            string Liquidador = cmbLiquidador.Text;
            DateTime fechaApertura = dtpAperura.Value;
            try
            {
                // Crear una lista para almacenar las líneas del archivo CSV
                List<string> lineas = new List<string>();
                // Agregar la primera línea con encabezados de columnas
                lineas.Add("Nº;Entidad;APERTURA;Nº EXPTE;JUZG.;JURISD;DIRECCION;LIQUIDADOR RESPONSABLE");
                // Variable para verificar si es la primera línea del archivo
                bool primerLinea = true;
                // Abrir el archivo CSV para lectura
                using (StreamReader lector = new StreamReader(filePath))
                {
                    string readLine;

                    // Leer el archivo línea por línea
                    while ((readLine = lector.ReadLine()) != null)
                    {
                        // Dividir la línea en elementos usando ';' como separador
                        string[] separador = readLine.Split(';');

                        // Verificar si hay al menos un elemento y si el primer elemento es un número válido
                        if (separador.Length > 0 && int.TryParse(separador[0], out int existingID))
                        {
                            // Comprobar si el número coincide con el valor de la variable "Numero"
                            if (existingID == Numero)
                            {
                                // Crear una nueva línea con los datos modificados
                                string nuevaLinea = $"{Numero};{Entidad};{fechaApertura};{Expediente};{Juzgado};{Jurisdiccion};{Direccion};{Liquidador}";

                                // Agregar la nueva línea a la lista
                                lineas.Add(nuevaLinea);
                            }
                            else
                            {
                                // Si el número no coincide, agregar la línea original sin modificaciones
                                lineas.Add(readLine);
                            }
                        }
                    }
                }
                // Escribir las líneas en el archivo original (sobreescribiendo el archivo)
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    foreach (string linea in lineas)
                    {
                        // Agregar la primera línea con los títulos de las columnas
                        if (primerLinea)
                        {
                            sw.WriteLine(linea);
                            primerLinea = false;
                        }
                        else
                        {
                            sw.WriteLine(linea);
                        }
                    }
                }
                // Mostrar un mensaje de éxito
                MessageBox.Show("Datos del Proveedor Nº " + Numero + " modificados correctamente.", "Modificación de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Limpiar y recargar los datos en la grilla de proveedores
                dgvProveedores.Rows.Clear();
                dgvProveedores.Columns.Clear();
                CargarTodo();
            }
            catch (Exception ex)
            {
                // En caso de error, mostrar un mensaje de error
                MessageBox.Show("Error al modificar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTodo()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string readLine = sr.ReadLine();
                if (readLine != null)
                {
                    string[] separador = readLine.Split(';');
                    foreach (string columna in separador)
                    {
                        dgvProveedores.Columns.Add(columna, columna);
                    }
                    //La HashSet<string> clase proporciona operaciones de conjuntos de alto rendimiento.
                    HashSet<string> jurisdiccionesUnicas = new HashSet<string>();
                    HashSet<string> juzgadoUnico = new HashSet<string>();
                    HashSet<string> responsablesUnicos = new HashSet<string>();

                    while (!sr.EndOfStream)
                    {
                        readLine = sr.ReadLine();
                        separador = readLine.Split(';');
                        dgvProveedores.Rows.Add(separador);
                        juzgadoUnico.Add(separador[4]);
                        jurisdiccionesUnicas.Add(separador[5]);
                        responsablesUnicos.Add(separador[7]);
                    }
                }
            }
        }



        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores ingresados por el usuario
                string numero = txtNum.Text;
                string entidad = txtEntidad.Text;
                DateTime apertura = dtpAperura.Value;
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
                dtpAperura.Value = DateTime.Now;
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
            this.Close();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNum.Text = dgvProveedores.CurrentRow.Cells[0].Value.ToString();
            txtEntidad.Text = dgvProveedores.CurrentRow.Cells[1].Value.ToString();
            dtpAperura.Text = dgvProveedores.CurrentRow.Cells[2].Value.ToString();
            txtNumExp.Text = dgvProveedores.CurrentRow.Cells[3].Value.ToString();
            cmbJuzg.SelectedItem = dgvProveedores.CurrentRow.Cells[4].Value.ToString();
            cmbJurisd.SelectedItem = dgvProveedores.CurrentRow.Cells[5].Value.ToString();
            txtDireccion.Text = dgvProveedores.CurrentRow.Cells[6].Value.ToString();
            cmbLiquidador.Text = dgvProveedores.CurrentRow.Cells[7].Value.ToString();

        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                int numeroRegistroAEliminar = dgvProveedores.SelectedRows[0].Index + 2; // Obtén el número de fila seleccionada
                //Especifica identificadores que indican el valor devuelto
                DialogResult resultado = MessageBox.Show("¿Seguro que deseas eliminar esta fila?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Elimina la fila del DataGridView
                    dgvProveedores.Rows.RemoveAt(dgvProveedores.SelectedRows[0].Index);

                    // Elimina la fila del archivo CSV
                    EliminarRegistroCSV(filePath, numeroRegistroAEliminar);
                    ActualizarArchivoCSV();
                    CargarDatosEnGrilla();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static void EliminarRegistroCSV(string filePath, int numeroRegistroAEliminar)
        {
            try
            {
                // Lee todo el contenido del archivo CSV
                string[] lineas = File.ReadAllLines(filePath);

                // Verifica que el número de registro a eliminar sea válido
                if (numeroRegistroAEliminar >= 1 && numeroRegistroAEliminar <= lineas.Length)
                {
                    // Crea un nuevo contenido sin el registro a eliminar
                    //String builder representa a una serie de caracteres mutables que se pueden ampliar para almacenar mas caracteres si es necesario
                    StringBuilder nuevoContenido = new StringBuilder();
                    for (int i = 0; i < lineas.Length; i++)
                    {
                        if (i + 1 != numeroRegistroAEliminar) // Omitir el registro que deseas eliminar
                        {
                            nuevoContenido.AppendLine(lineas[i]);
                        }
                    }

                    // Escribe el nuevo contenido en el archivo CSV
                    File.WriteAllText(filePath, nuevoContenido.ToString());

                    MessageBox.Show("Registro eliminado con éxito.");
                }
                else
                {
                    MessageBox.Show("Número de registro a eliminar no válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
        }

        private void ActualizarArchivoCSV()
        {
            try
            {
                // Abrir o crear el archivo CSV en modo escritura.
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    // Iterar a través de la lista de personas y escribir sus datos en el archivo CSV.
                    foreach (var reg in registros)
                    {
                        // Escribir los datos en formato CSV (separados por comas).
                        sw.WriteLine($"{reg.Numero};{reg.Entidad};{reg.Apertura};{reg.Expediente};{reg.Juzgado};{reg.Jurisdiccion};{reg.Direccion};{reg.LiquidadorResponsable}");
                    }
                }
                dgvProveedores.Refresh();

            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de que ocurra una excepción.
                MessageBox.Show("Error al escribir en el archivo CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDatosEnGrilla()
        {
            foreach (var reg in registros)
            {
                dgvProveedores.Rows.Add(new object[] { reg.Numero, reg.Entidad, reg.Apertura, reg.Expediente, reg.Juzgado, reg.Jurisdiccion, reg.Direccion, reg.LiquidadorResponsable });
            }
            registros.Clear();
        }

      

    }


}
