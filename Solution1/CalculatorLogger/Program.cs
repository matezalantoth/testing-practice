// See https://aka.ms/new-console-template for more information

namespace CalculatorLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calculator = new Calculator(new Logger());
            new Logger().Log($"result: {calculator.Add(1, 2)}");
        }
    }
}