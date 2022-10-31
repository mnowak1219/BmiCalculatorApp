using BMI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI.Tests
{
    public class ResultServiceTests
    {
        [Fact]
        public void SetRecentOverweightResult_ForOverweightResult_UpdatesProperty()
        {
            //Arrange
            var result = new BmiResult { BmiClassification = BmiClassification.Overweight };
            var resultService = new ResultService(new ResultRepository());

            //Act
            resultService.SetRecentOverweightResult(result);

            //Assert
            resultService.RecentOverweightResult.Should().Be(result);
        }

        [Theory]
        [InlineData(BmiClassification.Underweight)]
        [InlineData(BmiClassification.Normal)]
        [InlineData(BmiClassification.Obesity)]
        [InlineData(BmiClassification.ExtremeObesity)]
        public void SetRecentOverweightResult_ForNonOverweightResult_DoesntUpdatesProperty(BmiClassification bmiClassification)
        {
            //Arrange
            var result = new BmiResult { BmiClassification = bmiClassification };
            var resultService = new ResultService(new ResultRepository());

            //Act
            resultService.SetRecentOverweightResult(result);

            //Assert
            resultService.RecentOverweightResult.Should().BeNull();
        }

        [Fact]
        public async Task SaveUnderweightResultAsync_ForUnderweightResult_InvokesSaveResultAsync()
        {
            //Arrange
            var result = new BmiResult { BmiClassification = BmiClassification.Underweight };
            var repositoryMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repositoryMock.Object);

            //Act
            await resultService.SaveUnderweightResultAsync(result);

            //Assert
            repositoryMock.Verify(mock => mock.SaveResultAsync(result), Times.Once);
        }

        [Theory]
        [InlineData(BmiClassification.Normal)]
        [InlineData(BmiClassification.Overweight)]
        [InlineData(BmiClassification.Obesity)]
        [InlineData(BmiClassification.ExtremeObesity)]
        public async Task SaveUnderweightResultAsync_ForNonUnderweightResult_DoesntInvokesSaveResultAsync(BmiClassification bmiClassification)
        {
            //Arrange
            var result = new BmiResult { BmiClassification = bmiClassification };
            var repositoryMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repositoryMock.Object);

            //Act
            await resultService.SaveUnderweightResultAsync(result);

            //Assert
            repositoryMock.Verify(mock => mock.SaveResultAsync(result), Times.Never);
        }
    }
}
