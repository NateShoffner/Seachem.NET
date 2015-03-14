#region

using System;
using System.Windows.Forms;

#endregion

namespace DemoCalculator
{
    internal class NumericUpDownExtended : NumericUpDown
    {
        #region Overrides of Control

        #region Overrides of UpDownBase

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //select all text
            Select(0, Text.Length);
            base.OnMouseDown(e);
        }

        #endregion

        protected override void OnEnter(EventArgs e)
        {
            //select all text
            Select(0, Text.Length);
            base.OnEnter(e);
        }

        #endregion
    }
}