using MassSpecSim;

namespace MassSpecTest
{
    [TestClass]
    public sealed class HighestPointTests
    {
        [TestMethod]
        public void EmptyListReturnsNoHighestPoint()
        {
            // arrange
            var points = new List<MeasurementPoint>();

            // act
            var highestPoint = SpectrumAnalysis.FindHighestPoint(points);
            
            // assert
            Assert.IsNull(highestPoint, "no point in list");
        }

        [TestMethod]
        public void SingleHighestPointCanBeFound()
        {
            // arrange
            var expectedHighestPoint = new MeasurementPoint(6, 5);
            var points = new List<MeasurementPoint>
            {
                new MeasurementPoint(1, 0),
                new MeasurementPoint(2, 0),
                new MeasurementPoint(3, 0),
                new MeasurementPoint(4, 0),
                new MeasurementPoint(5, 0),
                expectedHighestPoint,
                new MeasurementPoint(7, 0)
            };

            // act
            var highestPoint = SpectrumAnalysis.FindHighestPoint(points);

            // assert
            Assert.AreEqual(expectedHighestPoint, highestPoint);
        }

        [TestMethod]
        public void WhenTwoPointsHaveTheSameHeightReturnFirst()
        {
            // arrange
            var firstHighestPoint = new MeasurementPoint(6, 5);
            var secondHighestPoint = new MeasurementPoint(8, 5);
            var points = new List<MeasurementPoint>
            {
                new MeasurementPoint(1, 0),
                new MeasurementPoint(2, 0),
                new MeasurementPoint(3, 0),
                new MeasurementPoint(4, 0),
                new MeasurementPoint(5, 0),
                firstHighestPoint,
                new MeasurementPoint(7, 0),
                secondHighestPoint
            };

            // act
            var highestPoint = SpectrumAnalysis.FindHighestPoint(points);

            // assert
            Assert.AreEqual(firstHighestPoint, highestPoint);
        }
    }
}
