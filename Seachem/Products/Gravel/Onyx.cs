namespace Seachem.Products.Gravel
{
    public class Onyx : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Onyx"; }
        }

        public SeachemDosage[] CalculateDosage()
        {
            return CalculateDosage(425);
        }

        #endregion
    }
}