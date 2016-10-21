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
            this.pvp = new System.Windows.Forms.Button();
            this.pvc = new System.Windows.Forms.Button();
            this.cvc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.pvp.Location = new System.Drawing.Point(55, 95);
            this.pvp.Name = "button1";
            this.pvp.Size = new System.Drawing.Size(200, 42);
            this.pvp.TabIndex = 0;
            this.pvp.Text = "Player vs Player";
            this.pvp.UseVisualStyleBackColor = true;
            this.pvp.Click += new System.EventHandler(this.pvp_Click);
            // 
            // button2
            // 
            this.pvc.Location = new System.Drawing.Point(55, 143);
            this.pvc.Name = "button2";
            this.pvc.Size = new System.Drawing.Size(200, 42);
            this.pvc.TabIndex = 1;
            this.pvc.Text = "Player vs Computer";
            this.pvc.UseVisualStyleBackColor = true;
            this.pvc.Click += new System.EventHandler(this.pvc_Click);
            // 
            // button3
            // 
            this.cvc.Location = new System.Drawing.Point(55, 190);
            this.cvc.Name = "button3";
            this.cvc.Size = new System.Drawing.Size(200, 42);
            this.cvc.TabIndex = 2;
            this.cvc.Text = "Computer vs Computer";
            this.cvc.UseVisualStyleBackColor = true;
            this.cvc.Click += new System.EventHandler(this.cvc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select your preferred game mode:";
            // 
            // GameModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 272);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cvc);
            this.Controls.Add(this.pvc);
            this.Controls.Add(this.pvp);
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