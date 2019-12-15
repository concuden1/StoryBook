using StoryBookManagement.DAO;
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

namespace StoryBookManagement
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();

            LoadAccountList();
        }

        void LoadAccountList()
        {
            string connectionSTR = "Data Source=.\\sqlexpress;Initial Catalog=StoryBookManagement;Integrated Security=True";
            
            SqlConnection connection = new SqlConnection(connectionSTR);

            string query = "SELECT * FROM dbo.Account";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            DataTable data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);

            connection.Close();

            grdAccount.DataSource = data;
        }
            

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
