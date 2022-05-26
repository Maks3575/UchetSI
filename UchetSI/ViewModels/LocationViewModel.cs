using UchetSI.Data.Models;

namespace UchetSI.ViewModels
{
    public class LocationViewModel
    {
        public IEnumerable<Location> Loc { get; set; }

        public IEnumerable<Position> Pos { get; set; }

    }
}
