﻿using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IGasDetectorService
    {
        bool Create(GasDetector gasDetector);
        bool Delete(int id);
        GasDetector Get(int id);
        IList<GasDetector> GetAll();
        bool Update(GasDetector gasDetector);
    }
}
