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
    public partial class Frm_search : Form
    {
        public Frm_search()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_enterkey.Text == string.Empty)
            {
                MessageBox.Show("enter a key");
            }
            else
            {
                EmployeesDAL dal = new EmployeesDAL();
                string key = txt_enterkey.Text;
                List<Employeemodel> list = dal.Searchemployee(key);
                dg_employees.DataSource = list;
            }
            
            
        }
    }
}
