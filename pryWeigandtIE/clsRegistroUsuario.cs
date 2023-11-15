using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace pryWeigandtIE
{
    internal class clsRegistroUsuario
    {
        private string rutaArchivo;
        private string cadenaConexion;
        private string estadoConexion;
        private OleDbConnection conexionBD;
        public clsRegistroUsuario()
        {
            rutaArchivo = "Login.accdb";
            cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
            estadoConexion = "CERRADO";

            ConectarBD();
        }

        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaConexion;
                conexionBD.Open();
                estadoConexion = "ABIERTO";
            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        }

        public bool InsertarUsuario(string nombre, string contraseña, byte[] firmaData)
        {
            try
            {
                // verifica si el nombre de usuario ya existe en la base de datos.
                string verificaQuery = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario";

                using (OleDbCommand verificaCmd = new OleDbCommand(verificaQuery, conexionBD))
                {
                    verificaCmd.Parameters.AddWithValue("@Usuario", nombre);
                    int count = (int)verificaCmd.ExecuteScalar();

                    if (count > 0)
                    {
                       
                        MessageBox.Show("Usuario ya registrado.");
                        return false;
                    }
                }

                // Si el usuario no existe, procede con la inserción.
                string insertQuery = "INSERT INTO Usuario (Usuario, Contraseña, Firma) VALUES (@Usuario, @Contraseña, @Firma)";

                using (OleDbCommand cmd = new OleDbCommand(insertQuery, conexionBD))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombre);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.Parameters.Add("@Firma", OleDbType.LongVarBinary).Value = firmaData;

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                estadoConexion = ex.Message;
                return false;
            }
        }
    }
}
