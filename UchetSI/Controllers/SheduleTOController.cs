using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UchetSI.Data.Models;
using UchetSI.ViewModels;

namespace UchetSI.Controllers
{
    public class SheduleTOController : Controller
    {
        private readonly ApplicationContext _db;


        public SheduleTOController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Location> org = _db.Locations.Where(or => or.TypeLocation.NameTypelocation == "Организация").ToList();
            List<Location> div = _db.Locations.Where(d => d.ParentId == org.FirstOrDefault().Id).ToList();
            List<Location> obj = _db.Locations.Where(ob => ob.ParentId == div.FirstOrDefault().Id).ToList();
            List<Location> subObj = _db.Locations.Where(s => s.ParentId == obj.FirstOrDefault().Id).ToList();
            List<TypeTO> typeTO = _db.TypeTOs.ToList();

            SelectList organization = new SelectList(org, "Id", "NameLocation");
            ViewBag.Organization = organization;

            SelectList division = new SelectList(div, "Id", "NameLocation");
            ViewBag.Division = division;

            SelectList objects = new SelectList(obj, "Id", "NameLocation");
            ViewBag.Objects = objects;

            SelectList types = new SelectList(typeTO, "Id", "NameTO");
            ViewBag.Types = types;


            //---------------
            SheduleViewModel SVM = new SheduleViewModel();
            SVM.STOList = new List<ScheduleTO>();
            SVM.HTO = new HoldingTO();

            for (int i = 0; i < 12; i++)
            {
                SVM.STOList.Add(new ScheduleTO()
                {
                    NumberMonth = i + 1
                });
            }

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTO(SheduleViewModel SVM)
        {
            //if (ModelState.IsValid)
            //{
            var HTO = _db.HoldingTOs.Add(SVM.HTO);
            _db.SaveChanges();
            int i = 0;
            foreach (var item in SVM.STOList)
            {
                item.NumberMonth = ++i;
                item.HoldingTOId = HTO.Entity.Id;
                _db.ScheduleTOs.Add(item);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
            //}
        }
        public ActionResult GetItem(int id)
        {
            return PartialView(_db.Locations.Where(l => l.ParentId == id).ToList());
        }

        public ActionResult Export()
        {

            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("Brands");

                // Merge a row
                //ws.Cell("B2").Value = "Merged Row(1) of Range (B2:D3)";
                //ws.Range("B2:D3").Row(1).Merge();

                //var HoldTO = _db.HoldingTOs.All();
                //var comps = _db.Companies.FromSqlRaw.ToList();

                worksheet.Cell(1,1).Value = "№ п/п";
                worksheet.Cell(1,2).Value = "Объект";
                worksheet.Cell(1,3).Value = "Период проведения";
                worksheet.Cell(1,4).Value = "Месяц";
                worksheet.Cell(1,4).Style.Alignment.WrapText = true;
                worksheet.Range("D1:O1").Row(1).Merge();
                worksheet.Row(1).Style.Font.Bold = true;

                //нумерация строк/ столбцов начинается с индекса 1(не 0)


                //foreach (var i in HoldTO)
                //{
                //    worksheet.Cell(i + 2, 1).Value = phoneBrands[i].Title;
                //    worksheet.Cell(i + 2, 2).Value = string.Join(", ", phoneBrands[i].PhoneModels.Select(x => x.Title));
                //}

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"ГрафикТО_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }
    }
}
