using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.Models;
using Devin.IDataAccess;
using Devin.DataAccess.BaseDataAccess;

namespace Devin.DataAccess
{
    public partial class UserRepository : BaseRepository<UserInfoSet>, IUserRepository
    {
    }
}
