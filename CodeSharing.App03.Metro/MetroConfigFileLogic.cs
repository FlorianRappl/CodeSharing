using CodeSharing.Pcl03;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace CodeSharing.App03.Metro
{
    class MetroConfigFileLogic : IFileLogic
    {
        readonly StorageFolder _configurationFolder;
        readonly String _configurationFileName;

        public MetroConfigFileLogic(StorageFolder configurationFolder, String configurationFileName)
        {
            _configurationFolder = configurationFolder;
            _configurationFileName = configurationFileName;
        }

        public async Task Load(Func<Stream, Task> loading)
        {
            try
            {
                var file = await _configurationFolder.GetFileAsync(_configurationFileName);
                
                using (var stream = await file.OpenAsync(FileAccessMode.Read))
                    await loading(stream.AsStreamForRead());
            }
            catch (FileNotFoundException)
            {
            }
        }

        public async Task Save(Func<Stream, Task> saving)
        {
            var file = await _configurationFolder.CreateFileAsync(_configurationFileName, CreationCollisionOption.ReplaceExisting);

            using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                await saving(stream.AsStreamForWrite());
        }
    }
}
