#region

using System;
using System.Reflection;
using System.Windows.Forms;
using Seachem;

#endregion

namespace DemoCalculator
{
    public partial class MainForm : Form
    {
        private ISeachemProduct[] _products;

        public MainForm()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            PopulateTypes();
            PopulateProducts();
        }

        private void PopulateTypes()
        {
            foreach (SeachemProductType type in Enum.GetValues(typeof (SeachemProductType)))
            {
                listTypes.Items.Add(type.ToString());
            }

            listTypes.SelectedIndex = 0;
        }

        private void PopulateProducts()
        {
            var type = (SeachemProductType) listTypes.SelectedIndex;
            _products = Seachem.Seachem.GetProducts(type);

            listProducts.Items.Clear();

            foreach (var product in _products)
            {
                listProducts.Items.Add(product.Name);
            }

            listProducts.SelectedIndex = 0;
        }

        private ISeachemProduct GetSelectedProduct()
        {
            return _products[listProducts.SelectedIndex];
        }

        private void listProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            productControl1.LoadProduct(GetSelectedProduct());
        }

        private void listTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProducts();
        }
    }
}