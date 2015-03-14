namespace Seachem
{
    /// <summary>
    ///     Represents a parameter.
    /// </summary>
    public class SeachemParameter
    {
        public SeachemParameter(string name, string unit)
        {
            Name = name;
            Unit = unit;
        }

        /// <summary>
        ///     Parameter name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Parameter measurement unit.
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        ///     Parameter value.
        /// </summary>
        public decimal Value { get; set; }
    }
}