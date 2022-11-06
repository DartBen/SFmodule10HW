using System;
using static System.Console;
internal class Program
{
    private static void Main(string[] args)
    {
        Calcutator calcutator = new Calcutator();
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
    public double a { get; set; }
    public double b { get; set; }
    public double ArgumentConsoleRequest(string a)
    {
        double result = 0;
        bool parsed = false;
        while (parsed == false)
        {
            try
            {
                WriteLine(a);
                parsed = Double.TryParse(ReadLine(), out result);
                if (parsed == false) throw new Exception("Вводимая строка не может быть преобразована в число!");
                return result;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        return result;
    }
    public double Sum(double a, double b)
    {
        return a + b;
    }
    public double Sum()
    {
        return a + b;
    }
}

