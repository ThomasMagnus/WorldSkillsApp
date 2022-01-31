using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WorldSkillsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            if (Regex.IsMatch(InputText.Text, pattern, RegexOptions.IgnoreCase))
            {
                SqlConnector sqlConnector = new SqlConnector();
                string login = InputText.Text;
                string sqlExpression = $"SELECT * FROM Users WHERE Email = '{login}'";
                PasswordBox password = PassInput;

                sqlConnector.SearchUser(sqlExpression, password, mainWindow);
            }
        }
    }
}
