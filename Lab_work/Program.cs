using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_work
{
    internal class Program
    {
        static void read(string file)
        {
            int vowel_letter = 0;
            int consonant_letter = 0;
            string vowels = "aoeiuyAOEIUYАОУЫЭЕЁИЮЯаоуыэеёиюя";
            using (FileStream stream = File.OpenRead(file))
            {
                byte[] array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.UTF8.GetString(array);
                for (int i = 0; i < textFromFile.Length; i++)
                {
                    char ch = textFromFile[i];
                    if (vowels.Contains(ch))
                    {
                        vowel_letter++;
                    }
                    else
                    {
                        consonant_letter++;
                    }
                }
                Console.WriteLine($"\nСтрока находящиеся в файле {file}: {textFromFile}.\n");
                Console.WriteLine($"Кол-во гласных — {vowel_letter},\nКол-во согласных — {consonant_letter}.");
            }
        }
        static int[,] Multiplication(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            if (a.GetLength(1) != b.GetLength(0))
            {
                Console.WriteLine("Матрицы нельзя перемножить.");
                r = new int[0, 0];
            }
            else
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        for (int k = 0; k < b.GetLength(0); k++)
                        {
                            r[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
            }
            return r;
        }
        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Input(out int[,] A, out int[,] B)
        {
            Console.WriteLine("Введите размерность первой матрицы. ");
            Console.Write("\nВведите высоту первой матрицы: ");
            int.TryParse(Console.ReadLine(), out int height);
            Console.Write("Введите ширину первой матрицы: ");
            int.TryParse(Console.ReadLine(), out int wight);
            A = new int[height, wight];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    A[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Введите размерность второй матрицы. ");
            Console.Write("\nВведите высоту вторйо матрицы: ");
            int.TryParse(Console.ReadLine(), out height);
            Console.Write("Введите ширину второй матрицы: ");
            int.TryParse(Console.ReadLine(), out wight);
            B = new int[height, wight];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write("B[{0},{1}] = ", i, j);
                    B[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        static Dictionary<string, double> Temperatur(int[,] Temp)
        {
            int sum;
            double arithmetic_mean;
            var Dictionary_Temp = new Dictionary<string, double>();
            for (int i = 0; i < Temp.GetLength(0); i++)
            {
                sum = 0;
                arithmetic_mean = 0;
                for (int j = 0; j < Temp.GetLength(1); j++)
                {
                    sum += Temp[i, j];
                }
                arithmetic_mean = (double) sum / Temp.GetLength(1);
                Dictionary_Temp.Add($"Month{i+1}", Math.Round(arithmetic_mean, 2));
            }
            return Dictionary_Temp;
        }
            static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.\nНаписать программу, которая вычисляет число гласных и согласных букв в файле.");
            Console.WriteLine("Задание 2.\nНаписать программу, реализующую умножению двух матриц, заданных в виде двумерного массива.");
            Console.WriteLine("Задание 3.\nНаписать программу, вычисляющую среднюю температуру месяца в течение года, вывести по возрастанию.");
            bool flag = true;
            while (flag)
            {
                Console.Write("\nВведите номер задания (1, 2, 3) для его проверки или 'break' для выходи из программы: ");
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        string File_name = "Text.txt";
                        read(File_name);
                        break;
                    case "2":
                        Input(out int[,] A, out int[,] B);
                        Console.WriteLine("\nМатрица A: ");
                        Print(A);
                        Console.WriteLine("\nМатрица B: ");
                        Print(B);
                        Console.WriteLine("\nМатрица C = A * B: ");
                        int[,] C = Multiplication(A, B);
                        Print(C);
                        break;
                    case "3":
                        Random random = new Random();
                        var Temperature = new int[12, 30];
                        for (int i = 0; i < Temperature.GetLength(0); i++)
                        {
                            for (int j = 0; j < Temperature.GetLength(1); j++)
                            {
                                Temperature[i, j] = random.Next(-30, 30);
                            }
                        }
                        Dictionary<string, double> dict = Temperatur(Temperature);
                        var sortedDict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                        foreach (var item in sortedDict)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "break":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nДанного задания не существует или не правильно введён 'break'.");
                        break;
                }
            }
        }
    }
}
