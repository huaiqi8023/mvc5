  //引进TT模板的命名空间

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.IDataAccess;
using Devin.Models;
using Devin.IDataAccess.IBaseRepository;
using System.Data;
using System.Linq.Expressions;
using Devin.DataAccess.BaseDataAccess;
namespace Devin.DataAccess
{
    //一次跟数据库交互的会话
    //public partial class DbSession  //代表应用程序跟数据库之间的一次会话，也是数据库访问层的统一入口
    //{
		//从这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有表的对应的仓储显示出来

		
		public partial class UserRepository:BaseRepository<ty_pmi_user>,IUserRepository
		{
		}

		//}
}
