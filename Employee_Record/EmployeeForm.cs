using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;

namespace Employee_Record
{
    public partial class EmployeeForm : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["employeeManagement"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;

        public EmployeeForm()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            LoadDepartments();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var EmployeeData = new Dictionary<string, object>
            {
                { "DeptID", comboBox1.SelectedValue.ToString() },
                { "EmpID", txtEmpID.Text},
                { "Name", txtName.Text },
                { "Address", comboBox1.Text },
            };
            Connection.Insert("Employee", EmployeeData);
            ShowData();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            ShowData();
        }
        private void ShowData()
        {
            DataTable dt = new DataTable();
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM Employee", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void rowHeader(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                txtEmpID.Enabled = true;
                txtEmpID.Clear();
                txtName.Clear();
                //comboBox1.Clear();
            }
            else
            {

                txtEmpID.Enabled = false;
                txtEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? string.Empty;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var EmployeeData = new Dictionary<string, object>
            {
                { "Name", txtName.Text },
                { "Address", comboBox1.Text }
            };

            Connection.Update("Employee", EmployeeData, "EmpID", txtEmpID.Text);
            ShowData();
            MessageBox.Show("Employee details updated successfully!");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int allowanceID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmpID"].Value);
                Connection.Delete("Employee", "EmpID", allowanceID);
                // {"DepartmentID",comboBox1.SelectedValue }
                ShowData();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtEmpID.Text = "";
            comboBox1.Text = "";
            //ID = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

        }
    }
    }



//if (string.IsNullOrEmpty(txtEmpID.Text))
//{
//    MessageBox.Show("Please enter an Employee ID to update.");
//    return;
//}

//using (SqlConnection conn = new SqlConnection(connectionString))
//{
//    string query = "UPDATE Employee SET Name = @Name, Address = @Address WHERE EmpID = @EmpID";
//    SqlCommand cmd = new SqlCommand(query, conn);

//    cmd.Parameters.AddWithValue("@EmpID", txtEmpID.Text);
//    cmd.Parameters.AddWithValue("@Name", txtName.Text);
//    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

//    conn.Open();
//    cmd.ExecuteNonQuery();
//    conn.Close();

//    ShowData();
//    MessageBox.Show("Employee details updated successfully!");
//}
