namespace Seachem.Products.Gravel
{
    public class Merdian : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Merdian"; }
        }

        public SeachemDosage[] Calculate()
        {
            return Calculate(320);
        }

        #endregion
    }
}