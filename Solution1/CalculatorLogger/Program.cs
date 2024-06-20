// See https://aka.ms/new-console-template for more information

namespace CalculatorLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILogger logger = new Logger();
            Calculator calculator = new Calculator(logger);
            logger.Log($"result: {calculator.Add(1, 2)}");
        }
    }
}