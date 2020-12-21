using IKAPP.BLL.DTO;
using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.BLL.Repository.Entity
{
   public class EmployeeRepository : Base.BaseRepository<Employee>
    {
        public void Update(Employee guncelle)
        {
            var bulunan = Find(guncelle.ID);
            bulunan.FirstName = guncelle.FirstName;
            bulunan.LastName = guncelle.LastName;
            bulunan.Adress = guncelle.Adress;
            bulunan.Phone = guncelle.Phone;
            bulunan.Email = guncelle.Email;
            bulunan.ImageURL = guncelle.ImageURL;
            Save();
        }

        public EmpOrderDTO empFind(int? ID)
        {
            if (ID != null)
            {
                var bul = (from e in this.GetAll()
                           where e.ID == ID
                           select new EmpOrderDTO
                           {
                               ID = e.ID,
                               Adress = e.Adress,
                               Email = e.Email,
                               FirstName = e.FirstName,
                               LastName = e.LastName,
                               Phone = e.Phone,
                               ImageURL = e.ImageURL,
                           }).SingleOrDefault();
                return bul;
            }
            else
            {
                return new EmpOrderDTO();
            }
        }

        public void MailUp(int ID)
        {
            var bul = Find(ID);
            bul.IsMail = true;
            Save();
        }
    
    }
}
