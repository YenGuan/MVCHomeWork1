using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCHomeWork1.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Find(int? id)
        {

            return this.All().FirstOrDefault(p => p.Id == id);
        }
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.已刪除 == false );
        }
        public IQueryable<客戶資料> All(bool showDelete)
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
        public override void Delete(客戶資料 entity)
        {
            entity.已刪除 = true;
       
        }
	}

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}