using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IUserService
    {
        bool Create(User user);
        bool Delete(string id);
        User Get(string id);
        IList<User> GetAll();
        bool Update(User user);
    }
}
