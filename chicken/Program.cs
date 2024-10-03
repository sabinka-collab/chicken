using System;
using System.Threading;

class Program
{
    private static readonly object _lock = new object();
    private static string _lastWord = string.Empty;

    static void Main(string[] args)
    {
        Thread chickenThread = new Thread(SayChicken);
        Thread eggThread = new Thread(SayEgg);

        chickenThread.Start();
        eggThread.Start();

        chickenThread.Join();
        eggThread.Join();

        Console.WriteLine($"В споре победила: {_lastWord}");
    }

    static void SayChicken()
    {
        for (int i = 0; i < 5; i++)
        {
            lock (_lock)
            {
                _lastWord = "Курица";
                Console.WriteLine(_lastWord);
                Thread.Sleep(100); // Задержка для большей видимости смены слов
            }
        }
    }

    static void SayEgg()
    {
        for (int i = 0; i < 5; i++)
        {
            lock (_lock)
            {
                _lastWord = "Яйцо";
                Console.WriteLine(_lastWord);
                Thread.Sleep(100); // Задержка для большей видимости смены слов
            }
        }
    }
}