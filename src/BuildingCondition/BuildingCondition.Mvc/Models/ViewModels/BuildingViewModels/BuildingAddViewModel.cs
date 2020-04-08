using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Models.ViewModels.BuildingViewModels
{
    public class BuildingAddViewModel : Building
    {
        public int NumberOfApartments { get; set; }
        public int NumberOfGates { get; set; }
        public new List<Apartment> Apartments { get; set; }
    }
}
