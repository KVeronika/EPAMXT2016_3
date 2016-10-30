using System;

namespace Task2._7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("For creating figures enter codes:");
                Console.WriteLine("1: Line");
                Console.WriteLine("2: Circle");
                Console.WriteLine("3: Rectangle");
                Console.WriteLine("4: Round");
                Console.WriteLine("5: Ring");
                IFigure[] figures = new IFigure[5];
                string key;
                for (int i = 0; i < figures.Length; i++)
                {
                    key = Console.ReadLine();
                    switch (key)
                    {
                        case "1":
                            {
                                Console.WriteLine("Enter two points:");
                                string line = Console.ReadLine();
                                string[] mas = line.Split(' ');
                                figures[i] = new Line(new Point(int.Parse(mas[0]), int.Parse(mas[1])), new Point(int.Parse(mas[2]), int.Parse(mas[3])));
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("Enter coordinates and radius");
                                string line = Console.ReadLine();
                                string[] mas = line.Split(' ');
                                figures[i] = new Circle(int.Parse(mas[0]), int.Parse(mas[1]), int.Parse(mas[2]));
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Enter start point coordinates and tho lenth of sides");
                                string line = Console.ReadLine();
                                string[] mas = line.Split(' ');
                                figures[i] = new Rectangle(new Point(int.Parse(mas[0]), int.Parse(mas[1])), int.Parse(mas[2]), int.Parse(mas[3]));
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("Enter coordinates and radius");
                                string line = Console.ReadLine();
                                string[] mas = line.Split(' ');
                                figures[i] = new Round(int.Parse(mas[0]), int.Parse(mas[1]), int.Parse(mas[2]));
                                break;
                            }
                        case "5":
                            {
                                Console.WriteLine("Enter coordinates and two radiuses");
                                string line = Console.ReadLine();
                                string[] mas = line.Split(' ');
                                figures[i] = new Ring(int.Parse(mas[0]), int.Parse(mas[1]), int.Parse(mas[2]), int.Parse(mas[3]));
                                break;
                            }
                    }
                    Console.WriteLine("Figure created, enter next code");
                }

                Console.WriteLine("You create figures:");
                foreach (var item in figures)
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
