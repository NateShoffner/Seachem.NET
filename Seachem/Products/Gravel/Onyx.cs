namespace Seachem.Products.Gravel
{
    public class Onyx : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Onyx"; }
        }

        public SeachemDosage[] Calculate()
        {
            return Calculate(425);
        }

        #endregion
    }
}