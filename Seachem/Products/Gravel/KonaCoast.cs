namespace Seachem.Products.Gravel
{
    public class KonaCoast : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Kona Coast"; }
        }

        public SeachemDosage[] Calculate()
        {
            return Calculate(366);
        }

        #endregion
    }
}