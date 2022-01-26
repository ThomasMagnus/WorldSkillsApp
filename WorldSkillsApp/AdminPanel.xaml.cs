using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WorldSkillsApp
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {

        SqlConnector sqlConnector = new SqlConnector();
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanelWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string selectUsers = @"SELECT Users.FirstName, Users.LastName, Users.Birthdate, Roles.Title, Users.Email, Offices.Title as Office, Users.Active
                                    FROM Users
                                    JOIN Roles ON Users.RoleID = Roles.ID
                                    JOIN Offices ON Users.OfficeID = Offices.ID";

            var reader = sqlConnector.Queryes(selectUsers);

            List<DataTable> dataTables = new List<DataTable>();

            int nowYear = DateTime.Now.Year;

            while (reader.Read())
            {
                try
                {
                    int age = nowYear - DateTime.Parse(reader["Birthdate"].ToString()).Year;
                    DataTable newDataTable = new DataTable
                    {
                        FirstName = reader["FirstName"],
                        LastName = reader["LastName"],
                        Age = age,
                        Role = reader["Title"],
                        EmailAddress = reader["Email"],
                        Offices = reader["Office"],
                        Active = reader["Active"]
                    };

                    dataTables.Add(newDataTable);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            OfficesData.ItemsSource = dataTables;
        }

        private void gridProducts_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                DataTable dataTable = (DataTable)e.Row.DataContext;

                if (dataTable.Role.ToString() == "Administrator") e.Row.Background = getColor(Colors.Lime);
                if (dataTable.Active.ToString() == "False") e.Row.Background = getColor(Colors.Red);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private SolidColorBrush getColor(Color color)
        {
            SolidColorBrush col = new SolidColorBrush(color);
            return col;
        }

        public class DataTable
        {
            public object ID { get; set; }
            public object FirstName { get; set; }
            public object LastName { get; set; }
            public object Age { get; set; }
            public object Role { get; set; }
            public object EmailAddress { get; set; }
            public object Offices { get; set; }
            public object Active { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPanelWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = (DataTable)OfficesData.SelectedItem;
            string email = dataTable.EmailAddress.ToString();
            string firstName = dataTable.FirstName.ToString();
            string lastName = dataTable.LastName.ToString();

            bool active = (bool)dataTable.Active;
            string commandNonActive = $"UPDATE Users SET Active=0 WHERE Email='{email}' AND FirstName='{firstName}' AND LastName='{lastName}'";
            string commandIsActive = $"UPDATE Users SET Active=1 WHERE Email='{email}' AND FirstName='{firstName}' AND LastName='{lastName}'";

            void changeActive(string query, Color color)
            {
                string command = query;
                sqlConnector.getQuery(command);
                int cell = OfficesData.SelectedIndex;

                DataGridRow row = (DataGridRow)OfficesData.ItemContainerGenerator.ContainerFromIndex(cell);
                row.Background = getColor(color);
            }

            if (active)
            {
                changeActive(commandNonActive, Colors.Red);
            }
            else
            {
                changeActive(commandIsActive, Colors.White);
            }
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content != null)
            {
                MessageBox.Show(selectedItem.Content.ToString());
            }
        }


    }
}
