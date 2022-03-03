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
using System.Data;

namespace WorldSkillsApp
{
    public partial class AddUser : Window
    {
        AdminPanel adminPanel = new AdminPanel();
        SqlConnector sqlConnector = new SqlConnector();
        DataTable user;

        public AddUser()
        {
            InitializeComponent();
            user = new DataTable();
            this.DataContext = user;
        }

        private void CloseAddPanel(object sender, RoutedEventArgs e)
        {
            AddUserPanel.Close();
        }

        private void ClearInputs()
        {

            email.Text = "";
            firstName.Text = "";
            lastName.Text = "";
            birthDate.Text = "[dd/mm/yy]";
            Password.Password = "";

            UserData.dataTables.Clear();
            adminPanel.getClassData(adminPanel.selectUsers);
        }

        private void AddUserOnData(object sender, RoutedEventArgs e)
        {
            CreateUser(UserData.officesObj);
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

        private void Load_AddUserPanel(object sender, RoutedEventArgs e)
        {
            adminPanel.OfficesData.ItemsSource = UserData.dataTables;
        }

    }
}
