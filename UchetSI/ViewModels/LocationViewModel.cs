using UchetSI.Data.Models;

namespace UchetSI.ViewModels
{
    public class LocationViewModel
    {
        public Location Loc { get; set; }

        public Position Pos { get; set; }

        public MeashuringTool MT { get; set; }

        public History His { get; set; }
    }
}
