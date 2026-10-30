using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace MassSpecSim
{
    // Vorbereitetes UI: Eingaben einlesen, Lernmethoden aufrufen und Ergebnisse anzeigen.
    public partial class MainWindow : Window
    {
        private readonly SpectrumSimulator simulator = new SpectrumSimulator();
        private readonly SpectrumChart chart;
        private List<MeasurementPoint> currentSpectrum = new List<MeasurementPoint>();

        public MainWindow()
        {
            InitializeComponent();
            chart = new SpectrumChart(SpectrumPlot);
            ShowExample();
        }

        private void ShowExample()
        {
            ShowSpectrum(ExampleSpectrum.Create(), "Feste Beispieldaten – keine Simulation");
            StatusText.Text = "Beispieldaten geladen. Beginne mit Aufgabe 0 in docs/Aufgaben.md.";
        }

        private void ShowSpectrum(List<MeasurementPoint> points, string source)
        {
            currentSpectrum = points;
            chart.Show(points, source);
            PointsTable.ItemsSource = currentSpectrum;
            SourceText.Text = source;
            PointCountText.Text = points.Count + " Datenpunkte · Linien verbinden die abgetasteten Werte";
            AnalysisText.Text = "Höchster Datenpunkt: noch nicht ausgewertet (Aufgabe 4).";
        }


        private void ExampleButton_Click(object sender, RoutedEventArgs e)
        {
            ShowExample();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            SimulationSettings? settings = ReadSettings(); 
            if (settings == null)
            {
                return;
            }

            try
            {
                List<MeasurementPoint> points = simulator.Generate(settings);
                if (points.Count == 0)
                {
                    StatusText.Text = "Noch keine Datenpunkte: Ergänze Aufgabe 2 in Generate. Die bisherige Anzeige bleibt erhalten.";
                    return;
                }

                ShowSpectrum(points, "Simuliertes Spektrum");
                StatusText.Text = "Spektrum erzeugt. Prüfe die Werte auch im Reiter Messwerte.";
            }
            catch (NotImplementedException exception)
            {
                // Ein offenes TODO ist am Anfang erwartbar und wird als Hinweis angezeigt.
                StatusText.Text = exception.Message;
            }
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MeasurementPoint? highest = SpectrumAnalysis.FindHighestPoint(currentSpectrum);
                if (highest == null)
                {
                    AnalysisText.Text = "Keine Datenpunkte für eine Auswertung vorhanden.";
                    return;
                }

                AnalysisText.Text = "Höchster Datenpunkt: m/z " + highest.MassToCharge.ToString("F3")
                    + " · Intensität " + highest.Intensity.ToString("F2") + " a.u.";
                StatusText.Text = "Auswertung abgeschlossen.";
            }
            catch (NotImplementedException exception)
            {
                StatusText.Text = exception.Message;
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Spektrum als CSV speichern";
            dialog.Filter = "CSV-Datei (*.csv)|*.csv";
            dialog.FileName = "spektrum.csv";
            dialog.DefaultExt = ".csv";

            if (dialog.ShowDialog(this) != true)
            {
                return;
            }

            try
            {
                SpectrumCsv.Save(dialog.FileName, currentSpectrum);
                StatusText.Text = "Gespeichert: " + dialog.FileName;
            }
            catch (NotImplementedException exception)
            {
                StatusText.Text = exception.Message;
            }
            catch (IOException exception)
            {
                StatusText.Text = "Datei konnte nicht gespeichert werden: " + exception.Message;
            }
            catch (UnauthorizedAccessException)
            {
                StatusText.Text = "Für diesen Speicherort fehlt die Schreibberechtigung.";
            }
        }

        private SimulationSettings? ReadSettings()
        {
            // Die Eingabeverarbeitung ist vorbereitet, damit der Einstieg bei den Algorithmen liegt.
            SimulationSettings settings = new SimulationSettings();

            if (!TryReadNumber(MinimumMassBox, out double minimum)
                || !TryReadNumber(MaximumMassBox, out double maximum)
                || !int.TryParse(PointCountBox.Text, out int count)
                || !TryReadNumber(PeakPositionBox, out double position)
                || !TryReadNumber(PeakHeightBox, out double height)
                || !TryReadNumber(PeakWidthBox, out double width)
                || !TryReadNumber(NoiseAmplitudeBox, out double noise)

                )
            {
                StatusText.Text = "Bitte gültige, endliche Zahlen eingeben. Die Anzahl muss eine ganze Zahl sein.";
                return null;
            }

            if (minimum < 0 || maximum <= minimum || maximum > 1000000)
            {
                StatusText.Text = "Der m/z-Bereich muss aufsteigend zwischen 0 und 1000000 liegen.";
                return null;
            }

            if (count < 2 || count > 20000)
            {
                StatusText.Text = "Wähle zwischen 2 und 20000 Datenpunkten.";
                return null;
            }

            if (position < minimum || position > maximum || width <= 0 || height < 0 || noise < 0)
            {
                StatusText.Text = "Peakposition im Messbereich, Peakbreite größer 0, Höhe und Rauschen mindestens 0 wählen.";
                return null;
            }

            settings.MinimumMass = minimum;
            settings.MaximumMass = maximum;
            settings.PointCount = count;
            settings.PeakPosition = position;
            settings.PeakHeight = height;
            settings.PeakWidth = width;
            settings.NoiseAmplitude = noise;
 
            return settings;
        }

        private bool TryReadNumber(TextBox textBox, out double value)
        {
            // Ohne Tausendertrennzeichen: Sowohl 1,5 als auch 1.5 werden eindeutig erkannt.
            bool success = double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.GetCultureInfo("de-DE"), out value);
            if (!success)
            {
                success = double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
            }

            return success && double.IsFinite(value);
        }
    }
}
