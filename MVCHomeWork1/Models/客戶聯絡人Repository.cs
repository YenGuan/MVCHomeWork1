using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCHomeWork1.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public 客戶聯絡人 Find(int? id)
        {

            return this.All().FirstOrDefault(p => p.已刪除 == false);
        }
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.已刪除 == false);
        }
        public IQueryable<客戶聯絡人> All(bool showDelete)
        {
            if (showDelete == true)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }
        public override void Delete(客戶聯絡人 entity)
        {
            entity.已刪除 = true;
            
        }
	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}