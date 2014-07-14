using CodeSharing.Pcl03;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CodeSharing.App03.Wpf
{
    class WpfConfigFileLogic : IFileLogic
    {
        readonly String _configurationFileName;

        public WpfConfigFileLogic(String configurationFileName)
        {
            _configurationFileName = configurationFileName;
        }

        public async Task Load(Func<Stream, Task> loading)
        {
            if (!File.Exists(_configurationFileName))
                return;

            using (var stream = File.Open(_configurationFileName, FileMode.Open))
                await loading(stream);
        }

        public async Task Save(Func<Stream, Task> saving)
        {
            using (var stream = File.Open(_configurationFileName, FileMode.Create))
                await saving(stream);
        }
    }
}
