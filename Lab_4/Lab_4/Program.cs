using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        class Set
        {
            private int size = 5;
            private int[] set_elements = new int[50];

            // индексатор для set
            public int this[int index]
            {
                get
                {
                    return set_elements[index];
                }
                set
                {
                    set_elements[index] = value;
                }
            }
            //заполняем множества 
            public static void fill_set(Set set)
            {
                Random rnd = new Random();
                int value;

                for (int i = 0; i < set.size; i++)
                {
                    value = rnd.Next(0, 50);
                    set[i] = value;
                }
            }
            //выводим множества на консоль 
            public static void output_set(Set set, int set_num)
            {
                Console.Write($"\n\nМножетсво №{set_num}:");
                for (int i = 0; i < set.size; i++)
                {
                    Console.Write($"  {set[i]}  ");
                }
            }

            // добавление случайного числа к множеству
            public static Set operator ++(Set set)
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 50);

                int i = set.size;
                set.size = set.size + 1;         //ув. разм. и знаносимм 6 элементом новое число 
                set[i] = value;
     
                return set;
            }

            // объединение множеств
            public static Set operator +(Set set1, Set set2)
            {
                Set set_union = new Set();
                int union_i = 0;

                for (int i = 0; i < set1.size; i++)
                {
                    set_union[union_i] = set1[i];
                    union_i++;
                }
                for (int i = 0; i < set2.size; i++)
                {
                    set_union[union_i] = set2[i];
                    union_i++;
                }

                set_union.size = union_i;
                return set_union;
            }

            // сравнение множеств
            public static bool operator <=(Set set1, Set set2)
            {
                if (set1.size != set2.size)
                {
                    return false;
                }
                else if (set1.size == set2.size)
                {
                    int result = 0;
                    int check;
                    for (int i = 0; i < set1.size; i++)
                    {
                        check = 0;
                        for (int j = 0; j < set2.size; j++)
                        {
                            if (set1[i] == set2[j])
                            {
                                check++;
                            }
                        }
                        if (check >= 1)
                        {
                            result++;
                        }
                    }
                    if (result == set1.size)
                    {
                        return true;
                    }
                }
                return false;
            }
            public static bool operator >=(Set set1, Set set2)
            {
                return false;
            }
            public static void fill_compare(Set set1, Set set2)
            {
                set1[0] = 10;
                set1[1] = 30;
                set1[2] = 40;
                set1[3] = 228;

                set2[0] = 30;
                set2[1] = 40;
                set2[2] = 228;
                set2[3] = 10;

                set1.size = 4;
                set2.size = 4;
            }

            // мощность множества
            public static int set_power(Set set)
            {
                int power = set.size;
                return power;
            }

            // доступ к элементу в заданной позиции
            public static int accessByIndex(Set set, int num_set)
            {
                output_set(set, num_set);

                Console.WriteLine("\nВведите номер элемента: ");
                int index_element = Convert.ToInt32(Console.ReadLine());
                if (index_element <= 0 || index_element > set.size)
                {
                    return 0;
                }

                Console.WriteLine($"Элемент под номером {index_element} = {set[index_element - 1]}");
                return 0;
            }

            // вложенный класс Owner
            public class Owner
            {
                public static readonly int id = 321;
                public static readonly string name = "Кононович Влад";
                public static readonly string organization_name = "Via";
            }

            // вложенный класс Date
            public class Date
            {
                public static readonly string date = "20.11.2020";
            }

            // сумма; разница между max и min; кол-во элементов
            public static class StatisticOperation    //4
            {
                public static int sum(Set set)
                {
                    int sum = 0;
                    for (int i = 0; i < set.size; i++)
                    {
                        sum += set[i];
                    }
                    return sum;
                }
                public static int difference_max_min(Set set)
                {
                    int max = -1000;
                    int min = 1000;

                    for (int i = 0; i < set.size; i++)
                    {
                        if (set[i] < min)
                        {
                            min = set[i];
                        }
                        if (set[i] > max)
                        {
                            max = set[i];
                        }
                    }
                    return max - min;
                }
                public static int numElements(Set set)
                {
                    return set.size;
                }
            }
        }
        static void Main(string[] args)
        {
            Set set1 = new Set();  //cоздаем множества

            Set.fill_set(set1);
            Set.output_set(set1, 1);

            set1++;
            Set.output_set(set1, 1);

            Set set2 = new Set();

            Set.fill_set(set2);
            Set.output_set(set2, 2);

            Set set3 = set1 + set2;

            Set.output_set(set3, 3);

            Set set4 = new Set();
            Set set5 = new Set();
            Set.fill_compare(set4, set5);
            if (set4 <= set5 == true)
            {
                Console.WriteLine("\n\nМножества set4 и set5 равны");
            }
            else
            {
                Console.WriteLine("\n\nМножества set4 и set5 не равны");
            }

            Console.WriteLine($"\nМощность множества №1 = {Set.set_power(set1)}");

            Console.WriteLine("\nВыберите множество( всего их 5): ");
            int num_set = Convert.ToInt32(Console.ReadLine());
            if (num_set == 1)
            {
                Set.accessByIndex(set1, num_set);
            }
            else if (num_set == 2)
            {
                Set.accessByIndex(set2, num_set);
            }
            else if (num_set == 3)
            {
                Set.accessByIndex(set3, num_set);
            }
            else if (num_set == 4)
            {
                Set.accessByIndex(set4, num_set);
            }
            else if (num_set == 5)
            {
                Set.accessByIndex(set5, num_set);
            }
            else
            {
                Console.WriteLine("\nВы ввели номер множества которого нет!");
            }



            Console.WriteLine($"\nID: { Set.Owner.id }");
            Console.WriteLine($"Имя: { Set.Owner.name }");
            Console.WriteLine($"Название организации: { Set.Owner.organization_name }");
            Console.WriteLine($"Дата создания: { Set.Date.date }");

        }
    }
}