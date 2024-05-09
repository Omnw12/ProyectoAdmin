using System;
using MySqlConnector;
using ProyectoChat.Clases;

namespace ProyectoChat
{
    public class BBdd
    {
        string server = "localhost";
        string username = "root";
        string password = "";
        string port = "3306";
        string connectionString;
        string database = "proyecto";
        string table = "admin";
        private string table2 = "concesionarios";
        MySqlConnection connection;
        MySqlCommand command;

        public BBdd()
        {
            connectionString = "server=" + server + ";user=" + username + ";port=" + port + ";password=" + password + ";";
        }

        public void Query(string query)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"MySQL Exception: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public ClassAdmins SelectLogin(String username, String password)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_admin, username, password, photo, id_concesionario FROM " + database + "." + table +
                                   " WHERE username = @username AND password = @password";
                    using (command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ClassAdmins client = new ClassAdmins()
                                {
                                    id_admin = Convert.ToInt32(reader["id_admin"]),
                                    username = reader["username"].ToString(),
                                    password = reader["password"].ToString(),
                                    photo = reader["photo"].ToString(),
                                    id_concesionario = Convert.ToInt32(reader["id_concesionario"])
                                };
                                return client;
                            }

                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                return null;
            }

            return null;
        }


        public InfoConc MostrarInfo(int id_concesionario)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_concesionario, nombre, direccion, id_provincia FROM " + database + "." + table2 +
                                   " WHERE id_concesionario = @id_concesionario";
                    using (command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_concesionario", id_concesionario);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                InfoConc info = new InfoConc()
                                {
                                    id_concesionario = Convert.ToInt32(reader["id_concesionario"]),
                                    nombre = reader["nombre"].ToString(),
                                    direccion = reader["direccion"].ToString(),
                                    id_provincia = Convert.ToInt32(reader["id_provincia"])
                                };
                                return info;
                            }

                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                return null;
            }

            return null;
        }
        public StockVehiculos MostrarStock(int id_concesionario)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_offer, id_concesionario, id_modelo, description, fotos, stock FROM " + database + "." + table2 +
                                   " WHERE id_concesionario = @id_concesionario";
                    using (command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_concesionario", id_concesionario);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                StockVehiculos stock = new StockVehiculos()
                                {
                                    id_offer = Convert.ToInt32(reader["id_offer"]), 
                                    id_concesionario = Convert.ToInt32(reader["id_concesionario"]),
                                    id_modelo = Convert.ToInt32(reader["nombre"]),
                                    description = reader["description"].ToString(),
                                    fotos = reader["id_provincia"].ToString(),
                                    stock = Convert.ToInt32(reader["stock"])
                                };
                                return stock;
                            }

                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Exception: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
                return null;
            }

            return null;
        }


    }

}
