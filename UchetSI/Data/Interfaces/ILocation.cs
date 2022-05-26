using UchetSI.Data.Models;

namespace UchetSI.Data.Interfaces
{
    public interface ILocation
    {
        IEnumerable<Location> AllOrganization { get; }
        IEnumerable<Location> AllDivision { get; }
        IEnumerable<Location> AllObject { get; }
        IEnumerable<Location> AllSubobject { get; }
        IEnumerable<Location> AllLocation { get; }
        void AddTypeLocation();


    }
}
