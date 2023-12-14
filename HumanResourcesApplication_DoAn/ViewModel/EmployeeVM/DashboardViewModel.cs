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
                Name = "Object1",
                Fill = null,
                GeometryStroke = null,
                GeometryFill = null,
                Values = new double[]{10,8,15,20,5},
                LineSmoothness = 1
            },
            new LineSeries<double>
            {
                Name = "Object2",
                Fill = null,
                GeometryStroke = null,
                GeometryFill = null,
                Values = new double[]{7,18,5,10,15},
                LineSmoothness = 1
            },
            new LineSeries<double>
            {
                Name = "Object3",
                Fill = null,
                GeometryStroke = null,
                GeometryFill = null,
                Values = new double[]{12,18,11,2,15},
                LineSmoothness = 1
            },
            new LineSeries<double>
            {
                Name = "Object4",
                Fill = null,
                GeometryStroke = null,
                GeometryFill = null,
                Values = new double[]{1,8,10,20,15},
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
    }
}
