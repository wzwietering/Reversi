using System.Windows.Forms;

namespace Reversi
{
    partial class SettingsMenu
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
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthNUD = new System.Windows.Forms.NumericUpDown();
            this.heightNUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.widthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(12, 22);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(12, 48);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 1;
            this.heightLabel.Text = "Height";
            // 
            // widthNUD
            // 
            this.widthNUD.Location = new System.Drawing.Point(122, 22);
            this.widthNUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.widthNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.widthNUD.Name = "widthNUD";
            this.widthNUD.Size = new System.Drawing.Size(75, 20);
            this.widthNUD.TabIndex = 2;
            this.widthNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.widthNUD.ValueChanged += new System.EventHandler(this.SaveSettings);
            // 
            // heightNUD
            // 
            this.heightNUD.Location = new System.Drawing.Point(122, 46);
            this.heightNUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.heightNUD.Name = "heightNUD";
            this.heightNUD.Size = new System.Drawing.Size(75, 20);
            this.heightNUD.TabIndex = 3;
            this.heightNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightNUD.ValueChanged += new System.EventHandler(this.SaveSettings);
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 194);
            this.Controls.Add(this.heightNUD);
            this.Controls.Add(this.widthNUD);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Name = "SettingsMenu";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.widthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ColorOptions()
        {
            for(int i = 0; i < players.Count; i++)
            {
                Label playerName = new Label();
                playerName.Text = "Player " + (i + 1) + " color";
                playerName.Location = new System.Drawing.Point(12, i * 24 + 84);
                playerName.Name = "player" + i + "Label";

                Button colorChoice = new Button();
                colorChoice.Text = "Choose";
                colorChoice.Location = new System.Drawing.Point(122, i * 24 + 79);
                colorChoice.Name = i.ToString();
                colorChoice.Click += new System.EventHandler(ChooseColor);

                this.Controls.Add(playerName);
                this.Controls.Add(colorChoice);
            }
        }

        #endregion

        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.NumericUpDown widthNUD;
        private System.Windows.Forms.NumericUpDown heightNUD;
    }
}