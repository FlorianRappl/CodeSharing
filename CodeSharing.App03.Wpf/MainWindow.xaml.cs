using CodeSharing.Pcl03;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CodeSharing.App03.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ConfigurationViewModel _content;
        readonly ConfigurationManager _config;

        public MainWindow()
        {
            var configPath = System.IO.Path.Combine(Environment.CurrentDirectory, "test.config");
            var configFileLogic = new WpfConfigFileLogic(configPath);

            _content = new ConfigurationViewModel();
            _config = new ConfigurationManager(configFileLogic);

            InitializeComponent();
            DataContext = this;
        }

        public ConfigurationViewModel ConfigurationContent
        {
            get { return _content; }
        }

        private void AddClick(Object sender, RoutedEventArgs e)
        {
            var text = KeyValueText.Text;
            var index = text.IndexOf('=');

            if (index >= 0)
            {
                var key = text.Substring(0, index).Trim();
                var value = text.Substring(index + 1).Trim();
                _content.Add(new KeyValuePair<String, String>(key, value));
                KeyValueText.Clear();
            }
        }

        private async void LoadClick(Object sender, RoutedEventArgs e)
        {
            var config = await _config.Read();
            _content.Clear();

            foreach (var pair in config)
                _content.Add(pair);
        }

        private async void SaveClick(Object sender, RoutedEventArgs e)
        {
            await _config.Save(_content);
        }
    }
}
