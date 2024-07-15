using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ColorInterpolationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string startColor = txtStartColor.Text;
            string endColor = txtEndColor.Text;
            int numSteps = (int)numStepsInput.Value;

            lstColors.Items.Clear();
            for (int step = 0; step <= numSteps; ++step)
            {
                double ratio = (double)step / numSteps;
                string interpolatedColor = InterpolateColor(startColor, endColor, ratio);
                lstColors.Items.Add(interpolatedColor);
            }
        }

        private void HexToRGB(string hex, out int r, out int g, out int b)
        {
            hex = hex.TrimStart('#');
            r = int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            g = int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            b = int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
        }

        private string RGBToHexUpperCase(int r, int g, int b)
        {
            return $"#{r:X2}{g:X2}{b:X2}";
        }

        private string InterpolateColor(string startColor, string endColor, double ratio)
        {
            HexToRGB(startColor, out int startR, out int startG, out int startB);
            HexToRGB(endColor, out int endR, out int endG, out int endB);

            int interpolatedR = startR + (int)(ratio * (endR - startR));
            int interpolatedG = startG + (int)(ratio * (endG - startG));
            int interpolatedB = startB + (int)(ratio * (endB - startB));

            return RGBToHexUpperCase(interpolatedR, interpolatedG, interpolatedB);
        }

        private void InitializeComponent()
        {
            this.txtStartColor = new System.Windows.Forms.TextBox();
            this.txtEndColor = new System.Windows.Forms.TextBox();
            this.numStepsInput = new System.Windows.Forms.NumericUpDown();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lstColors = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numStepsInput)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStartColor
            // 
            this.txtStartColor.Location = new System.Drawing.Point(12, 12);
            this.txtStartColor.Name = "txtStartColor";
            this.txtStartColor.Size = new System.Drawing.Size(100, 20);
            this.txtStartColor.TabIndex = 0;
            this.txtStartColor.Text = "#FF0000"; // 默认值
            // 
            // txtEndColor
            // 
            this.txtEndColor.Location = new System.Drawing.Point(12, 38);
            this.txtEndColor.Name = "txtEndColor";
            this.txtEndColor.Size = new System.Drawing.Size(100, 20);
            this.txtEndColor.TabIndex = 1;
            this.txtEndColor.Text = "#0000FF"; // 默认值
            // 
            // numStepsInput
            // 
            this.numStepsInput.Location = new System.Drawing.Point(12, 64);
            this.numStepsInput.Name = "numStepsInput";
            this.numStepsInput.Size = new System.Drawing.Size(100, 20);
            this.numStepsInput.TabIndex = 2;
            this.numStepsInput.Value = 10; // 默认值
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 90);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "生成颜色";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lstColors
            // 
            this.lstColors.FormattingEnabled = true;
            this.lstColors.Location = new System.Drawing.Point(118, 12);
            this.lstColors.Name = "lstColors";
            this.lstColors.Size = new System.Drawing.Size(150, 147);
            this.lstColors.TabIndex = 4;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lstColors);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.numStepsInput);
            this.Controls.Add(this.txtEndColor);
            this.Controls.Add(this.txtStartColor);
            this.Name = "Form1";
            this.Text = "颜色插值生成器";
            ((System.ComponentModel.ISupportInitialize)(this.numStepsInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtStartColor;
        private System.Windows.Forms.TextBox txtEndColor;
        private System.Windows.Forms.NumericUpDown numStepsInput;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ListBox lstColors;
    }
}
