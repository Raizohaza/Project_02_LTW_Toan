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
using Microsoft.Win32;
using System.Collections;

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for UserControlUpdate.xaml
    /// </summary>
    public partial class UserControlUpdate : UserControl
    {
        public static TCH _data;
        int index;
        public UserControlUpdate()
        {
            InitializeComponent();
        }

        public UserControlUpdate(TCH x,int i)
        {
            InitializeComponent();
            _data = x;
            index = i;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._data[index] = UserControlUpdate._data;
            string info = "";
            for (int i = 0; i < _data.Advance_Moneys.Count; i++)
            {
                info += $"{_data.Advance_Moneys[i].Info} so tien:{_data.Advance_Moneys[i].Money}\n";
            }
            if (info != "")
            {
                MessageBox.Show($"{info}", "Info", MessageBoxButton.OK);
            }
            this.Visibility = Visibility.Collapsed;
        }
        private void UserControlUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            NameTour.Text = _data.Name;
            IntroTour.Text = _data.Intro;
            data_member.ItemsSource = _data.Members;
            CostListView.ItemsSource = _data.bill;
            MilestonesListView.ItemsSource = _data.Milestones;
            if (_data.Advance_Moneys != null)
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

        //Trip
        private void Button_Get_Avatar_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                ImageForTour.Source = new BitmapImage(new Uri(screen.FileName));
            }
        }

        //List Member;
        private void Button_Get_Member_Avatar_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                var item = (list_member) (sender as FrameworkElement).DataContext;
                var index = data_member.Items.IndexOf(item);
                _data.Members[index].Member_Avatar = screen.FileName;

                data_member.ItemsSource = null;
                data_member.ItemsSource = _data.Members;
            }
        }

        private void MemberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = (list_member)(sender as FrameworkElement).DataContext;
            var index = data_member.Items.IndexOf(item);
            _data.Members[index].Member_Name = (sender as TextBox).Text;
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            list_member item = new list_member();
            _data.Members.Add(item);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (list_member)(sender as FrameworkElement).DataContext;
            var index = data_member.Items.IndexOf(item);
            _data.Members.RemoveAt(index);
        }




        //MileStone
        private void AddMilestone_Click(object sender, RoutedEventArgs e)
        {
            Milestone milestone = new Milestone();
            _data.Milestones.Add(milestone);
        }

        private void DeleteMilestone_Click(object sender, RoutedEventArgs e)
        {
            var item = (Milestone)(sender as FrameworkElement).DataContext;
            var index = MilestonesListView.Items.IndexOf(item);
            _data.Milestones.RemoveAt(index);
        }

        private void Button_Get_Milestone_Avatar_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                var item = (Milestone)(sender as FrameworkElement).DataContext;
                var index = MilestonesListView.Items.IndexOf(item);
                _data.Milestones[index].Part_Image = screen.FileName;

                MilestonesListView.ItemsSource = null;
                MilestonesListView.ItemsSource = _data.Milestones;
            }
        }
        private void PartTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = (Milestone)(sender as FrameworkElement).DataContext;
            var index = MilestonesListView.Items.IndexOf(item);
            _data.Milestones[index].Part = (sender as TextBox).Text;
        }

        private void Part_Detail_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = (Milestone)(sender as FrameworkElement).DataContext;
            var index = MilestonesListView.Items.IndexOf(item);
            _data.Milestones[index].Part_Detail = (sender as TextBox).Text;
        }

        //Cost
        private void AddCost_Click(object sender, RoutedEventArgs e)
        {
            bill item = new bill();
            _data.bill.Add(item);
        }

        private void CostNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = (bill)(sender as FrameworkElement).DataContext;
            var index = CostListView.Items.IndexOf(item);
            _data.bill[index].CostName = (sender as TextBox).Text;
        }

        private void CostTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = (bill)(sender as FrameworkElement).DataContext;
            var index = CostListView.Items.IndexOf(item);
            _data.bill[index].Cost = int.Parse((sender as TextBox).Text);
        }

        private void DeleteCost_Click(object sender, RoutedEventArgs e)
        {
            var item = (bill)(sender as FrameworkElement).DataContext;
            var index = CostListView.Items.IndexOf(item);
            _data.bill.RemoveAt(index);
        }

        private void AddAdvance_Click(object sender, RoutedEventArgs e)
        {
            Advance_Money item = new Advance_Money();
            _data.Advance_Moneys.Add(item);
        }

        private void DeleteAdvanceMoney_Click(object sender, RoutedEventArgs e)
        {
            var item = (Advance_Money)(sender as FrameworkElement).DataContext;
            var index = AdvanceList.Items.IndexOf(item);
            _data.Advance_Moneys.RemoveAt(index);
        }

        private void AdvanceMoney_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = (Advance_Money)(sender as FrameworkElement).DataContext;
            var index = AdvanceList.Items.IndexOf(item);
            _data.Advance_Moneys[index].Info = (sender as TextBox).Text;
        }

        private void AdvanceInfo_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = (Advance_Money)(sender as FrameworkElement).DataContext;
            var index = AdvanceList.Items.IndexOf(item);
            _data.Advance_Moneys[index].Money = int.Parse((sender as TextBox).Text);
        }
    }
}
