using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    class Log
    {

        private string id;
        private string time;
        private string userName;
        private string action;
        private string searchName;

        public Log()
        {

        }
        public Log(string id, string time, string userName, string action, string searchName)
        {
            this.id = id;
            this.time = time;
            this.userName = userName;
            this.action = action;
            this.searchName = searchName;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        public string SearchName
        {
            get { return searchName; }
            set { searchName = value; }
        }
    }
}
