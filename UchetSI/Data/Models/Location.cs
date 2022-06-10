using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UchetSI.Data.Models;

namespace UchetSI.Data.Models
{
    public class Location
    {   
 
        public int Id { get; set; }

        public string NameLocation { get; set; }

        public int? ParentId { get; set; }
        public Location? Parent { get; set; }
        public List<Location> Children { get; set; } = new List<Location>();

        public int TypeLocationId { get; set; }
        public TypeLocation? TypeLocation { get; set; }

        public List<Position>? Positions { get; set; }
        public List<HoldingTO>? HoldingTOs { get; set; }



    }
}
