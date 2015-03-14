#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Reef
{
    public class ReefIodide : ISeachemProduct
    {
        public ReefIodide()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Iodide", "mg/L (ppm)"),
                new SeachemParameter("Desired Iodide", "mg/L (ppm)")
            }.ToArray();

            Comment = "Considerations: If necessary, adjust amount so that iodide reads 0.06–0.08 mg/L 6–12 hours after the last dose. Natural seawater has an iodine concentration of .06 mg/L; however, many corals and crustaceans can benefit from a slightly higher concentration. Make large adjustments slowly to avoid overshooting intended level.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Reef Iodide"; }
        }

        public SeachemParameter[] Parameters { get; private set; }
        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = (decimal) 0.500000*volume*(desired - current);
            var doseA = doseB/5;
            doseA = Math.Round(doseA*10)/10;
            doseB = Math.Round(doseB*10)/10;

            return new List<SeachemDosage>
            {
                new SeachemDosage("Caps", doseA),
                new SeachemDosage("mL", doseB)
            }.ToArray();
        }

        #endregion
    }
}