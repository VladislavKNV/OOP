using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Set
    {
        static void Main()
        {
            // Создадём два множества
            SortedSet<char> ss = new SortedSet<char>();
            SortedSet<char> ss1 = new SortedSet<char>();
            SortedSet<char> ss2 = new SortedSet<char>();


            ss.Add('A');
            ss.Add('B');
            ss.Add('C');
            ss.Add('Z');
            ShowColl(ss, "Первая коллекция: ");

            ss1.Add('X');
            ss1.Add('Y');
            ss1.Add('Z');
            ShowColl(ss1, "Вторая коллекция");

            ss2.Add('A');
            ss2.Add('B');
            ss2.Add('B');
            ss2.Add('C');
            ShowColl(ss, "Первая коллекция: ");

            IEnumerable<char> query = from planet in ss2.Distinct()
                                        select planet;


            ss.UnionWith(ss1);
            ShowColl(ss, "Объединение множеств: ");

            ss.ExceptWith(ss1);
            ShowColl(ss, "Вычитание множеств");

            Console.ReadLine();
        }

        static void ShowColl(SortedSet<char> ss, string s)
        {
            Console.WriteLine(s);
            foreach (char ch in ss)
                Console.Write(ch + " ");
            Console.WriteLine("\n");
        }
    }
}