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
        void LoadBookList()
        {
            string query = "select * from book";

            grdBook.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadAccountList()
        {
            string query = "EXEC dbo.USP_GetAccountByUserName @userName ";
            grdAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[]{"DLan"});
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
