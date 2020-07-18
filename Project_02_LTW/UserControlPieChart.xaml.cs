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
using LiveCharts;
using LiveCharts.Wpf;

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for UserControlPieChart.xaml
    /// </summary>
    public partial class UserControlPieChart : UserControl
    {
        public UserControlPieChart()
        {
            InitializeComponent();
        }
        public SeriesCollection Data => new SeriesCollection()
        {
          
            //new ColumnSeries()
            //{
            //    Title = "Khoan chi dau nam",
            //    Values = new ChartValues<float> {100, 200, 300, 400},
            //    Stroke = Brushes.Red,
            //    StrokeThickness = 5,
            //    Fill = Brushes.Green,
            //    StrokeDashArray = new DoubleCollection {4, 10, 1}
            //}

            new PieSeries()
            {
                Values = new ChartValues<float> {50 } , Title = "Minh"
            },
            new PieSeries()
            {
                Values = new ChartValues<float> {50 } , Title = "Long"
            },
            new PieSeries()
            {
                Values = new ChartValues<float> {30 } , Title = "Hang",
            },
            new PieSeries()
            {
                Values = new ChartValues<float> {15 } , Title = "Tuan",
            }
        };
        private void UserControl_Initialized(object sender, EventArgs e)
        {
            this.DataContext = this;
        }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = chartPoint.ChartView as PieChart;
            foreach (PieSeries pie in chart.Series)
            {
                pie.PushOut = 0;
            }

            var neo = chartPoint.SeriesView as PieSeries;
            neo.PushOut = 30;
        }
    }
}