using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UchetSI.Data.Models;
using UchetSI.ViewModels;

namespace UchetSI.Controllers
{
    public class MoveSIController : Controller
    {
        private readonly ApplicationContext _db;


        public MoveSIController(ApplicationContext db)
        {

            _db = db;

        }
        public IActionResult Index()
        {
            List<Location> org = _db.Locations.Where(or => or.TypeLocation.NameTypelocation == "Организация").ToList();
            List<Location> div = _db.Locations.Where(d => d.ParentId == org.FirstOrDefault().Id).ToList();
            List<Location> obj = _db.Locations.Where(ob => ob.ParentId == div.FirstOrDefault().Id).ToList();
            List<Location> subObj = _db.Locations.Where(s => s.ParentId == obj.FirstOrDefault().Id).ToList();
            List<Position> pos = _db.Positions.Where(p => p.LocationId == subObj.FirstOrDefault().Id).ToList();
            List<MeashuringTool> mt = _db.MeashuringTools.ToList();
            List<StatusOfMT> somt = _db.StatusOfMTs.ToList();
            List<Status> stat = _db.Statuses.ToList();


            SelectList organization = new SelectList(org, "Id", "NameLocation");
            ViewBag.Organization = organization;
            SelectList division = new SelectList(div, "Id", "NameLocation");

            ViewBag.Division = division;
            SelectList objects = new SelectList(obj, "Id", "NameLocation");

            ViewBag.Objects = objects;
            SelectList subobjects = new SelectList(subObj, "Id", "NameLocation");

            ViewBag.Subobjects = subobjects;

            SelectList position = new SelectList(pos, "Id", "NamePosition");

            ViewBag.PositionList = position;

            SelectList tools = new SelectList(mt, "Id", "SerialNumber");

            ViewBag.Tools = tools;

            SelectList status = new SelectList(somt, "Id", "NameStatus");

            ViewBag.Status = status;

            SelectList statusHis = new SelectList(stat, "Id", "NameStatus");

            ViewBag.StatusHis = statusHis;

            //if (!String.IsNullOrWhiteSpace(Name))
            //{
            //    return View();
            //}

            return View(/*_db.Positions.Where(p => p.NamePosition == Name).Take(50)*/);
        }

        [HttpGet]
        public ActionResult GetPosition(int id)
        {
            LocationAndPositionVM LAPVM = new LocationAndPositionVM();
            LAPVM.Position = _db.Positions.FirstOrDefault(p => p.Id == id);
            LAPVM.Subobject = _db.Locations.First(s => s.Id == LAPVM.Position.LocationId);
            LAPVM.Object = _db.Locations.First(o => o.Id == LAPVM.Subobject.ParentId);
            LAPVM.Division = _db.Locations.First(d => d.Id == LAPVM.Object.ParentId);
            LAPVM.Organization = _db.Locations.First(org => org.Id == LAPVM.Division.ParentId);
            return PartialView(LAPVM);
        }

        public ActionResult GetItem(int id)
        {
            return PartialView(_db.Locations.Where(l => l.ParentId == id).ToList());
        }
        public ActionResult GetItemPosition(int id)
        {
            return PartialView(_db.Positions.Where(p => p.LocationId == id).ToList());
        }
            
        public ActionResult GetSI(int id)
        {
            MeashuringTool MT = _db.MeashuringTools.FirstOrDefault(mt => mt.Id == id);
            MT.DescriptionMI = _db.DescriptionMIs.First(DMI => DMI.Id == MT.DescriptionMIId);
            MT.DescriptionMI.MeasurementLimit = _db.MeasurementLimits.First(ML => ML.Id == MT.DescriptionMI.MeasurementLimitId);
            MT.DescriptionMI.outputSignal = _db.OutputSignals.First(OS => OS.Id == MT.DescriptionMI.outputSignalId);
            MT.DescriptionMI.TypeOfEquipment = _db.TypeOfEquipments.First(TOE => TOE.Id == MT.DescriptionMI.TypeOfEquipmentId);
            MT.DescriptionMI.TypeOfEquipment.Maker = _db.Makers.First(M => M.Id == MT.DescriptionMI.TypeOfEquipment.MakerId);
            MT.DescriptionMI.TypeOfEquipment.DescriptionOfEquipment = _db.DescriptionOfEquipments.First(DOE => DOE.Id == MT.DescriptionMI.TypeOfEquipment.DescriptionOfEquipmentId);
            MT.DescriptionMI.UnitOfMeasurement = _db.UnitOfMeasurements.First(UOM => UOM.Id == MT.DescriptionMI.UnitOfMeasurementId);
            MT.DescriptionMI.VerificationInterval = _db.VerificationInterval.First(VI => VI.Id == MT.DescriptionMI.VerificationIntervalId);
            return PartialView(MT);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MyAction(string submitButton, LocationViewModel lVM)
        {
            switch (submitButton)
            {
                case "Смонтировать":
                    // delegate sending to another controller action
                    return (MountSITOPosition(lVM));
                case "Демонтировать":
                    // call another action to perform the cancellation
                    return (DeMountSITOPosition(lVM));
                default:
                    // If they've submitted the form without a submitButton, 
                    // just return the view again.
                    return (View());
            }
        }

        
        public IActionResult MountSITOPosition(LocationViewModel lVM)
        {
            //if (lVM.His is null || lVM.His.MeashuringToolId is null || lVM.His.PositionId is null
            //   || _db.Histories.Where(h => h.MeashuringToolId == lVM.His.MeashuringToolId)
            //                   .OrderByDescending(h => h.DateTimeChange)
            //                   .FirstOrDefault()
            //                   .PositionId is not null
            //   || _db.Histories.Where(h => h.PositionId == lVM.His.PositionId)
            //                   .OrderByDescending(h => h.DateTimeChange)
            //                   .FirstOrDefault()
            //                   .MeashuringToolId is not null
            //   || _db.Histories.Where(h => h.PositionId == lVM.His.PositionId)
            //                   .OrderByDescending(h => h.DateTimeChange)
            //                   .FirstOrDefault().MeashuringToolId == lVM.His.MeashuringToolId)
            //{
            //    //Это ошибка    
            //}
            //else
            //{
                _db.Histories.Add(lVM.His);
                _db.SaveChanges();
           // }
            return RedirectToAction("Index");
        }

  
        public IActionResult DeMountSITOPosition(LocationViewModel lVM)
        {
            var hist = _db.Histories.Where(h => h.PositionId == lVM.His.PositionId)
                                .OrderByDescending(h => h.DateTimeChange)
                                .FirstOrDefault();
            if(hist is null 
                || hist.MeashuringToolId != lVM.His.MeashuringToolId 
                || hist.PositionId != lVM.His.PositionId)
            {
                //Это ошибка 
            }
            else
            {
                var HistPos = new History()
                {
                    PositionId = hist.PositionId,
                    DateTimeChange = DateTime.Now,
                    Comments = lVM.His.Comments,
                    StatusId = _db.Statuses.FirstOrDefault(s => s.NameStatus == "Демонтирован").Id

                };

                var HistMT = new History()
                {
                    MeashuringToolId = hist.MeashuringToolId,
                    DateTimeChange = DateTime.Now,
                    Comments = lVM.His.Comments,
                    StatusId = _db.Statuses.FirstOrDefault(s => s.NameStatus == "Демонтирован").Id

                };
                _db.Histories.Add(HistPos);
                _db.Histories.Add(HistMT);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
