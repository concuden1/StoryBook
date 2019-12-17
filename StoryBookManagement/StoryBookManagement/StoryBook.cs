using StoryBookManagement.DAO;
using StoryBookManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            LoadCategory();
            
        }
        #region Method
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";

        }

        void LoadBookListByCategoryID(int id)
        {
            List<Books> listBooks = BooksDAO.Instance.GetBooksByCategoryID(id);
            cbBook.DataSource = listBooks;
            cbBook.DisplayMember = "Name";
        }
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
                        btn.BackColor = Color.Green;
                        break;
                    default:
                        btn.BackColor = Color.Pink;
                        break;

                }

                flpBook.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvList.Items.Clear();
            List<StoryBookManagement.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByBook(id);
            float totalPrice = 0;
            foreach (StoryBookManagement.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.BookName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvList.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            txtTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        #endregion




        #region Events

        void btn_Click(object sender, EventArgs e)
        {
            int bookID = ((sender as Button).Tag as Book).ID;
            lsvList.Tag = (sender as Button).Tag;
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
       

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID; 

            LoadBookListByCategoryID(id);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Book book  = lsvList.Tag as Book;

            int idBill = BillDAO.Instance.GetUncheckBillIDByBookID(book.ID);
            int storyID = (cbBook.SelectedItem as Books).ID;
            int count = (int)nmBookCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(book.ID);

                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), storyID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, storyID, count);
            }
            ShowBill(book.ID);
        }


        #endregion
    }
}
