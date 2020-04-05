using System.Collections.Generic;

namespace BuildingCondition.Db.Models
{
    public class BuildingManager
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Building> Buildings { get; set; }

    }
}