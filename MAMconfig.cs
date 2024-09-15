using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
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
 *  
 *  Versionen:
 *  1.0: intitiale Veröffentlichung
 *  1.1: Kommentare für Funktionsparameter/Manual eingefügt. Potentielle Race Condition im Destruktor entfernt. Remove(<NoParameter>) löscht
 *       nun die komplette Liste mit Clear(). Aufruf des Editors erzwingt Neuschreiben der INI Datei.
 *  1.2: FindNotepad() hinzugefügt, da Notepad.exe ab W112024H2 nicht mehr im Systemverzeichnis ist, sondern als App ohne PATH Eintrag
 */
namespace MAMconfig
{
    public class Config
    {
        private string Pfad { get; } = "DummyApp";
        public string Version { get; } = "1.1";
        public bool Geaendert { get; set; } = false;
        private static Dictionary<string, string> IniListe = new Dictionary<string, string>();
        private static int CommentNumber = 0;
        /// <summary>
        /// zeigt alle Einträge der Liste auf der Console
        /// NUR ZUM DEBUGGEN!!!
        /// </summary>
        public void ShowListe()
        {
            foreach (KeyValuePair<string, string> s in IniListe)
            {
                    Console.WriteLine("{0} = {1}", s.Key, s.Value);
            }
        }
        /// <summary>
        /// Liest angegebene Datei ein.
        /// Übernimmt nur Kommentarzeilen und Zeilen im Format "Key = Value"
        /// </summary>
        /// <param name="Dateiname"></param>
        /// <returns>ob das Einlesen erfolgreich war</returns>
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
        /// <summary>
        /// Fügt dem Array eine Kommentarzeile hinzu, erhöht den globalen Zähler
        /// </summary>
        /// <param name="comment"> der Kommentar (für mehrzeilige Kommentare im String "\r\n#" verwenden)</param>
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
        /// <summary>
        /// Konstruktor erzeugt INI Objekt und versucht die Datei einzulesen
        /// 
        /// </summary>
        /// <param name="Appname">Name der Anwendung (Unterverzeichnis von APPDATA)</param>
        /// <param name="version">beliebig, wird nur auf Unterschiede getestet</param>
        /// <param name="File">Dateiname (ohne Suffix, der ist fest .INI)</param>
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
        /// <summary>
        /// schreibt die aktuellen Kommentare und Einstellungen in die INI Datei
        /// setzt das Geändert Flag zurück.
        /// Wird bei Programmende bei Bedarf aufgerufen, kann aber auch jederzeit manuell ausgelöst werden.
        /// </summary>
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
        /// <summary>
        /// Destruktor: schreibt, wenn Änderungen anstehen, die INI Datei 
        /// </summary>
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
        /// <summary>
        /// liefert Dateiname der verwendeten INI Datei
        /// </summary>
        /// <returns>vollständer Pfad und Dateiname der INI Datei</returns>
        public string GetPath()
        { 
            return Pfad;
        }
        /// <summary>
        /// liefert Wert zu einem Key als String
        /// Erzeugt Key mit Defaultvalue, wenn Eintrag noch nicht vorhanden ist(update) und markiert zum Neuschreiben bei Programmende
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultvalue"></param>
        /// <param name="comment">optionaler Kommentar, der vor dem Key eingefügt werden soll</param>
        /// <returns>Wert des gesuchten Keys<returns>
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
        /// <summary>
        /// liefert Wert zu einem Key als Zahl
        /// Erzeugt Key mit Defaultvalue, wenn Eintrag noch nicht vorhanden ist(update) und markiert zum Neuschreiben bei Programmende
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="comment"></param>
        /// <returns>INT Repräsentation des Wertes</returns>
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
        /// <summary>
        /// liefert Wert zu einem Key als logischen Wert
        /// Erzeugt Key mit Defaultvalue, wenn Eintrag noch nicht vorhanden ist(update) und markiert zum Neuschreiben bei Programmende
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="comment"></param>
        /// <returns>logischen Wert des Keys</returns>
        public bool Get(string key,
                        bool defaultValue,
                        string comment = "")
        {
            bool value;
            try
            {
                value = bool.Parse(Get(key, defaultValue.ToString(), comment));
            }
            catch { value = defaultValue; }
            return value; 
        }
        /// <summary>
        /// setzt einen Key auf einen Wert (string)
        /// Wenn noch nicht vorhanden, wird der Key erzeugt und am Ende des Arrays angehängt
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
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
        /// <summary>
        /// setzt einen Key auf einen Wert (Zahl)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set (string key,
                         int value)
        {
            Set (key,value.ToString());
        }
        /// <summary>
        /// setzt einen Key auf einen Wert (logische Werte)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set (string key,
                         bool value)
        {
            Set (key,value.ToString());
        }
       /// <summary>
       /// Einen oder alle Keys der Liste löschen
       /// </summary>
       /// <param name="key"></param>
        public void Remove(string key="")
        {
            Geaendert = true; // egal was passiert, muss später neu geschrieben werden
            // auf besonderem Wunsch eines einzelnen Herrens :-)))
            if (string.IsNullOrEmpty(key))
            {
                IniListe.Clear();
            }
            else
            {
                IniListe.Remove(key.ToLower());
            }
        }
        /// <summary>
        /// Startet notepad.exe mit der INI Datei
        /// Stehen Änderungen an, so werden sie vorher in die INI geschrieben
        /// </summary>
        public void EditINI()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(FindNotepad());
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = Pfad;
            // wenn Änderungen anstehen, erstmal wegschreiben, damit der Benutzer den aktuellen Stand zu Gesicht
            // bekommt. MAM 03.03.2024
            if (Geaendert) { WriteINI(); }
            Process.Start(startInfo);
        }
        /// <summary>
        /// Sucht auf neueren Computern die App "notepad.exe", die nun nicht mehr im Systemverzeichnis und somit im Pfad erreichbar ist
        /// </summary>
        /// <returns>Vollen Pfad des neuen Notepad.exe oder, auf alten Maschinen, einfach "notepad.exe"</returns>
        /// 
        // Böööhse Puuhben bei Microsoft! Nach nur 40 Jahren löschen sie einfach den Editor notepad.exe und packen stattdessen
        // eine zwielichtige App in einen mystischen Pfad, der nicht in PATH eingetragen ist. 
        // da müssen wir uns die Kommandozeile selber zusammenbasteln, statt es der Shell zu überlassen
        // "C:\Program Files\WindowsApps\Microsoft.WindowsNotepad_11.2407.8.0_x64__8wekyb3d8bbwe\Notepad\Notepad.exe"
        // HKEY_CLASSES_ROOT\AppX1b0e9ytcwx0wcmvkdey0h6af04t1ta3z\Shell\open\command
        // MAM 15.09.2024
        public string FindNotepad()
        {
            string X;
            X=(string)Registry.GetValue("HKEY_CLASSES_ROOT\\AppX1b0e9ytcwx0wcmvkdey0h6af04t1ta3z\\Shell\\open\\command", "", "notepad.exe");
            return X;
        }
    }
}
