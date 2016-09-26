using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DownloadYield
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"D:\回レ! 雪月花.mp3", FileMode.Create, FileAccess.Write);

            foreach (byte[] buffer in DownloadFile.Download())
            {
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
            }

            fs.Close();
            fs.Dispose();
            Console.WriteLine("OK"); 

            Console.ReadLine();
        }
    }

    public static class DownloadFile
    {
        public static IEnumerable<byte[]> Download()
        {
            var request = WebRequest.Create("http://nyan.90g.org/7/5/04/24013667eb69557b19ac03dfde8b36b3_320.mp3");

            var webResponse = request.GetResponse();
            const int bufferLen = 1024;
            byte[] buffer = new byte[bufferLen];
            using (var stream = webResponse.GetResponseStream())
            {
                if (stream == null) yield break;

                int count;
                do
                {
                    count = stream.Read(buffer, 0, buffer.Length);
                    if (count < bufferLen)
                    {
                        byte[] tmpBuffer = new byte[count];
                        Array.Copy(buffer, tmpBuffer, count);
                        yield return tmpBuffer;
                    }
                    else
                    {
                        yield return buffer;
                    }
                } while (count > 0);
            }
        }
    }
}
