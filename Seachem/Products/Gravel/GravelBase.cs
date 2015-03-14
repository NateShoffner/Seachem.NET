#region

using System.Collections.Generic;

#endregion

namespace Seachem.Products.Gravel
{
    public abstract class GravelBase
    {
        protected GravelBase()
        {
            Parameters = new List<SeachemParameter>
            {
                new SeachemParameter("Aquarium Width", "in"),
                new SeachemParameter("Aquarium Length", "in"),
                new SeachemParameter("Desired Substrate Depth", "in")
            }.ToArray();

            Comment = "If you plan on varying the depth of your substrate, use an average depth as your desired substrate depth.";
        }

        public string Comment { get; private set; }
        public SeachemParameter[] Parameters { get; private set; }
    }
}