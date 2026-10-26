using System;

namespace MassSpecSim
{
    // Vorbereitete Mathematik: Ein Peak wird hier als einfache Gaußkurve angenähert.
    public static class PeakMath
    {
        public static double Gaussian(double massToCharge, double position, double height, double width)
        {
            if (!double.IsFinite(width) || width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Die Peakbreite muss positiv und endlich sein.");
            }

            // Direkt am Zentrum ist distance = 0 und das Ergebnis entspricht height.
            // width entspricht Sigma, nicht der vollen Breite bei halber Höhe.
            double distance = (massToCharge - position) / width;
            double intensity = height * Math.Exp(-0.5 * distance * distance);
            return intensity;
        }
    }
}
