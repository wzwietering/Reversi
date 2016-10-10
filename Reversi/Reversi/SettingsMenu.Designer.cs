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
            this.applySettings = new System.Windows.Forms.Button();
            this.p1Color = new System.Windows.Forms.Label();
            this.p2Color = new System.Windows.Forms.Label();
            this.colorChoiceP1 = new System.Windows.Forms.Button();
            this.colorChoiceP2 = new System.Windows.Forms.Button();
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
            3,
            0,
            0,
            0});
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
            3,
            0,
            0,
            0});
            // 
            // applySettings
            // 
            this.applySettings.Location = new System.Drawing.Point(15, 150);
            this.applySettings.Name = "applySettings";
            this.applySettings.Size = new System.Drawing.Size(75, 23);
            this.applySettings.TabIndex = 4;
            this.applySettings.Text = "Apply";
            this.applySettings.UseVisualStyleBackColor = true;
            this.applySettings.Click += new System.EventHandler(this.saveSettings);
            // 
            // p1Color
            // 
            this.p1Color.AutoSize = true;
            this.p1Color.Location = new System.Drawing.Point(12, 84);
            this.p1Color.Name = "p1Color";
            this.p1Color.Size = new System.Drawing.Size(72, 13);
            this.p1Color.TabIndex = 5;
            this.p1Color.Text = "Player 1 Color";
            // 
            // p2Color
            // 
            this.p2Color.AutoSize = true;
            this.p2Color.Location = new System.Drawing.Point(12, 108);
            this.p2Color.Name = "p2Color";
            this.p2Color.Size = new System.Drawing.Size(72, 13);
            this.p2Color.TabIndex = 6;
            this.p2Color.Text = "Player 2 Color";
            // 
            // colorChoiceP1
            // 
            this.colorChoiceP1.Location = new System.Drawing.Point(122, 79);
            this.colorChoiceP1.Name = "colorChoiceP1";
            this.colorChoiceP1.Size = new System.Drawing.Size(75, 23);
            this.colorChoiceP1.TabIndex = 7;
            this.colorChoiceP1.Text = "Choose";
            this.colorChoiceP1.UseVisualStyleBackColor = true;
            this.colorChoiceP1.Click += new System.EventHandler(this.chooseColorP1);
            // 
            // colorChoiceP2
            // 
            this.colorChoiceP2.Location = new System.Drawing.Point(122, 103);
            this.colorChoiceP2.Name = "colorChoiceP2";
            this.colorChoiceP2.Size = new System.Drawing.Size(75, 23);
            this.colorChoiceP2.TabIndex = 8;
            this.colorChoiceP2.Text = "Choose";
            this.colorChoiceP2.UseVisualStyleBackColor = true;
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 194);
            this.Controls.Add(this.colorChoiceP2);
            this.Controls.Add(this.colorChoiceP1);
            this.Controls.Add(this.p2Color);
            this.Controls.Add(this.p1Color);
            this.Controls.Add(this.applySettings);
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

        #endregion

        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.NumericUpDown widthNUD;
        private System.Windows.Forms.NumericUpDown heightNUD;
        private System.Windows.Forms.Button applySettings;
        private System.Windows.Forms.Label p1Color;
        private System.Windows.Forms.Label p2Color;
        private System.Windows.Forms.Button colorChoiceP1;
        private System.Windows.Forms.Button colorChoiceP2;
    }
}