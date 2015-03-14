#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Reef
{
    public class ReefCarbonate : ISeachemProduct
    {
        public ReefCarbonate()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Alkalinity", "meq/L"),
                new SeachemParameter("Desired Alkalinity", "meq/L")
            }.ToArray();

            Comment = "Considerations: Reef alkalinity should ideally be maintained at 4-5 meq/L (11-17 dKH). It is advisable to make large adjustments slowly to avoid overshooting intended level or shocking  corals and inverts. Each dose will raise alkalinity by about 0.25 meq/L. Size or frequency of dose can be adjusted, but do not exceed 1 meq/L per day.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Reef Carbonate"; }
        }

        public SeachemParameter[] Parameters { get; private set; }
        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseA = (desired - current)/(decimal) 0.250000*(volume/20);
            var doseB = doseA*5;
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