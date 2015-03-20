namespace Seachem.Products.Gravel
{
    public class OnyxSand : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Onyx Sand"; }
        }

        public SeachemDosage[] CalculateDosage()
        {
            return CalculateDosage(260);
        }

        #endregion
    }
}