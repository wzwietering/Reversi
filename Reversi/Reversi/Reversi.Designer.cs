using System.Windows.Forms;

namespace Reversi
{
    partial class Reversi
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitGame = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.currentGameContainer = new System.Windows.Forms.UserControl();
            this.MessageBox = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGame,
            this.settingsToolStripMenuItem,
            this.exitGame});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGame
            // 
            this.newGame.Name = "newGame";
            this.newGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGame.Size = new System.Drawing.Size(141, 22);
            this.newGame.Text = "New";
            this.newGame.Click += new System.EventHandler(this.NewGame);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsMenu);
            // 
            // exitGame
            // 
            this.exitGame.Name = "exitGame";
            this.exitGame.Size = new System.Drawing.Size(141, 22);
            this.exitGame.Text = "Exit";
            this.exitGame.Click += new System.EventHandler(this.ExitGame);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help,
            this.about});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.help.Size = new System.Drawing.Size(142, 22);
            this.help.Text = "Help";
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(142, 22);
            this.about.Text = "About";
            this.about.Click += new System.EventHandler(this.aboutMenu);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(344, 6);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Display possible moves";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // currentGameContainer
            // 
            this.currentGameContainer.AutoSize = true;
            this.currentGameContainer.BackgroundImage = global::Reversi.Properties.Resources.WhiteMarble;
            this.currentGameContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentGameContainer.Location = new System.Drawing.Point(0, 24);
            this.currentGameContainer.Name = "currentGameContainer";
            this.currentGameContainer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.currentGameContainer.Size = this.Size;
            this.currentGameContainer.TabIndex = 0;
            // 
            // MessageBox
            // 
            this.MessageBox.AutoSize = true;
            this.MessageBox.BackColor = System.Drawing.Color.Transparent;
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageBox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBox.Location = new System.Drawing.Point(262, 37);
            this.MessageBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.MessageBox.Size = new System.Drawing.Size(148, 25);
            this.MessageBox.TabIndex = 3;
            this.MessageBox.Text = "This is not a valid move.";
            this.MessageBox.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.MessageBox.Visible = false;
            // 
            // Reversi
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.currentGameContainer);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Reversi";
            this.Text = "Reversi";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGame;
        private System.Windows.Forms.ToolStripMenuItem exitGame;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.UserControl currentGameContainer;
        private Label MessageBox;
    }
}

