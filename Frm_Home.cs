using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_ado1
{
    public partial class Frm_Home : Form
    {
        public Frm_Home()
        {
            InitializeComponent();
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            Frm_find obj = new Frm_find();
            obj.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Frm_search obj = new Frm_search();
            obj.Show();
        }
    }
}
