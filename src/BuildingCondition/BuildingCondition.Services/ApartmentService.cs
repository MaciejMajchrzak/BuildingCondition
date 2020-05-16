using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly BuildingConditionContext context;

        public ApartmentService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(Apartment apartment)
        {
            context.Apartments.Add(apartment);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var apartment = context.Apartments.SingleOrDefault(a => a.Id == id);

            if (apartment == null)
            {
                return false;
            }

            context.Apartments.Remove(apartment);

            return context.SaveChanges() > 0;
        }

        public Apartment Get(int id)
        {
            return context.Apartments.SingleOrDefault(a => a.Id == id);
        }

        public IList<Apartment> GetAll()
        {
            return context.Apartments.ToList();
        }

        public IList<Apartment> GetAllByBuildingId(int id)
        {
            return context.Apartments.Where(a => a.BuildingId == id).OrderBy(a => a.ApartmentNumber).ToList();
        }

        public bool Update(Apartment apartment)
        {
            context.Apartments.Update(apartment);

            return context.SaveChanges() > 0;
        }
    }
}
