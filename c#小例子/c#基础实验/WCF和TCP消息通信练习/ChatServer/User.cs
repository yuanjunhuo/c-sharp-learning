using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class User
    {
        public string userName;
        public readonly IChatServiceCallback callback;

        public User(string userName, IChatServiceCallback callback)
        {
            this.userName = userName;
            this.callback = callback;
        }
    }
}
