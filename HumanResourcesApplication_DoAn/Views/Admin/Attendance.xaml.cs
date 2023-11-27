using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
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
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendance : UserControl
    {
        private IListAttendanceRepository? attendanceRepository;
        public Attendance()
        {
            InitializeComponent();
            attendanceRepository = new ListAttendanceRepository();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Attendance_Users);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object obj)
        {
            bool canFilter = false;
            if (string.IsNullOrEmpty(Attendancetxtfilter.Text))
                canFilter=true;
            else if (obj != null)
            {
                canFilter = ((obj as Attendance)?.Name.IndexOf(Attendancetxtfilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                
            }
            return canFilter;
        }
        private void AttendancetxtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Attendance_Users.ItemsSource).Refresh();
        }
    }
}
