
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
/*
 * MAMconfig (c) MAM 2024, can be used freely in any project, unless it is commercial.
 * 
 * einfache Klasse, um INI Dateien (ohne Untersektionen) zu lesen und zu erstellen.
 * Erstellung wird "huckepack" beim Lesen durchgeführt
 * 
 * Normaler Ablauf:
 *  Variable für Klasse erzeugen
 *  Mit "Get" einzelne Parameter auslesen
 *  
 *  Die INI Datei wird in %APPDATA%\%APPNAME%\%FILENAME%.ini angelegt/gelesen.
 *  Beim Lesen von Parametern werden Defaultwerte und optionale Kommentare übergeben.
 *  Wird ein Parameter nicht in der Datei gefunden, so werden erst die optionalen Kommentar(e) angelegt, danach eine
 *  Zeile mit "Parameter" = "Defaultwert".
 *  Beim nächsten Programmstart/Aufruf wird dann diese Eintrag gelesen. Der Benutzer kann ihn zwischendurch mit einem Editor
 *  auf seinen Bedarf anpassen.
 *  Hat ein Parameter einen illegalen Wert (Leerstring, oder bei Zahlen keine Ziffer), so wird er auf Default zurückgesetzt.
 *  Tritt ein Parameter in der Datei mehr als einmal auf, so gilt die erste Zeile, alle anderen werden gelöscht.
 */

namespace MAMconfig
{
    public class Config
    {
        private string Pfad { get; } = "DummyApp";
        public string Version { get; } = "1.0";
        public bool Geaendert { get; set; } = false;
        private static Dictionary<string, string> IniListe = new Dictionary<string, string>();
        private static int CommentNumber = 0;

        /*
         * ShowListe(void)
         * nur zum Debuggen: gibt Liste aller Einträge mit Werten auf der Konsole aus
         */
        public void ShowListe()
        {

            foreach (KeyValuePair<string, string> s in IniListe)
            {
                    Console.WriteLine("{0} = {1}", s.Key, s.Value);
            }
        }
        /*
         * readIniFile(string)
         * erwartet vollständigen Pfad+Dateinamen
         * Versucht Datei einzulesen und Array zu befüllen
         * Liest nur Zeilen im Format "key = value" (Leerzeichen usw fliegen raus, Kommentarzeilen auch)
         * liefert zurück, ob Einlesen erfolgreich war (die Datei ist hinterher wieder geschlossen)
         */
        private bool ReadIniFile(string Dateiname)
        {
            try
            {
                if (File.Exists(Dateiname))
                {
                    using (var fs = new FileStream(Dateiname, FileMode.Open, FileAccess.Read))
                    {
                        using (var sr = new StreamReader(fs))
                        {
                            var setupFile = sr.ReadToEnd();
                            List<string> lines = setupFile.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            string property = string.Empty;
                           

                            foreach (string line in lines)
                            {
                                if (line.TrimStart().StartsWith("#") || line.TrimStart().StartsWith(";"))
                                {
                                    this.AddComment(line);
                                }
                                else
                                {
                                    string[] elements = line.Split('=');
                                    if (elements.Count() != 2) continue;
                                    try
                                    {
                                        IniListe.Add(elements[0].Trim().ToLower(), elements[1].Trim());

                                    }
                                    catch (System.ArgumentException e)
                                    {
                                        string X = e.Message;
                                        // könnte ein doppelter Eintrag sein, der zweite fliegt raus!!!
                                        //Console.WriteLine(X);
                                        //Console.ReadLine();
                                    }
                                    //Console.WriteLine(elements[0].Trim()+"="+elements[1].Trim());
                                }
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /*
         * AddComment()
         * Fügt dem Array eine Kommentarzeile hinzu, erhöht den globalen Zähler
         */
        public void AddComment(string comment)
        {
            string key = "#" + CommentNumber.ToString();
            CommentNumber++;
            if (! comment.StartsWith("#"))
            {
                IniListe.Add(key, "# "+comment);
            }
            else
            {
                IniListe.Add(key, comment);
            }
            
        }

        /*
         * Konstruktor
         * Erfordert APPNAME
         * optional Version und Dateiname
         */
        public Config(string Appname,
                      string version = "1.0",
                      string File = "config")
        {
            string APPDATA = Environment.GetEnvironmentVariable("APPDATA");
            Pfad = APPDATA + "\\" + Appname;

            /* Wenn Appdata\Programmname noch nicht da ist, den Ordner anlegen */
            if (!Directory.Exists(Pfad)) 
            {
                Directory.CreateDirectory(Pfad); 
            }
            Pfad = Pfad + "\\" + File + ".ini";
            
            Version = version;
            ReadIniFile(Pfad);
            string oldversion="";
            if (!IniListe.TryGetValue("version", out oldversion))
            {
                IniListe.Add("#0000", "# Dies ist die .INI Datei für das Programm " + Appname + "\r\n# die Einträge erfolgen im Format 'Name'='Wert'\r\n#")
;                IniListe["version"] = version;
                Geaendert = true; // muss neu gespeichert werden
            }
            /*
             * Prüfe auf Update (Unterschied der Versionsnummern)
             */
            if (oldversion != version) 
            {
                IniListe["version"] = version;
                Geaendert = true; 
            }
            //Console.WriteLine("Version:" + IniListe["version"]);
        }

        /* Erzwungenes Schreiben der INI Datei */
        public void WriteINI()
        {
            using (var fs = new FileStream(Pfad, FileMode.Create, FileAccess.Write))
            {
                using (var wr = new StreamWriter(fs))
                {
                    foreach (KeyValuePair<string, string> s in IniListe)
                    {
                        if (s.Key.StartsWith("#"))
                        {
                            wr.WriteLine("{0}", s.Value);
                        }
                        else { wr.WriteLine("{0} = {1}", s.Key.ToLower(), s.Value); }

                    }
                    //Console.WriteLine("INI Datei neu geschrieben");
                }
            }
            Geaendert = false;  
        }

        /* 
         * Destruktor: Schreibt INI Datei, wenn neue Keys (Kommentare zählen nicht) hinzugefügt wurden (update)
         */
        ~Config()
        {
            //Console.Write("Destruktor aufgerufen");
            if (Geaendert)
            {
                // Datei muss neu geschrieben werden. Formatierungen entfallen
                WriteINI();
            }
            //Console.ReadLine();
        }

        /* GetPath()
         * Liefert vollständigen Dateinamen der INI Datei (mit Pfad)
         */
        public string GetPath()
        { 
            return Pfad; 
        }

        /*
         * GetString () liefert String Eintrag zu einem Key
         * Erzeugt Key mit Defaultvalue, wenn Eintrag noch nicht vorhanden ist (update) und markiert zum Neuschreiben bei Programmende
         */
        public string Get(string key,
                          string defaultvalue,
                          string comment = "")
        { 
            string value;
            key = key.ToLower();

            try
            {
                value = IniListe[key];
                if (string.IsNullOrEmpty(value))
                {
                    /*
                     * Leerer String, Eintrag auf DefaultWert setzen.
                     */
                    this.Set(key,defaultvalue);
                    Geaendert = true;
                    return defaultvalue;
                }
            }
            catch (KeyNotFoundException)
            {
                // nicht da, also neu eintragen

                // haben wir einen Kommentar? dann davor einfügen?
                if (!string.IsNullOrEmpty(comment))
                {
                    AddComment(comment);
                }
                IniListe.Add(key, defaultvalue);   
                Geaendert=true; 
                return defaultvalue;
            }
            return value;
        }
        /*
         * GetNumber() dasselbe wie GetValue nur liefert es eine Zahl zurück
         * ACHTUNG! Kann eine Ausnahme erzeugen, wenn der Key keine Ziffern enthält!!!
         */
        public int Get(string key,
                       int defaultValue,
                       string comment = "")
        {
            int value;
            try
            {
                value = Int32.Parse(Get(key, defaultValue.ToString(), comment));
            }
            catch {  value = defaultValue; }

            return value;
        }
        
        public bool Get(string key,
                        bool defaultValue,
                        string comment = "")
        {
            return bool.Parse(Get(key, defaultValue.ToString(), comment));
        }

        /*
         * Set()
         * Seltener benötigt, aber vielleicht braucht es ja mal jemand hier und da
         */
        public void Set (string key,
                         string value)
        {
            try
            {
               IniListe[key.ToLower()] = value;
            }
            catch (KeyNotFoundException)
            {
                
            }
            // merken, dass wir was neu schreiben müssen
           Geaendert = true;  

        }
        public void Set (string key,
                         int value)
        {
            Set (key,value.ToString());
        }

        public void Set (string key,
                         bool value)
        {
            Set (key,value.ToString());
        }

        /*
         * Remove()
         * einen Key löschen (auch wenn er gar nicht da ist)
         */
        public void Remove(string key) => IniListe.Remove(key.ToLower());

        /// <summary>
        /// alle keys löschen
        /// </summary>
        public void Remove()
        {
            IniListe.Clear();
        }


        /*
         * EditINI()
         * Ruft einfach einen Editor auf um die Textdatei bearbeiten zu können
         */
        public void EditINI()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;

            startInfo.Arguments = Pfad;
            Process.Start(startInfo);
        }
    }

}
