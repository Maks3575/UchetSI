using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<Location> org = _db.Locations.Where(or => or.TypeLocation.NameTypelocation == "Организация").ToList();
            List<Location> div = _db.Locations.Where(d => d.ParentId == org.FirstOrDefault().Id).ToList();
            List<Location> obj = _db.Locations.Where(ob => ob.ParentId == div.FirstOrDefault().Id).ToList();
            List<Location> subObj = _db.Locations.Where(s => s.ParentId == obj.FirstOrDefault().Id).ToList();


            SelectList organization = new SelectList(org, "Id", "NameLocation");
            ViewBag.Organization = organization;

            SelectList division = new SelectList(div, "Id", "NameLocation");
            ViewBag.Division = division;

            SelectList objects = new SelectList(obj, "Id", "NameLocation");
            ViewBag.Objects = objects;


            TOViewModel model = new TOViewModel();
            var idObj = 5;
            var posList = _db.Positions.Where(p => p.Location.ParentId == idObj).ToList();
            var TOPVMList = posList.Select(p => GetTOPosition(p.Id)).Where(t => t.MT != null).ToList();
            if (TOPVMList is null || !TOPVMList.Any())
            {
                return View(model);
            }
            model.TOPVMs = TOPVMList;
            return View(model);
        }


        public IActionResult SearchResult(int id)
        {
            List<Location> org = _db.Locations.Where(or => or.TypeLocation.NameTypelocation == "Организация").ToList();
            List<Location> div = _db.Locations.Where(d => d.ParentId == org.FirstOrDefault().Id).ToList();
            List<Location> obj = _db.Locations.Where(ob => ob.ParentId == div.FirstOrDefault().Id).ToList();
            List<Location> subObj = _db.Locations.Where(s => s.ParentId == obj.FirstOrDefault().Id).ToList();


            SelectList organization = new SelectList(org, "Id", "NameLocation");
            ViewBag.Organization = organization;

            SelectList division = new SelectList(div, "Id", "NameLocation");
            ViewBag.Division = division;

            SelectList objects = new SelectList(obj, "Id", "NameLocation");
            ViewBag.Objects = objects;


            TOViewModel model = new TOViewModel();
            var idObj = id;
            var posList = _db.Positions.Where(p => p.Location.ParentId == idObj).ToList();
            var TOPVMList = posList.Select(p => GetTOPosition(p.Id)).Where(t => t.MT != null).ToList();
            if (TOPVMList is null || !TOPVMList.Any())
            {
                return View("Index", model);
            }
            model.TOPVMs = TOPVMList;
            return View("Index", model);
        }


        //public TOPositionViewModel GetTOPosition(int id)
        public IActionResult GetPVTOPosition(int id)
        {
            return PartialView("TOPosition", _db.Locations.Where(l => l.ParentId == id).ToList());
            //return PartialView("TOPosition");
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

        public ActionResult GetItem(int id)
        {
            return PartialView(_db.Locations.Where(l => l.ParentId == id).ToList());
        }

        public ActionResult Export()
        {

            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var ws = workbook.Worksheets.Add("OtchetTO");

                // Merge a row
                //ws.Cell("B2").Value = "Merged Row(1) of Range (B2:D3)";
                //ws.Range("B2:D3").Row(1).Merge();

                //var HoldTO = _db.HoldingTOs.All();
                //var comps = _db.Companies.FromSqlRaw.ToList();

                ws.Cell(3, 1).Value = "ОТЧЕТ";
                ws.Cell(3, 1).Style.Font.Bold = true;
                ws.Cell(3, 1).Style.Font.FontSize = 15;
                ws.Cell(3, 1).Style.Font.FontName = "Times New Roman";
                ws.Cell(3,1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(3,1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Range("A3:J3").Merge();
    

                ws.Cell(4, 1).Value = "о проведении технического обслуживания КИПиА и АСУТП технологического объекта СЦ 'Ярегаэнергонефть' УРУ ООО 'ЛУКОЙЛ-ЭНЕРГОСЕТИ' ";
                ws.Cell(4, 1).Style.Font.Bold = true;
                ws.Cell(4, 1).Style.Font.FontSize = 15;
                ws.Cell(4, 1).Style.Font.FontName = "Times New Roman";
                ws.Cell(4, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(4, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Range("A4:J4").Merge();

                ws.Cell(6, 2).Value = "         Объект:";
                ws.Cell(6, 2).Style.Font.Bold = true;
                ws.Cell(6, 2).Style.Font.FontSize = 11;
                ws.Cell(6, 2).Style.Font.FontName = "Times New Roman";
               //ws.Cell(6, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(6, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
    


                ws.Cell(6, 3).Value = "ПГУ '1'";
                ws.Cell(6, 3).Style.Font.Bold = true;
                ws.Cell(6, 3).Style.Font.FontSize = 9;
                ws.Cell(6, 3).Style.Font.FontName = "Times New Roman";
                //ws.Cell(6, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(6, 3).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(4, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(2).AdjustToContents();


                ws.Cell(7, 2).Value = "  Дата проведения:'";
                ws.Cell(7, 3).Value = "с   '01'     марта     2022 г.";
                ws.Cell(8, 3).Value = "по '25'     марта     2022 г.";
                ws.Cell(7, 3).Style.Font.FontSize = 11;
                ws.Cell(8, 3).Style.Font.FontSize = 11;
                ws.Cell(7, 2).Style.Font.FontName = "Times New Roman";
                //ws.Cell(6, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(7, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(7, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                ws.Cell(10, 1).Value = "№ п/п";
                ws.Cell(10, 1).Style.Font.Bold = true;
                ws.Cell(10, 1).Style.Font.FontSize = 10;
                ws.Cell(10, 1).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(1).AdjustToContents();
              

                ws.Cell(10, 2).Value = "Наименование средства измерений/ средства автоматизации";
                ws.Cell(10, 2).Style.Font.Bold = true;
                ws.Cell(10, 2).Style.Font.FontSize = 10;
                ws.Cell(10, 2).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(2).AdjustToContents();

                ws.Cell(10, 3).Value = "Контролируемый параметр, место установки";
                ws.Cell(10, 3).Style.Font.Bold = true;
                ws.Cell(10, 3).Style.Font.FontSize = 10;
                ws.Cell(10, 3).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 3).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 3).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(3).AdjustToContents();

                ws.Cell(10, 4).Value = "Позиция";
                ws.Cell(10, 4).Style.Font.Bold = true;
                ws.Cell(10, 4).Style.Font.FontSize = 10;
                ws.Cell(10, 4).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 4).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 4).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(4).AdjustToContents();

                ws.Cell(10, 5).Value = "Марка,тип";
                ws.Cell(10, 5).Style.Font.Bold = true;
                ws.Cell(10, 5).Style.Font.FontSize = 10;
                ws.Cell(10, 5).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(5).AdjustToContents();

                ws.Cell(10, 6).Value = "Серийный номер";
                ws.Cell(10, 6).Style.Font.Bold = true;
                ws.Cell(10, 6).Style.Font.FontSize = 10;
                ws.Cell(10, 6).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(6).AdjustToContents();

                ws.Cell(10, 7).Value = "Шкала Характеристика Тип сигнала";
                ws.Cell(10, 7).Style.Font.Bold = true;
                ws.Cell(10, 7).Style.Font.FontSize = 10;
                ws.Cell(10, 7).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(7).AdjustToContents();

                ws.Cell(10, 8).Value = "Вид ТО";
                ws.Cell(10, 8).Style.Font.Bold = true;
                ws.Cell(10, 8).Style.Font.FontSize = 10;
                ws.Cell(10, 8).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 8).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 8).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(8).AdjustToContents();

                ws.Cell(10, 9).Value = "Состояние оборудования";
                ws.Cell(10, 9).Style.Font.Bold = true;
                ws.Cell(10, 9).Style.Font.FontSize = 10;
                ws.Cell(10, 9).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 9).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 9).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(9).AdjustToContents();

                ws.Cell(10, 10).Value = "Год выпуска оборудования";
                ws.Cell(10, 10).Style.Font.Bold = true;
                ws.Cell(10, 10).Style.Font.FontSize = 10;
                ws.Cell(10, 10).Style.Font.FontName = "Times New Roman";
                ws.Cell(10, 10).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(10, 10).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Column(10).AdjustToContents();

                TOViewModel model = new TOViewModel();
                var idObj = 4;
                var posList = _db.Positions.Where(p => p.Location.ParentId == idObj).ToList();
                var TOPVMList = posList.Select(p => GetTOPosition(p.Id)).Where(t => t.MT != null).ToList();
                if (!(TOPVMList is null) || TOPVMList.Any())
                {
                    for (int i = 0; i < TOPVMList.Count; i++)
                    {
                      
                        ws.Cell(11 + i, 1).Value = i+1;
                        ws.Cell(11 + i, 1).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 1).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(1).AdjustToContents();
                        ws.Range("A10:J10").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        ws.Range("A10:J10").FirstColumn().Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                        ws.Range("A10:J10").LastColumn().Style.Border.RightBorder = XLBorderStyleValues.Thick;
                        ws.Range("A10:J10").FirstRow().Style.Border.TopBorder = XLBorderStyleValues.Thick;
                        ws.Range("A10:J10").LastRow().Style.Border.BottomBorder = XLBorderStyleValues.Thick;


                        ws.Cell(11 + i, 2).Value = TOPVMList[i].MT.DescriptionMI.TypeOfEquipment.DescriptionOfEquipment.NameDescription;
                        ws.Cell(11 + i, 2).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 2).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(2).AdjustToContents();

                        ws.Cell(11 + i, 3).Value = TOPVMList[i].Pos.NameParameter;
                        ws.Cell(11 + i, 3).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 3).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 3).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 3).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(3).AdjustToContents();

                        ws.Cell(11 + i, 4).Value = TOPVMList[i].Pos.NamePosition;
                        ws.Cell(11 + i, 4).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 4).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 4).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 4).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(4).AdjustToContents();

                        ws.Cell(11 + i, 5).Value = TOPVMList[i].MT.DescriptionMI.TypeOfEquipment.NameTypeOfEquipment;
                        ws.Cell(11 + i, 5).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 5).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(5).AdjustToContents();

                      

                        ws.Cell(11 + i, 6).Value = TOPVMList[i].MT.SerialNumber;
                        ws.Cell(11 + i, 6).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 6).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(6).AdjustToContents();

                        ws.Cell(11 + i, 7).Value = TOPVMList[i].MT.DescriptionMI.outputSignal.NameOutputSignal + ", " + TOPVMList[i].MT.DescriptionMI.MeasurementLimit.LowerLimit + "..." + TOPVMList[i].MT.DescriptionMI.MeasurementLimit.UpperLimit + TOPVMList[i].MT.DescriptionMI.UnitOfMeasurement.UnitName;
                        ws.Cell(11 + i, 7).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 7).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(7).AdjustToContents();

                        ws.Cell(11 + i, 8).Value = TOPVMList[i].TTO.NameTO;
                        ws.Cell(11 + i, 8).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 8).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 8).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 8).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(8).AdjustToContents();

                        ws.Cell(11 + i, 9).Value = TOPVMList[i].MT.StatusOfMT.NameStatus;
                        ws.Cell(11 + i, 9).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 9).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 9).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 9).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(10).AdjustToContents();

                        ws.Cell(11 + i, 10).Value = TOPVMList[i].MT.ReleaseDate.Year;
                        ws.Cell(11 + i, 10).Style.Font.FontSize = 10;
                        ws.Cell(11 + i, 10).Style.Font.FontName = "Times New Roman";
                        ws.Cell(11 + i, 10).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(11 + i, 10).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Column(11).AdjustToContents();


                    }
                }






                //worksheet.Cell(1, 4).Style.Alignment.WrapText = true;
                //worksheet.Range("D1:O1").Row(1).Merge();
                //worksheet.Row(1).Style.Font.Bold = true;

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
                        FileDownloadName = $"ОтчетТО_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }
    }
}
