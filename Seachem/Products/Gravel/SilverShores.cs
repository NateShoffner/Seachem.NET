namespace Seachem.Products.Gravel
{
    public class SilverShores : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Silver Shores"; }
        }

        public SeachemDosage[] Calculate()
        {
            return Calculate(458);
        }

        #endregion
    }
}