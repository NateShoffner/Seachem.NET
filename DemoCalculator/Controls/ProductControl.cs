#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Seachem;

#endregion

namespace DemoCalculator.Controls
{
    public partial class ProductControl : UserControl
    {
        private readonly Button _calcButton;
        private ISeachemProduct _product;

        public ProductControl()
        {
            InitializeComponent();

            _calcButton = new Button {Text = "Calculate"};
            _calcButton.Click += calcButton_Click;
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
            _product = product;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            //populate parameter controls
            foreach (var param in _product.Parameters)
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
            var dosages = _product.CalculateDosage();

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

                var dosage = _product.CalculateDosage()[i];

                controls.Add(new TextBox
                {
                    ReadOnly = true,
                    Text = dosage.Amount.ToString()
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
                Text = _product.Comment,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            AddRow(lblComment);
            tableLayoutPanel1.SetColumnSpan(lblComment, 3);
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            var parameters = _product.Parameters;

            for (var i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                var input = (NumericUpDownExtended) tableLayoutPanel1.GetControlFromPosition(1, i);
                param.Value = input.Value;
            }

            var dosages = _product.CalculateDosage();

            for (var i = 0; i < dosages.Length; i++)
            {
                var dosage = dosages[i];
                //params + calc button + index
                var rowIndex = parameters.Length + 1 + i;
                var txtBox = (TextBox) tableLayoutPanel1.GetControlFromPosition(1, rowIndex);
                txtBox.Text = dosage.Amount.ToString();
            }
        }
    }
}