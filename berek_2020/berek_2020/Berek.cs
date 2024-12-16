using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace berek_2020
{
    internal class Berek
    {
        public Berek(string sor)
        {
            string[] darabok = sor.Split(';');
            Nev = darabok[0];
            Neme = darabok[1] == "férfi";
            Hely = darabok[2];
            Csatlakozas = darabok[3];
            Ber = int.Parse(darabok[4]);
        }

        public string Nev { get; set; }
        public bool Neme { get; set; }
        public string Hely { get; set; }
        public string Csatlakozas { get; set; }
        public int Ber { get; set; }
    }
}
