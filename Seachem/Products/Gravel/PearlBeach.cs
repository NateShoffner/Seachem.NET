#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Gravel
{
    public class PearlBeach : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Pearl Beach"; }
        }

        public SeachemDosage[] CalculateDosage()
        {
            var width = Parameters[0].Value;
            var length = Parameters[0].Value;
            var depth = Parameters[0].Value;

            var total = Math.Ceiling(width*length*depth/525);

            return new List<SeachemDosage>
            {
                new SeachemDosage("Bags", total)
            }.ToArray();
        }

        #endregion
    }
}