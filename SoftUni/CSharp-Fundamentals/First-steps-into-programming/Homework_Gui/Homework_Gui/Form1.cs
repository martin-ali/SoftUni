using System;
using System.Windows.Forms;

namespace Homework_Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal firstNumber = decimal.Parse(this.textBox1.Text);
                decimal secondNumber = decimal.Parse(this.textBox2.Text);

                decimal result = firstNumber + secondNumber;

                textBoxResult.Text = result.ToString();
            }
            catch (Exception exception)
            {

                textBoxResult.Text = "Error!";
                throw exception; // Fuuuu
            }
        }
    }
}
