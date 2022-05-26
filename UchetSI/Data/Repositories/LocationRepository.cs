using UchetSI.Data.Interfaces;
using UchetSI.Data.Models;

namespace UchetSI.Data.Repositories
{
    public class LocationRepository : ILocation

    {
        private readonly ApplicationContext _context;

        public LocationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> AllOrganization => _context.Locations.Where(p => p.NameLocation == null).ToList();
        public IEnumerable<Location> AllDivision => _context.Locations.Where(l => l.TypeLocation.NameTypelocation == "Подразделение").ToList();

        public IEnumerable<Location> AllObject => _context.Locations.Where(l => l.TypeLocation.NameTypelocation == "Объект").ToList();

        public IEnumerable<Location> AllSubobject => _context.Locations.Where(l => l.TypeLocation.NameTypelocation == "Подобъект").ToList();

        public IEnumerable<Location> AllLocation => _context.Locations.ToList();

        public void AddTypeLocation()
        {
            throw new NotImplementedException();
        }
    }
}
