using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
В основной программе объявите и инициализируйте одномерный строковый массив 
и выполните циклический перебор его элементов с разных «начальных точек», 
разделяя элементы одним пробелом.

Тестирование приложения выполняется путем запуска разных наборов тестов.
На вход в первой строке поступает число - номер элемента, начиная с которого 
пойдет циклический перебор.
В следующей строке указаны элементы последовательности, разделенные одним или 
несколькими пробелами.
3
1 2 3 4 5
Программа должна вывести на экран:
3 4 5 1 2

В случае ввода некорректных данных выбрасывайте ArgumentException.

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.

 */
namespace Task02
{
    class IteratorSample : IEnumerable<string> // НЕ МЕНЯТЬ                     -хорошо
    {
        string[] values;
        int start;

        public IteratorSample(string[] values, int start)
        {
            this.values = values;
            this.start = start;
        }

        public IEnumerator<string> Cycle()
        {
            for (int i = start - 1; i < values.Length + start - 1; i++)
            {
                yield return values[i % values.Length];
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Cycle();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return values.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out int startingIndex) || startingIndex <=0)
                    throw new ArgumentException();
                try
                {
                    string[] values = Console.ReadLine().Split();
                    
                    if (startingIndex > values.Length)
                        throw new ArgumentException();
                    foreach (string ob in new IteratorSample(values, startingIndex))
                    {
                        if (ob != " " && ob != "" )
                        Console.Write(ob + " ");
                    }
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("error");
            }
            catch (Exception e)
            {
                Console.WriteLine("problem");
            }

            Console.ReadLine();
        }
    }
}
