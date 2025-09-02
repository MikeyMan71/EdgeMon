using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EdgeMon
{
    internal class Debugfile
    {
        public string Pfad { get; } = "DummyApp";
        StreamWriter sw;
        string debugfilename;

        public Debugfile(string Appname,
                    string version = "1.0",
                    string File = "debug")
        {
           
            string APPDATA = Environment.GetEnvironmentVariable("APPDATA");
            Pfad = APPDATA + "\\" + Appname;

            /* Wenn Appdata\Programmname noch nicht da ist, den Ordner anlegen */
            if (!Directory.Exists(Pfad))
            {
                Directory.CreateDirectory(Pfad);
            }
            debugfilename = Pfad + "\\" + File + ".txt";
            sw = new StreamWriter(debugfilename, false);
            sw.Close();

            
        }

        internal void add(string info)
        {
            sw = new StreamWriter(debugfilename, true);
            sw.WriteLine(info);
            sw.Close();
        }

        ~Debugfile()
        {
            //sw.Close();
        }



    }



    }

