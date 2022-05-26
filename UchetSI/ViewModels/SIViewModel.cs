using System.Web.Mvc;
using UchetSI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using UchetSI.Data.Interfaces;
using UchetSI.Data.Repositories;
using UchetSI.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UchetSI.ViewModels
{
    public class SIViewModel
    {
        public IEnumerable<MeashuringTool> MT { get; set; }
        public IEnumerable<MeasurementLimit> ML { get; set; }
        public IEnumerable<TypeOfEquipment> TOE { get; set; }
        public IEnumerable<DescriptionOfEquipment> DOE { get; set; }
        public IEnumerable<DescriptionMI> DM { get; set; }
        public IEnumerable<UnitOfMeasurement> UOM { get; set; }
        public IEnumerable<VerificationInterval> VI { get; set; }
        public IEnumerable<OutputSignal> OS { get; set; }
        public IEnumerable<History> H { get; set; }
        public IEnumerable<Status> S { get; set; }
    }
}
