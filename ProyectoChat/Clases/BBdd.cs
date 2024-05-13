using System;
using System.Data;
using System.Windows.Forms;
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
        string table2 = "concesionarios";
        string table3 = "offers";
        string table4 = "vista_modelos";
        string table5 = "peticiones";
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
                    string query = "SELECT id_concesionario, nombre, direccion, id_provincia, telefono FROM " + database + "." + table2 +
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
                                    id_provincia = Convert.ToInt32(reader["id_provincia"]),
                                    telefono = reader["telefono"].ToString()
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
        public InfoConc ActualizarInfo(InfoConc conc)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE " + database + "." + table2 + " SET nombre = @nombre, direccion = @direccion, id_provincia = @id_provincia, telefono = @telefono WHERE id_concesionario = @id_concesionario";
                    
                            using (command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id_concesionario", conc.id_concesionario);
                                command.Parameters.AddWithValue("@nombre", conc.nombre);
                                command.Parameters.AddWithValue("@direccion", conc.direccion);
                                command.Parameters.AddWithValue("@id_provincia", conc.id_provincia);
                                command.Parameters.AddWithValue("@telefono", conc.telefono);
                                command.ExecuteNonQuery();
                            }
                            connection.Close();
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
        public void MostrarStock(DataGridView dg, String id_concesionario)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT * FROM " + database + "." + table3 + " WHERE 1=1";

                    if (!string.IsNullOrEmpty(id_concesionario))
                    {
                        query += " AND id_concesionario LIKE @id_concesionario";
                    }



                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Asignar valores a los parámetros si se proporcionaron
                        if (!string.IsNullOrEmpty(id_concesionario))
                        {
                            cmd.Parameters.AddWithValue("@id_concesionario", "%" + id_concesionario + "%");
                        }



                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dg.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
            }

        }
        public void MostrarModelsFull(DataGridView dg)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM " + database + "." + table4;
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dg.DataSource = dt;
                        }
                    }

                }
            }
            catch (Exception ex) { }
        }
        public void MostrarPeticiones(DataGridView dg)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM " + database + "." + table5;
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dg.DataSource = dt;
                        }
                    }

                }
            }
            catch (Exception ex) { }
        }
        public void BuscarModelo(DataGridView dg, string modelo = "")
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT * FROM " + database + "." + table4 + " WHERE 1=1";

                    if (!string.IsNullOrEmpty(modelo))
                    {
                        query += " AND modelo LIKE @modelo";
                    }



                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Asignar valores a los parámetros si se proporcionaron
                        if (!string.IsNullOrEmpty(modelo))
                        {
                            cmd.Parameters.AddWithValue("@modelo", "%" + modelo + "%");
                        }



                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dg.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
            }
        }
        public void BuscarCoche_id(DataGridView dg, string id_coche = "", string id_concesionario = "")
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT * FROM " + database + "." + table3 + " WHERE 1=1";

                    if (!string.IsNullOrEmpty(id_coche))
                    {
                        query += " AND id_coche LIKE @id_coche";
                    }
                    if (!string.IsNullOrEmpty(id_concesionario))
                    {
                        query += " AND id_concesionario LIKE @id_concesionario";
                    }



                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Asignar valores a los parámetros si se proporcionaron
                        if (!string.IsNullOrEmpty(id_coche))
                        {
                            cmd.Parameters.AddWithValue("@id_coche", "%" + id_coche + "%");
                        }
                        if (!string.IsNullOrEmpty(id_concesionario))
                        {
                            cmd.Parameters.AddWithValue("@id_concesionario", "%" + id_concesionario + "%");
                        }


                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dg.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
            }
        }
        public void BuscarCoche_id1(DataGridView dg, string id_coche = "")
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT * FROM " + database + "." + table5 + " WHERE 1=1";

                    if (!string.IsNullOrEmpty(id_coche))
                    {
                        query += " AND id_coche LIKE @id_coche";
                    }



                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Asignar valores a los parámetros si se proporcionaron
                        if (!string.IsNullOrEmpty(id_coche))
                        {
                            cmd.Parameters.AddWithValue("@id_coche", "%" + id_coche + "%");
                        }



                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dg.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
            }
        }
        public void InsertStock(StockVehiculos stock)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "Insert Into " + database + "." + table3 + "(id_concesionario, id_coche, description, stock) Values (@id_concesionario,@id_coche,@description,@stock)";
                    using (command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@id_concesionario", stock.id_concesionario);
                        command.Parameters.AddWithValue("@id_coche", stock.id_coche);
                        command.Parameters.AddWithValue("@description", stock.description);
                        command.Parameters.AddWithValue("@stock", stock.stock);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();

                    MessageBox.Show("Registro añadido exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
                connection.Close();
            }

        }
        public void modifyStock(StockVehiculos stock)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE " + database + "." + table3 + " SET id_coche = @id_coche, description = @description, stock = @stock WHERE id_offer = @id_offer";
                    using (command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_offer", stock.id_offer);
                        command.Parameters.AddWithValue("@id_coche", stock.id_coche);
                        command.Parameters.AddWithValue("@description", stock.description);
                        command.Parameters.AddWithValue("@stock", stock.stock);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();

                    MessageBox.Show("Registro modificado exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
                connection.Close();
            }

        }
        public void eliminarStock(int id_offer)
        {
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM " + database + "." + table3 + " WHERE id_offer = @id_offer";

                    using (command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_offer", id_offer);
                        command.ExecuteNonQuery();
                    }

                    connection.Close();

                    MessageBox.Show("Registro eliminado exitosamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

    }

}
