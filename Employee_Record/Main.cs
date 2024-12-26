using Employee_Record;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Main : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0REECH5\SQLEXPRESS;Initial Catalog=employee_database;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public Main()
        {
            InitializeComponent();
            //btnEmployee.Text = Resource1.str_welcome;
            //btnDepartment.Text = Resource1._string;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm empForm = new EmployeeForm();
            empForm.ShowDialog();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.ShowDialog();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            SalaryForm salaryForm = new SalaryForm();
            salaryForm.ShowDialog();
        }

        private void btnAllowance_Click(object sender, EventArgs e)
        {
            AllowanceForm allowanceForm = new AllowanceForm();
            allowanceForm.ShowDialog();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            DepartmentForm departmentForm = new DepartmentForm();
            departmentForm.ShowDialog();
        }
    }
}
