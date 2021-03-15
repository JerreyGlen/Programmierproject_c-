Buildinfos:
	Alle Projekte in der solution haben das ZielFramework .Net-Framework 4.7.2
	unter Windows: 
		Unter Visual Studio Server als Startprojekt setzen und alles erstellen.

	Unter Linux:
		Unter linux kann man die serverkomponente mit dem mono-developmentkit kompilieren:
			$> xbuild Server.sln
			
Anleitung:
	Der Server läuft von alleine. Man muss ihn nur starten und beenden kann man ihn mit der Enter-Taste.
	Er läuft standardmäßig auf dem Port 4444.
	Falls der Server auf einem anderen Rechner läuft, auf dem man auch den Client laufen lässt,
	muss die Firewall so konfiguriert sein, dass sie eingehende Verbindungen über den Port zulässt.
	