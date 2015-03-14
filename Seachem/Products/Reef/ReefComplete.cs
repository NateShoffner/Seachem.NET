#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Reef
{
    public class ReefComplete : ISeachemProduct
    {
        public ReefComplete()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Calcium", "mg/L (ppm)"),
                new SeachemParameter("Desired Calcium", "mg/L (ppm)")
            }.ToArray();

            Comment = "Considerations: We recommend a Ca level between 380-420 mg/L with an alkalinity between 4-6 meq/L. It is advisable to make large adjustments slowly to avoid overshooting intended level or shocking  corals and inverts. Each capful will raise calcium by about 10 mg/L. Size or frequency of amount added can be adjusted, but do not exceed 25 mg/L per day.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Reef Complete"; }
        }

        public SeachemParameter[] Parameters { get; private set; }
        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = (decimal) 0.025000*volume*(desired - current);
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