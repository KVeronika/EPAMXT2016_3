using System;
using XT2016_3.UserInfo.Entities;
using XT2016_3.UserInfo.Logic;
using XT2016_3.UserInfo.LogicContracts;

namespace XT2016_3.UserInfo.ConsoleUI
{
    internal class Program
    {
        private static IUserLogic userLogic;
        private static IAwardLogic awardLogic;

        static Program()
        {
            userLogic = new UserLogic();
            awardLogic = new AwardLogic();
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("1. Add user");
                    Console.WriteLine("2. Delete user");
                    Console.WriteLine("3. Show users");
                    Console.WriteLine("4. Add new award");
                    Console.WriteLine("5. Show awards list");
                    Console.WriteLine("6: Add award to user");
                    Console.WriteLine("7: Show users with awards");
                    Console.WriteLine("0. Exit");

                    ConsoleKeyInfo entry = Console.ReadKey(intercept: true);
                    switch (entry.Key)
                    {
                        case ConsoleKey.D1:
                            AddUser();
                            break;

                        case ConsoleKey.D2:
                            DeleteUser();
                            break;

                        case ConsoleKey.D3:
                            ShowUsers();
                            break;

                        case ConsoleKey.D4:
                            AddAward();
                            break;

                        case ConsoleKey.D5:
                            ShowAwards();
                            break;

                        case ConsoleKey.D6:
                            AddAwardToUser();
                            break;

                        case ConsoleKey.D7:
                            ShowUsersWithAwards();
                            break;

                        case ConsoleKey.D0:
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ReadLine();
                }
            }
        }

        private static void AddUser()
        {
            try
            {
                Console.WriteLine("Enter username:");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter date of birth:");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                User user = userLogic.Add(userName, dateOfBirth);
                Console.ReadLine();
            }
            catch
            {
                throw new FormatException("Invalid date, try again!");
            }
        }

        private static void DeleteUser()
        {
            try
            {
                Console.WriteLine("Enter id of user that you need delete:");
                int idForDelete = int.Parse(Console.ReadLine());
                userLogic.Delete(idForDelete);
                Console.ReadLine();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (FormatException)
            {
                throw new FormatException("Id must be number!!!");
            }
        }

        private static void ShowUsers()
        {
            User[] users = userLogic.GetAll();
            if (!(users.Length == 0))
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id}. {user.Name} Date of birth: {user.DateOfBirth}, Age: {user.Age}");
                }
            }
            else
            {
                Console.WriteLine("Haven't users");
            }

            Console.ReadLine();
        }

        private static void AddAward()
        {
            Console.WriteLine("Enter award title");
            string title = Console.ReadLine();
            Award award = awardLogic.Add(title);
        }

        private static void ShowAwards()
        {
            Award[] awards = awardLogic.GetAll();
            if (!(awards.Length == 0))
            {
                foreach (var award in awards)
                {
                    Console.WriteLine($"{award.Id}. {award.Title}");
                }
            }
            else
            {
                Console.WriteLine("Haven't awards");
            }

            Console.ReadLine();
        }

        private static void AddAwardToUser()
        {
            Console.WriteLine("Enter user id");
            int userId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter award id");
            int awardId = int.Parse(Console.ReadLine());
            userLogic.AddAward(userId, awardId);
        }

        private static void ShowUsersWithAwards()
        {
            User[] users = userLogic.GetAll();
            if (!(users.Length == 0))
            {
                foreach (var user in users)
                {
                    Console.Write($"{user.Id}. {user.Name} Date of birth: {user.DateOfBirth}, Age: {user.Age}");
                    Award[] userAwards = userLogic.GetUserAwards(user.Id);
                    if (userAwards.Length != 0)
                    {
                        Console.Write(" Awards:");
                    }

                    foreach (var award in userAwards)
                    {
                        Console.Write($" {award.Title}");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Haven't users");
            }

            Console.ReadLine();
        }
    }
}