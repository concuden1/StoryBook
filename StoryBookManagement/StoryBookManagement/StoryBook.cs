using StoryBookManagement.DAO;
using StoryBookManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoryBookManagement
{
    public partial class StoryBook : Form
    {
        public StoryBook()
        {
            InitializeComponent();

            LoadStory();
            
        }
        #region Method
        void LoadStory()
        {
            List<Book> bookList = StoryDAO.Instance.LoadBookList();

            foreach (Book item in bookList)
            {
                Button btn = new Button() { Width = StoryDAO.BookWidth, Height = StoryDAO.BookHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Pink;
                        break;
                    default:
                        btn.BackColor = Color.Aqua;
                        break;

                }

                flpBook.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvList.Items.Clear();
            List<StoryBookManagement.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByBook(id);

            foreach (StoryBookManagement.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.BookName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                lsvList.Items.Add(lsvItem);
            }
        }

        #endregion




        #region Events

        void btn_Click(object sender, EventArgs e)
        {
            int bookID = ((sender as Button).Tag as Book).ID;
            ShowBill(bookID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfile f = new AccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }
        #endregion
    }
}
