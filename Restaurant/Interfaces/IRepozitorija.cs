using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Interfaces
{
    public interface IRepozitorija <T>
    {
        void RodykVisus();
        T RetriveByID(int id);
    }
}
