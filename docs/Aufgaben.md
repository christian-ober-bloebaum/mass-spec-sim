# Vom Datenpunkt zum Massenspektrum

Arbeite mit kleinen Beispielen. Vor einer neuen Methode hältst du Eingabe,
Ergebnis, einen Prüffall und den Ablauf in Worten fest. Verwende dafür die
[Planungsvorlage](Planungsvorlage.md). Beginne dann mit dem kleinsten sinnvollen
Schritt und zeige das Ergebnis, bevor du die nächste Funktion ergänzst.

Die nummerierten TODOs in den C#-Dateien gehören zu den Aufgaben hier.
`throw new NotImplementedException(...)` markiert eine offene Methode. Ersetze
diese Zeile durch deine Lösung, sobald du die betreffende Aufgabe bearbeitest.

## 0 – Daten und Diagramm kennenlernen

Starte die Anwendung. Die Beispieldaten sind von Hand festgelegt und haben
keinen Zusammenhang mit den Parameterfeldern. Suche die Datenpunkte für den
ersten Peak in `ExampleSpectrum.Create`.

Ändere genau eine Intensität. Sage vor dem Start voraus, was sich im Diagramm
ändern wird. Prüfe danach auch die Tabelle. Ändere anschließend eine m/z-Position
und beobachte den Unterschied. Die Liste soll nach m/z sortiert bleiben.

**Zeigen und erklären:** Was ist ein Datenpunkt? Warum werden zwei Arrays zum
Zeichnen an ScottPlot übergeben? Verfolge einen Buttonklick bis zur Methode.

## 1 – Eine gleichmäßige Massenskala

Implementiere `SpectrumSimulator.CreateMassAxis`. Die Methode erzeugt ein Array
mit `PointCount` Einträgen, einschließlich beider Grenzen.

**Vor dem Code:** Schreibe die Ergebnisse für 100 bis 104 mit fünf Punkten auf.
Bestimme dann die Werte bei drei Punkten. Wie viele Abstände gibt es zwischen
fünf Punkten? Welche Information brauchst du für den Wert an einem beliebigen Index?

**Kleine Schritte:** Lege zunächst das Array an. Berechne den Abstand. Fülle die
Werte in einer Schleife. Prüfe das Ergebnis mit einem Haltepunkt in `Generate`.
Die Oberfläche meldet danach noch „keine Datenpunkte“, solange Aufgabe 2 offen ist.

**Prüffälle:**

| Minimum | Maximum | Anzahl | Erwartet |
| --- | --- | --- | --- |
| 100 | 104 | 5 | 100, 101, 102, 103, 104 |
| 100 | 104 | 3 | 100, 102, 104 |
| 100 | 104 | 2 | 100, 104 |
| 0 | 1 | 3 | 0, 0.5, 1 |

Die Oberfläche lässt nur einen aufsteigenden Bereich und mindestens zwei Punkte
zu. Ob deine Methode auch ohne Oberfläche ungültige Einstellungen abweisen soll,
kannst du später mit dem Betreuer entscheiden.

## 2 – Einen Peak berechnen

Implementiere die Schleife in `SpectrumSimulator.Generate`. Für jeden Wert aus
der Massenskala wird die Intensität mit `PeakMath.Gaussian` berechnet. Erzeuge
daraus einen `MeasurementPoint` und füge ihn zur Ergebnisliste hinzu.

Die Hilfsfunktion bekommt m/z-Wert, Peakposition, Höhe und Breite. Schau dir
gemeinsam mit dem Betreuer an, warum das Ergebnis direkt im Zentrum der Peakhöhe
entspricht. Du musst die Formel nicht selbst herleiten.

**Vor dem Code:** Zeichne den Weg eines einzelnen m/z-Werts bis zum Datenpunkt.
Welche Werte bleiben während der Schleife gleich, welcher ändert sich?

**Prüfen:**

- Bei den Vorgaben entstehen 1001 Datenpunkte zwischen 100 und 600.
- Bei Position 300, Höhe 1000 und Rauschen 0 ist der Wert bei m/z 300 genau 1000.
- Bei Höhe 0 sind alle Intensitäten 0.
- Eine geänderte Position verschiebt den Peak; größere Breite macht ihn breiter.
- Zwei Erzeugungen mit gleichen Einstellungen und ohne Rauschen liefern gleiche Daten.

**Zusatzexperiment:** Verringere die Anzahl der Punkte stark. Warum sieht der
Peak anders aus? Warum muss der höchste Datenpunkt nicht genau die Peakhöhe erreichen?

## 3 – Rauschen hinzufügen

Implementiere `CreateNoise`. `random.NextDouble()` liefert einen Wert ab 0 und
kleiner als 1. Skaliere ihn auf die gewünschte Amplitude. Addiere in `Generate`
für jeden Datenpunkt einen eigenen Rauschwert zur Peakintensität.

**Vor dem Code:** Welche Werte kann die Methode bei Amplitude 0, 1 und 10 liefern?
Wo muss sie aufgerufen werden, damit nicht jeder Datenpunkt denselben Wert bekommt?

**Prüfen:** Rauschen 0 verändert nichts. Bei Peakhöhe 0 und Rauschen 20 liegen die
Werte zwischen 0 einschließlich und 20 ausschließlich. Negative Werte entstehen
bei diesem vereinfachten Modell nicht. Einzelne Zufallswerte können sich wiederholen;
ein Test darf nicht verlangen, dass jeder Wert von allen anderen verschieden ist.

## 4 – Höchsten Datenpunkt finden

Implementiere `SpectrumAnalysis.FindHighestPoint`. Verwende zunächst eine Schleife,
damit du deinen Suchalgorithmus erklären kannst. Verändere die Liste dabei nicht.
Bei Gleichstand gilt der erste höchste Punkt als Ergebnis, bei einer leeren Liste
gibt die Methode `null` zurück. Das Fragezeichen im Rückgabetyp erlaubt dieses Ergebnis.

**Vor dem Code:** Suche von Hand in den Intensitäten 2, 7, 4, 7. Welche Information
musst du beim Durchlaufen behalten? Was passiert bei nur einem Datenpunkt?

**Prüffälle:**

- Die unveränderten Beispieldaten liefern m/z 200 mit Intensität 1000.
- Eine Liste mit einem Punkt liefert diesen Punkt zurück.
- Eine leere Liste liefert `null`.
- Zwei gleich hohe Maxima liefern den zuerst vorkommenden Punkt.
- Eine Liste aus Nullwerten liefert den ersten Punkt.

Das ist eine Suche nach dem höchsten Datenpunkt, noch keine vollständige Peak-Erkennung.

## 5 – CSV speichern

Implementiere `SpectrumCsv.Save`. Der Speicherdialog ist schon vorbereitet.
Die Datei soll mit `mz,intensity` beginnen, danach folgt ein Wertepaar pro Zeile.
Das festgelegte Format verwendet Komma als Trennzeichen und Punkt als Dezimalzeichen.
Verwende bei der Umwandlung von Zahlen `CultureInfo.InvariantCulture`.

**Vor dem Code:** Schreibe die ganze erwartete Datei für zwei Datenpunkte auf.
Trenne die Fragen: Was ist der Text einer einzelnen Zeile? Wie wird er gespeichert?

Beispiel:

```text
mz,intensity
100,0
100.5,12.25
```

**Hinweise:** `System.IO` enthält Klassen zum Schreiben von Textdateien.
Ein `StreamWriter` muss geschlossen werden, auch wenn ein Fehler auftritt;
besprich dafür die klassische `using`-Anweisung mit dem Betreuer.

**Prüfen:** Öffne die Datei zunächst in einem Texteditor. Bei N Datenpunkten
stehen N+1 Zeilen darin. Prüfe die Werte 100.5 und 12.25 auch dann, wenn die
Windows-Anzeige ein Dezimalkomma verwendet. Eine leere Liste erzeugt nur die
Kopfzeile. Bei einem Fehler darf die Oberfläche nicht „Gespeichert“ melden.

## 6 – Gezielte Tests und Überarbeitung

Wähle mit dem Betreuer einige Prüffälle aus den bisherigen Aufgaben und mache
sie wiederholbar. Ein kleines Testprojekt ist dafür geeignet. Beginne mit
Massenskala und Maximumsuche; diese benötigen kein Fenster. Teste Zahlen mit
Nachkommastellen mit einer geeigneten Toleranz statt blind auf exakte Gleichheit.

Prüfe auch die vorbereitete Eingabeverarbeitung: leere Felder, Texte, vertauschte
Grenzen, Anzahl 1, Breite 0 und eine negative Rauschamplitude. Überlege, welche
Prüfung zur Oberfläche und welche zur Datenverarbeitung gehört.

Entferne erledigte TODOs, benenne unklare Variablen um und lasse jemanden die
Anwendung benutzen. Schreibe drei Beobachtungen auf und behebe die wichtigste.

## Erweiterung A – Mehrere Peaks

Erzeuge zunächst zwei feste Peaks, indem du ihre Intensitäten an jedem m/z-Wert
addierst. Überlege danach, wie eine Klasse `PeakDefinition` und eine Liste von
Peaks die festen Aufrufe ersetzen könnten. Ergänze die Bedienung erst, wenn die
Berechnung mit zwei von Hand festgelegten Peaks stimmt.

**Prüfen:** Ein zweiter Peak mit Höhe 0 ändert nichts. Zwei identische Peaks
verdoppeln die Intensität ohne Rauschen. Rauschen wird pro Datenpunkt einmal
addiert, nicht versehentlich einmal pro Peak.

## Erweiterung B – CSV wieder laden

Lege gemeinsam das Verhalten bei falscher Kopfzeile, fehlenden Spalten, ungültigen
Zahlen, negativen Intensitäten und unsortierten m/z-Werten fest. Implementiere
zuerst das Einlesen einer gültigen Datei, danach einen Fehlerfall nach dem anderen.
Verwende dasselbe Format wie beim Speichern und probiere die Beispieldatei in
`examples/` aus. Lade ein gespeichertes Spektrum wieder und vergleiche die Werte.

## Erweiterung C – Eine Messreihe

Nutze die Timer-Erfahrung aus Tetris. Ein Spieltakt wird nun zu einem Scan:
Spektrum erzeugen, anzeigen und eine laufende Nummer vergeben. Baue zunächst
Start und Stopp für genau diese Schritte. Probiere zehn Scans aus, bevor du
Zeitverläufe oder Dateiexporte ergänzst.

Lass danach zum Beispiel die Peakhöhe über mehrere Scans variieren. Berechne je
Scan die Summe der Intensitäten und zeige einen TIC-ähnlichen Verlauf in einem
zweiten Diagramm. Die Summe ist eine Größe unseres Lernmodells, kein gemessener
elektrischer Strom. Begrenze gespeicherte Scans, damit eine lange Messung den
Arbeitsspeicher nicht unbegrenzt füllt.

**Prüfen:** Stopp beendet die Erzeugung. Mehrfaches Starten erzeugt keine parallelen
Timer. Eine definierte Anzahl Scans endet von selbst. Ein neuer Lauf beginnt mit
einem klar festgelegten Zustand.

## Abschluss

Reserviere die letzten ein bis zwei Tage für Fehlerbehebung, kurze Anleitung und
Demonstration. Zeige den Weg von einem Parameter bis zum Diagramm, erkläre einen
eigenen Algorithmus und beschreibe eine Grenze eures Simulationsmodells.
