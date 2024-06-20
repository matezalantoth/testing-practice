using CalculatorLogger;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace CalculatorTesting;

public class Tests
{

    private static readonly object[] AddTestCases =
    {
        new object[] { 2, 2, 4, "Adding 2 and 2" },
        new object[] { 4, 5, 9, "Adding 4 and 5" }
    };

    private static readonly object[] AddThrowsExceptionTestCases =
    {
        new object[] { 1, 2  }
    };

    private static readonly object[] AddDoesNotThrowsExceptionTestCases =
    {
        new object[] { 2, 2  }
    };


    private static readonly object[] MultiplyTestCases =
    {
        new object[] { 1, 2, 2, "Multiplying 1 by 2" },
        new object[] { 4, 5, 20, "Multiplying 4 by 5" }
    };


    [TestCaseSource(nameof(AddTestCases))]
    public void AddReturnsCorrectSumAndLoggerRegistersIt(int num1, int num2, int expectedResult, string expectedMessage)
    {
        //Arrange
        var logger = Substitute.For<ILogger>();
        var calculator = new Calculator(logger);
        //Act
        int result = calculator.Add(num1, num2);
        //Assert
        Assert.That(result, Is.EqualTo(expectedResult));
        logger.Received().Log(expectedMessage);

    }

    [TestCaseSource(nameof(AddThrowsExceptionTestCases))]
    public void AddThrowsErrorWithOne(int num1, int num2)
    {
        var logger = Substitute.For<ILogger>();
        var calculator = new Calculator(logger);
        Assert.Throws<ArgumentException>(() => calculator.Add(num1, num2));
    }

    [TestCaseSource(nameof(AddDoesNotThrowsExceptionTestCases))]
    public void AddDoesNotThrowErrorWithTwo(int num1, int num2)
    {
        //Arrange
        var logger = Substitute.For<ILogger>();
        var calculator = new Calculator(logger);
        //Assert and Act
        Assert.DoesNotThrow(() => calculator.Add(num1, num2));
    }

    [TestCaseSource(nameof(MultiplyTestCases))]
    public void MultiplyReturnsCorrectProduct(int num1, int num2, int expectedResult, string expectedMessage)
    {
        //Arrange
        var logger = Substitute.For<ILogger>();
        var calculator = new Calculator(logger);
        //Act
        int result = calculator.Multiply(num1, num2);
        //Assert
        Assert.That(result, Is.EqualTo(expectedResult));
        logger.Received().Log(expectedMessage);
    }
}