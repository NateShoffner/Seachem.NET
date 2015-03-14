#region

using System;
using System.Collections.Generic;

#endregion

namespace Seachem.Products.Gravel
{
    public class GrayCoast : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Gray Coast"; }
        }

        public SeachemDosage[] CalculateDosage()
        {
            var width = Parameters[0].Value;
            var length = Parameters[0].Value;
            var depth = Parameters[0].Value;

            var total = Math.Ceiling(width*length*depth/260);

            return new List<SeachemDosage>
            {
                new SeachemDosage("Bags", total)
            }.ToArray();
        }

        #endregion
    }
}