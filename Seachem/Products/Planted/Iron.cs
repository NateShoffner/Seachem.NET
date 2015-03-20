#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Planted
{
    public class Iron : ISeachemProduct
    {
        public Iron()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Iron", "mg/L (ppm)"),
                new SeachemParameter("Desired Iron", "mg/L (ppm)")
            }.ToArray();

            Comment = "Considerations: We recommend maintaining an Fe level of about 0.10 mg/L. Iron is used quickly, so you will want to initially exceed 0.10 mg/L in order to prevent iron levels from falling below that level. For smaller doses, please note that each cap thread is about 1 mL";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Flourish Iron"; }
        }

        public SeachemParameter[] Parameters { get; private set; }

        public string Comment { get; private set; }

        public SeachemDosage[] Calculate()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = volume/50*((desired - current)*20);
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