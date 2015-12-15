using Devin.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Devin.DataAccess
{
    public static class DbSessionFactory
    {
        public static IDbSession GetCurrentSession()
        {
            IDbSession _dbSession = CallContext.GetData("DbSession") as DbSession;
            if (_dbSession == null)
            {
                _dbSession = new DbSession();
                CallContext.SetData("DbSession", _dbSession);
            }
            return _dbSession;
        }
    }
}
