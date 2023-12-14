using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.WPF;
using LiveChartsCore.Defaults;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Utils;
using System;
using LiveCharts;
using HumanResourcesApplication_DoAn.Repositories;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class DashBoardViewModel:ViewModelBase
    {
        private User user;
        private ObservableCollection<PieSeries<long>> pieSeriesCollection;
        private ObservableCollection<ColumnSeries<int>> columnSeriesCollection;
        private ObservableCollection<LineSeries<double>> lineSeriesCollection;
        private ObservableCollection<RowSeries<int>> rowSeriesCollection;
        private string organicProject;
        private string diretProject;
        private string referralProject;
        private string totalEmployee;
        private string totalDepartment;
        public string OrganicProject { get => organicProject; set { organicProject = value; OnPropertyChanged(nameof(OrganicProject)); } }
        public string DiretProject { get => diretProject; set { diretProject = value; OnPropertyChanged(nameof(DiretProject)); } }
        public string ReferralProject { get => referralProject; set { referralProject = value; OnPropertyChanged(nameof(referralProject)); } }
        public string TotalEmployee { get => totalEmployee; set { totalEmployee = value; OnPropertyChanged(nameof(TotalEmployee)); } }
        public string TotalDepartment { get => totalDepartment; set { totalDepartment = value; OnPropertyChanged(nameof(TotalDepartment)); } }
        public User User { get => user; set { user = value; OnPropertyChanged(nameof(User)); } }

        
        public ObservableCollection<PieSeries<long>> PieSeriesCollection
        {
            get { return pieSeriesCollection; }
            set { pieSeriesCollection = value; OnPropertyChanged(nameof(PieSeriesCollection)); } 
        }
        public ObservableCollection<ColumnSeries<int>> ColumnSeriesCollection 
        { 
            get => columnSeriesCollection;
            set
            {
                columnSeriesCollection = value;
                OnPropertyChanged(nameof(ColumnSeriesCollection));
            }
        }
        public ObservableCollection<LineSeries<double>> LineSeriesCollection 
        { 
            get => lineSeriesCollection;
            set
            {
                lineSeriesCollection = value;
                OnPropertyChanged(nameof(LineSeriesCollection));
            }
        }
        public ObservableCollection<RowSeries<int>> RowSeriesCollection 
        { 
            get => rowSeriesCollection;
            set
            {
                rowSeriesCollection = value;
                OnPropertyChanged(nameof(RowSeriesCollection));
            }
        }
        public DashBoardViewModel()
        {
            user = new User();
            user = MyApp.currentUser;
            ExcuteInitPieChartMonthCommand(null);
            ExcuteInitColumnChartCommand(null);
        }
        //COLUMNCHART
        public ViewModelCommand InitColumnChartCommand { get; }
        private void ExcuteInitColumnChartCommand(object? obj)
        {
            string currentYear = DateTime.Now.Year.ToString();
            totalDepartment = (DashboarRepository.Instance.QueryTotalDepartmentInYear(currentYear)).ToString();
            totalEmployee = (DashboarRepository.Instance.QueryTotalEmployeeInYear(currentYear)).ToString();

            columnSeriesCollection = new ObservableCollection<ColumnSeries<int>>
            {
                new ColumnSeries<int>
            {
                Name = "Department",
                Fill = new SolidColorPaint(SKColors.Blue),
                Values = new int[]{int.Parse(totalDepartment),13,15,17,19,20 },
                Stroke = null,
                MaxBarWidth = 20,
                Rx = 50,
                Ry = 50
             },

              new ColumnSeries<int>
              {
                  Name = "Employee",
                  Fill = new SolidColorPaint(SKColors.Gray),
                  Values = new int[]{int.Parse(totalEmployee),20,30,40,50,60 },
                  Stroke = null,
                  MaxBarWidth = 20,
                  Rx = 50,
                  Ry = 50
              },
            };
        }


        public Axis[] XAxes1 { get; set; }
         = new Axis[]
         {
            new Axis
            {
                NamePaint = new SolidColorPaint(SKColors.Blue),
                LabelsPaint = new SolidColorPaint(SKColors.Gray),
                TextSize = 12,
                Labels = new string[] {DateTime.Now.Year.ToString(),"2024","2025","2026","2027","2028"}
           }
         };
        public Axis[] YAxes1 { get; set; }
        = new Axis[]
        {
            new Axis
            {
                ForceStepToMin = true,
                MinStep = 10,
                SeparatorsAtCenter = false,
                MaxLimit = 60,
                MinLimit = 0,
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Gray),
                TextSize = 12,
            }
        };

        //PIECHART
        public ViewModelCommand InitPieChartMonthCommand { get; }
        private void ExcuteInitPieChartMonthCommand(object? obj)
        {
            string currentYear = DateTime.Now.Year.ToString();
            OrganicProject = (DashboarRepository.Instance.QueryOrganicPJInYear(currentYear)).ToString();
            DiretProject = (DashboarRepository.Instance.QueryDirectPJRevenueInYear(currentYear)).ToString();
            ReferralProject = (DashboarRepository.Instance.QueryReferralPJRevenueInYear(currentYear)).ToString();
            if (OrganicProject == "") OrganicProject = "0";
            if (DiretProject == "") DiretProject = "0";
            if (ReferralProject == "") ReferralProject = "0";

            ObservableCollection<long> organic = new ObservableCollection<long>();
            organic.Add(long.Parse(OrganicProject));
            ObservableCollection<long> diret = new ObservableCollection<long>();
            diret.Add(long.Parse(DiretProject));
            ObservableCollection<long> referral = new ObservableCollection<long>();
            referral.Add(long.Parse(ReferralProject));

            pieSeriesCollection
        = new ObservableCollection<PieSeries<long>>
        {
            new PieSeries<long> {
                Name = "Diret",
                Fill = new SolidColorPaint(SKColors.LightBlue),
                InnerRadius = 60,
                Values = diret
            },
            new PieSeries<long> {
                Name = "Organic",
                Fill = new SolidColorPaint(SKColors.Blue),
                Values = organic,
                InnerRadius = 60,

            },
            new PieSeries<long> {
                Name = "Referral",
                Fill = new SolidColorPaint(SKColors.LightSteelBlue),
                Values =  referral,
                InnerRadius = 60,
            }, 
        };
        }

        //LINECHART

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

        //ROWCHART
        public ObservableCollection<ISeries> Series4 { get; set; }
       = new ObservableCollection<ISeries>
       {
            new RowSeries<int>
            {
                Name = "Object1",
                Values = new int[]{80},
                Stroke = null,
                MaxBarWidth = 30,
                Rx = 50,
                Ry = 50
            },
            new RowSeries<int>
            {
                Name = "Object2",
                Stroke = null,
                Values = new int[]{50},
                Rx = 50,
                MaxBarWidth = 30,
                Ry = 50
            },
            new RowSeries<int>
            {

                Name = "Object3",
                Stroke = null,
                Values = new int[]{30},
                Rx = 50,
                MaxBarWidth = 30,
                Ry = 50
            },
            new RowSeries<int>
            {

                Name = "Object4",
                Stroke = null,
                Values = new int[]{20},
                Rx = 50,
                MaxBarWidth = 30,
                Ry = 50
            },
            new RowSeries<int>
            {

                Name = "Object5",
                Stroke = null,
                Values = new int[]{10},
                Rx = 50,
                MaxBarWidth = 30,
                Ry = 50
            },
       };
        public Axis[] YAxes3 { get; set; }
        = new Axis[]
        {
            new Axis
            {
                TextSize = 0
            }
        };

    }
}
