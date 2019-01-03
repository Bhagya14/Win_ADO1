using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Win_ado1
{
    class EmployeesDAL
    {

        SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        public int AddEmployee(Employeemodel model)
        {
            SqlCommand com_add_employee = new SqlCommand("proc_addemployee", con);
            com_add_employee.Parameters.AddWithValue("@name", model.employeename);
            com_add_employee.Parameters.AddWithValue("@city", model.employeecity);
            com_add_employee.Parameters.AddWithValue("@salary", model.employeesalary);
            com_add_employee.Parameters.AddWithValue("@password", model.employeepassword);

            com_add_employee.CommandType = CommandType.StoredProcedure;

            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;

            com_add_employee.Parameters.Add(para_return);
            con.Open();

            com_add_employee.ExecuteNonQuery();//exec proc

            con.Close();

            int id = Convert.ToInt32(para_return.Value);
            return id;

        }

        public bool Updateemployee(int id,string city,int salary)
        {
            SqlCommand com_update = new SqlCommand("proc_updateemployee", con);
            com_update.Parameters.AddWithValue("@id", id);
            com_update.Parameters.AddWithValue("@city", city);
            com_update.Parameters.AddWithValue("@salary", salary);
            com_update.CommandType = CommandType.StoredProcedure;
            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;
            com_update.Parameters.Add(para_return);
            con.Open();
            com_update.ExecuteNonQuery();
            con.Close();

            int count = Convert.ToInt32(para_return.Value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deleteemployee(int id)
        {
            SqlCommand com_delete = new SqlCommand("proc_deleteemployee", con);
            com_delete.Parameters.AddWithValue("@id", id);
            com_delete.CommandType = CommandType.StoredProcedure;
            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;
            com_delete.Parameters.Add(para_return);
            con.Open();
            com_delete.ExecuteNonQuery();
            con.Close();
            int count = Convert.ToInt32(para_return.Value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Login(int id,string password)
        {
            try
            {
                SqlCommand com_login = new SqlCommand("proc_login", con);
                com_login.Parameters.AddWithValue("@id", id);
                com_login.Parameters.AddWithValue("@password", password);
                com_login.CommandType = CommandType.StoredProcedure;
                SqlParameter para_return = new SqlParameter();
                para_return.Direction = ParameterDirection.ReturnValue;
                com_login.Parameters.Add(para_return);
                con.Open();
                com_login.ExecuteNonQuery();
                
                int count = Convert.ToInt32(para_return.Value);
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                System.Windows.Forms.MessageBox.Show("finally");
            }
        }

        public Employeemodel Findemployee(int id)
        {
            SqlCommand com_find = new SqlCommand("proc_findemployee", con);
            com_find.Parameters.AddWithValue("@id", id);
            com_find.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = com_find.ExecuteReader();
            if (dr.Read())
            {
                Employeemodel model = new Employeemodel();
                model.employeeid = dr.GetInt32(0);
                model.employeename = dr.GetString(1);
                model.employeecity = dr.GetString(2);
                model.employeesalary = dr.GetInt32(3);
                model.employeepassword = dr.GetString(4);
                con.Close();
                return model;
            }
            con.Close();
            return null;
        }

        public List<Employeemodel> Searchemployee(string key)
        {
            SqlCommand com_search = new SqlCommand("proc_searchemployee", con);
            com_search.Parameters.AddWithValue("@key",key );
            com_search.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = com_search.ExecuteReader();
            List<Employeemodel> list = new List<Employeemodel>();
            while (dr.Read())
            {
                Employeemodel model = new Employeemodel();
                model.employeeid = dr.GetInt32(0);
                model.employeename = dr.GetString(1);
                model.employeecity = dr.GetString(2);
                model.employeesalary = dr.GetInt32(3);
                model.employeepassword = dr.GetString(4);
                list.Add(model);
            }
            con.Close();
            return list;
        }

        public bool LoginSQLInjection(string id,string password)
        {
            SqlCommand com_login = new SqlCommand("select count(*) from tbl_employees where employeeid='" + id + "' and employeepassword='" + password + "'", con);
            con.Open();
            int count = Convert.ToInt32(com_login.ExecuteScalar());
            con.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
