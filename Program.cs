using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader sr = new StreamReader("C:\\Users\\Alena\\source\\repos\\рядИместо\\рядИместо\\26__t72u.txt"))
        {
            int n = int.Parse(sr.ReadLine());
            List < Tuple < int, int>> coordinates = new List<Tuple<int, int>>();

            // Считываем координаты занятых мест
            for (int i = 0; i < n; i++)
            {
                string[] inputs = sr.ReadLine().Split();
                int x = int.Parse(inputs[0]);
                int y = int.Parse(inputs[1]);
                coordinates.Add(new Tuple<int, int>(x, y));
            }

            // Сортируем координаты
            coordinates.Sort((a, b) => a.Item1 != b.Item1 ? a.Item1.CompareTo(b.Item1) : a.Item2.CompareTo(b.Item2));

            int[] ans = { 0, 0 };

            // Проходим по всем координатам занятых мест
            for (int i = 0; i < n - 1; i++)
            {
                // Проверяем, совпадает ли ряд и есть ли 2 свободных места между ними
                if (coordinates[i].Item1 == coordinates[i + 1].Item1 && coordinates[i].Item2 + 3 == coordinates[i + 1].Item2)
                {
                    int row = coordinates[i].Item1; // вычисляем ряд
                    int seat = coordinates[i].Item2 + 1; // минимальное свободное место между двумя креслами
                    if (row > ans[0])
                    {
                        ans[0] = row;
                        ans[1] = seat;
                    }
                }
            }

            // Выводим результат
            Console.WriteLine($"{ans[0]} {ans[1]}");
        }
    }
}
