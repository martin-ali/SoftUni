namespace Currency_Convertor_Gui
{
    partial class FormConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(18, 18);
            this.numericUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(180, 26);
            this.numericUpDown.TabIndex = 0;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "EUR",
            "USD",
            "GBP"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(279, 17);
            this.comboBoxCurrency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(88, 28);
            this.comboBoxCurrency.TabIndex = 1;
            this.comboBoxCurrency.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrency_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "BGN ->";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(18, 54);
            this.labelResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 23);
            this.labelResult.TabIndex = 3;
            // 
            // FormConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 102);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.numericUpDown);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormConverter";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormConverter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelResult;
    }
}

