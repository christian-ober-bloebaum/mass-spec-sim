# Massenspektrum-Simulator

WPF-Grundgerüst für ein C#-Praktikumsprojekt nach dem Einstieg mit Tetris.
Die Anwendung startet mit festen Beispieldaten. Simulation, Auswertung und
CSV-Export sind als kleine Lernaufgaben vorbereitet.

## Starten

Voraussetzungen: Windows 10 ab Version 2004 oder Windows 11, .NET 10 SDK und beispielsweise Visual Studio 2026 mit
der Workload „.NET-Desktopentwicklung“.

1. `MassSpecSim.sln` öffnen und die NuGet-Pakete wiederherstellen lassen.
2. Mit F5 starten. Im Diagramm erscheinen zwei Peaks aus festen Beispieldaten.
3. Den Reiter **Messwerte** ausprobieren und `ExampleSpectrum.cs` ansehen.
4. Mit [Aufgabe 0](docs/Aufgaben.md) beginnen. Vor jeder neuen Methode die
   [Planungsvorlage](docs/Planungsvorlage.md) ausfüllen.

Alternativ im Projektordner:

```powershell
dotnet build MassSpecSim.sln
dotnet run --project MassSpecSim/MassSpecSim.csproj
```

Die ausführbare Anwendung liegt nach einem Debug-Build in
`MassSpecSim/bin/Debug/net10.0-windows10.0.19041.0/MassSpecSim.exe`.

## Was funktioniert bereits?

- Fenster mit Eingabefeldern, Parameterprüfung und Buttons.
- Diagramm mit Zoom und Verschieben sowie eine Tabelle derselben Datenpunkte.
- Feste Beispieldaten mit zwei Peaks, unabhängig von den Eingabefeldern.
- Eine erklärte Hilfsfunktion für einen Gauß-Peak.
- Anbindung der offenen Lernmethoden an die Oberfläche und den Speicherdialog.
- Hinweise auf offene Aufgaben, ohne dass die Anwendung dadurch abstürzt.

**Die Simulation und der CSV-Export sind absichtlich noch nicht implementiert.**
„Spektrum erzeugen“ zeigt zunächst einen Hinweis auf Aufgabe 1. Bei offenen
Methoden wird `NotImplementedException` verwendet. Diese Platzhalter werden
jeweils durch die eigene Lösung ersetzt. Andere Programmierfehler werden nicht
pauschal abgefangen, damit sie beim Debuggen sichtbar bleiben.

## Dateien und Zuständigkeiten

| Datei | Aufgabe | Einstieg |
| --- | --- | --- |
| `MeasurementPoint.cs` | Ein m/z-Wert mit seiner Intensität | Verstehen |
| `SimulationSettings.cs` | Parameter für die Simulation | Verstehen |
| `ExampleSpectrum.cs` | Von Hand festgelegte Daten | Aufgabe 0 |
| `SpectrumSimulator.cs` | Massenskala, Peak und Rauschen | Aufgaben 1–3 |
| `PeakMath.cs` | Vorbereitete Gaußfunktion | Experimentieren |
| `SpectrumAnalysis.cs` | Höchsten Datenpunkt suchen | Aufgabe 4 |
| `SpectrumCsv.cs` | Datei schreiben | Aufgabe 5 |
| `SpectrumChart.cs` | Verbindung zu ScottPlot | Ist vorbereitet |
| `MainWindow.xaml` und `.xaml.cs` | Oberfläche und Aufrufe der Methoden | Gemeinsam lesen |

Die C#-Dateien liegen im Ordner `MassSpecSim/`. Der Code verwendet C# 14 und
.NET 10, klassische Klassen und Namespaces, explizite Typen und deutsche
Kommentare. Neue Algorithmen sollen zunächst mit Schleifen und kleinen Methoden
verständlich werden. Ein zusätzliches Architektur-Framework wird nicht benötigt.

## Fachliches Modell

Ein Spektrum ist hier eine Liste von Wertepaaren: m/z auf der horizontalen Achse
und Intensität in frei gewählten Einheiten (a.u.) auf der vertikalen Achse.
Die Linie verbindet die Datenpunkte. Sie berechnet keine zusätzlichen Messwerte.

Wir erzeugen vereinfachte Gaußkurven und addieren später gleichverteiltes,
nichtnegatives Rauschen. `PeakWidth` ist Sigma der Gaußkurve. Das ist ein Lernmodell,
kein physikalisches Gerätemodell. Der höchste abgetastete Punkt kann unterhalb der
vorgegebenen Peakhöhe liegen, wenn das Zentrum zwischen zwei Datenpunkten liegt.

## Diagrammbibliothek

Vorgegeben ist **ScottPlot.WPF 5.1.59** aus NuGet. ScottPlot ist kostenlos und
steht unter der MIT-Lizenz. Die konkrete Version steht in der Projektdatei;
`packages.lock.json` hält die aufgelösten Abhängigkeiten fest.

- [NuGet-Paket](https://www.nuget.org/packages/ScottPlot.WPF/5.1.59)
- [WPF-Einstieg](https://scottplot.net/quickstart/wpf/)
- [Beispiele für ScottPlot 5](https://scottplot.net/cookbook/5/)
- [ScottPlot-Lizenz](https://github.com/ScottPlot/ScottPlot/blob/main/LICENSE)

`NuGet.Config` verwendet für dieses Projekt ausschließlich nuget.org. Beim ersten
Wiederherstellen ist Internetzugriff erforderlich. Danach liegen die Pakete im
lokalen NuGet-Cache. Für einen anderen Rechner können sie auch vorab bereitgestellt
werden; ein kopierter Quellcodeordner allein enthält die Pakete nicht.

## Arbeitsweise

Erst Eingabe und gewünschtes Ergebnis aufschreiben, dann ein Mini-Beispiel von
Hand lösen, danach den Ablauf formulieren und programmieren. Die Aufgaben enthalten
konkrete Prüffälle. Halte funktionierende Zwischenstände in kleinen Git-Commits fest.

Ein möglicher Rahmen für die drei verbleibenden Wochen:

| Woche | Schwerpunkt |
| --- | --- |
| 1 | Datenfluss verstehen, Massenskala, einzelner Peak und Rauschen |
| 2 | Auswertung, CSV-Export, gezielte Prüffälle; bei Bedarf mehrere Peaks |
| 3 | Eine passende Erweiterung, Fehlerbehebung, Dokumentation und Demonstration |

Die Erweiterungen sind frei wählbar. Ein einzelnes einstellbares Spektrum mit
Auswertung und Export ist bereits ein abgeschlossenes Projekt.
