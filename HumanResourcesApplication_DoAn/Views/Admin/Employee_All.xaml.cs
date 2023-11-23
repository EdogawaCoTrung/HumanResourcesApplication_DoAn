using HumanResourcesApplication_DoAn.Model;
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
    /// Interaction logic for Employee_All.xaml
    /// </summary>
    public partial class Employee_All : UserControl
    {
        public Employee_All()
        {
            InitializeComponent();
            var converter = new BrushConverter();
            List<User> users = new List<User>();
            users.Add(new User() { Name = "Le Minh Toan", Email = "Cao Minh Quan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#1098AD"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Pham Hoang Tinh", Email = "Cao Minh Quan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#1E88E5"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Bui Tran Quang Trung", Email = "Le Minh Toan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Vu Thanh Tam", Email = "Joe Biden", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Le Ho Nhat Tan", Email = "Lee Sang Hiec", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Le Minh Toan", Email = "Cao Minh Quan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Pham Hoang Tinh", Email = "Cao Minh Quan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Bui Tran Quang Trung", Email = "Le Minh Toan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Vu Thanh Tam", Email = "Joe Biden", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Le Ho Nhat Tan", Email = "Lee Sang Hiec", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Le Minh Toan", Email = "Cao Minh Quan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Pham Hoang Tinh", Email = "Cao Minh Quan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Bui Tran Quang Trung", Email = "Le Minh Toan", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Vu Thanh Tam", Email = "Joe Biden", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            users.Add(new User() { Name = "Le Ho Nhat Tan", Email = "Lee Sang Hiec", Phone = 123456789, Employee_ID = "ABC123", JoinDate = "30 Apr, 2023", Role = "Developer", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), CharacterPicture = 'T' });
            Users.ItemsSource = users;
        }
        public class User
        {

            public string Name { get; set; }
            public string Email { get; set; }
            public int Phone { get; set; }
            public string Employee_ID { get; set; }
            public string JoinDate { get; set; }
            public string Role { get; set; }
            public Brush BgColor { get; set; }
            public char CharacterPicture { get; set; }
        }
    }
}
