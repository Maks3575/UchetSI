using Microsoft.Extensions.DependencyInjection;
using UchetSI.Data.Models;

namespace UchetSI.Data
{
    public class DBObjects
    {
        //public static void Initial(IApplicationBuilder content)
        //{

        //    if (!content.TypeLocations.Any())
        //    {
        //        content.TypeLocations.AddRange(TypeLocations.Select(t => t.Value));
        //    }

        //    if (!content.Locations.Any())
        //    {
        //        content.Locations.AddRange(

        //        new Location { 
        //            NameLocation = "СЦ Ярегаэнергонефть",
        //            ParentId = null,
        //            TypeLocation = TypeLocations["Организация"]
        //        },

        //        new Location { 
        //            NameLocation = "Котельная НШ-1",
        //            ParentId = 1,
        //            TypeLocation = TypeLocations["Подразделение"]
        //        },

        //        new Location {
        //            NameLocation = "ПГУ Север",
        //            ParentId = 1,
        //            TypeLocation = TypeLocations["Подразделение"]
        //        },
        //        new Location {
        //            NameLocation = "ПГУ 1",
        //            ParentId = 2,
        //            TypeLocation = TypeLocations["Объект"]
        //        },
        //        new Location { 
        //            NameLocation = "ПГУ 2",
        //            ParentId = 2,
        //            TypeLocation = TypeLocations["Объект"]
        //        },
        //        new Location {
        //            NameLocation = "Площадка",
        //            ParentId = 3,
        //            TypeLocation = TypeLocations["Объект"]
        //        },
        //        new Location {
        //            NameLocation = "РВС",
        //            ParentId = 4,
        //            TypeLocation = TypeLocations["Подобъект"]
        //        },
        //        new Location
        //        {
        //            NameLocation = "Дренажная ёмкость",
        //            ParentId = 4,
        //            TypeLocation = TypeLocations["Подобъект"]
        //        },
        //        new Location {
        //            NameLocation = "Узел учёта воды",
        //            ParentId = 5,
        //            TypeLocation = TypeLocations["Подобъект"]
        //        },
        //        new Location {
        //            NameLocation = "Блок укрытия горелок",
        //            ParentId = 5,
        //            TypeLocation = TypeLocations["Подобъект"]
        //        },
        //        new Location {
        //            NameLocation = "ТМ-блокр",
        //            ParentId = 6,
        //            TypeLocation = TypeLocations["Подобъект"]
        //        },
        //        new Location {
        //            NameLocation = "ПК 1",
        //            ParentId = 6,
        //            TypeLocation = TypeLocations["Подобъект"]
        //        }
        //        );
        //    }
        //}
        //private static Dictionary<string, TypeLocation> typelocation;
        //public static Dictionary<string, TypeLocation> TypeLocations
        //{
        //    get
        //    {
        //        if (typelocation == null)
        //        {
        //            var list = new TypeLocation[]
        //            {
        //                new TypeLocation { NameTypelocation = "Организация" },
        //                new TypeLocation { NameTypelocation = "Подразделение" },
        //                new TypeLocation { NameTypelocation = "Объект" },
        //                new TypeLocation { NameTypelocation = "Подобъект" }
        //            };

        //            typelocation = new Dictionary<string, TypeLocation>();
        //            foreach (TypeLocation el in list)
        //                typelocation.Add(el.NameTypelocation, el);
        //        }
        //        return typelocation;
        //    }
        //}
    }
}
