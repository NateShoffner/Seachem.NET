#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DemoCalculator.Controls;
using Seachem;

#endregion

namespace DemoCalculator.Forms
{
    public partial class MainForm : Form
    {
        private readonly Button _calcButton;
        private ISeachemProduct[] _products;

        public MainForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            _calcButton = new Button { Text = "Calculate" };
            _calcButton.Click += calcButton_Click;

            PopulateTypes();
        }

        private void PopulateTypes()
        {
            foreach (var type in Seachem.Seachem.GetProductTypes())
            {
                listTypes.Items.Add(type.ToString());
            }

            listTypes.SelectedIndex = 0;
        }

        private void PopulateProducts()
        {
            var type = (SeachemProductType) Enum.Parse(typeof (SeachemProductType), listTypes.Text);
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
            LoadProduct(GetSelectedProduct());
        }

        private void listTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProducts();
        }

        private void AddRow(params Control[] controls)
        {
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowCount = tableLayoutPanel1.RowStyles.Count;
            var rowIndex = tableLayoutPanel1.RowCount - 1;

            for (var i = 0; i < controls.Length; i++)
            {
                var c = controls[i];
                tableLayoutPanel1.Controls.Add(c, i, rowIndex);
            }
        }

        public void LoadProduct(ISeachemProduct product)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            //populate parameter controls
            foreach (var param in product.Parameters)
            {
                var lblName = new Label
                {
                    Text = string.Format("{0}:", param.Name),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                };
                var nudValue = new NumericUpDownExtended
                {
                    DecimalPlaces = 2,
                    Width = 70,
                    Maximum = 999
                };
                var lblUnit = new Label
                {
                    Text = param.Unit,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                AddRow(lblName, nudValue, lblUnit);
            }

            AddRow(_calcButton);

            //populate dosage controls
            var dosages = product.Calculate();

            for (var i = 0; i < dosages.Length; i++)
            {
                var controls = new List<Control>();

                if (i == 0)
                {
                    controls.Add(new Label
                    {
                        Text = "You'll need:",
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleLeft,
                    });
                }

                var dosage = product.Calculate()[i];

                controls.Add(new TextBox
                {
                    ReadOnly = true,
                    Text = dosage.Value.ToString()
                });

                controls.Add(new Label
                {
                    Text = dosage.Unit,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft
                });

                if (i != dosages.Length - 1)
                {
                    controls.Add(new Label
                    {
                        Text = "or",
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter
                    });
                }

                AddRow(controls.ToArray());
            }

            var lblComment = new Label
            {
                Text = product.Comment,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            AddRow(lblComment);
            tableLayoutPanel1.SetColumnSpan(lblComment, 3);
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            var product = GetSelectedProduct();

            var parameters = product.Parameters;

            for (var i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                var input = (NumericUpDownExtended) tableLayoutPanel1.GetControlFromPosition(1, i);
                param.Value = input.Value;
            }

            var dosages = product.Calculate();

            for (var i = 0; i < dosages.Length; i++)
            {
                var dosage = dosages[i];
                //params + calc button + index
                var rowIndex = parameters.Length + 1 + i;
                var txtBox = (TextBox) tableLayoutPanel1.GetControlFromPosition(1, rowIndex);
                txtBox.Text = dosage.Value.ToString();
            }
        }
    }
}