using System;
using System.Globalization;
using System.Threading;

using System.Configuration;

namespace Task5
{
    public class Program
    {
        public static void Main()
        {
            string trackingFolderPath = @"D:\XT2016_3\Tasks\WatchedFolder";
            BackupSystem.PrepareForTracking(trackingFolderPath);
            Console.WriteLine("If you want to track changes, please press 1");
            Console.WriteLine("If you want to backup folder, please press 2");
            string key = Console.ReadLine();
            switch (key)
            {
                case "1":
                    {
                        Console.WriteLine("Program in tracking mode");
                        BackupSystem.TrackChanges(trackingFolderPath);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Enter date and time");
                        try
                        {
                            DateTime dateAndTime = DateTime.Parse(Console.ReadLine());
                            BackupSystem.Backup(trackingFolderPath, dateAndTime);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Please, try it again");
                            break;
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid key");
                        break;
                    }
            }
        }
    }
}