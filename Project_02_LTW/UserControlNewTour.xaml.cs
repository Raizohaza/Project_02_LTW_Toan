using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for UserControlNewTour.xaml
    /// </summary>
    public partial class UserControlNewTour : UserControl
    {
        public UserControlNewTour()
        {
            InitializeComponent();
        }

        public TCH _Tour { get; set; } = null;

        void Update()
        {
            string Step_Info = string.Concat("Member ", ":");
            MemberLabel.Text = Step_Info;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _Tour = new TCH();
            _Tour.Members = new BindingList<list_member>();
            _Tour.bill = new BindingList<bill>();

            Update();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        private void Button_Done_Click(object sender, RoutedEventArgs e)
        {
            _Tour.Imagee = Image_TextBox.Text;
            if (LeaderCheck.IsChecked == true)
                _Tour.Pass = "true";
            else _Tour.Pass = "false";
            _Tour.Name = Tour_Name.Text;
            _Tour.Intro = Intro_TextBox.Text;
            MainWindow._data.Add(_Tour);

            this.Visibility = Visibility.Collapsed;
        }

        private void Button_AddMember_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = result = MessageBox.Show("Bạn có muốn thêm thêm thành viên?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result.Equals(MessageBoxResult.OK))
            {

                _Tour.Members.Add(new list_member() { Member_Name = MemberTB.Text});
                MemberListView.ItemsSource = _Tour.Members;
                MemberTB.Text = string.Empty;
                Update();
            }

        }
        private void Button_AddCost_Click(object sender, RoutedEventArgs e)
        {
            var number = Int32.Parse(CostPriceTextBox.Text);
            List<bill> listBill = new List<bill>();
            MessageBoxResult result = result = MessageBox.Show("bạn có muốn thêm chi phí của lộ trình?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result.Equals(MessageBoxResult.OK))
            {
                
                _Tour.bill.Add(new bill { CostName = CostTextBox.Text, Cost = number });
                this.CostList.Items.Add(new bill { CostName = CostTextBox.Text, Cost = number });
                //CostList.ItemsSource = _Tour.bill;
                
                CostTextBox.Text = string.Empty;
                CostPriceTextBox.Text = string.Empty;
                Update();
            }
        }

        private void Button_Get_Avatar_Click(object sender, RoutedEventArgs e)
        {

            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                Image_TextBox.Text = screen.FileName;
                Image.Source = new BitmapImage(new Uri(screen.FileName));
            }

        }
        private void ListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}