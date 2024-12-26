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

namespace Employee_Record
{
    public partial class ContactForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0REECH5\SQLEXPRESS;Initial Catalog=employee_database;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        public ContactForm()
        {
            InitializeComponent();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        
        private void rowHeader(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                txtContactID.Enabled = true;
                txtContactID.Clear();
                txtEmpID.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
            }
            else
            {
                txtContactID.Enabled = false;
                txtContactID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                txtEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? string.Empty;
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? string.Empty;


            }
        }
        private void Insert_Click(object sender, EventArgs e)
        {
            var ContactData = new Dictionary<string, object>
            {
                { "ContactID", txtContactID.Text },
                { "EmpID", txtEmpID.Text },
                { "Phone", txtPhone.Text },
                { "Email", txtEmail.Text },
            };
            Connection.Insert("Contact", ContactData);
            ShowData();
        }
        private void ShowData()
        {
            DataTable dt = new DataTable();
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM Contact", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

    }
}
