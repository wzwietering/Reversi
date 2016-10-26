using System;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsMenu));
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthNUD = new System.Windows.Forms.NumericUpDown();
            this.heightNUD = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.widthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(12, 28);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(12, 54);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 1;
            this.heightLabel.Text = "Height";
            // 
            // widthNUD
            // 
            this.widthNUD.Location = new System.Drawing.Point(122, 28);
            this.widthNUD.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.widthNUD.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.widthNUD.Name = "widthNUD";
            this.widthNUD.Size = new System.Drawing.Size(75, 20);
            this.widthNUD.TabIndex = 2;
            this.widthNUD.Value = new decimal(new int[] {
            Settings.BoardWidth,
            0,
            0,
            0});
            // 
            // heightNUD
            // 
            this.heightNUD.Location = new System.Drawing.Point(122, 53);
            this.heightNUD.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.heightNUD.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.heightNUD.Name = "heightNUD";
            this.heightNUD.Size = new System.Drawing.Size(75, 20);
            this.heightNUD.TabIndex = 3;
            this.heightNUD.Value = new decimal(new int[] {
            Settings.BoardHeight,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(236, 161);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(40, 21);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 189);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.heightNUD);
            this.Controls.Add(this.widthNUD);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SettingsMenu";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.widthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PlayerOptions()
        {
            for(int i = 0; i < players.Length; i++)
            {
                TextBox playerName = new TextBox();
                playerName.Text = players[i].PlayerName;
                playerName.Location = new System.Drawing.Point(12, i * 30 + 100);
                playerName.Name = i.ToString();
                playerName.TextChanged += new System.EventHandler(ChangePlayerName);

                Button colorChoice = new Button();
                colorChoice.Text = "Color";
                colorChoice.Location = new System.Drawing.Point(122, i * 30 + 100);
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
        private Button okButton;
        private MenuStrip menuStrip1;
    }
}