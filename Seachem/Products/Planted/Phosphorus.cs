#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Planted
{
    public class Phosphorus : ISeachemProduct
    {
        public Phosphorus()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Phosphorus", "mg/L (ppm)"),
                new SeachemParameter("Desired Phosphorus", "mg/L (ppm)")
            }.ToArray();

            Comment = "Considerations: Use once or twice a week or as needed in response to signs of phosphorus deficiency (e.g. stunted growth, plant dark green). The ideal phosphate level will vary, but generally ranges from 0.15–1.0 mg/L. Use MultiTest: Phosphate™ to monitor phosphate levels.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Flourish Phosphorus"; }
        }

        public SeachemParameter[] Parameters { get; private set; }

        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = volume/20*((desired - current)*(decimal) 16.600000);
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