using System;
using MySqlConnector;

namespace ProyectoChat
{
    public class BBdd
    {
        string server = "20.90.95.76";
        string username = "grupo";
        string password = "Javapy86125678";
        string port = "3306";
        string connectionString;
        string database = "proyecto";
        string table = "admin";
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
                    string query = "SELECT id_admin, username, password, photo FROM " + database + "." + table +
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




    }

}
