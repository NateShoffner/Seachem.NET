namespace Seachem
{
    /// <summary>
    ///     Represents a dosage.
    /// </summary>
    public class SeachemDosage
    {
        public SeachemDosage(string unit, decimal amount)
        {
            Unit = unit;
            Amount = amount;
        }

        /// <summary>
        ///     The dosage unit.
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        ///     The dosage amount.
        /// </summary>
        public decimal Amount { get; private set; }
    }
}