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
    public partial class Frm_find : Form
    {
        public Frm_find()
        {
            InitializeComponent();
        }

        private void Frm_find_Load(object sender, EventArgs e)
        {

        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_enteremployeeid.Text == String.Empty)
            {
                MessageBox.Show("enter id:");
            }
            else
            {
                int id = Convert.ToInt32(txt_enteremployeeid.Text);
                EmployeesDAL dal = new EmployeesDAL();
                Employeemodel model = dal.Findemployee(id);
                if (model != null)
                {
                    txt_employeename.Text = model.employeename;
                    txt_employeecity.Text = model.employeecity;
                    txt_employeesalary.Text = model.employeesalary.ToString();
                    txt_employeepassword.Text = model.employeepassword;
                }
                else
                {
                    MessageBox.Show("employee not found");
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_enteremployeeid.Text);
            string city = txt_employeecity.Text;
            int salary = Convert.ToInt32(txt_employeesalary.Text);
            EmployeesDAL dal = new EmployeesDAL();
            bool status = dal.Updateemployee(id, city, salary);
            if (status == true)
            {
                MessageBox.Show("employee details updated");
            }
            else
            {
                MessageBox.Show("not updated");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_enteremployeeid.Text);
            EmployeesDAL dal = new EmployeesDAL();
            bool status = dal.Deleteemployee(id);
            if (status == true)
            {
                MessageBox.Show("employee deleted");
            }
            else
            {
                MessageBox.Show("employee not deleted");
            }
        }
    }
}
