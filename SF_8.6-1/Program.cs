using System;
using System.IO;
using System.Collections;

namespace SF_8._6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь до папки:\t");
            string path = string.Format(@"{0}", Console.ReadLine());
            DeleteFiles(path);

            Console.ReadKey();
        }
        static void DeleteFiles(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    foreach (var file in Directory.GetFiles(path))
                    {
                        DateTime fileCreationTime = File.GetCreationTime(file);
                        TimeSpan t = DateTime.Now - fileCreationTime;
                        if (t > TimeSpan.FromMinutes(30))
                        {
                            File.Delete(file);
                            Console.WriteLine("{0} - удален", file);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
