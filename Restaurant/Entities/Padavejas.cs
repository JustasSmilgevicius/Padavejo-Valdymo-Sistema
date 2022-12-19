using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Entities
{
    public class Padavejas
    {
        public int PadavejoID{get;set;}
        public string PadavejoVardas { get; set; }
        public Padavejas() { }
        public Padavejas(int padavejoID, string padavejoVardas)
        {
            PadavejoID = padavejoID;
            PadavejoVardas = padavejoVardas;
        }

    }
}
