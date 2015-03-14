#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Reef
{
    public class ReefAdvantageStrontium : ISeachemProduct
    {
        public ReefAdvantageStrontium()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Strontium", "mg/L (ppm)"),
                new SeachemParameter("Desired Strontium", "mg/L (ppm)")
            }.ToArray();

            Comment = "Considerations: We recommend a strontium level between 8-12 mg/L. It is advisable to make large adjustments slowly to avoid overshooting intended level. Excess strontium  may enhance the loss of carbonate alkalinity. Do not directly mix with any carbonate supplement.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Reef Advantage Strontium"; }
        }

        public SeachemParameter[] Parameters { get; private set; }
        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = volume*(desired - current)/(decimal) 7.500000;
            var doseA = doseB/8;
            doseA = Math.Round(doseA*10)/10;
            doseB = Math.Round(doseB*10)/10;

            return new List<SeachemDosage>
            {
                new SeachemDosage("Tspns", doseA),
                new SeachemDosage("g", doseB)
            }.ToArray();
        }

        #endregion
    }
}