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
        public MeashuringTool MT { get; set; }

        public MeasurementLimit ML { get; set; }

        public DescriptionMI DMI { get; set; }
    }
}
