using UchetSI.Data.Interfaces;
using UchetSI.Data.Models;

namespace UchetSI.Data.Repositories
{
    public class TypeLocationRepository : ITypeLocation
    {
        private readonly ApplicationContext _context;

        public TypeLocationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<TypeLocation> AllTypeLocations => _context.TypeLocations.ToList();
    }
}
