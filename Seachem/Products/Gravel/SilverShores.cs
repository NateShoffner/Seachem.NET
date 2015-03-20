namespace Seachem.Products.Gravel
{
    public class SilverShores : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Silver Shores"; }
        }

        public SeachemDosage[] CalculateDosage()
        {
            return CalculateDosage(458);
        }

        #endregion
    }
}