﻿using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IBuildingService
    {
        bool Create(Building building);
        bool Delete(int id);
        Building Get(int id);
        IList<Building> GetAll();
        bool Update(Building building);
    }
}
