using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WorldSkillsApp
{
    public class SqlConnector
    {
        
        private static string connectionString = "Server=LAPTOP-TNCLBUIO;Database=Session1_01;Trusted_Connection=True;";
        public SqlConnection sqlConnection = new SqlConnection(connectionString);

        private void OpenConnect()
        {
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getQuery(string query)
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            OpenConnect();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void SearchUser(string query, PasswordBox userPass, MainWindow mainWindow)
        {
            OpenConnect();

            try
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object pass = reader["Password"];
                        object role = reader["RoleID"];

                        if (userPass.Password == pass.ToString() && role.ToString() == "1")
                        {
                            sqlConnection.Close();
                            AdminPanel adminPanel = new AdminPanel();
                            adminPanel.Show();
                            mainWindow.Close();
                            break;
                        }
                        else if (userPass.Password == pass.ToString() && role.ToString() == "2")
                        {
                            sqlConnection.Close();
                            UserWindow userWindow = new UserWindow();
                            userWindow.Show();
                            mainWindow.Close();
                        }
                        else
                        {
                            MessageBox.Show("Faild");
                            sqlConnection.Close();
                            break;
                        }
                    }
                } else
                {
                    MessageBox.Show("Пользователь с таким Email не найден!");
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public SqlDataReader Queryes(string query)
        {
            OpenConnect();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                return reader;
            }
            catch
            {
                return null;
            }
        }
    }
}
