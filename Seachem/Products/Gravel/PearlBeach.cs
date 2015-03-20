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
            return CalculateDosage(525);
        }

        #endregion
    }
}