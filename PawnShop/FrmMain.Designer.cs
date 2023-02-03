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
            this.mnuPawn = new System.Windows.Forms.ToolStripMenuItem();
            this.pawnBigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pawnSmallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYae = new System.Windows.Forms.ToolStripMenuItem();
            this.အရToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.အရသToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sarYinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPannel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPawn,
            this.mnuYae,
            this.sarYinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuPawn
            // 
            this.mnuPawn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pawnBigToolStripMenuItem,
            this.pawnSmallToolStripMenuItem});
            this.mnuPawn.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuPawn.Name = "mnuPawn";
            this.mnuPawn.Size = new System.Drawing.Size(92, 40);
            this.mnuPawn.Text = "အပေါင်";
            // 
            // pawnBigToolStripMenuItem
            // 
            this.pawnBigToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.pawnBigToolStripMenuItem.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pawnBigToolStripMenuItem.Name = "pawnBigToolStripMenuItem";
            this.pawnBigToolStripMenuItem.Size = new System.Drawing.Size(220, 44);
            this.pawnBigToolStripMenuItem.Text = "အပေါင်ကြီး";
            this.pawnBigToolStripMenuItem.Click += new System.EventHandler(this.pawnBigToolStripMenuItem_Click);
            // 
            // pawnSmallToolStripMenuItem
            // 
            this.pawnSmallToolStripMenuItem.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pawnSmallToolStripMenuItem.Name = "pawnSmallToolStripMenuItem";
            this.pawnSmallToolStripMenuItem.Size = new System.Drawing.Size(220, 44);
            this.pawnSmallToolStripMenuItem.Text = "အပေါင်သေး";
            this.pawnSmallToolStripMenuItem.Click += new System.EventHandler(this.pawnSmallToolStripMenuItem_Click);
            // 
            // mnuYae
            // 
            this.mnuYae.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.အရToolStripMenuItem,
            this.အရသToolStripMenuItem});
            this.mnuYae.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuYae.Name = "mnuYae";
            this.mnuYae.Size = new System.Drawing.Size(82, 40);
            this.mnuYae.Text = "‌အရွေး";
            // 
            // အရToolStripMenuItem
            // 
            this.အရToolStripMenuItem.Name = "အရToolStripMenuItem";
            this.အရToolStripMenuItem.Size = new System.Drawing.Size(210, 44);
            this.အရToolStripMenuItem.Text = "‌အရွေးကြီး";
            this.အရToolStripMenuItem.Click += new System.EventHandler(this.အရToolStripMenuItem_Click);
            // 
            // အရသToolStripMenuItem
            // 
            this.အရသToolStripMenuItem.Name = "အရသToolStripMenuItem";
            this.အရသToolStripMenuItem.Size = new System.Drawing.Size(210, 44);
            this.အရသToolStripMenuItem.Text = "‌အရွေးသေး";
            this.အရသToolStripMenuItem.Click += new System.EventHandler(this.အရသToolStripMenuItem_Click);
            // 
            // sarYinToolStripMenuItem
            // 
            this.sarYinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyToolStripMenuItem});
            this.sarYinToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sarYinToolStripMenuItem.Name = "sarYinToolStripMenuItem";
            this.sarYinToolStripMenuItem.Size = new System.Drawing.Size(95, 40);
            this.sarYinToolStripMenuItem.Text = "Sar Yin";
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new System.Drawing.Size(159, 36);
            this.dailyToolStripMenuItem.Text = "Daily";
            this.dailyToolStripMenuItem.Click += new System.EventHandler(this.dailyToolStripMenuItem_Click);
            // 
            // mainPannel
            // 
            this.mainPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPannel.Location = new System.Drawing.Point(0, 44);
            this.mainPannel.Name = "mainPannel";
            this.mainPannel.Size = new System.Drawing.Size(800, 406);
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
            this.MaximizeBox = false;
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
        private System.Windows.Forms.ToolStripMenuItem mnuPawn;
        private System.Windows.Forms.ToolStripMenuItem pawnBigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pawnSmallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuYae;
        private System.Windows.Forms.Panel mainPannel;
        private System.Windows.Forms.ToolStripMenuItem အရToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem အရသToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sarYinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem;
    }
}

