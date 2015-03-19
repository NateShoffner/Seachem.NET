#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Planted
{
    public class Nitrogen : ISeachemProduct
    {
        public Nitrogen()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Nitrogen", "meq/L"),
                new SeachemParameter("Desired Nitrogen", "meq/L")
            }.ToArray();

            Comment = "Considerations: If using a \"nitrate equivalent\" value for Current and Desired Nitrogen levels, divide the result by 5.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Flourish Nitrogen"; }
        }

        public SeachemParameter[] Parameters { get; private set; }

        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = (desired - current)*(volume*(decimal) 0.250000);
            var doseA = doseB/Constants.CapmL;
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