# testing-practice

**1. Create tests for calculator**
- 1. use NSubstitute to mock logger
- 2. dependency inject mockedLogger;
- 3. Assert.That
- 4. ensure the logger received the data (.Received.Log(message))
<details>
  <summary>Solution (don't look unless really stuck)</summary>

  ```c#
public class CalculatorTests
{
    [Test]
    public void Add_ReturnsCorrectSum()
    {
   
        var logger = Substitute.For<ILogger>();
        var calculator = new Calculator(logger);
        int a = 5;
        int b = 10;
        int result = calculator.Add(a, b);
        Assert.That(result, Is.EqualTo(15));
        logger.Received().Log($"Adding {a} and {b}");
    }

    [Test]
    public void Multiply_ReturnsCorrectProduct()
    {
        var logger = Substitute.For<ILogger>();
        var calculator = new Calculator(logger);
        int a = 3;
        int b = 7;
        int result = calculator.Multiply(a, b);
        Assert.That(result, Is.EqualTo(21));
        logger.Received().Log($"Multiplying {a} by {b}");  
    }
}

  ```

</details>

**Ex: Create error handling and use Assert Throws to test**