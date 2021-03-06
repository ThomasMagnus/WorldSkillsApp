using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSkillsApp
{
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
    
    internal static class UserData
    {
        public static ObservableCollection<DataTable> dataTables = new ObservableCollection<DataTable>();
        public static ObservableCollection<GetDataCrashes> CrashesData = new ObservableCollection<GetDataCrashes>();

        public static Dictionary<string, int> officesObj = new Dictionary<string, int> { };
        public static string email { get; set; }
        public static int roleId { get; set; }
    }

    public class DataCrashes
    {
        public static object UserId { set; get; }
        public static object UserEmail { set; get; }
        public static object FirstName { set; get; }
        public string NowDate { set; get; }
        public string LoginTime { set; get; }
        public string LogoutTime { set; get; }
        public string FullTime { set; get; }
        public string Error { set; get; }
    }

    public class GetDataCrashes
    {
        public string NowDate { set; get; }
        public string LoginTime { set; get; }
        public string LogoutTime { set; get; }
        public string FullTime { set; get; }
        public string Error { set; get; }
    } 
}
