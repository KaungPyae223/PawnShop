using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawnShop.Monthly
{
    public partial class DailyAdd : Form
    {
        public DailyAdd()
        {
            InitializeComponent();
        }

        private void DailyAdd_Load(object sender, EventArgs e)
        {
            this.Size=new Size(530, 700);
            int h = Screen.PrimaryScreen.Bounds.Size.Height;
            int screenwidth = Screen.PrimaryScreen.Bounds.Size.Width;
            int formh = this.Height;
            int fontwidth = this.Width;
            this.Location=new Point((screenwidth-fontwidth)/2, (h-formh)/2);
        }
    }
}
