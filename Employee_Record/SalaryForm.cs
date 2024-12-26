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
using System.Xml.Linq;

namespace Employee_Record
{
    public partial class SalaryForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0REECH5\SQLEXPRESS;Initial Catalog=employee_database;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public SalaryForm()
        {
            InitializeComponent();
            LoadDepartments();
        }

        private void SalaryForm_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            var SalaryData = new Dictionary<string, object>
            {
                { "SalaryID", txtSalaryID.Text },
                { "EmpID", txtEmpID.Text },
                { "BasicSalary", txtBasicSalary.Text },
            };
            Connection.Insert("Salary", SalaryData);
            ShowData();
        }
        private void rowHeader(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                txtSalaryID.Enabled = true;
                txtEmpID.Clear();
                txtBasicSalary.Clear();
            }
            else
            {
                txtSalaryID.Enabled = false;
                txtSalaryID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                txtEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;
                txtBasicSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? string.Empty;

            }
        }
        private void ShowData()
        {
            DataTable dt = new DataTable();
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM Salary", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void LoadDepartments()
        {
            try
            {
                DataTable departmentData = Connection.GetDepartments();
                comboBox1.DisplayMember = "DeptName"; // Display department names
                comboBox1.ValueMember = "DeptID";     // Store department IDs
                comboBox1.DataSource = departmentData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
