using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryBookManagement.DTO
{
    public class Bill
    {

        public Bill (int id, int status)
        {
            this.ID = id;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Status =(int)row["status"];
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
