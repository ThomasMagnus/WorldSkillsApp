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

        private void ClearInputs()
        {
            foreach (UIElement elem in MainGrid.Children)
            {
                
            }
        }

        private void AddUserOnData(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> officesObj = new Dictionary<string, int> { };

            GetOfficesDict(officesObj);
            CreateUser(officesObj);
        }

        private void GetOfficesDict(Dictionary<string, int> officesObj)
        {
            try
            {
                string detectCountryIdCommand = "SELECT * FROM Offices";
                var reader = sqlConnector.Queryes(detectCountryIdCommand);


                while (reader.Read())
                {
                    officesObj[reader["Title"].ToString()] = Int32.Parse(reader["ID"].ToString());
                }
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

        private void CreateUser(Dictionary<string, int> officesObj)
        {
            try
            {
                string showAllUsers = "SELECT max(ID) FROM Users";
                var reader = sqlConnector.Queryes(showAllUsers);
                int userId = 0;
                PasswordBox password = Password;

                while (reader.Read()) userId = (int)reader[""];
                sqlConnector.sqlConnection.Close();

                var res = sqlConnector.Queryes($"SELECT * FROM Users WHERE Email='{email.Text}'");

                if (res.HasRows)
                {
                    MessageBox.Show("Пользователь с таким email уже в системе!", "Ошибка");
                }
                else
                {
                    string addUserCommand = $@"INSERT INTO Users VALUES ({++userId}, 2, '{email.Text}', '{password.Password}', 
                                           '{firstName.Text}', '{lastName.Text}', {officesObj[office.Text]}, '{birthDate.Text}', 1)";

                    sqlConnector.getQuery(addUserCommand);

                    MessageBox.Show("Пользователь добавлен!");
                    ClearInputs();
                }
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
