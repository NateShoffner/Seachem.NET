#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Reef
{
    public class ReefBuffer : ISeachemProduct
    {
        public ReefBuffer()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current Alkalinity", "meq/L"),
                new SeachemParameter("Desired Alkalinity", "meq/L")
            }.ToArray();

            Comment = "Considerations: Reef alkalinity should ideally be maintained at 4-5 meq/L (11-14 dKH).  Reef Buffer™ will raise carbonate alkalinity; however, it is intended primarily for use as a buffer in a reef system where the maintenance of a pH of 8.3 is often difficult. When pH is not an issue, try  Reef Builder™ or Reef Carbonate™";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Reef Buffer"; }
        }

        public SeachemParameter[] Parameters { get; private set; }
        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseA = (desired - current)/(decimal) 0.500000*(volume/40);
            var doseB = doseA*5;
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