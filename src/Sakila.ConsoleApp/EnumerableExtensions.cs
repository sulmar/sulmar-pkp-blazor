using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.ConsoleApp;

internal static class EnumerableExtensions
{
    // Metoda rozszerzajaca typ IEnumerable<T>

    public static void Dump<T>(this IEnumerable<T> items, string title = "")
    {
        if (!string.IsNullOrEmpty(title))
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(title);
            Console.WriteLine("--------------------");
        }

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Count: {items.Count()}");
    }
}
