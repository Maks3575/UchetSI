using System.ComponentModel.DataAnnotations;

namespace UchetSI.Data.Models
{
    public class MeashuringTool
    {
        public int Id { get; set; }
        
        public string SerialNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        public string PassportNumber { get; set; }

        public List<History> Histories { get; set; } = new List<History>();

        public int DescriptionMIId { get; set; }

        public DescriptionMI DescriptionMI { get; set; }

        public int StatusOfMTId { get; set; }
        public StatusOfMT StatusOfMT { get; set; }

    }
}
