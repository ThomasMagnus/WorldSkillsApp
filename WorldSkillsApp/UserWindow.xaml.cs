using System;
using System.Collections.Generic;
using System.Windows;

namespace WorldSkillsApp
{
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        SqlConnector connector;
        DataCrashes crashesData = new DataCrashes();
        GetDataCrashes getCrashesData;
        public string SqlRequest(string date, string loginTime, string logoutTime, string fullTime, string Error)
        {
            return String.Format("INSERT INTO Crashes VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                DataCrashes.UserId, DataCrashes.UserEmail.ToString(), date, loginTime, logoutTime, fullTime, Error);
        }

        private void detectedDays()
        {
            var limitDate = DateTime.Today.AddDays(-30);

            string commandSQL = $"SELECT * FROM Crashes WHERE NowDate > '{limitDate}' " +
                $"AND UserId ={Int32.Parse(DataCrashes.UserId.ToString())}";

            List<object> days = new List<object> { };

            connector = new SqlConnector();

            var reader = connector.Queryes(commandSQL);

            while (reader.Read()) if (reader.HasRows) days.Add(reader["FullTime"]);

            TimeSpan timeSpant = TimeSpan.Parse("00:00:00");

            foreach (var item in days) timeSpant += TimeSpan.Parse(item.ToString());

            TimeSpant.Text = $"Time spent on system: {timeSpant}";
        }

        private void Loading_Panel(object sender, RoutedEventArgs e)
        {
            detectedDays();
            welcomeText.Text = $"Hi {DataCrashes.FirstName}, Welcome to AMONIC Airlines.";

            crashesData.LoginTime = DateTime.Now.ToString("HH:mm");
            crashesData.NowDate = DateTime.Now.ToString("dd.MM.yyyy");

            string command = $"SELECT * FROM Crashes WHERE UserId={Int32.Parse(DataCrashes.UserId.ToString())}";

            connector = new SqlConnector();
            var reader = connector.Queryes(command);
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    getCrashesData = new GetDataCrashes();

                    getCrashesData.NowDate = DateTime.Parse(reader["FullTime"].ToString()).ToString("dd.MM.yyyy");
                    getCrashesData.LoginTime = reader["LoginTime"].ToString();
                    getCrashesData.LogoutTime = reader["LogoutTime"].ToString();
                    getCrashesData.FullTime = DateTime.Parse(reader["FullTime"].ToString()).ToString("HH:mm");
                    getCrashesData.Error = reader["ErrorText"].ToString();

                    UserData.CrashesData.Add(getCrashesData);
                }
            }
            

            CrashesData.ItemsSource = UserData.CrashesData;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            userWindow.Close();
        }

        private void PostCrashesData(string date, string loginTime, string logoutTime, string fullTime, string Error)
        {
            connector = new SqlConnector();
            string sqlCommand = SqlRequest(date, loginTime, logoutTime, fullTime, Error);
            connector.getQuery(sqlCommand);
        }
        private void userWindow_Closed(object sender, EventArgs e)
        {
            PostDataCrashes();
        }

        private void PostDataCrashes()
        {
            string logoutTime = DateTime.Now.ToString("HH:mm");
            TimeSpan fullTime = DateTime.Parse(logoutTime.ToString()) - DateTime.Parse(crashesData.LoginTime.ToString());
            crashesData.LogoutTime = logoutTime.ToString();
            crashesData.FullTime = fullTime.ToString();
            crashesData.Error = "";

            PostCrashesData(crashesData.NowDate.ToString(), crashesData.LoginTime.ToString(), crashesData.LogoutTime.ToString(),
                crashesData.FullTime.ToString(), crashesData.Error.ToString());
        }
    }
}
