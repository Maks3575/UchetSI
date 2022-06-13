using Microsoft.AspNetCore.Mvc;
using UchetSI.Data.Models;
using UchetSI.ViewModels;

namespace UchetSI.Controllers
{
    public class CarryingTOController : Controller
    {
        private readonly ApplicationContext _db;


        public CarryingTOController(ApplicationContext db)
        {

            _db = db;

        }
        public IActionResult Index()
        {
            TOViewModel model = new TOViewModel();
            int idObj = 4;
            var posList = _db.Positions.Where(p => p.Location.ParentId == idObj).ToList();
            var TOPVMList = posList.Select(p => GetTOPosition(p.Id)).Where(t => t.MT != null).ToList();
            if(TOPVMList is null || !TOPVMList.Any())
            {
                return View(model);
            }
            model.TOPVMs = TOPVMList;
            return View(model);
        }


        //public TOPositionViewModel GetTOPosition(int id)
        public IActionResult GetPVTOPosition(int id)
        {

            return PartialView("TOPosition");
        }

        public TOPositionViewModel GetTOPosition(int id)
        {
            TOPositionViewModel TOPVM = new TOPositionViewModel();
            TOPVM.Pos = _db.Positions.FirstOrDefault(p => p.Id == id);
            var Hist = _db.Histories.Where(h => h.PositionId == id && h.MeashuringToolId != null).OrderByDescending(h => h.DateTimeChange).FirstOrDefault();
            if (Hist is null)
            {
                TOPVM.MT = null;
                return TOPVM;
            }
            else
            {
                TOPVM.MT = _db.MeashuringTools.First(MT => MT.Id == Hist.MeashuringToolId);
                TOPVM.MT.StatusOfMT = _db.StatusOfMTs.FirstOrDefault(s => s.Id == TOPVM.MT.StatusOfMTId);
                TOPVM.MT.DescriptionMI = _db.DescriptionMIs.FirstOrDefault(d => d.Id == TOPVM.MT.DescriptionMIId);
                TOPVM.MT.DescriptionMI.MeasurementLimit = _db.MeasurementLimits.FirstOrDefault(m => m.Id == TOPVM.MT.DescriptionMI.MeasurementLimitId);
                TOPVM.MT.DescriptionMI.outputSignal = _db.OutputSignals.FirstOrDefault(o => o.Id == TOPVM.MT.DescriptionMI.outputSignalId);
                TOPVM.MT.DescriptionMI.UnitOfMeasurement = _db.UnitOfMeasurements.FirstOrDefault(u => u.Id == TOPVM.MT.DescriptionMI.UnitOfMeasurementId);
                TOPVM.MT.DescriptionMI.VerificationInterval = _db.VerificationInterval.FirstOrDefault(v => v.Id == TOPVM.MT.DescriptionMI.VerificationIntervalId);
                TOPVM.MT.DescriptionMI.TypeOfEquipment = _db.TypeOfEquipments.FirstOrDefault(t => t.Id == TOPVM.MT.DescriptionMI.TypeOfEquipmentId);
                TOPVM.MT.DescriptionMI.TypeOfEquipment.Maker = _db.Makers.FirstOrDefault(tm => tm.Id == TOPVM.MT.DescriptionMI.TypeOfEquipment.MakerId);
                TOPVM.MT.DescriptionMI.TypeOfEquipment.DescriptionOfEquipment = _db.DescriptionOfEquipments
                    .FirstOrDefault(td => td.Id == TOPVM.MT.DescriptionMI.TypeOfEquipment.DescriptionOfEquipmentId);

                Location subObj = _db.Locations.FirstOrDefault(l => l.Id == TOPVM.Pos.LocationId);
                Location obj = _db.Locations.FirstOrDefault(l => l.Id == subObj.ParentId);
 
                var HTO = _db.HoldingTOs.FirstOrDefault(h => h.LocationId == obj.Id && h.YearEvent == DateTime.Now.Year);
                if (HTO == null)
                {
                    TOPVM.TTO = new TypeTO();
                    TOPVM.TTO.NameTO = "Не указан";
                    return TOPVM;
                }
                //var sto = HTO.ScheduleTOs.ToList();
                var STO = _db.ScheduleTOs.FirstOrDefault(s => s.NumberMonth == DateTime.Now.Month && s.HoldingTOId == HTO.Id);
                TOPVM.TTO = _db.TypeTOs.FirstOrDefault(t => t.Id == STO.TypeTOId);
                return TOPVM;
            }
        }
    }
}
