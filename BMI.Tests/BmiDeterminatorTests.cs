namespace BMI.Tests
{
    public class BmiDeterminatorTests
    {
        [Fact]
        public void BmiDeterminate_BmiFrom0To18_5_ReturnsUnderwaightClassification()
        {
            //Arrange
            var bmiDeterminator = new BmiDeterminator();
            double bmi = 15;

            //Act
            BmiClassification result = bmiDeterminator.DetermineBmi(bmi);

            //Assert
            Assert.Equal(BmiClassification.Underweight, result);
        }

        [Theory]
        [InlineData(19)]
        [InlineData(24)]
        public void BmiDeterminate_BmiFrom18_5To24_9_ReturnsNormalClassification(double bmi)
        {
            //Arrange
            var bmiDeterminator = new BmiDeterminator();

            //Act
            BmiClassification result = bmiDeterminator.DetermineBmi(bmi);

            //Assert
            Assert.Equal(BmiClassification.Normal, result);

        }

        [Theory]
        [InlineData(25, BmiClassification.Overweight)]
        [InlineData(29, BmiClassification.Overweight)]
        [InlineData(30, BmiClassification.Obesity)]
        [InlineData(34, BmiClassification.Obesity)]
        [InlineData(35, BmiClassification.ExtremeObesity)]
        [InlineData(39, BmiClassification.ExtremeObesity)]
        public void BmiDeterminate_BmiFrom24_9ToInfinity_ReturnsClassification(double bmi, BmiClassification bmiClassification)
        {
            //Arrange
            var bmiDeterminator = new BmiDeterminator();

            //Act
            BmiClassification result = bmiDeterminator.DetermineBmi(bmi);

            //Assert
            Assert.Equal(bmiClassification, result);
        }
    }
}
