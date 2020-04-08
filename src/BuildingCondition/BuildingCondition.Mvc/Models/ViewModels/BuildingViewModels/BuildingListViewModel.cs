using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Models.ViewModels.BuildingViewModels
{
    public class BuildingListViewModel
    {
        public ICollection<Building> Buildings { get; set; }
    }
}
