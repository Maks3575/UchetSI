using UchetSI.Data.Models;

namespace UchetSI.ViewModels
{
    public class TOViewModel
    {
        public List<TOPositionViewModel> TOPVMs { get; set; } = new List<TOPositionViewModel>();
        public HoldingTO HTO { get; set; }
        public List<ScheduleTO> STOList { get; set; }
        public int IdObj { get; set; }
    }
}
