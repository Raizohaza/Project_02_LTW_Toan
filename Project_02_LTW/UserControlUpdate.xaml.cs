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

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for UserControlUpdate.xaml
    /// </summary>
    public partial class UserControlUpdate : UserControl
    {
        private TCH _data;
        public UserControlUpdate()
        {
            InitializeComponent();
        }

        public UserControlUpdate(TCH x)
        {
            InitializeComponent();
            _data = x;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UserControlUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            NameTour.Text = _data.Name;
            IntroTour.Text = _data.Intro;
            data_member.ItemsSource = _data.list_member;
            CostListView.ItemsSource = _data.bill;
            MilestonesListView.ItemsSource = _data.Milestones;
            AdvanceList.ItemsSource = _data.Advance_Moneys;

            if (_data.Imagee.Contains(":\\"))
                ImageForTour.Source = new BitmapImage(new Uri(_data.Imagee));
            else
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                var absolute = $"{folder}imageeeee\\{_data.Imagee}";
                ImageForTour.Source = new BitmapImage(new Uri(absolute));
            }
        }
    }
}
