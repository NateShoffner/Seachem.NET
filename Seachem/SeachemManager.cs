#region

using System;
using System.Collections.Generic;
using System.Linq;
using Seachem.Products.Gravel;
using Seachem.Products.Planted;
using Seachem.Products.Reef;

#endregion

namespace Seachem
{
    public static class SeachemManager
    {
        /// <summary>
        ///     Get all Seachem products.
        /// </summary>
        /// <returns>Returns an array of products.</returns>
        public static ISeachemProduct[] GetProducts()
        {
            var flags = Enum.GetValues(typeof (SeachemProductType)).Cast<SeachemProductType>().
                Aggregate((SeachemProductType) 0, (current, type) => current | type);

            return GetProducts(flags);
        }

        /// <summary>
        ///     Get Seachem products by specific types.
        /// </summary>
        /// <param name="type">The product type.</param>
        /// <returns>Returns an array of products.</returns>
        public static ISeachemProduct[] GetProducts(SeachemProductType type)
        {
            var products = new List<ISeachemProduct>();

            if ((type & SeachemProductType.Gravel) == SeachemProductType.Gravel)
            {
                products.AddRange(new ISeachemProduct[]
                {
                    new Flourite(),
                    new FlouriteRed(),
                    new FlouriteDark(),
                    new FlouriteBlack(),
                    new FlouriteBlackSand(),
                    new OnyxSand(),
                    new Onyx(),
                    new GrayCoast(),
                    new KonaCoast(),
                    new Merdian(),
                    new PearlBeach(),
                    new SilverShores()
                });
            }

            if ((type & SeachemProductType.Planted) == SeachemProductType.Planted)
            {
                products.AddRange(new ISeachemProduct[]
                {
                    new Equilibrium(),
                    new Iron(),
                    new Potassium(),
                    new Nitrogen(),
                    new Phosphorus(),
                    new AlkalineBuffer(),
                    new LiquidAlkalineBuffer()
                });
            }

            if ((type & SeachemProductType.Reef) == SeachemProductType.Reef)
            {
                products.AddRange(new ISeachemProduct[]
                {
                    new ReefCalcium(),
                    new ReefAdvantageCalcium(),
                    new ReefComplete(),
                    new ReefBuffer(),
                    new ReefBuilder(),
                    new ReefCarbonate(),
                    new ReefIodide(),
                    new ReefStrontium(),
                    new ReefAdvantageStrontium(),
                    new ReefAdvantageMagnesium()
                });
            }

            return products.ToArray();
        }

        public static SeachemProductType[] GetProductTypes()
        {
            var types = Enum.GetValues(typeof (SeachemProductType));
            return types.OfType<SeachemProductType>().Select(o => o).ToArray();
        }
    }
}