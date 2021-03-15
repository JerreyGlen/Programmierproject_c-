# Programmierproject_c-sharp
Kooperatives Design
Zwei Leute können durch Inventor zusammen arbeiten. Der eine, der Moderator, kann sein Bildschirm dem ZUschauer teilen und der Zuschauer kann
einen Laserpointer benutzen, um dem Moderator genau was auf seinem Bildschirm. Das heißt, der Moderator
kann sehen, wohin der Moderator geklickt und demzufolge seine Sorge verstehen.
Der ZUschauer kann Moderatorrechte beantragen. Die beiden kommunizieren durch einen Chat.

Installationshinweise:
Das Endprodukt befindet sich im Ordner /program/AddIn-Client.sln und /program/Server/Server.sln
In der Addin-Client.sln ist AddIn-Client als Start-Projektt zu wählen und bei Server.sln Server.
Der Hostname des Servers lässt sich über die Settings-Datei(Settings.settings) im Projekt ClientNetworking einstellen
(Standardmäßig ist localhost eingestellt).
in der .addin Datei im Projekt AddIn-Client, muss beim Assembly-Property der XML-Datei
der Pfad zur .dll Datei des Projekts angegeben werden
also: <kompletter lokaler Pfad zum repository>\grp10\programm\AddIn-Client\Jerrey\AddIn_Client\bin\Debug\AddIn_Client.dll
Dann kann das Programm gestartet werden.
In Inventor kann nocheinmal überprüft werden, ob mit der Pfadangabe alles gestimmt hat, indem man
unter Extras > Zusatzmoodule das Addin "AddIn-Client" auswählt. Dort sind am besten die Häkchen bei "Geladen/nicht Geladen" und "Automatisch laden" zu setzen.

wichtiger Hinweis:
Da die Arbeitsdatei zwischen zwei partnern ausgetauscht wird, funktioniert Das AddIn nur mit Dokumenten die bereits gespeichert wurden.
Also wenn man ein neues Dokument öffnet, muss man dies zuerst speichern, bevor man eine Verbindung zum Server aufbaut.
viel Spaß beim ausprobieren!
