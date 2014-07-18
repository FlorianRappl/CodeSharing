using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CodeSharing.App05.Wpf
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await this.WaitForClick();
            var inspector = new Inspector(Assembly.GetExecutingAssembly());
            DataContext = inspector.GetInstance<IMessageHolder>();
        }
    }

    static class EventExtensions
    {
        public static async Task WaitForClick(this Control ctrl)
        {
            var task = new TaskCompletionSource<Boolean>();

            MouseButtonEventHandler handler = (s, ev) =>
            {
                task.SetResult(true);
            };

            ctrl.MouseDown += handler;

            await task.Task;

            ctrl.MouseDown -= handler;
        }
    }
}
