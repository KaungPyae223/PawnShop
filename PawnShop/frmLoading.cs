using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawnShop
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }
        FrmMain frm = new FrmMain();
        private void frmLoading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pgvLoad.Value<100)
            {
                pgvLoad.Value+=2;
                label2.Text=pgvLoad.Value.ToString()+" %";
            }
            else
            {
                timer1.Stop(); 
                frm.ShowDialog();
                this.Close();
            }
        }
    }
}
