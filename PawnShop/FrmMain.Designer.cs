namespace PawnShop
{
    partial class FrmMain
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
            this.pawnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yaeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pawnBigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pawnSmallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPannel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pawnToolStripMenuItem,
            this.yaeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pawnToolStripMenuItem
            // 
            this.pawnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pawnBigToolStripMenuItem,
            this.pawnSmallToolStripMenuItem});
            this.pawnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pawnToolStripMenuItem.Name = "pawnToolStripMenuItem";
            this.pawnToolStripMenuItem.Size = new System.Drawing.Size(85, 38);
            this.pawnToolStripMenuItem.Text = "Pawn";
            // 
            // yaeToolStripMenuItem
            // 
            this.yaeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yaeToolStripMenuItem.Name = "yaeToolStripMenuItem";
            this.yaeToolStripMenuItem.Size = new System.Drawing.Size(66, 38);
            this.yaeToolStripMenuItem.Text = "Yae";
            // 
            // pawnBigToolStripMenuItem
            // 
            this.pawnBigToolStripMenuItem.Name = "pawnBigToolStripMenuItem";
            this.pawnBigToolStripMenuItem.Size = new System.Drawing.Size(270, 40);
            this.pawnBigToolStripMenuItem.Text = "Pawn Big";
            this.pawnBigToolStripMenuItem.Click += new System.EventHandler(this.pawnBigToolStripMenuItem_Click);
            // 
            // pawnSmallToolStripMenuItem
            // 
            this.pawnSmallToolStripMenuItem.Name = "pawnSmallToolStripMenuItem";
            this.pawnSmallToolStripMenuItem.Size = new System.Drawing.Size(270, 40);
            this.pawnSmallToolStripMenuItem.Text = "Pawn Small";
            // 
            // mainPannel
            // 
            this.mainPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPannel.Location = new System.Drawing.Point(0, 42);
            this.mainPannel.Name = "mainPannel";
            this.mainPannel.Size = new System.Drawing.Size(800, 408);
            this.mainPannel.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPannel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pawnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pawnBigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pawnSmallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yaeToolStripMenuItem;
        private System.Windows.Forms.Panel mainPannel;
    }
}

