using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace Modelo
{
    public class ConexionBD
    {
        private const string URL = "server=localhost;database=db_pizzas;user=root;password=";
        private MySqlConnection _connection;

        public ConexionBD()
        {
            _connection = new MySqlConnection(URL);
        }

        public MySqlConnection ObtenerConexion()
        {
            return _connection;
        }

        public void AbrirConexion()
        {
            try
            {
                _connection.Open();
                Console.WriteLine("¡Conexión exitosa!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                    Console.WriteLine("Conexión cerrada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar la conexión: {ex.Message}");
            }
        }
    }
}
