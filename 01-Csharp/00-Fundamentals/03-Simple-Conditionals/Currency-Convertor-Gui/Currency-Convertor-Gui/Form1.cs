using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Convertor_Gui
{
    public partial class FormConverter : Form
    {
        public FormConverter()
        {
            InitializeComponent();
        }

        private void FormConverter_Load(object sender, EventArgs e)
        {
            this.Name = "FormConverter";
            this.Text = "Currency Converter";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.comboBoxCurrency.SelectedItem = "EUR";
            
            Initialize_NumbericUpDown(this.numericUpDown);
            Initialize_ComboBox(this.comboBoxCurrency);
            Initialize_LabelResult(this.labelResult);
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void ConvertCurrency()
        {
            var originalAmount = this.numericUpDown.Value;
            var convertedAmount = originalAmount;

            if (this.comboBoxCurrency.SelectedItem.ToString() == "EUR")
            {
                convertedAmount = originalAmount / 1.95583m;
            }
            else if (this.comboBoxCurrency.SelectedItem.ToString() == "USD")
            {
                convertedAmount = originalAmount / 1.80810m;
            }
            else if (this.comboBoxCurrency.SelectedItem.ToString() == "GBP")
            {
                convertedAmount = originalAmount / 2.54990m;
            }

            this.labelResult.Text = originalAmount + " лв. = " +
            Math.Round(convertedAmount, 2) + " " + this.comboBoxCurrency.SelectedItem;
        }

        private void Initialize_NumbericUpDown(NumericUpDown numericUpDown)
        {
            numericUpDown.Value = 1;
            numericUpDown.Minimum = 0;
            numericUpDown.Maximum = 1000000;
            numericUpDown.TextAlign = HorizontalAlignment.Right;
            numericUpDown.DecimalPlaces = 2;
        }

        private void Initialize_ComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Initialize_LabelResult(Label labelResult)
        {
            labelResult.AutoSize = false;
            labelResult.BackColor = Color.PaleGreen;
            labelResult.TextAlign = ContentAlignment.MiddleCenter;
            labelResult.Width = 350;
            labelResult.Height = 40;
        }
    }
}
