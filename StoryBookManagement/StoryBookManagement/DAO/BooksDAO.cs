using StoryBookManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryBookManagement.DAO
{
    public class BooksDAO
    {
         private static BooksDAO instance;

        public static BooksDAO Instance
        {
            get { if (instance == null)instance = new BooksDAO(); return BooksDAO.instance; }
            private set { BooksDAO.instance = value; }
        }
        private BooksDAO() { }

        public List<Books> GetBooksByCategoryID(int id)
        {
            List<Books> list = new List<Books>();

            string query = "Select * from Story where idCategory = "+ id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Books books = new Books(item);
                list.Add(books);
            }

            return list;
        }
        
    }
}
