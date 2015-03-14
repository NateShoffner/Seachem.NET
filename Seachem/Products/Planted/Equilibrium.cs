#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Planted
{
    public class Equilibrium : ISeachemProduct
    {
        public Equilibrium()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Volume", "US Gallons"),
                new SeachemParameter("Current GH", "meq/L"),
                new SeachemParameter("Desired GH", "meq/L")
            }.ToArray();

            Comment = "Considerations: Equilibrium™ can be added straight, although for optimum solubility we recommend mixing with ~ 1 L (1 qt.) of water (the resulting mixture will have a white opaque appearance). When this mixture is added to the aquarium it will impart a slight haze that should clear within 15–30 minutes.";
        }

        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Equilibrium"; }
        }

        public SeachemParameter[] Parameters { get; private set; }

        public string Comment { get; private set; }

        public SeachemDosage[] CalculateDosage()
        {
            var volume = Parameters[0].Value;
            var current = Parameters[1].Value;
            var desired = Parameters[2].Value;

            var doseB = volume/20*(16*(desired - current));
            var doseA = doseB/16;
            doseA = Math.Round(doseA*10)/10;
            doseB = Math.Round(doseB*10)/10;

            return new List<SeachemDosage>
            {
                new SeachemDosage("Tablespoons", doseA),
                new SeachemDosage("Grams", doseB)
            }.ToArray();
        }

        #endregion
    }
}