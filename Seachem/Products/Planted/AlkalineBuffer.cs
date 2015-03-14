#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Planted
{
    public class AlkalineBuffer : ISeachemProduct
    {
        public AlkalineBuffer()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current KH", "meq/L"),
                new SeachemParameter("Desired KH", "meq/L")
            }.ToArray();

            Comment = "Considerations: 2 meq/L is equal to  5.6 dKH. If your test kit measures in dKH, divide your test kit reading by 2.8 to determine your current KH levels in meq/L. Do the same for desired KH.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Alkaline Buffer"; }
        }

        public SeachemParameter[] Parameters { get; private set; }

        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = (desired - current)*(decimal) 3.500000*(volume/10);
            var doseA = doseB/7;
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