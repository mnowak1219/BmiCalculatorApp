namespace BMI.Tests
{
    public class ImperialBmiCalculatorTests
    {        
        [Theory]
        [JsonFileData("Data/ImperialBmiCalculatorCorrectData.json")]
        public void CalculateBmi_ForGivenWeightAndHeight_ReturnsCorrectBmi(double weight, double height, double bmiResult)
        {
            //Arrange
            var imperialBmiCalculator = new ImperialBmiCalculator();

            //Act
            double result = imperialBmiCalculator.CalculateBmi(weight, height);

            //Assert
            Assert.Equal(bmiResult, result);
        }

        [Theory]
        [JsonFileData("Data/ImperialBmiCalculatorWrongData.json")]
        public void CalculateBmi_ForInvalidArguments_ThrowsArgumentException(double weight, double height)
        {
            //Arrange
            var imperialBmiCalculator = new ImperialBmiCalculator();

            //Act
            Action action = () => imperialBmiCalculator.CalculateBmi(weight, height);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
