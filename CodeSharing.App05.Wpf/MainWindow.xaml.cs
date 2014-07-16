using System.Reflection;
using System.Windows;

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
            var inspector = new Inspector(Assembly.GetExecutingAssembly());
            DataContext = inspector.GetInstance<IMessageHolder>();
        }
    }
}
