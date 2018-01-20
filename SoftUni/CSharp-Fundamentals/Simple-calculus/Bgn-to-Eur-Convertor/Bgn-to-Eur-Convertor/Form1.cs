using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bgn_to_Eur_Convertor
{
    public partial class FormConverter : Form
    {
        private const decimal BGN_TO_EUR_COURSE = 1.95583m;

        public FormConverter()
        {
            InitializeComponent();

            // Initialize numericUpDown
            this.numericUpDownAmountOfMoney.DecimalPlaces = 2;

            // Initialize labelResult
            this.labelResult.AutoSize = false;
            this.labelResult.BackColor = Color.PaleGreen;
            this.labelResult.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void numericUpDownAmountOfMoney_ValueChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void FormConverter_Load(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void numericUpDownAmountOfMoney_KeyUp(object sender, KeyEventArgs e)
        {
            ConvertCurrency();
        }

        private void ConvertCurrency()
        {
            var valueInBgn = this.numericUpDownAmountOfMoney.Value;
            var valueInEur = valueInBgn * BGN_TO_EUR_COURSE;

            this.labelResult.Text = $"{valueInBgn} BGN = {Math.Round(valueInEur, 2)} EUR";
        }

    }
}
