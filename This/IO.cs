using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace This
{
    public sealed class IO
    {

        private static StorageFolder folder = ApplicationData.Current.LocalFolder;

        private static Exception exception;
        public static Exception Exception
        {

            get { return exception; }
        }

        public static async Task WriteDataToFileAsync(string fileName, string content)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(content);
             //   byte[] data = Encoding.Unicode.GetBytes(content);

            
                var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

                using (var s = await file.OpenStreamForWriteAsync())
                {
                    await s.WriteAsync(data, 0, data.Length);
                }
              

            }
               
            catch (Exception ex)
            {
               
            }
        }

        public static async Task<string> ReadFileContentsAsync(string fileName)
        {
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync(fileName);

             
                using (var streamReader = new StreamReader(file))
                {

                    string result = streamReader.ReadToEnd();
                    file.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                return string.Empty;
            }
        }

    }

}
