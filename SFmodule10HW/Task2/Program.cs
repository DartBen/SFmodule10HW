using System;
using static System.Console;
internal class Program
{
    static ILogger logger { get; set; }
    private static void Main(string[] args)
    {
        logger = new Logger();
        Calcutator calcutator = new Calcutator(logger);

        calcutator.a = calcutator.ArgumentConsoleRequest("Введите первое слогаемое");
        calcutator.b = calcutator.ArgumentConsoleRequest("Введите второе слогаемое");
        WriteLine($"Сумма чисел = {calcutator.Sum()}");
    }
}

interface ICalcutatorSum<in T>
{
    public double Sum(T a, T b);
    public double ArgumentConsoleRequest(string a);
    public double Sum();
}

class Calcutator : ICalcutatorSum<Double>
{
    ILogger Logger { get; }
    public double a { get; set; }
    public double b { get; set; }

    public Calcutator(ILogger logger)
    {
        Logger = logger;
    }
    public double ArgumentConsoleRequest(string a)
    {
        double result = 0;
        bool parsed = false;
        while (parsed == false)
        {
            Logger.Event("Запрос аргумента");
            try
            {
                WriteLine(a);
                parsed = Double.TryParse(ReadLine(), out result);
                if (parsed == false) throw new Exception("Вводимая строка не может быть преобразована в число!");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                WriteLine(ex.Message);
            }
        }
        Logger.Event("Аргумент был записан");
        return result;
    }
    public double Sum(double a, double b)
    {
        Logger.Event("Запрос суммы аргументов");
        return a + b;
    }
    public double Sum()
    {
        return Sum(a, b);
    }
}

interface ILogger
{
    void Event(string message);
    void Error(string message);
}

class Logger : ILogger
{
    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        WriteLine($"Logger: {message}");
        Console.ResetColor(); 
    }

    public void Event(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        WriteLine($"Logger: {message}");
        Console.ResetColor();
    }
}