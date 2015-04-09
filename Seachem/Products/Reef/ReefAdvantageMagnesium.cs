#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Reef
{
    public class ReefAdvantageMagnesium : ISeachemProduct
    {
        public ReefAdvantageMagnesium()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Magnesium", "mg/L (ppm)"),
                new SeachemParameter("Desired Magnesium", "mg/L (ppm)")
            }.ToArray();

            Comment = "Considerations: We recommend a magnesium  level between 1200-1350 mg/L. Make large adjustments slowly to avoid overshooting intended level. Amount or frequency can be adjusted, but do not exceed 25 g/80 L per day. Dissolve in at least one cup of freshwater. Excess magnesium may enhance the loss of carbonate alkalinity. Do not directly mix with any carbonate supplement.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Reef Advantage Magnesium"; }
        }

        public SeachemParameter[] Parameters { get; private set; }
        public string Comment { get; private set; }

        public SeachemDosage[] Calculate()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseA = (decimal) 0.009500*volume*(desired - current);
            var doseB = doseA*5;
            doseA = Math.Round(doseA*10)/10;
            doseB = Math.Round(doseB*10)/10;

            return new List<SeachemDosage>
            {
                new SeachemDosage("Tspns", doseA),
                new SeachemDosage("Grams", doseB)
            }.ToArray();
        }

        #endregion
    }
}