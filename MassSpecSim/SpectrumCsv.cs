using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

namespace MassSpecSim
{
    public static class SpectrumCsv
    {
        public static void Save(string filePath, List<MeasurementPoint> points)
        {
            var csv = new StringBuilder();
            csv.AppendLine("mz"+ delimiter +"intensity");
            foreach (var point in points)
            {
                string line = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", point.MassToCharge,delimiter, point.Intensity);
                csv.AppendLine(line);
                
            }
            File.WriteAllText(filePath, csv.ToString());
            // TODO 5: Schreibe die Kopfzeile mz,intensity und danach einen Datenpunkt pro Zeile.
            // Das Dateiformat verwendet Kommas als Trennzeichen und Punkte als Dezimalzeichen.
            // Nutze CultureInfo.InvariantCulture, damit es auf anderen Rechnern gleich aussieht.
            // filePath wurde bereits über einen Speicherdialog ausgewählt.
        }
        private static string delimiter = ",";
    }
}
