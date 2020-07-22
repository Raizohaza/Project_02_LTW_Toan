using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for UserControlTourDetail.xaml
    /// </summary>
    public partial class UserControlTourDetail : UserControl
    {
        public TCH _data;
        int index;

        
        string get_tour;
        public UserControlTourDetail(TCH x, int i)
        {
            InitializeComponent();
            _data = x;
            index = i;
            get_tour = _data.Name;
        }


        private void ModifyData_Click(object sender, RoutedEventArgs e)
        {
            //Grid_1.Visibility = Visibility.Hidden;
            Grid_1.Children.Add(new UserControlUpdate(_data,index));
            _data = UserControlUpdate._data;
        }

        private void Show_PieChart_Click(object sender, RoutedEventArgs e)
        {
            Grid_1.Children.Add(new UserControlPieChart(_data));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_data.Imagee.Contains(":\\"))
                ImageTour.Source = new BitmapImage(new Uri(_data.Imagee));
            else
            {
                var folder2 = AppDomain.CurrentDomain.BaseDirectory;
                var absolute = $"{folder2}imageeeee\\{_data.Imagee}";
                ImageTour.Source = new BitmapImage(new Uri(absolute));
            }
            IntroTour.Text = _data.Intro;
            NameTour.Text = _data.Name;
            data_member.ItemsSource = _data.Members;

            data_member.ItemsSource = _data.Members;
            imagee_of_team.ItemsSource = _data.Milestones;
        }
    }
}

