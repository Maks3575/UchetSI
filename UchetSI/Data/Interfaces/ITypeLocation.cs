using UchetSI.Data.Models;

namespace UchetSI.Data.Interfaces
{
    public interface ITypeLocation
    {
        IEnumerable<TypeLocation> AllTypeLocations { get; }
    }
}
