using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Utils;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    class DashboardViewModel:ViewModelBase
    {
        private User _user;

        public User User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }
        public DashboardViewModel()
        {
            _user = new User();
            _user = MyApp.currentUser;

        }
        public ObservableCollection<ISeries> Series3 { get; set; }
        = new ObservableCollection<ISeries>
        {
            new LineSeries<double>
            {
                Name = "Base Salary",
                Fill = null,
                GeometryStroke = null,
                GeometryFill = null,
                Values = new double[]{10,10,15,20,20},
                LineSmoothness = 1
            },
            new LineSeries<double>
            {
                Name = "Attendance Bonus",
                Fill = null,
                GeometryStroke = null,
                GeometryFill = null,
                Values = new double[]{7,8,8,9,10},
                LineSmoothness = 1
            },
            new LineSeries<double>
            {
                Name = "Performance Bonus",
                Fill = null,
                GeometryStroke = null,
                GeometryFill = null,
                Values = new double[]{10,10,11,12,13},
                LineSmoothness = 1
            },
            new LineSeries<double>
            {
                Name = "Yearend Bonus",
                Fill = null,
                GeometryStroke = null,
                GeometryFill = null,
                Values = new double[]{6,6,7,7,9},
                LineSmoothness = 1
            },
        };
        public Axis[] YAxes2 { get; set; }
        = new Axis[]
        {
            new Axis
            {
                ForceStepToMin = true,
                MinStep = 5,
                SeparatorsAtCenter = false,
                MaxLimit = 20,
                MinLimit = 0,
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Gray),
                TextSize = 12,
            }
        };
        public Axis[] XAxes2 { get; set; }
        = new Axis[]
        {
            new Axis
            {
                ForceStepToMin = true,
                Labels= new string[]{"2019","2020","2021","2022","2023"},
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Gray),
                TextSize = 12,
            }
        };
    }
}
