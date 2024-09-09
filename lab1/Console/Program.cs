using System;
using System.Diagnostics;
internal class Program
{
    static void Main(string[] args)
    {
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 2000; i++)
        {
            Console.WriteLine(i);
        }
        sw.Stop();
        Console.WriteLine($"Vremya: {sw.ElapsedMilliseconds}"); 
    }
}
