using ScottPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Media.Converters;
using static MassSpecSim.MainWindow;

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
            
            for(int i = 0; i < massValues.Length; i++)
            {
                var x = massValues[i];
                var y = 0d;
                // gehe über alle peaks, summiere intensitäten in y
                foreach(var peak in settings.Peaks)
                {
                    y += PeakMath.Gaussian(x, peak.Position, peak.Height, peak.Width);
                }
                double noise = CreateNoise(settings.NoiseAmplitude);
                points.Add(new MeasurementPoint(x, y + noise));
            }

            // TODO 3: Ergänze später das Rauschen über CreateNoise.
            return points;
        }

        public double CreateNoise(double amplitude)
        {

            if (amplitude <= 0)
            {
                return 0;

            }
            return random.NextDouble() * amplitude ;
            // TODO 3: Nutze random.NextDouble() für einen Wert zwischen 0 und amplitude.
            // Bei amplitude = 0 muss das Ergebnis immer 0 sein.
            // Es genügt für diese Übung, nichtnegatives, gleichverteiltes Rauschen zu erzeugen.


        }
    }
}
