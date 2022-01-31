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
            try
            {
                string detectCountryIdCommand = "SELECT * FROM Offices";
                var reader = sqlConnector.Queryes(detectCountryIdCommand);

                Dictionary<string, int> officesObj = new Dictionary<string, int> { };

                while (reader.Read())
                {
                    officesObj[reader["Title"].ToString()] = Int32.Parse(reader["ID"].ToString());
                }

                foreach (var item in officesObj)
                {
                    MessageBox.Show(item[]);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
