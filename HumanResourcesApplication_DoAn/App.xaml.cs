using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HumanResourcesApplication_DoAn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginWindow();
            loginView.Show();
            BindingImage bindingIcon = new BindingImage();
            BitmapSource icon = new BitmapImage(new Uri(bindingIcon.ConvertPath("favicon.ico")));
            Current.MainWindow.Icon = new BitmapImage();
            Current.MainWindow.Icon = icon;
        }
        protected override void OnStartup(StartupEventArgs e)
        { 
            base.OnStartup(e);

            // Lấy hình ảnh biểu tượng và tạo một đối tượng BitmapSource.
            

            // Đặt hình ảnh biểu tượng cho ứng dụng.
           

            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Use "vi-VN" for Vietnamese format
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            cultureInfo.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
