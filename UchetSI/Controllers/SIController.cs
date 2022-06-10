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

            var SI = (history is null) ? new MeashuringTool() : _db.MeashuringTools.FirstOrDefault(mt => mt.Id == history.MeashuringToolId);
            var DMI = (history is null) ? new DescriptionMI() : _db.DescriptionMIs.FirstOrDefault(dmi => dmi.Id == SI.DescriptionMIId);
            var TOE = (history is null) ? new TypeOfEquipment() : _db.TypeOfEquipments.FirstOrDefault(toe => toe.Id == DMI.TypeOfEquipmentId);
            var DTOE = (history is null) ? new DescriptionOfEquipment() : _db.DescriptionOfEquipments.FirstOrDefault(dtoe => TOE.DescriptionOfEquipmentId == dtoe.Id);
            var MT = (history is null) ? new MeasurementLimit() : _db.MeasurementLimits.FirstOrDefault(mt => mt.Id == DMI.MeasurementLimitId);
            var UM = (history is null) ? new UnitOfMeasurement() : _db.UnitOfMeasurements.FirstOrDefault(um => um.Id == DMI.UnitOfMeasurementId);
            var STAT = (history is null) ? new Status() : _db.Statuses.FirstOrDefault(s => s.Id == history.StatusId);

            //var ser = _db.MeashuringTools(mt => mt.SerialNumber).ToList();

            //SelectList seriya = new SelectList(ser, "Id", "SerialNumber");
            //ViewBag.Seriya = seriya;
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

            //sIVM.OS = new SelectList(_db.OutputSignals.ToList(), "Id", "NameOutputSignal");

            //SelectList OutputSignalSL = new SelectList(_db.OutputSignals.ToList(), "Id", "NameOutputSignal");
            ViewBag.OutputSignalSL = new SelectList(_db.OutputSignals.ToList(), "Id", "NameOutputSignal");

            ViewBag.UnitOfMeasurementSL = new SelectList(_db.UnitOfMeasurements.ToList(), "Id", "UnitName");
            ViewBag.VerificationIntervalSL = new SelectList(_db.VerificationInterval.ToList(), "Id", "Interval");
            ViewBag.TypeOfEquipmentsSL = new SelectList(_db.TypeOfEquipments.ToList(), "Id", "NameTypeOfEquipment");
            ViewBag.StatusOfMT = new SelectList(_db.StatusOfMTs.ToList(), "Id", "NameStatus");

            return View(sIVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SIViewModel SIVM)
        {
            var MT = SIVM.MT;
            var ML = SIVM.ML;

            if(_db.MeasurementLimits.Any(ML => ML.LowerLimit == SIVM.ML.LowerLimit && ML.UpperLimit == SIVM.ML.UpperLimit))
            {
                SIVM.DMI.MeasurementLimitId = _db.MeasurementLimits.First(ML => ML.LowerLimit == SIVM.ML.LowerLimit && ML.UpperLimit == SIVM.ML.UpperLimit).Id;
            }
            else
            {
                _db.MeasurementLimits.Add(SIVM.ML);
                _db.SaveChanges();
                SIVM.DMI.MeasurementLimitId = _db.MeasurementLimits.First(ML => ML.LowerLimit == SIVM.ML.LowerLimit && ML.UpperLimit == SIVM.ML.UpperLimit).Id;
            }
            var _DMI = _db.DescriptionMIs
                .FirstOrDefault(DMI =>
                    DMI.MeasurementLimitId == SIVM.DMI.MeasurementLimitId
                    && DMI.outputSignalId == SIVM.DMI.outputSignalId
                    && DMI.TypeOfEquipmentId == SIVM.DMI.TypeOfEquipmentId
                    && DMI.UnitOfMeasurementId == SIVM.DMI.UnitOfMeasurementId
                    && DMI.VerificationIntervalId == SIVM.DMI.VerificationIntervalId);

            if (_DMI is null)
            {
                _db.DescriptionMIs.Add(SIVM.DMI);
                _db.SaveChanges();
            }

            _DMI = _db.DescriptionMIs
                .First(DMI =>
                    DMI.MeasurementLimitId == SIVM.DMI.MeasurementLimitId
                    && DMI.outputSignalId == SIVM.DMI.outputSignalId
                    && DMI.TypeOfEquipmentId == SIVM.DMI.TypeOfEquipmentId
                    && DMI.UnitOfMeasurementId == SIVM.DMI.UnitOfMeasurementId
                    && DMI.VerificationIntervalId == SIVM.DMI.VerificationIntervalId);
            
            SIVM.MT.DescriptionMIId = _DMI.Id;
            _db.MeashuringTools.Add(SIVM.MT);
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
            //}
            //return View(obj);
        }
    }
}