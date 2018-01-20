using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catch_the_Button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCatchMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are winner!", "Winscrn.Win32Trojan_Root.Exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonCatchMe_MouseEnter(object sender, EventArgs e)
        {
            Random randomNumber = new Random();

            var horizontalBorder = this.ClientSize.Width - this.buttonCatchMe.Width;
            var verticalBorder = this.ClientSize.Height - this.buttonCatchMe.Height;

            var newButtonPosition = new Point(randomNumber.Next(horizontalBorder), randomNumber.Next(verticalBorder));

            this.buttonCatchMe.Location = newButtonPosition;
        }
    }
}
