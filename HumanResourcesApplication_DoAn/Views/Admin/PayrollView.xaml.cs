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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HumanResourcesApplication_DoAn.Views.Admin
{
    /// <summary>
    /// Interaction logic for PayrollView.xaml
    /// </summary>
    public partial class PayrollView : UserControl
    {
        public PayrollView()
        {
            InitializeComponent();
            List<User> users = new List<User>();
            users.Add(new User() { number = "01", userName = "13 NOVEMBER 2023", email = "09:56", role = "19:56", Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "02", userName = "14 NOVEMBER 2023", email = "08:56", role = "16:56", Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "03", userName = "15 NOVEMBER 2023", email = "07:56", role = "17:56", Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "04", userName = "16 NOVEMBER 2023", email = "10:56", role = "18:56", Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "01", userName = "13 NOVEMBER 2023", email = "09:56", role = "19:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "02", userName = "14 NOVEMBER 2023", email = "08:56", role = "16:56", Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "03", userName = "15 NOVEMBER 2023", email = "07:56", role = "17:56", Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "04", userName = "16 NOVEMBER 2023", email = "10:56", role = "18:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "01", userName = "13 NOVEMBER 2023", email = "09:56", role = "19:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "02", userName = "14 NOVEMBER 2023", email = "08:56", role = "16:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "03", userName = "15 NOVEMBER 2023", email = "07:56", role = "17:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "04", userName = "16 NOVEMBER 2023", email = "10:56", role = "18:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "01", userName = "13 NOVEMBER 2023", email = "09:56", role = "19:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "02", userName = "14 NOVEMBER 2023", email = "08:56", role = "16:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "03", userName = "15 NOVEMBER 2023", email = "07:56", role = "17:56" , Salary = "19:56", status = "19:56" });
            users.Add(new User() { number = "04", userName = "16 NOVEMBER 2023", email = "10:56", role = "18:56" , Salary = "19:56", status = "19:56" });
            Users.ItemsSource = users;
        }
        public class User
        {

            public string number { get; set; }
            public string userName { get; set; }
            public string email { get; set; }
            public string role { get; set; }
            public string Salary { get; set; }
            public string status { get; set; }

        }
    }
}
