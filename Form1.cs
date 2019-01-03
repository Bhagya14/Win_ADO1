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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Newemployee_Click(object sender, EventArgs e)
        {
            if (txt_employeename.Text == String.Empty)
            {
                MessageBox.Show("Enter Name:");
            }
            else if (txt_employeecity.Text == String.Empty)
            {
                MessageBox.Show("enter city:");
            }
            else if (txt_employeesalary.Text == String.Empty)
            {
                MessageBox.Show("enter salary:");
            }
            else if (txt_employeepassword.Text == String.Empty)
            {
                MessageBox.Show("enter password:");
            }
            else
            {
                Employeemodel model = new Employeemodel();
                model.employeename = txt_employeename.Text;
                model.employeecity = txt_employeecity.Text;
                model.employeesalary =Convert.ToInt32(txt_employeesalary.Text);
                model.employeepassword = txt_employeepassword.Text;
                EmployeesDAL dal = new EmployeesDAL();
                int id = dal.AddEmployee(model);
                MessageBox.Show("employee added:id:" + id);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_loginid.Text == string.Empty)
            {
                MessageBox.Show("enter login id:");
            }
            else if (txt_password.Text == String.Empty)
            {
                MessageBox.Show("enter password:");
            }
            else
            {
                try {
                    int Loginid = Convert.ToInt32(txt_loginid.Text);
                    string Password = txt_password.Text;
                    EmployeesDAL dal = new EmployeesDAL();
                    bool status = dal.Login(Loginid, Password);
                    if (status == true)
                    {
                        MessageBox.Show("Valid User");
                        Frm_Home obj = new Frm_Home();
                        obj.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User");
                    }
                }
                catch(System.Data.SqlClient.SqlException exp)
                {
                    MessageBox.Show("Database error:" + exp.Message);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("wrong input:" + exp.Message);
                }
               //finally
                //{
                    MessageBox.Show("finally block");
               // }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_employeename.Text = string.Empty;
            txt_employeecity.Text = string.Empty;
            txt_employeesalary.Text = string.Empty;
            txt_employeepassword.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txt_loginid.Text;
            string password = txt_password.Text;
            EmployeesDAL dal = new EmployeesDAL();
            bool status = dal.LoginSQLInjection(id, password);
            if (status == true)
            {
                MessageBox.Show("Valid user");
            }
            else
            {
                MessageBox.Show("Invalid user");
            }
        }
    }
}
