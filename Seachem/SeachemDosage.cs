namespace Seachem
{
    /// <summary>
    ///     Represents a dosage.
    /// </summary>
    public class SeachemDosage
    {
        public SeachemDosage(string unit, decimal value)
        {
            Unit = unit;
            Value = value;
        }

        /// <summary>
        ///     The dosage unit.
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        ///     The dosage amount.
        /// </summary>
        public decimal Value { get; private set; }
    }
}