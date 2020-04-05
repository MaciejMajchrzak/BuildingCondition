using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class UserService : IUserService
    {
        private readonly BuildingConditionContext context;

        public UserService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(User user)
        {
            context.Users.Add(user);

            return context.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            var user = context.Users.SingleOrDefault(a => a.Id == id);

            if (user == null)
            {
                return false;
            }

            context.Users.Remove(user);

            return context.SaveChanges() > 0;
        }

        public User Get(string id)
        {
            return context.Users.SingleOrDefault(a => a.Id == id);
        }

        public IList<User> GetAll()
        {
            return context.Users.ToList();
        }

        public bool Update(User user)
        {
            context.Users.Update(user);

            return context.SaveChanges() > 0;
        }
    }
}
