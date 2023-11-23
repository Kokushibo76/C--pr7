using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktosikNomer7
{
    public class D4C
    {
        static void Main(string[] args)
        {
            do
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.Clear();
                Console.WriteLine("Позиции:");

                foreach (var drive in drives)
                {
                    Console.WriteLine ("   " + drive.Name + " " + drive.TotalSize / 1073741824 + " Гб " + "Доступно: " + drive.AvailableFreeSpace / 1073741824 + "Гб");
                }

                int pos = Strelocki.strelochk1(1, drives.Length + 2);
                if (pos != -1)
                {
                    fayliki.ShowDirectoryInfo(drives[pos - 1].RootDirectory.FullName);
                }
            } while (true);
        }
    }
}

public class Strelocki
    {
        public static int strelochk1(int min, int max)
        {
            int pos = 1;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != min)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != max)
                {
                    pos++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    pos = -1;
                    return pos;
                }

            } while (key.Key != ConsoleKey.Enter);
              return pos;
        }
    }
    public static class fayliki
    {
        public static void ShowDirectoryInfo(string ab)
        {
            while (true)
            {
                Console.Clear();
                var folders = Directory.GetDirectories(ab);
                var file1 = Directory.GetFiles(ab);
                var spisok = new List<string>();

                spisok.AddRange(folders);
                spisok.AddRange(file1);

                int i;

                foreach (var folder in folders)
                {
                    spisok.Add(folder);
                }

                foreach (var file in file1)
                {
                    spisok.Add(file);
                }

                foreach (string corsina in folders)
                {
                    var createDate = Directory.GetCreationTime(corsina);

                    Console.Write("  Место проживания файла: " + corsina);
                    Console.SetCursorPosition(60, Console.CursorTop);
                    Console.WriteLine("Дата и время рождения файла: " + createDate);
                }
                foreach (string file in file1)
                {
                    var createDate = Directory.GetCreationTime(file);

                    Console.Write("  Место проживания файла: " + file);
                    Console.SetCursorPosition(54, Console.CursorTop);
                    Console.Write("      Дата и время рождения файла: " + createDate + "\n");
                }

                int pos = Strelocki.strelochk1(1, folders.Length + file1.Length);
                
                if (pos != -1)
                {
                    try
                    {
                        ShowDirectoryInfo(spisok[pos]);
                    }
                    catch (IOException)
                    {
                        Process.Start(new ProcessStartInfo { FileName = spisok[pos], UseShellExecute = true });
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }