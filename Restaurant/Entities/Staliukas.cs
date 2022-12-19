using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Entities
{
    public class Staliukas
    {
        public int StaliukoID { get; set; }
        public int SedimuVietuSkaicius { get; set; }
        public bool ArLaisvas { get; set; }
        public Staliukas() { }
        public Staliukas(int staliukoID, int sedimuVietuSkaicius, bool arLaisvas)
        {
            StaliukoID = staliukoID;
            SedimuVietuSkaicius = sedimuVietuSkaicius;
            ArLaisvas = arLaisvas;
        }
    }
}
