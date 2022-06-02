using UchetSI.Data.Models;

namespace UchetSI.ViewModels
{
    public class LocationAndPositionVM
    {
        public Location Organization { get; set; }
        public Location Division { get; set; }
        public Location Object { get; set; }
        public Location Subobject { get; set; }
        public Position Position { get; set; }
        public MeashuringTool MT { get; set; }

        public MeasurementLimit ML { get; set; }

        public DescriptionMI DMI { get; set; }

    }
}
