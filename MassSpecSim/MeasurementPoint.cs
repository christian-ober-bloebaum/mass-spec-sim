using System.Diagnostics.CodeAnalysis;

namespace MassSpecSim
{
    // Ein Datenpunkt ist ein Wertepaar: Position auf der m/z-Achse und Intensität.
    public class MeasurementPoint
    {
        public double MassToCharge { get; set; }
        public double Intensity { get; set; }

        public MeasurementPoint(double massToCharge, double intensity)
        {
            MassToCharge = massToCharge;
            Intensity = intensity;
        }

        public override string ToString()
        {

            return "("+MassToCharge+"m/z; "+Intensity+ "cps)";
        }
    }
}
