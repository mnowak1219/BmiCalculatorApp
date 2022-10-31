using System.Diagnostics;
using Xunit.Abstractions;

namespace BMI.Tests
{
    public class BmiCalculatorFacadeTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public BmiCalculatorFacadeTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [ClassData(typeof(BmiCalculatorFacadeTestsData))]
        public void GetResult_ForValidInputs_ReturnsCorrectSummary(UnitSystem unitSystem, BmiClassification bmiClassification, string expectedResult)
        {
            //Arrange
            var bmiDeterminatorMock = new Mock<IBmiDeterminator>();
            bmiDeterminatorMock.Setup(m => m.DetermineBmi(It.IsAny<double>()))
                .Returns(bmiClassification);
            var bmiCalculatorFacade = new BmiCalculatorFacade(unitSystem, bmiDeterminatorMock.Object);

            //Act
            var result = bmiCalculatorFacade.GetResult(1, 1);
            _testOutputHelper.WriteLine($"For the classification: \"{bmiClassification}\", the result is: \"{result.Summary}\"");

            //Assert
            result.Summary.Should().Be(expectedResult);

        }
    }
}
