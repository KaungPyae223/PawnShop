﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawnShop.PawnData
{
    public partial class frmPawnSmall : Form
    {
        public frmPawnSmall()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmPawnAdd frm= new frmPawnAdd();
            frm.ShowDialog();
        }
    }
}