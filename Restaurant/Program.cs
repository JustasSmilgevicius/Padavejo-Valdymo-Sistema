using System;
using Restaurant.BusinessLogic;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            var restikas = new Restoranas();
            restikas.UserInterface();
        }
    }
}
