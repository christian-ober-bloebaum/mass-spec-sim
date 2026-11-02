using MassSpecSim;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MassSpecTest
{
    [TestClass]
    public sealed class MassAxisTests
    {
        [TestMethod]
        public void MassAxisHasCorrectPointCount()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act
            var massAxis = sim.CreateMassAxis(settings);

            // assert
            Assert.HasCount(settings.PointCount, massAxis, "Punktanzahl Falsch");
        }

        [TestMethod]
        public void MassAxisHasCorrectMaximum()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act
            var massAxis = sim.CreateMassAxis(settings);

            // assert
            Assert.AreEqual(settings.MaximumMass, massAxis[massAxis.Length - 1], "Maximaler Massenwert ist falsch");
        }

        [TestMethod]
        public void MassAxisHasCorrectMinimum()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act
            var minMass = sim.CreateMassAxis(settings);

            // assert
            Assert.AreEqual(settings.MinimumMass, minMass[0], "Minimaler Massenwert ist falsch");
        }

        [TestMethod]
        public void EqualPointSpread()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act
            var massAxis = sim.CreateMassAxis(settings);

            //assert
            double correctDistance = 0;
            for (int i = 0; i < massAxis.Length - 1; i++)
            {
                var currentDistance = massAxis[i + 1] - massAxis[i];
                if(correctDistance != 0)
                {
                    Assert.AreEqual(correctDistance, currentDistance, "Point distance not correct");
                }
                else
                {
                    correctDistance = currentDistance;
                }
            }
        }
    }
}