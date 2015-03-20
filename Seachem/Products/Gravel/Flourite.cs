namespace Seachem.Products.Gravel
{
    public class Flourite : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Flourite"; }
        }

        public SeachemDosage[] Calculate()
        {
            return Calculate(425);
        }

        #endregion
    }
}