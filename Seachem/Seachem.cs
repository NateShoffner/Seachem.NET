#region

using System;
using System.Collections.Generic;
using Seachem.Products.Gravel;
using Seachem.Products.Planted;
using Seachem.Products.Reef;

#endregion

namespace Seachem
{
    public class Seachem
    {
        /// <summary>
        ///     Get all Seachem products.
        /// </summary>
        /// <returns>Returns an array of products.</returns>
        public static ISeachemProduct[] GetProducts()
        {
            var products = new List<ISeachemProduct>();

            foreach (SeachemProductType type in Enum.GetValues(typeof (SeachemProductType)))
            {
                products.AddRange(GetProducts(type));
            }

            return products.ToArray();
        }

        /// <summary>
        ///     Get Seachem products by specific types.
        /// </summary>
        /// <param name="type">The product type.</param>
        /// <returns>Returns an array of products.</returns>
        public static ISeachemProduct[] GetProducts(SeachemProductType type)
        {
            switch (type)
            {
                case SeachemProductType.Gravel:
                    return new ISeachemProduct[]
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
                    };
                case SeachemProductType.Planted:
                    return new ISeachemProduct[]
                    {
                        new Equilibrium(),
                        new Iron(),
                        new Potassium(),
                        new Nitrogen(),
                        new Phosphorus(),
                        new AlkalineBuffer(),
                        new LiquidAlkalineBuffer()
                    };
                case SeachemProductType.Reef:
                    return new ISeachemProduct[]
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
                    };
            }

            return new ISeachemProduct[] {};
        }
    }
}