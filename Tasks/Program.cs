using System;

namespace Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.\nЗадание отсутствует.");
            Console.WriteLine("Задание 2.\nЗадание отсутствует.");
            Console.WriteLine("Задание 3.\nЗадание отсутствует.");
            Console.WriteLine("Задание 4.\nЗадание отсутствует.");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nВведите номер задания (1, 2, 3) для его проверки или 'break' для выходи из программы: ");
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("\nДанного задания не существует или не правильно введён 'break'.");
                        break;
                }
            }
        }
    }
}
