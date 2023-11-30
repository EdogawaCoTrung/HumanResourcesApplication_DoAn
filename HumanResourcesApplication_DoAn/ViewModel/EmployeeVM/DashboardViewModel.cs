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

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class DashboardViewModel:ViewModelBase
    {
        //COLUMNCHART
        public ObservableCollection<ISeries> Series1 { get; set; }
        = new ObservableCollection<ISeries>
        {
            new ColumnSeries<int>
            {
                Name = "Object1",
                Fill = new SolidColorPaint(SKColors.Blue),
                Values = new int[]{80,60,30,50,92,100},
                Stroke = null,
                MaxBarWidth = 10,
                Rx = 50,
                Ry = 50
            },
            new ColumnSeries<int>
            {
                Name = "Object2",
                Fill = new SolidColorPaint(SKColors.LightBlue),
                Stroke = null,
                Values = new int[]{50,40,60,70,75,75},
                Rx = 50,
                MaxBarWidth = 10,
                Ry = 50
            },
            new ColumnSeries<int>
            {

                Name = "Object3",
                Fill = new SolidColorPaint(SKColors.LightSteelBlue),
                Stroke = null,
                Values = new int[]{70,100,80,50,82,110},
                Rx = 50,
                MaxBarWidth = 10,
                Ry = 50
            }
        };


        public Axis[] XAxes1 { get; set; }
        = new Axis[]
        {
            new Axis
            {
                NamePaint = new SolidColorPaint(SKColors.Blue),
                LabelsPaint = new SolidColorPaint(SKColors.Gray),
                TextSize = 12,
                Labels = new string[] {"Otc1","Otc2","Otc3","Otc4","Otc5","Otc6"}
            }
        };
        public Axis[] YAxes1 { get; set; }
        = new Axis[]
        {
            new Axis
            {
                ForceStepToMin = true,
                MinStep = 30,
                SeparatorsAtCenter = false,
                MaxLimit = 120,
                MinLimit = 0,
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Gray),
                TextSize = 12,
            }
        };

        //PIECHART

        public ObservableCollection<ISeries> Series2 { get; set; }
        = new ObservableCollection<ISeries>
        {
            new PieSeries<double> {
                Name = "Object1",
                Fill = new SolidColorPaint(SKColors.LightBlue),
                InnerRadius = 60,
                Values = new ObservableCollection<double> { 28 },
            },
            new PieSeries<double> {
                Name = "Object2",
                Fill = new SolidColorPaint(SKColors.Blue),
                InnerRadius = 60,
                Values = new ObservableCollection<double> { 52 },

            },
            new PieSeries<double> {
                Name = "Object3",
                Fill = new SolidColorPaint(SKColors.LightSteelBlue),
                InnerRadius = 60,
                Values = new ObservableCollection<double> { 15 },

            },
        };

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
