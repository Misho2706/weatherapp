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
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace weatherapp
{
    public partial class Request_History : Form
    {
        public Request_History()
        {
            InitializeComponent();
            List<string> tables = GetTables(connstring);
            tablelistcombo.DataSource = tables;
            tablelistcombo.SelectedIndex = 2;
            string x = tablelistcombo.Items[2].ToString();
            //GetHistory(x);
        }
        string connstring = @"Data Source=DESKTOP-FBL0QF6\SQLEXPRESS;Initial Catalog=Weather;Integrated Security=true";
        //public void GetHistory(string tablename)
        //{
        //    using (var dbContext = new WeatherService.WeatherEntities2())
        //    {
        //        string selectQuery = $"SELECT * FROM {tablename}";
                 

        //        // Get the underlying database connection
        //        var connection = dbContext.Database.Connection;
        //        connection.Open();

        //        // Create a command object using the connection and query
        //        var command = connection.CreateCommand();
        //        command.CommandText = selectQuery;

        //        // Execute the query and retrieve the results as a DbDataReader
        //        using (var reader = command.ExecuteReader())
        //        {
        //            // Create a DataTable to hold the data
        //            var dataTable = new System.Data.DataTable();
        //            dataTable.Load(reader);

        //            // Bind the DataTable to the DataGridView
        //            dataGridView1.DataSource = dataTable;
        //        }

        //        connection.Close();
        //    }



            //SqlConnection con = new SqlConnection(connstring);

            //con.Open();
            //string selectstr = "select * from @table";
            //selectstr = selectstr.Replace("@table", tablename);
            //SqlCommand cmd = new SqlCommand(selectstr, con);

            //cmd.CommandType = CommandType.Text;

            //SqlDataAdapter da = new SqlDataAdapter(cmd);

            //DataSet ds = new DataSet();

            //da.Fill(ds, "ss");


            //dataGridView1.DataSource = ds.Tables["ss"];
            //con.Close();


       // }

        public static List<string> GetTables(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void tablelistcombo_SelectedValueChanged(object sender, EventArgs e)
        {
            
            //GetHistory(tablelistcombo.SelectedItem.ToString());
        }
    }
}
