using System;

namespace Task5
{
    public class Program
    {
        public static void Main()
        {
            BackupSystem.PrepareForTracking(Constants.TrackingFolderPath);
            Console.WriteLine("If you want to track changes, please press 1");
            Console.WriteLine("If you want to backup folder, please press 2");
            string key = Console.ReadLine();
            switch (key)
            {
                case "1":
                    {
                        Console.WriteLine("Program in tracking mode");
                        BackupSystem.TrackChanges(Constants.TrackingFolderPath);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Enter date and time");
                        try
                        {
                            DateTime dateAndTime = DateTime.Parse(Console.ReadLine());
                            BackupSystem.Backup(Constants.TrackingFolderPath, dateAndTime);
                        }
                        catch (Exception e)
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