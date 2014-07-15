using CodeSharing.Pcl04;
using System.Windows;

namespace CodeSharing.App04.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ITracker tracker;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = tracker = new MouseTracker();
        }

        private void StopTracking(object sender, RoutedEventArgs e)
        {
            tracker.Stop();
        }

        private void StartTracking(object sender, RoutedEventArgs e)
        {
            tracker.Start();
        }
    }
}
