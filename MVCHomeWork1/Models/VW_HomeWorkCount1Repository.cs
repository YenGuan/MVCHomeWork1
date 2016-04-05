using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCHomeWork1.Models
{   
	public  class VW_HomeWorkCount1Repository : EFRepository<VW_HomeWorkCount1>, IVW_HomeWorkCount1Repository
	{

	}

	public  interface IVW_HomeWorkCount1Repository : IRepository<VW_HomeWorkCount1>
	{

	}
}