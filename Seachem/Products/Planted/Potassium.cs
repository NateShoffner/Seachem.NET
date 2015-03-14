#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Planted
{
    public class Potassium : ISeachemProduct
    {
        public Potassium()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Potassium", "mg/L (ppm)"),
                new SeachemParameter("Desired Potassium", "mg/L (ppm)")
            }.ToArray();

            Comment = "Considerations: Repeat - 2-3 times per week or as needed (in response to signs of potassium deficiency in older leaves which includes: chlorosis (yellowing), necrossis (death/browning), and weak stems and roots.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Flourish Potassium"; }
        }

        public SeachemParameter[] Parameters { get; private set; }

        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = volume/30*((desired - current)*(decimal) 2.500000);
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