using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/* На вход подается число N.
 * На каждой из следующих N строках записаны ФИО человека, 
 * разделенные одним пробелом. Отчество может отсутствовать.
 * Используя собственноручно написанный итератор, выведите имена людей,
 * отсортированные в лексико-графическом порядке в формате 
 *      <Фамилия_с_большой_буквы> <Заглавная_первая_буква_имени>.
 * Затем выведите имена людей в исходном порядке.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield.
 * 
 * Пример входных данных:
 * 3
 * Banana Bill Bananovich
 * Apple Alex Applovich
 * Carrot Clark Carrotovich
 * 
 * Пример выходных данных:
 * Apple A.
 * Banana B.
 * Carrot C.
 * 
 * Banana B.
 * Apple A.
 * Carrot C.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
                    throw new ArgumentException();
                List<string> allNames = new List<string>(N);

                for (int i = 0; i < N; i++)
                {
                    allNames.Add(Console.ReadLine());
                }

                Person[] people = new Person[N];
                for (int i = 0; i < allNames.Count; i++)
                {
                    string[] parameters = allNames[i].Split();
                    if (parameters.Length < 2)
                        throw new ArgumentException();
                    string name = parameters[1];
                    string last = parameters[0];
                    people[i] = new Person(name, last);
                }

                People peopleList = new People(people);

                foreach (Person p in peopleList)
                    Console.WriteLine(p);

                Console.WriteLine();
                foreach (Person p in peopleList.GetPeople)
                    Console.WriteLine(p);
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }
    }

    public class Person
    {
        public string firstName;
        public string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return $"{lastName} {firstName.ToUpper()[0]}.";
        }
    }


    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] people)
        {
            _people = people;
        }

        public Person[] GetPeople
        {
            get => _people;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }


    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        private int index = -1;




        public PeopleEnum(Person[] persons)
        {
            _people = new Person[persons.Length];
            Array.Copy(persons, _people, persons.Length);
            Array.Sort(_people, (p1, p2) =>
            {
                int result = p1.lastName.CompareTo(p2.lastName);
                if (result == 0)
                    return p1.firstName.CompareTo(p2.firstName);
                return result;
            });


        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {

            if (index < _people.Length - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }


        public Person Current
        {
            get { return _people[index]; }
        }

    }
}
