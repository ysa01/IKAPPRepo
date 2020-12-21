using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.BLL.Repository.Entity
{
    public class CustomerRepository : Base.BaseRepository<Customer>
    {
        public void Update(Customer cust)
        {
            var bul = Find(cust.ID);
            bul.Adress = cust.Adress;
            bul.Email = cust.Email;
            bul.FirstName = cust.FirstName;
            bul.LastName = cust.LastName;
            bul.Phone = cust.Phone;
            Save();
        }

        public Customer PhoneSearch(string phn)
        {
            var bulunan = this.GetAll().Where(x => x.Phone == phn).SingleOrDefault();
            return bulunan;
        }
    }
}
