using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace Task_2
{
    public partial class MainWindow : Window
    {


        System.Timers.Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            ConnectionDataButton.IsEnabled = true;
            DisconnectDataButton.IsEnabled = false;

            timer = new System.Timers.Timer();

            timer.Interval = 4000;
            timer.Elapsed += Tic_Timer;

        }


        async void Tic_Timer(object sender, ElapsedEventArgs e)
        {
            string text = await Task.Run(() =>
            {
                return "Дані отримані\n";
            });

            Dispatcher.Invoke(() =>
            {
                InfoBox.Text += text;
                InfoBox.ScrollToEnd();
                timer.Stop();
                DisconnectDataButton.IsEnabled = !DisconnectDataButton.IsEnabled;
                ConnectionDataButton.IsEnabled = !ConnectionDataButton.IsEnabled;
            });


        }




        private async void ConnectionDataButton_Click(object sender, RoutedEventArgs e)
        {
            InfoBox.Text += await Task.Run(() =>
            {
                Thread.Sleep(2000);
                timer.Start();
                return "Підключення До БД\n";
            });

        }

        private async void DisconnectDataButton_Click(object sender, RoutedEventArgs e)
        {

            InfoBox.Text += await Task.Run(() =>
            {
                Thread.Sleep(2000);
                timer.Start();
                return "Відключення від БД\n";
            });


        }
    }
}