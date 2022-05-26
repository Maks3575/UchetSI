using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UchetSI.Data.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string NamePosition { get; set; }
        public bool Paz { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string NameParameter { get; set; }
        public List<History> Histories { get; set; }

    }
}
