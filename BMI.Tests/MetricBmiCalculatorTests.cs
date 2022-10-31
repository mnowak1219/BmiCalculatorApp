namespace BMI.Tests
{
    public class MetricBmiCalculatorTests
    {
        [Theory]
        [JsonFileData("Data/MetricBmiCalculatorCorrectData.json")]
        public void CalculateBmi_ForGivenWeightAndHeight_ReturnsCorrectBmi(double weight, double height, double bmiResult)
        {
            //Arrange
            var metricBmiCalculator = new MetricBmiCalculator();

            //Act
            double result = metricBmiCalculator.CalculateBmi(weight, height);

            //Assert
            Assert.Equal(bmiResult, result);
        }

        [Theory]
        [JsonFileData("Data/MetricBmiCalculatorWrongData.json")]
        public void CalculateBmi_ForInvalidArguments_ThrowsArgumentException(double weight, double height)
        {
            //Arrange
            var metricBmiCalculator = new MetricBmiCalculator();

            //Act
            Action action = () => metricBmiCalculator.CalculateBmi(weight, height);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
