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
    public partial class AllowanceForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0REECH5\SQLEXPRESS;Initial Catalog=employee_database;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public AllowanceForm()
        {
            InitializeComponent();
        }

        private void AllowanceForm_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var EmployeeData = new Dictionary<string, object>
            {
                { "AllowanceID", txtAllowanceID.Text },
                { "EmpID", txtEmpID.Text },
                { "Amount", txtAmount.Text },
            };
            Connection.Insert("Allowance", EmployeeData);
            ShowData();
        }
        private void rowHeader(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                txtAllowanceID.Enabled = true;
                txtAllowanceID.Clear();
                txtEmpID.Clear();
                txtAmount.Clear();
            }
            else
            {
                txtAllowanceID.Enabled = false;
                txtAllowanceID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                txtEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;
                txtAmount.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? string.Empty;

            }
        }
        private void ShowData()
        {
            DataTable dt = new DataTable();
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM Allowance", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}