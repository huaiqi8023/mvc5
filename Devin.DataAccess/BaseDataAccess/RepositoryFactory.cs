using Devin.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devin.DataAccess.BaseDataAccess
{
    public static partial class RepositoryFactory
    {
        public static IUserRepository UserRepository
        {
            get
            {
                return new UserRepository();
            }
        }
    }
}
