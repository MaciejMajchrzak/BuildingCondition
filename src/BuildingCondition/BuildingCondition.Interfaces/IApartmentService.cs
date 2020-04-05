using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IApartmentService
    {
        bool Create(Apartment apartment);
        bool Delete(int id);
        Apartment Get(int id);
        IList<Apartment> GetAll();
        bool Update(Apartment apartment);
    }
}
