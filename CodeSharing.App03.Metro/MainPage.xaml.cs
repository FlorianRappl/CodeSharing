using CodeSharing.Pcl03;
using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CodeSharing.App03.Metro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly ConfigurationViewModel _content;
        readonly ConfigurationManager _config;

        public MainPage()
        {
            var configFileLogic = new MetroConfigFileLogic(ApplicationData.Current.LocalFolder, "test.config");

            _content = new ConfigurationViewModel();
            _config = new ConfigurationManager(configFileLogic);

            this.InitializeComponent();
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
                KeyValueText.Text = String.Empty;
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
