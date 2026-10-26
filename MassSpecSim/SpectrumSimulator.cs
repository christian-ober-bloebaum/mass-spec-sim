using System;
using System.Collections.Generic;
using System.Windows;

namespace MassSpecSim
{
    // Hier entstehen die Messdaten. Diese Klasse kennt keine Fenster und Diagramme.
    public class SpectrumSimulator
    {
        // Für Aufgabe 3: Dieses Objekt kann bei jedem Aufruf einen neuen Zufallswert liefern.
        private readonly Random random = new Random();

        public double[] CreateMassAxis(SimulationSettings settings)
        {
            // 1: Erzeuge PointCount gleichmäßig verteilte m/z-Werte.
            // Der erste Wert ist MinimumMass, der letzte MaximumMass.

            double [] result = new double[settings.PointCount];
            double delta = (settings.MaximumMass - settings.MinimumMass) / (settings.PointCount - 1);
            for(int i = 0; i < result.Length; i++)
            {
                if (i == 0) 
                { 
                    result[i] = settings.MinimumMass;
                    continue;
                }
                result[i] = result[i-1] + delta;
            }
            return result;
        }

        public List<MeasurementPoint> Generate(SimulationSettings settings)
        {
            double[] massValues = CreateMassAxis(settings);
            List<MeasurementPoint> points = new List<MeasurementPoint>();

            // TODO 2: Durchlaufe massValues, berechne jeweils die Intensität mit PeakMath.Gaussian
            // und füge einen MeasurementPoint hinzu. Liste und Achse müssen gleich viele Werte haben.
            // TODO 3: Ergänze später das Rauschen über CreateNoise.

            return points;
        }

        public double CreateNoise(double amplitude)
        {
            // TODO 3: Nutze random.NextDouble() für einen Wert zwischen 0 und amplitude.
            // Bei amplitude = 0 muss das Ergebnis immer 0 sein.
            // Es genügt für diese Übung, nichtnegatives, gleichverteiltes Rauschen zu erzeugen.
            throw new NotImplementedException("Aufgabe 3: Ergänze CreateNoise in SpectrumSimulator.cs.");
        }
    }
}
