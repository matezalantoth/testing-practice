namespace CalculatorLogger;

public class Calculator
{
    private readonly ILogger _logger;

    public Calculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        if (a == 1)
        {
            throw new ArgumentException();
        }
        _logger.Log($"Adding {a} and {b}");
        return a + b;
    }

    public int Multiply(int a, int b)
    {
        _logger.Log($"Multiplying {a} by {b}");
        return a * b;
    }
}