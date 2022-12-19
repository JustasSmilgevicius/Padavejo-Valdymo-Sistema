using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Meniu
{
    public class GerimuMeniu : BendraInformacija
    {
        
        public GerimuMeniu() { }
        public GerimuMeniu(int id, string pavadinimas, decimal kaina)
        {
            ID = id;
            Pavadinimas = pavadinimas;
            Kaina = kaina;
        }
    }
}
