﻿using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IApartmentElectricalInstalationReportService
    {
        bool Create(ApartmentElectricalInstalationReport apartmentElectricalInstalationReport);
        bool Delete(int id);
        ApartmentElectricalInstalationReport Get(int id);
        IList<ApartmentElectricalInstalationReport> GetAll();
        bool Update(ApartmentElectricalInstalationReport apartmentElectricalInstalationReport);
    }
}
