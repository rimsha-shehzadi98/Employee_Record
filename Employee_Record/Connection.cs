using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace Employee_Record
{
    public class Connection
    {
        public static string conString = ConfigurationManager.ConnectionStrings["employeeManagement"].ConnectionString;

        SqlCommand cmd;
        public static void Insert(string tableName, Dictionary<string, object> columnValues)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException("Table name cannot be null or empty.");
            if (columnValues == null || columnValues.Count == 0)
                throw new ArgumentException("Column values cannot be null or empty.");

            var columns = string.Join(", ", columnValues.Keys);
            var parameters = string.Join(", ", columnValues.Keys.Select(k => $"@{k}"));
            var query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

            using (var connection = new SqlConnection(conString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    foreach (var pair in columnValues)
                    {
                        command.Parameters.AddWithValue($"@{pair.Key}", pair.Value ?? DBNull.Value);
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Record inserted into {tableName} successfully.");
                }
            }
        }

        public static void Update(string tableName, Dictionary<string, object> columnValues, string primaryKeyColumn, object primaryKeyValue)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException("Table name cannot be null or empty.", nameof(tableName));
            if (columnValues == null || columnValues.Count == 0)
                throw new ArgumentException("Column values cannot be null or empty.", nameof(columnValues));
            if (string.IsNullOrEmpty(primaryKeyColumn))
                throw new ArgumentException("Primary key column cannot be null or empty.", nameof(primaryKeyColumn));
            if (primaryKeyValue == null)
                throw new ArgumentNullException(nameof(primaryKeyValue), "Primary key value cannot be null.");

            // Construct the SQL query
            var setClause = string.Join(", ", columnValues.Keys.Select(column => $"{column} = @{column}"));
            var query = $"UPDATE {tableName} SET {setClause} WHERE {primaryKeyColumn} = @PrimaryKey";

            // Execute the query
            using (var connection = new SqlConnection(conString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    // Add parameters for the columns to be updated
                    foreach (var column in columnValues)
                    {
                        command.Parameters.AddWithValue($"@{column.Key}", column.Value ?? DBNull.Value);
                    }

                    // Add the primary key parameter
                    command.Parameters.AddWithValue("@PrimaryKey", primaryKeyValue);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected > 0
                        ? $"Record in {tableName} updated successfully."
                        : "No record found to update.");
                }
            }
        }

        public static DataTable GetData(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException("Table name cannot be null or empty.");
            //if (dataGridView == null)
            //  throw new ArgumentNullException(nameof(dataGridView), "DataGridView cannot be null.");

            var query = $"SELECT * FROM {tableName}";

            using (var connection = new SqlConnection(conString))
            {
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    connection.Open();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        public static void Delete(string tableName, string columnName, object columnValue)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException("Table name cannot be null or empty.");
            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("Column name cannot be null or empty.");
            if (columnValue == null)
                throw new ArgumentNullException(nameof(columnValue), "Column value cannot be null.");

            var query = $"DELETE FROM {tableName} WHERE {columnName} = @{columnName}";

            using (var connection = new SqlConnection(conString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue($"@{columnName}", columnValue);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0
                        ? $"Record in {tableName} deleted successfully."
                        : "No record found to delete.");
                }
            }
        }

        public static DataTable GetDepartments()
        {
            var query = "SELECT DeptID, DeptName FROM Department";

            using (var connection = new SqlConnection(conString))
            {
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable departmentTable = new DataTable();
                    adapter.Fill(departmentTable);
                    return departmentTable;
                }
            }
        }

    }
}


//Exception k baad bhi jo code execute krwana hai wo final mein aye ga