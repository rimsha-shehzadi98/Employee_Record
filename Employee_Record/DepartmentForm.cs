using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Employee_Record
{
    public partial class DepartmentForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-0REECH5\\SQLEXPRESS;Initial Catalog=employee_database;Integrated Security=True;";
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0REECH5\SQLEXPRESS;Initial Catalog=employee_database;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        public DepartmentForm()
        {
            InitializeComponent();

            contextMenuStrip1 = new ContextMenuStrip();

            contextMenuStrip1.Items.Add("Insert", null, Insert_Click);
            contextMenuStrip1.Items.Add("Update", null, Update_Click);
            contextMenuStrip1.Items.Add("Delete", null, Delete_Click);
            contextMenuStrip1.Items.Add("Clear", null, Clear_Click);

            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }


        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            ShowData();
            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
        }

        private void ShowData()
        {
            DataTable dt = new DataTable();
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM Department", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            var DepartmentData = new Dictionary<string, object>
            {
                { "DeptID", txtDeptID.Text },
                { "DeptName", txtDeptName.Text },
            };
            Connection.Insert("Department", DepartmentData);
            ShowData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Department SET DeptName = @DeptName WHERE DeptID = @DeptID";
                SqlCommand cmd = new SqlCommand(query, conn);

                var selectedRow = dataGridView1.SelectedRows[0];
                string deptID = selectedRow.Cells["DeptID"].Value.ToString();

                cmd.Parameters.AddWithValue("@DeptID", deptID);
                cmd.Parameters.AddWithValue("@DeptName", txtDeptName.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                ShowData();
                ClearData();
                MessageBox.Show("Department updated successfully!");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Department WHERE DeptID = @DeptID";
                SqlCommand cmd = new SqlCommand(query, conn);

                var selectedRow = dataGridView1.SelectedRows[0];
                string deptID = selectedRow.Cells["DeptID"].Value.ToString();

                cmd.Parameters.AddWithValue("@DeptID", deptID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                ShowData();
                ClearData();
               
                MessageBox.Show("Department deleted successfully!");
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtDeptID.Clear();
            txtDeptName.Clear();
            txtDeptID.Enabled = true;
        }
        private void ClearData()
        {
            txtDeptID.Clear();
            txtDeptName.Clear();
            txtDeptID.Enabled = true;
        }
        private void rowHeader(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                txtDeptID.Enabled = true;
                txtDeptID.Clear();
                txtDeptName.Clear();
            }
            else
            {
                txtDeptID.Enabled = false;
                txtDeptID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                txtDeptName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;
            }
        }
    }
}
