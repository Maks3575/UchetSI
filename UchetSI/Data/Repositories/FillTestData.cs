using UchetSI.Data.Interfaces;
using UchetSI.Data.Models;

namespace UchetSI.Data.Repositories
{
    public class FillTestData : IFillTestData
    {
        private readonly ApplicationContext _context;

        public FillTestData(ApplicationContext context)
        {
            _context = context;
        }

        public void FillingTestData()
        {

            _context.TypeLocations.Add(new TypeLocation { NameTypelocation = "Организация" });
            _context.TypeLocations.Add(new TypeLocation { NameTypelocation = "Подразделение" });
            _context.TypeLocations.Add(new TypeLocation { NameTypelocation = "Объект" });
            _context.TypeLocations.Add(new TypeLocation { NameTypelocation = "Подобъект" });

            _context.Statuses.Add(new Status { NameStatus = "Устанолен" });
            _context.Statuses.Add(new Status { NameStatus = "Демонтирован" });

            _context.StatusOfMTs.Add(new StatusOfMT { NameStatus = "Исправен" });
            _context.StatusOfMTs.Add(new StatusOfMT { NameStatus = "Неисправен" });
            _context.StatusOfMTs.Add(new StatusOfMT { NameStatus = "Демонтирован" });

            _context.UnitOfMeasurements.Add(new UnitOfMeasurement { UnitName = "МПа" });
            _context.UnitOfMeasurements.Add(new UnitOfMeasurement { UnitName = "С" });
            _context.UnitOfMeasurements.Add(new UnitOfMeasurement { UnitName = "т/ч" });
            _context.UnitOfMeasurements.Add(new UnitOfMeasurement { UnitName = "м3/ч" });
            _context.UnitOfMeasurements.Add(new UnitOfMeasurement { UnitName = "мм" });

            _context.VerificationInterval.Add(new VerificationInterval { Interval = 6 });
            _context.VerificationInterval.Add(new VerificationInterval { Interval = 12 });
            _context.VerificationInterval.Add(new VerificationInterval { Interval = 24 });
            _context.VerificationInterval.Add(new VerificationInterval { Interval = 36 });
            _context.VerificationInterval.Add(new VerificationInterval { Interval = 48 });

            _context.OutputSignals.Add(new OutputSignal { NameOutputSignal = "4-20 мА" });
            _context.OutputSignals.Add(new OutputSignal { NameOutputSignal = "0-20 мА" });
            _context.OutputSignals.Add(new OutputSignal { NameOutputSignal = "0-1000 Ггц" });
            _context.OutputSignals.Add(new OutputSignal { NameOutputSignal = "0-5 В" });

            _context.MeasurementLimits.Add(new MeasurementLimit { LowerLimit = 0, UpperLimit = 1 });
            _context.MeasurementLimits.Add(new MeasurementLimit { LowerLimit = 0, UpperLimit = 6 });
            _context.MeasurementLimits.Add(new MeasurementLimit { LowerLimit = 0, UpperLimit = 1.6F });
            _context.MeasurementLimits.Add(new MeasurementLimit { LowerLimit = 0, UpperLimit = 2000 });
            _context.MeasurementLimits.Add(new MeasurementLimit { LowerLimit = -50, UpperLimit = 150 });
            _context.MeasurementLimits.Add(new MeasurementLimit { LowerLimit = 0, UpperLimit = 300 });

            _context.Makers.Add(new Maker { NameMaker = "ЗАО 'ЭМИС'" });
            _context.Makers.Add(new Maker { NameMaker = "ООО 'Элемер'" });
            _context.Makers.Add(new Maker { NameMaker = "ООО 'Метран'" });
            _context.Makers.Add(new Maker { NameMaker = "ENDRESS+HAUSER" });

            _context.DescriptionOfEquipments.Add(new DescriptionOfEquipment { NameDescription = "Преобразователь расхода вихревой" });
            _context.DescriptionOfEquipments.Add(new DescriptionOfEquipment { NameDescription = "Преобразователь температуры" });
            _context.DescriptionOfEquipments.Add(new DescriptionOfEquipment { NameDescription = "Преобразователь давления" });
            _context.DescriptionOfEquipments.Add(new DescriptionOfEquipment { NameDescription = "Преобразователь уровня" });


            _context.SaveChanges();

            ////////////////////////////////////////////////////////////////////////////////////////////////




            _context.TypeOfEquipments.Add(new TypeOfEquipment { NameTypeOfEquipment = "ЭМИС-ВИХРЬ 200", MakerId = 1, DescriptionOfEquipmentId = 1 });
            _context.TypeOfEquipments.Add(new TypeOfEquipment { NameTypeOfEquipment = "TMT142R", MakerId = 4, DescriptionOfEquipmentId = 2 });
            _context.TypeOfEquipments.Add(new TypeOfEquipment { NameTypeOfEquipment = "Метран-286-23", MakerId = 3, DescriptionOfEquipmentId = 2 });
            _context.TypeOfEquipments.Add(new TypeOfEquipment { NameTypeOfEquipment = "Метран 150", MakerId = 3, DescriptionOfEquipmentId = 3 });
            _context.TypeOfEquipments.Add(new TypeOfEquipment { NameTypeOfEquipment = "PMP55-2DRK1", MakerId = 4, DescriptionOfEquipmentId = 3 });


            _context.Locations.Add(new Location { NameLocation = "СЦ Ярегаэнергонефть", ParentId = null, TypeLocationId = 1 });
            _context.Locations.Add(new Location { NameLocation = "Котельная НШ-1", ParentId = 1, TypeLocationId = 2 });
            _context.Locations.Add(new Location { NameLocation = "ПГУ Север", ParentId = 1, TypeLocationId = 2 });
            _context.Locations.Add(new Location { NameLocation = "ПГУ 1", ParentId = 2, TypeLocationId = 3 });
            _context.Locations.Add(new Location { NameLocation = "ПГУ 2", ParentId = 2, TypeLocationId = 3 });
            _context.Locations.Add(new Location { NameLocation = "Площадка", ParentId = 3, TypeLocationId = 3 });
            _context.Locations.Add(new Location { NameLocation = "РВС", ParentId = 4, TypeLocationId = 4 });
            _context.Locations.Add(new Location { NameLocation = "Дренажная ёмкость", ParentId = 4, TypeLocationId = 4 });
            _context.Locations.Add(new Location { NameLocation = "Узел учёта воды", ParentId = 5, TypeLocationId = 4 });
            _context.Locations.Add(new Location { NameLocation = "Блок укрытия горелок", ParentId = 5, TypeLocationId = 4 });
            _context.Locations.Add(new Location { NameLocation = "ТМ-блокр", ParentId = 6, TypeLocationId = 4 });
            _context.Locations.Add(new Location { NameLocation = "ПК 1", ParentId = 6, TypeLocationId = 4 });

            _context.SaveChanges();



            ///////////////////////////////////////////////////////////

            _context.Positions.Add(new Position { NamePosition = "LT311", LocationId = 7, NameParameter = "Уровень воды в деаэраторе", Paz = true });
            _context.Positions.Add(new Position { NamePosition = "TT311", LocationId = 7, NameParameter = "Температура в деаэраторе", Paz = true });
            _context.Positions.Add(new Position { NamePosition = "PT311", LocationId = 8, NameParameter = "Давление в деаэраторе", Paz = true });
            _context.Positions.Add(new Position { NamePosition = "PT310", LocationId = 8, NameParameter = "Давление пара на деаэратор", Paz = true });
            _context.Positions.Add(new Position { NamePosition = "FT100", LocationId = 8, NameParameter = "Расход воды с ВПУ-700", Paz = false });

            _context.DescriptionMIs.Add(new DescriptionMI { outputSignalId = 3, MeasurementLimitId = 6, VerificationIntervalId = 3, UnitOfMeasurementId = 3, TypeOfEquipmentId = 1 });
            _context.DescriptionMIs.Add(new DescriptionMI { outputSignalId = 2, MeasurementLimitId = 2, VerificationIntervalId = 4, UnitOfMeasurementId = 4, TypeOfEquipmentId = 2 });

            _context.SaveChanges();

            ///////////////////////////////////////////////////////////////

            _context.MeashuringTools.Add(new MeashuringTool { SerialNumber = "17942", ReleaseDate = new DateTime(2017, 7, 20), PassportNumber = "g543g255", DescriptionMIId = 1, StatusOfMTId = 1 });
            _context.MeashuringTools.Add(new MeashuringTool { SerialNumber = "56365", ReleaseDate = new DateTime(2020, 5, 30), PassportNumber = "g543g255", DescriptionMIId = 2, StatusOfMTId = 1 });

            _context.SaveChanges();

            ////////////////////////////////////////////////////////////

            _context.Histories.Add(new History { DateTimeChange = new DateTime(2022, 5, 20), PositionId = 1, StatusId = 1, MeashuringToolId = 1, Comments = "Комент1" });
            _context.Histories.Add(new History { DateTimeChange = new DateTime(2022, 6, 20), PositionId = 2, StatusId = 1, MeashuringToolId = 2, Comments = "Комент2" });

            _context.SaveChanges();
        }



    }
}
