namespace Seachem.Products.Gravel
{
    public class GrayCoast : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Gray Coast"; }
        }

        public SeachemDosage[] Calculate()
        {
            return Calculate(260);
        }

        #endregion
    }
}