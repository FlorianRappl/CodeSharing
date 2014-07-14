using System;
using System.IO;
using System.Threading.Tasks;

namespace CodeSharing.Pcl03
{
    public interface IFileLogic
    {
        Task Load(Func<Stream, Task> loading);

        Task Save(Func<Stream, Task> saving);
    }
}
