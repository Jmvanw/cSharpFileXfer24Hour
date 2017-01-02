using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cSharpFileXfer24Hour
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime time = DateTime.Now;             // Use current time.
            string format = "MMM ddd d HH:mm yyyy";   // Use this format.
            Console.WriteLine(time.ToString(format)); // Write to console.

            Program.copyOver();

        }

        static string copyOver()
        {
            string srcDir = @"C:\Users\jmvan\Desktop\Folder A\"; //change to whatever you want your source file to be
            string desDir = @"C:\Users\jmvan\Desktop\Folder B\"; //change to whatever you want your destination file to be
            string FilesToMove = @"*.txt";
            var files = new DirectoryInfo(srcDir).GetFiles(FilesToMove);
            

            foreach (var file in files)
            {
                if (DateTime.UtcNow - file.LastWriteTimeUtc < TimeSpan.FromHours(24))
                {
                    string newFile = srcDir + file;
                    string moveHere = desDir + file;
                    File.Move(newFile, moveHere);
                    Console.WriteLine("File Moved");
                }
            }
            return "Something to Return";
        }
    }
}
