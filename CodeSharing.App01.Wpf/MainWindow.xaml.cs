using CodeSharing.Pcl01;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CodeSharing.App01.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void name_TextChanged(Object sender, TextChangedEventArgs e)
        {
            var sample = new Sample(name.Text);
            greeting.Text = sample.Greetings();
            welcome.Text = sample.Welcome();
        }
    }
}
