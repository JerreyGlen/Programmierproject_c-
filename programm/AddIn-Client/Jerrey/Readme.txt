normalerweise Um das Programm zum Testen soll das Inventoraddin Projekt auf dem Rechner installiert worden und von Inventor
detektiert worden. Das Addin Datei soll als zusatzmodule von Inventor aufgerufen werden.
Inventor kann es selbst detektiert, aber es muss immer manuell zwischen Zusatzmodule hinzugefügt werden.
Bei Der Eigenschaften des Addin-Klassenbibliothek soll Inventorunter Debuggen als externes Programm festgelegt werden.
Dann kann es wenn man will das Programm auf visual Studio gestartet werden.
Andersfall kann die KlassenBilbliothek Application nur zum test vom GuI benutzt werden. Als Start Projekt soll es festlegt werden und fertig

Das Gemachte ist folgendermaße aufgebaut:

-Die KlassenBilbliothek AddinClient: hier wurde ein IventorAddinProjekt aufgebaut
Ziel: Hinzufügen von 3 Addins Button in Invenor Toolbar "ZUsatzmodule"
Diese Buttons ermöglichen das Erstellen einer neuen Session, das Beitreten einer Session, Das Öffnen der AddOut Apps. Das
Beenden der laufenden Session, Das zeigen seiner Information: Username ind MeetingID.
Das Bibliothek besteht aus folgenden Dateien(Klasse):
AddinGlobal: DIe InventorSteuerelemente werden deklariert
AssemblysInfo: Allgemeinen Informationen über Assembly werden durch Das Eingeben von Parametern gesteuert
ButtonAction: was gemacht wird wenn auf jeden Button geklickt wird
InventorButton: Es wird nutzliche Konstructoren von Inventorsteuerelemente Aufgerufen
StandardAddInServer: Hier wird Buttons and Toolbar an Inventor hinzugefügt

-Die KlassenBilbliothek Application: Nur zum test vom GuI. Als Start Projekt festlegen und fertig

-Die KlassenBilbliothek Client: Hier Gibt es Alle windowaforms
Chaat: um Nachrichten zu zeigen.

Disconnect: die Session beenden

GUI: Die Hauptwindowsform, Enthält StreamingTeil

Help: für Hilfe

Moderator: Wenn man Moderator werden will

UserID: Fragt Username und Meetings Id, bevor Gui mit dieden Informationen geöffnet wird.