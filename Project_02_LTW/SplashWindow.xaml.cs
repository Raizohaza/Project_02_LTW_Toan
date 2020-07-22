using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {


        private Random _rng = new Random();
        static List<string> Img = new List<string>();
        static List<string> Desc = new List<string>();
        ObservableCollection<TCH> _data;
        DispatcherTimer temp = new DispatcherTimer();
        string dataFile = "";
        public SplashWindow()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{file}SplashWindow.txt";
            var data = File.ReadAllText(dataFile);
            if (data == "true")
            {
                var screen = new MainWindow();
                screen.Show();
                this.Close();
            }
            else
            {
                temp.Tick += new EventHandler(temp_Tick);
                temp.Interval = new TimeSpan(0, 0, 60);
                temp.Start();
            }


        }

        private void temp_Tick(object sender, EventArgs e)
        {
            if (check == true)
            {
                var screen = new MainWindow();
                screen.Show();
                temp.Stop();
                this.Close();
            }
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {

            // đọc file data_travel

            var file = AppDomain.CurrentDomain.BaseDirectory;
            var database = $"{file}data_travel.txt";
            var lines = File.ReadAllLines(database);
            var count = int.Parse(lines[0]);
            _data = new ObservableCollection<TCH>();


            // lấy giá trị các dòng trong file data_travel

            for (int i = 0; i < count; i++)
            {
                var line1 = lines[i * 4 + 1];
                var line2 = lines[i * 4 + 2];

                var line3 = lines[i * 4 + 3];
                var line4 = lines[i * 4 + 4];


                var tmp = new TCH()
                {
                    Name = line1,
                    Imagee = line3,
                    Intro = line2,
                    Pass = line4,
                };
                _data.Add(tmp);
            }

            // xuất 

            var temp = _rng.Next(_data.Count);
            NameImg.Text = _data[temp].Name;
            Intro.Text = _data[temp].Intro;
            dataFile = $"{file}imageeeee\\{_data[temp].Imagee}";
            Autoimg.ImageSource = new BitmapImage(new Uri(dataFile));

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{file}SplashWindow.txt";
            File.AppendAllText(dataFile, "true");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory;
            dataFile = $"{file}SplashWindow.txt";
            File.Create(dataFile).Close();
        }
        bool check = true;

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            check = false;
            var screen = new MainWindow();
            screen.Show();
            this.Close();
        }
    }
}
