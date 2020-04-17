using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Models.ViewModels.DashboardViewModels
{
    public class DashboardUsersViewModel
    {
        public ICollection<User> Users { get; set; }
    }
}
