using Microsoft.AspNetCore.Mvc;
using UchetSI.Data.Interfaces;
using UchetSI.Data.Repositories;
using UchetSI.Data.Models;
using UchetSI.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace UchetSI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILocation _AllLocation;
        //private readonly ITypeLocation _AllTypeLocation;
        private readonly IFillTestData _AddInDb;

        private readonly ApplicationContext _db;


        public HomeController(/*ILocation iLocation, ITypeLocation iTypeLocation,*/ IFillTestData iFildTestData, ApplicationContext db)
        {
            //_AllLocation = iLocation;
            //_AllTypeLocation = iTypeLocation;
            _AddInDb = iFildTestData;
            _db = db;

        }


        public IActionResult Index()
        {

            //var Loc = _AllLocation.AllOrganization;
            //var div = _AllLocation.AllDivision;
            //LocationViewModel lvm= new LocationViewModel();
            //_AllLocation.AddTypeLocation();
            _AddInDb.FillingTestData();

            //lvm.GetTypeLocations = _AllTypeLocation.AllTypeLocations;
            //lvm.getOrganization = _AllLocation.AllOrganization;
            //lvm.getDivision = _AllLocation.AllDivision;

            //int indexOrganization = 1;
            //int indexSubdivision = 2;
            //int indexObjects = 4;



            var pos = _db.Positions.FirstOrDefault(p => p.NamePosition == "LKS48");

            //var v = _db.MeashuringTools.Select(mt => mt.Histories.Where(h => h.Position.Id == pos.Id)).OrderByDescending();
            //var mt = _db.Histories.Where(h => h.Position.Id == pos.Id).OrderByDescending(h => h.Id).FirstOrDefault().MeashuringTool;

            LoadViewBag();
            return View();

        }

        public IActionResult CreatePosition()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePosition(LocationViewModel obj)
        {
            //if (ModelState.IsValid)
            //{
                _db.Positions.Add(obj.Pos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            //}
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LocationViewModel obj)
        {
            //if (ModelState.IsValid)
            //{
            _db.Locations.Add(obj.Loc);
            //_db.Positions.Add(obj.Pos);
            _db.SaveChanges();
            //}
            LoadViewBag();
            return View();

        }



        private void LoadViewBag()
        {
            List<Location> org = _db.Locations.Where(or => or.TypeLocation.NameTypelocation == "Организация").ToList();
            List<Location> div = _db.Locations.Where(d => d.ParentId == org.FirstOrDefault().Id).ToList();
            List<Location> obj = _db.Locations.Where(ob => ob.ParentId == div.FirstOrDefault().Id).ToList();
            List<Location> subObj = _db.Locations.Where(s => s.ParentId == obj.FirstOrDefault().Id).ToList();
            List<Position> pos = _db.Positions.Where(p => p.LocationId == subObj.FirstOrDefault().Id).ToList();


            SelectList organization = new SelectList(org, "Id", "NameLocation");
            ViewBag.Organization = organization;
            SelectList division = new SelectList(div, "Id", "NameLocation");

            ViewBag.Division = division;
            SelectList objects = new SelectList(obj, "Id", "NameLocation");

            ViewBag.Objects = objects;
            SelectList subobjects = new SelectList(subObj, "Id", "NameLocation");

            ViewBag.Subobjects = subobjects;

            ViewBag.PositionList = pos;

        }

        public ActionResult GetItems(int id)
        {
            return PartialView(_db.Locations.Where(l => l.ParentId == id).ToList());
        }


        public ActionResult GetPosition(int id)
        {
            return PartialView(_db.Positions.Where(p => p.LocationId == id).ToList());
        }


    }
}