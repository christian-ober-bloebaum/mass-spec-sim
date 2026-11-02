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
            var maxMass = sim.CreateMassAxis(settings);

            // assert
            Assert.AreEqual(settings.MaximumMass, maxMass[4], "Maximaler Massenwert ist falsch");
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
        public void SettingsHaveCorrectPeakPosition()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act

            // assert
            Assert.AreEqual(settings.PeakPosition, settings.Peaks[0].Position, "PeakPosition ist falsch");
        }

        [TestMethod]
        public void SettingsHaveCorrectPeakHeight()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act

            // assert
            Assert.AreEqual(settings.PeakHeight, settings.Peaks[0].Height, "PeakHeight ist falsch");
        }

        [TestMethod]
        public void SettingsHaveCorrectPeakWidth()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act

            // assert
            Assert.AreEqual(settings.PeakWidth, settings.Peaks[0].Width, "PeakWidth ist falsch");
        }

        [TestMethod]
        public void SettingsHaveCorrectNoiseAmplitude()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act

            // assert
            Assert.AreEqual(settings.NoiseAmplitude, settings.NoiseAmplitude, "NoiseAmplitude ist falsch");
        }

        [TestMethod]
        public void SettingsHaveCorrectPeaksList()
        {
            // arrange
            SpectrumSimulator sim = new SpectrumSimulator();
            SimulationSettings settings = new SimulationSettings();

            // act

            // assert
            Assert.HasCount(settings.Peaks.Count, settings.Peaks, "Anzahl der vordefinierten Peaks ist falsch");
        }
    }
}