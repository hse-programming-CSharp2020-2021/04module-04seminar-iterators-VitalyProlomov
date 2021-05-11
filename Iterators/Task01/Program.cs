using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Необходимо построить ряд чисел Фибоначчи, ограниченный числом, введенным с клавиатуры.
 * 
 * Пример входных данных:
 * 6
 * Пример выходных данных:
 * 1 1 2 3 5
 * Пояснение:
 * следующее число 3 + 5 = 8 не выводится на экран, так как 8 > 6.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * 
*/
namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                if (!int.TryParse((input), out int value))
                    throw new ArgumentException();
                if (value <= 0)
                    throw new ArgumentException();
                foreach (int el in Fibonacci(value))
                {
                    Console.Write(el + " ");
                }
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }

        public static IEnumerable<int> Fibonacci(int maxValue)
        {
            int a = 0;
            int b = 1;
            List<int> fibonacci = new List<int>();
            if (maxValue < 0)
                return null;
            fibonacci.Add(a);
            fibonacci.Add(b);
            while (a + b <= maxValue)
            {
                fibonacci.Add(a + b);
                a = b;
                b = fibonacci[fibonacci.Count - 1];
            }
            return fibonacci;
        }

    }
}

