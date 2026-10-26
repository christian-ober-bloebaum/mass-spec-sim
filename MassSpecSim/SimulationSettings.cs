namespace MassSpecSim
{
    // Diese Werte werden von der Oberfläche eingelesen und an den Simulator übergeben.
    public class SimulationSettings
    {
        public double MinimumMass { get; set; } = 100;
        public double MaximumMass { get; set; } = 600;
        public int PointCount { get; set; } = 1001;
        public double PeakPosition { get; set; } = 300;
        public double PeakHeight { get; set; } = 1000;
        public double PeakWidth { get; set; } = 5;
        public double NoiseAmplitude { get; set; } = 0;
    }
}
