Build-Infos:
Alle Projekte haben das Zielframework .Net-Framework 4.7.2.
und lassen sich entsprechend unter Windows mit Visual-Studio erstellen.
Als start-Projekt muss man den Client-Dummy wählen, alle anderen Projekte sind Klassenbibliotheken.

Da beim Client für den LaserPointer NuGet-Pakete verwendet werden, 
ist es von Vorteil die automatische Paketwiederherstellung in Visual-Studio aktivert zu haben.

Der Hostname des Servers lässt sich über die Settings-Datei im Projekt "ClientNetworking" einstellen.
Standardmäßig ist dieser auf "localhost" gesetzt.

Anleitung zum Client Dummy:

Inventor muss vollständig laufen beim Start des Client-Dummys, also nicht nur das Ladefenster beim Applikationsstart.
Genauso wie es auch laufen würde, wenn das AddIn verwendet werden würde.
Der Server läuft ohne Benutzerinteraktion von ganz alleine und lässt sich über die Entertaste beenden.
Beim Client-Dummy, gibt es verschiedene Buttons und Eingabefelder.

Die Session mit der man sich verbinden möchte, kann man oben links eintragen. Wird dieses Feld leer gelassen, wird eine neue Session erstellt.
Direkt daneben lässt sich die Datei auswählen, die synchronisiert werden soll.
Mit dem SendFile-Button kann man die ausgewählte datei senden und die Kopie beim anderen Client wird überschrieben und mit notepad geöffnet.

Die große blaue Fläche zeigt Bilder an die gesendet(mit dem send Screenshot button) und empfangen wurden 
und wenn man dadrauf klickt, wird die relative Position im blauen Feld
übertragen und als laserpointerpunkt in Inventor beim anderen Client in der Session angezeigt.

Mit dem "Request Moderator"-Button, kann der Zuschauer(Viewer) eine Anfrage senden
wodurch beim Moderator ein popupfenster angezeigt wird, in dem man die Anfrage bestätigt oder ablehnt.
Die Antwort wird dann wiederum zurückgeschickt an den Zuschauer. Je nach Antwort wechseln die Rollen oder eben nicht.
Mit End-Session / Quit session, kann man die Verbindung trennen. Trennt der Moderator die Verbindung, wird die Session automatisch beendet.

Damit kann man alle Funktionen der Networking, Server und Laserpointer Komponenten testen.
