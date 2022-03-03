using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WorldSkillsApp
{
    public partial class AdminPanel : Window
    {

        SqlConnector sqlConnector = new SqlConnector();

        public string selectUsers = @"SELECT Users.FirstName, Users.LastName, Users.Birthdate, Roles.Title, Users.Email, Offices.Title as Office, Users.Active
                                    FROM Users
                                    JOIN Roles ON Users.RoleID = Roles.ID
                                    JOIN Offices ON Users.OfficeID = Offices.ID";

        public AdminPanel()
        {
            InitializeComponent();
        }

        DataTable newDataTable;

        private void refreshDataGrid()
        {
            OfficesData.ItemsSource = null;
            OfficesData.ItemsSource = UserData.dataTables;
        }

        private void ShowAddUser(object sender, RoutedEventArgs e)
        {
            AddUser addUserPanel = new AddUser();
            addUserPanel.Show();
        }

        public void getClassData(string selectUsers)
        {

            var reader = sqlConnector.Queryes(selectUsers);

            int nowYear = DateTime.Now.Year;

            while (reader.Read())
            {
                try
                {
                    int age = nowYear - DateTime.Parse(reader["Birthdate"].ToString()).Year;
                    newDataTable = new DataTable
                    {
                        FirstName = reader["FirstName"],
                        LastName = reader["LastName"],
                        Age = age,
                        Role = reader["Title"],
                        EmailAddress = reader["Email"],
                        Offices = reader["Office"],
                        Active = reader["Active"]
                    };

                    UserData.dataTables.Add(newDataTable);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            sqlConnector.sqlConnection.Close();
        }

        public void GetOfficesDict(Dictionary<string, int> officesObj)
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

        private void AdminPanelWindow_Loaded(object sender, RoutedEventArgs e)
        {
            getClassData(selectUsers);
            OfficesData.ItemsSource = UserData.dataTables;
            GetOfficesDict(UserData.officesObj);
        }

        private void gridProducts_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                DataTable dataTable = (DataTable)e.Row.DataContext;

                if (dataTable.Role.ToString() == "Administrator") e.Row.Background = getColor(Colors.Lime);
                if (dataTable.Active.ToString() == "False") e.Row.Background = getColor(Colors.Red);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private SolidColorBrush getColor(Color color)
        {
            SolidColorBrush col = new SolidColorBrush(color);
            return col;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPanelWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            DataTable dataTable = detectUser();

            ChangeQueries commandNonActive = new ChangeQueries("Active=0", dataTable.EmailAddress.ToString(),
                dataTable.FirstName.ToString(), dataTable.LastName.ToString());
            ChangeQueries commandIsActive = new ChangeQueries("Active=1", dataTable.EmailAddress.ToString(),
                dataTable.FirstName.ToString(), dataTable.LastName.ToString());

            bool active = (bool)dataTable.Active;

            if (active)
            {
                changeUserRow(commandNonActive.command, Colors.Red);
                dataTable.Active = false;
            }
            else
            {
                changeUserRow(commandIsActive.command, Colors.White);
                dataTable.Active = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                ChangeRole changeRole = new ChangeRole();
                DataTable dataTable = detectUser();
                if (dataTable == null)
                {
                    MessageBox.Show("Пользователь не выбран!");
                    return;
                }
                UserData.email = dataTable.EmailAddress.ToString();

                changeRole.Show();
            }
            catch
            {
                MessageBox.Show("Пользователь не выбран!");
            }
        }

        private void changeUserRow(string query, Color color)
        {

            string command = query;
            sqlConnector.getQuery(command);
            int cell = OfficesData.SelectedIndex;

            DataGridRow row = (DataGridRow)OfficesData.ItemContainerGenerator.ContainerFromIndex(cell);
            row.Background = getColor(color);
        }


        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            if (selectedItem.Content != null)
            {
                string officeTitle = selectedItem.Content.ToString();
                string sqlCommand1 = String.Format(@"SELECT Users.FirstName, Users.LastName, Users.Birthdate, Roles.Title, Users.Email, Offices.Title as Office, Users.Active
                                    FROM Users
                                    JOIN Roles ON Users.RoleID = Roles.ID
                                    JOIN Offices ON Users.OfficeID = Offices.ID
                                    WHERE Offices.Title = '{0}'", officeTitle);

                UserData.dataTables.Clear();
                if (officeTitle == "All officces") getClassData(selectUsers);
                else getClassData(sqlCommand1);

                refreshDataGrid();
            }
        }

        public DataTable detectUser()
        {

            DataTable dataTable = (DataTable)OfficesData.SelectedItem;

            return dataTable;
        }

        private struct ChangeQueries
        {
            public string query, email, firstName, lastName, command;

            public ChangeQueries(string query, string email, string firstName, string lastName)
            {
                this.query = query;
                this.email = email;
                this.firstName = firstName;
                this.lastName = lastName;

                command = $"UPDATE Users SET {query} WHERE Email='{email}'" +
                    $" AND FirstName='{firstName}' AND LastName='{lastName}'";
            }
        }
    }
}