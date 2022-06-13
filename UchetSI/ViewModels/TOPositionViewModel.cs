using UchetSI.Data.Models;

namespace UchetSI.ViewModels
{ 
    public class TOPositionViewModel
    {
        public Position Pos { get; set; }
        public MeashuringTool MT { get; set; }
        public TypeTO TTO { get; set; }
    }
}
