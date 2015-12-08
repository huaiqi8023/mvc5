using Devin.IDataAccess.IBaseDataAccess;
using Devin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devin.IDataAccess
{
    public interface IUserRepository : IBaseRepository<UserInfoSet>
    {
    }
}
