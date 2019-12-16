using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryBookManagement.DTO
{
    class BillInfo
    {
        public BillInfo(int id, int billID, int storyID, int cuont)
        {
            this.ID = id;
            this.BillID = billID;
            this.StoryID = storyID;
            this.Count = count; 
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.StoryID = (int)row["idstory"];
            this.Count = (int)row["count"]; 
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private int storyID;

        public int StoryID
        {
            get { return storyID; }
            set { storyID = value; }
        }

        private int billID;

        public int BillID
        {
            get { return billID; }
            set { billID = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
