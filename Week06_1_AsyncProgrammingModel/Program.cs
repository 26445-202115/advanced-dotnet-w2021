using System;
using System.IO;

namespace Week06_1_AsyncProgrammingModel
{
    class Program
    {

        static void Main(string[] args)
        {

            // get the path of the app data folder
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // create an DirectoryInfo object instance which contains information about the directory
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            // retrieve all the files ending with file extension .txt in the folder and all its subfolders
            var files = directoryInfo.GetFiles("*.txt", SearchOption.AllDirectories);

            Console.WriteLine($"Found {files.Length} files");

            var buffer = new byte[1024];
            foreach (var fileInfo in files)
            {
                var stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
                stream.BeginRead(buffer, 0, buffer.Length, HandleRead, stream);
            }

        }

        private static void HandleRead(IAsyncResult result)
        {
            var fileStream = (FileStream)result.AsyncState;
            var bytesRead = fileStream.EndRead(result);

            Console.WriteLine($"Read {bytesRead} bytes from file: {fileStream.Name}");
        }
    }
}
