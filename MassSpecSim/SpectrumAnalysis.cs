using System.Collections.Generic;
using System.Linq;

namespace MassSpecSim
{
    public static class SpectrumAnalysis
    {
        public static MeasurementPoint? FindHighestPoint(List<MeasurementPoint> points)
        {
            // TODO 4: Suche mit einer Schleife den Datenpunkt mit der höchsten Intensität.
            // Bei einer leeren Liste: null. Bei Gleichstand: den ersten höchsten Punkt zurückgeben.
            // Gesucht ist der höchste ABGETASTETE Datenpunkt, nicht zwingend das exakte Peakzentrum.
            MeasurementPoint? highest = null;
            foreach (MeasurementPoint currentPoint in points) 
            {
                if (highest == null || currentPoint.Intensity > highest.Intensity)
                {
                    // neuer höchster punkt
                    highest = currentPoint;
                }
            }

            return highest;
        }
    }
}
