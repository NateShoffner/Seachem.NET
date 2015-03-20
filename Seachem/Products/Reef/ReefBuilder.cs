#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Reef
{
    public class ReefBuilder : ISeachemProduct
    {
        public ReefBuilder()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Alkalinity", "meq/L"),
                new SeachemParameter("Desired Alkalinity", "meq/L")
            }.ToArray();

            Comment = "Considerations: Reef alkalinity should ideally be maintained at 4-5 meq/L (11-17 dKH). Alkalinity should not be allowed to fall below  2 meq/L. It is advisable to make large adjustments slowly to avoid overshooting intended level or shocking  corals and inverts. Dissolve in at least one cup of freshwater. Do not exceed 12 g/150 L per day.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Reef Builder"; }
        }

        public SeachemParameter[] Parameters { get; private set; }
        public string Comment { get; private set; }

        public SeachemDosage[] Calculate()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = (decimal) 0.320000*(volume*(desired - current));
            var doseA = doseB/6;
            doseA = Math.Round(doseA*10)/10;
            doseB = Math.Round(doseB*10)/10;

            return new List<SeachemDosage>()
            {
                new SeachemDosage("Tspns", doseA),
                new SeachemDosage("g", doseB)
            }.ToArray();
        }

        #endregion
    }
}