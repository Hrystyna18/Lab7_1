using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Threading;

namespace Lab7_1
{
    class Program
    {
        public static void Main(string[] args)
        {

            Collection c1 = new Collection(135, "Withered leaves", 137, 3, "Ivan Franko");
            Collection c2 = new Collection(310, "Prince's mountain", 270, 7, "Lina Kostenko");
            Collection c3 = new Collection(298, "Uniqueness", 264, 2, "Lina Kostenko");
            Collection c4 = new Collection(169, "Antenna", 147, 3, "Sergey Zhadan");
            Collection c5 = new Collection(520, "Well", 245, 3, "Katerina Kalitko");
            Collection c6 = new Collection(241, "Letters to Ukraine", 360, 1, "Yuriy Andrukhovych");
            Collection c7 = new Collection(315, "Divine comedy", 980, 8, "Dante Alighieri");
            Collection c8 = new Collection(311, "Forest Song", 457, 12, "Lesya Ukrainka");
            Collection c9 = new Collection(378, "Romeo & Juliet", 853, 3, "William Shakespeare");
            Collection c10 = new Collection(470, "Artery", 456, 4, "Dmitry Lazutkin");
            Collection [] n = new Collection[10];
            n[0] = c1;
            n[1] = c2;
            n[2] = c3;
            n[3] = c4;
            n[4] = c5;
            n[5] = c6;
            n[6] = c7;
            n[7] = c8;
            n[8] = c9;
            n[9] = c10;
            Array.Sort(n);
            Console.WriteLine("Сортування за цiною: ");
            Console.WriteLine("{0, -25}{1, -15}{2, -20}{3, -20}{4, -10}", "Збiрка", "Цiна", "К-сть сторiнок", "К-сть роздiлiв", "Автор");
            for (int i = 0; i < n.Length; i++)
            {
                Console.WriteLine("{0, -25}{1, -15}{2, -20}{3, -20}{4, -10}", n[i].Name, n[i].Price, n[i].Pages, n[i].Sections, n[i].Author);
            }
            Console.WriteLine("Сортування за к-стю сторiнок:\n");
            Console.WriteLine("{0, -25}{1, -15}{2, -20}{3, -20}{4, -10}", "Збiрка", "Цiна", "К-сть сторiнок", "К-сть роздiлiв", "Автор");
            Array.Sort(n, new Collection.SortByPages());
            foreach (Collection elem in n) elem.Info1();

        }
    }


    public class Collection : IComparable
    {
        public string Name;
        public int Price;
        public int Pages;
        public int Sections;
        public string Author;

        public Collection(int P, string N, int Pg, int S, string A)
        {
            Name = N;
            Price = P;
            Pages = Pg;
            Sections = S;
            Author = A;
        }


        public class SortByPages : IComparer
        {

            int IComparer.Compare(object ob1, object ob2)
            {
                Collection p1 = (Collection)ob1;
                Collection p2 = (Collection)ob2;
                if (p1.Pages > p2.Pages) return 1;
                if (p1.Pages < p2.Pages) return -1;
                return 0;
            }
        }
        public int CompareTo(object obj)
        {
            Collection a = obj as Collection;
            if (a != null)
            {
                if (this.Price < a.Price)
                    return -1;
                else if (this.Price > a.Price)
                    return 1;
                else
                    return 0;
            }
            else
            {
                throw new Exception("Параметр має бути типу Collection!");
            }

        }

        public void Info1()
        {
            Console.WriteLine("{0, -25}{1, -15}{2, -20}{3, -20}{4, -10}", Name, Price, Pages, Sections, Author);
        }

        public class Collections : IEnumerable
        {
            public Collection[] an;
            public Collections(Collection[] array)
            {
                an = new Collection[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    an[i] = array[i];
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }
            public CLLC GetEnumerator()
            {
                return new CLLC(an);
            }
        }
        public class CLLC : IEnumerator
        {
            public Collection[] an;
            int pos = -1;
            public CLLC(Collection[] list)
            {
                an = list;
            }
            public void Reset()
            {
                pos = -1;
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public bool MoveNext()
            {
                pos++;
                return (pos < an.Length);
            }
            public Collection Current
            {
                get
                {
                    try
                    {
                        return an[pos];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
