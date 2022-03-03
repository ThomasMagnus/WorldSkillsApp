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

namespace WorldSkillsApp
{
    public partial class ChangeRole : Window
    {
        public ChangeRole()
        {
            InitializeComponent();
            DataTable user = new DataTable();
            DataContext = user;
        }

        AdminPanel adminPanel = new AdminPanel();

        SqlConnector sqlConnector = new SqlConnector();

        private void Apply_Change(object sender, RoutedEventArgs e)
        {

            string userEmail = UserData.email.ToString();


            string SQLCommand = $"UPDATE Users SET Email='{email.Text}', FirstName='{firstName.Text}', " +
                $"LastName='{lastName.Text}', OfficeID={UserData.officesObj[office.Text]}, RoleID={UserData.roleId} WHERE Email='{userEmail}'";

            sqlConnector.getQuery(SQLCommand);

            UserData.dataTables.Clear();
            adminPanel.getClassData(adminPanel.selectUsers);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            UserData.roleId = radioButton.Content.ToString() == "User" ? 2 : 1;
        }

        private void Cancel_Changes(object sender, RoutedEventArgs e)
        {
            ChangeRolePanel.Close();
        }
    }
}
