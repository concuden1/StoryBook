using StoryBookManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryBookManagement.DAO
{
    public class StoryDAO
    {
        private static StoryDAO instance;

        public static StoryDAO Instance
        {
            get { if (instance == null) instance = new StoryDAO(); return StoryDAO.instance; }
            private set { StoryDAO.instance = value; }
        }

        public static int BookWidth = 80;
        public static int BookHeight = 80;

        private StoryDAO() { }

        public List<Book> LoadBookList()
        {
            List<Book> bookList = new List<Book>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetBookList");

            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);
                bookList.Add(book);
            }


            return bookList;
         
        }

    }
}
