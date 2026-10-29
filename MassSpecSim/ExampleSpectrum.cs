using System.Collections.Generic;

namespace MassSpecSim
{
    // Feste Übungsdaten, keine Messung und keine fertige Simulation.
    public static class ExampleSpectrum
    {
        public static List<MeasurementPoint> Create()
        {
            List<MeasurementPoint> points = new List<MeasurementPoint>();

            points.Add(new MeasurementPoint(100, 0));
            points.Add(new MeasurementPoint(150, 0));
            points.Add(new MeasurementPoint(185, 0));
            points.Add(new MeasurementPoint(190, 100));
            points.Add(new MeasurementPoint(195, 500));
            points.Add(new MeasurementPoint(200, 1000));
            points.Add(new MeasurementPoint(205, 500));
            points.Add(new MeasurementPoint(210, 100));
            points.Add(new MeasurementPoint(215, 0));
            points.Add(new MeasurementPoint(300, 0));
            points.Add(new MeasurementPoint(385, 1200));
            points.Add(new MeasurementPoint(395, 300));
            points.Add(new MeasurementPoint(400, 0));
            points.Add(new MeasurementPoint(405, 00));
            points.Add(new MeasurementPoint(415, 0));
            points.Add(new MeasurementPoint(500, 0));
            points.Add(new MeasurementPoint(600, 0));

            return points;
        }
    }
}
