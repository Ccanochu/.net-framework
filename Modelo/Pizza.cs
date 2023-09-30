using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Modelo
{
    public class Pizza
    {
        public Pizza()
        {
        }

        public void CrearPizza(string nombre, decimal precio, string tamanio, bool gluten_checked)
        {
            string query = "INSERT INTO tb_pizzas (nombre, precio, tamanio, gluten_checked) " +
               "VALUES (@nombre, @precio, @tamanio, @gluten_checked)";


            ConexionBD conexionBD = new ConexionBD();
            using (MySqlConnection connection = conexionBD.ObtenerConexion())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@tamanio", tamanio);
                command.Parameters.AddWithValue("@gluten_checked", gluten_checked);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Pizza registrada correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar la pizza: {ex.Message}");
                }

                conexionBD.CerrarConexion();
            }

        }

        public DataTable ListarPizzas()
        {
            DataTable dtPizzas = new DataTable();

            string query = "SELECT id, nombre, tamanio, gluten_checked, precio FROM tb_pizzas";

            ConexionBD conexionBD = new ConexionBD();
            using (MySqlConnection connection = conexionBD.ObtenerConexion())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    conexionBD.AbrirConexion();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dtPizzas.Load(reader);
                    }

                    return dtPizzas;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al listar las pizzas: {ex.Message}");
                    return null;
                }
            }
        }


        public void EliminarPizza(int id)
        {
            string query = "DELETE FROM tb_pizzas WHERE id = @id";

            ConexionBD conexionBD = new ConexionBD();
            using (MySqlConnection connection = conexionBD.ObtenerConexion())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {   
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    conexionBD.AbrirConexion();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Pizza eliminada correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar la pizza: {ex.Message}");
                }
            }
        }

        public void ActualizarPizza(string nombre, decimal precio, string tamanio, bool gluten_checked, int id)
        {
            string query = "UPDATE tb_pizzas SET nombre = @nombre, precio = @precio, tamanio = @tamanio, gluten_checked = @gluten_checked WHERE id = @id";



            ConexionBD conexionBD = new ConexionBD();
            using (MySqlConnection connection = conexionBD.ObtenerConexion())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@tamanio", tamanio);
                command.Parameters.AddWithValue("@gluten_checked", gluten_checked);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Pizza actualizada correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar la pizza: {ex.Message}");
                }

                conexionBD.CerrarConexion();
            }

        }
    }
}
