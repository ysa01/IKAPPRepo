using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.BLL.Repository.Entity
{
    public class UserRepository : Base.BaseRepository<User>
    {
        public bool login(string username, string password)
        {
            bool rtn = table.Any(x => x.UserName == username && x.Password == password);
            if (rtn == true)
            {
                return true;
            }
            else return false;
           
        }

        public User FindUserName(string username)
        {
            return table.FirstOrDefault(x => x.UserName == username);
        }
    }
}
