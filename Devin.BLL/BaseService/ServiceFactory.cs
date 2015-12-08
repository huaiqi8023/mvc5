using Devin.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devin.BLL.BaseService
{
    public static  class ServiceFactory
    {
        public static IUserService UserService
        {
            get
            {
                return new UserService();
            }
        }
    }
}
