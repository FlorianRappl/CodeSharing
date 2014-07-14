using System;
using System.IO;
using System.Threading.Tasks;

namespace CodeSharing.Pcl03
{
    public class ConfigurationManager
    {
        IFileLogic _fileLogic;

        public ConfigurationManager(IFileLogic fileLogic)
        {
            _fileLogic = fileLogic;
        }

        public async Task<IConfiguration> Read()
        {
            var config = new DefaultConfiguration();

            await _fileLogic.Load(async stream =>
            {
                using (var reader = new StreamReader(stream))
                {
                    var line = String.Empty;

                    while (!String.IsNullOrEmpty(line = await reader.ReadLineAsync()))
                    {
                        var idx = line.IndexOf('=');

                        if (idx >= 0)
                        {
                            var key = line.Substring(0, idx).Trim();
                            var value = line.Substring(idx + 1).Trim();
                            config.Add(key, value);
                        }
                    }
                }
            });

            return config;
        }

        public async Task Save(IConfiguration configuration)
        {
            await _fileLogic.Save(async stream =>
            {
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var pair in configuration)
                        await writer.WriteLineAsync(String.Format("{0} = {1}", pair.Key, pair.Value));
                }
            });
        }
    }
}
