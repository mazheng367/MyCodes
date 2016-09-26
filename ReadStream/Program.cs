using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadStream
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"D:\回レ! 雪月花.mp3", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024];
            int pos;
            while ((pos = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                Console.WriteLine($"read size:{pos}");
            }

            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
