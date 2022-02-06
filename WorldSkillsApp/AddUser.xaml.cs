using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;

namespace WorldSkillsApp
{
    public partial class AddUser : Window
    {
        SqlConnector sqlConnector = new SqlConnector();

        public AddUser()
        {
            InitializeComponent();
        }

        private void CloseAddPanel(object sender, RoutedEventArgs e)
        {
            AddUserPanel.Close();
        }

        private void AddUserOnData(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> officesObj = new Dictionary<string, int> { };

            try
            {
                string detectCountryIdCommand = "SELECT * FROM Offices";
                var reader = sqlConnector.Queryes(detectCountryIdCommand);


                while (reader.Read())
                {
                    officesObj[reader["Title"].ToString()] = Int32.Parse(reader["ID"].ToString());
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnector.sqlConnection.Close();
            }

            try
            {
                string showAllUsers = "SELECT max(ID) FROM Users";
                var reader = sqlConnector.Queryes(showAllUsers);
                int userId = 0;
                PasswordBox password = new PasswordBox();

                while (reader.Read()) userId = (int)reader[""];

                string addUserCommand = $@"INSERT INTO Users VALUES ({userId++}, 2, '{email.Text}', {password.Password}, 
                                            '{firstName.Text}', '{lastName.Text}', {officesObj[office.Text]}, '{birthDate.Text}', 1)";

                sqlConnector.getQuery(addUserCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnector.sqlConnection.Close();
            }
        }
    }
}
