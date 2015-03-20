namespace Seachem.Products.Gravel
{
    public class KonaCoast : GravelBase, ISeachemProduct
    {
        #region Implementation of ISeachemProduct

        public string Name
        {
            get { return "Kona Coast"; }
        }

        public SeachemDosage[] CalculateDosage()
        {
            return CalculateDosage(366);
        }

        #endregion
    }
}