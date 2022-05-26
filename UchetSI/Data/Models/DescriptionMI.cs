namespace UchetSI.Data.Models
{
    public class DescriptionMI
    {
        public int Id { get; set; }
        public int outputSignalId { get; set; }

        public int MeasurementLimitId { get; set; }
        public int VerificationIntervalId { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public int TypeOfEquipmentId { get; set; }
        public OutputSignal outputSignal { get; set; }

        public MeasurementLimit MeasurementLimit { get; set; }

        public VerificationInterval VerificationInterval { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        public TypeOfEquipment TypeOfEquipment { get; set; }

        public List<MeashuringTool> MeashuringTools { get; set; } = new List<MeashuringTool>();

    }
}
