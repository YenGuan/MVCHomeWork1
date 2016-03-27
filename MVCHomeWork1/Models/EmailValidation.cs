using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHomeWork1.Models
{
    public class EmailValidation
    {
       
        public bool validation(int p_id,int p_custid ,string p_mail) 
        {
            客戶資料Entities db = new 客戶資料Entities();
            var data = db.客戶聯絡人.AsQueryable();
            data.Where(p => p.Id != p_id).Where(p => p.客戶Id == p_custid).Where(p => p.Email == p_mail);
            if (data.Count() > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}