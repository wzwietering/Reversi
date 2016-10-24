namespace Reversi
{
    partial class GameModeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameModeForm));
            this.pvp = new System.Windows.Forms.Button();
            this.pvc = new System.Windows.Forms.Button();
            this.cvc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pvp
            // 
            this.pvp.Location = new System.Drawing.Point(41, 77);
            this.pvp.Margin = new System.Windows.Forms.Padding(2);
            this.pvp.Name = "pvp";
            this.pvp.Size = new System.Drawing.Size(150, 34);
            this.pvp.TabIndex = 0;
            this.pvp.Text = "Player vs Player";
            this.pvp.UseVisualStyleBackColor = true;
            this.pvp.Click += new System.EventHandler(this.pvp_Click);
            // 
            // pvc
            // 
            this.pvc.Location = new System.Drawing.Point(41, 116);
            this.pvc.Margin = new System.Windows.Forms.Padding(2);
            this.pvc.Name = "pvc";
            this.pvc.Size = new System.Drawing.Size(150, 34);
            this.pvc.TabIndex = 1;
            this.pvc.Text = "Player vs Computer";
            this.pvc.UseVisualStyleBackColor = true;
            this.pvc.Click += new System.EventHandler(this.pvc_Click);
            // 
            // cvc
            // 
            this.cvc.Location = new System.Drawing.Point(41, 154);
            this.cvc.Margin = new System.Windows.Forms.Padding(2);
            this.cvc.Name = "cvc";
            this.cvc.Size = new System.Drawing.Size(150, 34);
            this.cvc.TabIndex = 2;
            this.cvc.Text = "Computer vs Computer";
            this.cvc.UseVisualStyleBackColor = true;
            this.cvc.Click += new System.EventHandler(this.cvc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select your preferred game mode:";
            // 
            // GameModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 221);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cvc);
            this.Controls.Add(this.pvc);
            this.Controls.Add(this.pvp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameModeForm";
            this.Text = "GameModeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pvp;
        private System.Windows.Forms.Button pvc;
        private System.Windows.Forms.Button cvc;
        private System.Windows.Forms.Label label1;
    }
}