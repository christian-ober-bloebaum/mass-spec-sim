using System.Collections.Generic;
using ScottPlot.WPF;

namespace MassSpecSim
{
    // Vorbereitete Verbindung zur Diagrammbibliothek. Kein Teil der Simulation.
    public class SpectrumChart
    {
        private readonly WpfPlot plot;

        public SpectrumChart(WpfPlot plotControl)
        {
            plot = plotControl;
        }

        public void Show(List<MeasurementPoint> points, string title)
        {
            double[] masses = new double[points.Count];
            double[] intensities = new double[points.Count];

            for (int index = 0; index < points.Count; index++)
            {
                masses[index] = points[index].MassToCharge;
                intensities[index] = points[index].Intensity;
            }

            // Die wichtigsten ScottPlot-Aufrufe: leeren, Daten hinzufügen, beschriften, neu zeichnen.
            plot.Plot.Clear();
            ScottPlot.Plottables.Scatter line = plot.Plot.Add.Scatter(masses, intensities);
            line.MarkerSize = 5;
            line.LineWidth = 2;
            plot.Plot.Title(title);
            plot.Plot.XLabel("m/z");
            plot.Plot.YLabel("Intensität (a.u.)");
            plot.Plot.Axes.AutoScale();
            plot.Refresh();
        }
    }
}
