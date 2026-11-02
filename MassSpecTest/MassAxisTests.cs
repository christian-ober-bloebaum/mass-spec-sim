using MassSpecSim;

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
        

    }    
}
