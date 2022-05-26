using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UchetSI.Data.Models;
using UchetSI.ViewModels;

namespace UchetSI.Controllers
{
    public class SIController : Controller
    {
        private readonly ApplicationContext _db;

        public SIController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index(int idPosition)
        {
            History history = _db.Histories
                .Where(h => h.PositionId == idPosition)
                .OrderByDescending(h => h.DateTimeChange)
                .FirstOrDefault();

            var SI = (history is null) ? new MeashuringTool() : _db.MeashuringTools.First(mt => mt.Id == history.MeashuringToolId);
            var DMI = (history is null) ? new DescriptionMI() : _db.DescriptionMIs.First(dmi => dmi.Id == SI.DescriptionMIId);
            var TOE = (history is null) ? new TypeOfEquipment() : _db.TypeOfEquipments.First(toe => toe.DescriptionOfEquipmentId == SI.DescriptionMIId);
            var DTOE = (history is null) ? new DescriptionOfEquipment() : _db.DescriptionOfEquipments.First(dtoe => TOE.DescriptionOfEquipmentId == dtoe.Id);
            var MT = (history is null) ? new MeasurementLimit() : _db.MeasurementLimits.First(mt => mt.Id == DMI.MeasurementLimitId);
            var UM = (history is null) ? new UnitOfMeasurement() : _db.UnitOfMeasurements.First(um => um.Id == DMI.UnitOfMeasurementId);
            var STAT = (history is null) ? new Status() : _db.Statuses.First(s => s.Id == history.StatusId);
            ViewBag.SI = SI;
            ViewBag.TOE = TOE;
            ViewBag.DTOE = DTOE;
            ViewBag.MT = MT;
            ViewBag.UM = UM;
            ViewBag.STAT = STAT;
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            SIViewModel sIVM = new SIViewModel();

            sIVM.OS = _db.OutputSignals.ToList();

            //SelectList OutputSignalSL = new SelectList(_db.OutputSignals.ToList(), "Id", "NameOutputSignal");
            ViewBag.OutputSignalSL = new SelectList(_db.OutputSignals.ToList(), "Id", "NameOutputSignal");

            ViewBag.UnitOfMeasurementSL = new SelectList(_db.UnitOfMeasurements.ToList(), "Id", "UnitName");
            ViewBag.VerificationIntervalSL = new SelectList(_db.VerificationInterval.ToList(), "Id", "Interval");

            return View(sIVM);
        }
    }
}